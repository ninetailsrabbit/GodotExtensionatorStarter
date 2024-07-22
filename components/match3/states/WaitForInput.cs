using Godot;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class WaitForInput : BoardState {

        public override void Enter() {
            BoardUI?.Unlock();
        }

        public override void Exit(MachineState _) {
            BoardUI?.Lock();
        }
    }
}
