using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class PhotosensitiveCheckBox : CheckBox {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
        }

        public override void _Ready() {
            Toggled += OnToggled;
            ButtonPressed = (bool)SettingsFileHandlerAutoload.GetAccessibilitySection("photosensitive");
        }

        private void OnToggled(bool toggled) {
            SettingsFileHandlerAutoload.UpdateAccessibilitySection("photosensitive", toggled);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
