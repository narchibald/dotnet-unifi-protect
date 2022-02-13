using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class StorageStats
{
    [JsonConstructor]
    public StorageStats(
        double utilization,
        long capacity,
        long remainingCapacity,
        RecordingSpace recordingSpace,
        StorageDistribution storageDistribution)
    {
        this.Utilization = utilization;
        this.Capacity = capacity;
        this.RemainingCapacity = remainingCapacity;
        this.RecordingSpace = recordingSpace;
        this.StorageDistribution = storageDistribution;
    }

    public double Utilization { get; }

    public long Capacity { get; }

    public long RemainingCapacity { get; }

    public RecordingSpace RecordingSpace { get; }

    public StorageDistribution StorageDistribution { get; }
}