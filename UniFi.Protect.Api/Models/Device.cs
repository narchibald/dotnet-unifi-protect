namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Device
{
    [JsonConstructor]
    public Device(
        string model,
        long size,
        string healthy)
    {
        this.Model = model;
        this.Size = size;
        this.Healthy = healthy;
    }

    public string Model { get; }

    public long Size { get; }

    public string Healthy { get; }
}