using Extensionator;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class Swim : MachineState {
        [Export] public FirstPersonController Actor { get; set; } = default!;
        [Export] public string JumpInputAction = "jump";
        [Export] public float GravityForce { get; set; } = 0.1f;
        [Export] public float MaximumFallVelocity { get; set; } = 0.85f;
        [Export] public float Speed { get; set; } = 3f;
        [Export] public float SideSpeed { get; set; } = 2.6f;
        [Export] public float Acceleration { get; set; } = 8;
        [Export] public float Friction { get; set; } = 10;

        public MeshInstance3D Ocean { get; set; } = default!;
        public MeshInstance3D UnderWaterRefraction { get; set; } = default!;

        private bool WasUnderWater = false;
        private bool IsUnderWater = false;
        public override void Exit(MachineState nextState) {
            UnderWaterRefraction.Hide();
            //Actor.SubmergedEffect.Hide();
        }

        public override void Enter() {
            Actor.Velocity /= 2f;
        }

        public override void Ready() {
            Ocean = GetTree().Root.GetFirstNodeInGroup<MeshInstance3D>("ocean");
            UnderWaterRefraction = Ocean?.GetChild(0) as MeshInstance3D;
        }

        public override void Update(double delta) {
            var depth = Ocean.GlobalPosition.Y - (Actor.Eyes.GlobalPosition.Y - 0.15f);

            WasUnderWater = IsUnderWater;
            UnderWaterRefraction.Visible = depth > 0;
            IsUnderWater = UnderWaterRefraction.Visible;

            if (WasUnderWater && !IsUnderWater) {
                Actor.Velocity += Vector3.Up * 0.05f;
                //Actor.SubmergedEffect.Hide();
            }

            if (!WasUnderWater && IsUnderWater)
                //Actor.SubmergedEffect.Show();

            if (Actor.GlobalPosition.Y > Ocean.GlobalPosition.Y) {
                FSM?.ChangeStateTo<Fall>();
            }

            if (IsUnderWater)
                ApplyGravity(GravityForce, delta);

            if (Actor.MotionInput.InputDirection.IsZeroApprox())
                Decelerate(delta);
            else
                Accelerate(delta);

            DetectJump();

            Actor.MoveAndSlide();

        }

        protected void ApplyGravity(float force, double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            Actor.Velocity += Actor.UpDirectionOpposite() * (float)(force * delta);
            Actor.Velocity = Actor.Velocity with { Y = Mathf.Max(Actor.Velocity.Y, Mathf.Sign(Actor.UpDirectionOpposite().Y) * MaximumFallVelocity) };
        }

        protected void Accelerate(double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            var currentSpeed = Actor.MotionInput.InputDirection.In(Vector2.Right, Vector2.Left) ? SideSpeed : Speed;
            var direction = Actor.MotionInput.WorldCoordinateSpaceDirection;

            if (IsUnderWater) {
                if (Actor.MotionInput.InputDirection.IsEqualApprox(Vector2.Up)) {
                    direction = Actor.Camera.ForwardDirection();
                }
                else if (Actor.MotionInput.InputDirection.IsEqualApprox(Vector2.Down)) {
                    direction = Actor.Camera.ForwardDirection().Flip();
                }
            }
            else {
                //Means that it's looking down so can submerge into the water
                if (Mathf.Sign(Actor.Camera.ForwardDirection().Y).Equals(Mathf.Sign(Actor.UpDirectionOpposite().Y))) {
                    direction = Actor.Camera.ForwardDirection();
                }
            }


            // TODO - WITH ACCELERATION THE MOVEMENT IS NOT BEING APPLIED ON SWIM OR IT'S VERY LOW
            if (Acceleration > 0 && Friction > 0) {
                var acceleration = direction.Dot(Actor.Velocity) > 0 ? Acceleration : Friction;
                var accelerationWeight = Mathf.Clamp(acceleration * (float)delta, 0f, 1.0f);
                var velocity = Actor.Velocity.Lerp(direction * currentSpeed, (float)accelerationWeight);
            }
            else {
                Actor.Velocity = direction * currentSpeed;
            }

        }

        protected void Decelerate(double delta) {
            if (Friction > 0)
                Actor.Velocity = Actor.Velocity.Lerp(new Vector3(0, IsUnderWater ? Actor.Velocity.Y : 0, 0), Mathf.Clamp(Friction * (float)delta, 0, 1f));
            else
                Actor.Velocity = new Vector3(0, IsUnderWater ? Actor.Velocity.Y : 0, 0);
        }

        protected void DetectJump() {
            if (Actor.Jump && Actor.Eyes.GlobalPosition.Y > Ocean.GlobalPosition.Y && InputMap.HasAction(JumpInputAction) && Input.IsActionJustPressed(JumpInputAction))
                FSM?.ChangeStateTo<Jump>();
        }

    }
}
