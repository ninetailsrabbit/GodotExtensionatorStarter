using Godot;
using Godot.Collections;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class GraphicQualitySettings : VBoxContainer, ITranslatable {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<GameSettingsResource.QualityPresets, Button> QualityPresetButtons = [];

        public Dictionary<GameSettingsResource.QualityPresets, string> Translations = [];
        private ButtonGroup QualityPresetButtonGroup { get; } = new();


        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();

            Translations = new() {
                { GameSettingsResource.QualityPresets.Low, Localization.QualityLowTranslationKey},
                { GameSettingsResource.QualityPresets.Medium, Localization.QualityMediumTranslationKey},
                { GameSettingsResource.QualityPresets.High, Localization.QualityHighTranslationKey},
                { GameSettingsResource.QualityPresets.Ultra, Localization.QualityUltraTranslationKey},
            };

            AddChild(new Label() { Name = "GraphicsQualityLabel", Text = Tr(Localization.GraphicsQualityTranslationKey) });
        }

        public override void _Ready() {
            AnchorsPreset = AnchorsPreset = (int)LayoutPreset.FullRect;
            AddThemeConstantOverride("separation", 15);

            CreateGraphicQualityPresetButtons();

        }

        private void CreateGraphicQualityPresetButtons() {
            HBoxContainer hboxContainer = new();
            AddChild(hboxContainer);
            hboxContainer.AnchorsPreset = AnchorsPreset = (int)LayoutPreset.TopWide;
            hboxContainer.SizeFlagsHorizontal = SizeFlags.Fill;

            QualityPresetButtonGroup.Pressed += OnQualityPresetButtonPressed;

            foreach (var entry in SettingsFileHandlerAutoload.DefaultGameSettings.GraphicQualityPresets) {

                var button = new Button {
                    Text = entry.Key.ToString(),
                    Name = ((int)entry.Key).ToString(),
                    ButtonGroup = QualityPresetButtonGroup,
                    ToggleMode = true,
                    SizeFlagsHorizontal = SizeFlags.ExpandFill
                };

                QualityPresetButtons.Add(entry.Key, button);

                hboxContainer.AddChild(button);

                if (entry.Key.Equals((GameSettingsResource.QualityPresets)(int)SettingsFileHandlerAutoload.GetGraphicSection("quality_preset")))
                    button.ButtonPressed = true;
            }
        }
        private void OnQualityPresetButtonPressed(BaseButton button) {
            var qualityPreset = (GameSettingsResource.QualityPresets)(int.Parse(((Button)button).Name));

            SettingsFileHandlerAutoload.UpdateGraphicSection("quality_preset", (int)qualityPreset);
            SettingsFileHandlerAutoload.SaveSettings();
        }

        public void OnLocaleChanged() {
            if(IsInsideTree()) {
                GetNode<Label>("GraphicsQualityLabel").Text = Tr(Localization.GraphicsQualityTranslationKey);

                foreach (var entry in QualityPresetButtons) {
                    entry.Value.Text = Tr(Translations[entry.Key]);
                }
            }
        }
    }
}
