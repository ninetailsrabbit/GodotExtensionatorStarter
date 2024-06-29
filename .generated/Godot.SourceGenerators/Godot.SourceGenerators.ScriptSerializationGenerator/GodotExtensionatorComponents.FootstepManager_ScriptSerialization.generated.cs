using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class FootstepManager
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.FloorDetectorRaycast, global::Godot.Variant.From<global::Godot.RayCast3D>(this.FloorDetectorRaycast));
        info.AddProperty(PropertyName.IntervalTimer, global::Godot.Variant.From<global::Godot.Timer>(this.IntervalTimer));
        info.AddProperty(PropertyName.UsePitch, global::Godot.Variant.From<bool>(this.UsePitch));
        info.AddProperty(PropertyName.MinPitchRange, global::Godot.Variant.From<float>(this.MinPitchRange));
        info.AddProperty(PropertyName.MaxPitchRange, global::Godot.Variant.From<float>(this.MaxPitchRange));
        info.AddProperty(PropertyName.SfxPlaying, global::Godot.Variant.From<bool>(this.SfxPlaying));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.FloorDetectorRaycast, out var _value_FloorDetectorRaycast))
            this.FloorDetectorRaycast = _value_FloorDetectorRaycast.As<global::Godot.RayCast3D>();
        if (info.TryGetProperty(PropertyName.IntervalTimer, out var _value_IntervalTimer))
            this.IntervalTimer = _value_IntervalTimer.As<global::Godot.Timer>();
        if (info.TryGetProperty(PropertyName.UsePitch, out var _value_UsePitch))
            this.UsePitch = _value_UsePitch.As<bool>();
        if (info.TryGetProperty(PropertyName.MinPitchRange, out var _value_MinPitchRange))
            this.MinPitchRange = _value_MinPitchRange.As<float>();
        if (info.TryGetProperty(PropertyName.MaxPitchRange, out var _value_MaxPitchRange))
            this.MaxPitchRange = _value_MaxPitchRange.As<float>();
        if (info.TryGetProperty(PropertyName.SfxPlaying, out var _value_SfxPlaying))
            this.SfxPlaying = _value_SfxPlaying.As<bool>();
    }
}

}
