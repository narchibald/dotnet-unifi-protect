namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class DewarpState
{
    [JsonConstructor]
    public DewarpState(
        bool dewarp,
        State state)
    {
        this.Dewarp = dewarp;
        this.State = state;
    }

    public bool Dewarp { get; }

    public State State { get; }
}