namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Wifi
{
    [JsonConstructor]
    public Wifi(
        int? channel,
        int? frequency,
        object linkSpeedMbps,
        int? signalQuality,
        int? signalStrength)
    {
        this.Channel = channel;
        this.Frequency = frequency;
        this.LinkSpeedMbps = linkSpeedMbps;
        this.SignalQuality = signalQuality;
        this.SignalStrength = signalStrength;
    }

    public int? Channel { get; }

    public int? Frequency { get; }

    public object LinkSpeedMbps { get; }

    public int? SignalQuality { get; }

    public int? SignalStrength { get; }
}