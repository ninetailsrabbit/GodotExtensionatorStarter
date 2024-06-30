using Godot;

namespace GodotExtensionatorStarter {
    public partial class GlobalGameEvents : Node {

        #region InteractableSignals
        [Signal]
        public delegate void FocusedEventHandler(GodotObject interactor);
        [Signal]
        public delegate void UnFocusedEventHandler(GodotObject interactor);
        [Signal]
        public delegate void InteractedEventHandler(GodotObject interactor);
        [Signal]
        public delegate void CanceledInteractionEventHandler(GodotObject interactor);
        #endregion

        #region Player
        [Signal]
        public delegate void LockPlayerEventHandler();
        [Signal]
        public delegate void UnlockPlayerEventHandler();
        #endregion

        #region Game
        [Signal]
        public delegate void GamePausedEventHandler();
        [Signal]
        public delegate void GameResumedEventHandler();
        #endregion

    }

}