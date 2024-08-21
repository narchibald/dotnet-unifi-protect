namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class OneDrive
{
    [JsonProperty("email")]
    public string? Email { get; set; }
}