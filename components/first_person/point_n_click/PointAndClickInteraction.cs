using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    public abstract partial class PointAndClickInteraction : Node3D {

        public const string GroupName = "point_and_click_interaction";

        [Export] public StringName InteractionId = string.Empty;
        [Export] public PointAndClickController Actor { get; set; } = default!;

        [Export] public Input.CursorShape SelectedCursorShape = Input.CursorShape.Arrow;
        [Export(PropertyHint.Range, "0, 360f, 0.1f")] public float CameraVerticalRotationLimit { get; set; } = 89f;
        // 0 means 'no limit'
        [Export(PropertyHint.Range, "0, 360f, 0.1f")] public float CameraHorizontalRotationLimit { get; set; } = 0f;

        public GameGlobals GameGlobals { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public Interactable3D Interactable3D { get; set; } = null!;

        public override void _ExitTree() {
            Interactable3D.CanceledInteraction -= OnCanceledInteraction;
            Interactable3D.Interacted -= OnInteracted;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();

            Actor ??= GetTree().GetFirstNodeInGroup(PointAndClickController.GroupName) as PointAndClickController;

            Interactable3D = GetNode<Interactable3D>(nameof(Interactable3D));

            ArgumentNullException.ThrowIfNull(Interactable3D);

            Interactable3D.CanceledInteraction += OnCanceledInteraction;
            Interactable3D.Interacted += OnInteracted;
        }

        protected virtual void OnInteracted(GodotObject interactor) {
            if (Actor.CanMoveCamera)
                Actor.ChangeCameraRotationLimit(CameraHorizontalRotationLimit, CameraVerticalRotationLimit);
            else
                Actor.ReturnCameraRotationLimitToDefault();


            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.PointAndClickInteracted, this);
        }

        protected virtual void OnCanceledInteraction(GodotObject interactor) {
            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.PointAndClickInteractionCanceled, this);
        }
    }
}
