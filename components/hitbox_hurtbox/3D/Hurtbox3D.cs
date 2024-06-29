using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/hitbox_hurtbox/hurtbox.svg")]
    public partial class Hurtbox3D : Area3D {
        [Signal]
        public delegate void HitboxDetectedEventHandler(Hitbox3D hitbox);

        public GameGlobals GameGlobals { get; set; } = default!;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
        }
        public override void _Ready() {
            Monitoring = true;
            Monitorable = false;
            CollisionLayer = 0;
            CollisionMask = GameGlobals.HitboxesCollisionLayer;

            AreaEntered += OnAreaEntered;
        }

        public void OnAreaEntered(Area3D area) {
            if (area is Hitbox3D)
                EmitSignal(SignalName.HitboxDetected, area);
        }
    }

}