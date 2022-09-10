namespace UniFi.Protect.Api;

using UniFi.Protect.Api.Models;

public class NvrUpdatePacket
{
    public NvrUpdatePacket(NvrUpdateEventAction action, UpdatePayloadType format)
    {
        this.Action = action;
        this.Format = format;
    }

    public NvrUpdateEventAction Action { get; }

    public UpdatePayloadType Format { get; }
}

public class NvrUpdatePacket<T> : NvrUpdatePacket
{
    public NvrUpdatePacket(NvrUpdateEventAction action, UpdatePayloadType type, T payload)
        : base(action, type)
    {
        this.Payload = payload;
    }

    public T Payload { get; } // : Record<string, unknown> | string | Buffer
}