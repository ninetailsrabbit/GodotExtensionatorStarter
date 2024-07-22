using Extensionator;
using Godot;
using GodotExtensionator;
using Match3Maker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GodotExtensionatorStarter {
    //[Tool]
    public partial class BoardUI : Node2D, INotifyPropertyChanged {
        #region Preloaded scenes
        public readonly Dictionary<BoardMovements, PackedScene> PieceSceneByMovement = new() {
            { BoardMovements.ADJACENT, GD.Load<PackedScene>("res://components/match3/pieces/swap_modes/SwapPiece.tscn") },
            { BoardMovements.FREE_SWAP, GD.Load<PackedScene>("res://components/match3/pieces/swap_modes/SwapPiece.tscn") },
            { BoardMovements.CROSS, GD.Load<PackedScene>("res://components/match3/pieces/swap_modes/CrossPiece.tscn") },
            { BoardMovements.CROSS_DIAGONAL, GD.Load<PackedScene>("res://components/match3/pieces/swap_modes/CrossPiece.tscn") },
            { BoardMovements.CONNECT_LINE, GD.Load<PackedScene>("res://components/match3/pieces/swap_modes/LineConnectorPiece.tscn") },
        };

        public readonly PackedScene GridCellUIScene = GD.Load<PackedScene>("res://components/match3/cells/GridCellUI.tscn");
        #endregion
        #region Signals
        [Signal]
        public delegate void SwapRequestedEventHandler(PieceUI from, PieceUI to);

        [Signal]
        public delegate void SwappedPiecesEventHandler(PieceUI from, PieceUI to, GenericGodotWrapper<List<Sequence>> matches);

        [Signal]
        public delegate void SwapFailedEventHandler(GridCellUI fromGridCell, GridCellUI toGridCell);

        [Signal]
        public delegate void SwapRejectedEventHandler(PieceUI from, PieceUI to);

        [Signal]
        public delegate void ConsumeRequestedEventHandler(PieceUI[] pieces);

        [Signal]
        public delegate void ConsumedSequenceEventHandler(GenericGodotWrapper<Sequence> sequence);

        [Signal]
        public delegate void PieceSelectedEventHandler(PieceUI pieceUI);

        [Signal]
        public delegate void PieceUnSelectedEventHandler(PieceUI pieceUI);

        [Signal]
        public delegate void BoardLockedEventHandler();

        [Signal]
        public delegate void BoardUnlockedEventHandler();

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        public const string GROUP_NAME = "match3-board";
        public enum BoardMovements {
            ADJACENT,
            FREE_SWAP,
            CROSS,
            CROSS_DIAGONAL,
            CONNECT_LINE,
        }

        #region Exported variables

        [ExportGroup("Debug")]
        [Export]
        public bool PreviewGridInEditor {
            get => _previewGridInEditor;
            set {
                if (_previewGridInEditor != value) {
                    _previewGridInEditor = value;

                    if (_previewGridInEditor)
                        DrawPreviewGrid();
                    else
                        RemovePreviewSprites();
                }
            }
        }

        [Export] public bool CleanCurrentPreview { get => false; set { RemovePreviewSprites(); } }
        [Export(PropertyHint.ArrayType, "CompressedTexture2D")] public CompressedTexture2D[] PreviewPieces = [];
        [Export] public CompressedTexture2D OddCellTexture { get; set; } = default!;
        [Export] public CompressedTexture2D EvenCellTexture { get; set; } = default!;
        [Export(PropertyHint.ArrayType, "Vector2")]
        public Vector2[] EmptyCells {
            get => _emptyCells;
            set {
                if (_emptyCells != value) {
                    _emptyCells = value;
                    DrawPreviewGrid();
                }
            }
        }

        [ExportGroup("Size")]
        [Export]
        public int GridWidth {
            get => _gridWidth;
            set {
                if (_gridWidth != value) {
                    _gridWidth = Mathf.Max(value, Board.MIN_GRID_WIDTH);
                    DrawPreviewGrid();
                }
            }
        }

        [Export]
        public int GridHeight {
            get => _gridHeight;
            set {
                if (_gridHeight != value) {
                    _gridHeight = Mathf.Max(value, Board.MIN_GRID_HEIGHT);
                    DrawPreviewGrid();
                }
            }
        }
        [Export]
        public Vector2I CellSize {
            get => _cellSize;
            set {
                if (_cellSize != value) {
                    _cellSize = value;
                    DrawPreviewGrid();
                }
            }
        }
        [Export]
        public Vector2I CellOffset {
            get => _cellOffset;
            set {
                if (_cellOffset != value) {
                    _cellOffset = value;
                    DrawPreviewGrid();
                }
            }
        }

        [ExportGroup("Matches")]
        [Export] public int AvailableMovesOnStart = 25;
        [Export] public bool AllowMatchesOnStart = false;
        [Export] public bool HorizontalShape = true;
        [Export] public bool VerticalShape = true;
        [Export] public bool TShape = true;
        [Export] public bool LShape = true;
        [Export] public int MinMatch = 3;
        [Export] public int MaxMatch = 5;
        [Export] public int MinSpecialMatch = 2;
        [Export] public int MaxSpecialMatch = 2;
        [Export] public BoardMovements SwapMode = BoardMovements.ADJACENT;
        [Export] public Board.FILL_MODES FillMode = Board.FILL_MODES.FALL_DOWN;
        #endregion

        #region Class variables
        public Board Board { get; set; } = null!;
        public List<PieceResource> AvailablePieces = [];
        public PieceUI? CurrentSelectedPiece;

        public List<List<GridCellUI>> GridCells = [];
        public List<GridCellUI> GridCellsFlattened = [];
        public FiniteStateMachine FiniteStateMachine { get; set; } = null!;

        public Dictionary<BoardMovements, IBoardCellHighlighter> DefaultBoardCellHighlighters { get; set; } = new() {
            { BoardMovements.ADJACENT, new SwapAdjacentCellHighlighter()},
            { BoardMovements.FREE_SWAP, new SwapFreeCellHighlighter()},
            { BoardMovements.CROSS, new CrossCellHighlighter()},
            { BoardMovements.CROSS_DIAGONAL, new CrossDiagonalCellHighlighter()},
            { BoardMovements.CONNECT_LINE, new LineConnectorCellHighlighter()},
        };
        public Dictionary<BoardMovements, IPieceAnimator> DefaultBoardPieceAnimators { get; set; } = new() {
            {BoardMovements.ADJACENT, new SwapAdjacentPieceAnimator() },
            {BoardMovements.FREE_SWAP, new SwapFreePieceAnimator() },
            {BoardMovements.CROSS, new SwapCrossPieceAnimator() },
            {BoardMovements.CROSS_DIAGONAL, new SwapCrossDiagonalPieceAnimator() },
            {BoardMovements.CONNECT_LINE, new LineConnectorPieceAnimator() },
        };

        public Dictionary<BoardMovements, ISequenceConsumer> DefaultSequenceConsumers { get; set; } = new() {
            {BoardMovements.ADJACENT, new DefaultSequenceConsumer() },
            {BoardMovements.FREE_SWAP, new DefaultSequenceConsumer() },
            {BoardMovements.CROSS, new DefaultSequenceConsumer() },
            {BoardMovements.CROSS_DIAGONAL, new DefaultSequenceConsumer() },
            {BoardMovements.CONNECT_LINE, new DefaultSequenceConsumer() },
        };

        public IBoardCellHighlighter CurrentCellHighlighter {
            get => _currentCellHighlighter;
            set {
                if (_currentCellHighlighter != value) {
                    _currentCellHighlighter = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public IPieceAnimator CurrentPieceAnimator {
            get => _currentPieceAnimator;
            set {
                if (_currentPieceAnimator != value) {
                    _currentPieceAnimator = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ISequenceConsumer CurrentSequenceConsumer {
            get => _currentSequenceConsumer;
            set {
                if (_currentSequenceConsumer != value) {
                    _currentSequenceConsumer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private IBoardCellHighlighter _currentCellHighlighter = null!;
        private IPieceAnimator _currentPieceAnimator = null!;
        private ISequenceConsumer _currentSequenceConsumer = null!;
        public bool Locked {
            get => _locked;
            set {
                if (_locked != value) {
                    _locked = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Vector2[] _emptyCells = [];
        private Node2D? _rootPreviewNode { get; set; } = default!;
        private bool _locked = false;
        private bool _previewGridInEditor = true;
        private int _gridWidth = 8;
        private int _gridHeight = 7;
        private Vector2I _cellSize = new(48, 48);
        private Vector2I _cellOffset = new(5, 10);
        #endregion

        #region Debug variables
        public Label StateInformationLabel { get; set; } = default!;
        public Label LockedInformationLabel { get; set; } = default!;
        #endregion

        public override void _ExitTree() {
            if (!Engine.IsEditorHint()) {
                PropertyChanged -= OnPropertyChanged;
                PieceSelected -= OnPieceSelected;
                PieceUnSelected -= OnPieceUnSelected;
                BoardLocked -= OnBoardLocked;
                BoardUnlocked -= OnBoardUnlocked;
                SwapRequested -= OnSwapRequested;

                if (FiniteStateMachine is not null)
                    FiniteStateMachine.StateChanged -= OnStateChanged;
            }

        }

        public override void _EnterTree() {
            AddToGroup(GROUP_NAME);

            if (!Engine.IsEditorHint()) {
                RemovePreviewSprites();

                PropertyChanged += OnPropertyChanged;
                PieceSelected += OnPieceSelected;
                PieceUnSelected += OnPieceUnSelected;

                BoardLocked += OnBoardLocked;
                BoardUnlocked += OnBoardUnlocked;
                SwapRequested += OnSwapRequested;
                ConsumeRequested += OnConsumeRequested;
                FiniteStateMachine = this.FirstNodeOfClass<FiniteStateMachine>();

                if (FiniteStateMachine is not null) {
                    FiniteStateMachine.RegisterTransitions([
                        new WaitForInputToSwapTransition(),
                        new AnyToConsumeTransition()
                    ]);
                    FiniteStateMachine.StateChanged += OnStateChanged;

                }

                StateInformationLabel = GetNodeOrNull<Label>($"%{nameof(StateInformationLabel)}");
                LockedInformationLabel = GetNodeOrNull<Label>($"%{nameof(LockedInformationLabel)}");

                if (StateInformationLabel is not null)
                    StateInformationLabel.Text = $"[{FiniteStateMachine?.CurrentState.Name}]";

                if (LockedInformationLabel is not null)
                    LockedInformationLabel.Text = Locked ? "Locked" : "Unlocked";
            }
        }

        public override void _Ready() {
            if (!Engine.IsEditorHint()) {
                // TEMPORAL ADDED PIECES
                AvailablePieces = [
                PieceResource.Create(new Piece(new NormalPieceType("purple")), GD.Load<Texture2D>("res://components/match3/debug_ui/preview_pieces/blue_gem.png"), 1.5f),
                PieceResource.Create(new Piece(new NormalPieceType("yellow")), GD.Load<Texture2D>("res://components/match3/debug_ui/preview_pieces/yellow_gem.png"), 1.2f),
                PieceResource.Create(new Piece(new NormalPieceType("green")), GD.Load<Texture2D>("res://components/match3/debug_ui/preview_pieces/green_gem.png"), 1.15f),
            ];

                PrepareBoard();
                ChangeCellHighlighter();
                ChangePieceAnimator();
                ChangeSequenceConsumer();
            }

        }


        public void PrepareBoard() {
            Board = new(
               GridWidth,
               GridHeight,
               AvailableMovesOnStart,
               new PieceWeightGenerator(),
               new SequenceFinder(MinMatch, MaxMatch, MinSpecialMatch, MaxSpecialMatch, HorizontalShape, VerticalShape, TShape, LShape)
            );

            Board.FilledBoard += OnFilledBoard;

            // TEMPORAL
            Board.AddAvailablePieces(AvailablePieces.Select(pieceResource => pieceResource.Piece).ToList())
            .ChangeCellSize(CellSize.ToNumericVector())
            .ChangeOffset(CellOffset.ToNumericVector())
            .ChangeFillMode(FillMode)
            .PrepareGridCells()
            .FillInitialBoard(AllowMatchesOnStart);

            Locked = Board.Locked;
        }

        public void AddAvailablePieces(IEnumerable<PieceResource> availablePieces) {
            AvailablePieces.AddRange(availablePieces);
            AvailablePieces = AvailablePieces.RemoveDuplicates().RemoveNullables().ToList();
        }



        #region Draw
        public void DrawBoard() {
            foreach (GridCell gridCell in Board.CellsThatCanContainPieces()) {
                GridCellUI gridCellUI = DrawGridCellUI(gridCell);
                DrawPieceUIOnCell(gridCellUI);
            }
        }

        public GridCellUI DrawGridCellUI(GridCell gridCell) {
            GridCellUI gridCellUI = (GridCellUI)GridCellUIScene.Instantiate();

            gridCellUI.Cell = gridCell;
            gridCellUI.CellSize = CellSize;
            gridCellUI.Position = Board.CellPosition(gridCell).ToGodotVector();

            AddChild(gridCellUI);

            return gridCellUI;
        }

        public PieceUI? DrawPieceUIOnCell(GridCellUI cellUI) {
            if (cellUI.Cell.CanContainPiece && cellUI.Cell.HasPiece() && AvailablePieces.Count > 0) {
                var pieceUI = PieceSceneByMovement[SwapMode].Instantiate<PieceUI>();
                PieceResource pieceToDraw = AvailablePieces.First(pieceResource => pieceResource.Piece.Type.Equals(cellUI.Cell.Piece?.Type) && pieceResource.Piece.Type.Shape.Equals(cellUI.Cell.Piece.Type.Shape));

                pieceUI.BoardUI = this;
                pieceUI.Piece = cellUI.Cell.Piece;
                pieceUI.CellSize = CellSize;
                pieceUI.Image = pieceToDraw.Image;

                AddChild(pieceUI);
                pieceUI.GlobalPosition = cellUI.GlobalPosition;

                return pieceUI;
            }

            return null;

        }
        public void DrawPreviewGrid() {
            if (Engine.IsEditorHint() && PreviewGridInEditor) {

                this.SetOwnerToEditedSceneRoot();
                RemovePreviewSprites();

                if (_rootPreviewNode is null) {
                    _rootPreviewNode = new() { Name = "PreviewGrid" };
                    AddChild(_rootPreviewNode);
                    _rootPreviewNode.SetOwnerToEditedSceneRoot();
                }

                foreach (int column in Enumerable.Range(0, GridWidth)) {
                    foreach (int row in Enumerable.Range(0, GridHeight)) {

                        if (EmptyCells.Contains(new Vector2(row, column)))
                            continue;

                        Sprite2D currentCellSprite = new() {
                            Name = $"Cell_Column{column}_Row{row}",
                            Texture = (column + row) % 2 == 0 ? EvenCellTexture : OddCellTexture,
                            Position = new Vector2(CellSize.X * (float)column + CellOffset.X, CellSize.Y * (float)row + CellOffset.Y),
                        };

                        _rootPreviewNode.AddChild(currentCellSprite);
                        var cellTextureSize = currentCellSprite.Texture.GetSize();
                        currentCellSprite.Scale = new Vector2(CellSize.X / cellTextureSize.X, CellSize.Y / cellTextureSize.Y);
                        currentCellSprite.SetOwnerToEditedSceneRoot();

                        if (PreviewPieces.Length > 0) {
                            Sprite2D currentPieceSprite = new() {
                                Name = $"Piece_Column{column}_Row{row}",
                                Texture = PreviewPieces.RandomElement(),
                                Position = currentCellSprite.Position
                            };

                            _rootPreviewNode.AddChild(currentPieceSprite);
                            currentPieceSprite.GlobalPosition = currentCellSprite.GlobalPosition;
                            var pieceTextureSize = currentPieceSprite.Texture.GetSize();
                            currentPieceSprite.Scale = new Vector2(CellSize.X / pieceTextureSize.X, CellSize.Y / pieceTextureSize.Y) * 0.85f;
                            currentPieceSprite.SetOwnerToEditedSceneRoot();
                        }
                    }
                }

            }
        }

        #endregion

        public void ChangeCellHighlighter(IBoardCellHighlighter? boardCellHighlighter = null) {
            boardCellHighlighter ??= DefaultBoardCellHighlighters[SwapMode];
            CurrentCellHighlighter = boardCellHighlighter;
        }
        public void ChangePieceAnimator(IPieceAnimator? pieceAnimator = null) {
            pieceAnimator ??= DefaultBoardPieceAnimators[SwapMode];
            CurrentPieceAnimator = pieceAnimator;
        }
        public void ChangeSequenceConsumer(ISequenceConsumer? sequenceConsumer = null) {
            sequenceConsumer ??= DefaultSequenceConsumers[SwapMode];
            CurrentSequenceConsumer = sequenceConsumer;
        }
        public void RemoveCellHighlighter() {
            if (!Engine.IsEditorHint() && CurrentCellHighlighter is Node cellHighlighter && cellHighlighter.IsInsideTree())
                cellHighlighter.Free();
        }

        public void RemovePieceAnimator() {
            if (!Engine.IsEditorHint() && CurrentPieceAnimator is Node pieceAnimator && pieceAnimator.IsInsideTree())
                pieceAnimator.Free();
        }

        public void RemoveSequenceConsumer() {
            if (!Engine.IsEditorHint() && CurrentSequenceConsumer is Node currentSequenceConsumer && currentSequenceConsumer.IsInsideTree())
                currentSequenceConsumer.Free();
        }

        private void AddCellHighlighterToTree() {
            if (!Engine.IsEditorHint() && IsInsideTree()) {
                RemoveCellHighlighter();

                Node cellHighlighterNode = (Node)CurrentCellHighlighter;
                cellHighlighterNode.Name = $"{GetType().Name}CellHighlighter";

                CallDeferred(Node.MethodName.AddChild, cellHighlighterNode);
            }
        }

        private void AddPieceAnimatorToTree() {
            if (!Engine.IsEditorHint() && IsInsideTree()) {
                RemovePieceAnimator();

                Node pieceAnimatorNode = (Node)CurrentPieceAnimator;
                pieceAnimatorNode.Name = $"{GetType().Name}PieceAnimator";

                CallDeferred(Node.MethodName.AddChild, pieceAnimatorNode);
            }
        }

        private void AddSequenceConsumerToTree() {
            if (!Engine.IsEditorHint() && IsInsideTree()) {
                RemoveSequenceConsumer();

                Node sequenceConsumerNode = (Node)CurrentSequenceConsumer;
                sequenceConsumerNode.Name = $"{GetType().Name}SequenceConsumer";

                CallDeferred(Node.MethodName.AddChild, sequenceConsumerNode);
            }
        }


        #region Swap
        public void SwapPiecesRequest(GridCell fromGridCell, GridCell toGridCell) {
            switch (SwapMode) {
                case BoardMovements.ADJACENT:
                    SwapAdjacent(fromGridCell, toGridCell);
                    break;

                case BoardMovements.FREE_SWAP:
                    SwapFree(fromGridCell, toGridCell);
                    break;

                case BoardMovements.CROSS:
                    SwapCross(fromGridCell, toGridCell);
                    break;
                case BoardMovements.CROSS_DIAGONAL:
                    SwapCrossDiagonal(fromGridCell, toGridCell);
                    break;
            }
        }

        public async void SwapPieces(GridCell fromGridCell, GridCell toGridCell) {
            List<Sequence> matches = [FindMatchFromCell(fromGridCell), FindMatchFromCell(toGridCell)];
            matches = matches.RemoveNullables().ToList();

            if (PieceFromGridCell(fromGridCell) is PieceUI fromPieceUI && PieceFromGridCell(toGridCell) is PieceUI toPieceUI) {

                await CurrentPieceAnimator.SwapPieces(fromPieceUI, toPieceUI);

                if (matches.Count > 0) {
                    EmitSignal(SignalName.SwappedPieces, fromPieceUI, toPieceUI, new GenericGodotWrapper<List<Sequence>>(matches));
                }
                else {
                    await CurrentPieceAnimator.SwapPieces(fromPieceUI, toPieceUI);

                    fromGridCell.SwapPieceWith(toGridCell);
                    EmitSignal(SignalName.SwapRejected, fromPieceUI, toPieceUI);
                }

                return;
            }

            GD.PushError($"BoardUI::SwapPieces -> Failed to swap pieces, the Pieces nodes cannot be retrieved from cells {fromGridCell.Position()}, {toGridCell.Position()}");

            EmitSignal(SignalName.SwapFailed, GridCells[fromGridCell.Column][fromGridCell.Row], GridCells[toGridCell.Column][toGridCell.Row]);
        }

        private void SwapAdjacent(GridCell fromGridCell, GridCell toGridCell) {
            if (fromGridCell.IsAdjacentTo(toGridCell) && fromGridCell.SwapPieceWith(toGridCell))
                SwapPieces(fromGridCell, toGridCell);
            else
                EmitSignal(SignalName.SwapRejected, PieceFromGridCell(fromGridCell), PieceFromGridCell(toGridCell));
        }

        private void SwapFree(GridCell fromGridCell, GridCell toGridCell) {
            if (fromGridCell.SwapPieceWith(toGridCell))
                SwapPieces(fromGridCell, toGridCell);
            else
                EmitSignal(SignalName.SwapRejected, PieceFromGridCell(fromGridCell), PieceFromGridCell(toGridCell));

        }

        private void SwapCross(GridCell fromGridCell, GridCell toGridCell) {
            if ((fromGridCell.InSameColumnAs(toGridCell) || fromGridCell.InSameRowAs(toGridCell)) && fromGridCell.SwapPieceWith(toGridCell))
                SwapPieces(fromGridCell, toGridCell);
            else
                EmitSignal(SignalName.SwapRejected, PieceFromGridCell(fromGridCell), PieceFromGridCell(toGridCell));

        }

        private void SwapCrossDiagonal(GridCell fromGridCell, GridCell toGridCell) {
            if ((fromGridCell.InDiagonalWith(toGridCell) ||
                (!fromGridCell.InSameColumnAs(toGridCell) && !fromGridCell.InSameRowAs(toGridCell))) &&
                fromGridCell.SwapPieceWith(toGridCell)) {

                SwapPieces(fromGridCell, toGridCell);
            }
            else {
                EmitSignal(SignalName.SwapRejected, PieceFromGridCell(fromGridCell), PieceFromGridCell(toGridCell));
            }
        }
        #endregion

        #region Cell Helpers
        public Sequence? FindMatchFromCell(GridCellUI cellUI) => FindMatchFromCell(cellUI.Cell);
        public Sequence? FindMatchFromCell(GridCell cell) => Board.SequenceFinder.FindMatchFromCell(Board, cell);
        public List<Sequence> FindAllMatches() => Board.SequenceFinder.FindBoardSequences(Board);
        public List<PieceUI> PiecesFromSequence(GenericGodotWrapper<Sequence> sequenceWrapper) => PiecesFromSequence((Sequence)sequenceWrapper.Value);
#pragma warning disable 8619
        public List<PieceUI> PiecesFromSequence(Sequence sequence)
            => sequence.Cells.Select(PieceFromGridCell).RemoveNullables().RemoveDuplicates().ToList();
        public PieceUI? PieceFromGridCell(GridCell cell) => PieceUIFromPiece(cell.Piece);
        public PieceUI? PieceUIFromPiece(Piece piece) => DrawedPieces().FirstOrDefault(pieceUI => pieceUI.Piece.Id.Equals(piece.Id));

        public GridCellUI? GridCellUIFromCell(GridCell cell) => GridCells[cell.Column][cell.Row];
        public GridCellUI? GridCellUIFromPiece(PieceUI pieceUI) => GridCellUIFromPiece(pieceUI.Piece);
        public GridCellUI? GridCellUIFromPiece(Piece targetPiece) {
            return GridCellsFlattened.FirstOrDefault(cellUI => {
                return cellUI.Cell.Piece is Piece piece && targetPiece.Id.Equals(piece.Id);

            });
        }

        public List<GridCellUI> AdjacentCellsFrom(PieceUI pieceUI, bool includeDiagonals = false) {
            GridCellUI? originCellUI = GridCellUIFromPiece(pieceUI);

            if (originCellUI is not null && pieceUI.IsValid())
                return Board.AdjacentCellsFrom(originCellUI.Cell).Select(cell => GridCells[cell.Column][cell.Row]).ToList();

            return [];
        }

        public List<GridCellUI> CrossCells(PieceUI pieceUI) {
            if (GridCellUIFromPiece(pieceUI) is GridCellUI originCellUI)
                return Board.CrossCellsFrom(originCellUI.Cell).Select(cell => GridCells[cell.Column][cell.Row]).ToList();

            return [];
        }

        public List<GridCellUI> CrossDiagonalCells(PieceUI pieceUI) {
            if (GridCellUIFromPiece(pieceUI) is GridCellUI originCellUI)
                return Board.CrossDiagonalCellsFrom(originCellUI.Cell).Select(cell => GridCells[cell.Column][cell.Row]).ToList();

            return [];
        }
        #endregion

        #region Helpers
        public List<PieceUI> DrawedPieces() => GetTree().GetNodesInGroup(PieceUI.GROUP_NAME).Cast<PieceUI>().ToList();
        public List<GridCellUI> DrawedCells() => GetTree().GetNodesInGroup(GridCellUI.GROUP_NAME).Cast<GridCellUI>().ToList();

        public void Lock() {
            Locked = true;
        }
        public void Unlock() {
            Locked = false;
        }
        private void RemovePreviewSprites() {
            if (!Engine.IsEditorHint())
                _rootPreviewNode ??= GetNodeOrNull<Node2D>("PreviewGrid");

            _rootPreviewNode?.Free();
            _rootPreviewNode = null;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        #region Event callbacks

        private void OnConsumeRequested(PieceUI[] pieces) {
            if (Board.Locked)
                return;

            if (SwapMode.Equals(BoardMovements.CONNECT_LINE)) {
                Sequence matches = new(pieces.Select(piece => GridCellUIFromPiece(piece).Cell).ToList(), Sequence.SHAPES.LINE_CONNECTED);

                if (matches.Size() >= MinMatch)
                    FiniteStateMachine.ChangeStateTo<Consume>(new() { { "matches", new List<Sequence>() { matches } } });
            }

        }

        private void OnFilledBoard() {
            DrawBoard();

            GridCellsFlattened = GetTree()
                .GetNodesInGroup(GridCellUI.GROUP_NAME)
                .Cast<GridCellUI>()
                .Select(cell => cell)
                .ToList();

            foreach (int column in Enumerable.Range(0, GridWidth)) {
                GridCells.Add([]);

                foreach (int row in Enumerable.Range(0, GridHeight)) {
                    GridCells[column].Add(GridCellsFlattened.FirstOrDefault(cellUI => cellUI.Cell.Equals(Board.Cell(column, row))));
                }
            }
        }
        private void OnPieceSelected(PieceUI pieceUI) {
            if (Board.Locked || Locked)
                return;

            if (CurrentSelectedPiece is not null) {
                CurrentCellHighlighter.OnDeSelectedPiece(this, CurrentSelectedPiece);

                if (!CurrentSelectedPiece.Equals(pieceUI)) {
                    EmitSignal(SignalName.SwapRequested, CurrentSelectedPiece, pieceUI);
                    CurrentSelectedPiece = null;
                    return;
                }
            }

            CurrentSelectedPiece = pieceUI;
            CurrentCellHighlighter.OnSelectedPiece(this, pieceUI);
        }

        private void OnPieceUnSelected(PieceUI pieceUI) {
            if (Board.Locked || Locked)
                return;

            CurrentSelectedPiece = null;
            CurrentCellHighlighter.OnDeSelectedPiece(this, pieceUI);
        }

        private void OnBoardLocked() {
            if (LockedInformationLabel is not null)
                LockedInformationLabel.Text = nameof(Locked);
        }

        private void OnBoardUnlocked() {
            if (LockedInformationLabel is not null)
                LockedInformationLabel.Text = "Unlocked";
        }

        private void OnSwapRequested(PieceUI from, PieceUI to) {
            CurrentSelectedPiece = null;
            DrawedPieces().ForEach(piece => piece.IsSelected = false);

            if (!Board.Locked && from.IsValid() && to.IsValid())
                FiniteStateMachine.ChangeStateTo(nameof(Swap), new() { { "fromPiece", from }, { "toPiece", to } });
        }

        private void OnStateChanged(MachineState from, MachineState to) {
            if (StateInformationLabel is Label label)
                label.Text = $"{from.Name} -> [{to.Name}]";
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs eventArgs) {
            if (eventArgs.PropertyName is string propertyChanged) {
                if (propertyChanged.EqualsIgnoreCase(nameof(Locked))) {
                    if (Locked)
                        EmitSignal(SignalName.BoardLocked);
                    else
                        EmitSignal(SignalName.BoardUnlocked);
                }

                if (propertyChanged.EqualsIgnoreCase(nameof(CurrentCellHighlighter))) {
                    AddCellHighlighterToTree();
                }

                if (propertyChanged.EqualsIgnoreCase(nameof(CurrentPieceAnimator))) {
                    AddPieceAnimatorToTree();
                }

                if (propertyChanged.EqualsIgnoreCase(nameof(CurrentSequenceConsumer))) {
                    AddSequenceConsumerToTree();
                }
            }
        }

    }

    #endregion
}

