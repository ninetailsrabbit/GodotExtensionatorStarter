using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    [Icon("res://components/ui/menus/game_settings.svg")]
    public partial class GameSettingsUI : Control, ITranslatable {

        public GameGlobals GameGlobals { get; set; } = null!;
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;
        public MuteAudioBusesCheckButton MuteAudioBusesCheckButton { get; set; } = default!;

        public Dictionary<string, AudioSlider> AudioBusesSliders = [];

        public TabBar AudioTabBar { get; set; } = default!;
        public TabBar ScreenTabBar { get; set; } = default!;
        public TabBar GraphicsTabBar { get; set; } = default!;
        public TabBar GeneralTabBar { get; set; } = default!;
        public TabBar ControlsTabBar { get; set; } = default!;
        public Button BackButton { get; set; } = default!;

        public override void _ExitTree() {
            SettingsFileHandlerAutoload.LoadedSettings -= OnLoadedSettings;

            BackButton.Pressed -= OnBackButtonPressed;

        }

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            AudioTabBar = GetNode<TabBar>("%Audio");
            ScreenTabBar = GetNode<TabBar>("%Screen");
            GraphicsTabBar = GetNode<TabBar>("%Graphics");
            GeneralTabBar = GetNode<TabBar>("%General");
            ControlsTabBar = GetNode<TabBar>("%Controls");

            BackButton = GetNode<Button>($"%{nameof(BackButton)}");
            BackButton.Pressed += OnBackButtonPressed;

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
            AudioTabBar.Name = Tr(Localization.AudioTabTranslationKey);
            ScreenTabBar.Name = Tr(Localization.ScreenTabTranslationKey);
            GraphicsTabBar.Name = Tr(Localization.GraphicsTabTranslationKey);
            GeneralTabBar.Name = Tr(Localization.GeneralTabTranslationKeyTr);
            ControlsTabBar.Name = Tr(Localization.GeneralTabTranslationKeyTr);
        }

        private void OnLoadedSettings() {
            foreach (var entry in AudioBusesSliders) {
                entry.Value.Value = AudioManager.GetActualVolumeDbFromBus(entry.Key);
            }
        }

        private void OnBackButtonPressed() {
            // Only hide when this scene it's render within another

            if (Owner is not null) {
                Hide();
            }
        }
        public void OnLocaleChanged() {
            if (IsNodeReady())
                PrepareTabBars();
        }
    }

}