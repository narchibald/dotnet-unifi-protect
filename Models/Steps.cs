using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class Steps
{
    [JsonConstructor]
    public Steps(
        object max,
        object min,
        object step)
    {
        this.Max = max;
        this.Min = min;
        this.Step = step;
    }

    public object Max { get; }

    public object Min { get; }

    public object Step { get; }
}