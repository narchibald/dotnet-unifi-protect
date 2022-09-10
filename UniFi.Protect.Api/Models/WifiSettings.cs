namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class WifiSettings
{
    [JsonConstructor]
    public WifiSettings(
        bool useThirdPartyWifi,
        object ssid,
        object password)
    {
        this.UseThirdPartyWifi = useThirdPartyWifi;
        this.Ssid = ssid;
        this.Password = password;
    }

    public bool UseThirdPartyWifi { get; }

    public object Ssid { get; }

    public object Password { get; }
}