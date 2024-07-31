using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointNClickInteraction : Node3D {

        public const string GroupName = "point_and_click_interaction";

        public enum InteractionType {
            MOVEMENT,
            GRAB,
            ZOOM,
            SCAN,
            CINEMATIC,
            CAMERA_SHIFT,
            DIALOGUE
        }

        public Dictionary<InteractionType, CompressedTexture2D> DefaultCursors = new() {
            {InteractionType.MOVEMENT, Preloader.Instance.CursorStep },
            {InteractionType.GRAB, Preloader.Instance.CursorHandThinOpen },
            {InteractionType.ZOOM, Preloader.Instance.CursorZoom },
            {InteractionType.SCAN, Preloader.Instance.CursorZoom },
            {InteractionType.DIALOGUE, Preloader.Instance.CursorDialogue },
            {InteractionType.CINEMATIC, Preloader.Instance.CursorHelp},
        };

        [Export] public PointNClickController Actor { get; set; } = default!;
        [Export] public InteractionType SelectedInteractionType = InteractionType.MOVEMENT;
        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export] public CompressedTexture2D FocusCursor { get; set; } = default!;
        [Export] public float FadeTimeOnMovement = 0.5f;
        [Export] public float CameraShiftTransitionDuration = 1f;


        public GlobalCameraShifter GlobalCameraShifter { get; set; } = default!;
        public GlobalFade GlobalFade { get; set; } = default!;
        public GameGlobals GameGlobals { get; set; } = default!;
        public Interactable3D Interactable3D { get; set; } = null!;
        public Camera3D CameraToShift { get; set; } = null!;
        public Marker3D TargetPositionMarker { get; set; } = default!;

        public override void _ExitTree() {
            Interactable3D.Focused -= OnFocused;
            Interactable3D.UnFocused -= OnUnFocused;
            Interactable3D.CanceledInteraction -= OnCanceledInteraction;
            Interactable3D.Interacted -= OnInteracted;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            GlobalCameraShifter = this.GetAutoloadNode<GlobalCameraShifter>();
            GlobalFade = this.GetAutoloadNode<GlobalFade>();
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            Actor ??= GetTree().GetFirstNodeInGroup(PointNClickController.GroupName) as PointNClickController;
            CameraToShift ??= this.FirstNodeOfType<Camera3D>();

            Interactable3D = GetNode<Interactable3D>(nameof(Interactable3D));
            Interactable3D.Focused += OnFocused;
            Interactable3D.UnFocused += OnUnFocused;
            Interactable3D.CanceledInteraction += OnCanceledInteraction;
            Interactable3D.Interacted += OnInteracted;

            FocusCursor ??= DefaultCursors[SelectedInteractionType];

            if (SelectedInteractionType.Equals(InteractionType.MOVEMENT))
                TargetPositionMarker = this.FirstNodeOfType<Marker3D>();

            CreateActorDetectorArea();

            InputExtension.ShowMouseCursor();
        }

        public async void MoveActorToThisPointClickInteractionPosition() {
            GlobalFade.FadeIn(FadeTimeOnMovement);
            await ToSignal(GlobalFade, GlobalFade.SignalName.FadeFinished);

            Actor.AlignWithNode(TargetPositionMarker);
            Actor.ApplyStandingStature();

            GlobalFade.FadeOut(FadeTimeOnMovement);
        }

        public void MoveActorWithCameraShift() {
            if (IsCameraShift() && CameraToShift is not null) {
                GlobalCameraShifter.TransitionToRequestedCamera3D(Actor.Camera3D, CameraToShift, CameraShiftTransitionDuration);
                Actor.MouseRayCastInteractor.ChangeCameraTo(CameraToShift);
            }
        }

        public void BackToActorOriginalCamera() {
            if (IsCameraShift() && CameraToShift is not null) {
                GlobalCameraShifter.TransitionToFirstCameraThroughAllSteps3D();
                Actor.MouseRayCastInteractor.ReturnToOriginalCamera();
            }
        }

        private void CreateActorDetectorArea() {
            Area3D detector = new() {
                Name = "ActorAreaDetector",
                Monitoring = true,
                Monitorable = false,
                Priority = 1,
                CollisionLayer = 0,
                CollisionMask = GameGlobals.PlayerCollisionLayer
            };

            CollisionShape3D shape = new() { Shape = new SphereShape3D() { Radius = 0.8f } };

            AddChild(detector);
            detector.AddChild(shape);

            detector.AreaEntered += OnActorDetected;
            detector.AreaExited += OnActorExited;
        }

        private void OnActorDetected(Area3D _) {
            if (IsMovement() || IsCameraShift())
                Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, false);
        }

        private void OnActorExited(Area3D _) {
            if (IsMovement() || IsCameraShift())
                Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, true);
        }


        #region Helpers
        public bool IsMovement() => SelectedInteractionType.Equals(InteractionType.MOVEMENT);
        public bool IsGrab() => SelectedInteractionType.Equals(InteractionType.GRAB);
        public bool IsScan() => SelectedInteractionType.Equals(InteractionType.SCAN);
        public bool IsDialogue() => SelectedInteractionType.Equals(InteractionType.DIALOGUE);
        public bool IsZoom() => SelectedInteractionType.Equals(InteractionType.ZOOM);
        public bool IsCinematic() => SelectedInteractionType.Equals(InteractionType.CINEMATIC);
        public bool IsCameraShift() => SelectedInteractionType.Equals(InteractionType.CAMERA_SHIFT);
        #endregion

        private void OnFocused(GodotObject interactor) {
            if (FocusCursor is not null) {
                Input.SetCustomMouseCursor(FocusCursor, SelectedCursorShape, FocusCursor.GetSize() / 2);
            }
        }
        private void OnUnFocused(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }

        private void OnInteracted(GodotObject interactor) {
            switch (SelectedInteractionType) {
                case InteractionType.MOVEMENT:
                    MoveActorToThisPointClickInteractionPosition();
                    break;
            }
        }

        private void OnCanceledInteraction(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }
    }
}
