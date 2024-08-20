using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class AirState : MachineState {

        public enum AirControlMode {
            Full, // You can move in the air with any direction and update the velocity
            KeepImpulse // If no input direction is applied stays with the previous velocity
        }
        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public AirControlMode SelectedAirControlMode { get; set; } = AirControlMode.Full;
        [Export] public string JumpInputAction { get; set; } = "jump";
        [Export] public float GravityForce { get; set; } = 12.5f;
        [Export] public float MaximumFallVelocity { get; set; } = 50f;
        [Export] public float AirAcceleration { get; set; } = 20.0f;
        [Export] public float AirFriction { get; set; } = 25.0f;
        [Export] public float AirSpeed { get; set; } = 8.5f;

        public MeshInstance3D Ocean { get; set; } = default!;

        public float FinalSpeed = 0f;

        public override void Enter() {
            FinalSpeed = FSM?.LastState() is GroundState groundState ? Mathf.Max(AirSpeed, groundState.Speed) : AirSpeed;
        }

        public override void Ready() {
            Ocean = GetTree().Root.GetFirstNodeInGroup<MeshInstance3D>("ocean");
        }

        public override void PhysicsUpdate(double delta) {
            ApplyGravity(GravityForce, delta);
            LimitFallVelocity();
        }

        public void AirMove(double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            if (SelectedAirControlMode.Equals(AirControlMode.Full) || (SelectedAirControlMode.Equals(AirControlMode.KeepImpulse) && Actor.MotionInput.InputDirection.IsNotZeroApprox())) {
                var speed = Actor.MotionInput.WorldCoordinateSpaceDirection * FinalSpeed;

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
            if (Actor.Jump && InputMap.HasAction(JumpInputAction) && Input.IsActionJustPressed(JumpInputAction))
                FSM?.ChangeStateTo<Jump>();
        }

        public void DetectWall() {
            //if (Actor.WallClimb && Actor.WallRayCastDetector3D.IsFrontWallDetected()) {
            //    FSM?.ChangeStateTo<WallClimb>();
            //}
            if (Actor.WallRun && Actor.WallRayCastDetector3D.AnySideWallDetected()) {
                FSM?.ChangeStateTo<WallRun>();

            }
        }

        public void DetectSwim() {
            if (Actor.Swim && Actor.Eyes.GlobalPosition.Y <= Ocean.GlobalPosition.Y)
                FSM?.ChangeStateTo<Swim>();
        }
    }
}
