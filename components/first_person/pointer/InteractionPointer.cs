using Godot;
using GodotExtensionator;


namespace GodotExtensionatorStarter {
    public partial class InteractionPointer : Control {
        [Export] public Vector2 MinimumSize { get; set; } = new(64, 64);
        [Export] public CompressedTexture2D DefaultPointerTexture { get; set; } = default!;

        public TextureRect CurrentPointer { get; set; } = default!;

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            DefaultPointerTexture ??= Preloader.Instance.DefaultPointer;

            MouseFilter = MouseFilterEnum.Pass;

            CurrentPointer = GetNode<TextureRect>($"%{nameof(CurrentPointer)}");
            CurrentPointer.Texture = DefaultPointerTexture;
            CurrentPointer.ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
            CurrentPointer.CustomMinimumSize = MinimumSize;

            GlobalGameEvents.Focused += OnFocusedInteractable;
            GlobalGameEvents.UnFocused += OnUnFocusedInteractable;
        }

        private void OnFocusedInteractable(GodotObject _interactor) {
            if(_interactor is RayCastInteractor3D interactor) {
                CurrentPointer.Texture = interactor?.CurrentInteractable?.FocusPointer;
            }
        }

        private void OnUnFocusedInteractable(GodotObject _interactor) {
            if (_interactor is RayCastInteractor3D interactor) {
                CurrentPointer.Texture = DefaultPointerTexture;
            }
        }
    }


}