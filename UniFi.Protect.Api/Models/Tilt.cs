namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Tilt
{
    [JsonConstructor]
    public Tilt(
        Steps steps,
        Degrees degrees)
    {
        this.Steps = steps;
        this.Degrees = degrees;
    }

    public Steps Steps { get; }

    public Degrees Degrees { get; }
}