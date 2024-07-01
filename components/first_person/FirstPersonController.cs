using FirstPersonTemplate;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [Icon("res://components/first_person/mechanics/icons/first_person_controller.svg")]
    public partial class FirstPersonController : CharacterBody3D {
        public const string GROUP_NAME = "player";

        #region Exported variables
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
        [Export] public float HeadBobCrouchIntensity = 0.02f;
        [Export] public float HeadBobSwimIntensity = 0.02f;
        #endregion

        #region Collisions
        public CollisionShape3D StandShape { get; private set; } = default!;
        public CollisionShape3D CrouchShape { get; private set; } = default!;
        public CollisionShape3D CrawlShape { get; private set; } = default!;
        #endregion

        #region Motion
        public CameraMovement CameraMovement { get; private set; } = default!;
        public HeadBob HeadBob { get; private set; } = default!;
        public FiniteStateMachine FSM { get; private set; } = default!;
        public TransformedInput MotionInput { get; private set; } = default!;
        #endregion

        public bool wasGrounded = false;
        public bool isGrounded = false;
        public override void _UnhandledInput(InputEvent @event) {
            if (Input.IsActionJustPressed("ui_cancel")) {
                SwitchMouseCaptureMode();
            }
        }

        public override void _ExitTree() {
            FSM.StateChanged -= OnStateChanged;
        }

        public override void _EnterTree() {
            MotionInput = new(this);

            FSM = GetNode<FiniteStateMachine>(nameof(FiniteStateMachine));
            CameraMovement = this.FirstNodeOfClass<CameraMovement>();
            HeadBob = this.FirstNodeOfClass<HeadBob>();

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

        private void SwitchMouseCaptureMode() {
            if (InputExtension.IsMouseVisible())
                InputExtension.CaptureMouse();
            else
                InputExtension.ShowMouseCursor();
        }

        #region Signal callbacks
        private void OnStateChanged(MachineState from, MachineState to) {

        }

        #endregion
    }
}
