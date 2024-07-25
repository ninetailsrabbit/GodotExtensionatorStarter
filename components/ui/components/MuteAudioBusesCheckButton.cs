using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class MuteAudioBusesCheckButton : CheckButton {
        public override void _EnterTree() {
            Toggled += OnMuteCheckButtonPressed;
        }

        public override void _Ready() {
            ButtonPressed = AudioManager.AllBusesAreMuted();
        }

        private void OnMuteCheckButtonPressed(bool pressed) {
            if (pressed)
                AudioManager.MuteAllBuses();
            else
                AudioManager.UnmuteAllBuses();
        }
    }
}
