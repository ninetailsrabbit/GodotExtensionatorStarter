using Godot;

namespace GodotExtensionatorStarter {
    public partial class SwapFreeCellHighlighter : Node, IBoardCellHighlighter {

        private PieceUI? _currentSelectedPiece = null;
        private CompressedTexture2D _selectedTileTexture = GD.Load<CompressedTexture2D>("res://components/match3/debug_ui/preview_cells/highlighted.png");

        public void OnSelectedPiece(BoardUI BoardUI, PieceUI origin) {
            if (_currentSelectedPiece is null) {
                _currentSelectedPiece = origin;
                BoardUI.GridCellUIFromPiece(origin)?.ChangeBackgroundImage(_selectedTileTexture);
            }
            else {
                OnDeSelectedPiece(BoardUI, _currentSelectedPiece);
            }
        }

        public void OnDeSelectedPiece(BoardUI BoardUI, PieceUI origin) {
            BoardUI.GridCellUIFromPiece(origin)?.ChangeToOriginalBackgroundImage();
            _currentSelectedPiece = null;
        }

    }
}
