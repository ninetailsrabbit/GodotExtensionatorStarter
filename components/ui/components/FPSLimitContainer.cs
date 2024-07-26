using Godot;
using Godot.Collections;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class FPSLimitContainer : HBoxContainer {

        [Export] public int[] Limits = [0, 30, 60, 90, 144, 240];
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<int, Button> FPSLimitButtons = [];

        private ButtonGroup FpsLimitButtonGroup { get; } = new();
        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
        }

        public override void _Ready() {
            this.QueueFreeChildren();

            FpsLimitButtonGroup.Pressed += OnButtonPressed;

            foreach (int fpsLimit in Limits) {
                var button = new Button {
                    Text = fpsLimit.ToString(),
                    Name = fpsLimit.ToString(),
                    ButtonGroup = FpsLimitButtonGroup,
                    ToggleMode = true,
                    SizeFlagsHorizontal = SizeFlags.ExpandFill
                };

                AddChild(button);

                if (Engine.MaxFps.Equals(fpsLimit))
                    button.ButtonPressed = true;
            }
        }

        private void OnButtonPressed(BaseButton button) {
            Engine.MaxFps = ((Button)button).Text.ToInt();

            SettingsFileHandlerAutoload.UpdateGraphicSection("max_fps", Engine.MaxFps);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
