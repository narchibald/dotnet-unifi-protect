namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class User
{
    [JsonConstructor]
    public User(
        List<object> permissions,
        bool isOwner,
        bool enableNotifications,
        Settings settings,
        List<string> groups,
        Location location,
        List<object> alertRules,
        NotificationsV2 notificationsV2,
        FeatureFlags featureFlags,
        string id,
        bool hasAcceptedInvite,
        List<string> allPermissions,
        object cloudAccount,
        string name,
        string firstName,
        string lastName,
        string email,
        string localUsername,
        string modelKey)
    {
        this.Permissions = permissions;
        this.IsOwner = isOwner;
        this.EnableNotifications = enableNotifications;
        this.Settings = settings;
        this.Groups = groups;
        this.Location = location;
        this.AlertRules = alertRules;
        this.NotificationsV2 = notificationsV2;
        this.FeatureFlags = featureFlags;
        this.Id = id;
        this.HasAcceptedInvite = hasAcceptedInvite;
        this.AllPermissions = allPermissions;
        this.CloudAccount = cloudAccount;
        this.Name = name;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.LocalUsername = localUsername;
        this.ModelKey = modelKey;
    }

    public IReadOnlyList<object> Permissions { get; }

    public bool IsOwner { get; }

    public bool EnableNotifications { get; }

    public Settings Settings { get; }

    public IReadOnlyList<string> Groups { get; }

    public Location Location { get; }

    public IReadOnlyList<object> AlertRules { get; }

    public NotificationsV2 NotificationsV2 { get; }

    public FeatureFlags FeatureFlags { get; }

    public string Id { get; }

    public bool HasAcceptedInvite { get; }

    public IReadOnlyList<string> AllPermissions { get; }

    public object CloudAccount { get; }

    public string Name { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public string LocalUsername { get; }

    public string ModelKey { get; }
}