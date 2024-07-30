using Extensionator;
using Godot;
using GodotExtensionator;

//https://www.toppr.com/guides/physics/motion-in-a-plane/projectile-motion/
namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/rpg/projectiles/arcprojectile.svg")]
    public partial class ArcProjectile : Node2D {
        [Export] public Node2D Projectile { get; set; } = null!;
        [Export] public float TimeMultiplier = 6f;
        [Export] public float Gravity = 9.8f;

        public float zAxis = 0f;

        private bool _launched = false;
        private float _time = 0f;
        private float _initialSpeed = 0f;
        private Vector2 _initialPosition = Vector2.Zero;
        private Vector2 _throwDirection = Vector2.Zero;
        private float _throwAngle = 0f;

        public override void _PhysicsProcess(double delta) {
            _time += (float)delta * TimeMultiplier;

            if (_launched) {
                zAxis = _initialSpeed * Mathf.Sin(_throwAngle) * _time - 0.5f * Gravity * Mathf.Pow(_time, 2);

                if (zAxis > 0) {
                    var xAxis = _initialSpeed * Mathf.Cos(_throwAngle) * _time;

                    GlobalPosition = _initialPosition + _throwDirection * xAxis;
                    Projectile.Position = Projectile.Position with { Y = -zAxis };
                }
                else {
                    _launched = false;
                }
            }
        }

        public void Launch(Vector2 direction, float distance, float throwAngleDegrees) {
            if (!_launched) {
                _launched = true;

                _initialPosition = GlobalPosition;
                _throwDirection = direction.NormalizeVector();
                _throwAngle = (float)Mathf.DegToRad(throwAngleDegrees).NormalizeRadiansAngle();

                _initialSpeed = Mathf.Pow(distance * Gravity / Mathf.Sin(2 * _throwAngle), 0.5f);

                _time = 0f;
                zAxis = 0f;
            }

        }
    }
}
