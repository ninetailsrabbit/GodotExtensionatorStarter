using Godot;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {

    public partial class Transition : RefCounted {
        public MachineState? FromState { get; set; }
        public MachineState? ToState { get; set; }

        public Dictionary<string, object>? Parameters = null;

        public virtual bool ShouldTransition() => true;
        public virtual void OnTransition() { }
    }

}