using Godot;

namespace GodotExtensionatorStarter {
    public partial class GameGlobals : Node {
        public readonly uint WorldCollisionLayer = 1;
        public readonly uint PlayerCollisionLayer = 2;
        public readonly uint EnemiesCollisionLayer = 4;
        public readonly uint InteractablesCollisionLayer = 8;
        public readonly uint ThrowablesCollisionLayer = 16;
        public readonly uint HitboxesCollisionLayer = 32;


        public string NextScenePath = string.Empty;
    }

}