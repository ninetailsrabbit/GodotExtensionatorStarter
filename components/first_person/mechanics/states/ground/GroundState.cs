using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {
    public partial class GroundState : MachineState {

        [Export] public FirstPersonController Actor { get; set; } = default!;
        [Export] public string RunInputAction = "run";
        [Export] public string CrouchInputAction = "crouch";
        [Export] public string CrawlInputAction = "crawl";
        [Export] public string JumpInputAction = "jump";
        [Export] public float GravityForce = 9.8f;
        [Export] public float Speed = 10f;
        [Export] public float Acceleration = 0;
        [Export] public float Deceleration = 0;


        public void ApplyGravity(float force, double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            Actor.Velocity += Actor.UpDirectionOpposite() * (float)(force * delta);
        }
    }

}
