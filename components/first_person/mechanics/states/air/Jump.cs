using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Jump : AirState {

        [Export] public int JumpTimes { get; set; } = 1;
        [Export] public float HeightReducedByJump { get; set; } = 0.2f;
        [Export] public bool ShortenJumpOnInputRelease { get; set; } = true;

        [ExportGroup("Jump configuration")]
        [Export]
        public float JumpHeight {
            get => _jumpHeight;
            set {
                _jumpHeight = value;

                JumpVelocity = CalculateJumpVelocity(_jumpHeight, JumpPeakTime);
                JumpGravity = CalculateJumpGravity(_jumpHeight, JumpPeakTime);
                FallGravity = CalculateFallGravity(_jumpHeight, JumpFallTime);
            }
        }
        private float _jumpHeight = 4f;

        [Export]
        public float JumpPeakTime {
            get => _jumpPeakTime;
            set {
                _jumpPeakTime = value;

                JumpVelocity = CalculateJumpVelocity(JumpHeight, _jumpPeakTime);
                JumpGravity = CalculateJumpGravity(JumpHeight, _jumpPeakTime);
            }
        }
        private float _jumpPeakTime = 0.55f;

        [Export]
        public float JumpFallTime {
            get => _jumpFallTime;
            set {
                _jumpFallTime = value;

                FallGravity = CalculateFallGravity(JumpHeight, _jumpFallTime);
                AirSpeed = CalculateAirSpeed(JumpDistance, JumpPeakTime, _jumpFallTime);

            }
        }
        private float _jumpFallTime = 0.48f;

        [Export]
        public float JumpDistance {
            get => _jumpDistance; set {
                _jumpDistance = value;
                AirSpeed = CalculateAirSpeed(_jumpDistance, JumpPeakTime, JumpFallTime);
            }
        }
        private float _jumpDistance = 4f;

        public float JumpVelocity;
        public float JumpGravity;
        public float FallGravity;

        public int JumpCount = 0;
        public float JumpHorizontalBoost = 0f;
        public float JumpVerticalBoost = 0f;

        public Vector3 JumpedPosition = Vector3.Zero;

        public override void _EnterTree() {
            JumpVelocity = CalculateJumpVelocity(JumpHeight, JumpPeakTime);
            JumpGravity = CalculateJumpGravity(JumpHeight, JumpPeakTime);
            FallGravity = CalculateFallGravity(JumpHeight, JumpFallTime);
            AirSpeed = CalculateAirSpeed(JumpDistance, JumpPeakTime, JumpFallTime);
        }

        public override void Enter() {
            base.Enter();

            ApplyJump();
            Actor.MoveAndSlide();
        }

        public override void Exit(MachineState _) {
            JumpCount = 0;
            JumpHorizontalBoost = 0f;
            JumpVerticalBoost = 0f;
            JumpedPosition = Vector3.Zero;
        }

        public override void PhysicsUpdate(double delta) {
            ApplyGravity(GetGravity(), delta);

            if (Input.IsActionJustPressed(JumpInputAction) && JumpCount < JumpTimes)
                ApplyJump();

            if (ShortenJumpOnInputRelease && Input.IsActionJustReleased(JumpInputAction))
                ShortenJump();

            if (Actor.isGrounded) {
                if (Actor.MotionInput.InputDirection.IsZeroApprox())
                    FSM?.ChangeStateTo<Idle>();
                else
                    FSM?.ChangeStateTo<Walk>();
            }

            DetectFallAfterJumpFallTimePassed();
            DetectWall();

            AirMove(delta);

            Actor.MoveAndSlide();
        }

        public void ApplyJump() {
            JumpedPosition = Actor.Position;
            JumpCount += 1;

            Vector3 upDirection = Actor.UpDirection;
            var jumpVelocity = CalculateJumpVelocity(JumpHeight - (JumpCount * HeightReducedByJump), JumpPeakTime);

            if (upDirection.IsEqualApprox(Vector3.Down) || upDirection.IsEqualApprox(Vector3.Up))
                Actor.Velocity = Actor.Velocity with { Y = Mathf.Sign(upDirection.Y) * jumpVelocity };

            else if (upDirection.IsEqualApprox(Vector3.Right) || upDirection.IsEqualApprox(Vector3.Left)) {
                Actor.Velocity = Actor.Velocity with { X = Mathf.Sign(upDirection.X) * jumpVelocity };
            }
        }


        public float GetGravity() {
            Vector3 upDirectionOpposite = Actor.UpDirectionOpposite();

            if (upDirectionOpposite.IsEqualApprox(Vector3.Down))
                return Actor.Velocity.Y > 0 ? JumpGravity : FallGravity;
            else if (upDirectionOpposite.IsEqualApprox(Vector3.Up)) {
                return Actor.Velocity.Y < 0 ? JumpGravity : FallGravity;
            }
            else if (upDirectionOpposite.IsEqualApprox(Vector3.Right)) {
                return Actor.Velocity.X < 0 ? JumpGravity : FallGravity;
            }
            else if (upDirectionOpposite.IsEqualApprox(Vector3.Left)) {
                return Actor.Velocity.X > 0 ? JumpGravity : FallGravity;
            }
            else {
                return 0f;
            }
        }

        public void ShortenJump(float factor = 2f) {
            var newJumpVelocity = JumpVelocity / factor;

            if (Actor.Velocity.Y > newJumpVelocity)
                Actor.Velocity = Actor.Velocity with { Y = newJumpVelocity };
        }

        public void DetectFallAfterJumpFallTimePassed() {
            Vector3 upDirectionOpposite = Actor.UpDirectionOpposite();

            if ((upDirectionOpposite.IsEqualApprox(Vector3.Down) && Actor.Position.Y < JumpedPosition.Y) ||
               (upDirectionOpposite.IsEqualApprox(Vector3.Up) && Actor.Position.Y > JumpedPosition.Y) ||
               (upDirectionOpposite.IsEqualApprox(Vector3.Right) && Actor.Position.X > JumpedPosition.X) ||
               (upDirectionOpposite.IsEqualApprox(Vector3.Left) && Actor.Position.X < JumpedPosition.X)) {
                FSM?.ChangeStateTo<Fall>();
            }
        }

        #region Jump calculations
        private static float CalculateJumpGravity(float height, float peakTime) => (2f * height) / Mathf.Pow(peakTime, 2);

        private static float CalculateFallGravity(float height, float fallTime) => (2f * height) / Mathf.Pow(fallTime, 2);

        private static float CalculateJumpVelocity(float height, float peakTime) => CalculateJumpGravity(height, peakTime) * peakTime;

        private static float CalculateAirSpeed(float distance, float peakTime, float fallTime) => distance / (peakTime + fallTime);

        #endregion
    }
}
