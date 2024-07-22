using Godot;
using Match3Maker;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Consume : BoardState {

        public List<Sequence> Sequences = [];

        public override void Enter() {
            ConsumeSequences();
        }

        private async void ConsumeSequences() {
            await BoardUI.CurrentSequenceConsumer.ConsumeSequences(Sequences);
            FSM?.ChangeStateTo<Fill>();
        }

        public override void Exit(MachineState _) {
            Sequences = [];
        }
    }
}
