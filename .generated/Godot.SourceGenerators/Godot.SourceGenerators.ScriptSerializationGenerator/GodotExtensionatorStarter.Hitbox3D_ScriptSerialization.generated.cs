using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Hitbox3D
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.GameGlobals, global::Godot.Variant.From<global::GodotExtensionatorStarter.GameGlobals>(this.GameGlobals));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.GameGlobals, out var _value_GameGlobals))
            this.GameGlobals = _value_GameGlobals.As<global::GodotExtensionatorStarter.GameGlobals>();
    }
}

}
