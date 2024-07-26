using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class GraphicQualitySettings : VBoxContainer {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        private ButtonGroup QualityPresetButtonGroup { get; } = new();

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
        }

        public override void _Ready() {
            AnchorsPreset = AnchorsPreset = (int)LayoutPreset.FullRect;
            AddThemeConstantOverride("separation", 15);

            CreateGraphicQualityPresetButtons();

        }

        private void CreateGraphicQualityPresetButtons() {

            AddChild(new Label() { Text = "Graphics quality" });

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

                if (entry.Key.Equals((GameSettingsResource.QUALITY_PRESETS)(int)SettingsFileHandlerAutoload.GetGraphicSection("quality_preset")))
                    button.ButtonPressed = true;
            }
        }
        private void OnQualityPresetButtonPressed(BaseButton button) {
            var qualityPreset = (GameSettingsResource.QUALITY_PRESETS)(int.Parse(((Button)button).Name));

            SettingsFileHandlerAutoload.UpdateGraphicSection("quality_preset", (int)qualityPreset);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
