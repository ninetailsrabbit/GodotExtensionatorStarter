using System;
using Godot;


namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/motion/2D/rotation/orbit_component_2d.svg")]
    public partial class OrbitComponent2D : Node2D {
        [Signal]
        public delegate void StartedEventHandler();

        [Signal]
        public delegate void FinishedEventHandler();

        [Export] public Node2D RotationReference { get; set; } = null!;
        [Export] public bool AutoStart = true;
        [Export] public float Radius = 40f;
        [Export] public float AngleInRadians = Mathf.Pi / 4;
        [Export] public float AngularVelocity = Mathf.Pi / 2;

        public override void _EnterTree() {
            RotationReference ??= GetParent<Node2D>();

            ArgumentNullException.ThrowIfNull(RotationReference);

            SetProcess(false);

            if (AutoStart)
                Start();
        }

        public override void _Process(double delta) {
            AngleInRadians += (float)delta * AngularVelocity;
            AngleInRadians %= Mathf.Tau;

            var offset = new Vector2(Mathf.Cos(AngleInRadians), Mathf.Sin(AngleInRadians)) * Radius;

            Position = RotationReference.Position + offset;
        }

        public void Start() {
            SetProcess(true);
        }

        public void Stop() {
            SetProcess(false);
        }
    }

}
