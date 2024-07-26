﻿using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class ScreenshakeCheckBox : CheckBox {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
        }

        public override void _Ready() {
            Toggled += OnToggled;
            ButtonPressed = (bool)SettingsFileHandlerAutoload.GetAccessibilitySection("screenshake");
        }

        private void OnToggled(bool toggled) {
            SettingsFileHandlerAutoload.UpdateAccessibilitySection("screenshake", toggled);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
