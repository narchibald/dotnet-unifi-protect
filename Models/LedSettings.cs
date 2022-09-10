namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class LedSettings
{
    [JsonConstructor]
    public LedSettings(
        bool isEnabled,
        int blinkRate)
    {
        this.IsEnabled = isEnabled;
        this.BlinkRate = blinkRate;
    }

    public bool IsEnabled { get; }

    public int BlinkRate { get; }
}