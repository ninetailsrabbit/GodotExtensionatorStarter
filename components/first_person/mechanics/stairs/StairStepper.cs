using Godot;
using GodotExtensionator;
using System;


namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/mechanics/icons/stair_stepper_3d.svg")]
    public partial class StairStepper : Node3D {

        const float CROUCH_TRANSLATE = 0.7f;
        const float CROUCH_JUMP_ADD = 0.9f;

        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public Node3D CameraPivot { get; set; } = null!;
        [Export] public float MaxStepHeight = 0.5f;
        public RayCast3D StairsAheadRayCast3D { get; set; } = default!;
        public RayCast3D StairsBelowRayCast3D { get; set; } = default!;

        private float _walkSpeed = 0f;
        private bool _snappedToStairsLastFrame = false;
        private Vector3? _savedCameraPivotPositionForSmoothing = Vector3.Zero;

        public override void _EnterTree() {
            Actor ??= GetParent<FirstPersonController>();
            StairsAheadRayCast3D = GetNode<RayCast3D>($"%{nameof(StairsAheadRayCast3D)}");
            StairsBelowRayCast3D = GetNode<RayCast3D>($"%{nameof(StairsBelowRayCast3D)}");

            ArgumentNullException.ThrowIfNull(Actor);
            ArgumentNullException.ThrowIfNull(StairsAheadRayCast3D);
            ArgumentNullException.ThrowIfNull(StairsBelowRayCast3D);

            if (Actor.FSM.GetStateByName(nameof(Walk)) is Walk walkState)
                _walkSpeed = walkState.Speed;
        }


        public bool SnapUpToStairsCheck(double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            if (!Actor.isGrounded && !_snappedToStairsLastFrame)
                return false;

            if (Actor.Velocity.Y > 0 || (Actor.Velocity * new Vector3(1, 0, 1)).Length() == 0)
                return false;

            var expectedMoveMotion = Actor.Velocity * new Vector3(1, 0, 1) * (float)delta;
            var stepPositionWithClearance = Actor.GlobalTransform.Translated(expectedMoveMotion + new Vector3(0, MaxStepHeight * 2, 0));

            var downCheckResult = new KinematicCollision3D();

            if (Actor.TestMove(stepPositionWithClearance, new Vector3(0, -MaxStepHeight * 2, 0), downCheckResult) &&
                (downCheckResult.GetCollider() is StaticBody3D || downCheckResult.GetCollider() is CsgShape3D || downCheckResult.GetCollider() is MeshInstance3D)
            ) {
                var stepHeight = ((stepPositionWithClearance.Origin + downCheckResult.GetTravel()) - Actor.GlobalPosition).Y;

                if (stepHeight > MaxStepHeight || stepHeight <= 0.01f || (downCheckResult.GetPosition() - Actor.GlobalPosition).Y > MaxStepHeight)
                    return false;

                StairsAheadRayCast3D.GlobalPosition = downCheckResult.GetPosition() + Actor.UpDirection * MaxStepHeight + expectedMoveMotion.Normalized() * 0.1f;
                StairsAheadRayCast3D.ForceRaycastUpdate();

                if (StairsAheadRayCast3D.IsColliding() && !IsSurfaceTooSteep(StairsAheadRayCast3D.GetCollisionNormal())) {
                    SaveCameraPivotPositionForSmoothing();
                    Actor.GlobalPosition = stepPositionWithClearance.Origin + downCheckResult.GetTravel();
                    Actor.ApplyFloorSnap();
                    _snappedToStairsLastFrame = true;

                    return true;
                }
            }

            return false;
        }

        public void SnapDownToStairsCheck() {
            var didSnap = false;

            StairsBelowRayCast3D.ForceRaycastUpdate();
            var floorBelow = StairsBelowRayCast3D.IsColliding() && !IsSurfaceTooSteep(StairsBelowRayCast3D.GetCollisionNormal());

            if (Actor.Velocity.Y < 0 && floorBelow) {
                var bodyTestResult = new KinematicCollision3D();

                if (Actor.TestMove(Actor.GlobalTransform, Actor.UpDirectionOpposite() * MaxStepHeight, bodyTestResult)) {
                    SaveCameraPivotPositionForSmoothing();
                    Actor.Position = Actor.Position with { Y = Actor.Position.Y + bodyTestResult.GetTravel().Y };
                    Actor.ApplyFloorSnap();
                    didSnap = true;
                }
            }

            _snappedToStairsLastFrame = didSnap;
        }

        public void SlideCameraPivotSmoothToOrigin(double delta) {
            if (_savedCameraPivotPositionForSmoothing is Vector3 savedPosition) {
                CameraPivot.GlobalPosition = CameraPivot.GlobalPosition with { Y = savedPosition.Y };
                CameraPivot.Position = CameraPivot.Position with { Y = Mathf.Clamp(CameraPivot.Position.Y, -CROUCH_TRANSLATE, CROUCH_TRANSLATE) };

                var moveAmount = Mathf.Max(Actor.Velocity.Length() * delta, _walkSpeed / 2 * delta);

                CameraPivot.Position = CameraPivot.Position.MoveToward(new Vector3(CameraPivot.Position.X, 0f, CameraPivot.Position.Z), (float)moveAmount);

                _savedCameraPivotPositionForSmoothing = CameraPivot.GlobalPosition;

                if (CameraPivot.Position.Y == 0)
                    _savedCameraPivotPositionForSmoothing = null;
            }
        }

        private bool IsSurfaceTooSteep(Vector3 normal) => normal.AngleTo(Vector3.Up) > Actor.FloorMaxAngle;

        private void SaveCameraPivotPositionForSmoothing() {
            _savedCameraPivotPositionForSmoothing ??= CameraPivot.GlobalPosition;
        }
    }


}