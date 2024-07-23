using Godot;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/vfx/scenes/shockwave/shockwave.svg")]
    public partial class ShockwaveVFX : Node2D {
        #region Exported parameters
        [Export] public bool Autostart = true;
        [Export] public Color ShockwaveColor = Colors.White;
        [Export] public Color OutlineColor = Colors.Black;
        [Export] public bool DrawOutline = false;
        [Export] public float StartRadius = 10f;
        [Export] public float EndRadius = 100f;
        [Export] public float StartWidth = 6f;
        [Export] public float EndWidth = 0.2f;
        [Export] public int ArcPoints = 24;
        [Export] public float ExpandTime = 1f;
        #endregion

        public float TimeScale = 1f;
        public float CurrentTimer = 0f;
        public float Size = 1f;
        public float SizeT = 1f; // Intermediate value used in the code to control the animation of the shockwave's size 

        public override void _Ready() {
            Size = StartRadius;
            SetProcess(Autostart);
        }

        public override void _Process(double delta) {

            delta *= TimeScale;
            CurrentTimer += 1f / ExpandTime * (float)delta;

            if (CurrentTimer >= 1f)
                QueueFree();

            SizeT = (float)TorCurve.Run(CurrentTimer, 1.5f, 0f, 1f);
            Size = Mathf.Lerp(StartRadius, EndRadius, SizeT);

            QueueRedraw();
        }

        public void Spawn() {
            SetProcess(true);
        }

        public override void _Draw() {
            var smoothnessFactor = Mathf.Lerp(StartWidth, EndWidth, SizeT);

            if (DrawOutline)
                DrawArc(Vector2.Zero, Size, 0, Mathf.Tau, ArcPoints, OutlineColor * new Color(0, 0, 0, 1f - Mathf.Pow(SizeT, 4f)), Mathf.Min(smoothnessFactor + 8f, smoothnessFactor * 4f), false);

            DrawArc(Vector2.Zero, Size, 0, Mathf.Tau, ArcPoints, ShockwaveColor * new Color(1f, 1f, 1f, 1f - Mathf.Pow(SizeT, 4f)), smoothnessFactor, false);
        }

    }

}
