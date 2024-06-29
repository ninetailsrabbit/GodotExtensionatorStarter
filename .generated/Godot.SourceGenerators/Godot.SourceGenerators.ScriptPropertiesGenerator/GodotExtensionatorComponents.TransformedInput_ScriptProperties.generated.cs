using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class TransformedInput
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.RefCounted.PropertyName {
        /// <summary>
        /// Cached name for the 'MoveRightAction' property.
        /// </summary>
        public new static readonly global::Godot.StringName MoveRightAction = "MoveRightAction";
        /// <summary>
        /// Cached name for the 'MoveLeftAction' property.
        /// </summary>
        public new static readonly global::Godot.StringName MoveLeftAction = "MoveLeftAction";
        /// <summary>
        /// Cached name for the 'MoveForwardAction' property.
        /// </summary>
        public new static readonly global::Godot.StringName MoveForwardAction = "MoveForwardAction";
        /// <summary>
        /// Cached name for the 'MoveBackAction' property.
        /// </summary>
        public new static readonly global::Godot.StringName MoveBackAction = "MoveBackAction";
        /// <summary>
        /// Cached name for the 'Deadzone' property.
        /// </summary>
        public new static readonly global::Godot.StringName Deadzone = "Deadzone";
        /// <summary>
        /// Cached name for the 'InputDirection' property.
        /// </summary>
        public new static readonly global::Godot.StringName InputDirection = "InputDirection";
        /// <summary>
        /// Cached name for the 'InputDirectionDeadzoneSquareShape' property.
        /// </summary>
        public new static readonly global::Godot.StringName InputDirectionDeadzoneSquareShape = "InputDirectionDeadzoneSquareShape";
        /// <summary>
        /// Cached name for the 'InputDirectionHorizontalAxis' property.
        /// </summary>
        public new static readonly global::Godot.StringName InputDirectionHorizontalAxis = "InputDirectionHorizontalAxis";
        /// <summary>
        /// Cached name for the 'InputDirectionVerticalAxis' property.
        /// </summary>
        public new static readonly global::Godot.StringName InputDirectionVerticalAxis = "InputDirectionVerticalAxis";
        /// <summary>
        /// Cached name for the 'InputDirectionHorizontalAxisAppliedDeadzone' property.
        /// </summary>
        public new static readonly global::Godot.StringName InputDirectionHorizontalAxisAppliedDeadzone = "InputDirectionHorizontalAxisAppliedDeadzone";
        /// <summary>
        /// Cached name for the 'InputDirectionVerticalAxisAppliedDeadzone' property.
        /// </summary>
        public new static readonly global::Godot.StringName InputDirectionVerticalAxisAppliedDeadzone = "InputDirectionVerticalAxisAppliedDeadzone";
        /// <summary>
        /// Cached name for the 'WorldCoordinateSpaceDirection' property.
        /// </summary>
        public new static readonly global::Godot.StringName WorldCoordinateSpaceDirection = "WorldCoordinateSpaceDirection";
        /// <summary>
        /// Cached name for the 'PreviousInputDirection' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousInputDirection = "PreviousInputDirection";
        /// <summary>
        /// Cached name for the 'PreviousInputDirectionDeadzoneSquareShape' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousInputDirectionDeadzoneSquareShape = "PreviousInputDirectionDeadzoneSquareShape";
        /// <summary>
        /// Cached name for the 'PreviousInputDirectionHorizontalAxis' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousInputDirectionHorizontalAxis = "PreviousInputDirectionHorizontalAxis";
        /// <summary>
        /// Cached name for the 'PreviousInputDirectionVerticalAxis' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousInputDirectionVerticalAxis = "PreviousInputDirectionVerticalAxis";
        /// <summary>
        /// Cached name for the 'PreviousInputDirectionHorizontalAxisAppliedDeadzone' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousInputDirectionHorizontalAxisAppliedDeadzone = "PreviousInputDirectionHorizontalAxisAppliedDeadzone";
        /// <summary>
        /// Cached name for the 'PreviousInputDirectionVerticalAxisAppliedDeadzone' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousInputDirectionVerticalAxisAppliedDeadzone = "PreviousInputDirectionVerticalAxisAppliedDeadzone";
        /// <summary>
        /// Cached name for the 'PreviousWorldCoordinateSpaceDirection' property.
        /// </summary>
        public new static readonly global::Godot.StringName PreviousWorldCoordinateSpaceDirection = "PreviousWorldCoordinateSpaceDirection";
        /// <summary>
        /// Cached name for the 'Actor' field.
        /// </summary>
        public new static readonly global::Godot.StringName Actor = "Actor";
        /// <summary>
        /// Cached name for the '_deadzone' field.
        /// </summary>
        public new static readonly global::Godot.StringName _deadzone = "_deadzone";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.MoveRightAction) {
            this.MoveRightAction = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.MoveLeftAction) {
            this.MoveLeftAction = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.MoveForwardAction) {
            this.MoveForwardAction = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.MoveBackAction) {
            this.MoveBackAction = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.Deadzone) {
            this.Deadzone = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.InputDirection) {
            this.InputDirection = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector2>(value);
            return true;
        }
        else if (name == PropertyName.InputDirectionDeadzoneSquareShape) {
            this.InputDirectionDeadzoneSquareShape = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector2>(value);
            return true;
        }
        else if (name == PropertyName.InputDirectionHorizontalAxis) {
            this.InputDirectionHorizontalAxis = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.InputDirectionVerticalAxis) {
            this.InputDirectionVerticalAxis = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.InputDirectionHorizontalAxisAppliedDeadzone) {
            this.InputDirectionHorizontalAxisAppliedDeadzone = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.InputDirectionVerticalAxisAppliedDeadzone) {
            this.InputDirectionVerticalAxisAppliedDeadzone = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.WorldCoordinateSpaceDirection) {
            this.WorldCoordinateSpaceDirection = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector3>(value);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirection) {
            this.PreviousInputDirection = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector2>(value);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionDeadzoneSquareShape) {
            this.PreviousInputDirectionDeadzoneSquareShape = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector2>(value);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionHorizontalAxis) {
            this.PreviousInputDirectionHorizontalAxis = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionVerticalAxis) {
            this.PreviousInputDirectionVerticalAxis = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionHorizontalAxisAppliedDeadzone) {
            this.PreviousInputDirectionHorizontalAxisAppliedDeadzone = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionVerticalAxisAppliedDeadzone) {
            this.PreviousInputDirectionVerticalAxisAppliedDeadzone = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.PreviousWorldCoordinateSpaceDirection) {
            this.PreviousWorldCoordinateSpaceDirection = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Vector3>(value);
            return true;
        }
        else if (name == PropertyName.Actor) {
            this.Actor = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Node>(value);
            return true;
        }
        else if (name == PropertyName._deadzone) {
            this._deadzone = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.MoveRightAction) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.MoveRightAction);
            return true;
        }
        else if (name == PropertyName.MoveLeftAction) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.MoveLeftAction);
            return true;
        }
        else if (name == PropertyName.MoveForwardAction) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.MoveForwardAction);
            return true;
        }
        else if (name == PropertyName.MoveBackAction) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.MoveBackAction);
            return true;
        }
        else if (name == PropertyName.Deadzone) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.Deadzone);
            return true;
        }
        else if (name == PropertyName.InputDirection) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector2>(this.InputDirection);
            return true;
        }
        else if (name == PropertyName.InputDirectionDeadzoneSquareShape) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector2>(this.InputDirectionDeadzoneSquareShape);
            return true;
        }
        else if (name == PropertyName.InputDirectionHorizontalAxis) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.InputDirectionHorizontalAxis);
            return true;
        }
        else if (name == PropertyName.InputDirectionVerticalAxis) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.InputDirectionVerticalAxis);
            return true;
        }
        else if (name == PropertyName.InputDirectionHorizontalAxisAppliedDeadzone) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.InputDirectionHorizontalAxisAppliedDeadzone);
            return true;
        }
        else if (name == PropertyName.InputDirectionVerticalAxisAppliedDeadzone) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.InputDirectionVerticalAxisAppliedDeadzone);
            return true;
        }
        else if (name == PropertyName.WorldCoordinateSpaceDirection) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector3>(this.WorldCoordinateSpaceDirection);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirection) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector2>(this.PreviousInputDirection);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionDeadzoneSquareShape) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector2>(this.PreviousInputDirectionDeadzoneSquareShape);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionHorizontalAxis) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.PreviousInputDirectionHorizontalAxis);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionVerticalAxis) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.PreviousInputDirectionVerticalAxis);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionHorizontalAxisAppliedDeadzone) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.PreviousInputDirectionHorizontalAxisAppliedDeadzone);
            return true;
        }
        else if (name == PropertyName.PreviousInputDirectionVerticalAxisAppliedDeadzone) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.PreviousInputDirectionVerticalAxisAppliedDeadzone);
            return true;
        }
        else if (name == PropertyName.PreviousWorldCoordinateSpaceDirection) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Vector3>(this.PreviousWorldCoordinateSpaceDirection);
            return true;
        }
        else if (name == PropertyName.Actor) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.Node>(this.Actor);
            return true;
        }
        else if (name == PropertyName._deadzone) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this._deadzone);
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
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.MoveRightAction, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.MoveLeftAction, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.MoveForwardAction, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.MoveBackAction, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.Actor, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.Deadzone, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName._deadzone, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)5, name: PropertyName.InputDirection, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)5, name: PropertyName.InputDirectionDeadzoneSquareShape, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.InputDirectionHorizontalAxis, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.InputDirectionVerticalAxis, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.InputDirectionHorizontalAxisAppliedDeadzone, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.InputDirectionVerticalAxisAppliedDeadzone, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)9, name: PropertyName.WorldCoordinateSpaceDirection, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)5, name: PropertyName.PreviousInputDirection, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)5, name: PropertyName.PreviousInputDirectionDeadzoneSquareShape, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.PreviousInputDirectionHorizontalAxis, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.PreviousInputDirectionVerticalAxis, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.PreviousInputDirectionHorizontalAxisAppliedDeadzone, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.PreviousInputDirectionVerticalAxisAppliedDeadzone, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)9, name: PropertyName.PreviousWorldCoordinateSpaceDirection, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
