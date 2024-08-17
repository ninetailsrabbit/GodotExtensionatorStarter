using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/interaction/3D/destructibles/destructible.svg")]
    public partial class Destructible3D : Node3D {

        public const string GroupName = "destructible";
        private readonly RandomNumberGenerator _rng = new();

        public enum ShardTypes {
            Box,
            Brick,
        }

        public enum ExplosionModes {
            AllDirections,
            Horizontal,
            OppositeToCamera,
            ToTheCamera,
            Forward,
            Back,
            Left,
            Right,
            Ascendant,
            Landslide
        }

        [Export] public MeshInstance3D TargetMesh { get; set; } = null!;
        [Export] public Node3D ShardsSpawnSpot { get; set; } = null!;
        [Export] public Array<StaticBody3D> AffectedStaticBodies { get; set; } = []; // This are converted to rigid bodies after trigger destructible
        [Export] public Hurtbox3D HurtboxTrigger { get; set; } = null!;
        [Export] public int AmountOfShards = 100;
        [Export] public ExplosionModes SelectedExplosionMode = ExplosionModes.AllDirections;
        [Export] public float MinExplosionPower = 4.5f;
        [Export] public float MaxExplosionPower = 7f;

        public override void _UnhandledInput(InputEvent @event) {
            if (Input.IsActionJustPressed("ui_accept") && Visible)
                Destroy();
        }

        public override void _ExitTree() {
            HurtboxTrigger.HitboxDetected -= OnHitboxDetected;
        }

        public override void _EnterTree() {
            AddToGroup(GroupName);

            TargetMesh ??= this.FirstNodeOfType<MeshInstance3D>() ?? GetParentOrNull<MeshInstance3D>();
            ArgumentNullException.ThrowIfNull(TargetMesh);

            ShardsSpawnSpot ??= GetNodeOrNull<Node3D>(nameof(ShardsSpawnSpot));

            HurtboxTrigger ??= this.FirstNodeOfClass<Hurtbox3D>() ?? TargetMesh.FirstNodeOfClass<Hurtbox3D>();
            ArgumentNullException.ThrowIfNull(HurtboxTrigger);

            HurtboxTrigger.HitboxDetected += OnHitboxDetected;
        }


        public void Destroy() {
            Hide();


            foreach (var _ in Enumerable.Range(0, AmountOfShards)) {
                DestructibleShard3D shard = new() { RelatedDestructible = this };

                if (ShardsSpawnSpot is null) {
                    GetTree().Root.AddChild(shard);
                }
                else {
                    ShardsSpawnSpot.AddChild(shard);
                }

                var spawnPosition = shard.Position + TargetMesh.GetRandomSurfacePosition();
                shard.GlobalPosition = TargetMesh.GlobalPosition + spawnPosition;
                shard.GlobalRotation = TargetMesh.GlobalRotation;

                GenerateImpulseOnShard(shard);
            }

            TargetMesh.Remove();
            this.Remove();
        }

        private void GenerateImpulseOnShard(DestructibleShard3D shard) {
            var explosionPower = _rng.RandfRange(MinExplosionPower, MaxExplosionPower);

            switch (SelectedExplosionMode) {
                case ExplosionModes.AllDirections:
                    shard.ApplyCentralImpulse(Vector3.Right.GenerateRandomDirection() * explosionPower);
                    break;
                case ExplosionModes.OppositeToCamera:
                    shard.ApplyCentralImpulse(GetViewport().GetCamera3D().ForwardDirection() * explosionPower);
                    break;
                case ExplosionModes.ToTheCamera:
                    shard.ApplyCentralImpulse(GetViewport().GetCamera3D().ForwardDirection().Flip() * explosionPower);
                    break;
                case ExplosionModes.Horizontal:
                    shard.ApplyCentralImpulse((new List<Vector3>() { Vector3.Right, Vector3.Left }).RandomElement() * explosionPower);
                    break;
                case ExplosionModes.Forward:
                    shard.ApplyCentralImpulse(Vector3.Forward * explosionPower);
                    break;
                case ExplosionModes.Back:
                    shard.ApplyCentralImpulse(Vector3.Back * explosionPower);
                    break;
                case ExplosionModes.Left:
                    shard.ApplyCentralImpulse(Vector3.Left * explosionPower);
                    break;
                case ExplosionModes.Right:
                    shard.ApplyCentralImpulse(Vector3.Right * explosionPower);
                    break;
                case ExplosionModes.Ascendant:
                    shard.ApplyCentralImpulse(Vector3.Up * explosionPower);
                    break;
                case ExplosionModes.Landslide:
                    shard.ApplyCentralImpulse(Vector3.Down * explosionPower);
                    break;
                default:
                    shard.ApplyCentralImpulse(Vector3.Right.GenerateRandomDirection() * explosionPower);
                    break;
            }
        }
        protected virtual void OnHitboxDetected(Hitbox3D _) {
            Destroy();
        }

    }

}
