using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class AirState : MachineState {

        public enum AIR_CONTROL_MODE {
            FULL, // You can move in the air with any direction and update the velocity
            KEEP_IMPULSE // If no input direction is applied stays with the previous velocity
        }
        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public AIR_CONTROL_MODE AirControlMode { get; set; } = AIR_CONTROL_MODE.FULL;
        [Export] public string JumpInputAction { get; set; } = "jump";
        [Export] public float GravityForce { get; set; } = 12.5f;
        [Export] public float MaximumFallVelocity { get; set; } = 50f;
        [Export] public float AirAcceleration { get; set; } = 8.0f;
        [Export] public float AirFriction { get; set; } = 12.0f;
        [Export] public float AirSpeed { get; set; } = 5.5f;

        public override void PhysicsUpdate(double delta) {
            ApplyGravity(GravityForce, delta);
            LimitFallVelocity();
        }

        public void AirMove(double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            if (AirControlMode.Equals(AIR_CONTROL_MODE.FULL) || (AirControlMode.Equals(AIR_CONTROL_MODE.KEEP_IMPULSE) && Actor.MotionInput.InputDirection.IsNotZeroApprox())) {
                var speed = Actor.MotionInput.WorldCoordinateSpaceDirection * AirSpeed;

                if (AirAcceleration > 0 && AirFriction > 0) {
                    var acceleration = Actor.MotionInput.WorldCoordinateSpaceDirection.Dot(Actor.Velocity) > 0 ? AirAcceleration : AirFriction;
                    var accelerationWeight = Mathf.Clamp(acceleration * (float)delta, 0f, 1.0f);

                    Actor.Velocity = Actor.Velocity.Lerp(Actor.Velocity with { X = speed.X, Y = Actor.Velocity.Y, Z = speed.Z }, (float)accelerationWeight);
                }
                else {
                    Actor.Velocity = Actor.Velocity with { X = speed.X, Y = Actor.Velocity.Y, Z = speed.Z };
                }
            }
        }

        public void ApplyGravity(float force, double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            Actor.Velocity += Actor.UpDirectionOpposite() * (float)(force * delta);
        }


        protected void LimitFallVelocity() {
            Vector3 upDirectionOpposite = Actor.UpDirectionOpposite();

            if (upDirectionOpposite.IsEqualApprox(Vector3.Down) || upDirectionOpposite.IsEqualApprox(Vector3.Up))
                Actor.Velocity = Actor.Velocity with { Y = Mathf.Max(Mathf.Sign(upDirectionOpposite.Y) * MaximumFallVelocity, Actor.Velocity.Y) };
            else {
                Actor.Velocity = Actor.Velocity with { X = Mathf.Max(Mathf.Sign(upDirectionOpposite.X) * MaximumFallVelocity, Actor.Velocity.X) };
            }
        }

        public void DetectJump() {
            if (InputMap.HasAction(JumpInputAction) && Input.IsActionJustPressed(JumpInputAction))
                FSM?.ChangeStateTo<Jump>();
        }
    }
}
