using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class MuteAudioBusesCheckButton : CheckButton {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            Toggled += OnMuteCheckButtonPressed;
        }

        public override void _Ready() {
            ButtonPressed = AudioManager.AllBusesAreMuted();
        }

        private void OnMuteCheckButtonPressed(bool pressed) {
            if (pressed) {
                AudioManager.MuteAllBuses();
                SettingsFileHandlerAutoload.UpdateAudioSection("muted", true);
                SettingsFileHandlerAutoload.SaveSettings();
            }
            else {
                AudioManager.UnmuteAllBuses();
                SettingsFileHandlerAutoload.UpdateAudioSection("muted", false);
                SettingsFileHandlerAutoload.SaveSettings();
            }
        }
    }
}
