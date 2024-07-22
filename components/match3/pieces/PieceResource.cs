using Godot;
using Match3Maker;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class PieceResource : Resource {
        [Export] public Texture2D Image { get; set; } = null!;
        [Export]
        public float Weight {
            get => _weight; set {
                _weight = Mathf.Max(0.1f, value);

                if (Piece is not null)
                    Piece.Weight = _weight;
            }
        }
        public Piece Piece { get; set; } = null!;

        private float _weight = 1.0f;
        public PieceResource() { }
        public static PieceResource Create(Piece piece, Texture2D image, float weight = 1f) {
            PieceResource pieceResource = new() {
                Piece = piece,
                Image = image,
                Weight = weight
            };

            pieceResource.Piece.Weight = weight;

            return pieceResource;
        }
    }
}
