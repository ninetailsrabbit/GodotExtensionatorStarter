using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class MachineState
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node.MethodName {
        /// <summary>
        /// Cached name for the 'Ready' method.
        /// </summary>
        public new static readonly global::Godot.StringName Ready = "Ready";
        /// <summary>
        /// Cached name for the 'Enter' method.
        /// </summary>
        public new static readonly global::Godot.StringName Enter = "Enter";
        /// <summary>
        /// Cached name for the 'Exit' method.
        /// </summary>
        public new static readonly global::Godot.StringName Exit = "Exit";
        /// <summary>
        /// Cached name for the 'HandleInput' method.
        /// </summary>
        public new static readonly global::Godot.StringName HandleInput = "HandleInput";
        /// <summary>
        /// Cached name for the 'PhysicsUpdate' method.
        /// </summary>
        public new static readonly global::Godot.StringName PhysicsUpdate = "PhysicsUpdate";
        /// <summary>
        /// Cached name for the 'Update' method.
        /// </summary>
        public new static readonly global::Godot.StringName Update = "Update";
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
        methods.Add(new(name: MethodName.Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Enter, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Exit, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "nextState", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.HandleInput, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "event", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("InputEvent")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.PhysicsUpdate, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.Update, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName.Ready && args.Count == 0) {
            Ready();
            ret = default;
            return true;
        }
        if (method == MethodName.Enter && args.Count == 0) {
            Enter();
            ret = default;
            return true;
        }
        if (method == MethodName.Exit && args.Count == 1) {
            Exit(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.HandleInput && args.Count == 1) {
            HandleInput(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.PhysicsUpdate && args.Count == 1) {
            PhysicsUpdate(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.Update && args.Count == 1) {
            Update(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName.Ready) {
           return true;
        }
        else if (method == MethodName.Enter) {
           return true;
        }
        else if (method == MethodName.Exit) {
           return true;
        }
        else if (method == MethodName.HandleInput) {
           return true;
        }
        else if (method == MethodName.PhysicsUpdate) {
           return true;
        }
        else if (method == MethodName.Update) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
