using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/interaction/point_and_click/point_click_3d.svg")]
    public partial class PointClick3D : Node3D {

        [Export] public FirstPersonController FirstPersonController { get; set; } = null!;
        [Export] public MouseRayCastInteractor MouseRayCastInteractor { get; set; } = null!;

        public GlobalGameEvents GlobalGameEvents { get; set; } = null!;

        public override void _ExitTree() {
            GlobalGameEvents.PointClickMovementRequested -= OnPointClickMovementRequested;
        }
        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            FirstPersonController ??= GetTree().GetFirstNodeInGroup(FirstPersonController.GroupName) as FirstPersonController;
            MouseRayCastInteractor ??= this.FirstNodeOfClass<MouseRayCastInteractor>();

            ArgumentNullException.ThrowIfNull(FirstPersonController);
            ArgumentNullException.ThrowIfNull(MouseRayCastInteractor);

            GlobalGameEvents.PointClickMovementRequested += OnPointClickMovementRequested;
        }

        private void OnPointClickMovementRequested() {
            GD.Print("ALL GOOD BRO");
        }
    }
}
