using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickMovement : PointAndClickInteraction {
        [Signal]
        public delegate void ActorMovedToThisPositionEventHandler(Marker3D targetPosition);

        [Export] public Marker3D TargetPositionMarker { get; set; } = null!;
        [Export] public PointAndClickMovement PreviousMovementPoint { get; set; } = default!;

        [Export] public float FadeTimeOnMovement = 0.5f;

        public GlobalFade GlobalFade { get; set; } = default!;

        public override void _EnterTree() {
            base._EnterTree();

            GlobalFade = this.GetAutoloadNode<GlobalFade>();

            TargetPositionMarker = this.FirstNodeOfType<Marker3D>();

            ArgumentNullException.ThrowIfNull(TargetPositionMarker);
        }

        public async void MoveActorToPoint(PointAndClickMovement? targetPoint = null) {
            targetPoint ??= this;

            GlobalFade.FadeIn(targetPoint.FadeTimeOnMovement);
            await ToSignal(GlobalFade, GlobalFade.SignalName.FadeFinished);

            Actor.AlignWithNode(targetPoint.TargetPositionMarker);
            Actor.ApplyStandingStature();

            Actor.Camera3D.MakeCurrent();
            Actor.MouseRayCastInteractor.ReturnToOriginalCamera();

            GlobalFade.FadeOut(targetPoint.FadeTimeOnMovement);

            EmitSignal(SignalName.ActorMovedToThisPosition, targetPoint.TargetPositionMarker);
            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ActorMovedToPointAndClickPosition, this);
        }

        public void MoveActorToPreviousPoint() {
            if (PreviousMovementPoint is not null) {
                MoveActorToPoint(PreviousMovementPoint);
            }
        }

        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {
                base.OnInteracted(interactor);

                MoveActorToPoint();
            }
        }
    }
}
