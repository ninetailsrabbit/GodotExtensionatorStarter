using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SaveGameManager
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node.MethodName {
        /// <summary>
        /// Cached name for the 'CreateNewSave' method.
        /// </summary>
        public new static readonly global::Godot.StringName CreateNewSave = "CreateNewSave";
        /// <summary>
        /// Cached name for the 'WriteCurrentSave' method.
        /// </summary>
        public new static readonly global::Godot.StringName WriteCurrentSave = "WriteCurrentSave";
        /// <summary>
        /// Cached name for the 'RemoveSave' method.
        /// </summary>
        public new static readonly global::Godot.StringName RemoveSave = "RemoveSave";
        /// <summary>
        /// Cached name for the 'SaveExists' method.
        /// </summary>
        public new static readonly global::Godot.StringName SaveExists = "SaveExists";
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
        methods.Add(new(name: MethodName.CreateNewSave, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "filename", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.WriteCurrentSave, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.RemoveSave, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "save", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Resource")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.SaveExists, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)33, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "filename", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName.CreateNewSave && args.Count == 1) {
            CreateNewSave(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.WriteCurrentSave && args.Count == 0) {
            WriteCurrentSave();
            ret = default;
            return true;
        }
        if (method == MethodName.RemoveSave && args.Count == 1) {
            RemoveSave(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.SavedGameResource>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.SaveExists && args.Count == 1) {
            var callRet = SaveExists(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static bool InvokeGodotClassStaticMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName.SaveExists && args.Count == 1) {
            var callRet = SaveExists(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName.CreateNewSave) {
           return true;
        }
        else if (method == MethodName.WriteCurrentSave) {
           return true;
        }
        else if (method == MethodName.RemoveSave) {
           return true;
        }
        else if (method == MethodName.SaveExists) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
