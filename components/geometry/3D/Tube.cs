using Godot;
using Godot.Collections;
using System.Linq;


namespace GodotExtensionatorStarter {
    public partial class Tube : Path3D {
        [Export] public Node3D EndConnectionPoint { get; set; } = default!;
        [Export] public float TubeWidth = 0.03f;
        public CsgPolygon3D CSGPolygon3D { get; set; } = null!;

        public int CirclePoints = 8;
        public Vector3 OutLocal = Vector3.Zero;

        public override void _Ready() {
            Array<Vector2> polygonPoints = [];

            foreach (var index in Enumerable.Range(0, CirclePoints)) {
                polygonPoints.Add(Vector2.Right.Rotated(index * CirclePoints / Mathf.Tau) * TubeWidth);
            }

            CSGPolygon3D.Polygon = [.. polygonPoints];

            if (EndConnectionPoint is null) {
                SetProcess(false);

                return;
            }

            OutLocal = EndConnectionPoint.ToLocal(ToGlobal(Curve.GetPointOut(0) + Curve.GetPointPosition(0)));
        }

        public override void _Process(double delta) {
            var curvePointPosition = ToLocal(EndConnectionPoint.GlobalPosition);
            Curve.SetPointPosition(0, curvePointPosition);

            var curvePointPositionOut = ToLocal(EndConnectionPoint.ToGlobal(OutLocal) - curvePointPosition);
            Curve.SetPointOut(0, curvePointPositionOut);
        }
    }
}
