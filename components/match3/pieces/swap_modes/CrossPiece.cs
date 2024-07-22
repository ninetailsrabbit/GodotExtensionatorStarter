using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class CrossPiece : PieceUI {

        public DraggableSprite2D DraggableSprite { get; set; } = null!;
        public Area2D PieceArea { get; set; } = null!;
        public Area2D DetectionArea { get; set; } = null!;

        public int OriginalZIndex = 0;
        public override void _ExitTree() {
            base._ExitTree();

            DraggableSprite.DragStarted -= OnDragStarted;
            DraggableSprite.DragEnded -= OnDragEnded;

            BoardUI.BoardLocked -= OnBoardLocked;
            BoardUI.BoardUnlocked -= OnBoardUnlocked;
        }

        public override void _EnterTree() {
            base._EnterTree();

            DraggableSprite = GetNode<DraggableSprite2D>(nameof(DraggableSprite2D));

            PrepareSprite(DraggableSprite);
            PrepareAreaDetectors();

            DraggableSprite.DragStarted += OnDragStarted;
            DraggableSprite.DragEnded += OnDragEnded;

            BoardUI.BoardLocked += OnBoardLocked;
            BoardUI.BoardUnlocked += OnBoardUnlocked;

            OriginalZIndex = DraggableSprite.ZIndex;
        }

        private void OnBoardLocked() {
            DraggableSprite.Disable();
        }

        private void OnBoardUnlocked() {
            DraggableSprite.Enable();
        }

        private void PrepareAreaDetectors() {
            PieceArea = GetNode<Area2D>(nameof(PieceArea));
            DetectionArea = DraggableSprite.GetNode<Area2D>(nameof(DetectionArea));

            PieceArea.CollisionLayer = GameGlobals.PiecesCollisionLayer;
            PieceArea.CollisionMask = 0;
            PieceArea.Monitoring = false;
            PieceArea.Monitorable = true;

            DetectionArea.CollisionLayer = 0;
            DetectionArea.CollisionMask = GameGlobals.PiecesCollisionLayer;
            DetectionArea.Monitoring = true;
            DetectionArea.Monitorable = false;

            CollisionShape2D pieceAreaCollision = PieceArea.GetChild<CollisionShape2D>(0);
            CollisionShape2D detectionAreaCollision = DetectionArea.GetChild<CollisionShape2D>(0);

            RectangleShape2D pieceAreaShape = (RectangleShape2D)pieceAreaCollision.Shape;
            RectangleShape2D detectionAreaShape = (RectangleShape2D)detectionAreaCollision.Shape;

            pieceAreaShape.Size = BoardUI.CellSize - Vector2.One * 10;
            detectionAreaShape.Size = BoardUI.CellSize;

            pieceAreaCollision.Shape = pieceAreaShape;
            detectionAreaCollision.Shape = detectionAreaShape;

            DetectionArea.Disable();
        }

        private void OnDragStarted() {
            DraggableSprite.ZIndex = OriginalZIndex + 100;
            ZAsRelative = false;

            IsSelected = true;

            PieceArea.Disable();
            DetectionArea.Enable();
        }

        private void OnDragEnded() {
            DraggableSprite.ZIndex = OriginalZIndex;
            ZAsRelative = true;

            IsSelected = false;

            var piecesDetectedAreas = DetectionArea.GetOverlappingAreas();

            if (piecesDetectedAreas.Count > 0)
                BoardUI.EmitSignal(BoardUI.SignalName.SwapRequested, this, piecesDetectedAreas[0].GetParent<CrossPiece>());

            DetectionArea.Disable();
            PieceArea.Enable();
        }
    }
}

