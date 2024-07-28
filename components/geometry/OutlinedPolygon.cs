using Godot;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class OutlinedPolygon : Polygon2D {
        [Export] public float LineThickness = 2f;
        [Export] public Color LineColor = new(0f, 0f, 0f, 0.1f);

        public override void _Draw() {
            var points = Polygon;

            if (points.Length > 0) {
                points = [.. points, points[0]];
                DrawPolyline(points, LineColor, LineThickness, false);
            }
        }
    }
}
