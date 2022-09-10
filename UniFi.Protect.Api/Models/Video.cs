namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Video
{
    [JsonConstructor]
    public Video(
        long recordingStart,
        long recordingEnd,
        long recordingStartLq,
        long recordingEndLq,
        long timelapseStart,
        long timelapseEnd,
        long timelapseStartLq,
        long timelapseEndLq)
    {
        this.RecordingStart = recordingStart;
        this.RecordingEnd = recordingEnd;
        this.RecordingStartLq = recordingStartLq;
        this.RecordingEndLq = recordingEndLq;
        this.TimelapseStart = timelapseStart;
        this.TimelapseEnd = timelapseEnd;
        this.TimelapseStartLq = timelapseStartLq;
        this.TimelapseEndLq = timelapseEndLq;
    }

    public long RecordingStart { get; }

    public long RecordingEnd { get; }

    public long RecordingStartLq { get; }

    public long RecordingEndLq { get; }

    public long TimelapseStart { get; }

    public long TimelapseEnd { get; }

    public long TimelapseStartLq { get; }

    public long TimelapseEndLq { get; }
}