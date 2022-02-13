namespace UniFi.Protect.Api;

public interface IWebSocket
{
    event Action<NvrUpdatePacket>? Updated;

    bool IsConnected { get; }

    Task<bool> Connect(Uri uri);
}