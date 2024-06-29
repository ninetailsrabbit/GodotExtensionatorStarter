using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class TransformedInput
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.RefCounted.MethodName {
        /// <summary>
        /// Cached name for the 'Update' method.
        /// </summary>
        public new static readonly global::Godot.StringName Update = "Update";
        /// <summary>
        /// Cached name for the 'UpdatePreviousDirections' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdatePreviousDirections = "UpdatePreviousDirections";
        /// <summary>
        /// Cached name for the 'ChangeMoveRightAction' method.
        /// </summary>
        public new static readonly global::Godot.StringName ChangeMoveRightAction = "ChangeMoveRightAction";
        /// <summary>
        /// Cached name for the 'ChangeMoveLeftAction' method.
        /// </summary>
        public new static readonly global::Godot.StringName ChangeMoveLeftAction = "ChangeMoveLeftAction";
        /// <summary>
        /// Cached name for the 'ChangeMoveForwardAction' method.
        /// </summary>
        public new static readonly global::Godot.StringName ChangeMoveForwardAction = "ChangeMoveForwardAction";
        /// <summary>
        /// Cached name for the 'ChangeMoveBackAction' method.
        /// </summary>
        public new static readonly global::Godot.StringName ChangeMoveBackAction = "ChangeMoveBackAction";
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
        methods.Add(new(name: MethodName.Update, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdatePreviousDirections, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.ChangeMoveRightAction, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("RefCounted")), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "action", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.ChangeMoveLeftAction, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("RefCounted")), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "action", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.ChangeMoveForwardAction, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("RefCounted")), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "action", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.ChangeMoveBackAction, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("RefCounted")), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "action", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName.Update && args.Count == 0) {
            Update();
            ret = default;
            return true;
        }
        if (method == MethodName.UpdatePreviousDirections && args.Count == 0) {
            UpdatePreviousDirections();
            ret = default;
            return true;
        }
        if (method == MethodName.ChangeMoveRightAction && args.Count == 1) {
            var callRet = ChangeMoveRightAction(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.TransformedInput>(callRet);
            return true;
        }
        if (method == MethodName.ChangeMoveLeftAction && args.Count == 1) {
            var callRet = ChangeMoveLeftAction(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.TransformedInput>(callRet);
            return true;
        }
        if (method == MethodName.ChangeMoveForwardAction && args.Count == 1) {
            var callRet = ChangeMoveForwardAction(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.TransformedInput>(callRet);
            return true;
        }
        if (method == MethodName.ChangeMoveBackAction && args.Count == 1) {
            var callRet = ChangeMoveBackAction(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.TransformedInput>(callRet);
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName.Update) {
           return true;
        }
        else if (method == MethodName.UpdatePreviousDirections) {
           return true;
        }
        else if (method == MethodName.ChangeMoveRightAction) {
           return true;
        }
        else if (method == MethodName.ChangeMoveLeftAction) {
           return true;
        }
        else if (method == MethodName.ChangeMoveForwardAction) {
           return true;
        }
        else if (method == MethodName.ChangeMoveBackAction) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
