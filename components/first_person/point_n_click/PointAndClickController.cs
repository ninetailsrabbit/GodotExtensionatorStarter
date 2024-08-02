using Godot;
using GodotExtensionator;
using System.Linq;


namespace GodotExtensionatorStarter {

    [Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickController : Node3D {

        public const string GroupName = "point_and_click_controller";

        [Export] public float StandingStatureInMeters = 1.75f;
        [Export] public string DefaultAnimation = "idle";
        [Export]
        public bool UseAnimations {
            get => _useAnimations; set {
                if (_useAnimations != value) {
                    _useAnimations = value;

                    if (UseAnimations) {
                        RunAnimation(DefaultAnimation);
                    }
                    else {
                        AnimationPlayer.Stop();
                    }
                }
            }
        }
        [Export] public bool BlurCameraOnScan = true;


        public GlobalFade GlobalFade { get; set; } = default!;
        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public AnimationPlayer AnimationPlayer { get; set; } = null!;
        public MouseRayCastInteractor MouseRayCastInteractor { get; set; } = null!;

        public CanvasLayer InteractionLayer { get; set; } = null!;

        public SubViewport ScanSubViewport { get; set; } = null!;
        public Marker3D ScanObjectMarker { get; set; } = null!;

        public Node3D Eyes { get; set; } = null!;
        public Camera3D Camera3D { get; set; } = null!;

        public Vector3 OriginalEyesPosition = Vector3.Zero;
        public Vector3 OriginalEyesRotation = Vector3.Zero;

        private bool _useAnimations = true;

        public override void _ExitTree() {
            GlobalFade.FadeStarted -= OnFadeStarted;
            GlobalFade.FadeFinished -= OnFadeFinished;

            GlobalGameEvents.ActorMovedToPointAndClickPosition -= OnPointAndClickMovement;
            GlobalGameEvents.ActorScannedObject -= OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan -= OnPointAndClickScanCanceled;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            GlobalFade = this.GetAutoloadNode<GlobalFade>();
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();

            AnimationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
            MouseRayCastInteractor = GetNode<MouseRayCastInteractor>(nameof(MouseRayCastInteractor));
            ScanObjectMarker = GetNode<Marker3D>(nameof(ScanObjectMarker));
            Eyes = GetNode<Node3D>($"%{nameof(Eyes)}");
            Camera3D = GetNode<Camera3D>($"%{nameof(Camera3D)}");
            InteractionLayer = GetNode<CanvasLayer>($"{nameof(InteractionLayer)}");

            InteractionLayer.Hide();

            GlobalFade.FadeStarted += OnFadeStarted;
            GlobalFade.FadeFinished += OnFadeFinished;

            GlobalGameEvents.ActorMovedToPointAndClickPosition += OnPointAndClickMovement;
            GlobalGameEvents.ActorScannedObject += OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan += OnPointAndClickScanCanceled;
        }


        public override void _Ready() {
            ApplyStandingStature();

            OriginalEyesPosition = Eyes.Position;
            OriginalEyesRotation = Eyes.Rotation;

            Camera3D.MakeCurrent();
            EnableCameraBlur(false);

            RunAnimation(DefaultAnimation);
        }

        public void ResetEyesPosition() {
            AnimationPlayer.Stop();

            var tween = CreateTween();
            tween.TweenProperty(Eyes, Node3D.PropertyName.Rotation.ToString(), OriginalEyesRotation, 0.5f).SetEase(Tween.EaseType.Out);
        }

        public void ApplyStandingStature() {
            Position = Position with { Y = StandingStatureInMeters };
        }

        public void EnableCameraBlur(bool enabled = true) {
            ((CameraAttributesPractical)Camera3D.Attributes).DofBlurFarEnabled = enabled;
        }

        private void RunAnimation(string animationName) {
            if (UseAnimations)
                AnimationPlayer.Play(animationName);
        }

        private void OnFadeStarted() {
            ResetEyesPosition();
            MouseRayCastInteractor.Disable();
        }

        private void OnFadeFinished() {
            MouseRayCastInteractor.Enable();
            RunAnimation(DefaultAnimation);
        }

        private void OnPointAndClickMovement(PointAndClickMovement pointAndClickMovement) {
            GetTree().Root.GetAllChildren()
                .Where(node => node is PointAndClickMovement pointNClick && !pointNClick.Equals(pointAndClickMovement))
                .Cast<PointAndClickMovement>()
                .ToList()
                .ForEach(pointAndClick => pointAndClick.Interactable3D.Enable());

            pointAndClickMovement.Interactable3D.Disable();
        }


        private void OnPointAndClickObjectScanned(PointAndClickObjectScanner pointAndClickObjectScanner) {
            EnableCameraBlur(BlurCameraOnScan);
        }

        private void OnPointAndClickScanCanceled(PointAndClickObjectScanner pointAndClickObjectScanner) {
            EnableCameraBlur(false);
        }
    }
}
