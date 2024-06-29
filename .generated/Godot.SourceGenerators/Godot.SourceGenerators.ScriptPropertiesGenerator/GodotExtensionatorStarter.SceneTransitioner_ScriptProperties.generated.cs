using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class SceneTransitioner
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'TransitionAnimationPlayer' property.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionAnimationPlayer = "TransitionAnimationPlayer";
        /// <summary>
        /// Cached name for the 'ColorRect' property.
        /// </summary>
        public new static readonly global::Godot.StringName ColorRect = "ColorRect";
        /// <summary>
        /// Cached name for the 'LoadingScreenScene' field.
        /// </summary>
        public new static readonly global::Godot.StringName LoadingScreenScene = "LoadingScreenScene";
        /// <summary>
        /// Cached name for the 'NextScenePath' field.
        /// </summary>
        public new static readonly global::Godot.StringName NextScenePath = "NextScenePath";
        /// <summary>
        /// Cached name for the 'RemainingAnimations' field.
        /// </summary>
        public new static readonly global::Godot.StringName RemainingAnimations = "RemainingAnimations";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.TransitionAnimationPlayer) {
            this.TransitionAnimationPlayer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AnimationPlayer>(value);
            return true;
        }
        else if (name == PropertyName.ColorRect) {
            this.ColorRect = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ColorRect>(value);
            return true;
        }
        else if (name == PropertyName.LoadingScreenScene) {
            this.LoadingScreenScene = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.PackedScene>(value);
            return true;
        }
        else if (name == PropertyName.NextScenePath) {
            this.NextScenePath = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.RemainingAnimations) {
            this.RemainingAnimations = global::Godot.NativeInterop.VariantUtils.ConvertToArray<global::GodotExtensionatorStarter.SceneTransitioner.TRANSITIONS>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.TransitionAnimationPlayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.AnimationPlayer>(this.TransitionAnimationPlayer);
            return true;
        }
        else if (name == PropertyName.ColorRect) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.ColorRect>(this.ColorRect);
            return true;
        }
        else if (name == PropertyName.LoadingScreenScene) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.PackedScene>(this.LoadingScreenScene);
            return true;
        }
        else if (name == PropertyName.NextScenePath) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.NextScenePath);
            return true;
        }
        else if (name == PropertyName.RemainingAnimations) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromArray(this.RemainingAnimations);
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
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.LoadingScreenScene, hint: (global::Godot.PropertyHint)17, hintString: "PackedScene", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.TransitionAnimationPlayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.ColorRect, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.NextScenePath, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)28, name: PropertyName.RemainingAnimations, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
