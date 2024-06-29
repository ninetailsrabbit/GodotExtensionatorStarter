using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class GamepadControllerAutoload
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'CurrentControllerGUID' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerGUID = "CurrentControllerGUID";
        /// <summary>
        /// Cached name for the 'CurrentControllerName' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerName = "CurrentControllerName";
        /// <summary>
        /// Cached name for the 'CurrentDeviceId' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentDeviceId = "CurrentDeviceId";
        /// <summary>
        /// Cached name for the 'Connected' field.
        /// </summary>
        public new static readonly global::Godot.StringName Connected = "Connected";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.CurrentControllerGUID) {
            this.CurrentControllerGUID = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.CurrentControllerName) {
            this.CurrentControllerName = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.CurrentDeviceId) {
            this.CurrentDeviceId = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        else if (name == PropertyName.Connected) {
            this.Connected = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.CurrentControllerGUID) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.CurrentControllerGUID);
            return true;
        }
        else if (name == PropertyName.CurrentControllerName) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.CurrentControllerName);
            return true;
        }
        else if (name == PropertyName.CurrentDeviceId) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this.CurrentDeviceId);
            return true;
        }
        else if (name == PropertyName.Connected) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Connected);
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
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.CurrentControllerGUID, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.CurrentControllerName, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.CurrentDeviceId, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Connected, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
