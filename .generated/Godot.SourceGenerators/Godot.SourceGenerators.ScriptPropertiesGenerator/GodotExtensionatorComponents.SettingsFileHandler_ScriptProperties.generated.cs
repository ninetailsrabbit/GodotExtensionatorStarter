using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SettingsFileHandler
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'GamepadControllerManager' property.
        /// </summary>
        public new static readonly global::Godot.StringName GamepadControllerManager = "GamepadControllerManager";
        /// <summary>
        /// Cached name for the 'SettingsFilePath' field.
        /// </summary>
        public new static readonly global::Godot.StringName SettingsFilePath = "SettingsFilePath";
        /// <summary>
        /// Cached name for the 'ConfigFileApi' field.
        /// </summary>
        public new static readonly global::Godot.StringName ConfigFileApi = "ConfigFileApi";
        /// <summary>
        /// Cached name for the 'IncludeUIKeybindings' field.
        /// </summary>
        public new static readonly global::Godot.StringName IncludeUIKeybindings = "IncludeUIKeybindings";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.GamepadControllerManager) {
            this.GamepadControllerManager = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GamepadControllerAutoload>(value);
            return true;
        }
        else if (name == PropertyName.SettingsFilePath) {
            this.SettingsFilePath = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.ConfigFileApi) {
            this.ConfigFileApi = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(value);
            return true;
        }
        else if (name == PropertyName.IncludeUIKeybindings) {
            this.IncludeUIKeybindings = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.GamepadControllerManager) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.GamepadControllerAutoload>(this.GamepadControllerManager);
            return true;
        }
        else if (name == PropertyName.SettingsFilePath) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.SettingsFilePath);
            return true;
        }
        else if (name == PropertyName.ConfigFileApi) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.ConfigFile>(this.ConfigFileApi);
            return true;
        }
        else if (name == PropertyName.IncludeUIKeybindings) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.IncludeUIKeybindings);
            return true;
        }
        return base.GetGodotClassPropertyValue(name, out value);
    }
    /// <summary>
    /// Get the property information for all the properties declared in this class.
    /// This method is used by Godot to register the available properties in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.PropertyInfo> GetGodotPropertyList()
    {
        var properties = new global::System.Collections.Generic.List<global::Godot.Bridge.PropertyInfo>();
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.SettingsFilePath, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.ConfigFileApi, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.IncludeUIKeybindings, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.GamepadControllerManager, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
