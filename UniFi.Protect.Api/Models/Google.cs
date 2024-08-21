using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class Google
{
    [JsonProperty("email")]
    public string? Email { get; set; }
}