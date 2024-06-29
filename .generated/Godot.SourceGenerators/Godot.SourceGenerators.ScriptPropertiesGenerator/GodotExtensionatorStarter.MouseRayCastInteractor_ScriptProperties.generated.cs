﻿using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class MouseRayCastInteractor
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node3D.PropertyName {
        /// <summary>
        /// Cached name for the 'OriginCamera' property.
        /// </summary>
        public new static readonly global::Godot.StringName OriginCamera = "OriginCamera";
        /// <summary>
        /// Cached name for the 'GameGlobals' property.
        /// </summary>
        public new static readonly global::Godot.StringName GameGlobals = "GameGlobals";
        /// <summary>
        /// Cached name for the 'RayLength' field.
        /// </summary>
        public new static readonly global::Godot.StringName RayLength = "RayLength";
        /// <summary>
        /// Cached name for the 'InteractButton' field.
        /// </summary>
        public new static readonly global::Godot.StringName InteractButton = "InteractButton";
        /// <summary>
        /// Cached name for the 'CurrentInteractable' field.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentInteractable = "CurrentInteractable";
        /// <summary>
        /// Cached name for the 'Focused' field.
        /// </summary>
        public new static readonly global::Godot.StringName Focused = "Focused";
        /// <summary>
        /// Cached name for the 'Interacting' field.
        /// </summary>
        public new static readonly global::Godot.StringName Interacting = "Interacting";
        /// <summary>
        /// Cached name for the 'MousePosition' field.
        /// </summary>
        public new static readonly global::Godot.StringName MousePosition = "MousePosition";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.OriginCamera) {
            this.OriginCamera = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Camera3D>(value);
            return true;
        }
        else if (name == PropertyName.GameGlobals) {
            this.GameGlobals = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.GameGlobals>(value);
            return true;
        }
        else if (name == PropertyName.RayLength) {
            this.RayLength = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.InteractButton) {
            this.InteractButton = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.MouseButton>(value);
            return true;
        }
        else if (name == PropertyName.CurrentInteractable) {
            this.CurrentInteractable = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.Interactable3D>(value);
            return true;
        }
        else if (name == PropertyName.Focused) {
            this.Focused = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.Interacting) {
            this.Interacting = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.MousePosition) {
            this.MousePosition = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector2>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.OriginCamera) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Camera3D>(this.OriginCamera);
            return true;
        }
        else if (name == PropertyName.GameGlobals) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.GameGlobals>(this.GameGlobals);
            return true;
        }
        else if (name == PropertyName.RayLength) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.RayLength);
            return true;
        }
        else if (name == PropertyName.InteractButton) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.MouseButton>(this.InteractButton);
            return true;
        }
        else if (name == PropertyName.CurrentInteractable) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.Interactable3D>(this.CurrentInteractable);
            return true;
        }
        else if (name == PropertyName.Focused) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Focused);
            return true;
        }
        else if (name == PropertyName.Interacting) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Interacting);
            return true;
        }
        else if (name == PropertyName.MousePosition) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector2>(this.MousePosition);
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
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.OriginCamera, hint: (global::Godot.PropertyHint)34, hintString: "Camera3D", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.RayLength, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.InteractButton, hint: (global::Godot.PropertyHint)2, hintString: "None,Left,Right,Middle,WheelUp,WheelDown,WheelLeft,WheelRight,Xbutton1,Xbutton2", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.CurrentInteractable, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Focused, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Interacting, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)5, name: PropertyName.MousePosition, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.GameGlobals, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
