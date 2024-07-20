using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class ThrowableAreaDetector : Area3D {
        public GameGlobals GameGlobals { get; set; } = null!;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            CollisionLayer = 0;
            CollisionMask = GameGlobals.ThrowablesCollisionLayer;
            Monitorable = false;
            Monitoring = true;
            Priority = 2;
            
        }
    }
}
