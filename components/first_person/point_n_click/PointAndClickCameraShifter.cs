using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    public partial class PointAndClickCameraShifter : PointAndClickInteraction {

        [Export] public Camera3D CameraToShift { get; set; } = null!;
        [Export] public float TransitionDuration = 1.5f;

        public override void _EnterTree() {
            base._EnterTree();

            FocusCursor ??= Preloader.Instance.CursorLook;

            CameraToShift ??= this.FirstNodeOfType<Camera3D>();

            ArgumentNullException.ThrowIfNull(CameraToShift);
        }


        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {
                GlobalCameraShifter.TransitionToRequestedCamera3D(Actor.Camera3D, CameraToShift, TransitionDuration);

                Actor.MouseRayCastInteractor.ChangeCameraTo(CameraToShift);
            }
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {
                GlobalCameraShifter.TransitionToPreviousCamera3D();
                Actor.MouseRayCastInteractor.ReturnToOriginalCamera();
            }
        }
    }
}
