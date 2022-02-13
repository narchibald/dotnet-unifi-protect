namespace UniFi.Protect.Api;

using System.Net;
using System.Net.WebSockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UniFi.Protect.Api.Extensions;
using UniFi.Protect.Api.Models;
#if NET6_0
using System.IO.Compression;	
#else
using Ionic.Zlib;
#endif

public class WebSocket : IWebSocket
{
    private const int UpdatePacketHeaderSize = 8;
    private readonly IProtectConfiguration configuration;
    private readonly ISharedCookieContainer cookieContainer;
    private readonly ILogger<WebSocket> logger;
    private ClientWebSocket? websocket;
    private CancellationTokenSource? cancellationToken;
    private Task? listenerTask;

    public WebSocket(IProtectConfiguration configuration, ISharedCookieContainer cookieContainer, ILogger<WebSocket> logger)
    {
        this.configuration = configuration;
        this.cookieContainer = cookieContainer;
        this.logger = logger;
    }

    public event Action<NvrUpdatePacket>? Updated;

    public bool IsConnected => websocket?.State == WebSocketState.Open;

    public async Task<bool> Connect(Uri uri)
    {
        try
        {
            CreateWebSocket();
            await this.websocket.ConnectAsync(uri, this.cancellationToken.Token);
            if (this.websocket.State != WebSocketState.Open)
            {
                logger.LogDebug("Unable to connect to the realtime update events API. Will retry again later.");
                this.websocket?.Dispose();
                this.websocket = null;
                return false;
            }

            this.listenerTask = Task.Factory.StartNew(
                    async (o) => await Listen((CancellationToken)o!),
                    this.cancellationToken.Token,
                    this.cancellationToken.Token,
                    TaskCreationOptions.LongRunning,
                    TaskScheduler.Default)
                .Unwrap();

            return true;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error connecting to the realtime update events API");
        }

        return false;
    }

    private void CreateWebSocket()
    {
        this.websocket = new ClientWebSocket();
        this.cancellationToken = new CancellationTokenSource();
        this.websocket.Options.Cookies = this.cookieContainer.Container;
        this.websocket.Options.SetRequestHeader("rejectUnauthorized", "true");
        if (this.configuration.AllowUntrustedCerts)
        {
            this.websocket.Options.RemoteCertificateValidationCallback += (sender, cert, cetChain, policyErrors) => true;
        }
    }

    private static async Task<NvrUpdatePacket?> DecodeUpdatePacket(ArraySegment<byte> packet)
    {
        // What we need to do here is to split this packet into the header and payload, and decode them.

        // The fourth byte holds our payload size. When you add the payload size to our header frame size, you get the location of the
        // data header frame.
        var dataOffset = packet.ReadBeInt((int)UpdatePacketHeader.PayloadSize) + UpdatePacketHeaderSize;
        if (packet.Count != (dataOffset + UpdatePacketHeaderSize + packet.ReadBeInt(dataOffset + (int)UpdatePacketHeader.PayloadSize)))
        {
            throw new IndexOutOfRangeException("Packet length doesn't match header information.");
        }

        var action = await DecodeUpdateAction(packet.Slice(0, dataOffset));
        var payload = await DecodePayload(packet.Slice(dataOffset));

        if (action is null || payload is null)
        {
            return null;
        }

        return payload.Format switch
        {
            UpdatePayloadType.Json => new NvrUpdatePacket<JObject>(action, payload.Format, (JObject)payload.Data),
            UpdatePayloadType.String => new NvrUpdatePacket<string>(action, payload.Format, (string)payload.Data),
            UpdatePayloadType.Buffer => new NvrUpdatePacket<byte[]>(action, payload.Format, (byte[])payload.Data),
            _ => null
        };
    }

    private static async Task<NvrUpdateEventAction?> DecodeUpdateAction(ArraySegment<byte> data)
    {
        var frameType = (UpdatePacketType)data.ReadUInt8((int)UpdatePacketHeader.Type);
        if (frameType != UpdatePacketType.Action)
        {
            throw new FormatException("Expected data to be ACTION");
        }

        var payloadFormat = (UpdatePayloadType)data.ReadUInt8((int)UpdatePacketHeader.PayloadFormat);

        var compressed = data.ReadUInt8((int)UpdatePacketHeader.Deflated) == (byte)1;

        var payload = data.Slice(UpdatePacketHeaderSize);
        if (compressed)
        {
            payload = await Inflate(payload);
        }

        if (payloadFormat != UpdatePayloadType.Json)
        {
            return null;
        }

        var json = Encoding.UTF8.GetString(payload.Array!);
        return JsonConvert.DeserializeObject<NvrUpdateEventAction>(json);
    }

    private static async Task<PayLoadData?> DecodePayload(ArraySegment<byte> packet)
    {
        var frameType = (UpdatePacketType)packet.ReadUInt8((int)UpdatePacketHeader.Type);
        if (frameType != UpdatePacketType.Payload)
        {
            throw new FormatException("Expected data to be PAYLOAD");
        }

        var payloadFormat = (UpdatePayloadType)packet.ReadUInt8((int)UpdatePacketHeader.PayloadFormat);
        var compressed = packet.ReadUInt8((int)UpdatePacketHeader.Deflated) != 0;

        var payload = packet.Slice(UpdatePacketHeaderSize);
        if (compressed)
        {
            payload = await Inflate(payload);
        }

        object? data = payloadFormat switch
        {
            UpdatePayloadType.Json => JObject.Parse(Encoding.UTF8.GetString(payload.ToArray())),
            UpdatePayloadType.String => Encoding.UTF8.GetString(payload.ToArray()),
            UpdatePayloadType.Buffer => payload.ToArray(),
            _ => null
        };

        return data != null ? new PayLoadData(payloadFormat, data) : null;
    }

    private static async Task<ArraySegment<byte>> Inflate(ArraySegment<byte> deflatedData)
    {
        await using var compressedStream = new MemoryStream(deflatedData.ToArray());
        await using var uncompressedStream = new MemoryStream();
#if NET6_0
        using var decompressor = new ZLibStream(compressedStream, CompressionMode.Decompress);
#else
        await using var decompressor = new ZlibStream(compressedStream, CompressionMode.Decompress);
#endif

        await decompressor.CopyToAsync(uncompressedStream);

        return new ArraySegment<byte>(uncompressedStream.ToArray());
    }

    private async Task Listen(CancellationToken cancellation)
    {
        while (!cancellation.IsCancellationRequested)
        {
            var rcvBuffer = new ArraySegment<byte>(new byte[8192]);
            var rcvResult = await this.websocket.ReceiveAsync(rcvBuffer, cancellation);
            switch (rcvResult.MessageType)
            {
                case WebSocketMessageType.Close:
                    logger.LogDebug("Sadness web socket closed");
                    return;
                case WebSocketMessageType.Binary:
                    {
                        var updatePacket = await DecodeUpdatePacket(rcvBuffer.Slice(0, rcvResult.Count));
                        if (updatePacket != null)
                        {
                            this.Updated?.Invoke(updatePacket);
                        }
                    }

                    break;
                default:
                    logger.LogDebug($"Sadness web socket message type not handled. type: {rcvResult.MessageType}");
                    break;
            }
        }
    }

    private class PayLoadData
    {
        [JsonConstructor]
        public PayLoadData(UpdatePayloadType format, object data)
        {
            this.Format = format;
            this.Data = data;
        }

        public UpdatePayloadType Format { get; }

        public object Data { get; }
    }
}
