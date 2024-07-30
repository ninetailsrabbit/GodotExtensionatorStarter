using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    public partial class TestLevel2D : Node {

        public Sprite2D sprite { get; set; } = default!;
        public Marker2D marker { get; set; } = default!;
        public ArcProjectile arc { get; set; } = default!;

        public override void _Input(InputEvent @event) {
            if (Input.IsActionPressed("jump"))
                arc.Launch(Vector2.Right, 300f, 65f);

        }
        public override void _Ready() {
            arc = GetNode<ArcProjectile>(nameof(ArcProjectile));

            sprite = GetNode<Sprite2D>(nameof(Sprite2D));
            marker = GetNode<Marker2D>(nameof(Marker2D));

        }

        

    }

}