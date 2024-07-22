namespace GodotExtensionatorStarter {
    public partial class BoardState : MachineState {

        public BoardUI? BoardUI { get; set; } = default!;

        public override void _EnterTree() {
            BoardUI ??= (BoardUI)GetTree().GetFirstNodeInGroup(BoardUI.GROUP_NAME);
        }
    }
}
