using Extensionator;
using Godot;
using GodotExtensionator;
using System;


namespace GodotExtensionatorStarter {
    public partial class PointAndClickScanGUI : Control, ITranslatable {

        [Export] public PackedScene ScanViewport3DScene = GD.Load<PackedScene>("res://components/first_person/point_n_click/ScanViewport3D.tscn");

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public PointAndClickController Actor { get; set; } = null!;
        public SubViewport ScanSubViewport { get; set; } = null!;
        public RichTextLabel TitleLabel { get; set; } = null!;
        public Label DescriptionLabel { get; set; } = null!;

        public Interactable3D? CurrentInteractable { get; set; } = default!;

        public override void _ExitTree() {
            GlobalGameEvents.ActorScannedObject -= OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan -= OnPointAndClickScanCanceled;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();


            ScanSubViewport = GetNode<SubViewport>($"%{nameof(ScanSubViewport)}");
            TitleLabel = GetNode<RichTextLabel>($"%{nameof(TitleLabel)}");
            DescriptionLabel = GetNode<Label>($"%{nameof(DescriptionLabel)}");

            TitleLabel.Text = string.Empty;
            DescriptionLabel.Text = string.Empty;

            GlobalGameEvents.ActorScannedObject += OnPointAndClickObjectScanned;
            GlobalGameEvents.ActorCanceledScan += OnPointAndClickScanCanceled;
        }


        public override void _Ready() {
            Actor ??= GetTree().GetFirstNodeInGroup(PointAndClickController.GroupName) as PointAndClickController;
            ArgumentNullException.ThrowIfNull(Actor);
        }

        private void DisplayScanInformation(Interactable3D? interactable = null) {
            interactable ??= CurrentInteractable;

            if (interactable is not null) {
                TitleLabel.Text = Tr(interactable.Title);
                DescriptionLabel.Text = Tr(interactable.Description);
                DescriptionLabel.AdjustText();
            }
        }

        private void OnPointAndClickObjectScanned(PointAndClickObjectScanner pointAndClickObjectScanner) {
            if (ScanSubViewport.GetChildCount().IsZero()) {
                CurrentInteractable = pointAndClickObjectScanner.Interactable3D;

                Node3D TargetToScan = (Node3D)pointAndClickObjectScanner.TargetObjectToScan.Duplicate();

                ScanViewport scanViewport = ScanViewport3DScene.Instantiate<ScanViewport>();
                scanViewport.GetNode<Marker3D>(nameof(Marker3D)).AddChild(TargetToScan);

                ScanSubViewport.AddChild(scanViewport);

                scanViewport.MouseRotatorComponent3D.Target = TargetToScan;
                scanViewport.MouseRotatorComponent3D.SetProcessInput(pointAndClickObjectScanner.Interactable3D.CanBeRotatedOnScan);
                scanViewport.MouseRotatorComponent3D.SetProcessUnhandledInput(pointAndClickObjectScanner.Interactable3D.CanBeRotatedOnScan);

                scanViewport.SetCurrentMouseCursor(pointAndClickObjectScanner.InteractCursor);
                scanViewport.ChangeMouseCursor(pointAndClickObjectScanner.InteractCursor);
                scanViewport.ChangeMouseRotatorCursor(pointAndClickObjectScanner.ScanRotateCursor);

                Actor.MouseRayCastInteractor.ChangeCameraTo(scanViewport.ScanCamera);

                DisplayScanInformation(pointAndClickObjectScanner.Interactable3D);
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

                CurrentInteractable = null;
            }
        }

        public void OnLocaleChanged() {
            DisplayScanInformation();
        }
    }

}
