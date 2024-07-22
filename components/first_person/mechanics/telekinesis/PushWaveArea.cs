using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System;
using System.Linq;

namespace GodotExtensionatorStarter {
    public partial class PushWaveArea : Area3D {

        private readonly RandomNumberGenerator _rng = new();
        [Export] public Vector3 Direction = Vector3.Forward;
        [Export] public Vector3 UpwardOffset = Vector3.Up;
        [Export] public int PushableBodies = 7;
        [Export] public float MinAngularForce = 0.5f;
        [Export] public float MaxAngularForce = 1f;
        [Export] public float MinPushForce = 5.0f;
        [Export] public float MaxPushForce = 20.0f;
        [Export] public float MinUpwardForce = 0.1f;
        [Export] public float MaxUpwardForce = 1.0f;
        [Export] public float WaveSpeed = 2.0f;
        [Export] public float WaveRadius = 5.0f;
        [Export] public float TimeAlive = 1.0f;

        public PushWaveArea(Vector3? direction = null) {
            Direction = direction ?? Vector3.Forward;
        }
        public bool Active {
            get => _active;
            set {
                _active = value;
                Monitoring = _active;
                SetPhysicsProcess(_active);
            }
        }
        private bool _active = false;

        public GameGlobals GameGlobals { get; set; } = null!;

        public Array<RigidBody3D> BodiesPushed = [];

        public Timer AliveTimer { get; set; } = default!;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            Monitorable = false;
            Monitoring = true;
            CollisionLayer = 0;
            CollisionMask = GameGlobals.WorldCollisionLayer | GameGlobals.InteractablesCollisionLayer | GameGlobals.ThrowablesCollisionLayer | GameGlobals.EnemiesCollisionLayer;

            LinearDampSpaceOverride = SpaceOverride.Combine;
            LinearDamp = 0.5f;

            AngularDampSpaceOverride = SpaceOverride.Combine;
            AngularDamp = 0.5f;

            CollisionShape3D collision = new() { Shape = new SphereShape3D() { Radius = WaveRadius } };
            AddChild(collision);
            CreateAliveTimer();

            SetPhysicsProcess(Active);
        }

        public override void _Ready() {
            if (IsInstanceValid(AliveTimer))
                AliveTimer.Start();

            Active = true;
        }

        public override void _PhysicsProcess(double delta) {
            GlobalPosition += WaveSpeed * Direction;
            PushBodiesOnRange();
        }


        public void PushBodiesOnRange() {
            var bodies = GetOverlappingBodies().Where(body => body is RigidBody3D && !BodiesPushed.Contains(body)).Cast<RigidBody3D>();
            Vector3 upwardOffset = MaxUpwardForce.IsZero() ? Vector3.Zero : UpwardOffset * _rng.RandfRange(MinUpwardForce, MaxUpwardForce);

            foreach (var body in bodies) {
                BodiesPushed.Add(body);
                body.AngularVelocity = Vector3.Right.GenerateRandomFixedDirection() * _rng.RandfRange(MinAngularForce, MaxAngularForce);
                body.ApplyImpulse(Vector3.Right.RotateHorizontalRandom() * _rng.RandfRange(MinPushForce, MaxPushForce), -body.Position.Normalized() + upwardOffset);
            }

            Active = BodiesPushed.Count < PushableBodies;

        }

        private void CreateAliveTimer() {
            AliveTimer ??= new() {
                Name = "PushWaveAliveTimer",
                WaitTime = TimeAlive,
                ProcessCallback = Godot.Timer.TimerProcessCallback.Physics,
                Autostart = false,
                OneShot = true
            };

            AddChild(AliveTimer);
            AliveTimer.Timeout += OnAliveTimerTimeout;
        }

        private void OnAliveTimerTimeout() {
            this.Remove();
        }
    }
}
