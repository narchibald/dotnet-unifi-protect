namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;
using Payloads;

public class CloudProviders
{
    [JsonProperty("google")]
    public Google Google { get; set; }

    [JsonProperty("oneDrive")]
    public OneDrive OneDrive { get; set; }
}