namespace UniFi.Protect.Api.Models.Payloads;

public interface IEvent : IUpdate
{
    EventType Type { get; set; }

    DateTimeOffset Start { get; set; }

    DateTimeOffset? End { get; set; }

    int Score { get; set; }

    List<DetectionType> SmartDetectTypes { get; set; }

    List<string> SmartDetectEvents { get; set; }

    Metadata? Metadata { get; set; }

    string? Camera { get; set; }

    object? Partition { get; set; }

    string? User { get; set; }

    string Id { get; set; }
}