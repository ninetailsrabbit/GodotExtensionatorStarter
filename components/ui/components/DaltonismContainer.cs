﻿using Godot;
using Godot.Collections;
using GodotExtensionator;
using System;
using System.Linq;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class DaltonismContainer : HBoxContainer, ITranslatable {
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<GameSettingsResource.DaltonismTypes, Button> DaltonismButtons = [];
        public Dictionary<GameSettingsResource.DaltonismTypes, string> Translations = [];

        private ButtonGroup DaltonismButtonGroup { get; } = new();

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();

            Translations = new() {
                { GameSettingsResource.DaltonismTypes.NO, Localization.NoTranslationKey},
                { GameSettingsResource.DaltonismTypes.DEUTERANOPIA, Localization.DeuteranopiaTranslationKey},
                { GameSettingsResource.DaltonismTypes.PROTANOPIA, Localization.ProtanopiaTranslationKey},
                { GameSettingsResource.DaltonismTypes.TRITANOPIA, Localization.TritanopiaTranslationKey},
                { GameSettingsResource.DaltonismTypes.ACHROMATOPSIA, Localization.AchromatopsiaTranslationKey},
            };
        }

        public override void _Ready() {
            this.QueueFreeChildren();

            DaltonismButtonGroup.Pressed += OnButtonPressed;
            var daltonismTypes = Enum.GetValues(typeof(GameSettingsResource.DaltonismTypes)).Cast<GameSettingsResource.DaltonismTypes>();

            foreach (var daltonismType in daltonismTypes) {
                var button = new Button {
                    Text = Tr(Translations[daltonismType]),
                    Name = $"{(int)daltonismType}",
                    ButtonGroup = DaltonismButtonGroup,
                    ToggleMode = true,
                    SizeFlagsHorizontal = SizeFlags.ExpandFill
                };

                DaltonismButtons.Add(daltonismType, button);

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

        public void OnLocaleChanged() {
            foreach (var entry in DaltonismButtons)
                entry.Value.Text = Tr(Translations[entry.Key]);
        }
    }
}
