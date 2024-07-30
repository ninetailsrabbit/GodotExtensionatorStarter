using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointNClickInteraction : Node3D {
        public enum InteractionType {
            MOVEMENT,
            GRAB,
            ZOOM,
            SCAN,
            CINEMATIC,
            DIALOGUE
        }

        public Dictionary<InteractionType, CompressedTexture2D> DefaultCursors = new() {
            {InteractionType.MOVEMENT, Preloader.Instance.CursorStep },
            {InteractionType.GRAB, Preloader.Instance.CursorHandThinOpen },
            {InteractionType.ZOOM, Preloader.Instance.CursorZoom },
            {InteractionType.SCAN, Preloader.Instance.CursorZoom },
            {InteractionType.DIALOGUE, Preloader.Instance.CursorDialogue },
            {InteractionType.CINEMATIC, Preloader.Instance.CursorHelp},
        };

        [Export] public PointNClickController PointNClickController { get; set; } = default!;
        [Export] public InteractionType SelectedInteractionType = InteractionType.SCAN;
        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export] public CompressedTexture2D FocusCursor { get; set; } = default!;

        public Interactable3D Interactable3D { get; set; } = null!;

        public override void _ExitTree() {
            Interactable3D.Focused -= OnFocused;
            Interactable3D.UnFocused -= OnUnFocused;
            Interactable3D.CanceledInteraction -= OnCanceledInteraction;
            Interactable3D.Interacted -= OnInteracted;
        }

        public override void _EnterTree() {
            PointNClickController ??= GetTree().GetFirstNodeInGroup(PointNClickController.GroupName) as PointNClickController;

            Interactable3D = GetNode<Interactable3D>(nameof(Interactable3D));
            Interactable3D.Focused += OnFocused;
            Interactable3D.UnFocused += OnUnFocused;
            Interactable3D.CanceledInteraction += OnCanceledInteraction;
            Interactable3D.Interacted += OnInteracted;

            FocusCursor ??= DefaultCursors[SelectedInteractionType];

            InputExtension.ShowMouseCursor();
        }


        private void OnFocused(GodotObject interactor) {
            GD.Print("FOCUS");
            if (FocusCursor is not null) {
                Input.SetCustomMouseCursor(FocusCursor, SelectedCursorShape, FocusCursor.GetSize() / 2);
            }
        }
        private void OnUnFocused(GodotObject interactor) {
            GD.Print("UNFOCUS");

            PointNClickController.MouseRayCastInteractor.DisplayCustomCursor();
        }

        private void OnInteracted(GodotObject interactor) {

        }

        private void OnCanceledInteraction(GodotObject interactor) {

        }
    }
}
