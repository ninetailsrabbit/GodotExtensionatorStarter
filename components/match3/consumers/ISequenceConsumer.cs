using Match3Maker;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {
    public interface ISequenceConsumer {
        public Task ConsumeSequences(IEnumerable<Sequence> sequence);
        public Task ConsumeSequence(Sequence sequence);
    }
}
