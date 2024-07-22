using Godot;


namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class DraggableSprite2D : Sprite2D {

        #region Signals
        [Signal]
        public delegate void DragStartedEventHandler();

        [Signal]
        public delegate void DragEndedEventHandler();

        [Signal]
        public delegate void DragEnabledEventHandler();

        [Signal]
        public delegate void DragDisabledEventHandler();

        [Signal]
        public delegate void MouseReleasedEventHandler();

        [Signal]
        public delegate void PickedUpChangedEventHandler(bool picked);
        #endregion

        [Export] public bool ResetPositionOnRelease = true;
        [Export] public bool OneClickDrag = false;
        [Export] public float SmoothFactor = 20f;
        [Export]
        public string DragAction {
            get => _dragAction; set {
                _dragAction = value;

                SetProcess(InputMap.HasAction(_dragAction));
            }
        }

        public Button MouseRegion { get; set; } = default!;
        public Vector2 CurrentPosition = Vector2.Zero;
        public Vector2 MOffset = Vector2.Zero;

        public bool DragActive {
            get => _dragActive; set {
                if (_dragActive != value) {

                    if (value)
                        EmitSignal(SignalName.DragEnabled);
                    else
                        EmitSignal(SignalName.DragDisabled);

                    _dragActive = value;
                }
            }
        }

        public bool PickedUp {
            get => _pickedUp; set {

                if (_pickedUp != value) {
                    EmitSignal(SignalName.PickedUpChanged, value);


                    if (value) {
                        EmitSignal(SignalName.DragStarted);
                    }
                    else {
                        EmitSignal(SignalName.DragEnded);
                        ResetPosition();
                    }
                }

                _pickedUp = value;
            }
        }

        public Vector2 OriginalGlobalPosition = Vector2.Zero;
        public Vector2 OriginalPosition = Vector2.Zero;

        private bool _dragActive = true;
        private string _dragAction = "drag";
        private bool _pickedUp = false;

        public override void _ExitTree() {
            MouseReleased -= OnMouseReleased;
            TextureChanged -= OnTextureChanged;
        }
        public override void _EnterTree() {
            base._EnterTree();

            MouseReleased += OnMouseReleased;
            TextureChanged += OnTextureChanged;
        }

        public override void _Ready() {
            if (MouseRegion is null) {
                MouseRegion = new();
                MouseRegion.SelfModulate = MouseRegion.SelfModulate with { A = 0f };
                AddChild(MouseRegion);
            }

            MouseRegion.ButtonDown += OnMouseRegionPressed;

            OriginalGlobalPosition = GlobalPosition;
            OriginalPosition = Position;

            ResizeMouseRegion();
            SetProcess(InputMap.HasAction(DragAction));
        }

        public override void _Process(double delta) {
            if (Input.IsActionJustReleased(DragAction) && PickedUp)
                EmitSignal(SignalName.MouseReleased);

            else if (MouseRegion.ButtonPressed) {
                GlobalPosition = SmoothFactor > 0 ?
                    GlobalPosition.Lerp(GetGlobalMousePosition(), (float)(SmoothFactor * delta)) :
                    GetGlobalMousePosition();

                CurrentPosition = GlobalPosition + MOffset;
            }
        }

        public void ResetPosition() {
            if (IsInsideTree()) {
                GlobalPosition = OriginalGlobalPosition;
                Position = OriginalPosition;
            }

        }

        public void ResizeMouseRegion() {
            MouseRegion.Position = Vector2.Zero;
            MouseRegion.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
        }


        #region Signal Callbacks

        private void OnMouseRegionPressed() {
            PickedUp = true;

            if (IsInsideTree())
                MOffset = Transform.Origin - GetGlobalMousePosition();
        }

        private void OnMouseReleased() {
            PickedUp = false;
        }

        private void OnTextureChanged() {
            if (Texture is not null)
                ResizeMouseRegion();
        }
        #endregion
    }

}