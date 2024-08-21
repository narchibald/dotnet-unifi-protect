namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Metadata
{
    [JsonProperty("userName")]
    public string? UserName { get; set; }

    [JsonProperty("clientPlatform")]
    public string? ClientPlatform { get; set; }

    [JsonProperty("detectedThumbnails")]
    public List<DetectedThumbnail>? DetectedThumbnails { get; set; }
}