using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickMovement : PointAndClickInteraction {
        [Signal]
        public delegate void ActorMovedToThisPositionEventHandler(Marker3D targetPosition);

        [Export] public float FadeTimeOnMovement = 0.5f;

        public GlobalFade GlobalFade { get; set; } = default!;
        public Marker3D TargetPositionMarker { get; set; } = null!;

        public override void _EnterTree() {
            base._EnterTree();

            GlobalFade = this.GetAutoloadNode<GlobalFade>();

            FocusCursor ??= Preloader.Instance.CursorStep;

            TargetPositionMarker = this.FirstNodeOfType<Marker3D>();
        }

        public async void MoveActorToThisPoint() {
            GlobalFade.FadeIn(FadeTimeOnMovement);
            await ToSignal(GlobalFade, GlobalFade.SignalName.FadeFinished);

            Actor.AlignWithNode(TargetPositionMarker);
            Actor.ApplyStandingStature();

            GlobalFade.FadeOut(FadeTimeOnMovement);

            EmitSignal(SignalName.ActorMovedToThisPosition, TargetPositionMarker);
            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ActorMovedToPointAndClickPosition, this);
        }


        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {
                MoveActorToThisPoint();
            }
        }
    }
}
