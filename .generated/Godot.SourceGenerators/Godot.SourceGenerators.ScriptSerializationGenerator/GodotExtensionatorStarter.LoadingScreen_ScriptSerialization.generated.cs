using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class LoadingScreen
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.SaveGodotObjectData(info);
        info.AddProperty(PropertyName.SceneTransitioner, global::Godot.Variant.From<global::GodotExtensionatorStarter.SceneTransitioner>(this.SceneTransitioner));
        info.AddProperty(PropertyName.nextScenePath, global::Godot.Variant.From<string>(this.nextScenePath));
        info.AddProperty(PropertyName.UseSubThreads, global::Godot.Variant.From<bool>(this.UseSubThreads));
        info.AddProperty(PropertyName.CacheMode, global::Godot.Variant.From<global::Godot.ResourceLoader.CacheMode>(this.CacheMode));
        info.AddProperty(PropertyName.Progress, global::Godot.Variant.From<global::Godot.Collections.Array>(this.Progress));
        info.AddProperty(PropertyName.SceneLoadStatus, global::Godot.Variant.From<global::Godot.ResourceLoader.ThreadLoadStatus>(this.SceneLoadStatus));
        info.AddProperty(PropertyName.CurrentProgressValue, global::Godot.Variant.From<double>(this.CurrentProgressValue));
        info.AddProperty(PropertyName.SmoothValue, global::Godot.Variant.From<double>(this.SmoothValue));
        info.AddProperty(PropertyName.Loading, global::Godot.Variant.From<bool>(this.Loading));
        info.AddSignalEventDelegate(SignalName.Failed, this.backing_Failed);
        info.AddSignalEventDelegate(SignalName.Finished, this.backing_Finished);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGodotObjectData(global::Godot.Bridge.GodotSerializationInfo info)
    {
        base.RestoreGodotObjectData(info);
        if (info.TryGetProperty(PropertyName.SceneTransitioner, out var _value_SceneTransitioner))
            this.SceneTransitioner = _value_SceneTransitioner.As<global::GodotExtensionatorStarter.SceneTransitioner>();
        if (info.TryGetProperty(PropertyName.nextScenePath, out var _value_nextScenePath))
            this.nextScenePath = _value_nextScenePath.As<string>();
        if (info.TryGetProperty(PropertyName.UseSubThreads, out var _value_UseSubThreads))
            this.UseSubThreads = _value_UseSubThreads.As<bool>();
        if (info.TryGetProperty(PropertyName.CacheMode, out var _value_CacheMode))
            this.CacheMode = _value_CacheMode.As<global::Godot.ResourceLoader.CacheMode>();
        if (info.TryGetProperty(PropertyName.Progress, out var _value_Progress))
            this.Progress = _value_Progress.As<global::Godot.Collections.Array>();
        if (info.TryGetProperty(PropertyName.SceneLoadStatus, out var _value_SceneLoadStatus))
            this.SceneLoadStatus = _value_SceneLoadStatus.As<global::Godot.ResourceLoader.ThreadLoadStatus>();
        if (info.TryGetProperty(PropertyName.CurrentProgressValue, out var _value_CurrentProgressValue))
            this.CurrentProgressValue = _value_CurrentProgressValue.As<double>();
        if (info.TryGetProperty(PropertyName.SmoothValue, out var _value_SmoothValue))
            this.SmoothValue = _value_SmoothValue.As<double>();
        if (info.TryGetProperty(PropertyName.Loading, out var _value_Loading))
            this.Loading = _value_Loading.As<bool>();
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.LoadingScreen.FailedEventHandler>(SignalName.Failed, out var _value_Failed))
            this.backing_Failed = _value_Failed;
        if (info.TryGetSignalEventDelegate<global::GodotExtensionatorStarter.LoadingScreen.FinishedEventHandler>(SignalName.Finished, out var _value_Finished))
            this.backing_Finished = _value_Finished;
    }
}

}
