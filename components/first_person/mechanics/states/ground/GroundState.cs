using Extensionator;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class GroundState : MachineState {

        [Export] public FirstPersonController Actor { get; set; } = default!;
        [ExportGroup("Input actions")]
        [Export] public string RunInputAction = "run";
        [Export] public string CrouchInputAction = "crouch";
        [Export] public string CrawlInputAction = "crawl";
        [Export] public string JumpInputAction = "jump";
        [Export] public string CrouchAnimationName = "crouch";
        [Export] public string CrawlAnimationName = "crawl";
        [ExportGroup("Motion Parameters")]
        [Export] public float GravityForce { get; set; } = 9.8f;
        [Export] public float Speed { get; set; } = 10f;
        [Export] public float SideSpeed { get; set; } = 9.5f;
        [Export] public float Acceleration { get; set; } = 0;
        [Export] public float Friction { get; set; } = 0;

        public override void PhysicsUpdate(double delta) {
            if (!Actor.isGrounded)
                ApplyGravity(GravityForce, delta);

            if (Actor.IsFalling())
                FSM?.ChangeStateTo<Fall>();
        }

        protected void ApplyMovement(double delta) {
            if (Actor.Stairs) {
                // We want to only apply MoveAndSlide() when stair stepper is enabled and it's not detecting stairs up
                if (!Actor.StairStepper.SnapUpToStairsCheck(delta)) {
                    Actor.MoveAndSlide();
                    Actor.StairStepper.SnapDownToStairsCheck();
                }

                Actor.StairStepper.SlideCameraPivotSmoothToOrigin(delta);
            }
            else {
                Actor.MoveAndSlide();
            }
        }
        protected void ApplyGravity(float force, double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            Actor.Velocity += Actor.UpDirectionOpposite() * (float)(force * delta);
        }

        protected void Accelerate(double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();
            var currentSpeed = Actor.MotionInput.InputDirection.In(Vector2.Right, Vector2.Left) ? SideSpeed : Speed;

            if (Acceleration > 0 && Friction > 0) {
                var acceleration = Actor.MotionInput.WorldCoordinateSpaceDirection.Dot(Actor.Velocity) > 0 ? Acceleration : Friction;
                var accelerationWeight = Mathf.Clamp(acceleration * (float)delta, 0f, 1.0f);
                var velocity = Actor.Velocity.Lerp(currentSpeed * Actor.MotionInput.WorldCoordinateSpaceDirection, (float)accelerationWeight);

                Actor.Velocity = Actor.Velocity with { X = velocity.X, Z = velocity.Z };
            }
            else {
                Actor.Velocity = Actor.MotionInput.WorldCoordinateSpaceDirection * currentSpeed;
            }
        }
        protected void DetectRun() {
            if (Actor.Run && InputMap.HasAction(RunInputAction) && Input.IsActionPressed(RunInputAction))
                FSM?.ChangeStateTo<Run>();
        }

        protected void DetectCrouch() {
            if (Actor.Crouch && InputMap.HasAction(CrouchInputAction) && Input.IsActionPressed(CrouchInputAction))
                FSM?.ChangeStateTo<Crouch>();
        }

        protected void DetectCrawl() {
            if (Actor.Crawl && InputMap.HasAction(CrawlInputAction) && Input.IsActionPressed(CrawlInputAction))
                FSM?.ChangeStateTo<Crawl>();
        }

        protected void DetectJump() {
            if (Actor.Jump && InputMap.HasAction(JumpInputAction) && Input.IsActionJustPressed(JumpInputAction))
                FSM?.ChangeStateTo<Jump>();
        }
    }

}
