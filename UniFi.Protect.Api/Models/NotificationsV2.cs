namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class NotificationsV2
{
    [JsonConstructor]
    public NotificationsV2(
        string state,
        MotionNotifications motionNotifications,
        SystemNotifications systemNotifications)
    {
        this.State = state;
        this.MotionNotifications = motionNotifications;
        this.SystemNotifications = systemNotifications;
    }

    public string State { get; }

    public MotionNotifications MotionNotifications { get; }

    public SystemNotifications SystemNotifications { get; }
}