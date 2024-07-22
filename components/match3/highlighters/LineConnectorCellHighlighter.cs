using Godot;

namespace GodotExtensionatorStarter {
    public partial class LineConnectorCellHighlighter : Node, IBoardCellHighlighter {

        private CompressedTexture2D _selectedTileTexture = GD.Load<CompressedTexture2D>("res://components/match3/debug_ui/preview_cells/highlighted.png");

        public void OnSelectedPiece(BoardUI BoardUI, PieceUI origin) {
            BoardUI.GridCellUIFromPiece(origin)?.ChangeBackgroundImage(_selectedTileTexture);
        }

        public void OnDeSelectedPiece(BoardUI BoardUI, PieceUI origin) {
            BoardUI.GridCellUIFromPiece(origin)?.ChangeToOriginalBackgroundImage();
        }


    }
}
