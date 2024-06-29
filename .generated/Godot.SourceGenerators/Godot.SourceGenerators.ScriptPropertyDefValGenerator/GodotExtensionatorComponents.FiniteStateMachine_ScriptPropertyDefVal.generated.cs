namespace GodotExtensionatorComponents {

partial class FiniteStateMachine
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
#if TOOLS
    /// <summary>
    /// Get the default values for all properties declared in this class.
    /// This method is used by Godot to determine the value that will be
    /// used by the inspector when resetting properties.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant> GetGodotPropertyDefaultValues()
    {
        var values = new global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant>(4);
        global::GodotExtensionatorComponents.MachineState __CurrentState_default_value = default!;
        values.Add(PropertyName.CurrentState, global::Godot.Variant.From<global::GodotExtensionatorComponents.MachineState>(__CurrentState_default_value));
        bool __EnableStack_default_value = true;
        values.Add(PropertyName.EnableStack, global::Godot.Variant.From<bool>(__EnableStack_default_value));
        int __StackCapacity_default_value = 3;
        values.Add(PropertyName.StackCapacity, global::Godot.Variant.From<int>(__StackCapacity_default_value));
        bool __FlushStackWhenReachCapacity_default_value = false;
        values.Add(PropertyName.FlushStackWhenReachCapacity, global::Godot.Variant.From<bool>(__FlushStackWhenReachCapacity_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
