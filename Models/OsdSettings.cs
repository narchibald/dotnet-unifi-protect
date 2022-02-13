using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class OsdSettings
{
    [JsonConstructor]
    public OsdSettings(
        bool isNameEnabled,
        bool isDateEnabled,
        bool isLogoEnabled,
        bool isDebugEnabled)
    {
        this.IsNameEnabled = isNameEnabled;
        this.IsDateEnabled = isDateEnabled;
        this.IsLogoEnabled = isLogoEnabled;
        this.IsDebugEnabled = isDebugEnabled;
    }

    public bool IsNameEnabled { get; }

    public bool IsDateEnabled { get; }

    public bool IsLogoEnabled { get; }

    public bool IsDebugEnabled { get; }
}