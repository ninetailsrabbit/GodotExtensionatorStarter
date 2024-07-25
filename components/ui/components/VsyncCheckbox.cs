using Extensionator;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class VsyncCheckbox : CheckBox {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            Toggled += OnVsyncChanged;
        }

        public override void _Ready() {
            ButtonPressed = ((int)DisplayServer.WindowGetVsyncMode()).IsGreaterThanZero();
        }

        private void OnVsyncChanged(bool toggled) {
            DisplayServer.WindowSetVsyncMode((DisplayServer.VSyncMode)toggled.ToInt());

            SettingsFileHandlerAutoload.UpdateGraphicSection("vsync", (int)DisplayServer.WindowGetVsyncMode());
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
