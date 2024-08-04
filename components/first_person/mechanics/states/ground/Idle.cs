using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public sealed partial class Idle : GroundState {

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            Decelerate(delta);

            GD.Print(Actor.MotionInput.InputDirection);
            if (Actor.MotionInput.InputDirection.IsNotZeroApprox())
                FSM?.ChangeStateTo<Walk>();

            DetectJump();
            DetectCrouch();

            Actor.MoveAndSlide();
        }

        private void Decelerate(double delta) {
            if (Friction > 0 && Actor.Velocity.IsNotZeroApprox())
                Actor.Velocity = Actor.Velocity.Lerp(Vector3.Zero, Mathf.Clamp(Friction * (float)delta, 0, 1f));
            else
                Actor.Velocity = Vector3.Zero;
        }
    }
}
