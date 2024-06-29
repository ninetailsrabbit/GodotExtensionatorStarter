using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class GameGlobals
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'WorldCollisionLayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName WorldCollisionLayer = "WorldCollisionLayer";
        /// <summary>
        /// Cached name for the 'PlayerCollisionLayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName PlayerCollisionLayer = "PlayerCollisionLayer";
        /// <summary>
        /// Cached name for the 'EnemiesCollisionLayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName EnemiesCollisionLayer = "EnemiesCollisionLayer";
        /// <summary>
        /// Cached name for the 'InteractablesCollisionLayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName InteractablesCollisionLayer = "InteractablesCollisionLayer";
        /// <summary>
        /// Cached name for the 'ThrowablesCollisionLayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName ThrowablesCollisionLayer = "ThrowablesCollisionLayer";
        /// <summary>
        /// Cached name for the 'HitboxesCollisionLayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName HitboxesCollisionLayer = "HitboxesCollisionLayer";
        /// <summary>
        /// Cached name for the 'NextScenePath' field.
        /// </summary>
        public new static readonly global::Godot.StringName NextScenePath = "NextScenePath";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.NextScenePath) {
            this.NextScenePath = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.WorldCollisionLayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<uint>(this.WorldCollisionLayer);
            return true;
        }
        else if (name == PropertyName.PlayerCollisionLayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<uint>(this.PlayerCollisionLayer);
            return true;
        }
        else if (name == PropertyName.EnemiesCollisionLayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<uint>(this.EnemiesCollisionLayer);
            return true;
        }
        else if (name == PropertyName.InteractablesCollisionLayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<uint>(this.InteractablesCollisionLayer);
            return true;
        }
        else if (name == PropertyName.ThrowablesCollisionLayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<uint>(this.ThrowablesCollisionLayer);
            return true;
        }
        else if (name == PropertyName.HitboxesCollisionLayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<uint>(this.HitboxesCollisionLayer);
            return true;
        }
        else if (name == PropertyName.NextScenePath) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.NextScenePath);
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
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.WorldCollisionLayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.PlayerCollisionLayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.EnemiesCollisionLayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.InteractablesCollisionLayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.ThrowablesCollisionLayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.HitboxesCollisionLayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.NextScenePath, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
