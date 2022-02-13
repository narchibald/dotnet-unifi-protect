namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class MotionNotifications
{
    [JsonConstructor]
    public MotionNotifications(
        Trigger trigger,
        List<object> cameras,
        List<object> doorbells,
        List<object> lights,
        List<object> doorlocks,
        List<object> sensors)
    {
        this.Trigger = trigger;
        this.Cameras = cameras;
        this.Doorbells = doorbells;
        this.Lights = lights;
        this.Doorlocks = doorlocks;
        this.Sensors = sensors;
    }

    public Trigger Trigger { get; }

    public IReadOnlyList<object> Cameras { get; }

    public IReadOnlyList<object> Doorbells { get; }

    public IReadOnlyList<object> Lights { get; }

    public IReadOnlyList<object> Doorlocks { get; }

    public IReadOnlyList<object> Sensors { get; }
}