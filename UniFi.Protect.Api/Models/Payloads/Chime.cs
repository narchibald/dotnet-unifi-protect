namespace UniFi.Protect.Api.Models.Payloads;

using Newtonsoft.Json;

[PayloadIdentifier("chime")]
public class Chime : Update
{
    [JsonProperty("cameraIds")]
    public List<string> CameraIds { get; set; } = new ();

    [JsonProperty("nvrMac")]
    public string NvrMac { get; set; } = string.Empty;
}