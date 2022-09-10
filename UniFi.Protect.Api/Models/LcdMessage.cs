namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class LcdMessage
{
    [JsonConstructor]
    public LcdMessage(
        string text,
        object resetAt)
    {
        this.Text = text;
        this.ResetAt = resetAt;
    }

    public string Text { get; }

    public object ResetAt { get; }
}