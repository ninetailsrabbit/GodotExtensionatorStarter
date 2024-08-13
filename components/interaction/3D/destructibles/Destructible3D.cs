using Godot;
using GodotExtensionator;
using System;


namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/interaction/3D/destructibles/destructible.svg")]
    public partial class Destructible3D : Node3D {

        public const string GroupName = "destructible";
        public enum ShardTypes {
            Box,
            Brick,
        }

        public enum ExplosionModes {
            AllDirections,
            Horizontal,
            Forward,
            OppositeToCamera,
            ToTheCamera,
            Left,
            Right,
            Ascendant,
            Landslide
        }

        [Export] public MeshInstance3D TargetMesh { get; set; } = null!;
        [Export] public Node3D ShardsSpawnSpot { get; set; } = null!;
        [Export] public Hurtbox3D HurtboxTrigger { get; set; } = null!;
        [Export] public ShardTypes SelectedShardType = ShardTypes.Brick;
        [Export] public int AmountOfShards = 150;
        [Export] public float MinShardSize = 0.1f;
        [Export] public float MaxShardSize = 0.5f;
        [Export] public ExplosionModes SelectedExplosionMode = ExplosionModes.AllDirections;
        [Export] public float MinExplosionPower = 4.5f;
        [Export] public float MaxExplosionPower = 7f;
        [Export(PropertyHint.Range, "-8, 8, 0.001")] public float ShardsGravityScale = 0.75f;
        [Export(PropertyHint.Range, "0.01,1000,0.01")] public float ShardMass = 0.9f;

        public override void _EnterTree() {
            AddToGroup(GroupName);
            TargetMesh ??= this.FirstNodeOfType<MeshInstance3D>();
            ShardsSpawnSpot ??= GetNode<Node3D>(nameof(ShardsSpawnSpot));
            HurtboxTrigger ??= this.FirstNodeOfClass<Hurtbox3D>();

            ArgumentNullException.ThrowIfNull(TargetMesh);
            ArgumentNullException.ThrowIfNull(ShardsSpawnSpot);
            ArgumentNullException.ThrowIfNull(HurtboxTrigger);

            HurtboxTrigger.HitboxDetected += OnHitboxDetected;

            
        }

        protected virtual void OnHitboxDetected(Hitbox3D _) {
            // TODO - TRIGGER CONDITIONS FOR THIS DESTRUCTIBLE
        }

    }

}
