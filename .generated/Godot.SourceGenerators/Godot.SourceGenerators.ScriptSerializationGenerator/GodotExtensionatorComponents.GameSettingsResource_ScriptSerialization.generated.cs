using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class GameSettingsResource
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.AudioVolumes, global::Godot.Variant.CreateFrom(this.AudioVolumes));
        info.AddProperty(PropertyName.MouseSensitivity, global::Godot.Variant.From<float>(this.MouseSensitivity));
        info.AddProperty(PropertyName.ControllerVibration, global::Godot.Variant.From<bool>(this.ControllerVibration));
        info.AddProperty(PropertyName.AllowTelemetry, global::Godot.Variant.From<bool>(this.AllowTelemetry));
        info.AddProperty(PropertyName.CurrentLanguage, global::Godot.Variant.From<global::GodotExtensionatorComponents.Localization.LANGUAGES>(this.CurrentLanguage));
        info.AddProperty(PropertyName.ScreenBrightness, global::Godot.Variant.From<float>(this.ScreenBrightness));
        info.AddProperty(PropertyName.PhotoSensitive, global::Godot.Variant.From<bool>(this.PhotoSensitive));
        info.AddProperty(PropertyName.ScreenShake, global::Godot.Variant.From<bool>(this.ScreenShake));
        info.AddProperty(PropertyName.DisplayMode, global::Godot.Variant.From<global::Godot.DisplayServer.WindowMode>(this.DisplayMode));
        info.AddProperty(PropertyName.Vsync, global::Godot.Variant.From<global::Godot.DisplayServer.VSyncMode>(this.Vsync));
        info.AddProperty(PropertyName.AntiaAliasing, global::Godot.Variant.From<global::Godot.Viewport.Msaa>(this.AntiaAliasing));
        info.AddProperty(PropertyName.Resolutions, global::Godot.Variant.CreateFrom(this.Resolutions));
        info.AddProperty(PropertyName.CurrentQualityPreset, global::Godot.Variant.From<global::GodotExtensionatorComponents.GameSettingsResource.QUALITY_PRESETS>(this.CurrentQualityPreset));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.AudioVolumes, out var _value_AudioVolumes))
            this.AudioVolumes = _value_AudioVolumes.AsGodotDictionary<string, float>();
        if (info.TryGetProperty(PropertyName.MouseSensitivity, out var _value_MouseSensitivity))
            this.MouseSensitivity = _value_MouseSensitivity.As<float>();
        if (info.TryGetProperty(PropertyName.ControllerVibration, out var _value_ControllerVibration))
            this.ControllerVibration = _value_ControllerVibration.As<bool>();
        if (info.TryGetProperty(PropertyName.AllowTelemetry, out var _value_AllowTelemetry))
            this.AllowTelemetry = _value_AllowTelemetry.As<bool>();
        if (info.TryGetProperty(PropertyName.CurrentLanguage, out var _value_CurrentLanguage))
            this.CurrentLanguage = _value_CurrentLanguage.As<global::GodotExtensionatorComponents.Localization.LANGUAGES>();
        if (info.TryGetProperty(PropertyName.ScreenBrightness, out var _value_ScreenBrightness))
            this.ScreenBrightness = _value_ScreenBrightness.As<float>();
        if (info.TryGetProperty(PropertyName.PhotoSensitive, out var _value_PhotoSensitive))
            this.PhotoSensitive = _value_PhotoSensitive.As<bool>();
        if (info.TryGetProperty(PropertyName.ScreenShake, out var _value_ScreenShake))
            this.ScreenShake = _value_ScreenShake.As<bool>();
        if (info.TryGetProperty(PropertyName.DisplayMode, out var _value_DisplayMode))
            this.DisplayMode = _value_DisplayMode.As<global::Godot.DisplayServer.WindowMode>();
        if (info.TryGetProperty(PropertyName.Vsync, out var _value_Vsync))
            this.Vsync = _value_Vsync.As<global::Godot.DisplayServer.VSyncMode>();
        if (info.TryGetProperty(PropertyName.AntiaAliasing, out var _value_AntiaAliasing))
            this.AntiaAliasing = _value_AntiaAliasing.As<global::Godot.Viewport.Msaa>();
        if (info.TryGetProperty(PropertyName.Resolutions, out var _value_Resolutions))
            this.Resolutions = _value_Resolutions.AsGodotDictionary<string, global::Godot.Collections.Array<global::Godot.Vector2I>>();
        if (info.TryGetProperty(PropertyName.CurrentQualityPreset, out var _value_CurrentQualityPreset))
            this.CurrentQualityPreset = _value_CurrentQualityPreset.As<global::GodotExtensionatorComponents.GameSettingsResource.QUALITY_PRESETS>();
    }
}

}
