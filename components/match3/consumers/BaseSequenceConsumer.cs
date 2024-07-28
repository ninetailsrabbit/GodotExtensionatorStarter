using Godot;

namespace GodotExtensionatorStarter {

    public partial class BaseSequenceConsumer : Node {
        protected BoardUI BoardUI { get; set; } = null!;

        public override void _EnterTree() {
            BoardUI ??= (BoardUI)GetTree().GetFirstNodeInGroup(BoardUI.GroupName);
        }
    }
}
