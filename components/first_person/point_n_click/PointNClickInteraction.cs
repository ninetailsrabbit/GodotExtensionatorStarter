using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointNClickInteraction : Node3D {

        public const string GroupName = "point_and_click_interaction";

        public enum InteractionType {
            Movement,
            Grab,
            Zoom,
            Scan,
            Cinematic,
            CameraShift,
            Dialogue
        }

        public Dictionary<InteractionType, CompressedTexture2D> DefaultCursors = new() {
            {InteractionType.Movement, Preloader.Instance.CursorStep },
            {InteractionType.Grab, Preloader.Instance.CursorHandThinOpen },
            {InteractionType.Zoom, Preloader.Instance.CursorZoom },
            {InteractionType.Scan, Preloader.Instance.CursorZoom },
            {InteractionType.Dialogue, Preloader.Instance.CursorDialogue },
            {InteractionType.Cinematic, Preloader.Instance.CursorHelp},
        };

        [Export] public PointNClickController Actor { get; set; } = default!;
        [Export] public InteractionType SelectedInteractionType = InteractionType.Movement;
        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export] public CompressedTexture2D FocusCursor { get; set; } = default!;
        [Export] public Node3D ObjectToScan { get; set; } = default!;
        [Export] public float FadeTimeOnMovement = 0.5f;
        [Export] public float CameraShiftTransitionDuration = 1f;


        public GlobalCameraShifter GlobalCameraShifter { get; set; } = default!;
        public GlobalFade GlobalFade { get; set; } = default!;
        public GameGlobals GameGlobals { get; set; } = default!;
        public Interactable3D Interactable3D { get; set; } = null!;
        public Camera3D CameraToShift { get; set; } = null!;
        public Marker3D TargetPositionMarker { get; set; } = default!;

        private bool IsScanningObject = false;

        private Vector3 OriginalScanObjectPosition = Vector3.Zero;
        private Node? OriginalScanObjectParent { get; set; } = default!;

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

            if (IsMovement())
                TargetPositionMarker = this.FirstNodeOfType<Marker3D>();

            if (IsScan()) {
                ObjectToScan ??= GetParent<Node3D>();
            }

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

        public void ScanWorldObject() {
            Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, false);


            var scanObjectMarker = Actor.ScanObjectMarker;

            OriginalScanObjectParent = ObjectToScan.GetParent();
            OriginalScanObjectPosition = ObjectToScan.Position;

            IsScanningObject = true;
            Actor.UseAnimations = false;
            
            ObjectToScan.Reparent(scanObjectMarker);

            var tween = CreateTween();
            tween.TweenProperty(ObjectToScan, Node3D.PropertyName.Position.ToString(), Vector3.Zero, 0.5f)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

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
        public bool IsMovement() => SelectedInteractionType.Equals(InteractionType.Movement);
        public bool IsGrab() => SelectedInteractionType.Equals(InteractionType.Grab);
        public bool IsScan() => SelectedInteractionType.Equals(InteractionType.Scan);
        public bool IsDialogue() => SelectedInteractionType.Equals(InteractionType.Dialogue);
        public bool IsZoom() => SelectedInteractionType.Equals(InteractionType.Zoom);
        public bool IsCinematic() => SelectedInteractionType.Equals(InteractionType.Cinematic);
        public bool IsCameraShift() => SelectedInteractionType.Equals(InteractionType.CameraShift);
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
                case InteractionType.Movement:
                    MoveActorToThisPointClickInteractionPosition();
                    break;
                case InteractionType.Scan:
                    ScanWorldObject();
                    break;
            }
        }

        private void OnCanceledInteraction(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
            Actor.UseAnimations = true;

            if (IsScan()) {
                ObjectToScan.Reparent(OriginalScanObjectParent);

                var tween = CreateTween();
                tween.TweenProperty(ObjectToScan, Node3D.PropertyName.Position.ToString(), OriginalScanObjectPosition, 0.5f)
                    .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

                IsScanningObject = false;
                Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, true);
            }
        }
    }
}
