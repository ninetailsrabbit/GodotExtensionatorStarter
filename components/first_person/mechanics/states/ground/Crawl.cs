using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class Crawl : GroundState {

        public override void Enter() {
            if (Actor.AnimationPlayer is not null)
                Actor.AnimationPlayer?.Play(CrawlAnimationName);
        }

        public override void Exit(MachineState nextState) {
            ResetCrawlAnimation();
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            if (!Input.IsActionPressed(CrawlInputAction) && !Actor.CeilShapeCast.IsColliding()) {
                FSM?.ChangeStateTo<Crouch>();
            }

            Accelerate(delta);

            Actor.MoveAndSlide();
        }

        private async void ResetCrawlAnimation() {
            if (Actor.AnimationPlayer is not null) {
                Actor.AnimationPlayer.PlayBackwards(CrawlAnimationName);
                await Actor.AnimationPlayer.WaitToFinished();
            }
        }
    }
}
