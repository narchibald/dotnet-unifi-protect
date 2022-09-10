namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Dewarp
{
    [JsonConstructor]
    public Dewarp(
        DewarpState _61d8eed40190ab0387000420)
    {
        this.DewarpState = _61d8eed40190ab0387000420;
    }

    public DewarpState DewarpState { get; }
}