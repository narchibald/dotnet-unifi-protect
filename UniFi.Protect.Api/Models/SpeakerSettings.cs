namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

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