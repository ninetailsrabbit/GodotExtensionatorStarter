using Godot;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickObjectScanner : PointAndClickInteraction {

        [Export] public Node3D TargetObjectToScan { get; set; } = null!;
        [Export] public float DistanceFromCamera = 0.75f;

        public bool IsScanningObject = false;

        public Node OriginalParent { get; set; } = default!;

        public override void _EnterTree() {
            base._EnterTree();

            FocusCursor ??= Preloader.Instance.CursorLook;

            ArgumentNullException.ThrowIfNull(TargetObjectToScan);

            OriginalParent = TargetObjectToScan.GetParent();

            Interactable3D.Scannable = true;
        }

        protected override void OnInteracted(GodotObject interactor) {
            TargetObjectToScan.Reparent(Actor.Camera3D);

            var tween = CreateTween();
            tween.TweenProperty(TargetObjectToScan, Node3D.PropertyName.Position.ToString(), Vector3.Forward * DistanceFromCamera, 0.65f).From(TargetObjectToScan.Position)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Linear);

            Actor.UseAnimations = false;
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            base.OnCanceledInteraction(interactor);

            TargetObjectToScan.Reparent(OriginalParent);

            var tween = CreateTween();
            tween.TweenProperty(TargetObjectToScan, Node3D.PropertyName.Position.ToString(), Vector3.Zero, 0.55f)
                .SetEase(Tween.EaseType.OutIn).SetTrans(Tween.TransitionType.Sine);

            Actor.UseAnimations = true;
        }
    }
}
