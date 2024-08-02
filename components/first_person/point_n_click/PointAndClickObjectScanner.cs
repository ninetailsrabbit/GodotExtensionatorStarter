using Extensionator;
using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/first_person/point_n_click/point_click_3d.svg")]
    public partial class PointAndClickObjectScanner : PointAndClickInteraction {

        [Export] public Node3D TargetObjectToScan { get; set; } = null!;
        [Export] public PackedScene ScanViewportScene = GD.Load<PackedScene>("res://components/first_person/point_n_click/ScanViewport.tscn");

        public override void _EnterTree() {
            base._EnterTree();

            FocusCursor ??= Preloader.Instance.CursorLook;

            ArgumentNullException.ThrowIfNull(TargetObjectToScan);

            Interactable3D.Scannable = true;
        }

        protected override void OnInteracted(GodotObject interactor) {
            if (interactor is MouseRayCastInteractor mouseInteractor) {
                Actor.UseAnimations = false;
                Actor.InteractionLayer.Show();

                if (Actor.ScanSubViewport.GetChildCount().IsZero()) {
                    ScanViewport scanViewport = ScanViewportScene.Instantiate<ScanViewport>();
                    scanViewport.GetNode<Marker3D>(nameof(Marker3D)).AddChild(TargetObjectToScan.Duplicate());

                    Actor.ScanSubViewport.AddChild(scanViewport);

                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ActorScannedObject, this);
                }
            }
        }

        protected override void OnCanceledInteraction(GodotObject interactor) {
            base.OnCanceledInteraction(interactor);

            Actor.ScanSubViewport.RemoveAndQueueFreeChildren();
            Actor.InteractionLayer.Hide();
            Actor.UseAnimations = true;
            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ActorCanceledScan, this);

        }
    }
}
