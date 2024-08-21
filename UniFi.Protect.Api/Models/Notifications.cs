namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Notifications
{
    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("detectionNotifications")]
    public DetectionNotifications DetectionNotifications { get; set; }

    [JsonProperty("systemEventNotifications")]
    public SystemEventNotifications SystemEventNotifications { get; set; }
}