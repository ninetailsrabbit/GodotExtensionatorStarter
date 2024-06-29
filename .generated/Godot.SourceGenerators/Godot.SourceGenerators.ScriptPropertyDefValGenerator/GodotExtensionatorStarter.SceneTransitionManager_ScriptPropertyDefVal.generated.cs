namespace GodotExtensionatorStarter {

partial class SceneTransitionManager
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
        var values = new global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant>(1);
        global::Godot.PackedScene __LoadingScreenScene_default_value = (global::Godot.PackedScene)global::Godot.GD.Load("res://autoload/scenes/loading/LoadingScreen.tscn");
        values.Add(PropertyName.LoadingScreenScene, global::Godot.Variant.From<global::Godot.PackedScene>(__LoadingScreenScene_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
