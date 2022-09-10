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
    private readonly IProtectConfiguration configuration;
    private readonly ISharedCookieContainer cookieContainer;
    private readonly IPacketDecoder packetDecoder;
    private readonly ILogger<WebSocket> logger;
    private ClientWebSocket? websocket;
    private CancellationTokenSource? cancellationToken;
    private Task? listenerTask;

    public WebSocket(IProtectConfiguration configuration, ISharedCookieContainer cookieContainer, IPacketDecoder packetDecoder, ILogger<WebSocket> logger)
    {
        this.configuration = configuration;
        this.cookieContainer = cookieContainer;
        this.packetDecoder = packetDecoder;
        this.logger = logger;
    }

    public event Action<NvrUpdatePacket>? Updated;

    public bool IsConnected => websocket?.State == WebSocketState.Open;

    public async Task<bool> Connect(Uri uri)
    {
        try
        {
            CreateWebSocket();
            await this.websocket!.ConnectAsync(uri, this.cancellationToken!.Token);
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

    private async Task Listen(CancellationToken cancellation)
    {
        while (!cancellation.IsCancellationRequested)
        {
            var rcvBuffer = new ArraySegment<byte>(new byte[8192]);
            var rcvResult = await this.websocket!.ReceiveAsync(rcvBuffer, cancellation);
            switch (rcvResult.MessageType)
            {
                case WebSocketMessageType.Close:
                    logger.LogDebug("Sadness web socket closed");
                    return;
                case WebSocketMessageType.Binary:
                    {
                        var updatePacket = await packetDecoder.Decode(rcvBuffer.Slice(0, rcvResult.Count));
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
}
