namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class SmartDetectSettings
{
    [JsonConstructor]
    public SmartDetectSettings(
        List<string> objectTypes)
    {
        this.ObjectTypes = objectTypes;
    }

    public IReadOnlyList<string> ObjectTypes { get; }
}