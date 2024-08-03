using Extensionator;
using Godot;

namespace GodotExtensionatorStarter {
    public sealed class Preloader : SingletonBase<Preloader> {

        public readonly ShaderMaterial VoronoiMaterial = GD.Load<ShaderMaterial>("res://autoload/scene_transitioner/transitions/voronoi_material.tres");

        public PackedScene LoadingScreenDefaultScene = GD.Load<PackedScene>("res://autoload/scene_transitioner/loading/LoadingScreen.tscn");

        #region Crosshairs
        public CompressedTexture2D DefaultPointer = GD.Load<CompressedTexture2D>("res://assets/crosshair/crosshair_dot.png");
        public CompressedTexture2D DefaultFocusPointer = GD.Load<CompressedTexture2D>("res://assets/crosshair/crosshair_circle_focus.png");
        #endregion

        #region Cursors
        public CompressedTexture2D CursorPointerA = GD.Load<CompressedTexture2D>("res://assets/cursors/pointer_a.png");
        public CompressedTexture2D CursorPointerB = GD.Load<CompressedTexture2D>("res://assets/cursors/pointer_b.png");
        public CompressedTexture2D CursorPointerC = GD.Load<CompressedTexture2D>("res://assets/cursors/pointer_c.png");
        public CompressedTexture2D CursorStep = GD.Load<CompressedTexture2D>("res://assets/cursors/steps.png");
        public CompressedTexture2D CursorHandThinOpen = GD.Load<CompressedTexture2D>("res://assets/cursors/hand_thin_open.png");
        public CompressedTexture2D CursorHandThinClosed = GD.Load<CompressedTexture2D>("res://assets/cursors/hand_thin_closed.png");
        public CompressedTexture2D CursorZoom = GD.Load<CompressedTexture2D>("res://assets/cursors/zoom.png");
        public CompressedTexture2D CursorLook = GD.Load<CompressedTexture2D>("res://assets/cursors/look_c.png");
        public CompressedTexture2D CursorLock = GD.Load<CompressedTexture2D>("res://assets/cursors/lock.png");
        public CompressedTexture2D CursorDialogue = GD.Load<CompressedTexture2D>("res://assets/cursors/message_dots_square.png");
        public CompressedTexture2D CursorHelp = GD.Load<CompressedTexture2D>("res://assets/cursors/cursor_help.png");
        #endregion

        #region Sounds
        
        #endregion
    }
}
