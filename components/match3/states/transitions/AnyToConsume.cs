using Match3Maker;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    public partial class AnyToConsumeTransition : Transition {

        public override bool ShouldTransition() {
            List<Sequence>? initialSequences = Parameters?["matches"] as List<Sequence>;

            if (initialSequences is not null && initialSequences.Count > 0 && ToState is Consume consumeState) {
                consumeState.Sequences = initialSequences;

                return true;
            }

            return false;
        }
        public override void OnTransition() { }
    }

}
