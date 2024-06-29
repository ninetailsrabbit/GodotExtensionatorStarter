using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class GlobalGameEvents
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : global::Godot.Node.SignalName {
        /// <summary>
        /// Cached name for the 'Focused' signal.
        /// </summary>
        public new static readonly global::Godot.StringName Focused = "Focused";
        /// <summary>
        /// Cached name for the 'UnFocused' signal.
        /// </summary>
        public new static readonly global::Godot.StringName UnFocused = "UnFocused";
        /// <summary>
        /// Cached name for the 'Interacted' signal.
        /// </summary>
        public new static readonly global::Godot.StringName Interacted = "Interacted";
        /// <summary>
        /// Cached name for the 'CanceledInteraction' signal.
        /// </summary>
        public new static readonly global::Godot.StringName CanceledInteraction = "CanceledInteraction";
        /// <summary>
        /// Cached name for the 'LockPlayer' signal.
        /// </summary>
        public new static readonly global::Godot.StringName LockPlayer = "LockPlayer";
        /// <summary>
        /// Cached name for the 'UnlockPlayer' signal.
        /// </summary>
        public new static readonly global::Godot.StringName UnlockPlayer = "UnlockPlayer";
        /// <summary>
        /// Cached name for the 'GamePaused' signal.
        /// </summary>
        public new static readonly global::Godot.StringName GamePaused = "GamePaused";
        /// <summary>
        /// Cached name for the 'GameResumed' signal.
        /// </summary>
        public new static readonly global::Godot.StringName GameResumed = "GameResumed";
    }
    /// <summary>
    /// Get the signal information for all the signals declared in this class.
    /// This method is used by Godot to register the available signals in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotSignalList()
    {
        var signals = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(8);
        signals.Add(new(name: SignalName.Focused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.UnFocused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.Interacted, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.CanceledInteraction, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.LockPlayer, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        signals.Add(new(name: SignalName.UnlockPlayer, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        signals.Add(new(name: SignalName.GamePaused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        signals.Add(new(name: SignalName.GameResumed, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        return signals;
    }
#pragma warning restore CS0109
    private global::GodotExtensionatorStarter.GlobalGameEvents.FocusedEventHandler backing_Focused;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.FocusedEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.FocusedEventHandler Focused {
        add => backing_Focused += value;
        remove => backing_Focused -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.UnFocusedEventHandler backing_UnFocused;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.UnFocusedEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.UnFocusedEventHandler UnFocused {
        add => backing_UnFocused += value;
        remove => backing_UnFocused -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.InteractedEventHandler backing_Interacted;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.InteractedEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.InteractedEventHandler Interacted {
        add => backing_Interacted += value;
        remove => backing_Interacted -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.CanceledInteractionEventHandler backing_CanceledInteraction;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.CanceledInteractionEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.CanceledInteractionEventHandler CanceledInteraction {
        add => backing_CanceledInteraction += value;
        remove => backing_CanceledInteraction -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.LockPlayerEventHandler backing_LockPlayer;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.LockPlayerEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.LockPlayerEventHandler LockPlayer {
        add => backing_LockPlayer += value;
        remove => backing_LockPlayer -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.UnlockPlayerEventHandler backing_UnlockPlayer;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.UnlockPlayerEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.UnlockPlayerEventHandler UnlockPlayer {
        add => backing_UnlockPlayer += value;
        remove => backing_UnlockPlayer -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.GamePausedEventHandler backing_GamePaused;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.GamePausedEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.GamePausedEventHandler GamePaused {
        add => backing_GamePaused += value;
        remove => backing_GamePaused -= value;
}
    private global::GodotExtensionatorStarter.GlobalGameEvents.GameResumedEventHandler backing_GameResumed;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.GlobalGameEvents.GameResumedEventHandler"/>
    public event global::GodotExtensionatorStarter.GlobalGameEvents.GameResumedEventHandler GameResumed {
        add => backing_GameResumed += value;
        remove => backing_GameResumed -= value;
}
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RaiseGodotClassSignalCallbacks(in godot_string_name signal, NativeVariantPtrArgs args)
    {
        if (signal == SignalName.Focused && args.Count == 1) {
            backing_Focused?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            return;
        }
        if (signal == SignalName.UnFocused && args.Count == 1) {
            backing_UnFocused?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            return;
        }
        if (signal == SignalName.Interacted && args.Count == 1) {
            backing_Interacted?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            return;
        }
        if (signal == SignalName.CanceledInteraction && args.Count == 1) {
            backing_CanceledInteraction?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.GodotObject>(args[0]));
            return;
        }
        if (signal == SignalName.LockPlayer && args.Count == 0) {
            backing_LockPlayer?.Invoke();
            return;
        }
        if (signal == SignalName.UnlockPlayer && args.Count == 0) {
            backing_UnlockPlayer?.Invoke();
            return;
        }
        if (signal == SignalName.GamePaused && args.Count == 0) {
            backing_GamePaused?.Invoke();
            return;
        }
        if (signal == SignalName.GameResumed && args.Count == 0) {
            backing_GameResumed?.Invoke();
            return;
        }
        base.RaiseGodotClassSignalCallbacks(signal, args);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassSignal(in godot_string_name signal)
    {
        if (signal == SignalName.Focused) {
           return true;
        }
        else if (signal == SignalName.UnFocused) {
           return true;
        }
        else if (signal == SignalName.Interacted) {
           return true;
        }
        else if (signal == SignalName.CanceledInteraction) {
           return true;
        }
        else if (signal == SignalName.LockPlayer) {
           return true;
        }
        else if (signal == SignalName.UnlockPlayer) {
           return true;
        }
        else if (signal == SignalName.GamePaused) {
           return true;
        }
        else if (signal == SignalName.GameResumed) {
           return true;
        }
        return base.HasGodotClassSignal(signal);
    }
}

}
