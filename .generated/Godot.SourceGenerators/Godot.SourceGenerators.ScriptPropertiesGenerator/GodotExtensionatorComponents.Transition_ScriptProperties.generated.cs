using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class Transition
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.RefCounted.PropertyName {
        /// <summary>
        /// Cached name for the 'FromState' property.
        /// </summary>
        public new static readonly global::Godot.StringName FromState = "FromState";
        /// <summary>
        /// Cached name for the 'ToState' property.
        /// </summary>
        public new static readonly global::Godot.StringName ToState = "ToState";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.FromState) {
            this.FromState = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(value);
            return true;
        }
        else if (name == PropertyName.ToState) {
            this.ToState = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.FromState) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.MachineState>(this.FromState);
            return true;
        }
        else if (name == PropertyName.ToState) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.MachineState>(this.ToState);
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
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.FromState, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.ToState, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
