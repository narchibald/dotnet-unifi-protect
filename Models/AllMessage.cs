namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class AllMessage
{
    [JsonConstructor]
    public AllMessage(string type, string text)
    {
        this.Type = type;
        this.Text = text;
    }

    [JsonProperty("type")]
    public string Type { get; }

    [JsonProperty("text")]
    public string Text { get; }
}