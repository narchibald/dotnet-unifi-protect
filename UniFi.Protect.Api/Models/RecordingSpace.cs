namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class RecordingSpace
{
    [JsonConstructor]
    public RecordingSpace(
        long total,
        long? used,
        long available)
    {
        this.Total = total;
        this.Used = used;
        this.Available = available;
    }

    public long Total { get; }

    public long? Used { get; }

    public long Available { get; }
}