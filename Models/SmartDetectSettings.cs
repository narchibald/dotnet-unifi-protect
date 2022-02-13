using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

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