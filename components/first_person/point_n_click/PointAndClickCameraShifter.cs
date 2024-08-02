using Godot;
using GodotExtensionator;
using System;
using System.Linq;

namespace GodotExtensionatorStarter {
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
            if (interactor is MouseRayCastInteractor) {
                GlobalCameraShifter.TransitionToRequestedCamera3D(Actor.Camera3D, CameraToShift, TransitionDuration);
                Actor.MouseRayCastInteractor.ChangeCameraTo(CameraToShift);
            }
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {
                Actor.MouseRayCastInteractor.ChangeCameraTo(GlobalCameraShifter.TransitionSteps3D.Last().From);
                GlobalCameraShifter.TransitionToPreviousCamera3D();
            }
        }
    }
}
