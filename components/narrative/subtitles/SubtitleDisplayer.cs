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

        public delegate void SubtitleDisplayStartedEventHandler(DialogueBlock block);
        public delegate void SubtitleDisplayFinishedEventHandler(DialogueBlock block);

        public event SubtitleDisplayStartedEventHandler? SubtitleDisplayStarted;
        public event SubtitleDisplayFinishedEventHandler? SubtitleDisplayFinished;

        [Signal]
        public delegate void SubtitleBlocksStartedToDisplayEventHandler();
        [Signal]
        public delegate void SubtitleBlocksFinishedToDisplayEventHandler();

        [Export] public bool CanBeSkipped = false;
        [Export] public bool ManualSubtitleTransition = false;
        [Export] public float TimeBetweenBlocks = 1f;
        [Export] public string[] InputActionsToTransition = ["ui_accept"];

        public enum SubtitleState {
            WAITING_FOR_INPUT,
            DISPLAYING,
            NEUTRAL
        }

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public AutoTypedText AutoTypedText { get; set; } = null!;
        public AudioStreamPlayer AudioStreamPlayer { get; set; } = null!;
        public Timer BetweenBlocksTimer { get; set; } = null!;

        public List<DialogueBlock> DialogueBlocks { get; set; } = [];
        public DialogueBlock? CurrentDialogueBlock { get; set; } = default!;

        public SubtitleState CurrentSubtitleState = SubtitleState.NEUTRAL;
        public bool IsDisplaying {
            get => _isDisplaying;
            set {
                if (_isDisplaying != value) {
                    _isDisplaying = value;

                    CurrentSubtitleState = _isDisplaying ? SubtitleState.DISPLAYING : SubtitleState.NEUTRAL;
                }

            }
        }

        private bool _isDisplaying = false;

        public override void _ExitTree() {
            GlobalGameEvents.SubtitlesRequested -= OnSubtitlesRequested;

            AutoTypedText.Finished -= OnFinishedSubtitleBlockDisplay;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            GlobalGameEvents.SubtitlesRequested += OnSubtitlesRequested;
        }

        public override void _Input(InputEvent @event) {
            if (ManualSubtitleTransition &&
                CurrentSubtitleState.Equals(SubtitleState.WAITING_FOR_INPUT) &&
                InputExtension.IsAnyActionJustPressed(InputActionsToTransition)) {
                DisplayNextSubtitleBlock();
            }
        }


        public override void _Ready() {
            AudioStreamPlayer = GetNode<AudioStreamPlayer>(nameof(AudioStreamPlayer));
            BetweenBlocksTimer = GetNode<Timer>(nameof(BetweenBlocksTimer));

            BetweenBlocksTimer.WaitTime = MathF.Max(0.05f, TimeBetweenBlocks);
            BetweenBlocksTimer.Autostart = false;
            BetweenBlocksTimer.OneShot = true;
            BetweenBlocksTimer.Timeout += OnBetweenBlocksTimerTimeout;

            AutoTypedText = GetNode<AutoTypedText>($"%{nameof(AutoTypedText)}");

            ArgumentNullException.ThrowIfNull(AutoTypedText);

            AutoTypedText.ManualStart = false;
            AutoTypedText.CanBeSkipped = CanBeSkipped;
            AutoTypedText.Skipped += OnSkippedSubtitleBlock;
            AutoTypedText.Finished += OnFinishedSubtitleBlockDisplay;

        }

        public void LoadDialogueBlocks(IEnumerable<DialogueBlock> dialogueBlocks) {
            var previousDialogueBlocksCount = DialogueBlocks.Count;

            DialogueBlocks.AddRange(dialogueBlocks.ToList().RemoveDuplicates());

            if (previousDialogueBlocksCount.IsZero() && DialogueBlocks.Count > 0) {
                IsDisplaying = true;

                EmitSignal(SignalName.SubtitleBlocksStartedToDisplay);
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.SubtitleBlocksStartedToDisplay);
            }


            if (CurrentDialogueBlock is null && DialogueBlocks.Count > 0)
                DisplayNextSubtitleBlock();
        }

        public void DisplayNextSubtitleBlock() {
            if (DialogueBlocks.IsEmpty()) {

                if (CurrentDialogueBlock is not null) {
                    CurrentDialogueBlock = null;
                    BetweenBlocksTimer.Stop();
                    IsDisplaying = false;

                    EmitSignal(SignalName.SubtitleBlocksFinishedToDisplay);
                    GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.SubtitleBlocksFinishedToDisplay);
                }

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

        private void OnSubtitlesRequested(IEnumerable<DialogueBlock> dialogueBlocks) {
            LoadDialogueBlocks(dialogueBlocks);
        }

        private async void OnFinishedSubtitleBlockDisplay() {
            if (AudioStreamPlayer.Playing && !AudioManager.IsStreamLooped(AudioStreamPlayer.Stream)) {
                await ToSignal(AudioStreamPlayer, AudioStreamPlayer.SignalName.Finished);

            }

            if (!ManualSubtitleTransition)
                BetweenBlocksTimer.Start();
        }

        private void OnBetweenBlocksTimerTimeout() {
            if (ManualSubtitleTransition)
                CurrentSubtitleState = SubtitleState.WAITING_FOR_INPUT;
            else
                DisplayNextSubtitleBlock();
        }

        private void OnSkippedSubtitleBlock() {
            AudioStreamPlayer.Stop();
        }
    }

}
