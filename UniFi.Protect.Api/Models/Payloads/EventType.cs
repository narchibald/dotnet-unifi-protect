namespace UniFi.Protect.Api.Models.Payloads;

using System.Runtime.Serialization;

public enum EventType
{
    [EnumMember(Value = "smartDetectZone")]
    SmartDetectZone = 0,

    [EnumMember(Value = "ring")]
    Ring = 1,

    [EnumMember(Value = "access")]
    Access = 2,

    [EnumMember(Value = "motion")]
    Motion = 3,
}