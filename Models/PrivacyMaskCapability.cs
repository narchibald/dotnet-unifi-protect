using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

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