using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class RayCastInteractor3D
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.GameGlobals, global::Godot.Variant.From<global::GodotExtensionatorStarter.GameGlobals>(this.GameGlobals));
        info.AddProperty(PropertyName.InputAction, global::Godot.Variant.From<string>(this.InputAction));
        info.AddProperty(PropertyName.CurrentInteractable, global::Godot.Variant.From<global::GodotExtensionatorStarter.Interactable3D>(this.CurrentInteractable));
        info.AddProperty(PropertyName.Focused, global::Godot.Variant.From<bool>(this.Focused));
        info.AddProperty(PropertyName.Interacting, global::Godot.Variant.From<bool>(this.Interacting));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.GameGlobals, out var _value_GameGlobals))
            this.GameGlobals = _value_GameGlobals.As<global::GodotExtensionatorStarter.GameGlobals>();
        if (info.TryGetProperty(PropertyName.InputAction, out var _value_InputAction))
            this.InputAction = _value_InputAction.As<string>();
        if (info.TryGetProperty(PropertyName.CurrentInteractable, out var _value_CurrentInteractable))
            this.CurrentInteractable = _value_CurrentInteractable.As<global::GodotExtensionatorStarter.Interactable3D>();
        if (info.TryGetProperty(PropertyName.Focused, out var _value_Focused))
            this.Focused = _value_Focused.As<bool>();
        if (info.TryGetProperty(PropertyName.Interacting, out var _value_Interacting))
            this.Interacting = _value_Interacting.As<bool>();
    }
}

}
