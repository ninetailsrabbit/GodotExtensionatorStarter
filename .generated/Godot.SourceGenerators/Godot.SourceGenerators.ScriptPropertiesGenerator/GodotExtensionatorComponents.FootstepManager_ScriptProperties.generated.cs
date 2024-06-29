using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class FootstepManager
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node3D.PropertyName {
        /// <summary>
        /// Cached name for the 'FloorDetectorRaycast' property.
        /// </summary>
        public new static readonly global::Godot.StringName FloorDetectorRaycast = "FloorDetectorRaycast";
        /// <summary>
        /// Cached name for the 'IntervalTimer' property.
        /// </summary>
        public new static readonly global::Godot.StringName IntervalTimer = "IntervalTimer";
        /// <summary>
        /// Cached name for the 'UsePitch' field.
        /// </summary>
        public new static readonly global::Godot.StringName UsePitch = "UsePitch";
        /// <summary>
        /// Cached name for the 'MinPitchRange' field.
        /// </summary>
        public new static readonly global::Godot.StringName MinPitchRange = "MinPitchRange";
        /// <summary>
        /// Cached name for the 'MaxPitchRange' field.
        /// </summary>
        public new static readonly global::Godot.StringName MaxPitchRange = "MaxPitchRange";
        /// <summary>
        /// Cached name for the 'SfxPlaying' field.
        /// </summary>
        public new static readonly global::Godot.StringName SfxPlaying = "SfxPlaying";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.FloorDetectorRaycast) {
            this.FloorDetectorRaycast = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.RayCast3D>(value);
            return true;
        }
        else if (name == PropertyName.IntervalTimer) {
            this.IntervalTimer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Timer>(value);
            return true;
        }
        else if (name == PropertyName.UsePitch) {
            this.UsePitch = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.MinPitchRange) {
            this.MinPitchRange = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.MaxPitchRange) {
            this.MaxPitchRange = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.SfxPlaying) {
            this.SfxPlaying = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.FloorDetectorRaycast) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.RayCast3D>(this.FloorDetectorRaycast);
            return true;
        }
        else if (name == PropertyName.IntervalTimer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Timer>(this.IntervalTimer);
            return true;
        }
        else if (name == PropertyName.UsePitch) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.UsePitch);
            return true;
        }
        else if (name == PropertyName.MinPitchRange) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.MinPitchRange);
            return true;
        }
        else if (name == PropertyName.MaxPitchRange) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.MaxPitchRange);
            return true;
        }
        else if (name == PropertyName.SfxPlaying) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.SfxPlaying);
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
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.FloorDetectorRaycast, hint: (global::Godot.PropertyHint)34, hintString: "RayCast3D", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.UsePitch, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.MinPitchRange, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.MaxPitchRange, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.IntervalTimer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.SfxPlaying, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
