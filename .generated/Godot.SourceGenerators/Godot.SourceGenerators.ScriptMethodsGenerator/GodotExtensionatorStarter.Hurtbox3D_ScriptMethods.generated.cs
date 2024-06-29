﻿using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Hurtbox3D
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Area3D.MethodName {
        /// <summary>
        /// Cached name for the '_EnterTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _EnterTree = "_EnterTree";
        /// <summary>
        /// Cached name for the '_Ready' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Ready = "_Ready";
        /// <summary>
        /// Cached name for the 'OnAreaEntered' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnAreaEntered = "OnAreaEntered";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(3);
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnAreaEntered, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "area", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Area3D")),  }, defaultArguments: null));
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
        if (method == MethodName._Ready && args.Count == 0) {
            _Ready();
            ret = default;
            return true;
        }
        if (method == MethodName.OnAreaEntered && args.Count == 1) {
            OnAreaEntered(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.Area3D>(args[0]));
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
        else if (method == MethodName._Ready) {
           return true;
        }
        else if (method == MethodName.OnAreaEntered) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
