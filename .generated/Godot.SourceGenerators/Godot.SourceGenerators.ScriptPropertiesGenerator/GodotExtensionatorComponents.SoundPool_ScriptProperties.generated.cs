using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SoundPool
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'PoolPlayersNumber' property.
        /// </summary>
        public new static readonly global::Godot.StringName PoolPlayersNumber = "PoolPlayersNumber";
        /// <summary>
        /// Cached name for the 'StreamPlayersPool' field.
        /// </summary>
        public new static readonly global::Godot.StringName StreamPlayersPool = "StreamPlayersPool";
        /// <summary>
        /// Cached name for the '_poolPlayersNumber' field.
        /// </summary>
        public new static readonly global::Godot.StringName _poolPlayersNumber = "_poolPlayersNumber";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.PoolPlayersNumber) {
            this.PoolPlayersNumber = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        else if (name == PropertyName._poolPlayersNumber) {
            this._poolPlayersNumber = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.PoolPlayersNumber) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this.PoolPlayersNumber);
            return true;
        }
        else if (name == PropertyName.StreamPlayersPool) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromArray(this.StreamPlayersPool);
            return true;
        }
        else if (name == PropertyName._poolPlayersNumber) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this._poolPlayersNumber);
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
        properties.Add(new(type: (global::Godot.Variant.Type)28, name: PropertyName.StreamPlayersPool, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.PoolPlayersNumber, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName._poolPlayersNumber, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
