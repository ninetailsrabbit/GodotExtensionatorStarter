using Godot;
using GodotExtensionator;


namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class Fall : AirState {
        [Export] public float EdgeGampJump { get; set; } = 0.45f;
        [Export] public bool CoyoteTime { get; set; } = true;
        [Export] public int CoyoteTimeFrames { get; set; } = 20;
        [Export] public bool JumpInputBuffer { get; set; } = true;
        [Export] public int JumpInputBufferTimeFrames { get; set; } = 30;

        private bool _jumpRequested = false;
        private int _currentCoyoteTimeFrames = 0;
        private int _currentJumpInputBufferTimeFrames = 0;

        public override void Enter() {
            _jumpRequested = false;
            _currentCoyoteTimeFrames = CoyoteTimeFrames;
            _currentJumpInputBufferTimeFrames = JumpInputBufferTimeFrames;
        }
        public override void PhysicsUpdate(double delta) {
            if (!CoyoteTimeCountIsActive())
                base.PhysicsUpdate(delta);

            _jumpRequested = InputMap.HasAction(JumpInputAction) && Input.IsActionJustPressed(JumpInputAction);
            _currentCoyoteTimeFrames -= 1;
            _currentJumpInputBufferTimeFrames -= 1;

            if (_jumpRequested && CoyoteTimeCountIsActive())
                FSM?.ChangeStateTo<Jump>();

            else if ((!Actor.wasGrounded && Actor.isGrounded) || Actor.IsOnFloor()) {

                if (_jumpRequested && JumpInputBufferIsActive()) {
                    FSM?.ChangeStateTo<Jump>();
                }
                else {
                    if (Actor.MotionInput.InputDirection.IsZeroApprox())
                        FSM?.ChangeStateTo<Idle>();
                    else
                        FSM?.ChangeStateTo<Walk>();
                }
            }

            AirMove(delta);

            Actor.MoveAndSlide();
        }

        private bool CoyoteTimeCountIsActive() => CoyoteTime && _currentCoyoteTimeFrames.IsGreaterThanZero() && FSM?.LastState() is GroundState;
        private bool JumpInputBufferIsActive() => JumpInputBuffer && _currentJumpInputBufferTimeFrames.IsGreaterThanZero();
    }
}