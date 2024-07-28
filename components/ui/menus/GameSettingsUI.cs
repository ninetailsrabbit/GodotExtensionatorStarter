using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    public partial class GameSettingsUI : Control {

        public GameGlobals GameGlobals { get; set; } = null!;
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;
        public MuteAudioBusesCheckButton MuteAudioBusesCheckButton { get; set; } = default!;

        public Dictionary<string, AudioSlider> AudioBusesSliders = [];

        public override void _ExitTree() {
            SettingsFileHandlerAutoload.LoadedSettings -= OnLoadedSettings;
        }

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            SettingsFileHandlerAutoload.LoadedSettings += OnLoadedSettings;
        }

        public override void _Ready() {
            PrepareTabBars();
            MuteAudioBusesCheckButton = GetNode<MuteAudioBusesCheckButton>($"%{nameof(MuteAudioBusesCheckButton)}");

            foreach (var audioSlider in this.GetAllChildren<AudioSlider>()) {
                AudioBusesSliders.Add(audioSlider.AudioBus, audioSlider);
            }

        }

        private void PrepareTabBars() {
            var AudioTabBar = GetNode<TabBar>("%Audio");
            var ScreenTabBar = GetNode<TabBar>("%Screen");
            var GraphicsTabBar = GetNode<TabBar>("%Graphics");
            var GeneralTabBar = GetNode<TabBar>("%General");

            AudioTabBar.Name = Tr("AUDIO_TAB");
            ScreenTabBar.Name = Tr("SCREEN_TAB");
            GraphicsTabBar.Name = Tr("GRAPHICS_TAB");
            GeneralTabBar.Name = Tr("GENERAL_TAB");
        }

        private void OnLoadedSettings() {
            foreach (var entry in AudioBusesSliders) {
                entry.Value.Value = AudioManager.GetActualVolumeDbFromBus(entry.Key);
            }
        }
    }

}