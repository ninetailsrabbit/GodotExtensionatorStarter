using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using Match3Maker;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {
    public partial class LineConnector : Line2D {

        [Signal]
        public delegate void AddedPieceEventHandler(LineConnectorPiece piece);

        [Signal]
        public delegate void MatchSelectedEventHandler(LineConnectorPiece[] selectedPieces);

        public Array<LineConnectorPiece> PiecesConnected = [];
        public Area2D DetectionArea { get; set; } = null!;

        public LineConnectorPiece OriginPiece { get; set; } = default!;
        public List<LineConnectorPiece> PreviousMatches = [];
        public List<LineConnectorPiece> PossibleNextMatches = [];
        public GameGlobals GameGlobals { get; set; } = null!;

        public override void _ExitTree() {
            EmitSignal(SignalName.MatchSelected, PiecesConnected);

            AddedPiece -= OnAddedPiece;
            MatchSelected -= OnLineMatchSelected;

            foreach (LineConnectorPiece piece in PiecesConnected)
                piece.PieceArea.Enable();

            PreviousMatches.Concat(PossibleNextMatches)
                   .ToList()
                   .ForEach(piece => OriginPiece.BoardUI.CurrentCellHighlighter?.OnDeSelectedPiece(OriginPiece.BoardUI, piece));

            DetectionArea.Remove();
        }

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            Width = 1.5f;
            DefaultColor = Colors.Yellow;

            AddedPiece += OnAddedPiece;
            MatchSelected += OnLineMatchSelected;

            SetProcess(false);
        }

        public override void _Process(double delta) {
            if (Points.IsEmpty() || DetectionArea is null) return;

            var mousePosition = GetGlobalMousePosition();

            RemovePoint(Points.LastIndex());
            AddPoint(mousePosition);

            DetectionArea.GlobalPosition = mousePosition;
        }

        public void AddPiece(LineConnectorPiece pieceUI) {
            pieceUI.PieceArea.Disable();

            PiecesConnected.Add(pieceUI);

            ClearPoints();
            PiecesConnected.ToList().ForEach(pieceUI => AddPoint(pieceUI.GlobalPosition));
            AddPoint(GetGlobalMousePosition());

            EmitSignal(SignalName.AddedPiece, pieceUI);
        }

        private void PrepareDetectionArea() {
            DetectionArea = new Area2D {
                CollisionLayer = 0,
                CollisionMask = GameGlobals.PiecesCollisionLayer,
                ProcessPriority = 2,
                DisableMode = CollisionObject2D.DisableModeEnum.MakeStatic
            };

            DetectionArea.AddChild(new CollisionShape2D() { Shape = new RectangleShape2D() });

            GetTree().Root.AddChild(DetectionArea);

            CollisionShape2D detectionAreaCollision = DetectionArea.GetChild<CollisionShape2D>(0);
            RectangleShape2D detectionAreaShape = (RectangleShape2D)detectionAreaCollision.Shape;

            detectionAreaShape.Size = OriginPiece.CellSize / 2;
            detectionAreaCollision.Shape = detectionAreaShape;

            DetectionArea.GlobalPosition = GetGlobalMousePosition();
            DetectionArea.AreaEntered += OnPieceDetected;

            OriginPiece.PieceArea.Disable();
            SetProcess(true);
        }

        private void DetectNewMatchesFromLastPiece(LineConnectorPiece lastPiece) {
            GridCell? originCell = lastPiece.BoardUI.GridCellUIFromPiece(lastPiece.Piece)?.Cell;

            if (originCell is not null) {
                GridCell[] adjacentCells = [
                    originCell.NeighbourUp,
                    originCell.NeighbourRight,
                    originCell.NeighbourLeft,
                    originCell.NeighbourBottom,
                    originCell.DiagonalNeighbourBottomRight,
                    originCell.DiagonalNeighbourBottomLeft,
                    originCell.DiagonalNeighbourTopRight,
                    originCell.DiagonalNeighbourTopLeft
                ];

                PreviousMatches = [.. PossibleNextMatches];

                PossibleNextMatches = adjacentCells.RemoveNullables()
                    .Select(lastPiece.BoardUI.PieceFromGridCell)
                    .RemoveNullables()
                    .Cast<LineConnectorPiece>()
                    .Where(piece => !PiecesConnected.Contains(piece) && piece.MatchWith(lastPiece))
                    .ToList();

            }

        }


        private void OnPieceDetected(Area2D otherArea) {
            LineConnectorPiece pieceUI = otherArea.GetParent<LineConnectorPiece>();

            if (PossibleNextMatches.Contains(pieceUI))
                AddPiece(pieceUI);
        }

        private void OnAddedPiece(LineConnectorPiece piece) {
            if (PiecesConnected.Count == 1) {
                OriginPiece = piece;
                ZIndex = OriginPiece.ZIndex + 25;
                ZAsRelative = true;
                PrepareDetectionArea();
            }

            if (PiecesConnected.Count < piece.BoardUI.MaxMatch) {
                DetectNewMatchesFromLastPiece(piece);

                BoardUI BoardUI = OriginPiece.BoardUI;

                PreviousMatches
                    .ForEach(piece => BoardUI.CurrentCellHighlighter?.OnDeSelectedPiece(BoardUI, piece));

                PossibleNextMatches
                    .ForEach(piece => BoardUI.CurrentCellHighlighter?.OnSelectedPiece(BoardUI, piece));
            }
            else {
                SetProcess(false);
                RemovePoint(Points.LastIndex());
                DetectionArea.Disable();
            }
        }

        private void OnLineMatchSelected(LineConnectorPiece[] PiecesConnected) {
            OriginPiece.BoardUI.EmitSignal(BoardUI.SignalName.ConsumeRequested, PiecesConnected);
        }

    }
}
