using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class MusicManager
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
        /// Cached name for the 'PlayMusic' method.
        /// </summary>
        public new static readonly global::Godot.StringName PlayMusic = "PlayMusic";
        /// <summary>
        /// Cached name for the 'PlayStream' method.
        /// </summary>
        public new static readonly global::Godot.StringName PlayStream = "PlayStream";
        /// <summary>
        /// Cached name for the 'AddStreamsToMusicBank' method.
        /// </summary>
        public new static readonly global::Godot.StringName AddStreamsToMusicBank = "AddStreamsToMusicBank";
        /// <summary>
        /// Cached name for the 'AddStreamToMusicBank' method.
        /// </summary>
        public new static readonly global::Godot.StringName AddStreamToMusicBank = "AddStreamToMusicBank";
        /// <summary>
        /// Cached name for the 'RemoveStreamsFromBank' method.
        /// </summary>
        public new static readonly global::Godot.StringName RemoveStreamsFromBank = "RemoveStreamsFromBank";
        /// <summary>
        /// Cached name for the 'RemoveStreamMusicFromBank' method.
        /// </summary>
        public new static readonly global::Godot.StringName RemoveStreamMusicFromBank = "RemoveStreamMusicFromBank";
        /// <summary>
        /// Cached name for the 'CreateAudioStreamPlayers' method.
        /// </summary>
        public new static readonly global::Godot.StringName CreateAudioStreamPlayers = "CreateAudioStreamPlayers";
        /// <summary>
        /// Cached name for the 'OnFinishedAudioStreamPlayer' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnFinishedAudioStreamPlayer = "OnFinishedAudioStreamPlayer";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(9);
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.PlayMusic, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "streamName", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)1, name: "crossfade", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), new(type: (global::Godot.Variant.Type)3, name: "crossfadingTime", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.PlayStream, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "audioPlayer", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStreamPlayer")), new(type: (global::Godot.Variant.Type)24, name: "stream", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStream")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.AddStreamsToMusicBank, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)27, name: "streams", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.AddStreamToMusicBank, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "stream", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStream")), new(type: (global::Godot.Variant.Type)4, name: "name", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.RemoveStreamsFromBank, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)34, name: "names", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.RemoveStreamMusicFromBank, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "name", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.CreateAudioStreamPlayers, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.OnFinishedAudioStreamPlayer, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "audioPlayer", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("AudioStreamPlayer")),  }, defaultArguments: null));
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
        if (method == MethodName.PlayMusic && args.Count == 3) {
            PlayMusic(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(args[1]), global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if (method == MethodName.PlayStream && args.Count == 2) {
            PlayStream(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStreamPlayer>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStream>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.AddStreamsToMusicBank && args.Count == 1) {
            AddStreamsToMusicBank(global::Godot.NativeInterop.VariantUtils.ConvertToDictionary<string, global::Godot.AudioStream>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.AddStreamToMusicBank && args.Count == 2) {
            AddStreamToMusicBank(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStream>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.RemoveStreamsFromBank && args.Count == 1) {
            RemoveStreamsFromBank(global::Godot.NativeInterop.VariantUtils.ConvertTo<string[]>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.RemoveStreamMusicFromBank && args.Count == 1) {
            RemoveStreamMusicFromBank(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.CreateAudioStreamPlayers && args.Count == 0) {
            CreateAudioStreamPlayers();
            ret = default;
            return true;
        }
        if (method == MethodName.OnFinishedAudioStreamPlayer && args.Count == 1) {
            OnFinishedAudioStreamPlayer(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.AudioStreamPlayer>(args[0]));
            ret = default;
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
        else if (method == MethodName.PlayMusic) {
           return true;
        }
        else if (method == MethodName.PlayStream) {
           return true;
        }
        else if (method == MethodName.AddStreamsToMusicBank) {
           return true;
        }
        else if (method == MethodName.AddStreamToMusicBank) {
           return true;
        }
        else if (method == MethodName.RemoveStreamsFromBank) {
           return true;
        }
        else if (method == MethodName.RemoveStreamMusicFromBank) {
           return true;
        }
        else if (method == MethodName.CreateAudioStreamPlayers) {
           return true;
        }
        else if (method == MethodName.OnFinishedAudioStreamPlayer) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
