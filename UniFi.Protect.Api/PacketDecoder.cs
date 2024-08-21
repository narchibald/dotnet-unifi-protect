namespace UniFi.Protect.Api;

#if NET6_0_OR_GREATER
using System.IO.Compression;
#else
using Ionic.Zlib;
#endif
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Text;
using Extensions;
using Models;
using Models.Payloads;

public interface IPacketDecoder
{
    Task<NvrUpdatePacket?> Decode(ArraySegment<byte> packet);
}

public class PacketDecoder : IPacketDecoder
{
    private const int UpdatePacketHeaderSize = 8;

    private static readonly Dictionary<string, Type> ModelTypes;

    static PacketDecoder()
    {
        ModelTypes = typeof(PacketDecoder).Assembly.ExportedTypes
            .SelectMany(x => x.GetCustomAttributes(typeof(PayloadIdentifierAttribute), false).Select(a => new { Attribute = (PayloadIdentifierAttribute)a, Type = x }))
            .ToDictionary(x => x.Attribute!.ModelKey, v => v.Type, StringComparer.InvariantCultureIgnoreCase);
    }

    /*
     *  ### Packet Structure ###
     *
     * Header Frame 1 (8 bytes)
     * Action Frame (Size From Header 1)
     * Header Frame 2 (8 bytes)
     * Data Frame (Size From Header 2)
     *
     * Byte Offset | Description     | Bits | Values
     * 0           | Packet Type     | 8    | 1 - action frame, 2 - payload frame.
     * 1           | Payload Format  | 8    | 1 - JSON object, 2 - UTF8-encoded string, 3 - Node Buffer.
     * 2           | Deflated        | 8    | 0 - uncompressed, 1 - deflated / compressed (zlib-based).
     * 3           | Unknown         | 8    | Always 0. Possibly reserved for future use by Ubiquiti?
     * 4-7         | Payload Size    | 32   | Size of payload in network-byte order (big endian).
     */
    public async Task<NvrUpdatePacket?> Decode(ArraySegment<byte> packet)
    {
        // What we need to do here is to split this packet into the header and payload, and decode them.

        // The fourth byte holds our payload size. When you add the payload size to our header frame size, you get the location of the
        // data header frame.
        var dataOffset = packet.ReadBeInt((int)UpdatePacketHeader.PayloadSize) + UpdatePacketHeaderSize;
        if (packet.Count != (dataOffset + UpdatePacketHeaderSize + packet.ReadBeInt(dataOffset + (int)UpdatePacketHeader.PayloadSize)))
        {
            throw new IndexOutOfRangeException("Packet length doesn't match header information.");
        }

        var action = await DecodeAction(packet.Slice(0, dataOffset));
        var payload = await DecodePayload(packet.Slice(dataOffset));

        if (action is null || payload is null)
        {
            return null;
        }

        return payload.Format switch
        {
            UpdatePayloadType.Json => ParseJsonPayload(action, (JObject)payload.Data),
            UpdatePayloadType.String => new NvrUpdatePacket<string>(action, payload.Format, (string)payload.Data),
            UpdatePayloadType.Buffer => new NvrUpdatePacket<byte[]>(action, payload.Format, (byte[])payload.Data),
            _ => null
        };
    }

    private NvrUpdatePacket ParseJsonPayload(NvrUpdateEventAction action, JObject data)
    {
        if (ModelTypes.TryGetValue(action.ModelKey, out var parseType))
        {
            var typedData = data.ToObject(parseType);
            var typedUpdatePacketType = typeof(NvrUpdatePacket<>).MakeGenericType(parseType);
            return (NvrUpdatePacket)Activator.CreateInstance(typedUpdatePacketType, action, UpdatePayloadType.Json, typedData)!;
        }
        else
        {
            return new NvrUpdatePacket<JObject>(action, UpdatePayloadType.Json, data);
        }
    }

    private static async Task<NvrUpdateEventAction?> DecodeAction(ArraySegment<byte> data)
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

        var json = Encoding.UTF8.GetString(payload.ToArray());
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
#if NET6_0_OR_GREATER
        using var decompressor = new ZLibStream(compressedStream, CompressionMode.Decompress);
#else
        await using var decompressor = new ZlibStream(compressedStream, CompressionMode.Decompress);
#endif

        await decompressor.CopyToAsync(uncompressedStream);

        return new ArraySegment<byte>(uncompressedStream.ToArray());
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