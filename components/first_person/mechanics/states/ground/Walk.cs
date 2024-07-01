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
            Actor.MoveAndSlide();
        }

        //       func accelerate(delta: float) -> void:
        //# Using only the horizontal velocity, interpolate towards the input.
        //var temp_vel := velocity
        //   temp_vel.y = 0

        //var temp_accel: float
        //   var target: Vector3 = direction * speed

        //if direction.dot(temp_vel) > 0:

        //       temp_accel = acceleration
        //else:

        //       temp_accel = deceleration

        //if not is_on_floor():

        //       temp_accel *= air_control

        //   var accel_weight = clamp(temp_accel * delta, 0.0, 1.0)

        //   temp_vel = temp_vel.lerp(target, accel_weight)


        //   velocity.x = temp_vel.x

        //   velocity.z = temp_vel.z
        private void CreateCatchingBreathTimer() {
            if (CatchingBreathTimer == null) {
                CatchingBreathTimer = new Timer {
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
}
