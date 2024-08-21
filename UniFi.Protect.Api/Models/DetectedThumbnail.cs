namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;
using Converters;
public class DetectedThumbnail
{
    [JsonProperty("clockBestWall")]
    [JsonConverter(typeof(UnixTimeMillisecondsConverter))]
    public DateTimeOffset ClockBestWall { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    [JsonProperty("croppedId")]
    public string CroppedId { get; set; } = string.Empty;
}