using Extensionator;
using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GodotExtensionatorStarter {
    public partial class SubtitleDisplayer : Control {
        [Signal]
        public delegate void SubtitleDisplayStartedEventHandler(GenericGodotWrapper<DialogueBlock> block);
        [Signal]
        public delegate void SubtitleDisplayFinishedEventHandler(GenericGodotWrapper<DialogueBlock> block);

        [Export] public bool CanBeSkipped = false;

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public AutoTypedText AutoTypedText { get; set; } = null!;

        public List<DialogueBlock> DialogueBlocks { get; set; } = [];
        public DialogueBlock? CurrentDialogueBlock { get; set; } = default!;

        public override void _ExitTree() {
            SubtitleDisplayStarted -= OnSubtitleDisplayStarted;
            SubtitleDisplayFinished -= OnSubtitleDisplayFinished;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();

            SubtitleDisplayStarted += OnSubtitleDisplayStarted;
            SubtitleDisplayFinished += OnSubtitleDisplayFinished;
        }

        public override void _Ready() {
            AutoTypedText = GetNode<AutoTypedText>($"%{nameof(AutoTypedText)}");

            ArgumentNullException.ThrowIfNull(AutoTypedText);

            AutoTypedText.ManualStart = false;
            AutoTypedText.CanBeSkipped = CanBeSkipped;
            AutoTypedText.Finished += OnFinishedSubtitleBlockDisplay;
        }

        public void LoadDialogueBlocks(IEnumerable<DialogueBlock> dialogueBlocks) {
            DialogueBlocks.AddRange(dialogueBlocks.ToList());

            if (CurrentDialogueBlock is null && DialogueBlocks.Count > 0)
                DisplayNextSubtitleBlock();
        }

        public void DisplayNextSubtitleBlock() {
            if (DialogueBlocks.PopFront() is DialogueBlock nextSubtitle) {
                CurrentDialogueBlock = nextSubtitle;

                EmitSignal(SignalName.SubtitleDisplayFinished, new GenericGodotWrapper<DialogueBlock>((DialogueBlock)CurrentDialogueBlock));
                EmitSignal(SignalName.SubtitleDisplayStarted, new GenericGodotWrapper<DialogueBlock>(nextSubtitle));

                AutoTypedText.ReloadText(Tr(nextSubtitle.Text));
            }
            else {
                CurrentDialogueBlock = null;
            }
        }

        private void OnFinishedSubtitleBlockDisplay() {
            DisplayNextSubtitleBlock();
        }

        private void OnSubtitleDisplayStarted(GenericGodotWrapper<DialogueBlock> block) {
            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.SubtitleDisplayStarted, block);
        }

        private void OnSubtitleDisplayFinished(GenericGodotWrapper<DialogueBlock> block) {
            GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.SubtitleDisplayFinished, block);
        }

    }


    public readonly struct DialogueBlock(string id, string text, AudioStream? voiceStream = null) {
        public StringName Id { get; } = id;
        public string Text { get; } = text;
        public AudioStream? VoiceStream { get; } = voiceStream;
    }
}