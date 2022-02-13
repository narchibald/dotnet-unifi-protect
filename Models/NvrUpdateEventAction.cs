namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class NvrUpdateEventAction
{
    [JsonConstructor]
    public NvrUpdateEventAction(string action, string id, string modelKey, string newUpdateId)
    {
        this.Action = action;
        this.Id = id;
        this.ModelKey = modelKey;
        this.NewUpdateId = newUpdateId;
    }

    public string Action { get; }

    public string Id { get; }

    public string ModelKey { get; }

    public string NewUpdateId { get; }
}