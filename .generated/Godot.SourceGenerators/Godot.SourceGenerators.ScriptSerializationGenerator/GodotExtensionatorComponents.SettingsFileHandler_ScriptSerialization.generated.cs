using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SettingsFileHandler
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.GamepadControllerManager, global::Godot.Variant.From<global::GodotExtensionatorComponents.GamepadControllerAutoload>(this.GamepadControllerManager));
        info.AddProperty(PropertyName.SettingsFilePath, global::Godot.Variant.From<string>(this.SettingsFilePath));
        info.AddProperty(PropertyName.ConfigFileApi, global::Godot.Variant.From<global::Godot.ConfigFile>(this.ConfigFileApi));
        info.AddProperty(PropertyName.IncludeUIKeybindings, global::Godot.Variant.From<bool>(this.IncludeUIKeybindings));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.GamepadControllerManager, out var _value_GamepadControllerManager))
            this.GamepadControllerManager = _value_GamepadControllerManager.As<global::GodotExtensionatorComponents.GamepadControllerAutoload>();
        if (info.TryGetProperty(PropertyName.SettingsFilePath, out var _value_SettingsFilePath))
            this.SettingsFilePath = _value_SettingsFilePath.As<string>();
        if (info.TryGetProperty(PropertyName.ConfigFileApi, out var _value_ConfigFileApi))
            this.ConfigFileApi = _value_ConfigFileApi.As<global::Godot.ConfigFile>();
        if (info.TryGetProperty(PropertyName.IncludeUIKeybindings, out var _value_IncludeUIKeybindings))
            this.IncludeUIKeybindings = _value_IncludeUIKeybindings.As<bool>();
    }
}

}
