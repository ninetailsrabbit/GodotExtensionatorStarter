using Godot;


namespace GodotExtensionatorStarter {
    public partial class InteractionPointer : Control {
        [Export] public Vector2 MinimumSize { get; set; } = new(64, 64);
        [Export] public CompressedTexture2D DefaultPointerTexture { get; set; } = default!;

        public TextureRect CurrentPointer { get; set; } = default!;

        public override void _EnterTree() {
            MouseFilter = MouseFilterEnum.Pass;

            CurrentPointer = GetNode<TextureRect>($"%{nameof(CurrentPointer)}");
            CurrentPointer.Texture = DefaultPointerTexture;
            CurrentPointer.ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
            CurrentPointer.CustomMinimumSize = MinimumSize;
        }

    }


}