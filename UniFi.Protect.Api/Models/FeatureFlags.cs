namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class FeatureFlags
{
    [JsonConstructor]
    public FeatureFlags(
        bool canAdjustIrLedLevel,
        bool canMagicZoom,
        bool canOpticalZoom,
        bool canTouchFocus,
        bool hasAccelerometer,
        bool hasAec,
        bool hasBattery,
        bool hasBluetooth,
        bool hasChime,
        bool hasExternalIr,
        bool hasIcrSensitivity,
        bool hasLdc,
        bool hasLedIr,
        bool hasLedStatus,
        bool hasLineIn,
        bool hasMic,
        bool hasPrivacyMask,
        bool hasRtc,
        bool hasSdCard,
        bool hasSpeaker,
        bool hasWifi,
        bool hasHdr,
        bool hasAutoIcrOnly,
        List<string> videoModes,
        List<int> videoModeMaxFps,
        bool hasMotionZones,
        bool hasLcdScreen,
        List<object> mountPositions,
        List<string> smartDetectTypes,
        List<string> motionAlgorithms,
        bool hasSquareEventThumbnail,
        bool hasPackageCamera,
        PrivacyMaskCapability privacyMaskCapability,
        Focus focus,
        Pan pan,
        Tilt tilt,
        Zoom zoom,
        bool hasSmartDetect,
        bool notificationsV2,
        bool beta,
        bool dev)
    {
        this.CanAdjustIrLedLevel = canAdjustIrLedLevel;
        this.CanMagicZoom = canMagicZoom;
        this.CanOpticalZoom = canOpticalZoom;
        this.CanTouchFocus = canTouchFocus;
        this.HasAccelerometer = hasAccelerometer;
        this.HasAec = hasAec;
        this.HasBattery = hasBattery;
        this.HasBluetooth = hasBluetooth;
        this.HasChime = hasChime;
        this.HasExternalIr = hasExternalIr;
        this.HasIcrSensitivity = hasIcrSensitivity;
        this.HasLdc = hasLdc;
        this.HasLedIr = hasLedIr;
        this.HasLedStatus = hasLedStatus;
        this.HasLineIn = hasLineIn;
        this.HasMic = hasMic;
        this.HasPrivacyMask = hasPrivacyMask;
        this.HasRtc = hasRtc;
        this.HasSdCard = hasSdCard;
        this.HasSpeaker = hasSpeaker;
        this.HasWifi = hasWifi;
        this.HasHdr = hasHdr;
        this.HasAutoIcrOnly = hasAutoIcrOnly;
        this.VideoModes = videoModes;
        this.VideoModeMaxFps = videoModeMaxFps;
        this.HasMotionZones = hasMotionZones;
        this.HasLcdScreen = hasLcdScreen;
        this.MountPositions = mountPositions;
        this.SmartDetectTypes = smartDetectTypes;
        this.MotionAlgorithms = motionAlgorithms;
        this.HasSquareEventThumbnail = hasSquareEventThumbnail;
        this.HasPackageCamera = hasPackageCamera;
        this.PrivacyMaskCapability = privacyMaskCapability;
        this.Focus = focus;
        this.Pan = pan;
        this.Tilt = tilt;
        this.Zoom = zoom;
        this.HasSmartDetect = hasSmartDetect;
        this.NotificationsV2 = notificationsV2;
        this.Beta = beta;
        this.Dev = dev;
    }

    public bool CanAdjustIrLedLevel { get; }

    public bool CanMagicZoom { get; }

    public bool CanOpticalZoom { get; }

    public bool CanTouchFocus { get; }

    public bool HasAccelerometer { get; }

    public bool HasAec { get; }

    public bool HasBattery { get; }

    public bool HasBluetooth { get; }

    public bool HasChime { get; }

    public bool HasExternalIr { get; }

    public bool HasIcrSensitivity { get; }

    public bool HasLdc { get; }

    public bool HasLedIr { get; }

    public bool HasLedStatus { get; }

    public bool HasLineIn { get; }

    public bool HasMic { get; }

    public bool HasPrivacyMask { get; }

    public bool HasRtc { get; }

    public bool HasSdCard { get; }

    public bool HasSpeaker { get; }

    public bool HasWifi { get; }

    public bool HasHdr { get; }

    public bool HasAutoIcrOnly { get; }

    public IReadOnlyList<string> VideoModes { get; }

    public IReadOnlyList<int> VideoModeMaxFps { get; }

    public bool HasMotionZones { get; }

    public bool HasLcdScreen { get; }

    public IReadOnlyList<object> MountPositions { get; }

    public IReadOnlyList<string> SmartDetectTypes { get; }

    public IReadOnlyList<string> MotionAlgorithms { get; }

    public bool HasSquareEventThumbnail { get; }

    public bool HasPackageCamera { get; }

    public PrivacyMaskCapability PrivacyMaskCapability { get; }

    public Focus Focus { get; }

    public Pan Pan { get; }

    public Tilt Tilt { get; }

    public Zoom Zoom { get; }

    public bool HasSmartDetect { get; }

    public bool NotificationsV2 { get; }

    public bool Beta { get; }

    public bool Dev { get; }
}