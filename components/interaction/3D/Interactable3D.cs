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
        [Export] public bool KeepInteractableWhenUnFocus = false;

        [ExportGroup("Pointers")]
        [Export] public CompressedTexture2D FocusPointer { get; set; } = default!;
        [Export] public CompressedTexture2D InteractPointer { get; set; } = default!;

        [ExportGroup("Information")]
        [Export] public string Title = string.Empty;
        [Export] public string Description = string.Empty;
        [Export] public CATEGORY Category;

        [ExportGroup("Scan")]
        [Export] public bool Scannable = false;

        [ExportGroup("Pickup")]
        [Export] public bool Pickable = false;
        [Export] public string PickupMessage = string.Empty;
        [Export] public float PullPower = 20f;
        [Export] public float ThrowPower = 10f;

        [ExportGroup("Usable")]
        [Export] public bool Usable = false;
        [Export] public string UsableMessage = string.Empty;

        [ExportGroup("Inventory")]
        [Export] public bool CanBeSaved = false;
        [Export] public string InventorySaveMessage = string.Empty;

        [ExportGroup("Player")]
        [Export] public bool LockPlayer = false;

        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;


        public int TimesInteracted {
            get => _timesInteracted;
            set {
                int previousValue = TimesInteracted;
                _timesInteracted = value;

                if (previousValue != TimesInteracted && TimesInteracted.Equals(NumberOfTimesYouCanInteract))
                    EmitSignal(SignalName.InteractionLimitReached);

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

            FocusPointer ??= Preloader.Instance.DefaultFocusPointer;

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

        public bool CanBeSavedOnInventory() {
            return CanBeSaved;
        }
        private void OnInteracted(GodotObject interactor) {
            if (interactor is IInteractor _) {

                if (NumberOfTimesYouCanInteract.IsGreaterThanZero())
                    TimesInteracted += 1;

                if (LockPlayer)
                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.LockPlayer, this);

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.Interacted, interactor);
            }
        }
        private void OnCancelInteraction(GodotObject interactor) {
            if (interactor is IInteractor _) {
                if (LockPlayer)
                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.UnlockPlayer, this);

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.CanceledInteraction, interactor);
            }
        }
        private void OnUnFocused(GodotObject interactor) {
            if (interactor is IInteractor _)
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.UnFocused, interactor);
        }

        private void OnFocused(GodotObject interactor) {
            if (interactor is IInteractor _)
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.Focused, interactor);

        }

        private void OnInteractionLimitedReached() {
            Deactivate();
        }

    }
}