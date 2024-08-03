using Extensionator;
using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GodotExtensionatorStarter {

    public readonly struct DialogueBlock(string id, string text, AudioStream? voiceStream = null) {
        public string Id { get; } = id;
        public string Text { get; } = text;
        public AudioStream? VoiceStream { get; } = voiceStream;
    }
    public partial class SubtitleDisplayer : Control {

        public AudioStream voiceOne = GD.Load<AudioStream>("res://components/narrative/subtitles/voice1.mp3");
        public AudioStream voiceTwo = GD.Load<AudioStream>("res://components/narrative/subtitles/voice2.mp3");

        public delegate void SubtitleDisplayStartedEventHandler(DialogueBlock block);
        public delegate void SubtitleDisplayFinishedEventHandler(DialogueBlock block);

        public event SubtitleDisplayStartedEventHandler? SubtitleDisplayStarted;
        public event SubtitleDisplayFinishedEventHandler? SubtitleDisplayFinished;

        [Signal]
        public delegate void SubtitleBlocksFinishedToDisplayEventHandler();

        [Export] public bool CanBeSkipped = false;

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public AutoTypedText AutoTypedText { get; set; } = null!;
        public AudioStreamPlayer AudioStreamPlayer { get; set; } = null!;

        public List<DialogueBlock> DialogueBlocks { get; set; } = [];
        public DialogueBlock? CurrentDialogueBlock { get; set; } = default!;


        public override void _ExitTree() {
            AutoTypedText.Finished -= OnFinishedSubtitleBlockDisplay;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
        }


        public override void _Ready() {
            AudioStreamPlayer = GetNode<AudioStreamPlayer>(nameof(AudioStreamPlayer));
            AutoTypedText = GetNode<AutoTypedText>($"%{nameof(AutoTypedText)}");

            ArgumentNullException.ThrowIfNull(AutoTypedText);

            AutoTypedText.Skipped += OnSkippedSubtitleBlock;
            AutoTypedText.Finished += OnFinishedSubtitleBlockDisplay;

            AutoTypedText.ManualStart = false;
            AutoTypedText.CanBeSkipped = CanBeSkipped;
            AutoTypedText.Finished += OnFinishedSubtitleBlockDisplay;

            LoadDialogueBlocks([
                new DialogueBlock("id1", "porque esta puerta esta cerrada, no lo recuerdo joder", voiceOne),
                new DialogueBlock("id2", "Voy a darme un bano en mi cuuerpo asqueroso por favor", voiceTwo),

            ]);
        }

        public void LoadDialogueBlocks(IEnumerable<DialogueBlock> dialogueBlocks) {
            DialogueBlocks.AddRange(dialogueBlocks.ToList());

            if (CurrentDialogueBlock is null && DialogueBlocks.Count > 0)
                DisplayNextSubtitleBlock();
        }

        public void DisplayNextSubtitleBlock() {
            if (DialogueBlocks.IsEmpty()) {
                CurrentDialogueBlock = null;

                EmitSignal(SignalName.SubtitleBlocksFinishedToDisplay);
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.SubtitleBlocksFinishedToDisplay);

                return;
            }

            if (DialogueBlocks.PopFront() is DialogueBlock nextSubtitle) {

                if (CurrentDialogueBlock is DialogueBlock currentDialogueBlock) {
                    SubtitleDisplayFinished?.Invoke(currentDialogueBlock);
                    GlobalGameEvents.EmitSubtitleDisplayFinished(currentDialogueBlock);
                }

                CurrentDialogueBlock = nextSubtitle;

                SubtitleDisplayStarted?.Invoke(nextSubtitle);
                GlobalGameEvents.EmitSubtitleDisplayStarted(nextSubtitle);


                if (nextSubtitle.VoiceStream is not null) {
                    AudioStreamPlayer.Stream = nextSubtitle.VoiceStream;
                    AudioStreamPlayer.Play();
                }

                AutoTypedText.ReloadText(Tr(nextSubtitle.Text));
            }
        }

        private async void OnFinishedSubtitleBlockDisplay() {
            if (AudioStreamPlayer.Playing && !AudioManager.IsStreamLooped(AudioStreamPlayer.Stream)) {
                await ToSignal(AudioStreamPlayer, AudioStreamPlayer.SignalName.Finished);
                DisplayNextSubtitleBlock();
            }
            else {
                DisplayNextSubtitleBlock();
            }

        }

        private void OnSkippedSubtitleBlock() {
            AudioStreamPlayer.Stop();
        }
    }

}
