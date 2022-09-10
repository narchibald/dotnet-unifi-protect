namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class PirSettings
{
    [JsonConstructor]
    public PirSettings(
        int pirSensitivity,
        int pirMotionClipLength,
        int timelapseFrameInterval,
        int timelapseTransferInterval)
    {
        this.PirSensitivity = pirSensitivity;
        this.PirMotionClipLength = pirMotionClipLength;
        this.TimelapseFrameInterval = timelapseFrameInterval;
        this.TimelapseTransferInterval = timelapseTransferInterval;
    }

    public int PirSensitivity { get; }

    public int PirMotionClipLength { get; }

    public int TimelapseFrameInterval { get; }

    public int TimelapseTransferInterval { get; }
}