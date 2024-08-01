using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    public abstract partial class PointAndClickInteraction : Node3D {

        public const string GroupName = "point_and_click_interaction";

        [Export] public StringName InteractionId = string.Empty;
        [Export] public PointNClickController Actor { get; set; } = default!;

        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export] public CompressedTexture2D FocusCursor { get; set; } = default!;

        public GlobalFade GlobalFade { get; set; } = default!;
        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public Interactable3D Interactable3D { get; set; } = null!;


        //public GlobalCameraShifter GlobalCameraShifter { get; set; } = default!;
        //public GlobalFade GlobalFade { get; set; } = default!;
        //public GameGlobals GameGlobals { get; set; } = default!;
        //public Camera3D CameraToShift { get; set; } = null!;

        //private bool IsScanningObject = false;

        //private Vector3 OriginalScanObjectPosition = Vector3.Zero;
        //private Node? OriginalScanObjectParent { get; set; } = default!;

        public override void _ExitTree() {
            Interactable3D.Focused -= OnFocused;
            Interactable3D.UnFocused -= OnUnFocused;
            Interactable3D.CanceledInteraction -= OnCanceledInteraction;
            Interactable3D.Interacted -= OnInteracted;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            GlobalFade = this.GetAutoloadNode<GlobalFade>();
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();

            Actor ??= GetTree().GetFirstNodeInGroup(PointNClickController.GroupName) as PointNClickController;

            Interactable3D = this.FirstNodeOfClass<Interactable3D>();

            ArgumentNullException.ThrowIfNull(Interactable3D);

            Interactable3D.Focused += OnFocused;
            Interactable3D.UnFocused += OnUnFocused;
            Interactable3D.CanceledInteraction += OnCanceledInteraction;
            Interactable3D.Interacted += OnInteracted;


            //if (IsMovement())

            //if (IsScan()) {
            //    ObjectToScan ??= GetParent<Node3D>();
            //}

            //CreateActorDetectorArea();
        }

        //public async void MoveActorToThisPointClickInteractionPosition() {
        //    GlobalFade.FadeIn(FadeTimeOnMovement);
        //    await ToSignal(GlobalFade, GlobalFade.SignalName.FadeFinished);

        //    Actor.AlignWithNode(TargetPositionMarker);
        //    Actor.ApplyStandingStature();

        //    GlobalFade.FadeOut(FadeTimeOnMovement);
        //}

        //public void MoveActorWithCameraShift() {
        //    if (IsCameraShift() && CameraToShift is not null) {
        //        GlobalCameraShifter.TransitionToRequestedCamera3D(Actor.Camera3D, CameraToShift, CameraShiftTransitionDuration);
        //        Actor.MouseRayCastInteractor.ChangeCameraTo(CameraToShift);
        //    }
        //}

        //public void BackToActorOriginalCamera() {
        //    if (IsCameraShift() && CameraToShift is not null) {
        //        GlobalCameraShifter.TransitionToFirstCameraThroughAllSteps3D();
        //        Actor.MouseRayCastInteractor.ReturnToOriginalCamera();
        //    }
        //}

        //public void ScanWorldObject() {
        //    Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, false);


        //    var scanObjectMarker = Actor.ScanObjectMarker;

        //    OriginalScanObjectParent = ObjectToScan.GetParent();
        //    OriginalScanObjectPosition = ObjectToScan.Position;

        //    IsScanningObject = true;
        //    Actor.UseAnimations = false;

        //    ObjectToScan.Reparent(scanObjectMarker);

        //    var tween = CreateTween();
        //    tween.TweenProperty(ObjectToScan, Node3D.PropertyName.Position.ToString(), Vector3.Zero, 0.5f)
        //        .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

        //}

        //private void CreateActorDetectorArea() {
        //    Area3D detector = new() {
        //        Name = "ActorAreaDetector",
        //        Monitoring = true,
        //        Monitorable = false,
        //        Priority = 1,
        //        CollisionLayer = 0,
        //        CollisionMask = GameGlobals.PlayerCollisionLayer
        //    };

        //    CollisionShape3D shape = new() { Shape = new SphereShape3D() { Radius = 0.8f } };

        //    AddChild(detector);
        //    detector.AddChild(shape);

        //    detector.AreaEntered += OnActorDetected;
        //    detector.AreaExited += OnActorExited;
        //}

        //private void OnActorDetected(Area3D _) {
        //    if (IsMovement() || IsCameraShift())
        //        Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, false);
        //}

        //private void OnActorExited(Area3D _) {
        //    if (IsMovement() || IsCameraShift())
        //        Interactable3D.SetDeferred(Area3D.PropertyName.Monitorable, true);
        //}


        //#region Helpers
        //public bool IsMovement() => SelectedInteractionType.Equals(InteractionType.Movement);
        //public bool IsGrab() => SelectedInteractionType.Equals(InteractionType.Grab);
        //public bool IsScan() => SelectedInteractionType.Equals(InteractionType.Scan);
        //public bool IsDialogue() => SelectedInteractionType.Equals(InteractionType.Dialogue);
        //public bool IsZoom() => SelectedInteractionType.Equals(InteractionType.Zoom);
        //public bool IsCinematic() => SelectedInteractionType.Equals(InteractionType.Cinematic);
        //public bool IsCameraShift() => SelectedInteractionType.Equals(InteractionType.CameraShift);
        //#endregion

        protected virtual void OnFocused(GodotObject interactor) {
            if (FocusCursor is not null)
                Input.SetCustomMouseCursor(FocusCursor, SelectedCursorShape, FocusCursor.GetSize() / 2);
        }

        protected virtual void OnUnFocused(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }

        protected virtual void OnInteracted(GodotObject interactor) { }

        protected virtual void OnCanceledInteraction(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }
    }
}
