namespace GodotExtensionatorComponents {

partial class FootstepManager
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
        global::Godot.RayCast3D __FloorDetectorRaycast_default_value = default!;
        values.Add(PropertyName.FloorDetectorRaycast, global::Godot.Variant.From<global::Godot.RayCast3D>(__FloorDetectorRaycast_default_value));
        bool __UsePitch_default_value = true;
        values.Add(PropertyName.UsePitch, global::Godot.Variant.From<bool>(__UsePitch_default_value));
        float __MinPitchRange_default_value = .9f;
        values.Add(PropertyName.MinPitchRange, global::Godot.Variant.From<float>(__MinPitchRange_default_value));
        float __MaxPitchRange_default_value = 1.3f;
        values.Add(PropertyName.MaxPitchRange, global::Godot.Variant.From<float>(__MaxPitchRange_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
