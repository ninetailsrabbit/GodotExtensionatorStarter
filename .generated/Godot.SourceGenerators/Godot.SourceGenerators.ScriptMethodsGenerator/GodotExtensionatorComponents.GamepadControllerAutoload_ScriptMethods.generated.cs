using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class GamepadControllerAutoload
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node.MethodName {
        /// <summary>
        /// Cached name for the '_Notification' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Notification = "_Notification";
        /// <summary>
        /// Cached name for the '_EnterTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _EnterTree = "_EnterTree";
        /// <summary>
        /// Cached name for the 'HasJoypads' method.
        /// </summary>
        public new static readonly global::Godot.StringName HasJoypads = "HasJoypads";
        /// <summary>
        /// Cached name for the 'Joypads' method.
        /// </summary>
        public new static readonly global::Godot.StringName Joypads = "Joypads";
        /// <summary>
        /// Cached name for the 'StartControllerVibration' method.
        /// </summary>
        public new static readonly global::Godot.StringName StartControllerVibration = "StartControllerVibration";
        /// <summary>
        /// Cached name for the 'StopControllerVibration' method.
        /// </summary>
        public new static readonly global::Godot.StringName StopControllerVibration = "StopControllerVibration";
        /// <summary>
        /// Cached name for the 'UpdateCurrentController' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateCurrentController = "UpdateCurrentController";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsKeyboard' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsKeyboard = "CurrentControllerIsKeyboard";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsGeneric' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsGeneric = "CurrentControllerIsGeneric";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsLuna' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsLuna = "CurrentControllerIsLuna";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsPlaystation' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsPlaystation = "CurrentControllerIsPlaystation";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsXbox' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsXbox = "CurrentControllerIsXbox";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsSwitch' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsSwitch = "CurrentControllerIsSwitch";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsSwitchJoycon' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsSwitchJoycon = "CurrentControllerIsSwitchJoycon";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsSwitchJoyconLeft' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsSwitchJoyconLeft = "CurrentControllerIsSwitchJoyconLeft";
        /// <summary>
        /// Cached name for the 'CurrentControllerIsSwitchJoyconRight' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentControllerIsSwitchJoyconRight = "CurrentControllerIsSwitchJoyconRight";
        /// <summary>
        /// Cached name for the 'OnJoyConnectionChanged' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnJoyConnectionChanged = "OnJoyConnectionChanged";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(17);
        methods.Add(new(name: MethodName._Notification, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)2, name: "what", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.HasJoypads, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)33, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Joypads, returnVal: new(type: (global::Godot.Variant.Type)28, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)33, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.StartControllerVibration, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "weakStrength", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "strongStrength", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "duration", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.StopControllerVibration, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "weakStrength", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "strongStrength", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "duration", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateCurrentController, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)2, name: "device", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)4, name: "controllerName", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsKeyboard, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsGeneric, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsLuna, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsPlaystation, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsXbox, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsSwitch, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsSwitchJoycon, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsSwitchJoyconLeft, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentControllerIsSwitchJoyconRight, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnJoyConnectionChanged, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)2, name: "device", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)1, name: "connected", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName._Notification && args.Count == 1) {
            _Notification(global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName._EnterTree && args.Count == 0) {
            _EnterTree();
            ret = default;
            return true;
        }
        if (method == MethodName.HasJoypads && args.Count == 0) {
            var callRet = HasJoypads();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.Joypads && args.Count == 0) {
            var callRet = Joypads();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if (method == MethodName.StartControllerVibration && args.Count == 3) {
            StartControllerVibration(global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if (method == MethodName.StopControllerVibration && args.Count == 3) {
            StopControllerVibration(global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateCurrentController && args.Count == 2) {
            UpdateCurrentController(global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.CurrentControllerIsKeyboard && args.Count == 0) {
            var callRet = CurrentControllerIsKeyboard();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsGeneric && args.Count == 0) {
            var callRet = CurrentControllerIsGeneric();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsLuna && args.Count == 0) {
            var callRet = CurrentControllerIsLuna();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsPlaystation && args.Count == 0) {
            var callRet = CurrentControllerIsPlaystation();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsXbox && args.Count == 0) {
            var callRet = CurrentControllerIsXbox();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsSwitch && args.Count == 0) {
            var callRet = CurrentControllerIsSwitch();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsSwitchJoycon && args.Count == 0) {
            var callRet = CurrentControllerIsSwitchJoycon();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsSwitchJoyconLeft && args.Count == 0) {
            var callRet = CurrentControllerIsSwitchJoyconLeft();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentControllerIsSwitchJoyconRight && args.Count == 0) {
            var callRet = CurrentControllerIsSwitchJoyconRight();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.OnJoyConnectionChanged && args.Count == 2) {
            OnJoyConnectionChanged(global::Godot.NativeInterop.VariantUtils.ConvertTo<long>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static bool InvokeGodotClassStaticMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName.HasJoypads && args.Count == 0) {
            var callRet = HasJoypads();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.Joypads && args.Count == 0) {
            var callRet = Joypads();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFromArray(callRet);
            return true;
        }
        ret = default;
        return false;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName._Notification) {
           return true;
        }
        else if (method == MethodName._EnterTree) {
           return true;
        }
        else if (method == MethodName.HasJoypads) {
           return true;
        }
        else if (method == MethodName.Joypads) {
           return true;
        }
        else if (method == MethodName.StartControllerVibration) {
           return true;
        }
        else if (method == MethodName.StopControllerVibration) {
           return true;
        }
        else if (method == MethodName.UpdateCurrentController) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsKeyboard) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsGeneric) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsLuna) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsPlaystation) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsXbox) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsSwitch) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsSwitchJoycon) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsSwitchJoyconLeft) {
           return true;
        }
        else if (method == MethodName.CurrentControllerIsSwitchJoyconRight) {
           return true;
        }
        else if (method == MethodName.OnJoyConnectionChanged) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
