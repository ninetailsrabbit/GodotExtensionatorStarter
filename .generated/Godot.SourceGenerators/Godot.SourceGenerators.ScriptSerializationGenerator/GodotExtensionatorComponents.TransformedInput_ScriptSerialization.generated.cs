using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class TransformedInput
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.MoveRightAction, global::Godot.Variant.From<string>(this.MoveRightAction));
        info.AddProperty(PropertyName.MoveLeftAction, global::Godot.Variant.From<string>(this.MoveLeftAction));
        info.AddProperty(PropertyName.MoveForwardAction, global::Godot.Variant.From<string>(this.MoveForwardAction));
        info.AddProperty(PropertyName.MoveBackAction, global::Godot.Variant.From<string>(this.MoveBackAction));
        info.AddProperty(PropertyName.Deadzone, global::Godot.Variant.From<float>(this.Deadzone));
        info.AddProperty(PropertyName.InputDirection, global::Godot.Variant.From<global::Godot.Vector2>(this.InputDirection));
        info.AddProperty(PropertyName.InputDirectionDeadzoneSquareShape, global::Godot.Variant.From<global::Godot.Vector2>(this.InputDirectionDeadzoneSquareShape));
        info.AddProperty(PropertyName.InputDirectionHorizontalAxis, global::Godot.Variant.From<float>(this.InputDirectionHorizontalAxis));
        info.AddProperty(PropertyName.InputDirectionVerticalAxis, global::Godot.Variant.From<float>(this.InputDirectionVerticalAxis));
        info.AddProperty(PropertyName.InputDirectionHorizontalAxisAppliedDeadzone, global::Godot.Variant.From<float>(this.InputDirectionHorizontalAxisAppliedDeadzone));
        info.AddProperty(PropertyName.InputDirectionVerticalAxisAppliedDeadzone, global::Godot.Variant.From<float>(this.InputDirectionVerticalAxisAppliedDeadzone));
        info.AddProperty(PropertyName.WorldCoordinateSpaceDirection, global::Godot.Variant.From<global::Godot.Vector3>(this.WorldCoordinateSpaceDirection));
        info.AddProperty(PropertyName.PreviousInputDirection, global::Godot.Variant.From<global::Godot.Vector2>(this.PreviousInputDirection));
        info.AddProperty(PropertyName.PreviousInputDirectionDeadzoneSquareShape, global::Godot.Variant.From<global::Godot.Vector2>(this.PreviousInputDirectionDeadzoneSquareShape));
        info.AddProperty(PropertyName.PreviousInputDirectionHorizontalAxis, global::Godot.Variant.From<float>(this.PreviousInputDirectionHorizontalAxis));
        info.AddProperty(PropertyName.PreviousInputDirectionVerticalAxis, global::Godot.Variant.From<float>(this.PreviousInputDirectionVerticalAxis));
        info.AddProperty(PropertyName.PreviousInputDirectionHorizontalAxisAppliedDeadzone, global::Godot.Variant.From<float>(this.PreviousInputDirectionHorizontalAxisAppliedDeadzone));
        info.AddProperty(PropertyName.PreviousInputDirectionVerticalAxisAppliedDeadzone, global::Godot.Variant.From<float>(this.PreviousInputDirectionVerticalAxisAppliedDeadzone));
        info.AddProperty(PropertyName.PreviousWorldCoordinateSpaceDirection, global::Godot.Variant.From<global::Godot.Vector3>(this.PreviousWorldCoordinateSpaceDirection));
        info.AddProperty(PropertyName.Actor, global::Godot.Variant.From<global::Godot.Node>(this.Actor));
        info.AddProperty(PropertyName._deadzone, global::Godot.Variant.From<float>(this._deadzone));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.MoveRightAction, out var _value_MoveRightAction))
            this.MoveRightAction = _value_MoveRightAction.As<string>();
        if (info.TryGetProperty(PropertyName.MoveLeftAction, out var _value_MoveLeftAction))
            this.MoveLeftAction = _value_MoveLeftAction.As<string>();
        if (info.TryGetProperty(PropertyName.MoveForwardAction, out var _value_MoveForwardAction))
            this.MoveForwardAction = _value_MoveForwardAction.As<string>();
        if (info.TryGetProperty(PropertyName.MoveBackAction, out var _value_MoveBackAction))
            this.MoveBackAction = _value_MoveBackAction.As<string>();
        if (info.TryGetProperty(PropertyName.Deadzone, out var _value_Deadzone))
            this.Deadzone = _value_Deadzone.As<float>();
        if (info.TryGetProperty(PropertyName.InputDirection, out var _value_InputDirection))
            this.InputDirection = _value_InputDirection.As<global::Godot.Vector2>();
        if (info.TryGetProperty(PropertyName.InputDirectionDeadzoneSquareShape, out var _value_InputDirectionDeadzoneSquareShape))
            this.InputDirectionDeadzoneSquareShape = _value_InputDirectionDeadzoneSquareShape.As<global::Godot.Vector2>();
        if (info.TryGetProperty(PropertyName.InputDirectionHorizontalAxis, out var _value_InputDirectionHorizontalAxis))
            this.InputDirectionHorizontalAxis = _value_InputDirectionHorizontalAxis.As<float>();
        if (info.TryGetProperty(PropertyName.InputDirectionVerticalAxis, out var _value_InputDirectionVerticalAxis))
            this.InputDirectionVerticalAxis = _value_InputDirectionVerticalAxis.As<float>();
        if (info.TryGetProperty(PropertyName.InputDirectionHorizontalAxisAppliedDeadzone, out var _value_InputDirectionHorizontalAxisAppliedDeadzone))
            this.InputDirectionHorizontalAxisAppliedDeadzone = _value_InputDirectionHorizontalAxisAppliedDeadzone.As<float>();
        if (info.TryGetProperty(PropertyName.InputDirectionVerticalAxisAppliedDeadzone, out var _value_InputDirectionVerticalAxisAppliedDeadzone))
            this.InputDirectionVerticalAxisAppliedDeadzone = _value_InputDirectionVerticalAxisAppliedDeadzone.As<float>();
        if (info.TryGetProperty(PropertyName.WorldCoordinateSpaceDirection, out var _value_WorldCoordinateSpaceDirection))
            this.WorldCoordinateSpaceDirection = _value_WorldCoordinateSpaceDirection.As<global::Godot.Vector3>();
        if (info.TryGetProperty(PropertyName.PreviousInputDirection, out var _value_PreviousInputDirection))
            this.PreviousInputDirection = _value_PreviousInputDirection.As<global::Godot.Vector2>();
        if (info.TryGetProperty(PropertyName.PreviousInputDirectionDeadzoneSquareShape, out var _value_PreviousInputDirectionDeadzoneSquareShape))
            this.PreviousInputDirectionDeadzoneSquareShape = _value_PreviousInputDirectionDeadzoneSquareShape.As<global::Godot.Vector2>();
        if (info.TryGetProperty(PropertyName.PreviousInputDirectionHorizontalAxis, out var _value_PreviousInputDirectionHorizontalAxis))
            this.PreviousInputDirectionHorizontalAxis = _value_PreviousInputDirectionHorizontalAxis.As<float>();
        if (info.TryGetProperty(PropertyName.PreviousInputDirectionVerticalAxis, out var _value_PreviousInputDirectionVerticalAxis))
            this.PreviousInputDirectionVerticalAxis = _value_PreviousInputDirectionVerticalAxis.As<float>();
        if (info.TryGetProperty(PropertyName.PreviousInputDirectionHorizontalAxisAppliedDeadzone, out var _value_PreviousInputDirectionHorizontalAxisAppliedDeadzone))
            this.PreviousInputDirectionHorizontalAxisAppliedDeadzone = _value_PreviousInputDirectionHorizontalAxisAppliedDeadzone.As<float>();
        if (info.TryGetProperty(PropertyName.PreviousInputDirectionVerticalAxisAppliedDeadzone, out var _value_PreviousInputDirectionVerticalAxisAppliedDeadzone))
            this.PreviousInputDirectionVerticalAxisAppliedDeadzone = _value_PreviousInputDirectionVerticalAxisAppliedDeadzone.As<float>();
        if (info.TryGetProperty(PropertyName.PreviousWorldCoordinateSpaceDirection, out var _value_PreviousWorldCoordinateSpaceDirection))
            this.PreviousWorldCoordinateSpaceDirection = _value_PreviousWorldCoordinateSpaceDirection.As<global::Godot.Vector3>();
        if (info.TryGetProperty(PropertyName.Actor, out var _value_Actor))
            this.Actor = _value_Actor.As<global::Godot.Node>();
        if (info.TryGetProperty(PropertyName._deadzone, out var _value__deadzone))
            this._deadzone = _value__deadzone.As<float>();
    }
}

}
