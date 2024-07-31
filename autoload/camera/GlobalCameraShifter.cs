using Extensionator;
using Godot;
using System.Collections.Generic;
using System.Linq;


namespace GodotExtensionatorStarter {
    public partial class GlobalCameraShifter : Node {

        [Signal]
        public delegate void Transition2DStartedEventHandler(Camera2D from, Camera2D to, float duration);
        [Signal]
        public delegate void Transition2DFinishedEventHandler(Camera2D from, Camera2D to, float duration);
        [Signal]
        public delegate void Transition3DStartedEventHandler(Camera3D from, Camera3D to, float duration);
        [Signal]
        public delegate void Transition3DFinishedEventHandler(Camera3D from, Camera3D to, float duration);


        [Export] public float DefaultTransitionDuration = 1.5f;
        [Export] public bool RemoveLastTransitionStep2dOnBack = false;
        [Export] public bool RemoveLastTransitionStep3dOnBack = false;

        public Camera2D GlobalCameraTransition2D { get; set; } = null!;
        public Camera3D GlobalCameraTransition3D { get; set; } = null!;

        public List<TransitionStep2D> TransitionSteps2D = [];
        public List<TransitionStep3D> TransitionSteps3D = [];

        public Tween TransitionTween2D { get; set; } = default!;
        public Tween TransitionTween3D { get; set; } = default!;

        public bool IsTransitioning2D() => TransitionTween2D is not null && TransitionTween2D.IsRunning();
        public bool IsTransitioning3D() => TransitionTween2D is not null && TransitionTween3D.IsRunning();

        public override void _EnterTree() {
            GlobalCameraTransition2D = GetNode<Camera2D>(nameof(GlobalCameraTransition2D));
            GlobalCameraTransition3D = GetNode<Camera3D>(nameof(GlobalCameraTransition3D));
        }

        public async void TransitionToRequestedCamera2D(Camera2D from, Camera2D to, float? duration = null, bool recordTransition = true) {
            duration ??= DefaultTransitionDuration;

            if (IsTransitioning2D())
                return;

            EmitSignal(SignalName.Transition2DStarted);

            GlobalCameraTransition2D.MakeCurrent();

            GlobalCameraTransition2D.Offset = from.Offset;
            GlobalCameraTransition2D.GlobalTransform = from.GlobalTransform;
            GlobalCameraTransition2D.AnchorMode = from.AnchorMode;
            GlobalCameraTransition2D.Zoom = from.Zoom;
            GlobalCameraTransition2D.ProcessCallback = from.ProcessCallback;
            GlobalCameraTransition2D.LimitSmoothed = from.LimitSmoothed;
            GlobalCameraTransition2D.PositionSmoothingEnabled = from.PositionSmoothingEnabled;
            GlobalCameraTransition2D.RotationSmoothingEnabled = from.RotationSmoothingEnabled;

            TransitionTween2D = CreateTween();
            TransitionTween2D.SetParallel(true).SetEase(Tween.EaseType.InOut).SetTrans(Tween.TransitionType.Cubic);
            TransitionTween2D.TweenProperty(GlobalCameraTransition2D, Node2D.PropertyName.GlobalTransform.ToString(), to.GlobalTransform, (double)duration).From(GlobalCameraTransition2D.GlobalTransform);
            TransitionTween2D.TweenProperty(GlobalCameraTransition2D, Camera2D.PropertyName.Zoom.ToString(), to.GlobalTransform, (double)duration).From(GlobalCameraTransition2D.Zoom);

            await ToSignal(TransitionTween2D, Tween.SignalName.Finished);

            if (recordTransition)
                TransitionSteps2D.Add(new(from, to, (float)duration));

            to.MakeCurrent();

            EmitSignal(SignalName.Transition2DFinished);

        }

        public async void TransitionToRequestedCamera3D(Camera3D from, Camera3D to, float? duration = null, bool recordTransition = true) {
            duration ??= DefaultTransitionDuration;

            if (IsTransitioning3D())
                return;

            EmitSignal(SignalName.Transition3DStarted);

            GlobalCameraTransition3D.MakeCurrent();
            GlobalCameraTransition3D.Projection = to.Projection;

            switch (GlobalCameraTransition3D.Projection) {
                case Camera3D.ProjectionType.Orthogonal:
                    GlobalCameraTransition3D.Size = from.Size;
                    break;

                case Camera3D.ProjectionType.Frustum:
                    GlobalCameraTransition3D.FrustumOffset = from.FrustumOffset;
                    break;

                case Camera3D.ProjectionType.Perspective:
                    GlobalCameraTransition3D.Fov = from.Fov;
                    break;
            }


            GlobalCameraTransition3D.Far = from.Far;
            GlobalCameraTransition3D.Near = from.Near;
            GlobalCameraTransition3D.KeepAspect = from.KeepAspect;
            GlobalCameraTransition3D.CullMask = from.CullMask;
            GlobalCameraTransition3D.GlobalTransform = from.GlobalTransform;
            GlobalCameraTransition3D.Environment = from.Environment;
            GlobalCameraTransition3D.Attributes = from.Attributes;
            GlobalCameraTransition3D.DopplerTracking = from.DopplerTracking;

            TransitionTween3D = CreateTween();
            TransitionTween3D.SetParallel(true).SetEase(Tween.EaseType.InOut).SetTrans(Tween.TransitionType.Cubic);
            TransitionTween3D.TweenProperty(GlobalCameraTransition3D, Node3D.PropertyName.GlobalTransform.ToString(), to.GlobalTransform, (double)duration).From(GlobalCameraTransition3D.GlobalTransform);

            switch (to.Projection) {
                case Camera3D.ProjectionType.Orthogonal:
                    TransitionTween3D.TweenProperty(GlobalCameraTransition3D, Camera3D.PropertyName.Size.ToString(), to.GlobalTransform, (double)duration).From(GlobalCameraTransition3D.Size);

                    break;

                case Camera3D.ProjectionType.Frustum:
                    TransitionTween3D.TweenProperty(GlobalCameraTransition3D, Camera3D.PropertyName.FrustumOffset.ToString(), to.GlobalTransform, (double)duration).From(GlobalCameraTransition3D.FrustumOffset);

                    break;

                case Camera3D.ProjectionType.Perspective:
                    TransitionTween3D.TweenProperty(GlobalCameraTransition3D, Camera3D.PropertyName.Fov.ToString(), to.GlobalTransform, (double)duration).From(GlobalCameraTransition3D.Fov);

                    break;
            }


            await ToSignal(TransitionTween3D, Tween.SignalName.Finished);

            if (recordTransition)
                TransitionSteps3D.Add(new(from, to, (float)duration));

            to.MakeCurrent();

            EmitSignal(SignalName.Transition3DFinished);

        }

        public void TransitionToNextCamera2D(Camera2D to, float? duration = null) {
            duration ??= DefaultTransitionDuration;

            if (TransitionSteps2D.IsEmpty() || IsTransitioning2D())
                return;

            TransitionToRequestedCamera2D(TransitionSteps2D.Last().To, to, duration);
        }

        public void TransitionToPreviousCamera2D() {
            if (TransitionSteps2D.IsEmpty() || IsTransitioning2D())
                return;

            var lastStep = RemoveLastTransitionStep2dOnBack ? TransitionSteps2D.PopBack() : TransitionSteps2D.Last();

            TransitionToRequestedCamera2D(lastStep.To, lastStep.From, lastStep.Duration, false);
        }


        public async void TransitionToFirstCameraThroughAllSteps2D(bool cleanStepsOnFinish = true) {
            var transitionSteps = new List<TransitionStep2D>(TransitionSteps2D);
            transitionSteps.Reverse();

            foreach (TransitionStep2D step in transitionSteps) {
                TransitionToRequestedCamera2D(step.To, step.From, step.Duration, false);
                await ToSignal(this, SignalName.Transition3DFinished);
            }

            if (cleanStepsOnFinish)
                TransitionSteps3D.Clear();
        }

        public void TransitionToPreviousCamera3D() {
            if (TransitionSteps3D.IsEmpty() || IsTransitioning3D())
                return;

            var lastStep = RemoveLastTransitionStep3dOnBack ? TransitionSteps3D.PopBack() : TransitionSteps3D.Last();

            TransitionToRequestedCamera3D(lastStep.To, lastStep.From, lastStep.Duration, false);
        }
        public void TransitionToNextCamera3D(Camera3D to, float? duration = null) {
            duration ??= DefaultTransitionDuration;

            if (TransitionSteps3D.IsEmpty() || IsTransitioning3D())
                return;

            TransitionToRequestedCamera3D(TransitionSteps3D.Last().To, to, duration);
        }

        public async void TransitionToFirstCameraThroughAllSteps3D(bool cleanStepsOnFinish = true) {
            var transitionSteps = new List<TransitionStep3D>(TransitionSteps3D);
            transitionSteps.Reverse();

            foreach (TransitionStep3D step in transitionSteps) {
                TransitionToRequestedCamera3D(step.To, step.From, step.Duration, false);
                await ToSignal(this, SignalName.Transition3DFinished);
            }

            if (cleanStepsOnFinish)
                TransitionSteps3D.Clear();
        }
    }


    public record TransitionStep2D(Camera2D From, Camera2D To, float Duration) { }
    public record TransitionStep3D(Camera3D From, Camera3D To, float Duration) { }

}