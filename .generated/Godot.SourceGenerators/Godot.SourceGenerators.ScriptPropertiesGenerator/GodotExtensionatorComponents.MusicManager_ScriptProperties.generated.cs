using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class MusicManager
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'MainAudioStreamPlayer' property.
        /// </summary>
        public new static readonly global::Godot.StringName MainAudioStreamPlayer = "MainAudioStreamPlayer";
        /// <summary>
        /// Cached name for the 'SecondaryAudioStreamPlayer' property.
        /// </summary>
        public new static readonly global::Godot.StringName SecondaryAudioStreamPlayer = "SecondaryAudioStreamPlayer";
        /// <summary>
        /// Cached name for the 'CurrentAudioStreamPlayer' property.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentAudioStreamPlayer = "CurrentAudioStreamPlayer";
        /// <summary>
        /// Cached name for the 'MusicBank' field.
        /// </summary>
        public new static readonly global::Godot.StringName MusicBank = "MusicBank";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.MainAudioStreamPlayer) {
            this.MainAudioStreamPlayer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStreamPlayer>(value);
            return true;
        }
        else if (name == PropertyName.SecondaryAudioStreamPlayer) {
            this.SecondaryAudioStreamPlayer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStreamPlayer>(value);
            return true;
        }
        else if (name == PropertyName.CurrentAudioStreamPlayer) {
            this.CurrentAudioStreamPlayer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStreamPlayer>(value);
            return true;
        }
        else if (name == PropertyName.MusicBank) {
            this.MusicBank = global::Godot.NativeInterop.VariantUtils.ConvertToDictionary<string, global::Godot.AudioStream>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.MainAudioStreamPlayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.AudioStreamPlayer>(this.MainAudioStreamPlayer);
            return true;
        }
        else if (name == PropertyName.SecondaryAudioStreamPlayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.AudioStreamPlayer>(this.SecondaryAudioStreamPlayer);
            return true;
        }
        else if (name == PropertyName.CurrentAudioStreamPlayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.AudioStreamPlayer>(this.CurrentAudioStreamPlayer);
            return true;
        }
        else if (name == PropertyName.MusicBank) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromDictionary(this.MusicBank);
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
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.MainAudioStreamPlayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.SecondaryAudioStreamPlayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.CurrentAudioStreamPlayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)27, name: PropertyName.MusicBank, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
