using Godot;
using Godot.Collections;
using GodotExtensionator;


namespace GodotExtensionatorStarter {
    public partial class LoadingScreen : CanvasLayer {
        [Signal]
        public delegate void FailedEventHandler(int status);

        [Signal]
        public delegate void FinishedEventHandler();


        [Export(PropertyHint.File)] public string nextScenePath = string.Empty;
        [Export] public bool UseSubThreads = false;
        [Export] public ResourceLoader.CacheMode CacheMode = ResourceLoader.CacheMode.Reuse;

        public Array Progress = [];
        public ResourceLoader.ThreadLoadStatus SceneLoadStatus = ResourceLoader.ThreadLoadStatus.InProgress;

        public double CurrentProgressValue = 0f;
        public double SmoothValue = 0f;
        public bool Loading = false;

        public SceneTransitioner SceneTransitioner { get; set; } = default!;

        public override void _EnterTree() {
            SceneTransitioner = this.GetAutoloadNode<SceneTransitioner>();
        }
        public override void _Ready() {


            Finished += OnFinished;
            Failed += OnFailed;

            nextScenePath = SceneTransitioner.NextScenePath;

            if (nextScenePath.FilePathIsValid()) {
                ResourceLoader.LoadThreadedRequest(nextScenePath, "Loading screen active", UseSubThreads, CacheMode);
                Loading = true;
            }
            else {
                GD.PushError($"LoadingScreen: The next scene path is not valid to load{nextScenePath}");
            }
        }

        public override void _ExitTree() {
            Finished -= OnFinished;
            Failed -= OnFailed;
        }

        public override void _Process(double delta) {
            if (Loading) {
                var status = ResourceLoader.LoadThreadedGetStatus(nextScenePath, Progress);

                SmoothProgressValue(delta);

                if (status.Equals(ResourceLoader.ThreadLoadStatus.Loaded))
                    EmitSignal(SignalName.Finished);

                if (status.Equals(ResourceLoader.ThreadLoadStatus.Failed) || status.Equals(ResourceLoader.ThreadLoadStatus.InvalidResource))
                    EmitSignal(SignalName.Failed, (int)status);
            }
        }

        public double SmoothProgressValue(double delta) {
            if (Progress.Count > 0 && (double)Progress[0] >= CurrentProgressValue)
                CurrentProgressValue = (double)Progress[0];

            if (SmoothValue < CurrentProgressValue)
                SmoothValue = Mathf.Lerp(SmoothValue, CurrentProgressValue, delta);

            SmoothValue += delta * .2f * (CurrentProgressValue >= 1f ? 3f : Mathf.Clamp(.9 - SmoothValue, 0, 1f));

            return SmoothValue;
        }

        private void Reset() {
            Progress.Clear();
            CurrentProgressValue = 0f;
            SmoothValue = 0;
            Loading = false;
        }

        private void OnFinished() {
            Reset();
            SceneTransitioner.NextScenePath = "";
            SceneTransitioner.TransitionToScene((PackedScene)ResourceLoader.LoadThreadedGet(nextScenePath));
        }

        private void OnFailed(int status) {
            Reset();
            GD.PushError($"LoadingScreen: The load for {nextScenePath} failed with status {(ResourceLoader.ThreadLoadStatus)status}");
        }
    }
}