namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class DoorbellSettings
{
    [JsonConstructor]
    public DoorbellSettings(
        string defaultMessageText,
        int defaultMessageResetTimeoutMs,
        List<object> customMessages,
        List<AllMessage> allMessages)
    {
        this.DefaultMessageText = defaultMessageText;
        this.DefaultMessageResetTimeoutMs = defaultMessageResetTimeoutMs;
        this.CustomMessages = customMessages;
        this.AllMessages = allMessages;
    }

    public string DefaultMessageText { get; }

    public int DefaultMessageResetTimeoutMs { get; }

    public IReadOnlyList<object> CustomMessages { get; }

    public IReadOnlyList<AllMessage> AllMessages { get; }
}