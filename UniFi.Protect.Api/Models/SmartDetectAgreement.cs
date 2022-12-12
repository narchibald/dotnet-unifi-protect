namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class SmartDetectAgreement
{
    [JsonConstructor]
    public SmartDetectAgreement(
        string status,
        long? lastUpdateAt)
    {
        this.Status = status;
        this.LastUpdateAt = lastUpdateAt;
    }

    public string Status { get; }

    public long? LastUpdateAt { get; }
}