using Godot;
using Godot.Collections;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class FPSLimitContainer : HBoxContainer {

        [Export] public int[] Limits = [0, 30, 60, 90, 144];
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<int, Button> FPSLimitButtons = [];

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
        }

        public override void _Ready() {
            this.QueueFreeChildren();

            foreach (int fpsLimit in Limits) {
                var button = new Button { Text = fpsLimit.ToString() };

                AddChild(button);

                button.SizeFlagsHorizontal = SizeFlags.ExpandFill;
                button.Pressed += () => OnButtonPressed(button, fpsLimit); ;

                if (Engine.MaxFps.Equals(fpsLimit))
                    button.GrabFocus();
            }
        }

        private void OnButtonPressed(Button pressedButton, int limit) {
            Engine.MaxFps = limit;
            
            SettingsFileHandlerAutoload.UpdateGraphicSection("max_fps", Engine.MaxFps);
            SettingsFileHandlerAutoload.SaveSettings();

            pressedButton.GrabFocus();
        }
    }
}
