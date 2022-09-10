namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class ResolutionDistribution
{
    [JsonConstructor]
    public ResolutionDistribution(
        string resolution,
        object size,
        double percentage)
    {
        this.Resolution = resolution;
        this.Size = size;
        this.Percentage = percentage;
    }

    public string Resolution { get; }

    public object Size { get; }

    public double Percentage { get; }
}