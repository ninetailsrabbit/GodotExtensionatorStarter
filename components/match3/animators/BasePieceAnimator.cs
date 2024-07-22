using Godot;

namespace GodotExtensionatorStarter {
    public partial class BasePieceAnimator : Node {
        protected BoardUI BoardUI { get; set; } = null!;
        public override void _EnterTree() {
            BoardUI ??= (BoardUI)GetTree().GetFirstNodeInGroup(BoardUI.GROUP_NAME);
        }
    }
}
