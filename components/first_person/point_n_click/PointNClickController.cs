using Godot;
using GodotExtensionator;


namespace GodotExtensionatorStarter {

    [Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointNClickController : Node3D {

        [Export] public float StandingStatureInMeters = 1.75f;

        public GlobalFade GlobalFade { get; set; } = default!;
        public AnimationPlayer AnimationPlayer { get; set; } = null!;
        public MouseRayCastInteractor MouseRayCastInteractor { get; set; } = null!;

        public Node3D Eyes { get; set; } = null!;
        public Camera3D Camera3D { get; set; } = null!;

        public Vector3 OriginalEyesPosition = Vector3.Zero;

        public override void _EnterTree() {
            GlobalFade = this.GetAutoloadNode<GlobalFade>();
            AnimationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
            MouseRayCastInteractor = GetNode<MouseRayCastInteractor>(nameof(MouseRayCastInteractor));
            Eyes = GetNode<Node3D>($"%{nameof(Eyes)}");
            Camera3D = GetNode<Camera3D>($"%{nameof(Camera3D)}");

            GlobalFade.FadeStarted += OnFadeStarted;
            GlobalFade.FadeFinished += OnFadeFinished;
        }


        public override void _Ready() {
            Position = Position with { Y = StandingStatureInMeters };
            OriginalEyesPosition = Eyes.Position;

            Camera3D.MakeCurrent();
            AnimationPlayer.Play("idle");
        }

        private void OnFadeStarted() {
            MouseRayCastInteractor.Disable();
        }

        private void OnFadeFinished() {
            MouseRayCastInteractor.Enable();
        }
    }
}
