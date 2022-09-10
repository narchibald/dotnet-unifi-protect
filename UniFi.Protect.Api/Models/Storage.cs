namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Storage
{
    [JsonConstructor]
    public Storage(
        long used,
        double rate,
        long available,
        bool isRecycling,
        long size,
        string type,
        List<Device> devices)
    {
        this.Used = used;
        this.Rate = rate;
        this.Available = available;
        this.IsRecycling = isRecycling;
        this.Size = size;
        this.Type = type;
        this.Devices = devices;
    }

    public long Used { get; }

    public double Rate { get; }

    public long Available { get; }

    public bool IsRecycling { get; }

    public long Size { get; }

    public string Type { get; }

    public IReadOnlyList<Device> Devices { get; }
}