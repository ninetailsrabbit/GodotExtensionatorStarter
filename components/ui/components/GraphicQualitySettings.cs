using Godot;
using Godot.Collections;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class GraphicQualitySettings : VBoxContainer {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<GameSettingsResource.QualityPresets, string> Translations = [];

        private ButtonGroup QualityPresetButtonGroup { get; } = new();


        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();

            Translations = new() {
                { GameSettingsResource.QualityPresets.Low, Tr("QUALITY_LOW")},
                { GameSettingsResource.QualityPresets.Medium, Tr("QUALITY_MEDIUM")},
                { GameSettingsResource.QualityPresets.High, Tr("QUALITY_HIGH")},
                { GameSettingsResource.QualityPresets.Ultra, Tr("QUALITY_ULTRA")},
            };
        }

        public override void _Ready() {
            AnchorsPreset = AnchorsPreset = (int)LayoutPreset.FullRect;
            AddThemeConstantOverride("separation", 15);

            CreateGraphicQualityPresetButtons();

        }

        private void CreateGraphicQualityPresetButtons() {

            AddChild(new Label() { Text = Tr("GRAPHICS_QUALITY") });

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
    }
}
