namespace UniFi.Protect.Api;

public interface IProtect
{
    event Action<NvrUpdatePacket>? Updated;

    string NvrName { get; }

    Task<bool> Connect(bool autoRefresh = false);

    Task<bool> RefreshDevices();
}