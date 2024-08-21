namespace UniFi.Protect.Api.Models.Payloads;

using Newtonsoft.Json;
using Converters;

[PayloadIdentifier("event")]
public class Event : Update, IEvent
{
    [JsonProperty("type")]
    public EventType Type { get; set; }

    [JsonProperty("start")]
    [JsonConverter(typeof(UnixTimeMillisecondsConverter))]
    public DateTimeOffset Start { get; set; }

    [JsonProperty("end")]
    [JsonConverter(typeof(UnixTimeMillisecondsConverter))]
    public DateTimeOffset? End { get; set; }

    [JsonProperty("score")]
    public int Score { get; set; }

    [JsonProperty("smartDetectTypes")]
    public List<DetectionType> SmartDetectTypes { get; set; } = new ();

    [JsonProperty("smartDetectEvents")]
    public List<string> SmartDetectEvents { get; set; } = new ();

    [JsonProperty("metadata")]
    public Metadata? Metadata { get; set; }

    [JsonProperty("camera")]
    public string? Camera { get; set; }

    [JsonProperty("partition")]
    public object? Partition { get; set; }

    [JsonProperty("user")]
    public string? User { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}