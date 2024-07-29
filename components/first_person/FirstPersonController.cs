using FirstPersonTemplate;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [Icon("res://components/first_person/mechanics/icons/first_person_controller.svg")]
    public partial class FirstPersonController : CharacterBody3D {
        public const string GroupName = "player";

        #region Exported variables
        [ExportGroup("Input")]
        [Export] public string[] MouseModeSwitchInputs = ["ui_cancel"];

        [ExportGroup("Mechanics")]
        [Export] public bool Run = true;
        [Export] public bool Jump = true;
        [Export] public bool Crouch = true;
        [Export] public bool Crawl = true;
        [Export] public bool Slide = true;
        [Export] public bool WallRun = true;
        [Export] public bool WallJump = true;
        [Export] public bool WallClimb = true;
        [Export] public bool Surf = true;
        [Export] public bool Swim = true;
        [Export] public bool Stairs = true;

        [ExportGroup("HeadBob configuration")]
        [Export] public float HeadBobWalkIntensity = 0.02f;
        [Export] public float HeadBobRunIntensity = 0.05f;
        [Export] public float HeadBobCrouchIntensity = 0.01f;
        [Export] public float HeadBobSwimIntensity = 0.02f;
        #endregion

        #region Collisions
        public CollisionShape3D StandShape { get; private set; } = default!;
        public CollisionShape3D CrouchShape { get; private set; } = default!;
        public CollisionShape3D CrawlShape { get; private set; } = default!;
        public ShapeCast3D CeilShapeCast { get; private set; } = default!;
        #endregion

        #region Motion
        public AnimationPlayer AnimationPlayer { get; private set; } = default!;
        public CameraMovement CameraMovement { get; private set; } = default!;
        public HeadBob HeadBob { get; private set; } = default!;
        public StairStepper StairStepper { get; private set; } = default!;

        public FiniteStateMachine FSM { get; private set; } = default!;
        public MouseRayCastInteractor MouseRayCastInteractor { get; private set; } = default!;
        public TransformedInput MotionInput { get; private set; } = default!;
        #endregion

        public bool wasGrounded = false;
        public bool isGrounded = false;

        public override void _UnhandledInput(InputEvent @event) {
            if (InputExtension.IsAnyActionJustPressed(MouseModeSwitchInputs)) {
                SwitchMouseCaptureMode();
            }
        }

        public override void _ExitTree() {
            FSM.StateChanged -= OnStateChanged;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            MotionInput = new(this);

            AnimationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
            StandShape = GetNode<CollisionShape3D>(nameof(StandShape));
            CrouchShape = GetNode<CollisionShape3D>(nameof(CrouchShape));
            CrawlShape = GetNode<CollisionShape3D>(nameof(CrawlShape));
            CeilShapeCast = GetNode<ShapeCast3D>($"%{nameof(CeilShapeCast)}");

            MouseRayCastInteractor = GetNode<MouseRayCastInteractor>(nameof(MouseRayCastInteractor));

            FSM = GetNode<FiniteStateMachine>(nameof(FiniteStateMachine));
            CameraMovement = this.FirstNodeOfClass<CameraMovement>();
            HeadBob = this.FirstNodeOfClass<HeadBob>();
            StairStepper = this.FirstNodeOfClass<StairStepper>();

            FSM.RegisterTransitions([
                new WalkToRunTransition(),
                new RunToWalkTransition()
            ]);

            FSM.StateChanged += OnStateChanged;
        }

        public override void _Ready() {
            InputExtension.CaptureMouse();
        }

        public override void _PhysicsProcess(double delta) {
            wasGrounded = isGrounded;
            isGrounded = IsOnFloor();

            MotionInput.Update();
        }

        public bool IsFalling() {
            Vector3 oppositeUpDirection = this.UpDirectionOpposite();

            bool oppositeToGravityVector = (oppositeUpDirection.IsEqualApprox(Vector3.Down) && Velocity.Y < 0) ||
                (oppositeUpDirection.IsEqualApprox(Vector3.Up) && Velocity.Y > 0) ||
                (oppositeUpDirection.IsEqualApprox(Vector3.Left) && Velocity.X < 0) ||
                (oppositeUpDirection.IsEqualApprox(Vector3.Right) && Velocity.X > 0);

            return !isGrounded && oppositeToGravityVector && !StairStepper.StairsBelowRayCast3D.IsColliding();
        }

        private void SwitchMouseCaptureMode() {
            if (InputExtension.IsMouseVisible()) {
                InputExtension.CaptureMouse();
                MouseRayCastInteractor.Disable();
            }
            else {
                InputExtension.ShowMouseCursor();
                MouseRayCastInteractor.Enable();
            }


        }

        #region Signal callbacks
        private void OnStateChanged(MachineState from, MachineState to) {
            switch (to) {
                case Idle _:
                    StandShape.Disabled = false;
                    CrouchShape.Disabled = true;
                    CrawlShape.Disabled = true;
                    break;
                case Walk _:
                    StandShape.Disabled = false;
                    CrouchShape.Disabled = true;
                    CrawlShape.Disabled = true;
                    HeadBob.Intensity = HeadBobWalkIntensity;
                    break;
                case Run _:
                    StandShape.Disabled = false;
                    CrouchShape.Disabled = true;
                    CrawlShape.Disabled = true;
                    HeadBob.Intensity = HeadBobRunIntensity;
                    break;
                case Crouch _:
                    StandShape.Disabled = true;
                    CrouchShape.Disabled = false;
                    CrawlShape.Disabled = true;
                    HeadBob.Intensity = HeadBobCrouchIntensity;
                    break;
                case Crawl _:
                    StandShape.Disabled = true;
                    CrouchShape.Disabled = true;
                    CrawlShape.Disabled = false;
                    HeadBob.Intensity = HeadBobCrouchIntensity;
                    break;
                case Slide _:
                    StandShape.Disabled = true;
                    CrouchShape.Disabled = false;
                    CrawlShape.Disabled = true;
                    break;
                //case Swim _:
                //    HeadBob.Intensity = HeadBobSwimIntensity;
                //    break;
                case AirState _:
                    StandShape.Disabled = false;
                    CrouchShape.Disabled = true;
                    CrawlShape.Disabled = true;
                    break;
                default:
                    HeadBob.Intensity = HeadBobWalkIntensity;
                    break;
            }
        }


        #endregion
    }
}
