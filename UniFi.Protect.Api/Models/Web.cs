namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Web
{
    [JsonConstructor]
    public Web(
        Dewarp dewarp)
    {
        this.Dewarp = dewarp;
    }

    public Dewarp Dewarp { get; }
}