using Godot;
using Godot.Collections;
using GodotExtensionator;
using System;
using System.Linq;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class DaltonismContainer : HBoxContainer {
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<int, Button> DaltonismButtons = [];
        public Dictionary<GameSettingsResource.DaltonismTypes, string> Translations = [];

        private ButtonGroup DaltonismButtonGroup { get; } = new();

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();

            Translations = new() {
                { GameSettingsResource.DaltonismTypes.NO, Tr("GENERAL_NO")},
                { GameSettingsResource.DaltonismTypes.DEUTERANOPIA, Tr("DALTONISM_DEUTERANOPIA")},
                { GameSettingsResource.DaltonismTypes.PROTANOPIA, Tr("DALTONISM_PROTANOPIA")},
                { GameSettingsResource.DaltonismTypes.TRITANOPIA, Tr("DALTONISM_TRITANOPIA")},
                { GameSettingsResource.DaltonismTypes.ACHROMATOPSIA, Tr("DALTONISM_ACHROMATOPSIA")},
            };
        }

        public override void _Ready() {
            this.QueueFreeChildren();

            DaltonismButtonGroup.Pressed += OnButtonPressed;
            var daltonismTypes = Enum.GetValues(typeof(GameSettingsResource.DaltonismTypes)).Cast<GameSettingsResource.DaltonismTypes>();

            foreach (var daltonismType in daltonismTypes) {
                var button = new Button {
                    Text = Translations[daltonismType],
                    Name = $"{(int)daltonismType}",
                    ButtonGroup = DaltonismButtonGroup,
                    ToggleMode = true,
                    SizeFlagsHorizontal = SizeFlags.ExpandFill
                };

                AddChild(button);

                if (daltonismType.Equals((GameSettingsResource.DaltonismTypes)(int)SettingsFileHandlerAutoload.GetAccessibilitySection("daltonism")))
                    button.ButtonPressed = true;
            }
        }

        private void OnButtonPressed(BaseButton button) {
            var daltonismType = int.Parse(button.Name);

            RenderingServer.GlobalShaderParameterSet("daltonism", daltonismType);

            SettingsFileHandlerAutoload.UpdateAccessibilitySection("daltonism", daltonismType);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
