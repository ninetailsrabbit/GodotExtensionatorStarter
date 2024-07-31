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

        [Export] public PointNClickController Actor { get; set; } = default!;
        [Export] public InteractionType SelectedInteractionType = InteractionType.SCAN;
        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export] public CompressedTexture2D FocusCursor { get; set; } = default!;

        public GlobalFade GlobalFade { get; set; } = default!;
        public Interactable3D Interactable3D { get; set; } = null!;
        public Marker3D TargetPositionMarker { get; set; } = default!;

        public override void _ExitTree() {
            Interactable3D.Focused -= OnFocused;
            Interactable3D.UnFocused -= OnUnFocused;
            Interactable3D.CanceledInteraction -= OnCanceledInteraction;
            Interactable3D.Interacted -= OnInteracted;
        }

        public override void _EnterTree() {
            GlobalFade = this.GetAutoloadNode<GlobalFade>();
            Actor ??= GetTree().GetFirstNodeInGroup(PointNClickController.GroupName) as PointNClickController;

            Interactable3D = GetNode<Interactable3D>(nameof(Interactable3D));
            Interactable3D.Focused += OnFocused;
            Interactable3D.UnFocused += OnUnFocused;
            Interactable3D.CanceledInteraction += OnCanceledInteraction;
            Interactable3D.Interacted += OnInteracted;

            FocusCursor ??= DefaultCursors[SelectedInteractionType];

            if (SelectedInteractionType.Equals(InteractionType.MOVEMENT))
                TargetPositionMarker = this.FirstNodeOfType<Marker3D>();

            InputExtension.ShowMouseCursor();
        }

        public void MoveActorToNewPosition(Marker3D targetPosition) {
            var originalParent = Actor.GetParent();
            Actor.Reparent(TargetPositionMarker, false);
            Actor.Position = Vector3.Zero;
            Actor.Rotation = Vector3.Zero;

            Actor.Reparent(originalParent);
            Actor.ApplyStandingStature();
        }

        private void OnFocused(GodotObject interactor) {
            if (FocusCursor is not null) {
                Input.SetCustomMouseCursor(FocusCursor, SelectedCursorShape, FocusCursor.GetSize() / 2);
            }
        }
        private void OnUnFocused(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }

        private async void OnInteracted(GodotObject interactor) {
            switch (SelectedInteractionType) {
                case InteractionType.MOVEMENT:
                    GlobalFade.FadeIn(0.5f);
                    await ToSignal(GlobalFade, GlobalFade.SignalName.FadeFinished);

                    MoveActorToNewPosition(TargetPositionMarker);

                    GlobalFade.FadeOut(0.5f);
                    break;
            }
        }

        private void OnCanceledInteraction(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }
    }
}
