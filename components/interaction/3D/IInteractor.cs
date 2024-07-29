using Godot;
using System;

namespace GodotExtensionatorStarter {

    public interface IInteractor : IDisposable {

        public void Interact(GodotObject interactable);
        public void CancelInteract(GodotObject interactable);
        public void Focus(GodotObject interactable);
        public void UnFocus(GodotObject interactable);
    }

}