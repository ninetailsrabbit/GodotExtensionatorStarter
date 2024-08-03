﻿using Godot;
using GodotExtensionator;
using System.Collections.Generic;
using System.Linq;

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

        [Signal]
        public delegate void ChangedLanguageEventHandler(string language);
        [Signal]
        public delegate void ChangedSubtitlesDisplayOptionEventHandler(bool enabled);
        [Signal]
        public delegate void ChangedSubtitlesLanguageEventHandler(string language);
        [Signal]
        public delegate void ChangedVoiceLanguageEventHandler(string language);

        [Signal]
        public delegate void UpdatedGraphicSettingsEventHandler(int qualityPreset);

        public delegate void SubtitleDisplayStartedEventHandler(DialogueBlock block);
        public delegate void SubtitleDisplayFinishedEventHandler(DialogueBlock block);
        public delegate void SubtitlesRequestedEventHandler(IEnumerable<DialogueBlock> dialogueBlocks);

        public event SubtitleDisplayStartedEventHandler? SubtitleDisplayStarted;
        public event SubtitleDisplayFinishedEventHandler? SubtitleDisplayFinished;
        public event SubtitlesRequestedEventHandler? SubtitlesRequested;

        public void EmitSubtitleDisplayStarted(DialogueBlock block) {
            SubtitleDisplayStarted?.Invoke(block);
        }
        public void EmitSubtitleDisplayFinished(DialogueBlock block) {
            SubtitleDisplayFinished?.Invoke(block);
        }

        public void EmitSubtitlesRequested(IEnumerable<DialogueBlock> dialogueBlocks) {
            SubtitlesRequested?.Invoke(dialogueBlocks);
        }

        [Signal]
        public delegate void SubtitleBlocksStartedToDisplayEventHandler();
        [Signal]
        public delegate void SubtitleBlocksFinishedToDisplayEventHandler();
        #endregion

        #region Point and click
        [Signal]
        public delegate void PointAndClickInteractedEventHandler(PointAndClickInteraction pointAndClick);
        [Signal]
        public delegate void PointAndClickInteractionCanceledEventHandler(PointAndClickInteraction pointAndClick);
        [Signal]
        public delegate void ActorMovedToPointAndClickPositionEventHandler(PointAndClickMovement pointAndClick);
        [Signal]
        public delegate void ActorScannedObjectEventHandler(PointAndClickObjectScanner pointAndClick);
        [Signal]
        public delegate void ActorCanceledScanEventHandler(PointAndClickObjectScanner pointAndClick);
        #endregion

        public override void _Notification(int what) {
            if (what == NotificationTranslationChanged) {
                UpdateAllTranslatables();
            }
        }

        public void UpdateAllTranslatables() {
            GetTree().Root.GetAllChildren<Node>()
                .Where(node => node is ITranslatable)
                .Cast<ITranslatable>()
                .ToList()
                .ForEach(translatable => translatable.OnLocaleChanged());
        }

    }

}