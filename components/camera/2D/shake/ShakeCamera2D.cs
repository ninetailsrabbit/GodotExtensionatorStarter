using Godot;
using static Godot.FastNoiseLite;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class ShakeCamera2D : Camera2D {
        [Export] public float TraumaPower = 1.5f; //Power of the trauma to control the intensity of camera shake.
        [Export] public float NoiseSpeed = 5f; // Speed of the noise to determine how quickly the shake changes over time.
        [Export] public float Decay = 0.8f; // Decay rate to control how quickly the camera's trauma decreases over time.
        [Export] public float Amplitude = 18f; // Amplitude of the shake to adjust the magnitude of camera movement.
        [Export]
        public NoiseTypeEnum NoiseType {
            get => _noiseType;
            set {
                if (value != _noiseType) {
                    _noiseType = value;
                    Noise.Seed = (int)GD.Randi();
                    Noise.NoiseType = _noiseType;
                }
            }
        }

        public FastNoiseLite Noise = new();
        public float Trauma = 0f;
        public float NoiseY = 0f;

        private NoiseTypeEnum _noiseType = NoiseTypeEnum.Perlin;

        public override void _Ready() {
            Noise.Seed = (int)GD.Randi();
            Noise.NoiseType = _noiseType;
        }

        public override void _Process(double delta) {
            if (IsCurrent() && Trauma > 0) {
                Trauma = Mathf.Max(0, Trauma - Decay * (float)delta);
                NoiseY += NoiseSpeed;
                Shake();

            }
        }
        /// <summary>
        /// Add trauma value to start shaking this camera
        /// </summary>
        /// <param name="amount"></param>
        public void AddTrauma(float amount = 1f) {
            Trauma = Mathf.Min(Trauma + amount, 1f);
        }

        private void Shake() {
            var amount = Mathf.Pow(Trauma, TraumaPower);
            Offset = new Vector2(Amplitude * amount * Noise.GetNoise2D(Noise.Seed, NoiseY), Amplitude * amount * Noise.GetNoise2D(Noise.Seed * 2, NoiseY));
        }
    }
}