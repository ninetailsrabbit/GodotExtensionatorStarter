using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class LineConnectorPiece : PieceUI {

        public Sprite2D Sprite { get; set; } = null!;
        public Area2D PieceArea { get; set; } = null!;
        public Button MouseRegion { get; set; } = null!;
        public LineConnector? LineConnector { get; set; } = default!;

        public override void _EnterTree() {
            base._EnterTree();

            PieceArea = GetNode<Area2D>(nameof(PieceArea));
            PieceArea.CollisionLayer = GameGlobals.PiecesCollisionLayer;
            PieceArea.CollisionMask = 0;

            Sprite = GetNode<Sprite2D>(nameof(Sprite));
            PrepareSprite(Sprite);
        }


        public override void _Ready() {
            if (MouseRegion is null) {
                MouseRegion = new();
                MouseRegion.SelfModulate = MouseRegion.SelfModulate with { A8 = 100 }; // TODO - CHANGE TO 0 ON RELEASE
                Sprite.AddChild(MouseRegion);
            }

            MouseRegion.ButtonDown += OnPressed;
            MouseRegion.ButtonUp += OnRelease;
            MouseRegion.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
        }

        private void OnPressed() {
            if (BoardUI.Locked)
                return;

            IsSelected = true;

            LineConnector = new LineConnector();

            GetTree().Root.AddChild(LineConnector);

            LineConnector.AddPiece(this);
        }

        private void OnRelease() {
            IsSelected = false;
            LineConnector?.Remove();
            LineConnector = null;

        }
    }
}
