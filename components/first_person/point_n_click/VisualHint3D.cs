using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/point_n_click/visual_hint_3d.svg")]
    public partial class VisualHint3D : Node3D {

        [Export] public float ImageHintVisibleOnMeters = 3f;
        [Export] public float LabelHintVisibleOnMeters = 3f;
        [Export] public BaseMaterial3D.BillboardModeEnum LabelBillBoardMode = BaseMaterial3D.BillboardModeEnum.FixedY;
        [Export] public BaseMaterial3D.BillboardModeEnum ImageBillBoardMode = BaseMaterial3D.BillboardModeEnum.FixedY;
        [Export] public Label3D ScreenLabelInformation { get; set; } = default!;
        [Export] public Sprite3D ImageHint { get; set; } = default!;
        [Export] public CompressedTexture2D NormalHintTexture { get; set; } = default!;
        [Export] public CompressedTexture2D FocusHintTexture { get; set; } = default!;
        [Export] public Interactable3D InteractableRelated { get; set; } = null!;



        public override void _ExitTree() {
            InteractableRelated.Focused -= OnFocused;
            InteractableRelated.UnFocused -= OnUnFocused;
            InteractableRelated.CanceledInteraction -= OnUnFocused;
        }

        public override void _EnterTree() {
            ScreenLabelInformation = this.FirstNodeOfType<Label3D>();
            ImageHint = this.FirstNodeOfType<Sprite3D>();

            ArgumentNullException.ThrowIfNull(InteractableRelated);

            InteractableRelated.Focused += OnFocused;
            InteractableRelated.UnFocused += OnUnFocused;
            InteractableRelated.CanceledInteraction += OnUnFocused;
        }

        public override void _Ready() {
            if (ImageHint is not null) {
                ImageHint.Texture = NormalHintTexture;
                ImageHint.Billboard = ImageBillBoardMode;
                ImageHint.RenderPriority = 2;
                ImageHint.Transparent = true;
                ImageHint.NoDepthTest = true;
                ImageHint.VisibilityRangeEnd = ImageHintVisibleOnMeters;
            }

            if (ScreenLabelInformation is not null) {
                ScreenLabelInformation.Hide();
                ScreenLabelInformation.RenderPriority = 2;
                ScreenLabelInformation.Billboard = LabelBillBoardMode;
                ScreenLabelInformation.VisibilityRangeEnd = LabelHintVisibleOnMeters;
            }
        }

        private void OnFocused(GodotObject interactor) {
            if (ImageHint is not null && FocusHintTexture is not null)
                ImageHint.Texture = FocusHintTexture;

            ScreenLabelInformation?.Show();
        }

        private void OnUnFocused(GodotObject interactor) {
            if (ImageHint is not null && NormalHintTexture is not null)
                ImageHint.Texture = NormalHintTexture;

            ScreenLabelInformation?.Hide();
        }

    }
}
