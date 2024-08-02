using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    public abstract partial class PointAndClickInteraction : Node3D {

        public const string GroupName = "point_and_click_interaction";

        [Export] public StringName InteractionId = string.Empty;
        [Export] public PointAndClickController Actor { get; set; } = default!;

        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export] public CompressedTexture2D FocusCursor { get; set; } = default!;

        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public GlobalFade GlobalFade { get; set; } = default!;
        public GlobalCameraShifter GlobalCameraShifter { get; set; } = default!;

        public Interactable3D Interactable3D { get; set; } = null!;

        public override void _ExitTree() {
            Interactable3D.Focused -= OnFocused;
            Interactable3D.UnFocused -= OnUnFocused;
            Interactable3D.CanceledInteraction -= OnCanceledInteraction;
            Interactable3D.Interacted -= OnInteracted;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            GlobalFade = this.GetAutoloadNode<GlobalFade>();
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            GlobalCameraShifter = this.GetAutoloadNode<GlobalCameraShifter>();

            Actor ??= GetTree().GetFirstNodeInGroup(PointAndClickController.GroupName) as PointAndClickController;

            Interactable3D = this.FirstNodeOfClass<Interactable3D>();

            ArgumentNullException.ThrowIfNull(Interactable3D);

            Interactable3D.Focused += OnFocused;
            Interactable3D.UnFocused += OnUnFocused;
            Interactable3D.CanceledInteraction += OnCanceledInteraction;
            Interactable3D.Interacted += OnInteracted;
        }

        protected virtual void OnFocused(GodotObject interactor) {
            if (FocusCursor is not null)
                Input.SetCustomMouseCursor(FocusCursor, SelectedCursorShape, FocusCursor.GetSize() / 2);
        }

        protected virtual void OnUnFocused(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }

        protected virtual void OnInteracted(GodotObject interactor) { }

        protected virtual void OnCanceledInteraction(GodotObject interactor) {
            Actor.MouseRayCastInteractor.DisplayCustomCursor();
        }
    }
}
