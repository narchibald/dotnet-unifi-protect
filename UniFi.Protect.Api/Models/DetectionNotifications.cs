namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class DetectionNotifications
{
    [JsonProperty("ring")]
    public List<string> Ring { get; set; }

    [JsonProperty("motion")]
    public List<object> Motion { get; set; }

    [JsonProperty("person")]
    public List<object> Person { get; set; }

    [JsonProperty("vehicle")]
    public List<object> Vehicle { get; set; }

    [JsonProperty("animal")]
    public List<object> Animal { get; set; }

    [JsonProperty("package")]
    public List<object> Package { get; set; }

    [JsonProperty("alarmSmokeCmonx")]
    public List<object> AlarmSmokeCmonx { get; set; }

    [JsonProperty("alarmSmoke")]
    public List<object> AlarmSmoke { get; set; }

    [JsonProperty("alarmCmonx")]
    public List<object> AlarmCmonx { get; set; }

    [JsonProperty("alarmSiren")]
    public List<object> AlarmSiren { get; set; }

    [JsonProperty("alarmBabyCry")]
    public List<object> AlarmBabyCry { get; set; }

    [JsonProperty("alarmSpeak")]
    public List<object> AlarmSpeak { get; set; }

    [JsonProperty("alarmBark")]
    public List<object> AlarmBark { get; set; }

    [JsonProperty("alarmBurglar")]
    public List<object> AlarmBurglar { get; set; }

    [JsonProperty("alarmCarHorn")]
    public List<object> AlarmCarHorn { get; set; }

    [JsonProperty("alarmGlassBreak")]
    public List<object> AlarmGlassBreak { get; set; }

    [JsonProperty("sensorAlarm")]
    public List<object> SensorAlarm { get; set; }

    [JsonProperty("batteryStatus")]
    public List<object> BatteryStatus { get; set; }

    [JsonProperty("doorlockOpen")]
    public List<object> DoorlockOpen { get; set; }

    [JsonProperty("doorlockClosed")]
    public List<object> DoorlockClosed { get; set; }

    [JsonProperty("extremeValues")]
    public List<string> ExtremeValues { get; set; }

    [JsonProperty("waterLeak")]
    public List<object> WaterLeak { get; set; }

    [JsonProperty("sensorEntryStateChange")]
    public List<object> SensorEntryStateChange { get; set; }

    [JsonProperty("trigger")]
    public Trigger Trigger { get; set; }

    [JsonProperty("cameras")]
    public List<object> Cameras { get; set; }

    [JsonProperty("doorbells")]
    public List<object> Doorbells { get; set; }

    [JsonProperty("lights")]
    public List<object> Lights { get; set; }

    [JsonProperty("doorlocks")]
    public List<object> Doorlocks { get; set; }

    [JsonProperty("sensors")]
    public List<object> Sensors { get; set; }
}