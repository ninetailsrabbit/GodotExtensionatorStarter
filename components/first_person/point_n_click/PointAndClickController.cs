using FirstPersonTemplate;
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
                        AnimationPlayer?.Stop();
                    }
                }
            }
        }
        [Export] public bool BlurCameraOnScan = true;
        [Export] public string InputActionToChangeCameraMode = "change_camera_mode";
        [Export]
        public bool CanMoveCamera {
            get => _canMoveCamera;
            set {
                _canMoveCamera = value;
                SetProcessInput(_canMoveCamera);
            }
        }

        public GlobalFade GlobalFade { get; set; } = default!;
        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public AnimationPlayer AnimationPlayer { get; set; } = null!;
        public MouseRayCastInteractor MouseRayCastInteractor { get; set; } = null!;
        public CanvasLayer InteractionLayer { get; set; } = null!;
        public CanvasLayer SubtitlesLayer { get; set; } = null!;
        public SubViewport ScanSubViewport { get; set; } = null!;
        public Marker3D ScanObjectMarker { get; set; } = null!;
        public Node3D Eyes { get; set; } = null!;
        public Camera3D Camera3D { get; set; } = null!;

        public CameraMovement CameraMovement { get; set; } = default!;


        public Vector3 OriginalEyesPosition = Vector3.Zero;
        public Vector3 OriginalEyesRotation = Vector3.Zero;
        public enum PointAndClickCameraMode {
            FREE_MOVEMENT,
            STATIC
        }

        public PointAndClickCameraMode CurrentCameraMode {
            get => _currentCameraMode;
            set {
                if (_currentCameraMode != value) {
                    _currentCameraMode = value;

                    if (IsNodeReady()) {
                        switch (_currentCameraMode) {
                            case PointAndClickCameraMode.FREE_MOVEMENT:
                                CameraMovement.Enable();
                                MouseRayCastInteractor.Disable();
                                InputExtension.CaptureMouse();

                                break;
                            case PointAndClickCameraMode.STATIC:
                                CameraMovement.Disable();
                                MouseRayCastInteractor.Enable();
                                Input.MouseMode = Input.MouseModeEnum.Visible;

                                break;
                            default:
                                CameraMovement.Disable();
                                MouseRayCastInteractor.Enable();
                                Input.MouseMode = Input.MouseModeEnum.Visible;
                                break;
                        }
                    }

                }
            }
        }

        private PointAndClickCameraMode _currentCameraMode = PointAndClickCameraMode.STATIC;
        private bool _useAnimations = true;
        private bool _canMoveCamera = false;

        public override void _ExitTree() {
            GlobalFade.FadeStarted -= OnFadeStarted;
            GlobalFade.FadeFinished -= OnFadeFinished;

            GlobalGameEvents.ActorMovedToPointAndClickPosition -= OnPointAndClickInteracted;
            GlobalGameEvents.PointAndClickInteractionCanceled -= OnPointAndClickCanceledInteraction;
            GlobalGameEvents.ActorScannedObject -= OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan -= OnPointAndClickScanCanceled;

            GlobalGameEvents.ChangedSubtitlesDisplayOption -= OnChangedSubtitleDisplayOption;
            GlobalGameEvents.SubtitleBlocksStartedToDisplay -= OnSubtitleBlocksStartedToDisplay;
            GlobalGameEvents.SubtitleBlocksFinishedToDisplay -= OnSubtitleBlocksFinishedToDisplay;
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
            CameraMovement = GetNode<CameraMovement>($"%{nameof(CameraMovement)}");

            InteractionLayer = GetNode<CanvasLayer>($"{nameof(InteractionLayer)}");
            SubtitlesLayer = GetNode<CanvasLayer>($"{nameof(SubtitlesLayer)}");

            InteractionLayer.Hide();
            SubtitlesLayer.Hide();

            GlobalFade.FadeStarted += OnFadeStarted;
            GlobalFade.FadeFinished += OnFadeFinished;

            GlobalGameEvents.PointAndClickInteracted += OnPointAndClickInteracted;
            GlobalGameEvents.PointAndClickInteractionCanceled += OnPointAndClickCanceledInteraction;
            GlobalGameEvents.ActorScannedObject += OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan += OnPointAndClickScanCanceled;

            GlobalGameEvents.ChangedSubtitlesDisplayOption += OnChangedSubtitleDisplayOption;
            GlobalGameEvents.SubtitleBlocksStartedToDisplay += OnSubtitleBlocksStartedToDisplay;
            GlobalGameEvents.SubtitleBlocksFinishedToDisplay += OnSubtitleBlocksFinishedToDisplay;

        }

        public override void _Input(InputEvent @event) {
            if (CameraMovement is not null && CanMoveCamera && Input.IsActionJustPressed(InputActionToChangeCameraMode)) {
                if (CurrentCameraMode.Equals(PointAndClickCameraMode.STATIC))
                    ChangeCameraToFreeMovement();
                else
                    ChangeCameraToStaticMovement();
            }
        }

        public override void _Ready() {
            ChangeCameraToStaticMovement();
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

        public void LockCameraMovement() {
            CameraMovement?.Lock();
        }

        public void UnlockCameraMovement() {
            CameraMovement?.Unlock();
        }
        public void ChangeCameraToFreeMovement() {
            CurrentCameraMode = PointAndClickCameraMode.FREE_MOVEMENT;

            AnimationPlayer?.Stop();
        }

        public void ChangeCameraToStaticMovement() {
            CurrentCameraMode = PointAndClickCameraMode.STATIC;

            if (UseAnimations)
                RunAnimation(DefaultAnimation);
        }

        public void ReturnCameraRotationLimitToDefault() {
            CameraMovement.ReturnToOriginalLimitRotation();
        }
        public void ChangeCameraRotationLimit(float horizontalRotationLimit = 0f, float verticalRotationLimit = 89f) {
            CameraMovement.ChangeCameraHorizontalRotationLimit(horizontalRotationLimit);
            CameraMovement.ChangeCameraVerticalRotationLimit(verticalRotationLimit);
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

        private void OnPointAndClickInteracted(PointAndClickInteraction pointAndClickInteraction) {
            GetTree().Root.GetAllChildren()
                .Where(node => node is PointAndClickInteraction pointNClick && !pointNClick.Equals(pointAndClickInteraction))
                .Cast<PointAndClickInteraction>()
                .ToList()
                .ForEach(pointAndClick => pointAndClick.Interactable3D.Enable());

            pointAndClickInteraction.Interactable3D.Disable();
        }


        private void OnPointAndClickCanceledInteraction(PointAndClickInteraction pointAndClickInteraction) {
            pointAndClickInteraction.Interactable3D.Enable();
        }

        private void OnPointAndClickObjectScanned(PointAndClickObjectScanner pointAndClickObjectScanner) {
            EnableCameraBlur(BlurCameraOnScan);
        }

        private void OnPointAndClickScanCanceled(PointAndClickObjectScanner pointAndClickObjectScanner) {
            EnableCameraBlur(false);
        }

        private void OnChangedSubtitleDisplayOption(bool enabled) {
            if (enabled) {
                SubtitlesLayer.Enable();
            }
            else {
                SubtitlesLayer.Hide();
                SubtitlesLayer.Disable();
            }
        }

        private void OnSubtitleBlocksStartedToDisplay() {
            SubtitlesLayer.Show();
        }

        private void OnSubtitleBlocksFinishedToDisplay() {
            SubtitlesLayer.Hide();
        }

    }
}
