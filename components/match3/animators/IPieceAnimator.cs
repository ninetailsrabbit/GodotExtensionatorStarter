using Match3Maker;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {
    public interface IPieceAnimator {
        public Task SwapPieces(PieceUI from, PieceUI to);
        public Task FallDownPiece(PieceUI piece, GridCellUI emptyGridCell);
        public Task CreateNewPiece(PieceUI piece);
        public Task ConsumeSequence(Sequence sequence);
    }
}
