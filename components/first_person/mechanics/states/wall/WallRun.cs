using Godot;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class WallRun : Wall {

        public Vector3 WallRunDirection = Vector3.Zero;

        public override void Enter() {
            Actor.Velocity = Actor.Velocity with { Y = 0 };

            CalculateWallRunDirection();

            if (CurrentWallNormal.IsEqualApprox(Vector3.Right)) {
                CurrentWallSide = WallSide.Right;
            }

            if (CurrentWallNormal.IsEqualApprox(Vector3.Left)) {
                CurrentWallSide = WallSide.Left;
            }
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);


            if (!Actor.WallRayCastDetector3D.AnySideWallDetected()) {
                FSM?.ChangeStateTo<Fall>();
            }

            Actor.CameraMovement.PivotPoint.Rotation = Actor.CameraMovement.PivotPoint.Rotation with {
                Z = Mathf.LerpAngle(Actor.CameraMovement.PivotPoint.Rotation.Z, (CurrentWallSide.Equals(WallSide.Left) ? 1 : -1) * Mathf.DegToRad(CameraRotationAngle), (float)delta * CameraLerpRotationSpeed)
            };

            Accelerate(delta);

            DetectJump();

            Actor.MoveAndSlide();
        }

        public void Accelerate(double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            var currentVelocity = WallSpeed * WallRunDirection;

            if (WallAcceleration > 0) {
                var velocity = Actor.Velocity.Lerp(currentVelocity, Mathf.Clamp(WallAcceleration * (float)delta, 0f, 1.0f));
                Actor.Velocity = Actor.Velocity with { X = velocity.X, Z = velocity.Z };
            }
            else {
                Actor.Velocity = Actor.Velocity with { X = currentVelocity.X, Z = currentVelocity.Z };
            }
        }


        private void CalculateWallRunDirection() {
            WallRunDirection = CurrentWallNormal.Cross(Vector3.Up);

            if ((-Actor.GlobalTransform.Basis.Z - WallRunDirection).Length() > (-Actor.GlobalTransform.Basis.Z - -WallRunDirection).Length()) {
                WallRunDirection = -WallRunDirection;
            }
        }
    }
}