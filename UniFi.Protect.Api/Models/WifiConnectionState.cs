namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class WifiConnectionState
{
    [JsonConstructor]
    public WifiConnectionState(
        int channel,
        int frequency,
        int phyRate,
        int signalQuality,
        int signalStrength,
        string ssid)
    {
        this.Channel = channel;
        this.Frequency = frequency;
        this.PhyRate = phyRate;
        this.SignalQuality = signalQuality;
        this.SignalStrength = signalStrength;
        this.Ssid = ssid;
    }

    public int Channel { get; }

    public int Frequency { get; }

    public int PhyRate { get; }

    public int SignalQuality { get; }

    public int SignalStrength { get; }

    public string Ssid { get; }
}