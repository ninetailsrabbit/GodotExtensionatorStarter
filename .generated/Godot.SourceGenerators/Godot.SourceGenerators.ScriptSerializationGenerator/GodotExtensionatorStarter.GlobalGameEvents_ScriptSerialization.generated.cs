using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class GlobalGameEvents
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddSignalEventDelegate(SignalName.Focused, this.backing_Focused);
        info.AddSignalEventDelegate(SignalName.UnFocused, this.backing_UnFocused);
        info.AddSignalEventDelegate(SignalName.Interacted, this.backing_Interacted);
        info.AddSignalEventDelegate(SignalName.CanceledInteraction, this.backing_CanceledInteraction);
        info.AddSignalEventDelegate(SignalName.LockPlayer, this.backing_LockPlayer);
        info.AddSignalEventDelegate(SignalName.UnlockPlayer, this.backing_UnlockPlayer);
        info.AddSignalEventDelegate(SignalName.GamePaused, this.backing_GamePaused);
        info.AddSignalEventDelegate(SignalName.GameResumed, this.backing_GameResumed);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.FocusedEventHandler>(SignalName.Focused, out var _value_Focused))
            this.backing_Focused = _value_Focused;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.UnFocusedEventHandler>(SignalName.UnFocused, out var _value_UnFocused))
            this.backing_UnFocused = _value_UnFocused;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.InteractedEventHandler>(SignalName.Interacted, out var _value_Interacted))
            this.backing_Interacted = _value_Interacted;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.CanceledInteractionEventHandler>(SignalName.CanceledInteraction, out var _value_CanceledInteraction))
            this.backing_CanceledInteraction = _value_CanceledInteraction;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.LockPlayerEventHandler>(SignalName.LockPlayer, out var _value_LockPlayer))
            this.backing_LockPlayer = _value_LockPlayer;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.UnlockPlayerEventHandler>(SignalName.UnlockPlayer, out var _value_UnlockPlayer))
            this.backing_UnlockPlayer = _value_UnlockPlayer;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.GamePausedEventHandler>(SignalName.GamePaused, out var _value_GamePaused))
            this.backing_GamePaused = _value_GamePaused;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.GlobalGameEvents.GameResumedEventHandler>(SignalName.GameResumed, out var _value_GameResumed))
            this.backing_GameResumed = _value_GameResumed;
    }
}

}
