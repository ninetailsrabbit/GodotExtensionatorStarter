using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class SceneTransitioner
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node.MethodName {
        /// <summary>
        /// Cached name for the '_EnterTree' method.
        /// </summary>
        public new static readonly global::Godot.StringName _EnterTree = "_EnterTree";
        /// <summary>
        /// Cached name for the 'TransitionToScene' method.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionToScene = "TransitionToScene";
        /// <summary>
        /// Cached name for the 'TransitionToSceneFile' method.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionToSceneFile = "TransitionToSceneFile";
        /// <summary>
        /// Cached name for the 'TransitionToScenePacked' method.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionToScenePacked = "TransitionToScenePacked";
        /// <summary>
        /// Cached name for the 'TransitionWithLoadingScreen' method.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionWithLoadingScreen = "TransitionWithLoadingScreen";
        /// <summary>
        /// Cached name for the 'PrepareTransitionAnimations' method.
        /// </summary>
        public new static readonly global::Godot.StringName PrepareTransitionAnimations = "PrepareTransitionAnimations";
        /// <summary>
        /// Cached name for the 'AnimationNameFromTransition' method.
        /// </summary>
        public new static readonly global::Godot.StringName AnimationNameFromTransition = "AnimationNameFromTransition";
        /// <summary>
        /// Cached name for the 'VoronoiInTransition' method.
        /// </summary>
        public new static readonly global::Godot.StringName VoronoiInTransition = "VoronoiInTransition";
        /// <summary>
        /// Cached name for the 'VoronoiOutTransition' method.
        /// </summary>
        public new static readonly global::Godot.StringName VoronoiOutTransition = "VoronoiOutTransition";
        /// <summary>
        /// Cached name for the 'OnTransitionAnimationFinished' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnTransitionAnimationFinished = "OnTransitionAnimationFinished";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(10);
        methods.Add(new(name: MethodName._EnterTree, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.TransitionToScene, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "scenePath", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)1, name: "loadingScreen", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)2, name: "outTransition", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)2, name: "inTransition", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.TransitionToSceneFile, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "scenePath", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)1, name: "loadingScreen", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.TransitionToScenePacked, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "scene", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("PackedScene")), new(type: (global::Godot.Variant.Type)1, name: "loadingScreen", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.TransitionWithLoadingScreen, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "loadingScene", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.PrepareTransitionAnimations, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)1, name: "loadingScreen", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)2, name: "outTransition", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)2, name: "inTransition", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.AnimationNameFromTransition, returnVal: new(type: (global::Godot.Variant.Type)4, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)2, name: "transition", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.VoronoiInTransition, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)1, name: "flip", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "duration", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.VoronoiOutTransition, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)1, name: "flip", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "duration", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnTransitionAnimationFinished, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)21, name: "animationName", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
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
        if (method == MethodName.TransitionToScene && args.Count == 4) {
            TransitionToScene(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.SceneTransitioner.TRANSITIONS>(args[2]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.SceneTransitioner.TRANSITIONS>(args[3]));
            ret = default;
            return true;
        }
        if (method == MethodName.TransitionToSceneFile && args.Count == 2) {
            TransitionToSceneFile(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.TransitionToScenePacked && args.Count == 2) {
            TransitionToScenePacked(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.PackedScene>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.TransitionWithLoadingScreen && args.Count == 1) {
            TransitionWithLoadingScreen(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.PrepareTransitionAnimations && args.Count == 3) {
            PrepareTransitionAnimations(global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.SceneTransitioner.TRANSITIONS>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.SceneTransitioner.TRANSITIONS>(args[2]));
            ret = default;
            return true;
        }
        if (method == MethodName.AnimationNameFromTransition && args.Count == 1) {
            var callRet = AnimationNameFromTransition(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.SceneTransitioner.TRANSITIONS>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if (method == MethodName.VoronoiInTransition && args.Count == 2) {
            VoronoiInTransition(global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.VoronoiOutTransition && args.Count == 2) {
            VoronoiOutTransition(global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnTransitionAnimationFinished && args.Count == 1) {
            OnTransitionAnimationFinished(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.StringName>(args[0]));
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
        else if (method == MethodName.TransitionToScene) {
           return true;
        }
        else if (method == MethodName.TransitionToSceneFile) {
           return true;
        }
        else if (method == MethodName.TransitionToScenePacked) {
           return true;
        }
        else if (method == MethodName.TransitionWithLoadingScreen) {
           return true;
        }
        else if (method == MethodName.PrepareTransitionAnimations) {
           return true;
        }
        else if (method == MethodName.AnimationNameFromTransition) {
           return true;
        }
        else if (method == MethodName.VoronoiInTransition) {
           return true;
        }
        else if (method == MethodName.VoronoiOutTransition) {
           return true;
        }
        else if (method == MethodName.OnTransitionAnimationFinished) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
