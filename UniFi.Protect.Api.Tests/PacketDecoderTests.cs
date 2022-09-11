namespace UniFi.Protect.Api.Tests;
public class PacketDecoderTests
{
    [Theory]
    [InlineData("AQEAAAAAAJF7ImFjdGlvbiI6ImFkZCIsIm5ld1VwZGF0ZUlkIjoiM2ViMzA1ZGQtMDA4Yy00NWQ5LWE2YjEtZTI5N2EyNTUwMjlmIiwibW9kZWxLZXkiOiJldmVudCIsImlkIjoiNjMxZDI1NDQwMmY0OWEwMzg3MGNlOTRjIiwibWFjIjoiIiwiX2lzRXZlbnQiOnRydWV9AgEAAAAAAPZ7InR5cGUiOiJhY2Nlc3MiLCJzdGFydCI6MTY2Mjg1NDQ2ODc1NSwic2NvcmUiOjAsInNtYXJ0RGV0ZWN0VHlwZXMiOltdLCJzbWFydERldGVjdEV2ZW50cyI6W10sIm1ldGFkYXRhIjp7ImNsaWVudFBsYXRmb3JtIjoid2ViIn0sImNhbWVyYSI6bnVsbCwicGFydGl0aW9uIjpudWxsLCJ1c2VyIjoiNjFkYmVlMTgwMjRkYjMwMzg3MDAxMWY0IiwiaWQiOiI2MzFkMjU0NDAyZjQ5YTAzODcwY2U5NGMiLCJtb2RlbEtleSI6ImV2ZW50In0=")]
    public async Task DecodeUpdatePacket(string base64Data)
    {
        // Arrange
        var data = new ArraySegment<byte>(Convert.FromBase64String(base64Data));
        var decoder = new PacketDecoder();

        // Act 
        var updatePacket = await decoder.Decode(data);

        // Assert
        Assert.NotNull(updatePacket);
    }
}