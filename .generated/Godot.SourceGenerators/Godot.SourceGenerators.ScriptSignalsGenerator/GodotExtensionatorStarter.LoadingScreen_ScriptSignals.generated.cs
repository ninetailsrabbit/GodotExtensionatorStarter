using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class LoadingScreen
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : global::Godot.CanvasLayer.SignalName {
        /// <summary>
        /// Cached name for the 'Failed' signal.
        /// </summary>
        public new static readonly global::Godot.StringName Failed = "Failed";
        /// <summary>
        /// Cached name for the 'Finished' signal.
        /// </summary>
        public new static readonly global::Godot.StringName Finished = "Finished";
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
        signals.Add(new(name: SignalName.Failed, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)2, name: "status", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        signals.Add(new(name: SignalName.Finished, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        return signals;
    }
#pragma warning restore CS0109
    private global::GodotExtensionatorStarter.LoadingScreen.FailedEventHandler backing_Failed;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.LoadingScreen.FailedEventHandler"/>
    public event global::GodotExtensionatorStarter.LoadingScreen.FailedEventHandler Failed {
        add => backing_Failed += value;
        remove => backing_Failed -= value;
}
    private global::GodotExtensionatorStarter.LoadingScreen.FinishedEventHandler backing_Finished;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.LoadingScreen.FinishedEventHandler"/>
    public event global::GodotExtensionatorStarter.LoadingScreen.FinishedEventHandler Finished {
        add => backing_Finished += value;
        remove => backing_Finished -= value;
}
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RaiseGodotClassSignalCallbacks(in godot_string_name signal, NativeVariantPtrArgs args)
    {
        if (signal == SignalName.Failed && args.Count == 1) {
            backing_Failed?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(args[0]));
            return;
        }
        if (signal == SignalName.Finished && args.Count == 0) {
            backing_Finished?.Invoke();
            return;
        }
        base.RaiseGodotClassSignalCallbacks(signal, args);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassSignal(in godot_string_name signal)
    {
        if (signal == SignalName.Failed) {
           return true;
        }
        else if (signal == SignalName.Finished) {
           return true;
        }
        return base.HasGodotClassSignal(signal);
    }
}

}
