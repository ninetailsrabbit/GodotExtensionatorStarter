using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    public partial class PointAndClickCameraShifter : PointAndClickInteraction {

        [Export] public Camera3D CameraToShift { get; set; } = null!;

        public override void _EnterTree() {
            base._EnterTree();

            FocusCursor ??= Preloader.Instance.CursorLook;

            CameraToShift ??= this.FirstNodeOfType<Camera3D>();

            ArgumentNullException.ThrowIfNull(CameraToShift);
        }
    }
}
