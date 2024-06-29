using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SaveGameManager
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.CurrentSavedGame, global::Godot.Variant.From<global::GodotExtensionatorComponents.SavedGameResource>(this.CurrentSavedGame));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.CurrentSavedGame, out var _value_CurrentSavedGame))
            this.CurrentSavedGame = _value_CurrentSavedGame.As<global::GodotExtensionatorComponents.SavedGameResource>();
    }
}

}
