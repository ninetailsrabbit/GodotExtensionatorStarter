using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class SceneTransitionManager
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.TransitionAnimationPlayer, global::Godot.Variant.From<global::Godot.AnimationPlayer>(this.TransitionAnimationPlayer));
        info.AddProperty(PropertyName.ColorRect, global::Godot.Variant.From<global::Godot.ColorRect>(this.ColorRect));
        info.AddProperty(PropertyName.LoadingScreenScene, global::Godot.Variant.From<global::Godot.PackedScene>(this.LoadingScreenScene));
        info.AddProperty(PropertyName.NextScenePath, global::Godot.Variant.From<string>(this.NextScenePath));
        info.AddProperty(PropertyName.RemainingAnimations, global::Godot.Variant.CreateFrom(this.RemainingAnimations));
        info.AddSignalEventDelegate(SignalName.TransitionRequested, this.backing_TransitionRequested);
        info.AddSignalEventDelegate(SignalName.TransitionFinished, this.backing_TransitionFinished);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.TransitionAnimationPlayer, out var _value_TransitionAnimationPlayer))
            this.TransitionAnimationPlayer = _value_TransitionAnimationPlayer.As<global::Godot.AnimationPlayer>();
        if (info.TryGetProperty(PropertyName.ColorRect, out var _value_ColorRect))
            this.ColorRect = _value_ColorRect.As<global::Godot.ColorRect>();
        if (info.TryGetProperty(PropertyName.LoadingScreenScene, out var _value_LoadingScreenScene))
            this.LoadingScreenScene = _value_LoadingScreenScene.As<global::Godot.PackedScene>();
        if (info.TryGetProperty(PropertyName.NextScenePath, out var _value_NextScenePath))
            this.NextScenePath = _value_NextScenePath.As<string>();
        if (info.TryGetProperty(PropertyName.RemainingAnimations, out var _value_RemainingAnimations))
            this.RemainingAnimations = _value_RemainingAnimations.AsGodotArray<global::GodotExtensionatorStarter.SceneTransitionManager.TRANSITIONS>();
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.SceneTransitionManager.TransitionRequestedEventHandler>(SignalName.TransitionRequested, out var _value_TransitionRequested))
            this.backing_TransitionRequested = _value_TransitionRequested;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.SceneTransitionManager.TransitionFinishedEventHandler>(SignalName.TransitionFinished, out var _value_TransitionFinished))
            this.backing_TransitionFinished = _value_TransitionFinished;
    }
}

}
