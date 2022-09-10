namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Cpu
{
    [JsonConstructor]
    public Cpu(
        double averageLoad,
        double temperature)
    {
        this.AverageLoad = averageLoad;
        this.Temperature = temperature;
    }

    public double AverageLoad { get; }

    public double Temperature { get; }
}