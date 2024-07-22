using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class WaitForInputToSwapTransition : Transition {

        public override bool ShouldTransition() {

            if (FromState is WaitForInput && ToState is Swap swapState) {
                swapState.FromPiece = Parameters["fromPiece"] as PieceUI;
                swapState.ToPiece = Parameters["toPiece"] as PieceUI;

                if (PiecesAreValid(swapState.FromPiece, swapState.ToPiece))
                    return true;

                swapState.FromPiece = null;
                swapState.ToPiece = null;
            }

            return false;
        }
        public override void OnTransition() { }
        private static bool PiecesAreValid(PieceUI fromPiece, PieceUI toPiece)
            => fromPiece is not null &&
            toPiece is not null &&
            fromPiece.Piece is not null &&
            toPiece.Piece is not null &&
            fromPiece.IsValid() &&
            toPiece.IsValid();
    }
}

