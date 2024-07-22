using Godot;
using Match3Maker;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Swap : BoardState {

        public PieceUI? FromPiece;
        public PieceUI? ToPiece;

        public override void _ExitTree() {
            base._ExitTree();

            BoardUI.SwappedPieces -= OnSwappedPieces;
            BoardUI.SwapRejected -= OnSwapRejected;
            BoardUI.SwapFailed -= OnSwapFailed;
        }
        public override void _EnterTree() {
            base._EnterTree();

            BoardUI.SwappedPieces += OnSwappedPieces;
            BoardUI.SwapRejected += OnSwapRejected;
            BoardUI.SwapFailed += OnSwapFailed;
        }

        public override void Enter() {
            GridCell? fromGridCell = BoardUI?.GridCellUIFromPiece(FromPiece)?.Cell;
            GridCell? toGridCell = BoardUI?.GridCellUIFromPiece(ToPiece)?.Cell;

            if (fromGridCell is not null && toGridCell is not null) {
                BoardUI?.SwapPiecesRequest(fromGridCell, toGridCell);
            }
        }

        private void OnSwappedPieces(PieceUI fromPieceUI, PieceUI toPieceUI, GenericGodotWrapper<List<Sequence>> matches) {
            FSM?.ChangeStateTo<Consume>(new() { { "matches", matches.Value } });
        }

        private void OnSwapRejected(PieceUI fromPieceUI, PieceUI toPieceUI) {
            FSM?.ChangeStateTo<WaitForInput>();
        }

        private void OnSwapFailed(GridCellUI fromGridCell, GridCellUI toGridCell) {
            FSM?.ChangeStateTo<WaitForInput>();

        }
    }

}