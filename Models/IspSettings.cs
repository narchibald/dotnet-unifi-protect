namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class IspSettings
{
    [JsonConstructor]
    public IspSettings(
        string aeMode,
        string irLedMode,
        int irLedLevel,
        int wdr,
        int icrSensitivity,
        int brightness,
        int contrast,
        int hue,
        int saturation,
        int sharpness,
        int denoise,
        bool isFlippedVertical,
        bool isFlippedHorizontal,
        bool isAutoRotateEnabled,
        bool isLdcEnabled,
        bool is3dnrEnabled,
        bool isExternalIrEnabled,
        bool isAggressiveAntiFlickerEnabled,
        bool isPauseMotionEnabled,
        int dZoomCenterX,
        int dZoomCenterY,
        int dZoomScale,
        int dZoomStreamId,
        string focusMode,
        int focusPosition,
        int touchFocusX,
        int touchFocusY,
        int zoomPosition,
        object mountPosition)
    {
        this.AeMode = aeMode;
        this.IrLedMode = irLedMode;
        this.IrLedLevel = irLedLevel;
        this.Wdr = wdr;
        this.IcrSensitivity = icrSensitivity;
        this.Brightness = brightness;
        this.Contrast = contrast;
        this.Hue = hue;
        this.Saturation = saturation;
        this.Sharpness = sharpness;
        this.Denoise = denoise;
        this.IsFlippedVertical = isFlippedVertical;
        this.IsFlippedHorizontal = isFlippedHorizontal;
        this.IsAutoRotateEnabled = isAutoRotateEnabled;
        this.IsLdcEnabled = isLdcEnabled;
        this.Is3dnrEnabled = is3dnrEnabled;
        this.IsExternalIrEnabled = isExternalIrEnabled;
        this.IsAggressiveAntiFlickerEnabled = isAggressiveAntiFlickerEnabled;
        this.IsPauseMotionEnabled = isPauseMotionEnabled;
        this.DZoomCenterX = dZoomCenterX;
        this.DZoomCenterY = dZoomCenterY;
        this.DZoomScale = dZoomScale;
        this.DZoomStreamId = dZoomStreamId;
        this.FocusMode = focusMode;
        this.FocusPosition = focusPosition;
        this.TouchFocusX = touchFocusX;
        this.TouchFocusY = touchFocusY;
        this.ZoomPosition = zoomPosition;
        this.MountPosition = mountPosition;
    }

    public string AeMode { get; }

    public string IrLedMode { get; }

    public int IrLedLevel { get; }

    public int Wdr { get; }

    public int IcrSensitivity { get; }

    public int Brightness { get; }

    public int Contrast { get; }

    public int Hue { get; }

    public int Saturation { get; }

    public int Sharpness { get; }

    public int Denoise { get; }

    public bool IsFlippedVertical { get; }

    public bool IsFlippedHorizontal { get; }

    public bool IsAutoRotateEnabled { get; }

    public bool IsLdcEnabled { get; }

    public bool Is3dnrEnabled { get; }

    public bool IsExternalIrEnabled { get; }

    public bool IsAggressiveAntiFlickerEnabled { get; }

    public bool IsPauseMotionEnabled { get; }

    public int DZoomCenterX { get; }

    public int DZoomCenterY { get; }

    public int DZoomScale { get; }

    public int DZoomStreamId { get; }

    public string FocusMode { get; }

    public int FocusPosition { get; }

    public int TouchFocusX { get; }

    public int TouchFocusY { get; }

    public int ZoomPosition { get; }

    public object MountPosition { get; }
}