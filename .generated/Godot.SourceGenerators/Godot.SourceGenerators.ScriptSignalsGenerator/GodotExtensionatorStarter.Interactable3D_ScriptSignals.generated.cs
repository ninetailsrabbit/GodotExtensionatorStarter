using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Interactable3D
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : global::Godot.Area3D.SignalName {
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
        /// Cached name for the 'InteractionLimitReached' signal.
        /// </summary>
        public new static readonly global::Godot.StringName InteractionLimitReached = "InteractionLimitReached";
    }
    /// <summary>
    /// Get the signal information for all the signals declared in this class.
    /// This method is used by Godot to register the available signals in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotSignalList()
    {
        var signals = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(5);
        signals.Add(new(name: SignalName.Focused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.UnFocused, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.Interacted, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.CanceledInteraction, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "interactor", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Object")),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.InteractionLimitReached, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        return signals;
    }
#pragma warning restore CS0109
    private global::GodotExtensionatorStarter.Interactable3D.FocusedEventHandler backing_Focused;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.Interactable3D.FocusedEventHandler"/>
    public event global::GodotExtensionatorStarter.Interactable3D.FocusedEventHandler Focused {
        add => backing_Focused += value;
        remove => backing_Focused -= value;
}
    private global::GodotExtensionatorStarter.Interactable3D.UnFocusedEventHandler backing_UnFocused;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.Interactable3D.UnFocusedEventHandler"/>
    public event global::GodotExtensionatorStarter.Interactable3D.UnFocusedEventHandler UnFocused {
        add => backing_UnFocused += value;
        remove => backing_UnFocused -= value;
}
    private global::GodotExtensionatorStarter.Interactable3D.InteractedEventHandler backing_Interacted;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.Interactable3D.InteractedEventHandler"/>
    public event global::GodotExtensionatorStarter.Interactable3D.InteractedEventHandler Interacted {
        add => backing_Interacted += value;
        remove => backing_Interacted -= value;
}
    private global::GodotExtensionatorStarter.Interactable3D.CanceledInteractionEventHandler backing_CanceledInteraction;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.Interactable3D.CanceledInteractionEventHandler"/>
    public event global::GodotExtensionatorStarter.Interactable3D.CanceledInteractionEventHandler CanceledInteraction {
        add => backing_CanceledInteraction += value;
        remove => backing_CanceledInteraction -= value;
}
    private global::GodotExtensionatorStarter.Interactable3D.InteractionLimitReachedEventHandler backing_InteractionLimitReached;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.Interactable3D.InteractionLimitReachedEventHandler"/>
    public event global::GodotExtensionatorStarter.Interactable3D.InteractionLimitReachedEventHandler InteractionLimitReached {
        add => backing_InteractionLimitReached += value;
        remove => backing_InteractionLimitReached -= value;
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
        if (signal == SignalName.InteractionLimitReached && args.Count == 0) {
            backing_InteractionLimitReached?.Invoke();
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
        else if (signal == SignalName.InteractionLimitReached) {
           return true;
        }
        return base.HasGodotClassSignal(signal);
    }
}

}
