using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class GameSettingsResource
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Resource.PropertyName {
        /// <summary>
        /// Cached name for the 'AudioVolumes' field.
        /// </summary>
        public new static readonly global::Godot.StringName AudioVolumes = "AudioVolumes";
        /// <summary>
        /// Cached name for the 'MouseSensitivity' field.
        /// </summary>
        public new static readonly global::Godot.StringName MouseSensitivity = "MouseSensitivity";
        /// <summary>
        /// Cached name for the 'ControllerVibration' field.
        /// </summary>
        public new static readonly global::Godot.StringName ControllerVibration = "ControllerVibration";
        /// <summary>
        /// Cached name for the 'AllowTelemetry' field.
        /// </summary>
        public new static readonly global::Godot.StringName AllowTelemetry = "AllowTelemetry";
        /// <summary>
        /// Cached name for the 'CurrentLanguage' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentLanguage = "CurrentLanguage";
        /// <summary>
        /// Cached name for the 'ScreenBrightness' field.
        /// </summary>
        public new static readonly global::Godot.StringName ScreenBrightness = "ScreenBrightness";
        /// <summary>
        /// Cached name for the 'PhotoSensitive' field.
        /// </summary>
        public new static readonly global::Godot.StringName PhotoSensitive = "PhotoSensitive";
        /// <summary>
        /// Cached name for the 'ScreenShake' field.
        /// </summary>
        public new static readonly global::Godot.StringName ScreenShake = "ScreenShake";
        /// <summary>
        /// Cached name for the 'DisplayMode' field.
        /// </summary>
        public new static readonly global::Godot.StringName DisplayMode = "DisplayMode";
        /// <summary>
        /// Cached name for the 'Vsync' field.
        /// </summary>
        public new static readonly global::Godot.StringName Vsync = "Vsync";
        /// <summary>
        /// Cached name for the 'AntiaAliasing' field.
        /// </summary>
        public new static readonly global::Godot.StringName AntiaAliasing = "AntiaAliasing";
        /// <summary>
        /// Cached name for the 'Resolutions' field.
        /// </summary>
        public new static readonly global::Godot.StringName Resolutions = "Resolutions";
        /// <summary>
        /// Cached name for the 'CurrentQualityPreset' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentQualityPreset = "CurrentQualityPreset";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.AudioVolumes) {
            this.AudioVolumes = global::Godot.NativeInterop.VariantUtils.ConvertToDictionary<string, float>(value);
            return true;
        }
        else if (name == PropertyName.MouseSensitivity) {
            this.MouseSensitivity = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.ControllerVibration) {
            this.ControllerVibration = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.AllowTelemetry) {
            this.AllowTelemetry = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.CurrentLanguage) {
            this.CurrentLanguage = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.Localization.LANGUAGES>(value);
            return true;
        }
        else if (name == PropertyName.ScreenBrightness) {
            this.ScreenBrightness = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.PhotoSensitive) {
            this.PhotoSensitive = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.ScreenShake) {
            this.ScreenShake = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.DisplayMode) {
            this.DisplayMode = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.DisplayServer.WindowMode>(value);
            return true;
        }
        else if (name == PropertyName.Vsync) {
            this.Vsync = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.DisplayServer.VSyncMode>(value);
            return true;
        }
        else if (name == PropertyName.AntiaAliasing) {
            this.AntiaAliasing = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Viewport.Msaa>(value);
            return true;
        }
        else if (name == PropertyName.Resolutions) {
            this.Resolutions = global::Godot.NativeInterop.VariantUtils.ConvertToDictionary<string, global::Godot.Collections.Array<global::Godot.Vector2I>>(value);
            return true;
        }
        else if (name == PropertyName.CurrentQualityPreset) {
            this.CurrentQualityPreset = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GameSettingsResource.QUALITY_PRESETS>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.AudioVolumes) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromDictionary(this.AudioVolumes);
            return true;
        }
        else if (name == PropertyName.MouseSensitivity) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.MouseSensitivity);
            return true;
        }
        else if (name == PropertyName.ControllerVibration) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.ControllerVibration);
            return true;
        }
        else if (name == PropertyName.AllowTelemetry) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.AllowTelemetry);
            return true;
        }
        else if (name == PropertyName.CurrentLanguage) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.Localization.LANGUAGES>(this.CurrentLanguage);
            return true;
        }
        else if (name == PropertyName.ScreenBrightness) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.ScreenBrightness);
            return true;
        }
        else if (name == PropertyName.PhotoSensitive) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.PhotoSensitive);
            return true;
        }
        else if (name == PropertyName.ScreenShake) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.ScreenShake);
            return true;
        }
        else if (name == PropertyName.DisplayMode) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.DisplayServer.WindowMode>(this.DisplayMode);
            return true;
        }
        else if (name == PropertyName.Vsync) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.DisplayServer.VSyncMode>(this.Vsync);
            return true;
        }
        else if (name == PropertyName.AntiaAliasing) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Viewport.Msaa>(this.AntiaAliasing);
            return true;
        }
        else if (name == PropertyName.Resolutions) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromDictionary(this.Resolutions);
            return true;
        }
        else if (name == PropertyName.CurrentQualityPreset) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.GameSettingsResource.QUALITY_PRESETS>(this.CurrentQualityPreset);
            return true;
        }
        return base.GetGodotClassPropertyValue(name, out value);
    }
    /// <summary>
    /// Get the property information for all the properties declared in this class.
    /// This method is used by Godot to register the available properties in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.PropertyInfo> GetGodotPropertyList()
    {
        var properties = new global::System.Collections.Generic.List<global::Godot.Bridge.PropertyInfo>();
        properties.Add(new(type: (global::Godot.Variant.Type)27, name: PropertyName.AudioVolumes, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.MouseSensitivity, hint: (global::Godot.PropertyHint)1, hintString: "0.1f, 20f, 0.1f", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.ControllerVibration, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.AllowTelemetry, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.CurrentLanguage, hint: (global::Godot.PropertyHint)2, hintString: "ENGLISH,CZECH,DANISH,GERMAN,GREEK,ESPERANTO,SPANISH,FRENCH,INDONESIAN,ITALIAN,LATVIAN,POLISH,PORTUGUESE_BRAZILIAN,PORTUGUESE,RUSSIAN,CHINESE_SIMPLIFIED,CHINESE_TRADITIONAL,NORWEGIAN_BOKMAL,HUNGARIAN,ROMANIAN,KOREAN,TURKISH,JAPANESE,UKRAINIAN", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.ScreenBrightness, hint: (global::Godot.PropertyHint)1, hintString: "0, 1f, 0.01f", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.PhotoSensitive, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.ScreenShake, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.DisplayMode, hint: (global::Godot.PropertyHint)2, hintString: "Windowed,Minimized,Maximized,Fullscreen,ExclusiveFullscreen", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.Vsync, hint: (global::Godot.PropertyHint)2, hintString: "Disabled,Enabled,Adaptive,Mailbox", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.AntiaAliasing, hint: (global::Godot.PropertyHint)2, hintString: "Disabled,Msaa2X,Msaa4X,Msaa8X,Max", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)27, name: PropertyName.Resolutions, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.CurrentQualityPreset, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
