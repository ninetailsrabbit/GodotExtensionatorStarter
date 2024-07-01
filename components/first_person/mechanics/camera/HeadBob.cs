using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/mechanics/icons/head_effect.svg")]
    public partial class HeadBob : Node3D {
        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public Node3D Head { get; set; } = null!;
        [Export] public float Speed = 10f;
        [Export] public float Intensity = 0.02f;
        [Export] public float LerpSpeed = 5f;

        private float _headBobIndex = 0f;

        private Vector3 _headBobVector = Vector3.Zero;

        private Vector3 _originalHeadPosition = Vector3.Zero;

        public override void _Ready() {
            _originalHeadPosition = Head.Position;
        }

        public override void _PhysicsProcess(double delta) {
            _headBobIndex += Speed * (float)delta;

            if (Actor.isGrounded && Actor.MotionInput.InputDirection.IsNotZeroApprox()) {
                _headBobVector.X = Mathf.Sin(_headBobIndex / 2);
                _headBobVector.Y = Mathf.Sin(_headBobIndex);

                Head.Position = Head.Position with {
                    X = Mathf.Lerp(Head.Position.X, _headBobVector.X * Intensity, (float)delta * LerpSpeed),
                    Y = Mathf.Lerp(Head.Position.Y, _headBobVector.Y * (Intensity * 2), (float)delta * LerpSpeed),
                };
            }
            else {
                Head.Position = Head.Position with {
                    X = Mathf.Lerp(Head.Position.X, _originalHeadPosition.X, (float)delta * LerpSpeed),
                    Y = Mathf.Lerp(Head.Position.Y, _originalHeadPosition.Y, (float)delta * LerpSpeed),
                };
            }
        }

    }
}
