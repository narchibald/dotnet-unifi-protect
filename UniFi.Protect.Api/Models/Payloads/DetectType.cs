namespace UniFi.Protect.Api.Models.Payloads;

using System.Runtime.Serialization;

public enum DetectionType
{
    [EnumMember(Value = "person")]
    Person,

    [EnumMember(Value = "vehicle")]
    Vehicle,

    [EnumMember(Value = "package")]
    Package,

    [EnumMember(Value = "animal")]
    Animal,
}