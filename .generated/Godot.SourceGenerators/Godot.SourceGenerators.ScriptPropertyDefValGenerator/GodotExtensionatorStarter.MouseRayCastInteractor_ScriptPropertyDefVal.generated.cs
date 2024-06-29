namespace GodotExtensionatorStarter {

partial class MouseRayCastInteractor
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
        var values = new global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant>(3);
        global::Godot.Camera3D __OriginCamera_default_value = default!;
        values.Add(PropertyName.OriginCamera, global::Godot.Variant.From<global::Godot.Camera3D>(__OriginCamera_default_value));
        float __RayLength_default_value = 1000f;
        values.Add(PropertyName.RayLength, global::Godot.Variant.From<float>(__RayLength_default_value));
        global::Godot.MouseButton __InteractButton_default_value = global::Godot.MouseButton.Left;
        values.Add(PropertyName.InteractButton, global::Godot.Variant.From<global::Godot.MouseButton>(__InteractButton_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
