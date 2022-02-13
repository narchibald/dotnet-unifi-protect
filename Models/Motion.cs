namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Motion
{
    [JsonConstructor]
    public Motion(
        int today,
        int average,
        List<int> lastDays,
        List<int> recentHours)
    {
        this.Today = today;
        this.Average = average;
        this.LastDays = lastDays;
        this.RecentHours = recentHours;
    }

    public int Today { get; }

    public int Average { get; }

    public IReadOnlyList<int> LastDays { get; }

    public IReadOnlyList<int> RecentHours { get; }
}