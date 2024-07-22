using GodotExtensionator;
using Match3Maker;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {
    public partial class DefaultSequenceConsumer : BaseSequenceConsumer, ISequenceConsumer {

        public async Task ConsumeSequence(Sequence sequence) {
            var pieces = BoardUI.PiecesFromSequence(sequence);

            await BoardUI.CurrentPieceAnimator.ConsumeSequence(sequence);

            BoardUI.Board.ConsumeSequence(sequence);
            pieces.ForEach(piece => piece.Remove());
        }

        public async Task ConsumeSequences(IEnumerable<Sequence> sequences) {
            await Task.WhenAll(sequences.Select(async sequence => await ConsumeSequence(sequence)));
        }
    }
}
