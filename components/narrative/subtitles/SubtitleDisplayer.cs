using System;
using System.Collections.Generic;
using System.Linq;
using Extensionator;
using Godot;
using GodotExtensionator;


namespace GodotExtensionatorStarter {

    public readonly struct DialogueBlock(string id, string speaker, string text, bool autoType = true, AudioStream? voiceStream = null) {
        public string Id { get; } = id;
        public string Speaker { get; } = speaker;
        public string Text { get; } = text;
        public bool AutoType { get; } = autoType;
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

        [Export] public bool StaticDisplay = false;
        [Export] public bool AutoTypeCanBeSkipped = false;
        [Export] public bool ManualSubtitleTransition = false;
        [Export] public float TimeBetweenBlocks = 1f;
        [Export] public bool UseTypeSounds = false;
        [Export] public string[] InputActionsToTransition = ["ui_accept"];
        public enum SubtitleState {
            WaitingForInput,
            Displaying,
            Neutral
        }

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public AutoTypedText AutoTypedText { get; set; } = null!;
        public AudioStreamPlayer AudioStreamPlayer { get; set; } = null!;
        public Timer BetweenBlocksTimer { get; set; } = null!;

        public List<DialogueBlock> DialogueBlocks { get; set; } = [];
        public DialogueBlock? CurrentDialogueBlock { get; set; } = default!;

        public SubtitleState CurrentSubtitleState = SubtitleState.Neutral;
        public bool IsDisplaying {
            get => _isDisplaying;
            set {
                if (_isDisplaying != value) {
                    _isDisplaying = value;

                    CurrentSubtitleState = _isDisplaying ? SubtitleState.Displaying : SubtitleState.Neutral;
                }

            }
        }

        private bool _isDisplaying = false;

        public override void _ExitTree() {
            GlobalGameEvents.SubtitlesRequested -= OnSubtitlesRequested;

            SubtitleBlocksFinishedToDisplay -= OnSubtitleBlocksFinishedToDisplay;

            AutoTypedText.Skipped -= OnSkippedSubtitleBlock;
            AutoTypedText.Finished -= OnFinishedSubtitleBlockDisplay;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            GlobalGameEvents.SubtitlesRequested += OnSubtitlesRequested;

            SubtitleBlocksFinishedToDisplay += OnSubtitleBlocksFinishedToDisplay;
        }

        public override void _Input(InputEvent @event) {
            if (ManualSubtitleTransition &&
                CurrentSubtitleState.Equals(SubtitleState.WaitingForInput) &&
                InputExtension.IsAnyActionJustPressed(InputActionsToTransition) && !AutoTypedText.IsSkipped) {
                DisplayNextSubtitleBlock();
            }

            if (AutoTypeCanBeSkipped && AutoTypedText.IsSkipped)
                AutoTypedText.IsSkipped = false;
        }


        public override void _Ready() {
            AudioStreamPlayer = GetNode<AudioStreamPlayer>(nameof(AudioStreamPlayer));
            AudioStreamPlayer.Bus = "Voice";

            BetweenBlocksTimer = GetNode<Timer>(nameof(BetweenBlocksTimer));
            BetweenBlocksTimer.WaitTime = MathF.Max(0.05f, TimeBetweenBlocks);
            BetweenBlocksTimer.Autostart = false;
            BetweenBlocksTimer.OneShot = true;
            BetweenBlocksTimer.Timeout += OnBetweenBlocksTimerTimeout;

            AutoTypedText = GetNode<AutoTypedText>($"%{nameof(AutoTypedText)}");
            ArgumentNullException.ThrowIfNull(AutoTypedText);

            AutoTypedText.UseTypeSounds = UseTypeSounds;
            AutoTypedText.ManualStart = false;
            AutoTypedText.CanBeSkipped = AutoTypeCanBeSkipped;

            AutoTypedText.Skipped += OnSkippedSubtitleBlock;
            AutoTypedText.Finished += OnFinishedSubtitleBlockDisplay;


            LoadDialogueBlocks([new DialogueBlock("100", "potato", "give me the freedom i want piece of shit")]);
        }

        public void LoadDialogueBlocks(IEnumerable<DialogueBlock> dialogueBlocks) {
            var previousDialogueBlocksCount = DialogueBlocks.Count;

            DialogueBlocks.AddRange(dialogueBlocks.ToList().RemoveDuplicates());

            if (previousDialogueBlocksCount.IsZero() && DialogueBlocks.Count > 0) {
                IsDisplaying = true;

                EmitSignal(SignalName.SubtitleBlocksStartedToDisplay);
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.SubtitleBlocksStartedToDisplay);
            }


            if (CurrentDialogueBlock is null && DialogueBlocks.Count > 0) {
                Show();
                DisplayNextSubtitleBlock();

            }
        }

        public void DisplayNextSubtitleBlock() {
            if (DialogueBlocks.IsEmpty()) {

                if (CurrentDialogueBlock is not null) {
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

                CurrentSubtitleState = SubtitleState.Displaying;
                CurrentDialogueBlock = nextSubtitle;

                SubtitleDisplayStarted?.Invoke(nextSubtitle);
                GlobalGameEvents.EmitSubtitleDisplayStarted(nextSubtitle);


                if (nextSubtitle.VoiceStream is not null) {
                    AudioStreamPlayer.Stream = nextSubtitle.VoiceStream;
                    AudioStreamPlayer.Play();
                }

                if (nextSubtitle.AutoType) {
                    AutoTypedText.ReloadText(Tr(nextSubtitle.Text));
                }
                else {
                    AutoTypedText.Text = Tr(nextSubtitle.Text);
                    AutoTypedText.EmitSignal(AutoTypedText.SignalName.Finished);
                }

            }
        }

        private void OnSubtitlesRequested(IEnumerable<DialogueBlock> dialogueBlocks) {
            LoadDialogueBlocks(dialogueBlocks);
        }

        private async void OnFinishedSubtitleBlockDisplay() {
            if (AudioStreamPlayer.Playing && !AudioManager.IsStreamLooped(AudioStreamPlayer.Stream)) {
                await ToSignal(AudioStreamPlayer, AudioStreamPlayer.SignalName.Finished);
            }

            if (ManualSubtitleTransition)
                CurrentSubtitleState = SubtitleState.WaitingForInput;
            else
                BetweenBlocksTimer.Start();
        }

        private void OnBetweenBlocksTimerTimeout() {
            DisplayNextSubtitleBlock();
        }

        private void OnSkippedSubtitleBlock() {
            AudioStreamPlayer.Stop();

            if (ManualSubtitleTransition)
                CurrentSubtitleState = SubtitleState.WaitingForInput;

        }

        private void OnSubtitleBlocksFinishedToDisplay() {
            CurrentDialogueBlock = null;
            BetweenBlocksTimer.Stop();
            IsDisplaying = false;

            AutoTypedText.Clear();
            Hide();
        }
    }

}
