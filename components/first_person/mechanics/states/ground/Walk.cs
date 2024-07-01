using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Walk : GroundState {

        [Export] public float CatchingBreathRecoveryTime = 3f;

        public Timer CatchingBreathTimer { get; set; } = default!;

        public override void _Ready() {
            CreateCatchingBreathTimer();
        }

        public override void Enter() {
            Actor.Velocity = Actor.Velocity with { Y = 0 };
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            if (Actor.MotionInput.InputDirection.IsZeroApprox())
                FSM?.ChangeStateTo<Idle>();

            Accelerate(delta);
            DetectRun();
            DetectCrouch();

            Actor.MoveAndSlide();
        }

        private void CreateCatchingBreathTimer() {
            CatchingBreathTimer ??= new Timer {
                Name = "RunCatchingBreathTimer",
                WaitTime = CatchingBreathRecoveryTime,
                ProcessCallback = Timer.TimerProcessCallback.Physics,
                Autostart = false,
                OneShot = true
            };

            AddChild(CatchingBreathTimer);
        }
    }
}
