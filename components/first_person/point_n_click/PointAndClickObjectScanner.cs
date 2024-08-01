using Godot;

namespace GodotExtensionatorStarter {
    public partial class PointAndClickObjectScanner : PointAndClickInteraction {


        [Export] public Node3D TargetObjectToScan { get; set; } = null!;

        public bool IsScanningObject = false;

    }
}
