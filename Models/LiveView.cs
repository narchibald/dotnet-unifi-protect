namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class LiveView
{
    [JsonConstructor]
    public LiveView(
        string name,
        bool isDefault,
        bool isGlobal,
        int layout,
        List<Slot> slots,
        string owner,
        string id,
        string modelKey)
    {
        this.Name = name;
        this.IsDefault = isDefault;
        this.IsGlobal = isGlobal;
        this.Layout = layout;
        this.Slots = slots;
        this.Owner = owner;
        this.Id = id;
        this.ModelKey = modelKey;
    }

    public string Name { get; }

    public bool IsDefault { get; }

    public bool IsGlobal { get; }

    public int Layout { get; }

    public IReadOnlyList<Slot> Slots { get; }

    public string Owner { get; }

    public string Id { get; }

    public string ModelKey { get; }
}