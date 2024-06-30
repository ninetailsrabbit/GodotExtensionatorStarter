using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public sealed partial class Idle : GroundState {

        public override void Enter() {
            Actor.Velocity = Vector3.Zero;
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            //if (Actor.MotionInput.InputDirection.IsNotZeroApprox())
            //    FSM.ChangeStateTo<Walk>();

            //DetectJump();
            //DetectCrouch();

            Actor.MoveAndSlide();
        }
    }
}
