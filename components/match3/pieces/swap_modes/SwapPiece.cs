using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class SwapPiece : PieceUI {

        public Button MouseRegion { get; set; } = default!;
        public Sprite2D Sprite { get; set; } = null!;

        public override void _EnterTree() {
            base._EnterTree();

            Sprite = this.FirstNodeOfType<Sprite2D>();
            PrepareSprite(Sprite);
        }

        public override void _Ready() {
            base._Ready();

            if (MouseRegion is null) {
                MouseRegion = new();
                MouseRegion.SelfModulate = MouseRegion.SelfModulate with { A8 = 100 }; // TODO - CHANGE TO 0 ON RELEASE
                Sprite.AddChild(MouseRegion);
            }

            MouseRegion.Pressed += OnPressed;
            MouseRegion.Position = Vector2.Zero;
            MouseRegion.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
        }

        private void OnPressed() {
            IsSelected = !IsSelected;
        }
    }
}
