using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class LoadingScreen
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.CanvasLayer.PropertyName {
        /// <summary>
        /// Cached name for the 'SceneTransitionManager' property.
        /// </summary>
        public new static readonly global::Godot.StringName SceneTransitionManager = "SceneTransitionManager";
        /// <summary>
        /// Cached name for the 'nextScenePath' field.
        /// </summary>
        public new static readonly global::Godot.StringName nextScenePath = "nextScenePath";
        /// <summary>
        /// Cached name for the 'UseSubThreads' field.
        /// </summary>
        public new static readonly global::Godot.StringName UseSubThreads = "UseSubThreads";
        /// <summary>
        /// Cached name for the 'CacheMode' field.
        /// </summary>
        public new static readonly global::Godot.StringName CacheMode = "CacheMode";
        /// <summary>
        /// Cached name for the 'Progress' field.
        /// </summary>
        public new static readonly global::Godot.StringName Progress = "Progress";
        /// <summary>
        /// Cached name for the 'SceneLoadStatus' field.
        /// </summary>
        public new static readonly global::Godot.StringName SceneLoadStatus = "SceneLoadStatus";
        /// <summary>
        /// Cached name for the 'CurrentProgressValue' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentProgressValue = "CurrentProgressValue";
        /// <summary>
        /// Cached name for the 'SmoothValue' field.
        /// </summary>
        public new static readonly global::Godot.StringName SmoothValue = "SmoothValue";
        /// <summary>
        /// Cached name for the 'Loading' field.
        /// </summary>
        public new static readonly global::Godot.StringName Loading = "Loading";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.SceneTransitionManager) {
            this.SceneTransitionManager = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.SceneTransitionManager>(value);
            return true;
        }
        else if (name == PropertyName.nextScenePath) {
            this.nextScenePath = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.UseSubThreads) {
            this.UseSubThreads = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.CacheMode) {
            this.CacheMode = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ResourceLoader.CacheMode>(value);
            return true;
        }
        else if (name == PropertyName.Progress) {
            this.Progress = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Collections.Array>(value);
            return true;
        }
        else if (name == PropertyName.SceneLoadStatus) {
            this.SceneLoadStatus = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ResourceLoader.ThreadLoadStatus>(value);
            return true;
        }
        else if (name == PropertyName.CurrentProgressValue) {
            this.CurrentProgressValue = global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(value);
            return true;
        }
        else if (name == PropertyName.SmoothValue) {
            this.SmoothValue = global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(value);
            return true;
        }
        else if (name == PropertyName.Loading) {
            this.Loading = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.SceneTransitionManager) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.SceneTransitionManager>(this.SceneTransitionManager);
            return true;
        }
        else if (name == PropertyName.nextScenePath) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.nextScenePath);
            return true;
        }
        else if (name == PropertyName.UseSubThreads) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.UseSubThreads);
            return true;
        }
        else if (name == PropertyName.CacheMode) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.ResourceLoader.CacheMode>(this.CacheMode);
            return true;
        }
        else if (name == PropertyName.Progress) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Collections.Array>(this.Progress);
            return true;
        }
        else if (name == PropertyName.SceneLoadStatus) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.ResourceLoader.ThreadLoadStatus>(this.SceneLoadStatus);
            return true;
        }
        else if (name == PropertyName.CurrentProgressValue) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<double>(this.CurrentProgressValue);
            return true;
        }
        else if (name == PropertyName.SmoothValue) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<double>(this.SmoothValue);
            return true;
        }
        else if (name == PropertyName.Loading) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Loading);
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
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.nextScenePath, hint: (global::Godot.PropertyHint)13, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.UseSubThreads, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.CacheMode, hint: (global::Godot.PropertyHint)2, hintString: "Ignore,Reuse,Replace", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)28, name: PropertyName.Progress, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.SceneLoadStatus, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.CurrentProgressValue, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.SmoothValue, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Loading, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.SceneTransitionManager, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
