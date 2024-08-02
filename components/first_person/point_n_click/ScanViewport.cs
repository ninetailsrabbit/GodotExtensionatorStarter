using Godot;
using GodotExtensionatorStarter;
using System;

public partial class ScanViewport : Node3D
{
	public Marker3D Marker3D { get; set; } = default!;
	public MouseRotatorComponent3D MouseRotatorComponent3D { get; set; } = default!;

    public override void _EnterTree()
	{
		Marker3D = GetNode<Marker3D>(nameof(Marker3D));
        MouseRotatorComponent3D = GetNode<MouseRotatorComponent3D>(nameof(MouseRotatorComponent3D));

        Marker3D.ChildEnteredTree += OnMarkerChildEntered;
        Marker3D.ChildExitingTree += OnMarkerChildExited;
    }


	private void OnMarkerChildEntered(Node child) {
		if (child is Node3D _child) {
			MouseRotatorComponent3D.Target = _child;
		}
	}

    private void OnMarkerChildExited(Node child) {
        if (child is Node3D) {
            MouseRotatorComponent3D.Target = null;
        }
    }
}
