namespace UniFi.Protect.Api.Models.Payloads;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal class PayloadIdentifierAttribute : Attribute
{
    public PayloadIdentifierAttribute(string modelKey)
    {
        this.ModelKey = modelKey;
    }

    public string ModelKey { get; }
}