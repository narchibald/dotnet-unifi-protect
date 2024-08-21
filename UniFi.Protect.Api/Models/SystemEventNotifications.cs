namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class SystemEventNotifications
{
    [JsonProperty("deviceIssue")]
    public List<object> DeviceIssue { get; set; }

    [JsonProperty("applicationIssue")]
    public List<string> ApplicationIssue { get; set; }

    [JsonProperty("deviceAdoptedRemoved")]
    public List<object> DeviceAdoptedRemoved { get; set; }

    [JsonProperty("deviceLimitationReached")]
    public List<object> DeviceLimitationReached { get; set; }

    [JsonProperty("deviceDiscovery")]
    public List<string> DeviceDiscovery { get; set; }

    [JsonProperty("deviceUpdateStatus")]
    public List<object> DeviceUpdateStatus { get; set; }

    [JsonProperty("adminAccess")]
    public List<object> AdminAccess { get; set; }

    [JsonProperty("adminChangeSettings")]
    public List<object> AdminChangeSettings { get; set; }

    [JsonProperty("adminRecordingClipsManipulations")]
    public List<object> AdminRecordingClipsManipulations { get; set; }

    [JsonProperty("adminGeolocation")]
    public List<object> AdminGeolocation { get; set; }
}