using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class TalkbackSettings
{
    [JsonConstructor]
    public TalkbackSettings(
        string typeFmt,
        string typeIn,
        string bindAddr,
        int bindPort,
        string filterAddr,
        int filterPort,
        int channels,
        int samplingRate,
        int bitsPerSample,
        int quality)
    {
        this.TypeFmt = typeFmt;
        this.TypeIn = typeIn;
        this.BindAddr = bindAddr;
        this.BindPort = bindPort;
        this.FilterAddr = filterAddr;
        this.FilterPort = filterPort;
        this.Channels = channels;
        this.SamplingRate = samplingRate;
        this.BitsPerSample = bitsPerSample;
        this.Quality = quality;
    }

    public string TypeFmt { get; }

    public string TypeIn { get; }

    public string BindAddr { get; }

    public int BindPort { get; }

    public string FilterAddr { get; }

    public int FilterPort { get; }

    public int Channels { get; }

    public int SamplingRate { get; }

    public int BitsPerSample { get; }

    public int Quality { get; }
}