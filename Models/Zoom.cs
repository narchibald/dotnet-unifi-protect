namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Zoom
{
    [JsonConstructor]
    public Zoom(
        Steps steps,
        Degrees degrees)
    {
        this.Steps = steps;
        this.Degrees = degrees;
    }

    public Steps Steps { get; }

    public Degrees Degrees { get; }
}