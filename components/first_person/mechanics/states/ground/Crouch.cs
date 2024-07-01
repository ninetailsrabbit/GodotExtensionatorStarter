using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class Crouch : GroundState {

        public override void Enter() {
            if (FSM?.LastState() is not Slide)
                Actor.AnimationPlayer?.Play("crouch");
        }

        public override async void Exit(MachineState nextState) {
            if (Actor.AnimationPlayer is not null && nextState is not Crawl) {
                Actor.AnimationPlayer.PlayBackwards("crouch");
                await Actor.AnimationPlayer.WaitToFinished();
            }
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            if (!Input.IsActionPressed(CrouchInputAction) && !Actor.CeilShapeCast.IsColliding()) {
                if (Actor.Velocity.IsZeroApprox())
                    FSM?.ChangeStateTo<Idle>();
                else
                    FSM?.ChangeStateTo<Walk>();
            }

            DetectJump();
            Accelerate(delta);

            Actor.MoveAndSlide();
        }
    }
}
