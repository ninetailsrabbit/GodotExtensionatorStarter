using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    public partial class GameSettingsUI : Control {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;
        public MuteAudioBusesCheckButton MuteAudioBusesCheckButton { get; set; } = default!;

        public Dictionary<string, AudioSlider> AudioBusesSliders = [];

        public override void _ExitTree() {
            SettingsFileHandlerAutoload.LoadedSettings -= OnLoadedSettings;
        }

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            SettingsFileHandlerAutoload.LoadedSettings += OnLoadedSettings;
        }

        public override void _Ready() {
            MuteAudioBusesCheckButton = GetNode<MuteAudioBusesCheckButton>($"%{nameof(MuteAudioBusesCheckButton)}");

            foreach (var audioSlider in this.GetAllChildren<AudioSlider>()) {
                AudioBusesSliders.Add(audioSlider.AudioBus, audioSlider);
            }

        }

        private void OnLoadedSettings() {
            foreach (var entry in AudioBusesSliders) {
                entry.Value.Value = AudioManager.GetActualVolumeDbFromBus(entry.Key);
            }
        }
    }

}