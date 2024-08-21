namespace UniFi.Protect.Api.Models.Payloads;

using Newtonsoft.Json;
using Converters;

[PayloadIdentifier("user")]
public class User : Update
{
    [JsonProperty("permissions")]
    public List<object> Permissions { get; set; }

    [JsonProperty("lastLoginIp")]
    public string? LastLoginIp { get; set; }

    [JsonProperty("lastLoginTime")]
    [JsonConverter(typeof(UnixTimeMillisecondsConverter))]
    public DateTimeOffset? LastLoginTime { get; set; }

    [JsonProperty("isOwner")]
    public bool IsOwner { get; set; }

    [JsonProperty("enableNotifications")]
    public bool EnableNotifications { get; set; }

    [JsonProperty("settings")]
    public Settings Settings { get; set; }

    [JsonProperty("groups")]
    public List<string> Groups { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("alertRules")]
    public List<object> AlertRules { get; set; }

    [JsonProperty("notificationsV2")]
    public NotificationsV2 NotificationsV2 { get; set; }

    [JsonProperty("notifications")]
    public Notifications Notifications { get; set; }

    [JsonProperty("notificationSnoozeSettings")]
    public object NotificationSnoozeSettings { get; set; }

    [JsonProperty("featureFlags")]
    public FeatureFlags FeatureFlags { get; set; }

    [JsonProperty("cloudProviders")]
    public CloudProviders CloudProviders { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("hasAcceptedInvite")]
    public bool HasAcceptedInvite { get; set; }

    [JsonProperty("allPermissions")]
    public List<string> AllPermissions { get; set; }

    [JsonProperty("scopes")]
    public List<string> Scopes { get; set; }

    [JsonProperty("cloudAccount")]
    public object CloudAccount { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("localUsername")]
    public string LocalUsername { get; set; }
}