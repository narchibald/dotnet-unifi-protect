namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Ports
{
    [JsonConstructor]
    public Ports(
        int ump,
        int http,
        int https,
        int rtsp,
        int rtsps,
        int rtmp,
        int devicesWss,
        int cameraHttps,
        int cameraTcp,
        int liveWs,
        int liveWss,
        int tcpStreams,
        int playback,
        int emsCli,
        int emsLiveFlv,
        int cameraEvents,
        int tcpBridge,
        int ucore,
        int discoveryClient)
    {
        this.Ump = ump;
        this.Http = http;
        this.Https = https;
        this.Rtsp = rtsp;
        this.Rtsps = rtsps;
        this.Rtmp = rtmp;
        this.DevicesWss = devicesWss;
        this.CameraHttps = cameraHttps;
        this.CameraTcp = cameraTcp;
        this.LiveWs = liveWs;
        this.LiveWss = liveWss;
        this.TcpStreams = tcpStreams;
        this.Playback = playback;
        this.EmsCli = emsCli;
        this.EmsLiveFlv = emsLiveFlv;
        this.CameraEvents = cameraEvents;
        this.TcpBridge = tcpBridge;
        this.Ucore = ucore;
        this.DiscoveryClient = discoveryClient;
    }

    public int Ump { get; }

    public int Http { get; }

    public int Https { get; }

    public int Rtsp { get; }

    public int Rtsps { get; }

    public int Rtmp { get; }

    public int DevicesWss { get; }

    public int CameraHttps { get; }

    public int CameraTcp { get; }

    public int LiveWs { get; }

    public int LiveWss { get; }

    public int TcpStreams { get; }

    public int Playback { get; }

    public int EmsCli { get; }

    public int EmsLiveFlv { get; }

    public int CameraEvents { get; }

    public int TcpBridge { get; }

    public int Ucore { get; }

    public int DiscoveryClient { get; }
}