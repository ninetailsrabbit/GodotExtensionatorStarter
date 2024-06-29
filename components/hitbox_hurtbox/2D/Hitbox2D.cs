using Godot;
using GodotExtensionator;


namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/hitbox_hurtbox/hitbox.svg")]
    public partial class Hitbox2D : Area2D {

        public GameGlobals GameGlobals { get; set; } = default!;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
        }

        public override void _Ready() {
            Monitorable = true;
            Monitoring = false;
            CollisionMask = 0;
            CollisionLayer = GameGlobals.HitboxesCollisionLayer;
        }

    }

}