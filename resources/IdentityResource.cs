using Godot;
using System;

namespace GodotExtensionatorStarter {

    [Tool]
    [GlobalClass]
    public abstract partial class IdentityResource : Resource {
        public string Id { get; private set; }

        private Guid? _guid;

        public Guid GetId() {
            _guid ??= Guid.Parse(Id);

            return _guid.Value;
        }

        public IdentityResource() {
            Id = Guid.NewGuid().ToString();
        }
    }

}
