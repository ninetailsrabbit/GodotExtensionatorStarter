using Extensionator;
using Godot;
using GodotExtensionator;
using Match3Maker;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GodotExtensionatorStarter {
    public partial class PieceUI : Node2D {
        #region Signals
        [Signal]
        public delegate void SelectedEventHandler();

        [Signal]
        public delegate void UnSelectedEventHandler();

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        public const string GROUP_NAME = "piece";

        [Export] public BoardUI BoardUI { get; set; } = null!;
        [Export] public Vector2I CellSize;
        [Export] public Texture2D Image { get; set; } = null!;
        [Export] public float TextureScale = 0.85f;
        public GameGlobals GameGlobals { get; set; } = default!;
        public Piece Piece { get; set; } = null!;

        public bool IsSelected {
            get => _isSelected;
            set {
                if (_isSelected != value && (!IsInsideTree() || (BoardUI is BoardUI board && !board.Locked))) {
                    _isSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isSelected = false;
        public override void _ExitTree() {
            PropertyChanged -= OnPropertyChanged;
        }

        public override void _EnterTree() {
            AddToGroup(GROUP_NAME);
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            BoardUI ??= (BoardUI)GetTree().GetFirstNodeInGroup(BoardUI.GROUP_NAME);
            PropertyChanged += OnPropertyChanged;
            Name = $"{Piece.Type.Shape.ToPascalCase()}-{Piece.Type.GetType()}";
            IsSelected = false;
        }

        protected void PrepareSprite(Sprite2D sprite) {
            sprite.Texture = Image;
            var textureSize = sprite.Texture.GetSize();
            sprite.Scale = new Vector2(CellSize.X / textureSize.X, CellSize.Y / textureSize.Y) * TextureScale;
        }

        public bool MatchWith(PieceUI pieceUI) => Piece.MatchWith(pieceUI.Piece);

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Event callbacks
        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs eventArgs) {
            if (eventArgs.PropertyName.EqualsIgnoreCase(nameof(IsSelected))) {

                if (IsSelected) {
                    EmitSignal(SignalName.Selected, this);
                    BoardUI.EmitSignal(BoardUI.SignalName.PieceSelected, this);

                }
                else {
                    EmitSignal(SignalName.UnSelected, this);
                    BoardUI.EmitSignal(BoardUI.SignalName.PieceUnSelected, this);
                }
            }
        }

        #endregion
    }

}
