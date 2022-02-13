namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class LocationSettings
{
    [JsonConstructor]
    public LocationSettings(
        bool isAway,
        bool isGeofencingEnabled,
        double latitude,
        double longitude,
        int radius)
    {
        this.IsAway = isAway;
        this.IsGeofencingEnabled = isGeofencingEnabled;
        this.Latitude = latitude;
        this.Longitude = longitude;
        this.Radius = radius;
    }

    public bool IsAway { get; }

    public bool IsGeofencingEnabled { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public int Radius { get; }
}