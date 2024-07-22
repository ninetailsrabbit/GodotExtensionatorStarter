using Godot;

namespace GodotExtensionatorStarter {

    public interface IBoardCellHighlighter {
        public void OnSelectedPiece(BoardUI BoardUI, PieceUI origin);
        public void OnDeSelectedPiece(BoardUI BoardUI, PieceUI origin);
    }
}
