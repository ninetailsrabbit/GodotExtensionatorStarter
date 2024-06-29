using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class GameGlobals
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.NextScenePath, global::Godot.Variant.From<string>(this.NextScenePath));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.NextScenePath, out var _value_NextScenePath))
            this.NextScenePath = _value_NextScenePath.As<string>();
    }
}

}
