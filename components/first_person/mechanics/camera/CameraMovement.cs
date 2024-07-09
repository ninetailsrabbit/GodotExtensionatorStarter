using Extensionator;
using Godot;
using GodotExtensionator;
using GodotExtensionatorStarter;
using System;

namespace FirstPersonTemplate {

    [GlobalClass, Icon("res://components/first_person/mechanics/icons/first_person_camera_rotator.svg")]
    public partial class CameraMovement : Node3D {

        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public Camera3D Camera { get; set; } = default!;
        [Export] public Node3D PivotPoint { get; set; } = default!;
        [Export(PropertyHint.Range, "0, 100, 0.5")] public float CameraSensitivity { get; set; } = 45f;
        [Export(PropertyHint.Range, "0.1f, 20f, 0.1f")] public float MouseSensitivity { get; set; } = 3f;
        [Export(PropertyHint.Range, "0, 360f, 0.1f")] public float CameraVerticalRotationLimit { get; set; } = 89f;


        public override void _EnterTree() {
            Actor ??= GetParent<FirstPersonController>();
            ArgumentNullException.ThrowIfNull(nameof(Actor));

            Camera ??= Actor.FirstNodeOfType<Camera3D>();
            ArgumentNullException.ThrowIfNull(nameof(Camera));

            ArgumentNullException.ThrowIfNull(nameof(PivotPoint));
        }

        public override void _UnhandledInput(InputEvent @event) {
            if (Input.MouseMode.In(Input.MouseModeEnum.Captured) && @event is InputEventMouseMotion mouseMotion) {
                Input.UseAccumulatedInput = false;
                RotateCamera(((InputEventMouseMotion)mouseMotion.XformedBy(GetTree().Root.GetFinalTransform())));
            }
            else {
                Input.UseAccumulatedInput = true;
            }
        }

        public void RotateCamera(InputEventMouseMotion mouseMotion) {
            var mouseSensitivity = MouseSensitivity / 1000f;

            var twistInput = mouseMotion.Relative.X * mouseSensitivity;
            var pitchInput = mouseMotion.Relative.Y * mouseSensitivity;
            var cameraRotationLimit = Mathf.DegToRad(CameraVerticalRotationLimit);

            var actorRotationY = Actor.Rotation.Y - twistInput;
            var actorRotationX = PivotPoint.Rotation.X - pitchInput;
            actorRotationX = Mathf.Clamp(actorRotationX, -cameraRotationLimit, cameraRotationLimit);

            Actor.Rotation = Actor.Rotation with { Y = Mathf.LerpAngle(Actor.Rotation.Y, actorRotationY, CameraSensitivity / 100) };
            PivotPoint.Rotation = PivotPoint.Rotation with { X = Mathf.LerpAngle(PivotPoint.Rotation.X, actorRotationX, CameraSensitivity / 100) };
            PivotPoint.Orthonormalize();
        }
    }

}