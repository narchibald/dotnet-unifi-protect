namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Stats
{
    [JsonConstructor]
    public Stats(
        long rxBytes,
        long txBytes,
        Wifi wifi,
        Battery battery,
        Video video,
        Storage storage,
        int wifiQuality,
        int wifiStrength)
    {
        this.RxBytes = rxBytes;
        this.TxBytes = txBytes;
        this.Wifi = wifi;
        this.Battery = battery;
        this.Video = video;
        this.Storage = storage;
        this.WifiQuality = wifiQuality;
        this.WifiStrength = wifiStrength;
    }

    public long RxBytes { get; }

    public long TxBytes { get; }

    public Wifi Wifi { get; }

    public Battery Battery { get; }

    public Video Video { get; }

    public Storage Storage { get; }

    public int WifiQuality { get; }

    public int WifiStrength { get; }
}