namespace UniFi.Protect.Api.Models.Payloads;

using Newtonsoft.Json;
using Converters;

[PayloadIdentifier("nvr")]
public class Nvr : Update
{
    [JsonProperty("uptime")]
    [JsonConverter(typeof(UnixTimeMillisecondsConverter))]
    public DateTimeOffset Uptime { get; set; }

    [JsonProperty("lastSeen")]
    [JsonConverter(typeof(UnixTimeMillisecondsConverter))]
    public DateTimeOffset LastSeen { get; set; }
}