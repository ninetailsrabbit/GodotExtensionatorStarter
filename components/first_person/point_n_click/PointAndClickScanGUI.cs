using Extensionator;
using Godot;
using GodotExtensionator;
using System;


namespace GodotExtensionatorStarter {
    public partial class PointAndClickScanGUI : Control {

        [Export] public PackedScene ScanViewport3DScene = GD.Load<PackedScene>("res://components/first_person/point_n_click/ScanViewport3D.tscn");

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public PointNClickController Actor { get; set; } = null!;
        public SubViewport ScanSubViewport { get; set; } = null!;
        public RichTextLabel TitleLabel { get; set; } = null!;
        public Label DescriptionLabel { get; set; } = null!;


        public override void _ExitTree() {
            GlobalGameEvents.ActorScannedObject -= OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan -= OnPointAndClickScanCanceled;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();

            ScanSubViewport = GetNode<SubViewport>($"%{nameof(ScanSubViewport)}");
            TitleLabel = GetNode<RichTextLabel>($"%{nameof(TitleLabel)}");
            DescriptionLabel = GetNode<Label>($"%{nameof(DescriptionLabel)}");

            GlobalGameEvents.ActorScannedObject += OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan += OnPointAndClickScanCanceled;
        }


        public override void _Ready() {
            Actor ??= GetTree().GetFirstNodeInGroup(PointNClickController.GroupName) as PointNClickController;
            ArgumentNullException.ThrowIfNull(Actor);
        }

        private void OnPointAndClickObjectScanned(PointAndClickObjectScanner pointAndClickObjectScanner) {
            if (ScanSubViewport.GetChildCount().IsZero()) {
                Node3D TargetToScan = (Node3D)pointAndClickObjectScanner.TargetObjectToScan.Duplicate();

                ScanViewport scanViewport = ScanViewport3DScene.Instantiate<ScanViewport>();
                scanViewport.GetNode<Marker3D>(nameof(Marker3D)).AddChild(TargetToScan);

                ScanSubViewport.AddChild(scanViewport);

                scanViewport.MouseRotatorComponent3D.Target = TargetToScan;

                scanViewport.ChangeMouseCursor(pointAndClickObjectScanner.InteractCursor);
                scanViewport.ChangeMouseRotatorCursor(pointAndClickObjectScanner.ScanRotateCursor);

                Actor.MouseRayCastInteractor.ChangeCameraTo(scanViewport.ScanCamera);

                TitleLabel.Text = pointAndClickObjectScanner.Interactable3D.Title;
                DescriptionLabel.Text = pointAndClickObjectScanner.Interactable3D.Description;
                DescriptionLabel.AdjustText();
            }
        }

        private void OnPointAndClickScanCanceled(PointAndClickObjectScanner pointAndClickObjectScanner) {
            if (ScanSubViewport.GetChildCount().IsGreaterThanZero()) {
                ScanViewport scanViewport3D = (ScanViewport)ScanSubViewport.GetChild(0);
                scanViewport3D.MouseRotatorComponent3D.ResetToDefaultCursors();

                ScanSubViewport.RemoveAndQueueFreeChildren();

                TitleLabel.Text = string.Empty;
                DescriptionLabel.Text = string.Empty;
                Actor.MouseRayCastInteractor.ReturnToOriginalCamera();
            }

        }
    }

}
