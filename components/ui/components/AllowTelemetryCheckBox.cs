using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class AllowTelemetryCheckBox : CheckBox {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
        }

        public override void _Ready() {
            Toggled += OnToggled;
            ButtonPressed = (bool)SettingsFileHandlerAutoload.GetAnalyticsSection("allow_telemetry");
        }

        private void OnToggled(bool toggled) {
            SettingsFileHandlerAutoload.UpdateAnalyticsSection("allow_telemetry", toggled);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
