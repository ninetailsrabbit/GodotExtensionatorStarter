using Extensionator;
using Godot;

namespace GodotExtensionatorStarter {
    public sealed class Preloader : SingletonBase<Preloader> {

        public readonly ShaderMaterial VoronoiMaterial = GD.Load<ShaderMaterial>("res://autoload/scene_transitioner/transitions/voronoi_material.tres");

        public PackedScene LoadingScreenDefaultScene = GD.Load<PackedScene>("res://autoload/scene_transitioner/loading/LoadingScreen.tscn");

    }
}
