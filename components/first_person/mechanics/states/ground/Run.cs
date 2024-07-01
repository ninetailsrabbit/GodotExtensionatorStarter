using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Run : GroundState {

        [Export] public float SprintTime = 3.5f;

        public bool InRecovery = false;
        public Timer SpeedTimer { get; set; } = default!;

        public override void _Ready() {
            CreateSpeedTimer();
        }
        public override void Enter() {
            Actor.Velocity = Actor.Velocity with { Y = 0 };

            if (SprintTime > 0 && IsInstanceValid(SpeedTimer))
                SpeedTimer.Start();
            
            InRecovery = false;
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            if (Actor.MotionInput.InputDirection.IsZeroApprox() || !Input.IsActionPressed(RunInputAction))
                FSM?.ChangeStateTo<Idle>();

            Accelerate(delta);

            //if(Actor.Slide) {
            //    if (InputMap.HasAction(CrouchInputAction) && Input.IsActionJustPressed(CrouchInputAction))
            //        FSM?.ChangeStateTo<Slide>();
            //} else {
            //    DetectCrouch();
            //}

            Actor.MoveAndSlide();
        }

        private void CreateSpeedTimer() {
            if (SpeedTimer is null) {
                SpeedTimer = new Timer {
                    Name = "RunSpeedTimer",
                    WaitTime = SprintTime,
                    ProcessCallback = Timer.TimerProcessCallback.Physics,
                    Autostart = false,
                    OneShot = true
                };

                AddChild(SpeedTimer);
                SpeedTimer.Timeout += OnSpeedTimerTimeout;
            }
        }

        private void OnSpeedTimerTimeout() {
            InRecovery = true;
            FSM?.ChangeStateTo<Walk>();
        }

    }
}
