using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class Nvr
{
    [JsonConstructor]
    public Nvr(
        string mac,
        string host,
        string name,
        bool canAutoUpdate,
        bool isStatsGatheringEnabled,
        string timezone,
        string version,
        string ucoreVersion,
        string firmwareVersion,
        object uiVersion,
        string hardwarePlatform,
        Ports ports,
        long uptime,
        long lastSeen,
        bool isUpdating,
        object lastUpdateAt,
        bool isStation,
        bool enableAutomaticBackups,
        bool enableStatsReporting,
        bool isSshEnabled,
        object errorCode,
        string releaseChannel,
        object ssoChannel,
        List<string> hosts,
        bool enableBridgeAutoAdoption,
        string hardwareId,
        string hardwareRevision,
        int hostType,
        string hostShortname,
        bool isHardware,
        bool isWirelessUplinkEnabled,
        string timeFormat,
        string temperatureUnit,
        long recordingRetentionDurationMs,
        bool enableCrashReporting,
        bool disableAudio,
        string analyticsData,
        string anonymousDeviceId,
        int cameraUtilization,
        bool isRecycling,
        List<double> avgMotions,
        bool disableAutoLink,
        bool skipFirmwareUpdate,
        WifiSettings wifiSettings,
        LocationSettings locationSettings,
        FeatureFlags featureFlags,
        SystemInfo systemInfo,
        DoorbellSettings doorbellSettings,
        SmartDetectAgreement smartDetectAgreement,
        StorageStats storageStats,
        string id,
        bool isAway,
        bool isSetup,
        string network,
        string type,
        long upSince,
        bool isRecordingDisabled,
        bool isRecordingMotionOnly,
        MaxCameraCapacity maxCameraCapacity,
        string modelKey)
    {
        this.Mac = mac;
        this.Host = host;
        this.Name = name;
        this.CanAutoUpdate = canAutoUpdate;
        this.IsStatsGatheringEnabled = isStatsGatheringEnabled;
        this.Timezone = timezone;
        this.Version = version;
        this.UcoreVersion = ucoreVersion;
        this.FirmwareVersion = firmwareVersion;
        this.UiVersion = uiVersion;
        this.HardwarePlatform = hardwarePlatform;
        this.Ports = ports;
        this.Uptime = uptime;
        this.LastSeen = lastSeen;
        this.IsUpdating = isUpdating;
        this.LastUpdateAt = lastUpdateAt;
        this.IsStation = isStation;
        this.EnableAutomaticBackups = enableAutomaticBackups;
        this.EnableStatsReporting = enableStatsReporting;
        this.IsSshEnabled = isSshEnabled;
        this.ErrorCode = errorCode;
        this.ReleaseChannel = releaseChannel;
        this.SsoChannel = ssoChannel;
        this.Hosts = hosts;
        this.EnableBridgeAutoAdoption = enableBridgeAutoAdoption;
        this.HardwareId = hardwareId;
        this.HardwareRevision = hardwareRevision;
        this.HostType = hostType;
        this.HostShortname = hostShortname;
        this.IsHardware = isHardware;
        this.IsWirelessUplinkEnabled = isWirelessUplinkEnabled;
        this.TimeFormat = timeFormat;
        this.TemperatureUnit = temperatureUnit;
        this.RecordingRetentionDurationMs = recordingRetentionDurationMs;
        this.EnableCrashReporting = enableCrashReporting;
        this.DisableAudio = disableAudio;
        this.AnalyticsData = analyticsData;
        this.AnonymousDeviceId = anonymousDeviceId;
        this.CameraUtilization = cameraUtilization;
        this.IsRecycling = isRecycling;
        this.AvgMotions = avgMotions;
        this.DisableAutoLink = disableAutoLink;
        this.SkipFirmwareUpdate = skipFirmwareUpdate;
        this.WifiSettings = wifiSettings;
        this.LocationSettings = locationSettings;
        this.FeatureFlags = featureFlags;
        this.SystemInfo = systemInfo;
        this.DoorbellSettings = doorbellSettings;
        this.SmartDetectAgreement = smartDetectAgreement;
        this.StorageStats = storageStats;
        this.Id = id;
        this.IsAway = isAway;
        this.IsSetup = isSetup;
        this.Network = network;
        this.Type = type;
        this.UpSince = upSince;
        this.IsRecordingDisabled = isRecordingDisabled;
        this.IsRecordingMotionOnly = isRecordingMotionOnly;
        this.MaxCameraCapacity = maxCameraCapacity;
        this.ModelKey = modelKey;
    }

    public string Mac { get; }

    public string Host { get; }

    public string Name { get; }

    public bool CanAutoUpdate { get; }

    public bool IsStatsGatheringEnabled { get; }

    public string Timezone { get; }

    public string Version { get; }

    public string UcoreVersion { get; }

    public string FirmwareVersion { get; }

    public object UiVersion { get; }

    public string HardwarePlatform { get; }

    public Ports Ports { get; }

    public long Uptime { get; }

    public long LastSeen { get; }

    public bool IsUpdating { get; }

    public object LastUpdateAt { get; }

    public bool IsStation { get; }

    public bool EnableAutomaticBackups { get; }

    public bool EnableStatsReporting { get; }

    public bool IsSshEnabled { get; }

    public object ErrorCode { get; }

    public string ReleaseChannel { get; }

    public object SsoChannel { get; }

    public IReadOnlyList<string> Hosts { get; }

    public bool EnableBridgeAutoAdoption { get; }

    public string HardwareId { get; }

    public string HardwareRevision { get; }

    public int HostType { get; }

    public string HostShortname { get; }

    public bool IsHardware { get; }

    public bool IsWirelessUplinkEnabled { get; }

    public string TimeFormat { get; }

    public string TemperatureUnit { get; }

    public long RecordingRetentionDurationMs { get; }

    public bool EnableCrashReporting { get; }

    public bool DisableAudio { get; }

    public string AnalyticsData { get; }

    public string AnonymousDeviceId { get; }

    public int CameraUtilization { get; }

    public bool IsRecycling { get; }

    public IReadOnlyList<double> AvgMotions { get; }

    public bool DisableAutoLink { get; }

    public bool SkipFirmwareUpdate { get; }

    public WifiSettings WifiSettings { get; }

    public LocationSettings LocationSettings { get; }

    public FeatureFlags FeatureFlags { get; }

    public SystemInfo SystemInfo { get; }

    public DoorbellSettings DoorbellSettings { get; }

    public SmartDetectAgreement SmartDetectAgreement { get; }

    public StorageStats StorageStats { get; }

    public string Id { get; }

    public bool IsAway { get; }

    public bool IsSetup { get; }

    public string Network { get; }

    public string Type { get; }

    public long UpSince { get; }

    public bool IsRecordingDisabled { get; }

    public bool IsRecordingMotionOnly { get; }

    public MaxCameraCapacity MaxCameraCapacity { get; }

    public string ModelKey { get; }
}