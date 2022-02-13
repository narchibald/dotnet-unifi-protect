namespace UniFi.Protect.Api.Extensions;

using System.Buffers.Binary;

public static class ArraySegmentExtensions
{
    public static int ReadBeInt(this ArraySegment<byte> src, int position)
    {
        return BinaryPrimitives.ReadInt32BigEndian(new ReadOnlySpan<byte>(src.Slice(position, 4).ToArray()));
    }

    public static byte ReadUInt8(this ArraySegment<byte> src, int position)
    {
        return src.Slice(position, 1).ToArray().First();
    }
}