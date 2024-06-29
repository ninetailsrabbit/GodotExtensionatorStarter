using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Interactable3D
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
        /// Cached name for the '_ExitTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _ExitTree = "_ExitTree";
        /// <summary>
        /// Cached name for the 'Activate' method.
        /// </summary>
        public new static readonly global::Godot.StringName Activate = "Activate";
        /// <summary>
        /// Cached name for the 'Deactivate' method.
        /// </summary>
        public new static readonly global::Godot.StringName Deactivate = "Deactivate";
        /// <summary>
        /// Cached name for the 'IsScannable' method.
        /// </summary>
        public new static readonly global::Godot.StringName IsScannable = "IsScannable";
        /// <summary>
        /// Cached name for the 'IsPickable' method.
        /// </summary>
        public new static readonly global::Godot.StringName IsPickable = "IsPickable";
        /// <summary>
        /// Cached name for the 'IsUsable' method.
        /// </summary>
        public new static readonly global::Godot.StringName IsUsable = "IsUsable";
        /// <summary>
        /// Cached name for the 'CanBeSavedOnInventory' method.
        /// </summary>
        public new static readonly global::Godot.StringName CanBeSavedOnInventory = "CanBeSavedOnInventory";
        /// <summary>
        /// Cached name for the 'OnInteracted' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnInteracted = "OnInteracted";
        /// <summary>
        /// Cached name for the 'OnCancelInteraction' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnCancelInteraction = "OnCancelInteraction";
        /// <summary>
        /// Cached name for the 'OnUnFocused' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnUnFocused = "OnUnFocused";
        /// <summary>
        /// Cached name for the 'OnFocused' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnFocused = "OnFocused";
        /// <summary>
        /// Cached name for the 'OnInteractionLimitedReached' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnInteractionLimitedReached = "OnInteractionLimitedReached";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(14);
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName._ExitTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Activate, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Deactivate, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.IsScannable, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.IsPickable, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.IsUsable, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CanBeSavedOnInventory, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnInteracted, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnCancelInteraction, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnUnFocused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnFocused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnInteractionLimitedReached, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
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
        if (method == MethodName.Activate && args.Count == 0) {
            Activate();
            ret = default;
            return true;
        }
        if (method == MethodName.Deactivate && args.Count == 0) {
            Deactivate();
            ret = default;
            return true;
        }
        if (method == MethodName.IsScannable && args.Count == 0) {
            var callRet = IsScannable();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.IsPickable && args.Count == 0) {
            var callRet = IsPickable();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.IsUsable && args.Count == 0) {
            var callRet = IsUsable();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CanBeSavedOnInventory && args.Count == 0) {
            var callRet = CanBeSavedOnInventory();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.OnInteracted && args.Count == 1) {
            OnInteracted(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnCancelInteraction && args.Count == 1) {
            OnCancelInteraction(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnUnFocused && args.Count == 1) {
            OnUnFocused(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnFocused && args.Count == 1) {
            OnFocused(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnInteractionLimitedReached && args.Count == 0) {
            OnInteractionLimitedReached();
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
        else if (method == MethodName.Activate) {
           return true;
        }
        else if (method == MethodName.Deactivate) {
           return true;
        }
        else if (method == MethodName.IsScannable) {
           return true;
        }
        else if (method == MethodName.IsPickable) {
           return true;
        }
        else if (method == MethodName.IsUsable) {
           return true;
        }
        else if (method == MethodName.CanBeSavedOnInventory) {
           return true;
        }
        else if (method == MethodName.OnInteracted) {
           return true;
        }
        else if (method == MethodName.OnCancelInteraction) {
           return true;
        }
        else if (method == MethodName.OnUnFocused) {
           return true;
        }
        else if (method == MethodName.OnFocused) {
           return true;
        }
        else if (method == MethodName.OnInteractionLimitedReached) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
