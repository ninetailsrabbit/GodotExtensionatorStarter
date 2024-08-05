using Extensionator;
using Godot;
using GodotExtensionator;
using System;

namespace FirstPersonTemplate {

    [GlobalClass, Icon("res://components/first_person/mechanics/icons/first_person_camera_rotator.svg")]
    public partial class CameraMovement : Node3D {

        [Export] public Node3D Actor { get; set; } = null!;
        [Export] public Camera3D Camera { get; set; } = default!;
        [Export] public Node3D PivotPoint { get; set; } = default!;
        [Export(PropertyHint.Range, "0.0, 100.0, 0.5")] public float CameraSensitivity { get; set; } = 45f;
        [Export(PropertyHint.Range, "0.1f, 20f, 0.1f")] public float MouseSensitivity { get; set; } = 3f;
        // 0 means 'no limit'
        [Export(PropertyHint.Range, "0, 360f, 0.1f")] public float CameraVerticalRotationLimit { get; set; } = 89f;
        // 0 means 'no limit'
        [Export(PropertyHint.Range, "0, 360f, 0.1f")] public float CameraHorizontalRotationLimit { get; set; } = 0f;


        public bool Locked {
            get => _locked;
            set {
                _locked = value;
                SetProcessInput(_locked);
            }
        }

        public float CurrentVerticalRotationLimit = 0f;
        public float CurrentHorizontalRotationLimit = 0f;

        private bool _locked = false;

        public override void _EnterTree() {
            Actor ??= GetParent<Node3D>();
            ArgumentNullException.ThrowIfNull(nameof(Actor));

            Camera ??= Actor.FirstNodeOfType<Camera3D>();
            ArgumentNullException.ThrowIfNull(nameof(Camera));
            ArgumentNullException.ThrowIfNull(nameof(PivotPoint));

            CurrentVerticalRotationLimit = CameraVerticalRotationLimit;
            CurrentHorizontalRotationLimit = CameraHorizontalRotationLimit;
        }

        public override void _Input(InputEvent @event) {
            if (@event is InputEventMouseMotion mouseMotion) {

                if (InputExtension.IsMouseCaptured()) {
                    Input.UseAccumulatedInput = false;
                    RotateCamera(((InputEventMouseMotion)mouseMotion.XformedBy(GetTree().Root.GetFinalTransform())));
                }
                else {
                    Input.UseAccumulatedInput = true;
                }
            }
        }

        public void RotateCamera(InputEventMouseMotion mouseMotion) {
            var mouseSensitivity = MouseSensitivity / 1000f;

            var twistInput = mouseMotion.Relative.X * mouseSensitivity;
            var pitchInput = mouseMotion.Relative.Y * mouseSensitivity;
            var cameraVerticalRotationLimit = Mathf.DegToRad(CameraVerticalRotationLimit);
            var cameraHorizontalRotationLimit = Mathf.DegToRad(CameraHorizontalRotationLimit);

            var actorRotationY = CurrentHorizontalRotationLimit.IsZero() ? Actor.Rotation.Y - twistInput : Mathf.Clamp(Actor.Rotation.Y - twistInput, -cameraHorizontalRotationLimit, cameraHorizontalRotationLimit);
            var actorRotationX = PivotPoint.Rotation.X - pitchInput;
            actorRotationX = CurrentVerticalRotationLimit.IsZero() ? actorRotationX : Mathf.Clamp(actorRotationX, -cameraVerticalRotationLimit, cameraVerticalRotationLimit);

            Actor.Rotation = Actor.Rotation with { Y = Mathf.LerpAngle(Actor.Rotation.Y, actorRotationY, CameraSensitivity / 100) };
            PivotPoint.Rotation = PivotPoint.Rotation with { X = Mathf.LerpAngle(PivotPoint.Rotation.X, actorRotationX, CameraSensitivity / 100) };
            PivotPoint.Orthonormalize();
        }

        public void Lock() {
            Locked = true;
        }

        public void Unlock() {
            Locked = false;
        }

        public void ChangeCameraHorizontalRotationLimit(float newRotationLimit) {
            CurrentHorizontalRotationLimit = newRotationLimit;
        }

        public void ChangeCameraVerticalRotationLimit(float newRotationLimit) {
            CameraVerticalRotationLimit = newRotationLimit;
        }

        public void ReturnToOriginalHorizontalRotation() {
            CurrentHorizontalRotationLimit = CameraHorizontalRotationLimit;
        }

        public void ReturnToOriginalVerticalRotation() {
            CurrentVerticalRotationLimit = CameraVerticalRotationLimit;
        }

        public void ReturnToOriginalLimitRotation() {
            ReturnToOriginalHorizontalRotation();
            ReturnToOriginalVerticalRotation();
        }
    }

}