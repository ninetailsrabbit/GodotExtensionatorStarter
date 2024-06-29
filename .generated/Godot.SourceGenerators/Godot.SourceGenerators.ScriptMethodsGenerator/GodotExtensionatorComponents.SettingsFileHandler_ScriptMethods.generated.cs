using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SettingsFileHandler
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node.MethodName {
        /// <summary>
        /// Cached name for the '_Ready' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Ready = "_Ready";
        /// <summary>
        /// Cached name for the 'ChangeConfigPath' method.
        /// </summary>
        public new static readonly global::Godot.StringName ChangeConfigPath = "ChangeConfigPath";
        /// <summary>
        /// Cached name for the 'ReturnToDefaultConfigPath' method.
        /// </summary>
        public new static readonly global::Godot.StringName ReturnToDefaultConfigPath = "ReturnToDefaultConfigPath";
        /// <summary>
        /// Cached name for the 'LoadSettings' method.
        /// </summary>
        public new static readonly global::Godot.StringName LoadSettings = "LoadSettings";
        /// <summary>
        /// Cached name for the 'UpdateSettings' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateSettings = "UpdateSettings";
        /// <summary>
        /// Cached name for the 'UpdateKeybindings' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateKeybindings = "UpdateKeybindings";
        /// <summary>
        /// Cached name for the 'UpdateAudio' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateAudio = "UpdateAudio";
        /// <summary>
        /// Cached name for the 'UpdateGraphics' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateGraphics = "UpdateGraphics";
        /// <summary>
        /// Cached name for the 'UpdateAccessibility' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateAccessibility = "UpdateAccessibility";
        /// <summary>
        /// Cached name for the 'UpdateLocalization' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateLocalization = "UpdateLocalization";
        /// <summary>
        /// Cached name for the 'UpdateAnalytics' method.
        /// </summary>
        public new static readonly global::Godot.StringName UpdateAnalytics = "UpdateAnalytics";
        /// <summary>
        /// Cached name for the 'LoadKeybindings' method.
        /// </summary>
        public new static readonly global::Godot.StringName LoadKeybindings = "LoadKeybindings";
        /// <summary>
        /// Cached name for the 'LoadAudio' method.
        /// </summary>
        public new static readonly global::Godot.StringName LoadAudio = "LoadAudio";
        /// <summary>
        /// Cached name for the 'LoadGraphics' method.
        /// </summary>
        public new static readonly global::Godot.StringName LoadGraphics = "LoadGraphics";
        /// <summary>
        /// Cached name for the 'AddKeybindingEvent' method.
        /// </summary>
        public new static readonly global::Godot.StringName AddKeybindingEvent = "AddKeybindingEvent";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(15);
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.ChangeConfigPath, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "newPath", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.ReturnToDefaultConfigPath, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.LoadSettings, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "configFile", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("ConfigFile")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateSettings, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "gameSettings", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Resource")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateKeybindings, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateAudio, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateGraphics, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "gameSettings", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Resource")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateAccessibility, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "gameSettings", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Resource")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateLocalization, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "gameSettings", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Resource")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.UpdateAnalytics, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "gameSettings", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Resource")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.LoadKeybindings, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)33, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "configFile", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("ConfigFile")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.LoadAudio, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)33, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "configFile", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("ConfigFile")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.LoadGraphics, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "configFile", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("ConfigFile")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.AddKeybindingEvent, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)33, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "action", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)34, name: "keybindingType", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName._Ready && args.Count == 0) {
            _Ready();
            ret = default;
            return true;
        }
        if (method == MethodName.ChangeConfigPath && args.Count == 1) {
            var callRet = ChangeConfigPath(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.SettingsFileHandler>(callRet);
            return true;
        }
        if (method == MethodName.ReturnToDefaultConfigPath && args.Count == 0) {
            var callRet = ReturnToDefaultConfigPath();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.SettingsFileHandler>(callRet);
            return true;
        }
        if (method == MethodName.LoadSettings && args.Count == 1) {
            LoadSettings(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateSettings && args.Count == 1) {
            UpdateSettings(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GameSettingsResource>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateKeybindings && args.Count == 0) {
            UpdateKeybindings();
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateAudio && args.Count == 0) {
            UpdateAudio();
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateGraphics && args.Count == 1) {
            UpdateGraphics(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GameSettingsResource>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateAccessibility && args.Count == 1) {
            UpdateAccessibility(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GameSettingsResource>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateLocalization && args.Count == 1) {
            UpdateLocalization(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GameSettingsResource>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.UpdateAnalytics && args.Count == 1) {
            UpdateAnalytics(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.GameSettingsResource>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.LoadKeybindings && args.Count == 1) {
            LoadKeybindings(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.LoadAudio && args.Count == 1) {
            LoadAudio(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.LoadGraphics && args.Count == 1) {
            LoadGraphics(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.AddKeybindingEvent && args.Count == 2) {
            AddKeybindingEvent(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string[]>(args[1]));
            ret = default;
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static bool InvokeGodotClassStaticMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName.LoadKeybindings && args.Count == 1) {
            LoadKeybindings(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.LoadAudio && args.Count == 1) {
            LoadAudio(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.AddKeybindingEvent && args.Count == 2) {
            AddKeybindingEvent(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string[]>(args[1]));
            ret = default;
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
        if (method == MethodName._Ready) {
           return true;
        }
        else if (method == MethodName.ChangeConfigPath) {
           return true;
        }
        else if (method == MethodName.ReturnToDefaultConfigPath) {
           return true;
        }
        else if (method == MethodName.LoadSettings) {
           return true;
        }
        else if (method == MethodName.UpdateSettings) {
           return true;
        }
        else if (method == MethodName.UpdateKeybindings) {
           return true;
        }
        else if (method == MethodName.UpdateAudio) {
           return true;
        }
        else if (method == MethodName.UpdateGraphics) {
           return true;
        }
        else if (method == MethodName.UpdateAccessibility) {
           return true;
        }
        else if (method == MethodName.UpdateLocalization) {
           return true;
        }
        else if (method == MethodName.UpdateAnalytics) {
           return true;
        }
        else if (method == MethodName.LoadKeybindings) {
           return true;
        }
        else if (method == MethodName.LoadAudio) {
           return true;
        }
        else if (method == MethodName.LoadGraphics) {
           return true;
        }
        else if (method == MethodName.AddKeybindingEvent) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
