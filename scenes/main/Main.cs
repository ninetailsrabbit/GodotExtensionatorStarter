using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class Main : Node {

        [Export(PropertyHint.File, "*.tscn")] public string NextScene = string.Empty;
        public ContentWarningsDisplayer ContentWarningsDisplayer { get; set; } = default!;
        public SceneTransitioner SceneTransitioner { get; set; } = default!;
        public override void _ExitTree() {
            if (ContentWarningsDisplayer is not null)
                ContentWarningsDisplayer.AllContentWarningsDisplayed -= OnContentWarningsDisplayFinished;
        }

        public override void _EnterTree() {
            SceneTransitioner = this.GetAutoloadNode<SceneTransitioner>();
        }
        public override void _Ready() {
            ContentWarningsDisplayer = this.FirstNodeOfClass<ContentWarningsDisplayer>();

            if (ContentWarningsDisplayer is not null)
                ContentWarningsDisplayer.AllContentWarningsDisplayed += OnContentWarningsDisplayFinished;
        }


        private void OnContentWarningsDisplayFinished() {
            SceneTransitioner.TransitionToScene(NextScene);
        }
    }

}
