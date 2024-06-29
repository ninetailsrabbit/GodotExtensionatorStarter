namespace GodotExtensionatorStarter {

partial class LoadingScreen
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
        string __nextScenePath_default_value = string.Empty;
        values.Add(PropertyName.nextScenePath, global::Godot.Variant.From<string>(__nextScenePath_default_value));
        bool __UseSubThreads_default_value = false;
        values.Add(PropertyName.UseSubThreads, global::Godot.Variant.From<bool>(__UseSubThreads_default_value));
        global::Godot.ResourceLoader.CacheMode __CacheMode_default_value = global::Godot.ResourceLoader.CacheMode.Reuse;
        values.Add(PropertyName.CacheMode, global::Godot.Variant.From<global::Godot.ResourceLoader.CacheMode>(__CacheMode_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
