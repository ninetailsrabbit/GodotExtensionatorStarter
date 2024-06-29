using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Hurtbox3D
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : global::Godot.Area3D.SignalName {
        /// <summary>
        /// Cached name for the 'HitboxDetected' signal.
        /// </summary>
        public new static readonly global::Godot.StringName HitboxDetected = "HitboxDetected";
    }
    /// <summary>
    /// Get the signal information for all the signals declared in this class.
    /// This method is used by Godot to register the available signals in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotSignalList()
    {
        var signals = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(1);
        signals.Add(new(name: SignalName.HitboxDetected, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "hitbox", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Area3D")),  }, defaultArguments: null));
        return signals;
    }
#pragma warning restore CS0109
    private global::GodotExtensionatorStarter.Hurtbox3D.HitboxDetectedEventHandler backing_HitboxDetected;
    /// <inheritdoc cref="global::GodotExtensionatorStarter.Hurtbox3D.HitboxDetectedEventHandler"/>
    public event global::GodotExtensionatorStarter.Hurtbox3D.HitboxDetectedEventHandler HitboxDetected {
        add => backing_HitboxDetected += value;
        remove => backing_HitboxDetected -= value;
}
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RaiseGodotClassSignalCallbacks(in godot_string_name signal, NativeVariantPtrArgs args)
    {
        if (signal == SignalName.HitboxDetected && args.Count == 1) {
            backing_HitboxDetected?.Invoke(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.Hitbox3D>(args[0]));
            return;
        }
        base.RaiseGodotClassSignalCallbacks(signal, args);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassSignal(in godot_string_name signal)
    {
        if (signal == SignalName.HitboxDetected) {
           return true;
        }
        return base.HasGodotClassSignal(signal);
    }
}

}
