using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/vfx/scenes/pop/pop_effect.svg")]
    public partial class PopVFX : Node2D {
        [Signal]
        public delegate void FinishedEventHandler();

        [Export] public Color CircleColor = Colors.White;
        [Export] public float Radius = 6f;
        [Export(PropertyHint.Range, "0f, 360f, 0.01f")] public float AngleRange = 360f;
        [Export] public float TimeScale = 1f;
        [Export] public float StepSpeed = 3f;
        [Export] public float MinDistance = 300f;
        [Export] public float MaxDistance = 600f;
        [Export] public int SpawnTimes { get => _spawnTimes; set { _spawnTimes = Mathf.Max(1, value); } }
        [Export] public float TargetScale = 0.1f;

        private readonly RandomNumberGenerator _rng = new();
        private int _spawnTimes = 5;

        private Vector2 _velocity = Vector2.Zero;
        private Vector2 _initialPosition = Vector2.Zero;
        private Vector2 _initialScale = Vector2.One;

        private int _spawnTimesApplied = 0;

        public override void _ExitTree() {
            Finished -= OnFinished;
        }
        public override void _EnterTree() {
            Finished += OnFinished;
        }
        public override void _Ready() {
            _initialPosition = Position;
            _initialScale = Scale;
            Setup(false);

        }

        public override void _Process(double delta) {
            delta *= TimeScale;

            _velocity *= 1f - (StepSpeed * (float)delta);
            Position += _velocity * (float)delta;
            Scale *= 1f - (StepSpeed * (float)delta);

            if (Scale.X < TargetScale && _spawnTimesApplied <= _spawnTimes)
                Setup(true);
        }

        public void Setup(bool countAsApplied = true) {
            Scale = _initialScale;
            Position = _initialPosition;
            _velocity = Vector2.FromAngle(_rng.Randf() * Mathf.DegToRad(AngleRange)) * _rng.RandfRange(MinDistance, MaxDistance);
            Modulate = CircleColor;

            if (countAsApplied) {
                _spawnTimesApplied += 1;

                if (_spawnTimesApplied >= _spawnTimes)
                    EmitSignal(SignalName.Finished);
            }
        }

        public override void _Draw() {
            DrawCircle(Vector2.Zero, Radius, CircleColor);
        }

        private void OnFinished() {
            QueueFree();
        }
    }

}


