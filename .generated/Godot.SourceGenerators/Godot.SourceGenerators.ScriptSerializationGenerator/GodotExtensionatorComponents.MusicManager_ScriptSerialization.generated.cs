using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class MusicManager
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.MainAudioStreamPlayer, global::Godot.Variant.From<global::Godot.AudioStreamPlayer>(this.MainAudioStreamPlayer));
        info.AddProperty(PropertyName.SecondaryAudioStreamPlayer, global::Godot.Variant.From<global::Godot.AudioStreamPlayer>(this.SecondaryAudioStreamPlayer));
        info.AddProperty(PropertyName.CurrentAudioStreamPlayer, global::Godot.Variant.From<global::Godot.AudioStreamPlayer>(this.CurrentAudioStreamPlayer));
        info.AddProperty(PropertyName.MusicBank, global::Godot.Variant.CreateFrom(this.MusicBank));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.MainAudioStreamPlayer, out var _value_MainAudioStreamPlayer))
            this.MainAudioStreamPlayer = _value_MainAudioStreamPlayer.As<global::Godot.AudioStreamPlayer>();
        if (info.TryGetProperty(PropertyName.SecondaryAudioStreamPlayer, out var _value_SecondaryAudioStreamPlayer))
            this.SecondaryAudioStreamPlayer = _value_SecondaryAudioStreamPlayer.As<global::Godot.AudioStreamPlayer>();
        if (info.TryGetProperty(PropertyName.CurrentAudioStreamPlayer, out var _value_CurrentAudioStreamPlayer))
            this.CurrentAudioStreamPlayer = _value_CurrentAudioStreamPlayer.As<global::Godot.AudioStreamPlayer>();
        if (info.TryGetProperty(PropertyName.MusicBank, out var _value_MusicBank))
            this.MusicBank = _value_MusicBank.AsGodotDictionary<string, global::Godot.AudioStream>();
    }
}

}
