using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class MachineState
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.FSM, global::Godot.Variant.From<global::GodotExtensionatorComponents.FiniteStateMachine>(this.FSM));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.FSM, out var _value_FSM))
            this.FSM = _value_FSM.As<global::GodotExtensionatorComponents.FiniteStateMachine>();
    }
}

}
