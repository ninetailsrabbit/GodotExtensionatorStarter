using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class Main : Node {
        public SceneTransitioner SceneTransitioner { get; set; } = default!;
        public override void _EnterTree() {
            SceneTransitioner = this.GetAutoloadNode<SceneTransitioner>();
        }
    }

}
