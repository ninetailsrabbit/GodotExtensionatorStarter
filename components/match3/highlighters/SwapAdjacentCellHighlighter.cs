using Godot;

namespace GodotExtensionatorStarter {
    public partial class SwapAdjacentCellHighlighter : Node, IBoardCellHighlighter {

        private PieceUI? _currentSelectedPiece = null;
        private CompressedTexture2D _selectedTileTexture = GD.Load<CompressedTexture2D>("res://components/match3/debug_ui/preview_cells/highlighted.png");

        public void OnSelectedPiece(BoardUI BoardUI, PieceUI origin) {
            if (_currentSelectedPiece is null) {
                _currentSelectedPiece = origin;
                BoardUI.AdjacentCellsFrom(origin).ForEach(cellUI => cellUI.ChangeBackgroundImage(_selectedTileTexture));
            }
            else {
                OnDeSelectedPiece(BoardUI, _currentSelectedPiece);
            }
        }

        public void OnDeSelectedPiece(BoardUI BoardUI, PieceUI origin) {
            BoardUI.AdjacentCellsFrom(origin).ForEach(cellUI => cellUI.ChangeToOriginalBackgroundImage());
            _currentSelectedPiece = null;
        }

    }
}
