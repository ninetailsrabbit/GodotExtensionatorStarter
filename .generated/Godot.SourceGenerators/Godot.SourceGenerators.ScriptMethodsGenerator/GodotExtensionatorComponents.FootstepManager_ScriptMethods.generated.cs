using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class FootstepManager
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node3D.MethodName {
        /// <summary>
        /// Cached name for the '_EnterTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _EnterTree = "_EnterTree";
        /// <summary>
        /// Cached name for the 'Footstep' method.
        /// </summary>
        public new static readonly global::Godot.StringName Footstep = "Footstep";
        /// <summary>
        /// Cached name for the 'CreateIntervalTimer' method.
        /// </summary>
        public new static readonly global::Godot.StringName CreateIntervalTimer = "CreateIntervalTimer";
        /// <summary>
        /// Cached name for the 'OnIntervalTimerTimeout' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnIntervalTimerTimeout = "OnIntervalTimerTimeout";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(4);
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Footstep, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "interval", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.CreateIntervalTimer, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnIntervalTimerTimeout, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
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
        if (method == MethodName.Footstep && args.Count == 1) {
            Footstep(global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.CreateIntervalTimer && args.Count == 0) {
            CreateIntervalTimer();
            ret = default;
            return true;
        }
        if (method == MethodName.OnIntervalTimerTimeout && args.Count == 0) {
            OnIntervalTimerTimeout();
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
        else if (method == MethodName.Footstep) {
           return true;
        }
        else if (method == MethodName.CreateIntervalTimer) {
           return true;
        }
        else if (method == MethodName.OnIntervalTimerTimeout) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
