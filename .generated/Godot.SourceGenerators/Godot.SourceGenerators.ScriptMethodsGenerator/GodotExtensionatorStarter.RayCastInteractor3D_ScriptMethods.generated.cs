using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class RayCastInteractor3D
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.RayCast3D.MethodName {
        /// <summary>
        /// Cached name for the '_EnterTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _EnterTree = "_EnterTree";
        /// <summary>
        /// Cached name for the '_UnhandledInput' method.
        /// </summary>
        public new static readonly global::Godot.StringName _UnhandledInput = "_UnhandledInput";
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
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(6);
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._UnhandledInput, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "event", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("InputEvent")),  }, defaultArguments: null));
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
        if (method == MethodName._EnterTree && args.Count == 0) {
            _EnterTree();
            ret = default;
            return true;
        }
        if (method == MethodName._UnhandledInput && args.Count == 1) {
            _UnhandledInput(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.InputEvent>(args[0]));
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
        if (method == MethodName._EnterTree) {
           return true;
        }
        else if (method == MethodName._UnhandledInput) {
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
