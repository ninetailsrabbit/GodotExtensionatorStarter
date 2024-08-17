using Godot;
using GodotExtensionator;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {
    public partial class AnyToWallRunTransition : Transition {

        public override bool ShouldTransition() {
            if (ToState is Wall wallState && wallState.Actor.WallRayCastDetector3D.AnyWallSideDetected()) {
                wallState.CurrentWallNormal = (new List<Vector3>() {
                    wallState.Actor.WallRayCastDetector3D.GetLeftWallNormal(),
                    wallState.Actor.WallRayCastDetector3D.GetRightWallNormal()
                }).FirstOrDefault(normal => normal.IsNotZeroApprox(), Vector3.Zero);

                return wallState.CurrentWallNormal.IsNotZeroApprox();
            }

            return false;
        }
    }
}
