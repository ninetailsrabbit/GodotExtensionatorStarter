using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SoundPool
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
        /// Cached name for the 'Play' method.
        /// </summary>
        public new static readonly global::Godot.StringName Play = "Play";
        /// <summary>
        /// Cached name for the 'PlayWithPitch' method.
        /// </summary>
        public new static readonly global::Godot.StringName PlayWithPitch = "PlayWithPitch";
        /// <summary>
        /// Cached name for the 'PlayWithPitchRange' method.
        /// </summary>
        public new static readonly global::Godot.StringName PlayWithPitchRange = "PlayWithPitchRange";
        /// <summary>
        /// Cached name for the 'StopStreamsFromBus' method.
        /// </summary>
        public new static readonly global::Godot.StringName StopStreamsFromBus = "StopStreamsFromBus";
        /// <summary>
        /// Cached name for the 'SetupPool' method.
        /// </summary>
        public new static readonly global::Godot.StringName SetupPool = "SetupPool";
        /// <summary>
        /// Cached name for the 'NextAvailableAudioStreamPlayer' method.
        /// </summary>
        public new static readonly global::Godot.StringName NextAvailableAudioStreamPlayer = "NextAvailableAudioStreamPlayer";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(7);
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.Play, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "stream", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStream")), new(type: (global::Godot.Variant.Type)4, name: "bus", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "volume", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.PlayWithPitch, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "stream", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStream")), new(type: (global::Godot.Variant.Type)4, name: "bus", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "volume", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "pitch", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.PlayWithPitchRange, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "stream", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStream")), new(type: (global::Godot.Variant.Type)4, name: "bus", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "volume", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "minPitch", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "maxPitch", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.StopStreamsFromBus, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "bus", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.SetupPool, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.NextAvailableAudioStreamPlayer, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStreamPlayer")), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
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
        if (method == MethodName.Play && args.Count == 3) {
            Play(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStream>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if (method == MethodName.PlayWithPitch && args.Count == 4) {
            PlayWithPitch(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStream>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[2]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[3]));
            ret = default;
            return true;
        }
        if (method == MethodName.PlayWithPitchRange && args.Count == 5) {
            PlayWithPitchRange(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStream>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[2]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[3]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[4]));
            ret = default;
            return true;
        }
        if (method == MethodName.StopStreamsFromBus && args.Count == 1) {
            StopStreamsFromBus(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.SetupPool && args.Count == 0) {
            SetupPool();
            ret = default;
            return true;
        }
        if (method == MethodName.NextAvailableAudioStreamPlayer && args.Count == 0) {
            var callRet = NextAvailableAudioStreamPlayer();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.AudioStreamPlayer>(callRet);
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName._Ready) {
           return true;
        }
        else if (method == MethodName.Play) {
           return true;
        }
        else if (method == MethodName.PlayWithPitch) {
           return true;
        }
        else if (method == MethodName.PlayWithPitchRange) {
           return true;
        }
        else if (method == MethodName.StopStreamsFromBus) {
           return true;
        }
        else if (method == MethodName.SetupPool) {
           return true;
        }
        else if (method == MethodName.NextAvailableAudioStreamPlayer) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
