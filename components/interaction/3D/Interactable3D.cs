using Extensionator;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/interaction/interactable.svg")]
    public partial class Interactable3D : Area3D {
        #region Signals
        [Signal]
        public delegate void FocusedEventHandler(GodotObject interactor);
        [Signal]
        public delegate void UnFocusedEventHandler(GodotObject interactor);
        [Signal]
        public delegate void InteractedEventHandler(GodotObject interactor);
        [Signal]
        public delegate void CanceledInteractionEventHandler(GodotObject interactor);
        [Signal]
        public delegate void InteractionLimitReachedEventHandler();

        #endregion

        public enum CATEGORY {
            DOOR,
            WINDOW,
            OBJECT,
            ITEM,
            WEAPON,
            KEY
        }

        // Set to zero to use infinitely this interactable
        [Export] public int NumberOfTimesYouCanInteract = 0;
        [Export] public bool ChangeCursor = true;
        [Export] public bool ChangeScreenPointer = false;

        [ExportGroup("Pointers and cursors")]
        [Export] public CompressedTexture2D FocusCursor { get; set; } = Preloader.Instance.CursorLook;
        [Export] public CompressedTexture2D InteractCursor { get; set; } = default!;
        [Export] public CompressedTexture2D FocusScreenPointer { get; set; } = Preloader.Instance.DefaultFocusPointer;
        [Export] public CompressedTexture2D InteractScreenPointer { get; set; } = default!;

        [ExportGroup("Information")]
        [Export] public StringName Id = string.Empty;
        [Export] public string Title = string.Empty;
        [Export] public string Description = string.Empty;
        [Export] public string TranslationKey = string.Empty;
        [Export] public CATEGORY Category;

        [ExportGroup("Scan")]
        [Export] public bool Scannable = false;
        [Export] public bool CanBeRotatedOnScan = false;

        [ExportGroup("Pickup")]
        [Export] public bool Pickable = false;
        [Export] public string PickupMessage = string.Empty;
        [Export] public string PickupTranslationKey = string.Empty;
        [Export] public float PullPower = 20f;
        [Export] public float ThrowPower = 10f;

        [ExportGroup("Usable")]
        [Export] public bool Usable = false;
        [Export] public string UsableMessage = string.Empty;
        [Export] public string UsableMessageTranslationKey = string.Empty;

        [ExportGroup("Inventory")]
        [Export] public int Slots = 1;
        [Export] public bool CanBeSaved = false;
        [Export] public string InventorySaveMessage = string.Empty;
        [Export] public string InventorySaveMessageTranslationKey = string.Empty;

        [ExportGroup("Player")]
        [Export] public bool LockPlayerOnInteraction = false;

        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public CursorManager CursorManager { get; set; } = default!;

        public int TimesInteracted {
            get => _timesInteracted;
            set {
                int previousValue = TimesInteracted;
                _timesInteracted = value;

                if (IsNodeReady() && previousValue != TimesInteracted && TimesInteracted.Equals(NumberOfTimesYouCanInteract)) {
                    EmitSignal(SignalName.InteractionLimitReached);
                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.InteractableInteractionLimitReached, this);
                    Deactivate();
                }

            }
        }

        private int _timesInteracted = 0;

        public override void _ExitTree() {
            Interacted -= OnInteracted;
            CanceledInteraction -= OnCancelInteraction;
            Focused -= OnFocused;
            UnFocused -= OnUnFocused;
            InteractionLimitReached -= OnInteractionLimitedReached;
        }

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            CursorManager = this.GetAutoloadNode<CursorManager>();

            Priority = 3;
            CollisionLayer = GameGlobals.InteractablesCollisionLayer;
            CollisionMask = 0;
            Monitoring = false;
            Monitorable = true;

            Interacted += OnInteracted;
            CanceledInteraction += OnCancelInteraction;
            Focused += OnFocused;
            UnFocused += OnUnFocused;
            InteractionLimitReached += OnInteractionLimitedReached;
        }

        public void Activate() {
            CollisionLayer = GameGlobals.InteractablesCollisionLayer;
            Monitorable = true;
            TimesInteracted = 0;
        }

        public void Deactivate() {
            CollisionLayer = 0;
            Monitorable = false;
        }

        public bool IsScannable() => Scannable;
        public bool IsPickable() => Pickable;
        public bool IsUsable() => Usable;

        public bool CanBeSavedOnInventory() => CanBeSaved;

        private void OnInteracted(GodotObject interactor) {
            if (interactor is IInteractor _interactor) {

                if (NumberOfTimesYouCanInteract.IsGreaterThanZero())
                    TimesInteracted += 1;

                if (LockPlayerOnInteraction)
                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.LockPlayer, this);

                if (_interactor is MouseRayCastInteractor && ChangeCursor && InteractCursor is not null)
                    CursorManager.ChangeCursorTo(InteractCursor);

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.Interacted, interactor);
            }
        }
        private void OnCancelInteraction(GodotObject interactor) {
            if (interactor is IInteractor _interactor) {
                if (LockPlayerOnInteraction)
                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.UnlockPlayer, this);

                if (_interactor is MouseRayCastInteractor && ChangeCursor)
                    CursorManager.ReturnCursorToDefault();

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.CanceledInteraction, interactor);
            }
        }
        private void OnUnFocused(GodotObject interactor) {
            if (interactor is IInteractor _interactor) {
                if (_interactor is MouseRayCastInteractor && ChangeCursor)
                    CursorManager.ReturnCursorToDefault();

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.UnFocused, interactor);

            }
        }

        private void OnFocused(GodotObject interactor) {
            if (interactor is IInteractor _interactor) {
                if (_interactor is MouseRayCastInteractor && ChangeCursor && FocusCursor is not null)
                    CursorManager.ChangeCursorTo(FocusCursor);

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.Focused, interactor);
            }

        }

        private void OnInteractionLimitedReached() {
            Deactivate();
        }

    }
}