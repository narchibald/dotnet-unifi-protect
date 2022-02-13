using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class NvrBootstrap
{
    [JsonConstructor]
    public NvrBootstrap(
        string authUserId,
        string accessKey,
        List<Camera> cameras,
        List<User> users,
        List<object> groups,
        List<LiveView> liveviews,
        List<object> schedules,
        Nvr nvr,
        List<object> legacyUfVs,
        string lastUpdateId,
        List<object> viewers,
        List<object> displays,
        List<object> lights,
        List<object> bridges,
        List<object> sensors,
        List<object> doorlocks,
        List<object> chimes)
    {
        this.AuthUserId = authUserId;
        this.AccessKey = accessKey;
        this.Cameras = cameras;
        this.Users = users;
        this.Groups = groups;
        this.Liveviews = liveviews;
        this.Schedules = schedules;
        this.Nvr = nvr;
        this.LegacyUfVs = legacyUfVs;
        this.LastUpdateId = lastUpdateId;
        this.Viewers = viewers;
        this.Displays = displays;
        this.Lights = lights;
        this.Bridges = bridges;
        this.Sensors = sensors;
        this.Doorlocks = doorlocks;
        this.Chimes = chimes;
    }

    public string AuthUserId { get; }

    public string AccessKey { get; }

    public IReadOnlyList<Camera> Cameras { get; }

    public IReadOnlyList<User> Users { get; }

    public IReadOnlyList<object> Groups { get; }

    public IReadOnlyList<LiveView> Liveviews { get; }

    public IReadOnlyList<object> Schedules { get; }

    public Nvr Nvr { get; }

    public IReadOnlyList<object> LegacyUfVs { get; }

    public string LastUpdateId { get; }

    public IReadOnlyList<object> Viewers { get; }

    public IReadOnlyList<object> Displays { get; }

    public IReadOnlyList<object> Lights { get; }

    public IReadOnlyList<object> Bridges { get; }

    public IReadOnlyList<object> Sensors { get; }

    public IReadOnlyList<object> Doorlocks { get; }

    public IReadOnlyList<object> Chimes { get; }
}