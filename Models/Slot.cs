using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class Slot
{
    [JsonConstructor]
    public Slot(
        List<string> cameras,
        string cycleMode,
        int cycleInterval)
    {
        this.Cameras = cameras;
        this.CycleMode = cycleMode;
        this.CycleInterval = cycleInterval;
    }

    public IReadOnlyList<string> Cameras { get; }

    public string CycleMode { get; }

    public int CycleInterval { get; }
}