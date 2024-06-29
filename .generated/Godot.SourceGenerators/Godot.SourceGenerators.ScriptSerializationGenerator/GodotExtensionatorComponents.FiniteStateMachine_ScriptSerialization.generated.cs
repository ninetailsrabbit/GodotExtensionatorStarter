using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class FiniteStateMachine
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.CurrentState, global::Godot.Variant.From<global::GodotExtensionatorComponents.MachineState>(this.CurrentState));
        info.AddProperty(PropertyName.EnableStack, global::Godot.Variant.From<bool>(this.EnableStack));
        info.AddProperty(PropertyName.StackCapacity, global::Godot.Variant.From<int>(this.StackCapacity));
        info.AddProperty(PropertyName.FlushStackWhenReachCapacity, global::Godot.Variant.From<bool>(this.FlushStackWhenReachCapacity));
        info.AddProperty(PropertyName.IsTransitioning, global::Godot.Variant.From<bool>(this.IsTransitioning));
        info.AddProperty(PropertyName.Locked, global::Godot.Variant.From<bool>(this.Locked));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.CurrentState, out var _value_CurrentState))
            this.CurrentState = _value_CurrentState.As<global::GodotExtensionatorComponents.MachineState>();
        if (info.TryGetProperty(PropertyName.EnableStack, out var _value_EnableStack))
            this.EnableStack = _value_EnableStack.As<bool>();
        if (info.TryGetProperty(PropertyName.StackCapacity, out var _value_StackCapacity))
            this.StackCapacity = _value_StackCapacity.As<int>();
        if (info.TryGetProperty(PropertyName.FlushStackWhenReachCapacity, out var _value_FlushStackWhenReachCapacity))
            this.FlushStackWhenReachCapacity = _value_FlushStackWhenReachCapacity.As<bool>();
        if (info.TryGetProperty(PropertyName.IsTransitioning, out var _value_IsTransitioning))
            this.IsTransitioning = _value_IsTransitioning.As<bool>();
        if (info.TryGetProperty(PropertyName.Locked, out var _value_Locked))
            this.Locked = _value_Locked.As<bool>();
    }
}

}
