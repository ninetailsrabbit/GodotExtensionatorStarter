using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class GamepadControllerAutoload
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.CurrentControllerGUID, global::Godot.Variant.From<string>(this.CurrentControllerGUID));
        info.AddProperty(PropertyName.CurrentControllerName, global::Godot.Variant.From<string>(this.CurrentControllerName));
        info.AddProperty(PropertyName.CurrentDeviceId, global::Godot.Variant.From<int>(this.CurrentDeviceId));
        info.AddProperty(PropertyName.Connected, global::Godot.Variant.From<bool>(this.Connected));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.CurrentControllerGUID, out var _value_CurrentControllerGUID))
            this.CurrentControllerGUID = _value_CurrentControllerGUID.As<string>();
        if (info.TryGetProperty(PropertyName.CurrentControllerName, out var _value_CurrentControllerName))
            this.CurrentControllerName = _value_CurrentControllerName.As<string>();
        if (info.TryGetProperty(PropertyName.CurrentDeviceId, out var _value_CurrentDeviceId))
            this.CurrentDeviceId = _value_CurrentDeviceId.As<int>();
        if (info.TryGetProperty(PropertyName.Connected, out var _value_Connected))
            this.Connected = _value_Connected.As<bool>();
    }
}

}
