using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class FiniteStateMachine
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'CurrentState' property.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentState = "CurrentState";
        /// <summary>
        /// Cached name for the 'EnableStack' field.
        /// </summary>
        public new static readonly global::Godot.StringName EnableStack = "EnableStack";
        /// <summary>
        /// Cached name for the 'StackCapacity' field.
        /// </summary>
        public new static readonly global::Godot.StringName StackCapacity = "StackCapacity";
        /// <summary>
        /// Cached name for the 'FlushStackWhenReachCapacity' field.
        /// </summary>
        public new static readonly global::Godot.StringName FlushStackWhenReachCapacity = "FlushStackWhenReachCapacity";
        /// <summary>
        /// Cached name for the 'States' field.
        /// </summary>
        public new static readonly global::Godot.StringName States = "States";
        /// <summary>
        /// Cached name for the 'Transitions' field.
        /// </summary>
        public new static readonly global::Godot.StringName Transitions = "Transitions";
        /// <summary>
        /// Cached name for the 'StatesStack' field.
        /// </summary>
        public new static readonly global::Godot.StringName StatesStack = "StatesStack";
        /// <summary>
        /// Cached name for the 'IsTransitioning' field.
        /// </summary>
        public new static readonly global::Godot.StringName IsTransitioning = "IsTransitioning";
        /// <summary>
        /// Cached name for the 'Locked' field.
        /// </summary>
        public new static readonly global::Godot.StringName Locked = "Locked";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.CurrentState) {
            this.CurrentState = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(value);
            return true;
        }
        else if (name == PropertyName.EnableStack) {
            this.EnableStack = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.StackCapacity) {
            this.StackCapacity = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        else if (name == PropertyName.FlushStackWhenReachCapacity) {
            this.FlushStackWhenReachCapacity = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.IsTransitioning) {
            this.IsTransitioning = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.Locked) {
            this.Locked = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.CurrentState) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.MachineState>(this.CurrentState);
            return true;
        }
        else if (name == PropertyName.EnableStack) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.EnableStack);
            return true;
        }
        else if (name == PropertyName.StackCapacity) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this.StackCapacity);
            return true;
        }
        else if (name == PropertyName.FlushStackWhenReachCapacity) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.FlushStackWhenReachCapacity);
            return true;
        }
        else if (name == PropertyName.States) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromDictionary(this.States);
            return true;
        }
        else if (name == PropertyName.Transitions) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromDictionary(this.Transitions);
            return true;
        }
        else if (name == PropertyName.StatesStack) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFromArray(this.StatesStack);
            return true;
        }
        else if (name == PropertyName.IsTransitioning) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.IsTransitioning);
            return true;
        }
        else if (name == PropertyName.Locked) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Locked);
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
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.CurrentState, hint: (global::Godot.PropertyHint)34, hintString: "Node", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.EnableStack, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.StackCapacity, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.FlushStackWhenReachCapacity, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)27, name: PropertyName.States, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)27, name: PropertyName.Transitions, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)28, name: PropertyName.StatesStack, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.IsTransitioning, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Locked, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
