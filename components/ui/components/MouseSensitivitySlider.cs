using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class MouseSensitivitySlider : HSlider {
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;
        public override void _EnterTree() {
            Name = $"MouseSensitivitySlider";

            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();

            MinValue = 0.5f;
            MaxValue = 20f;
            Step = 0.5f;
            TickCount = (int)Mathf.Ceil(MaxValue / MinValue);
            TicksOnBorders = true;

            ValueChanged += OnMouseSensitivityChanged;
        }

        public override void _Ready() {
            if (Visible)
                this.Enable();
            else
                this.Disable();

            Value = (float)SettingsFileHandlerAutoload.ConfigFileApi.GetValue(SettingsFileHandlerAutoload.AccessibilitySection, "mouse_sensitivity");
        }

        private void OnMouseSensitivityChanged(double value) {
            SettingsFileHandlerAutoload.UpdateAccessibilitySection("mouse_sensitivity", (float)value);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
