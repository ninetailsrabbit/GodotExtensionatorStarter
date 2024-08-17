using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class DestructibleShard3D : RigidBody3D {
        public const string GroupName = "destructible";
        public enum ShardTypes {
            Box,
            Brick,
        }

        [Export] public bool UseDestructibleParentMaterial = true;
        [Export] public float TimeInTheWorld = 10f;
        [Export] public float MinShardSize = 0.15f;
        [Export] public float MaxShardSize = 0.25f;
        [Export] public float MinAngularVelocity = 0.5f;
        [Export] public float MaxAngularVelocity = 2f;
        [Export(PropertyHint.Range, "-8, 8, 0.001")] public float ShardsGravityScale = 0.75f;
        [Export(PropertyHint.Range, "0.01, 1000, 0.01")] public float ShardMass = 0.9f;
        [Export] public float ExtraScale = 1.05f;
        [Export] public ShardTypes SelectedShardType = ShardTypes.Brick;

        public GameGlobals GameGlobals { get; set; } = default!;
        public Destructible3D RelatedDestructible { get; set; } = null!;
        public MeshInstance3D MeshInstance { get; set; } = null!;

        private Timer? FreeTimer { get; set; } = default!;
        private readonly RandomNumberGenerator _rng = new();

        public override void _EnterTree() {
            AddToGroup(GroupName);

            Name = nameof(DestructibleShard3D);

            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            RelatedDestructible ??= GetParent<Destructible3D>();

            if (TimeInTheWorld > 0) {
                FreeTimer ??= new() {
                    Name = "FreeTimer",
                    ProcessCallback = Godot.Timer.TimerProcessCallback.Physics,
                    WaitTime = TimeInTheWorld,
                    Autostart = true,
                    OneShot = true
                };

                AddChild(FreeTimer);
                FreeTimer.Timeout += OnFreeTimerTimeout;
            }

            CollisionLayer = GameGlobals.ShardsCollisionLayer;
            CollisionMask = GameGlobals.WorldCollisionLayer | GameGlobals.PlayerCollisionLayer | GameGlobals.EnemiesCollisionLayer | GameGlobals.ThrowablesCollisionLayer | GameGlobals.ShardsCollisionLayer;
            GravityScale = ShardsGravityScale;
            Mass = ShardMass;
            AngularVelocity = Vector3.Right.GenerateRandomFixedDirection() * _rng.RandfRange(MinAngularVelocity, MaxAngularVelocity);
        }

        public override void _Ready() {
            CreateMesh();
            GenerateRandomShardScale();
            CreateCollision();
        }

        private void CreateCollision() {
            CollisionShape3D collision = new() { Shape = new BoxShape3D(), Scale = MeshInstance.Scale * ExtraScale };
            AddChild(collision);
        }

        private void GenerateRandomShardScale() {
            MeshInstance.Scale = Vector3.One.Scale(_rng.RandfRange(MinShardSize, MaxShardSize));

            if (SelectedShardType.Equals(ShardTypes.Brick))
                MeshInstance.Scale = new Vector3(MeshInstance.Scale.X / _rng.RandfRange(1.1f, 10f), MeshInstance.Scale.Y / _rng.RandfRange(2f, 10f), MeshInstance.Scale.Z);
        }

        private void CreateMesh() {
            MeshInstance = new() { Mesh = new BoxMesh() { Size = Vector3.One } };

            if (UseDestructibleParentMaterial) {
                if (RelatedDestructible.TargetMesh.Mesh.SurfaceGetMaterial(0) as StandardMaterial3D is not null) {
                    MeshInstance.Mesh.SurfaceSetMaterial(0, RelatedDestructible.TargetMesh.Mesh.SurfaceGetMaterial(0));
                }
                else if (RelatedDestructible.TargetMesh.MaterialOverride as StandardMaterial3D is not null) {
                    MeshInstance.Mesh.SurfaceSetMaterial(0, RelatedDestructible.TargetMesh.MaterialOverride);
                }
            }

            AddChild(MeshInstance);
        }

        private void OnFreeTimerTimeout() {
            this.Remove();
        }
    }
}
