namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Channel
{
    [JsonConstructor]
    public Channel(
        int id,
        string videoId,
        string name,
        bool enabled,
        bool isRtspEnabled,
        object rtspAlias,
        int width,
        int height,
        int fps,
        int bitrate,
        int minBitrate,
        int maxBitrate,
        int minClientAdaptiveBitRate,
        int minMotionAdaptiveBitRate,
        List<int> fpsValues,
        int idrInterval)
    {
        this.Id = id;
        this.VideoId = videoId;
        this.Name = name;
        this.Enabled = enabled;
        this.IsRtspEnabled = isRtspEnabled;
        this.RtspAlias = rtspAlias;
        this.Width = width;
        this.Height = height;
        this.Fps = fps;
        this.Bitrate = bitrate;
        this.MinBitrate = minBitrate;
        this.MaxBitrate = maxBitrate;
        this.MinClientAdaptiveBitRate = minClientAdaptiveBitRate;
        this.MinMotionAdaptiveBitRate = minMotionAdaptiveBitRate;
        this.FpsValues = fpsValues;
        this.IdrInterval = idrInterval;
    }

    public int Id { get; }

    public string VideoId { get; }

    public string Name { get; }

    public bool Enabled { get; }

    public bool IsRtspEnabled { get; }

    public object RtspAlias { get; }

    public int Width { get; }

    public int Height { get; }

    public int Fps { get; }

    public int Bitrate { get; }

    public int MinBitrate { get; }

    public int MaxBitrate { get; }

    public int MinClientAdaptiveBitRate { get; }

    public int MinMotionAdaptiveBitRate { get; }

    public IReadOnlyList<int> FpsValues { get; }

    public int IdrInterval { get; }
}