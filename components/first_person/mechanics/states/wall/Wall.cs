using Extensionator;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class Wall : MachineState {

        [Export] public FirstPersonController Actor { get; set; } = default!;
        [Export(PropertyHint.Range, "0, 360f, 0.01f")] public float CameraRotationAngle = 15f;
        [Export] public float CameraLerpRotationSpeed = 8f;
        [Export] public float WallGravity = 0.5f;
        [Export] public float WallSpeed = 7.5f;
        [Export] public float WallAcceleration = 0;
        [Export] public float WallFriction = 0f;
        [Export] public string JumpInputAction { get; set; } = "jump";

        public enum WallSide {
            Right,
            Left,
            Front
        }

        public Vector3 CurrentWallNormal = Vector3.Zero;
        public WallSide CurrentWallSide = WallSide.Front;

        public override void Exit(MachineState _) {
            CurrentWallNormal = Vector3.Zero;
            CurrentWallSide = WallSide.Front;
        }

        public override void PhysicsUpdate(double delta) {
            ApplyGravity(WallGravity, delta);
        }

        public void ApplyGravity(float force, double? delta = null) {
            if (WallGravity.IsZero())
                return;

            delta ??= GetPhysicsProcessDeltaTime();

            Actor.Velocity += Actor.UpDirectionOpposite() * (float)(force * delta);
        }

        public void DetectJump() {
            if (Actor.WallJump && InputMap.HasAction(JumpInputAction) && Input.IsActionJustPressed(JumpInputAction))
                FSM?.ChangeStateTo<Jump>();
        }
    }
}
