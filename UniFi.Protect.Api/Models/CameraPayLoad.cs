namespace UniFi.Protect.Api.Models;

public class CameraPayLoad
{
    public List<object>? RecordingSchedules { get; init; }

    public Stats? Stats { get; init; }

    public WifiConnectionState? WifiConnectionState { get; init; }

    public double? Voltage { get; init; }

    public long? UpSince { get; init; }

    public long? Uptime { get; init; }

    public long? LastSeen { get; init; }

    public long? LastRing { get; init; }
}