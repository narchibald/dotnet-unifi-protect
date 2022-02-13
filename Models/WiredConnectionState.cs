namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class WiredConnectionState
{
    [JsonConstructor]
    public WiredConnectionState(
        object phyRate)
    {
        this.PhyRate = phyRate;
    }

    public object PhyRate { get; }
}