using Extensionator;
using Godot;

namespace GodotExtensionatorStarter {
    public sealed class Preloader : SingletonBase<Preloader> {

        public readonly ShaderMaterial VORNOI_MATERIAL = GD.Load<ShaderMaterial>("res://autoload/scene_transitioner/transitions/voronoi_material.tres");


    }
}
