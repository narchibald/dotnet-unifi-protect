namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Location
{
    [JsonConstructor]
    public Location(
        bool isAway,
        object latitude,
        object longitude)
    {
        this.IsAway = isAway;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public bool IsAway { get; }

    public object Latitude { get; }

    public object Longitude { get; }
}