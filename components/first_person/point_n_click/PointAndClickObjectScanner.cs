using Godot;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickObjectScanner : PointAndClickInteraction {

        [Export] public Node3D TargetObjectToScan { get; set; } = null!;
        [Export] public PackedScene ScanViewport3DScene = GD.Load<PackedScene>("res://components/first_person/point_n_click/ScanViewport3D.tscn");
        [Export] public CompressedTexture2D InteractCursor = Preloader.Instance.CursorHandThinOpen;
        [Export] public CompressedTexture2D ScanRotateCursor { get; set; } = Preloader.Instance.CursorHandThinClosed;
        public override void _EnterTree() {
            base._EnterTree();

            FocusCursor ??= Preloader.Instance.CursorZoom;

            ArgumentNullException.ThrowIfNull(TargetObjectToScan);

            Interactable3D.Scannable = true;
        }

        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {

                Actor.UseAnimations = false;
                Actor.InteractionLayer.Show();

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ActorScannedObject, this);
            }
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor) {

                base.OnCanceledInteraction(interactor);

                Actor.UseAnimations = true;
                Actor.InteractionLayer.Hide();

                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ActorCanceledScan, this);
            }
        }
    }
}
