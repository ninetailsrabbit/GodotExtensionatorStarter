using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickCameraShifter : PointAndClickInteraction {

        [Export] public Camera3D CameraToShift { get; set; } = null!;
        [Export] public float TransitionDuration = 1.5f;

        public GlobalCameraShifter GlobalCameraShifter { get; set; } = default!;

        public override void _EnterTree() {
            base._EnterTree();

            GlobalCameraShifter = this.GetAutoloadNode<GlobalCameraShifter>();

            FocusCursor ??= Preloader.Instance.CursorLook;

            CameraToShift ??= this.FirstNodeOfType<Camera3D>();

            ArgumentNullException.ThrowIfNull(CameraToShift);

        }


        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor &&
                !GlobalCameraShifter.IsTransitioning3D() &&
                !GetViewport().GetCamera3D().Equals(CameraToShift)) {

                base.OnInteracted(interactor);

                GlobalCameraShifter.TransitionToRequestedCamera3D(Actor.Camera3D, CameraToShift, TransitionDuration);
                Actor.MouseRayCastInteractor.ChangeCameraTo(CameraToShift);
            }
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor && !GlobalCameraShifter.IsTransitioning3D()) {

                base.OnCanceledInteraction(interactor);

                Actor.MouseRayCastInteractor.ReturnToOriginalCamera();
                GlobalCameraShifter.TransitionToPreviousCamera3D();
            }
        }
    }
}
