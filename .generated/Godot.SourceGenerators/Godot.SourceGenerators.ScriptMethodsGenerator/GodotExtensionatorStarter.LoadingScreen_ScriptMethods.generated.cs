using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class LoadingScreen
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.CanvasLayer.MethodName {
        /// <summary>
        /// Cached name for the '_EnterTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _EnterTree = "_EnterTree";
        /// <summary>
        /// Cached name for the '_Ready' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Ready = "_Ready";
        /// <summary>
        /// Cached name for the '_ExitTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _ExitTree = "_ExitTree";
        /// <summary>
        /// Cached name for the '_Process' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Process = "_Process";
        /// <summary>
        /// Cached name for the 'SmoothProgressValue' method.
        /// </summary>
        public new static readonly global::Godot.StringName SmoothProgressValue = "SmoothProgressValue";
        /// <summary>
        /// Cached name for the 'Reset' method.
        /// </summary>
        public new static readonly global::Godot.StringName Reset = "Reset";
        /// <summary>
        /// Cached name for the 'OnFinished' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnFinished = "OnFinished";
        /// <summary>
        /// Cached name for the 'OnFailed' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnFailed = "OnFailed";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(8);
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._ExitTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._Process, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.SmoothProgressValue, returnVal: new(type: (global::Godot.Variant.Type)3, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.Reset, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnFinished, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnFailed, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)2, name: "status", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
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
        if (method == MethodName._ExitTree && args.Count == 0) {
            _ExitTree();
            ret = default;
            return true;
        }
        if (method == MethodName._Process && args.Count == 1) {
            _Process(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.SmoothProgressValue && args.Count == 1) {
            var callRet = SmoothProgressValue(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if (method == MethodName.Reset && args.Count == 0) {
            Reset();
            ret = default;
            return true;
        }
        if (method == MethodName.OnFinished && args.Count == 0) {
            OnFinished();
            ret = default;
            return true;
        }
        if (method == MethodName.OnFailed && args.Count == 1) {
            OnFailed(global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(args[0]));
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
        else if (method == MethodName._ExitTree) {
           return true;
        }
        else if (method == MethodName._Process) {
           return true;
        }
        else if (method == MethodName.SmoothProgressValue) {
           return true;
        }
        else if (method == MethodName.Reset) {
           return true;
        }
        else if (method == MethodName.OnFinished) {
           return true;
        }
        else if (method == MethodName.OnFailed) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
