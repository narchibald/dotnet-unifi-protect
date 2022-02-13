namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Tmpfs
{
    [JsonConstructor]
    public Tmpfs(
        int available,
        int total,
        int used,
        string path)
    {
        this.Available = available;
        this.Total = total;
        this.Used = used;
        this.Path = path;
    }

    public int Available { get; }

    public int Total { get; }

    public int Used { get; }

    public string Path { get; }
}