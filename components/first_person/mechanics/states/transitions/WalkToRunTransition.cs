namespace GodotExtensionatorStarter {

    public partial class WalkToRunTransition : Transition {
        public override bool ShouldTransition() {
            if (FromState is Walk walk && ToState is Run _)
                return walk.Actor.Run && walk.CatchingBreathTimer.IsStopped();

            return false;
        }
        public override void OnTransition() { }
    }
}
