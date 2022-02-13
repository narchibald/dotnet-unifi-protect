using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class StorageDistribution
{
    [JsonConstructor]
    public StorageDistribution(
        List<RecordingTypeDistribution> recordingTypeDistributions,
        List<ResolutionDistribution> resolutionDistributions)
    {
        this.RecordingTypeDistributions = recordingTypeDistributions;
        this.ResolutionDistributions = resolutionDistributions;
    }

    public IReadOnlyList<RecordingTypeDistribution> RecordingTypeDistributions { get; }

    public IReadOnlyList<ResolutionDistribution> ResolutionDistributions { get; }
}