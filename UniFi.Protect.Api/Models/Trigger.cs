namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Trigger
{
    [JsonConstructor]
    public Trigger(
        string when,
        string location,
        List<object> schedules)
    {
        this.When = when;
        this.Location = location;
        this.Schedules = schedules;
    }

    public string When { get; }

    public string Location { get; }

    public IReadOnlyList<object> Schedules { get; }
}