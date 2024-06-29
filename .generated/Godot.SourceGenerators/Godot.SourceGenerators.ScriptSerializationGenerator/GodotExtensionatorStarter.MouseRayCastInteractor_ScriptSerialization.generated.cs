using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class MouseRayCastInteractor
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.OriginCamera, global::Godot.Variant.From<global::Godot.Camera3D>(this.OriginCamera));
        info.AddProperty(PropertyName.GameGlobals, global::Godot.Variant.From<global::GodotExtensionatorStarter.GameGlobals>(this.GameGlobals));
        info.AddProperty(PropertyName.RayLength, global::Godot.Variant.From<float>(this.RayLength));
        info.AddProperty(PropertyName.InteractButton, global::Godot.Variant.From<global::Godot.MouseButton>(this.InteractButton));
        info.AddProperty(PropertyName.CurrentInteractable, global::Godot.Variant.From<global::GodotExtensionatorStarter.Interactable3D>(this.CurrentInteractable));
        info.AddProperty(PropertyName.Focused, global::Godot.Variant.From<bool>(this.Focused));
        info.AddProperty(PropertyName.Interacting, global::Godot.Variant.From<bool>(this.Interacting));
        info.AddProperty(PropertyName.MousePosition, global::Godot.Variant.From<global::Godot.Vector2>(this.MousePosition));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.OriginCamera, out var _value_OriginCamera))
            this.OriginCamera = _value_OriginCamera.As<global::Godot.Camera3D>();
        if (info.TryGetProperty(PropertyName.GameGlobals, out var _value_GameGlobals))
            this.GameGlobals = _value_GameGlobals.As<global::GodotExtensionatorStarter.GameGlobals>();
        if (info.TryGetProperty(PropertyName.RayLength, out var _value_RayLength))
            this.RayLength = _value_RayLength.As<float>();
        if (info.TryGetProperty(PropertyName.InteractButton, out var _value_InteractButton))
            this.InteractButton = _value_InteractButton.As<global::Godot.MouseButton>();
        if (info.TryGetProperty(PropertyName.CurrentInteractable, out var _value_CurrentInteractable))
            this.CurrentInteractable = _value_CurrentInteractable.As<global::GodotExtensionatorStarter.Interactable3D>();
        if (info.TryGetProperty(PropertyName.Focused, out var _value_Focused))
            this.Focused = _value_Focused.As<bool>();
        if (info.TryGetProperty(PropertyName.Interacting, out var _value_Interacting))
            this.Interacting = _value_Interacting.As<bool>();
        if (info.TryGetProperty(PropertyName.MousePosition, out var _value_MousePosition))
            this.MousePosition = _value_MousePosition.As<global::Godot.Vector2>();
    }
}

}
