using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class SceneTransitioner
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : global::Godot.Node.SignalName {
        /// <summary>
        /// Cached name for the 'TransitionRequested' signal.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionRequested = "TransitionRequested";
        /// <summary>
        /// Cached name for the 'TransitionFinished' signal.
        /// </summary>
        public new static readonly global::Godot.StringName TransitionFinished = "TransitionFinished";
    }
    /// <summary>
    /// Get the signal information for all the signals declared in this class.
    /// This method is used by Godot to register the available signals in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotSignalList()
    {
        var signals = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(2);
        signals.Add(new(name: SignalName.TransitionRequested, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "nextScenePath", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.TransitionFinished, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "nextScenePath", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return signals;
    }
#pragma warning restore CS0109
    private global::GodotExtensionatorStarter.SceneTransitioner.TransitionRequestedEventHandler backing_TransitionRequested;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.SceneTransitioner.TransitionRequestedEventHandler"/>
    public event global::GodotExtensionatorStarter.SceneTransitioner.TransitionRequestedEventHandler TransitionRequested {
        add => backing_TransitionRequested += value;
        remove => backing_TransitionRequested -= value;
}
    private global::GodotExtensionatorStarter.SceneTransitioner.TransitionFinishedEventHandler backing_TransitionFinished;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.SceneTransitioner.TransitionFinishedEventHandler"/>
    public event global::GodotExtensionatorStarter.SceneTransitioner.TransitionFinishedEventHandler TransitionFinished {
        add => backing_TransitionFinished += value;
        remove => backing_TransitionFinished -= value;
}
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RaiseGodotClassSignalCallbacks(in godot_string_name signal, NativeVariantPtrArgs args)
    {
        if (signal == SignalName.TransitionRequested && args.Count == 1) {
            backing_TransitionRequested?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            return;
        }
        if (signal == SignalName.TransitionFinished && args.Count == 1) {
            backing_TransitionFinished?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            return;
        }
        base.RaiseGodotClassSignalCallbacks(signal, args);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassSignal(in godot_string_name signal)
    {
        if (signal == SignalName.TransitionRequested) {
           return true;
        }
        else if (signal == SignalName.TransitionFinished) {
           return true;
        }
        return base.HasGodotClassSignal(signal);
    }
}

}
