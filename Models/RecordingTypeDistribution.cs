namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class RecordingTypeDistribution
{
    [JsonConstructor]
    public RecordingTypeDistribution(
        string recordingType,
        object size,
        double percentage)
    {
        this.RecordingType = recordingType;
        this.Size = size;
        this.Percentage = percentage;
    }

    public string RecordingType { get; }

    public object Size { get; }

    public double Percentage { get; }
}