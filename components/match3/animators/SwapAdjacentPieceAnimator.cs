using Godot;
using Match3Maker;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {
    public partial class SwapAdjacentPieceAnimator : BasePieceAnimator, IPieceAnimator {
        public async Task ConsumeSequence(Sequence sequence) {
            var tween = CreateTween().SetParallel(true);

            foreach (var piece in BoardUI.PiecesFromSequence(sequence)) {
                tween.TweenProperty(piece, "scale", Vector2.Zero, 0.35f).SetEase(Tween.EaseType.Out);
            }

            await ToSignal(tween, Tween.SignalName.Finished);
        }

        public async Task SwapPieces(PieceUI from, PieceUI to) {
            Vector2 fromGlobalPosition = from.GlobalPosition;
            Vector2 toGlobalPosition = to.GlobalPosition;

            Tween tween = CreateTween();
            tween.SetParallel(true);
            tween.TweenProperty(from, "global_position", toGlobalPosition, 0.2f).SetEase(Tween.EaseType.In);
            tween.TweenProperty(from, "modulate:a", 0.1f, 0.2f).SetEase(Tween.EaseType.In);
            tween.TweenProperty(to, "global_position", fromGlobalPosition, 0.2f).SetEase(Tween.EaseType.In);
            tween.TweenProperty(to, "modulate:a", 0.1f, 0.2f).SetEase(Tween.EaseType.In);

            tween.Chain();
            tween.TweenProperty(from, "modulate:a", 1f, 0.2f).SetEase(Tween.EaseType.In);
            tween.TweenProperty(to, "modulate:a", 1f, 0.2f).SetEase(Tween.EaseType.In);

            await ToSignal(tween, Tween.SignalName.Finished);
        }

        public async Task CreateNewPiece(PieceUI pieceUI) {
            var fallDistance = pieceUI.CellSize.Y * BoardUI.GridHeight;
            pieceUI.Hide();

            Tween tween = CreateTween().SetParallel(true);
            tween.TweenProperty(pieceUI, "visible", true, 0.1f);
            tween.TweenProperty(pieceUI, "global_position", pieceUI.GlobalPosition, 0.25f).SetTrans(Tween.TransitionType.Quad)
                .From(new Vector2(pieceUI.GlobalPosition.X, pieceUI.GlobalPosition.Y - fallDistance));

            await ToSignal(tween, Tween.SignalName.Finished);
        }

        public async Task FallDownPiece(PieceUI piece, GridCellUI emptyGridCell) {
            Tween tween = CreateTween();
            tween.TweenProperty(piece, "global_position", emptyGridCell.GlobalPosition, 0.2f)
                .SetEase(Tween.EaseType.Out)
                .SetTrans(Tween.TransitionType.Linear);

            await ToSignal(tween, Tween.SignalName.Finished);
        }
    }
}
