namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Settings
{
    [JsonConstructor]
    public Settings(
        Flags flags,
        Web web)
    {
        this.Flags = flags;
        this.Web = web;
    }

    public Flags Flags { get; }

    public Web Web { get; }
}