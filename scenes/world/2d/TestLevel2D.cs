using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    public partial class TestLevel2D : Node {

        public Sprite2D sprite { get; set; } = default!;
        public Sprite2D toFollow { get; set; } = default!;
        public Marker2D marker { get; set; } = default!;
        public ArcProjectile arc { get; set; } = default!;

        public GlobalFade GlobalFade { get; set; } = default!;

        public double elapsed = 0d;

        public override void _Input(InputEvent @event) {
            
        }

        public override void _Process(double delta) {
            elapsed += delta;

            toFollow.GlobalPosition = toFollow.GetGlobalMousePosition();
            sprite.RotateToward(toFollow, (float)elapsed);

        }
        public override void _Ready() {
            GlobalFade = this.GetAutoloadNode<GlobalFade>();

            arc = GetNode<ArcProjectile>(nameof(ArcProjectile));

            sprite = GetNode<Sprite2D>(nameof(Sprite2D));
            toFollow = GetNode<Sprite2D>("ToFollow");
            marker = GetNode<Marker2D>(nameof(Marker2D));

        }

        

    }

}