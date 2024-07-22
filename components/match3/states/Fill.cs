using Godot;
using Match3Maker;

#pragma warning disable 8600,8602

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class Fill : BoardState {

        public override void Enter() {
            UpdateFromVirtualBoard();

            var matches = BoardUI.FindAllMatches();

            if (matches.Count > 0)
                FSM?.ChangeStateTo<Consume>(new() { { "matches", matches } });
            else
                FSM?.ChangeStateTo<WaitForInput>();

            return;
        }

        private void UpdateFromVirtualBoard() {
            var virtualBoard = BoardUI.Board.MovePiecesAndFillEmptyCells();

            foreach (var movementUpdate in virtualBoard.MovementUpdates()) {
                GridCell currentCell = BoardUI.Board.Cell(movementUpdate.CellPieceMovement.PreviousCell.Position());
                GridCell emptyCell = BoardUI.Board.Cell(movementUpdate.CellPieceMovement.NewCell.Position());

                GridCellUI emptyCellUI = BoardUI.GridCellUIFromCell(emptyCell);
                PieceUI pieceUI = BoardUI.PieceFromGridCell(currentCell);

                if(emptyCellUI is not null && pieceUI is not null) {
                    emptyCell.AssignPiece(currentCell.Piece);
                    currentCell.RemovePiece();

                    BoardUI.CurrentPieceAnimator.FallDownPiece(pieceUI, emptyCellUI);
                }
             
            }

            foreach (var fillUpdate in virtualBoard.FillUpdates()) {
                GridCell emptyCell = BoardUI.Board.Cell(fillUpdate.CellPieceFill.Cell.Position());

                if (BoardUI.GridCellUIFromCell(emptyCell) is GridCellUI emptyCellUI) {
                    emptyCell.AssignPiece(fillUpdate.CellPieceFill.Piece);

                    if (BoardUI.DrawPieceUIOnCell(emptyCellUI) is PieceUI pieceUI) {
                        BoardUI.CurrentPieceAnimator.CreateNewPiece(pieceUI);
                    }
                }
            }
        }
    }
}
