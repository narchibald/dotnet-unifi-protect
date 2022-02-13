using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class EventStats
{
    [JsonConstructor]
    public EventStats(
        Motion motion,
        Smart smart)
    {
        this.Motion = motion;
        this.Smart = smart;
    }

    public Motion Motion { get; }

    public Smart Smart { get; }
}