namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class SystemInfo
{
    [JsonConstructor]
    public SystemInfo(
        Cpu cpu,
        Memory memory,
        Storage storage,
        Tmpfs tmpfs)
    {
        this.Cpu = cpu;
        this.Memory = memory;
        this.Storage = storage;
        this.Tmpfs = tmpfs;
    }

    public Cpu Cpu { get; }

    public Memory Memory { get; }

    public Storage Storage { get; }

    public Tmpfs Tmpfs { get; }
}