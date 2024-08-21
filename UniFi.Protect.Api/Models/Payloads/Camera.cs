namespace UniFi.Protect.Api.Models.Payloads;

using Newtonsoft.Json;

[PayloadIdentifier("camera")]
public class Camera : Update
{
    [JsonProperty("voltage")]
    public decimal Voltage { get; set; }

    [JsonProperty("nvrMac")]
    public string NvrMac { get; set; }
}