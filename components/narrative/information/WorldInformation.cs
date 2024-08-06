using Godot;
using GodotExtensionator;


namespace GodotExtensionatorStarter {
    public partial class WorldInteractableInformation : Control, ITranslatable {
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;

        public Label InformationLabel { get; set; } = null!;
        public Interactable3D? CurrentInteractable { get; set; } = default!;

        public override void _ExitTree() {
            GlobalGameEvents.Focused -= OnWorldInteractableFocused;
            GlobalGameEvents.UnFocused -= OnWorldInteractableUnFocused;
            GlobalGameEvents.CanceledInteraction -= OnWorldInteractableUnFocused;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            GlobalGameEvents.Focused += OnWorldInteractableFocused;
            GlobalGameEvents.UnFocused += OnWorldInteractableUnFocused;
            GlobalGameEvents.CanceledInteraction += OnWorldInteractableUnFocused;

            InformationLabel = GetNode<Label>($"%{nameof(InformationLabel)}");
            InformationLabel.Text = string.Empty;

            MouseFilter = MouseFilterEnum.Ignore;
        }

        private void OnWorldInteractableFocused(GodotObject interactor) {
            if (interactor is IInteractor _interactor) {
                CurrentInteractable = _interactor.CurrentInteractable;

                if (CurrentInteractable is not null)
                    InformationLabel.Text = Tr(CurrentInteractable.Title);
            }
        }

        private void OnWorldInteractableUnFocused(GodotObject interactor) {
            if (interactor is IInteractor) {
                CurrentInteractable = null;
                InformationLabel.Text = string.Empty;
            }
        }

        public void OnLocaleChanged() {
            if (CurrentInteractable is not null)
                InformationLabel.Text = Tr(CurrentInteractable.Title);
        }
    }

}