using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/interaction/interactor_3d.svg")]
    public partial class RayCastInteractor3D : RayCast3D, IInteractor {

        [Export] public string InputAction = "interact";

        public Interactable3D? CurrentInteractable;
        public bool Focused = false;
        public bool Interacting = false;

        public GameGlobals GameGlobals { get; set; } = default!;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            Enabled = true;
            ExcludeParent = true;
            CollisionMask = GameGlobals.InteractablesCollisionLayer;
            CollideWithAreas = true;
            CollideWithBodies = false;
        }

        public override void _UnhandledInput(InputEvent @event) {
            if (InputMap.HasAction(InputAction)
                && Input.IsActionJustPressed(InputAction)
                && CurrentInteractable is not null
                && !Interacting) {
                Interact(CurrentInteractable);
            }
        }

        public void Interact(GodotObject interactable) {
            if (interactable is Interactable3D _interactable) {

                if (_interactable.IsScannable()) {
                    Interacting = true;
                    Enabled = true;
                }

                _interactable.EmitSignalSafe(Interactable3D.SignalName.Interacted, this);

            }
        }

        public void CancelInteract(GodotObject interactable) {
            if (interactable is Interactable3D _interactable) {
                Interacting = false;

                if (_interactable.IsScannable())
                    Enabled = false;


                _interactable.EmitSignalSafe(Interactable3D.SignalName.CanceledInteraction, this);
            }

        }

        public void Focus(GodotObject interactable) {
            if (interactable is Interactable3D _interactable) {
                CurrentInteractable = _interactable;

                Focused = true;

                _interactable.EmitSignalSafe(Interactable3D.SignalName.Focused, this);
            }
        }

        public void UnFocus(GodotObject interactable) {
            if (interactable is Interactable3D _interactable) {

                _interactable.EmitSignalSafe(Interactable3D.SignalName.UnFocused, this);

                CurrentInteractable = null;
                Focused = false;
            }
        }
    }
}