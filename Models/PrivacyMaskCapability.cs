namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class PrivacyMaskCapability
{
    [JsonConstructor]
    public PrivacyMaskCapability(
        int maxMasks,
        bool rectangleOnly)
    {
        this.MaxMasks = maxMasks;
        this.RectangleOnly = rectangleOnly;
    }

    public int MaxMasks { get; }

    public bool RectangleOnly { get; }
}