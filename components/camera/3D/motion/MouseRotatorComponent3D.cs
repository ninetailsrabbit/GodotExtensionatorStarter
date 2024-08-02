using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/camera/3D/motion/3d_rotation_component.svg")]
    public partial class MouseRotatorComponent3D : Node3D {
        [Export] public float MouseSensitivity = 6f;
        [Export] public Node3D? Target { get; set; } = default!;
        [Export] public MouseButton MouseRotationButton = MouseButton.Left;
        [Export] public bool KeepPressedToRotate = true;
        [Export] public bool ResetRotationOnRelease = false;


        private Vector3 _originalRotation = Vector3.Zero;
        private Tween ResetRotationTween { get; set; } = default!;

        public override void _Input(InputEvent @event) {
            if (Target is not null) {

                if (@event is InputEventMouseMotion mouseMotion && MouseMovementDetected(@event)) {
                    var mouseInput = ((InputEventMouseMotion)mouseMotion.XformedBy(GetTree().Root.GetFinalTransform())).Relative;

                    Target.RotateX(mouseInput.Y * (MouseSensitivity / 1000f));
                    Target.RotateY(mouseInput.X * (MouseSensitivity / 1000f));
                }

                if (ResetRotationOnRelease && !Target.Rotation.IsEqualApprox(_originalRotation) && MouseReleaseDetected(@event)) {
                    ResetTargetRotation();
                }

            }
        }

        public override void _Ready() {
            Target ??= GetParent<Node3D>();

            ArgumentNullException.ThrowIfNull(Target);

            _originalRotation = Target.Rotation;
        }


        private bool MouseMovementDetected(InputEvent @event) {
            return !KeepPressedToRotate ||
                (KeepPressedToRotate &&
                ((MouseRotationButton.Equals(MouseButton.Left) && @event.IsMouseLefttButtonPressed()) ||
                 (MouseRotationButton.Equals(MouseButton.Right) && @event.IsMouseRightButtonPressed()))
                );
        }

        private bool MouseReleaseDetected(InputEvent @event) {
            return (MouseRotationButton.Equals(MouseButton.Left) && !@event.IsMouseLefttButtonPressed()) ||
                 (MouseRotationButton.Equals(MouseButton.Right) && !@event.IsMouseRightButtonPressed());

        }

        private void ResetTargetRotation() {
            if ((ResetRotationTween is null || (ResetRotationTween is not null && !ResetRotationTween.IsRunning()))) {
                ResetRotationTween = CreateTween();
                ResetRotationTween.TweenProperty(Target, Node3D.PropertyName.Rotation.ToString(), _originalRotation, 0.5f).From(Target.Rotation)
                    .SetTrans(Tween.TransitionType.Quad).SetEase(Tween.EaseType.In);
            }
        }

    }
}
