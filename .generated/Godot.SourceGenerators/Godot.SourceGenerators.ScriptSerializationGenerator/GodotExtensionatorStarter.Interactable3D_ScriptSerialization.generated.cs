using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Interactable3D
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.FocusPointer, global::Godot.Variant.From<global::Godot.CompressedTexture2D>(this.FocusPointer));
        info.AddProperty(PropertyName.InteractPointer, global::Godot.Variant.From<global::Godot.CompressedTexture2D>(this.InteractPointer));
        info.AddProperty(PropertyName.GameGlobals, global::Godot.Variant.From<global::GodotExtensionatorStarter.GameGlobals>(this.GameGlobals));
        info.AddProperty(PropertyName.GlobalGameEvents, global::Godot.Variant.From<global::GodotExtensionatorStarter.GlobalGameEvents>(this.GlobalGameEvents));
        info.AddProperty(PropertyName.TimesInteracted, global::Godot.Variant.From<int>(this.TimesInteracted));
        info.AddProperty(PropertyName.NumberOfTimesYouCanInteract, global::Godot.Variant.From<int>(this.NumberOfTimesYouCanInteract));
        info.AddProperty(PropertyName.Title, global::Godot.Variant.From<string>(this.Title));
        info.AddProperty(PropertyName.Description, global::Godot.Variant.From<string>(this.Description));
        info.AddProperty(PropertyName.Category, global::Godot.Variant.From<global::GodotExtensionatorStarter.Interactable3D.CATEGORY>(this.Category));
        info.AddProperty(PropertyName.Scannable, global::Godot.Variant.From<bool>(this.Scannable));
        info.AddProperty(PropertyName.Pickable, global::Godot.Variant.From<bool>(this.Pickable));
        info.AddProperty(PropertyName.PickupMessage, global::Godot.Variant.From<string>(this.PickupMessage));
        info.AddProperty(PropertyName.PullPower, global::Godot.Variant.From<float>(this.PullPower));
        info.AddProperty(PropertyName.ThrowPower, global::Godot.Variant.From<float>(this.ThrowPower));
        info.AddProperty(PropertyName.Usable, global::Godot.Variant.From<bool>(this.Usable));
        info.AddProperty(PropertyName.UsableMessage, global::Godot.Variant.From<string>(this.UsableMessage));
        info.AddProperty(PropertyName.CanBeSaved, global::Godot.Variant.From<bool>(this.CanBeSaved));
        info.AddProperty(PropertyName.InventorySaveMessage, global::Godot.Variant.From<string>(this.InventorySaveMessage));
        info.AddProperty(PropertyName.LockPlayer, global::Godot.Variant.From<bool>(this.LockPlayer));
        info.AddProperty(PropertyName._timesInteracted, global::Godot.Variant.From<int>(this._timesInteracted));
        info.AddSignalEventDelegate(SignalName.Focused, this.backing_Focused);
        info.AddSignalEventDelegate(SignalName.UnFocused, this.backing_UnFocused);
        info.AddSignalEventDelegate(SignalName.Interacted, this.backing_Interacted);
        info.AddSignalEventDelegate(SignalName.CanceledInteraction, this.backing_CanceledInteraction);
        info.AddSignalEventDelegate(SignalName.InteractionLimitReached, this.backing_InteractionLimitReached);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.FocusPointer, out var _value_FocusPointer))
            this.FocusPointer = _value_FocusPointer.As<global::Godot.CompressedTexture2D>();
        if (info.TryGetProperty(PropertyName.InteractPointer, out var _value_InteractPointer))
            this.InteractPointer = _value_InteractPointer.As<global::Godot.CompressedTexture2D>();
        if (info.TryGetProperty(PropertyName.GameGlobals, out var _value_GameGlobals))
            this.GameGlobals = _value_GameGlobals.As<global::GodotExtensionatorStarter.GameGlobals>();
        if (info.TryGetProperty(PropertyName.GlobalGameEvents, out var _value_GlobalGameEvents))
            this.GlobalGameEvents = _value_GlobalGameEvents.As<global::GodotExtensionatorStarter.GlobalGameEvents>();
        if (info.TryGetProperty(PropertyName.TimesInteracted, out var _value_TimesInteracted))
            this.TimesInteracted = _value_TimesInteracted.As<int>();
        if (info.TryGetProperty(PropertyName.NumberOfTimesYouCanInteract, out var _value_NumberOfTimesYouCanInteract))
            this.NumberOfTimesYouCanInteract = _value_NumberOfTimesYouCanInteract.As<int>();
        if (info.TryGetProperty(PropertyName.Title, out var _value_Title))
            this.Title = _value_Title.As<string>();
        if (info.TryGetProperty(PropertyName.Description, out var _value_Description))
            this.Description = _value_Description.As<string>();
        if (info.TryGetProperty(PropertyName.Category, out var _value_Category))
            this.Category = _value_Category.As<global::GodotExtensionatorStarter.Interactable3D.CATEGORY>();
        if (info.TryGetProperty(PropertyName.Scannable, out var _value_Scannable))
            this.Scannable = _value_Scannable.As<bool>();
        if (info.TryGetProperty(PropertyName.Pickable, out var _value_Pickable))
            this.Pickable = _value_Pickable.As<bool>();
        if (info.TryGetProperty(PropertyName.PickupMessage, out var _value_PickupMessage))
            this.PickupMessage = _value_PickupMessage.As<string>();
        if (info.TryGetProperty(PropertyName.PullPower, out var _value_PullPower))
            this.PullPower = _value_PullPower.As<float>();
        if (info.TryGetProperty(PropertyName.ThrowPower, out var _value_ThrowPower))
            this.ThrowPower = _value_ThrowPower.As<float>();
        if (info.TryGetProperty(PropertyName.Usable, out var _value_Usable))
            this.Usable = _value_Usable.As<bool>();
        if (info.TryGetProperty(PropertyName.UsableMessage, out var _value_UsableMessage))
            this.UsableMessage = _value_UsableMessage.As<string>();
        if (info.TryGetProperty(PropertyName.CanBeSaved, out var _value_CanBeSaved))
            this.CanBeSaved = _value_CanBeSaved.As<bool>();
        if (info.TryGetProperty(PropertyName.InventorySaveMessage, out var _value_InventorySaveMessage))
            this.InventorySaveMessage = _value_InventorySaveMessage.As<string>();
        if (info.TryGetProperty(PropertyName.LockPlayer, out var _value_LockPlayer))
            this.LockPlayer = _value_LockPlayer.As<bool>();
        if (info.TryGetProperty(PropertyName._timesInteracted, out var _value__timesInteracted))
            this._timesInteracted = _value__timesInteracted.As<int>();
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.Interactable3D.FocusedEventHandler>(SignalName.Focused, out var _value_Focused))
            this.backing_Focused = _value_Focused;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.Interactable3D.UnFocusedEventHandler>(SignalName.UnFocused, out var _value_UnFocused))
            this.backing_UnFocused = _value_UnFocused;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.Interactable3D.InteractedEventHandler>(SignalName.Interacted, out var _value_Interacted))
            this.backing_Interacted = _value_Interacted;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.Interactable3D.CanceledInteractionEventHandler>(SignalName.CanceledInteraction, out var _value_CanceledInteraction))
            this.backing_CanceledInteraction = _value_CanceledInteraction;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.Interactable3D.InteractionLimitReachedEventHandler>(SignalName.InteractionLimitReached, out var _value_InteractionLimitReached))
            this.backing_InteractionLimitReached = _value_InteractionLimitReached;
    }
}

}
