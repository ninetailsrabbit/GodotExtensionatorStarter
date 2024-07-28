using Godot;
using Match3Maker;
using System;
using System.Data.Common;

namespace GodotExtensionatorStarter {
    public partial class GridCellUI : Node2D {
        #region Signals
        [Signal]
        public delegate void RemovedPieceEventHandler(GenericGodotWrapper<Piece> removedPiece);
        #endregion

        public const string GroupName = "cell";

        [Export] public Vector2I CellSize;
        [Export] public CompressedTexture2D OddCellTexture { get; set; } = default!;
        [Export] public CompressedTexture2D EvenCellTexture { get; set; } = default!;

        public Texture2D SelectedBackgroundImage { get; set; } = default!;
        public Sprite2D BackgroundSprite { get; set; } = default!;

        public Guid Id = Guid.NewGuid();
        public GridCell Cell { get; set; } = null!;

        public override void _EnterTree() {
            AddToGroup(GroupName);
            PrepareBackgroundSprite();

            Name = $"Cell_Column{Cell.Column}_Row{Cell.Row}";
        }

        public void ChangeToOriginalBackgroundImage() {
            BackgroundSprite.Texture = SelectedBackgroundImage;
        }

        public void ChangeBackgroundImage(Texture2D newImage) {
            BackgroundSprite.Texture = newImage;
        }

        private void PrepareBackgroundSprite() {
            SelectedBackgroundImage = (Cell.Column + Cell.Row) % 2 == 0 ? EvenCellTexture : OddCellTexture;

            BackgroundSprite ??= GetNode<Sprite2D>(nameof(BackgroundSprite));
            BackgroundSprite.Texture = SelectedBackgroundImage;
            BackgroundSprite.ZIndex = -10;

            var textureSize = BackgroundSprite.Texture.GetSize();
            BackgroundSprite.Scale = new Vector2(CellSize.X / textureSize.X, CellSize.Y / textureSize.Y);
        }
    }

}