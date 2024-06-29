namespace GodotExtensionatorComponents {

partial class GameSettingsResource
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
        var values = new global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant>(11);
        global::Godot.Collections.Dictionary<string, float> __AudioVolumes_default_value = new()  {
                {"music", 1f  },
                {"sfx", 1f  },
                {"echosfx", 1f  },
                {"voice", 1f  },
                {"ui", 1f  },
                {"ambient", 1f  },
    };
        values.Add(PropertyName.AudioVolumes, global::Godot.Variant.CreateFrom(__AudioVolumes_default_value));
        float __MouseSensitivity_default_value = 3f;
        values.Add(PropertyName.MouseSensitivity, global::Godot.Variant.From<float>(__MouseSensitivity_default_value));
        bool __ControllerVibration_default_value = true;
        values.Add(PropertyName.ControllerVibration, global::Godot.Variant.From<bool>(__ControllerVibration_default_value));
        bool __AllowTelemetry_default_value = false;
        values.Add(PropertyName.AllowTelemetry, global::Godot.Variant.From<bool>(__AllowTelemetry_default_value));
        global::GodotExtensionatorComponents.Localization.LANGUAGES __CurrentLanguage_default_value = global::GodotExtensionatorComponents.Localization.LANGUAGES.ENGLISH;
        values.Add(PropertyName.CurrentLanguage, global::Godot.Variant.From<global::GodotExtensionatorComponents.Localization.LANGUAGES>(__CurrentLanguage_default_value));
        float __ScreenBrightness_default_value = 1f;
        values.Add(PropertyName.ScreenBrightness, global::Godot.Variant.From<float>(__ScreenBrightness_default_value));
        bool __PhotoSensitive_default_value = true;
        values.Add(PropertyName.PhotoSensitive, global::Godot.Variant.From<bool>(__PhotoSensitive_default_value));
        bool __ScreenShake_default_value = true;
        values.Add(PropertyName.ScreenShake, global::Godot.Variant.From<bool>(__ScreenShake_default_value));
        global::Godot.DisplayServer.WindowMode __DisplayMode_default_value = global::Godot.DisplayServer.WindowMode.Windowed;
        values.Add(PropertyName.DisplayMode, global::Godot.Variant.From<global::Godot.DisplayServer.WindowMode>(__DisplayMode_default_value));
        global::Godot.DisplayServer.VSyncMode __Vsync_default_value = global::Godot.DisplayServer.VSyncMode.Disabled;
        values.Add(PropertyName.Vsync, global::Godot.Variant.From<global::Godot.DisplayServer.VSyncMode>(__Vsync_default_value));
        global::Godot.Viewport.Msaa __AntiaAliasing_default_value = global::Godot.Viewport.Msaa.Disabled;
        values.Add(PropertyName.AntiaAliasing, global::Godot.Variant.From<global::Godot.Viewport.Msaa>(__AntiaAliasing_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
