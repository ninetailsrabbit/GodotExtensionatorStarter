using Godot;
using Match3Maker;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {
    public partial class LineConnectorPieceAnimator : BasePieceAnimator, IPieceAnimator {
        public async Task ConsumeSequence(Sequence sequence) {
            var tween = CreateTween().SetParallel(true);

            foreach (var piece in BoardUI.PiecesFromSequence(sequence)) {
                tween.TweenProperty(piece, "scale", Vector2.Zero, 0.45f).SetEase(Tween.EaseType.Out);
            }

            await ToSignal(tween, Tween.SignalName.Finished);
        }

        public async Task CreateNewPiece(PieceUI piece) {
            var fallDistance = piece.CellSize.Y * BoardUI.GridHeight;

            Tween tween = CreateTween();
            tween.TweenProperty(piece, "global_position", piece.GlobalPosition, 0.25f).SetTrans(Tween.TransitionType.Quad)
                .From(new Vector2(piece.GlobalPosition.X, piece.GlobalPosition.Y - fallDistance));

            await ToSignal(tween, Tween.SignalName.Finished);
        }

        public async Task FallDownPiece(PieceUI piece, GridCellUI emptyGridCell) {
            Tween tween = CreateTween();
            tween.TweenProperty(piece, "global_position", emptyGridCell.GlobalPosition, 0.15f)
                .SetEase(Tween.EaseType.Out)
                .SetTrans(Tween.TransitionType.Linear);

            await ToSignal(tween, Tween.SignalName.Finished);
        }

        public async Task SwapPieces(PieceUI from, PieceUI to) {
            await Task.CompletedTask;
        }


    }
}
