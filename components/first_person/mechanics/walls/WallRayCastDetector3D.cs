﻿using Godot;

namespace FirstPersonTemplate {

    [GlobalClass, Icon("res://components/first_person/mechanics/icons/wall_detector.svg")]
    public partial class WallRayCastDetector3D : Node3D {
        public enum WallSides {
            Front,
            Right,
            Left,
            Back
        }

        [Export] public float SeparationFromOrigin = 0.15f;
        [Export] public float TopDetectorDistanceFromOrigin = 0.45f;
        [Export] public float BottomDetectorDistanceFromOrigin = 0.45f;
        [Export] public float FromDetectorDistanceFromOrigin = 0.45f;

        [Export(PropertyHint.Range, "0.1f, 10.0f, 0.01f")] public float RightDistanceDetector = 0.5f;
        [Export(PropertyHint.Range, "0.1f, 10.0f, 0.01f")] public float LeftDistanceDetector = 0.5f;
        [Export(PropertyHint.Range, "0.1f, 10.0f, 0.01f")] public float FrontDistanceDetector = 0.5f;

        public RayCast3D TopRightRayCast { get; set; } = default!;
        public RayCast3D BottomRightRayCast { get; set; } = default!;
        public RayCast3D TopLeftRayCast { get; set; } = default!;
        public RayCast3D BottomLeftRayCast { get; set; } = default!;
        public RayCast3D TopFrontRayCast { get; set; } = default!;
        public RayCast3D BottomFrontRayCast { get; set; } = default!;

        public override void _Ready() {
            CreateWallRayCastDetectors();
        }

        public bool IsFrontWallDetected() => TopFrontRayCast.IsColliding() && BottomFrontRayCast.IsColliding();
        public bool IsLeftWallDetected() => TopLeftRayCast.IsColliding() && BottomLeftRayCast.IsColliding();
        public bool IsRightWallDetected() => TopRightRayCast.IsColliding() && BottomRightRayCast.IsColliding();
        public bool AnyWallSideDetected() => IsFrontWallDetected() || IsLeftWallDetected() || IsRightWallDetected();
        public bool AnySideWallDetected() => !IsFrontWallDetected() && (IsLeftWallDetected() || IsRightWallDetected());

        public Vector3 GetLeftWallNormal() {
            if (IsLeftWallDetected()) {
                return BottomLeftRayCast.GetCollisionNormal();
            }

            return Vector3.Zero;
        }

        public Vector3 GetRightWallNormal() {
            if (IsRightWallDetected()) {
                return BottomRightRayCast.GetCollisionNormal();
            }

            return Vector3.Zero;
        }

        public Vector3 GetFrontWallNormal() {
            if (IsFrontWallDetected()) {
                return BottomFrontRayCast.GetCollisionNormal();
            }

            return Vector3.Zero;
        }


        private void CreateWallRayCastDetectors() {
            TopRightRayCast = new RayCast3D { TargetPosition = Vector3.Right * RightDistanceDetector };
            BottomRightRayCast = new RayCast3D { TargetPosition = Vector3.Right * RightDistanceDetector };

            TopLeftRayCast = new RayCast3D { TargetPosition = Vector3.Left * LeftDistanceDetector };
            BottomLeftRayCast = new RayCast3D { TargetPosition = Vector3.Left * LeftDistanceDetector };

            TopFrontRayCast = new RayCast3D { TargetPosition = Vector3.Forward * FrontDistanceDetector };
            BottomFrontRayCast = new RayCast3D { TargetPosition = Vector3.Forward * FrontDistanceDetector };

            AddChild(TopRightRayCast);
            AddChild(BottomRightRayCast);
            AddChild(TopLeftRayCast);
            AddChild(BottomLeftRayCast);
            AddChild(TopFrontRayCast);
            AddChild(BottomFrontRayCast);

            TopRightRayCast.Position = new Vector3(
                Vector3.Right.X * SeparationFromOrigin,
                Vector3.Up.Y * TopDetectorDistanceFromOrigin,
                TopRightRayCast.Position.Z
            );

            BottomRightRayCast.Position = new Vector3(
                Vector3.Right.X * SeparationFromOrigin,
                Vector3.Down.Y * TopDetectorDistanceFromOrigin,
                BottomRightRayCast.Position.Z
            );

            TopLeftRayCast.Position = new Vector3(
                Vector3.Left.X * SeparationFromOrigin,
                Vector3.Up.Y * TopDetectorDistanceFromOrigin,
                TopLeftRayCast.Position.Z
            );

            BottomLeftRayCast.Position = new Vector3(
                Vector3.Left.X * SeparationFromOrigin,
                Vector3.Down.Y * TopDetectorDistanceFromOrigin,
                BottomLeftRayCast.Position.Z
            );

            TopFrontRayCast.Position = new Vector3(
                TopFrontRayCast.Position.X,
                Vector3.Up.Y * TopDetectorDistanceFromOrigin,
                Vector3.Forward.Z * SeparationFromOrigin
          );

            BottomFrontRayCast.Position = new Vector3(
                BottomFrontRayCast.Position.X,
                Vector3.Down.Y * TopDetectorDistanceFromOrigin,
                Vector3.Forward.Z * SeparationFromOrigin
            );

        }
    }
}
