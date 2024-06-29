using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class MouseRayCastInteractor
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node3D.MethodName {
        /// <summary>
        /// Cached name for the '_Input' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Input = "_Input";
        /// <summary>
        /// Cached name for the '_Ready' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Ready = "_Ready";
        /// <summary>
        /// Cached name for the '_Process' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Process = "_Process";
        /// <summary>
        /// Cached name for the 'GetDetectedInteractable' method.
        /// </summary>
        public new static readonly global::Godot.StringName GetDetectedInteractable = "GetDetectedInteractable";
        /// <summary>
        /// Cached name for the 'Enable' method.
        /// </summary>
        public new static readonly global::Godot.StringName Enable = "Enable";
        /// <summary>
        /// Cached name for the 'Disable' method.
        /// </summary>
        public new static readonly global::Godot.StringName Disable = "Disable";
        /// <summary>
        /// Cached name for the 'Interact' method.
        /// </summary>
        public new static readonly global::Godot.StringName Interact = "Interact";
        /// <summary>
        /// Cached name for the 'CancelInteract' method.
        /// </summary>
        public new static readonly global::Godot.StringName CancelInteract = "CancelInteract";
        /// <summary>
        /// Cached name for the 'Focus' method.
        /// </summary>
        public new static readonly global::Godot.StringName Focus = "Focus";
        /// <summary>
        /// Cached name for the 'UnFocus' method.
        /// </summary>
        public new static readonly global::Godot.StringName UnFocus = "UnFocus";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(10);
        methods.Add(new(name: MethodName._Input, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "event", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("InputEvent")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._Process, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.GetDetectedInteractable, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Area3D")), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Enable, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Disable, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Interact, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactable", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.CancelInteract, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactable", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.Focus, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactable", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UnFocus, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactable", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName._Input && args.Count == 1) {
            _Input(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName._Ready && args.Count == 0) {
            _Ready();
            ret = default;
            return true;
        }
        if (method == MethodName._Process && args.Count == 1) {
            _Process(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.GetDetectedInteractable && args.Count == 0) {
            var callRet = GetDetectedInteractable();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.Interactable3D>(callRet);
            return true;
        }
        if (method == MethodName.Enable && args.Count == 0) {
            Enable();
            ret = default;
            return true;
        }
        if (method == MethodName.Disable && args.Count == 0) {
            Disable();
            ret = default;
            return true;
        }
        if (method == MethodName.Interact && args.Count == 1) {
            Interact(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.CancelInteract && args.Count == 1) {
            CancelInteract(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.Focus && args.Count == 1) {
            Focus(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.UnFocus && args.Count == 1) {
            UnFocus(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName._Input) {
           return true;
        }
        else if (method == MethodName._Ready) {
           return true;
        }
        else if (method == MethodName._Process) {
           return true;
        }
        else if (method == MethodName.GetDetectedInteractable) {
           return true;
        }
        else if (method == MethodName.Enable) {
           return true;
        }
        else if (method == MethodName.Disable) {
           return true;
        }
        else if (method == MethodName.Interact) {
           return true;
        }
        else if (method == MethodName.CancelInteract) {
           return true;
        }
        else if (method == MethodName.Focus) {
           return true;
        }
        else if (method == MethodName.UnFocus) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
