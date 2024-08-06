using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickCameraShifter : PointAndClickInteraction {

        [Export] public Camera3D CameraToShift { get; set; } = null!;
        [Export] public float TransitionDuration = 1.5f;
        [Export] public MouseButton ReturnToPreviousCameraButton = MouseButton.Right;
        [Export] public PointAndClickCameraShifter PreviousCameraShifter { get; set; } = default!;
        public GlobalCameraShifter GlobalCameraShifter { get; set; } = default!;

        public override void _EnterTree() {
            base._EnterTree();

            GlobalCameraShifter = this.GetAutoloadNode<GlobalCameraShifter>();

            CameraToShift ??= this.FirstNodeOfType<Camera3D>();

            ArgumentNullException.ThrowIfNull(CameraToShift);
        }

        public override void _Input(InputEvent @event) {
            if (GetViewport().GetCamera3D().Equals(CameraToShift) && ReturnToPreviousCameraButton.Equals(MouseButton.Right) && @event.IsMouseRightClick()) {
                Interactable3D.EmitSignal(Interactable3D.SignalName.CanceledInteraction, Actor.MouseRayCastInteractor);
            }
        }

        public void ReturnToPreviousCamera() {
            SetProcessInput(false);

            if (PreviousCameraShifter is null) {
                Actor.MouseRayCastInteractor.ReturnToOriginalCamera();
                GlobalCameraShifter.TransitionToRequestedCamera3D(CameraToShift, Actor.Camera3D, TransitionDuration, false);
            }
            else {
                Actor.MouseRayCastInteractor.ChangeCameraTo(PreviousCameraShifter.CameraToShift);
                GlobalCameraShifter.TransitionToRequestedCamera3D(CameraToShift, PreviousCameraShifter.CameraToShift, TransitionDuration, false);
            }
        }

        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor &&
                !GlobalCameraShifter.IsTransitioning3D() &&
                !GetViewport().GetCamera3D().Equals(CameraToShift)) {

                base.OnInteracted(interactor);
                GlobalCameraShifter.TransitionToRequestedCamera3D(GetViewport().GetCamera3D(), CameraToShift, TransitionDuration);
                Actor.MouseRayCastInteractor.ChangeCameraTo(CameraToShift);

                SetProcessInput(true);
            }
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor && !GlobalCameraShifter.IsTransitioning3D()) {

                base.OnCanceledInteraction(interactor);

                ReturnToPreviousCamera();
            }
        }
    }
}
