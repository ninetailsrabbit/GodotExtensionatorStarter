using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class Transition
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.FromState, global::Godot.Variant.From<global::GodotExtensionatorComponents.MachineState>(this.FromState));
        info.AddProperty(PropertyName.ToState, global::Godot.Variant.From<global::GodotExtensionatorComponents.MachineState>(this.ToState));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.FromState, out var _value_FromState))
            this.FromState = _value_FromState.As<global::GodotExtensionatorComponents.MachineState>();
        if (info.TryGetProperty(PropertyName.ToState, out var _value_ToState))
            this.ToState = _value_ToState.As<global::GodotExtensionatorComponents.MachineState>();
    }
}

}
