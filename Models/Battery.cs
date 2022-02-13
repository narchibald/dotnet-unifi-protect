namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Battery
{
    [JsonConstructor]
    public Battery(object percentage, bool isCharging, string sleepState)
    {
        this.Percentage = percentage;
        this.IsCharging = isCharging;
        this.SleepState = sleepState;
    }

    [JsonProperty("percentage")]
    public object Percentage { get; }

    [JsonProperty("isCharging")]
    public bool IsCharging { get; }

    [JsonProperty("sleepState")]
    public string SleepState { get; }
}