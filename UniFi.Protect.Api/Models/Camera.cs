namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Camera
{
    [JsonConstructor]
    public Camera(
        bool isDeleting,
        string mac,
        string host,
        string connectionHost,
        string type,
        string name,
        long upSince,
        long? uptime,
        long? lastSeen,
        long? connectedSince,
        string state,
        string hardwareRevision,
        string firmwareVersion,
        string latestFirmwareVersion,
        string firmwareBuild,
        bool isUpdating,
        bool isAdopting,
        bool isAdopted,
        bool isAdoptedByOther,
        bool isProvisioned,
        bool isRebooting,
        bool isSshEnabled,
        bool canAdopt,
        bool isAttemptingToConnect,
        long lastMotion,
        int micVolume,
        bool isMicEnabled,
        bool isRecording,
        bool isMotionDetected,
        bool isSmartDetected,
        decimal? phyRate,
        bool hdrMode,
        string videoMode,
        bool isProbingForWifi,
        string apMac,
        int? apRssi,
        string elementInfo,
        int chimeDuration,
        bool isDark,
        object lastPrivacyZonePositionId,
        long? lastRing,
        bool isLiveHeatmapEnabled,
        string anonymousDeviceId,
        EventStats eventStats,
        bool videoReconfigurationInProgress,
        double? voltage,
        WiredConnectionState wiredConnectionState,
        List<Channel> channels,
        IspSettings ispSettings,
        TalkbackSettings talkbackSettings,
        OsdSettings osdSettings,
        LedSettings ledSettings,
        SpeakerSettings speakerSettings,
        RecordingSettings recordingSettings,
        SmartDetectSettings smartDetectSettings,
        List<object> recordingSchedules,
        List<MotionZone> motionZones,
        List<object> privacyZones,
        List<SmartDetectZone> smartDetectZones,
        List<object> smartDetectLines,
        Stats stats,
        FeatureFlags featureFlags,
        PirSettings pirSettings,
        LcdMessage lcdMessage,
        WifiConnectionState wifiConnectionState,
        List<object> lenses,
        string id,
        bool isConnected,
        string platform,
        bool hasSpeaker,
        bool hasWifi,
        int audioBitrate,
        bool canManage,
        bool isManaged,
        string modelKey)
    {
        this.IsDeleting = isDeleting;
        this.Mac = mac;
        this.Host = host;
        this.ConnectionHost = connectionHost;
        this.Type = type;
        this.Name = name;
        this.UpSince = upSince;
        this.Uptime = uptime;
        this.LastSeen = lastSeen;
        this.ConnectedSince = connectedSince;
        this.State = state;
        this.HardwareRevision = hardwareRevision;
        this.FirmwareVersion = firmwareVersion;
        this.LatestFirmwareVersion = latestFirmwareVersion;
        this.FirmwareBuild = firmwareBuild;
        this.IsUpdating = isUpdating;
        this.IsAdopting = isAdopting;
        this.IsAdopted = isAdopted;
        this.IsAdoptedByOther = isAdoptedByOther;
        this.IsProvisioned = isProvisioned;
        this.IsRebooting = isRebooting;
        this.IsSshEnabled = isSshEnabled;
        this.CanAdopt = canAdopt;
        this.IsAttemptingToConnect = isAttemptingToConnect;
        this.LastMotion = lastMotion;
        this.MicVolume = micVolume;
        this.IsMicEnabled = isMicEnabled;
        this.IsRecording = isRecording;
        this.IsMotionDetected = isMotionDetected;
        this.IsSmartDetected = isSmartDetected;
        this.PhyRate = phyRate;
        this.HdrMode = hdrMode;
        this.VideoMode = videoMode;
        this.IsProbingForWifi = isProbingForWifi;
        this.ApMac = apMac;
        this.ApRssi = apRssi;
        this.ElementInfo = elementInfo;
        this.ChimeDuration = chimeDuration;
        this.IsDark = isDark;
        this.LastPrivacyZonePositionId = lastPrivacyZonePositionId;
        this.LastRing = lastRing;
        this.IsLiveHeatmapEnabled = isLiveHeatmapEnabled;
        this.AnonymousDeviceId = anonymousDeviceId;
        this.EventStats = eventStats;
        this.VideoReconfigurationInProgress = videoReconfigurationInProgress;
        this.Voltage = voltage;
        this.WiredConnectionState = wiredConnectionState;
        this.Channels = channels;
        this.IspSettings = ispSettings;
        this.TalkbackSettings = talkbackSettings;
        this.OsdSettings = osdSettings;
        this.LedSettings = ledSettings;
        this.SpeakerSettings = speakerSettings;
        this.RecordingSettings = recordingSettings;
        this.SmartDetectSettings = smartDetectSettings;
        this.RecordingSchedules = recordingSchedules;
        this.MotionZones = motionZones;
        this.PrivacyZones = privacyZones;
        this.SmartDetectZones = smartDetectZones;
        this.SmartDetectLines = smartDetectLines;
        this.Stats = stats;
        this.FeatureFlags = featureFlags;
        this.PirSettings = pirSettings;
        this.LcdMessage = lcdMessage;
        this.WifiConnectionState = wifiConnectionState;
        this.Lenses = lenses;
        this.Id = id;
        this.IsConnected = isConnected;
        this.Platform = platform;
        this.HasSpeaker = hasSpeaker;
        this.HasWifi = hasWifi;
        this.AudioBitrate = audioBitrate;
        this.CanManage = canManage;
        this.IsManaged = isManaged;
        this.ModelKey = modelKey;
    }

    public bool IsDeleting { get; }

    public string Mac { get; }

    public string Host { get; }

    public string ConnectionHost { get; }

    public string Type { get; }

    public string Name { get; }

    public long UpSince { get; }

    public long? Uptime { get; }

    public long? LastSeen { get; }

    public long? ConnectedSince { get; }

    public string State { get; }

    public string HardwareRevision { get; }

    public string FirmwareVersion { get; }

    public string LatestFirmwareVersion { get; }

    public string FirmwareBuild { get; }

    public bool IsUpdating { get; }

    public bool IsAdopting { get; }

    public bool IsAdopted { get; }

    public bool IsAdoptedByOther { get; }

    public bool IsProvisioned { get; }

    public bool IsRebooting { get; }

    public bool IsSshEnabled { get; }

    public bool CanAdopt { get; }

    public bool IsAttemptingToConnect { get; }

    public long LastMotion { get; }

    public int MicVolume { get; }

    public bool IsMicEnabled { get; }

    public bool IsRecording { get; }

    public bool IsMotionDetected { get; }

    public bool IsSmartDetected { get; }

    public decimal? PhyRate { get; }

    public bool HdrMode { get; }

    public string VideoMode { get; }

    public bool IsProbingForWifi { get; }

    public string ApMac { get; }

    public int? ApRssi { get; }

    public string ElementInfo { get; }

    public int ChimeDuration { get; }

    public bool IsDark { get; }

    public object LastPrivacyZonePositionId { get; }

    public long? LastRing { get; }

    public bool IsLiveHeatmapEnabled { get; }

    public string AnonymousDeviceId { get; }

    public EventStats EventStats { get; }

    public bool VideoReconfigurationInProgress { get; }

    public double? Voltage { get; }

    public WiredConnectionState WiredConnectionState { get; }

    public IReadOnlyList<Channel> Channels { get; }

    public IspSettings IspSettings { get; }

    public TalkbackSettings TalkbackSettings { get; }

    public OsdSettings OsdSettings { get; }

    public LedSettings LedSettings { get; }

    public SpeakerSettings SpeakerSettings { get; }

    public RecordingSettings RecordingSettings { get; }

    public SmartDetectSettings SmartDetectSettings { get; }

    public IReadOnlyList<object> RecordingSchedules { get; }

    public IReadOnlyList<MotionZone> MotionZones { get; }

    public IReadOnlyList<object> PrivacyZones { get; }

    public IReadOnlyList<SmartDetectZone> SmartDetectZones { get; }

    public IReadOnlyList<object> SmartDetectLines { get; }

    public Stats Stats { get; }

    public FeatureFlags FeatureFlags { get; }

    public PirSettings PirSettings { get; }

    public LcdMessage LcdMessage { get; }

    public WifiConnectionState WifiConnectionState { get; }

    public IReadOnlyList<object> Lenses { get; }

    public string Id { get; }

    public bool IsConnected { get; }

    public string Platform { get; }

    public bool HasSpeaker { get; }

    public bool HasWifi { get; }

    public int AudioBitrate { get; }

    public bool CanManage { get; }

    public bool IsManaged { get; }

    public string ModelKey { get; }
}