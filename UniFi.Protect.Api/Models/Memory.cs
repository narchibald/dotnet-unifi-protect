namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Memory
{
    [JsonConstructor]
    public Memory(
        int available,
        int free,
        int total)
    {
        this.Available = available;
        this.Free = free;
        this.Total = total;
    }

    public int Available { get; }

    public int Free { get; }

    public int Total { get; }
}