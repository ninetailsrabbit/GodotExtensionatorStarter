using Godot;

namespace GodotExtensionatorStarter {
    public abstract partial class Door : Node3D {
        #region Signals
        [Signal]
        public delegate void OpenedEventHandler();
        [Signal]
        public delegate void ClosedEventHandler();
        [Signal]
        public delegate void LockedEventHandler();
        [Signal]
        public delegate void UnlockedEventHandler();
        [Signal]
        public delegate void TriedToOpenLockedDoorEventHandler();
        [Signal]
        public delegate void WrongKeyUsedDoorEventHandler();

        #endregion

        [ExportGroup("Interaction parameters")]
        public bool IsOpen {
            get => _isOpen;
            set {
                if (value != _isOpen)
                    EmitSignal(value ? SignalName.Opened : SignalName.Closed);

                _isOpen = value;
            }
        }

        public bool IsLocked {
            get => _isLocked;
            set {
                if (value != _isLocked)
                    EmitSignal(value ? SignalName.Locked : SignalName.Unlocked);

                _isLocked = value;
            }
        }
        [Export] public string DoorName = "Door";
        [Export] public string KeyId { get; set; } = string.Empty;
        [Export] public float DelayBeforeClose = 0f;
        [Export] public AnimationPlayer AnimationPlayer { get; set; } = default!;
        [Export] public string OpenDoorAnimationName = "open";
        [Export] public Interactable3D Interactable3D { get; set; } = default!;

        private bool _isOpen = false;
        private bool _isLocked = false;

        public override void _ExitTree() {
            if (Interactable3D is not null) {
                Interactable3D.Interacted -= OnInteracted;
                Interactable3D.Focused -= OnFocused;
                Interactable3D.UnFocused -= OnUnFocused;
            }
        }

        public override void _EnterTree() {
            AnimationPlayer ??= GetNode<AnimationPlayer>(nameof(AnimationPlayer));
            Interactable3D ??= GetNode<Interactable3D>(nameof(Interactable3D));

            if (Interactable3D is not null) {
                Interactable3D.Interacted += OnInteracted;
                Interactable3D.Focused += OnFocused;
                Interactable3D.UnFocused += OnUnFocused;

            }
        }

        protected virtual void Open() {
            if (IsLocked)
                EmitSignal(SignalName.TriedToOpenLockedDoor);

            if (!IsLocked && !IsOpen) {
                AnimationPlayer.Play(OpenDoorAnimationName);
                IsOpen = true;
            }
        }
        protected virtual async void Close() {
            if (!IsLocked && DelayBeforeClose > 0 && IsOpen)
                await ToSignal(GetTree().CreateTimer(DelayBeforeClose), Timer.SignalName.Timeout);

            AnimationPlayer.PlayBackwards(OpenDoorAnimationName);
            IsOpen = false;
        }
        protected virtual void Unlock() { }
        protected virtual void Lock() { }


        private void OnInteracted(GodotObject interactor) {
            if (interactor is IInteractor) {
                if (IsOpen)
                    Close();
                else
                    Open();
            }
        }

        private void OnFocused(GodotObject interactor) {
            if (interactor is IInteractor) {
                if (Interactable3D.FocusPointer is not null)
                    Input.SetCustomMouseCursor(Interactable3D.FocusPointer, Input.CursorShape.Arrow, Interactable3D.FocusPointer.GetSize() / 2);
            }
        }

        private void OnUnFocused(GodotObject interactor) {
            if (interactor is IInteractor) {
               // TODO - CREATE A GLOBAL CUSTOM CURSOR MANAGER TO NOT REPEAT LOGIC
            }
        }
    }
}