using Godot;
using System;

namespace GodotExtensionatorStarter {
    public partial class ScanViewport : Node3D {
        public Marker3D Marker3D { get; set; } = default!;
        public MouseRotatorComponent3D MouseRotatorComponent3D { get; set; } = default!;
        public Camera3D ScanCamera { get; set; } = default!;
        public PointAndClickController Actor { get; set; } = null!;

        public override void _EnterTree() {
            Marker3D = GetNode<Marker3D>(nameof(Marker3D));
            MouseRotatorComponent3D = GetNode<MouseRotatorComponent3D>(nameof(MouseRotatorComponent3D));
            ScanCamera = GetNode<Camera3D>(nameof(Camera3D));

            ArgumentNullException.ThrowIfNull(Marker3D);
            ArgumentNullException.ThrowIfNull(MouseRotatorComponent3D);
            ArgumentNullException.ThrowIfNull(ScanCamera);
        }

        public override void _Ready() {
            Actor ??= GetTree().GetFirstNodeInGroup(PointAndClickController.GroupName) as PointAndClickController;
            ArgumentNullException.ThrowIfNull(Actor);
        }

        public void SetCurrentMouseCursor(CompressedTexture2D cursorTexture) {
            Input.SetCustomMouseCursor(cursorTexture, Input.CursorShape.Arrow, cursorTexture.GetSize() / 2);
        }
        public void ChangeMouseCursor(CompressedTexture2D? cursorTexture) {
            if (cursorTexture is not null)
                MouseRotatorComponent3D.SelectedCursor = cursorTexture;
        }
        public void ChangeMouseRotatorCursor(CompressedTexture2D? cursorTexture) {
            if (cursorTexture is not null)
                MouseRotatorComponent3D.SelectedRotateCursor = cursorTexture;
        }

    }
}