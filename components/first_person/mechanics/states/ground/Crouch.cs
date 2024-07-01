using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class Crouch : GroundState {

        public override void Enter() {
            CrouchAnimation();
        }

        public override void Exit(MachineState nextState) {
            ResetCrouchAnimation(nextState);
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            if (!Input.IsActionPressed(CrouchInputAction) && !Actor.CeilShapeCast.IsColliding()) {
                if (Actor.Velocity.IsZeroApprox())
                    FSM?.ChangeStateTo<Idle>();
                else
                    FSM?.ChangeStateTo<Walk>();
            }

            Accelerate(delta);
            DetectJump();
            DetectCrawl();

            Actor.MoveAndSlide();
        }

        #region Animations
        private async void CrouchAnimation() {
            var previousState = FSM?.LastState();

            if (previousState is not Slide && previousState is not Crawl) {
                Actor.AnimationPlayer?.Play("crouch");
                await Actor.AnimationPlayer.WaitToFinished();
            }
        }

        private async void ResetCrouchAnimation(MachineState nextState) {
            if (Actor.AnimationPlayer is not null && nextState is not Crawl) {
                Actor.AnimationPlayer.PlayBackwards("crouch");
                await Actor.AnimationPlayer.WaitToFinished();
            }
        }
        #endregion
    }
}
