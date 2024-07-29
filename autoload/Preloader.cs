using Extensionator;
using Godot;

namespace GodotExtensionatorStarter {
    public sealed class Preloader : SingletonBase<Preloader> {

        public readonly ShaderMaterial VoronoiMaterial = GD.Load<ShaderMaterial>("res://autoload/scene_transitioner/transitions/voronoi_material.tres");

        public PackedScene LoadingScreenDefaultScene = GD.Load<PackedScene>("res://autoload/scene_transitioner/loading/LoadingScreen.tscn");

        public CompressedTexture2D DefaultPointer = GD.Load<CompressedTexture2D>("res://assets/crosshair/crosshair_dot.png");
        public CompressedTexture2D DefaultFocusPointer = GD.Load<CompressedTexture2D>("res://assets/crosshair/crosshair_circle_focus.png");
    }
}
