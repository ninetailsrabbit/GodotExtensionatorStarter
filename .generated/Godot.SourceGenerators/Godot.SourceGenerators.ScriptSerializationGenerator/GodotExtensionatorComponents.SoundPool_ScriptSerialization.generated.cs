using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class SoundPool
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.PoolPlayersNumber, global::Godot.Variant.From<int>(this.PoolPlayersNumber));
        info.AddProperty(PropertyName._poolPlayersNumber, global::Godot.Variant.From<int>(this._poolPlayersNumber));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.PoolPlayersNumber, out var _value_PoolPlayersNumber))
            this.PoolPlayersNumber = _value_PoolPlayersNumber.As<int>();
        if (info.TryGetProperty(PropertyName._poolPlayersNumber, out var _value__poolPlayersNumber))
            this._poolPlayersNumber = _value__poolPlayersNumber.As<int>();
    }
}

}
