using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class WindowManager : Node {
        public override void _ExitTree() {
            GetTree().Root.SizeChanged -= OnViewportSizeChanged;
        }

        public override void _Ready() {
            GetTree().Root.SizeChanged += OnViewportSizeChanged;
        }

        private void OnViewportSizeChanged() {
            GetViewport().CenterWindowPosition();
        }
    }
}
