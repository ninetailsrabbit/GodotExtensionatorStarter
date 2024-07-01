using Extensionator;
using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/mechanics/icons/head_effect.svg")]
    public partial class SwingHead : Node3D {
        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public Node3D Head { get; set; } = null!;
        [Export(PropertyHint.Range, "0, 360f, 0.01f")] public float SwingRotationDegrees = 1.5f;
        [Export] public float SwingLerpFactor = 5f;
        [Export] public float SwingLerpRecoveryFactor = 7.5f;

        private Vector3 _originalHeadRotation = Vector3.Zero;

        public override void _Ready() {
            _originalHeadRotation = Head.Rotation;
        }

        public override void _PhysicsProcess(double delta) {
            if (Actor.isGrounded) {
                var direction = Actor.MotionInput.InputDirection;

                if (direction.In(Vector2.Right, Vector2.Left)) {
                    Head.Rotation = Head.Rotation with {
                        Z = Mathf.LerpAngle(Head.Rotation.Z, -Mathf.Sign(direction.X) * Mathf.DegToRad(SwingRotationDegrees), SwingLerpFactor * (float)delta)
                    };
                }
                else {
                    Head.Rotation = Head.Rotation with {
                        Z = Mathf.LerpAngle(Head.Rotation.Z, _originalHeadRotation.Z, SwingLerpRecoveryFactor * (float)delta)
                    };
                }
            }
        }

    }
}
