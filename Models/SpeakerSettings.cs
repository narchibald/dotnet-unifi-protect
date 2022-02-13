using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class SpeakerSettings
{
    [JsonConstructor]
    public SpeakerSettings(
        bool isEnabled,
        bool areSystemSoundsEnabled,
        int volume)
    {
        this.IsEnabled = isEnabled;
        this.AreSystemSoundsEnabled = areSystemSoundsEnabled;
        this.Volume = volume;
    }

    public bool IsEnabled { get; }

    public bool AreSystemSoundsEnabled { get; }

    public int Volume { get; }
}