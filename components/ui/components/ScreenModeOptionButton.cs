using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class ScreenModeOptionButton : OptionButton {
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public DisplayServer.WindowMode[] ValidWindowModes = [
            DisplayServer.WindowMode.Windowed,
            DisplayServer.WindowMode.Fullscreen,
            DisplayServer.WindowMode.ExclusiveFullscreen,
        ];

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            ItemSelected += OnScreenModeSelected;
        }

        public override void _Ready() {
            foreach (var windowMode in AvailableWindowModes())
                AddItem(windowMode.ToString(), (int)windowMode);

            Select(GetItemIndex((int)DisplayServer.WindowGetMode()));
        }

        private IEnumerable<DisplayServer.WindowMode> AvailableWindowModes()
            => Enum.GetValues(typeof(DisplayServer.WindowMode))
                    .Cast<DisplayServer.WindowMode>()
                    .Where(mode => ValidWindowModes.Contains(mode));
        private void OnScreenModeSelected(long idx) {
            DisplayServer.WindowSetMode((DisplayServer.WindowMode)GetItemId((int)idx));

            SettingsFileHandlerAutoload.UpdateGraphicSection("display", (int)DisplayServer.WindowGetMode());
            SettingsFileHandlerAutoload.SaveSettings();
        }

    }
}
