namespace GodotExtensionatorStarter {

partial class Interactable3D
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
#if TOOLS
    /// <summary>
    /// Get the default values for all properties declared in this class.
    /// This method is used by Godot to determine the value that will be
    /// used by the inspector when resetting properties.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant> GetGodotPropertyDefaultValues()
    {
        var values = new global::System.Collections.Generic.Dictionary<global::Godot.StringName, global::Godot.Variant>(16);
        global::Godot.CompressedTexture2D __FocusPointer_default_value = default!;
        values.Add(PropertyName.FocusPointer, global::Godot.Variant.From<global::Godot.CompressedTexture2D>(__FocusPointer_default_value));
        global::Godot.CompressedTexture2D __InteractPointer_default_value = default!;
        values.Add(PropertyName.InteractPointer, global::Godot.Variant.From<global::Godot.CompressedTexture2D>(__InteractPointer_default_value));
        int __NumberOfTimesYouCanInteract_default_value = 0;
        values.Add(PropertyName.NumberOfTimesYouCanInteract, global::Godot.Variant.From<int>(__NumberOfTimesYouCanInteract_default_value));
        string __Title_default_value = string.Empty;
        values.Add(PropertyName.Title, global::Godot.Variant.From<string>(__Title_default_value));
        string __Description_default_value = string.Empty;
        values.Add(PropertyName.Description, global::Godot.Variant.From<string>(__Description_default_value));
        global::GodotExtensionatorStarter.Interactable3D.CATEGORY __Category_default_value = default;
        values.Add(PropertyName.Category, global::Godot.Variant.From<global::GodotExtensionatorStarter.Interactable3D.CATEGORY>(__Category_default_value));
        bool __Scannable_default_value = false;
        values.Add(PropertyName.Scannable, global::Godot.Variant.From<bool>(__Scannable_default_value));
        bool __Pickable_default_value = false;
        values.Add(PropertyName.Pickable, global::Godot.Variant.From<bool>(__Pickable_default_value));
        string __PickupMessage_default_value = string.Empty;
        values.Add(PropertyName.PickupMessage, global::Godot.Variant.From<string>(__PickupMessage_default_value));
        float __PullPower_default_value = 20f;
        values.Add(PropertyName.PullPower, global::Godot.Variant.From<float>(__PullPower_default_value));
        float __ThrowPower_default_value = 10f;
        values.Add(PropertyName.ThrowPower, global::Godot.Variant.From<float>(__ThrowPower_default_value));
        bool __Usable_default_value = false;
        values.Add(PropertyName.Usable, global::Godot.Variant.From<bool>(__Usable_default_value));
        string __UsableMessage_default_value = string.Empty;
        values.Add(PropertyName.UsableMessage, global::Godot.Variant.From<string>(__UsableMessage_default_value));
        bool __CanBeSaved_default_value = false;
        values.Add(PropertyName.CanBeSaved, global::Godot.Variant.From<bool>(__CanBeSaved_default_value));
        string __InventorySaveMessage_default_value = string.Empty;
        values.Add(PropertyName.InventorySaveMessage, global::Godot.Variant.From<string>(__InventorySaveMessage_default_value));
        bool __LockPlayer_default_value = false;
        values.Add(PropertyName.LockPlayer, global::Godot.Variant.From<bool>(__LockPlayer_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}

}
