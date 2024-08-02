using Extensionator;
using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class AutoTypedText : RichTextLabel {
        const char BBcodeStartFlag = '[';
        const char BBcodeEndFlag = ']';

        [Signal]
        public delegate void FinishedEventHandler();

        [Export] public string ContentToDisplay = string.Empty;
        [Export] public bool ManualStart = false;
        [Export] public string[] InputActionsToStart = ["ui_accept"];
        [Export] public bool CanBeSkipped = true;
        [Export] public string[] InputActionsToSkip = ["ui_accept"];
        [Export] public float LetterTime = 0.03f;
        [Export] public float SpaceTime = 0.06f;
        [Export] public float PunctuationTime = 0.2f;

        public int LetterIndex = -1;
        public Timer TypingTimer { get; set; } = default!;
        public string CurrentBBcode = string.Empty;
        public bool BBCodeFlag = false;
        public bool IsTyping = false;
        public bool TypingFinished = false;


        public override void _UnhandledInput(InputEvent @event) {
            if (!TypingFinished) {

                if (IsTyping) {
                    if (CanBeSkipped && InputExtension.IsAnyActionJustPressed(InputActionsToStart))
                        Skip();
                }
                else {
                    if (ManualStart && InputExtension.IsAnyActionJustPressed(InputActionsToStart))
                        DisplayLetters();
                }
            }
        }
        public override void _ExitTree() {
            Finished -= OnFinishedContentDisplay;
        }
        public override void _EnterTree() {
            Finished += OnFinishedContentDisplay;

            CreateTypingTimer();
        }

        public override void _Ready() {
            BbcodeEnabled = true;
            FitContent = true;

            if (!ManualStart && ContentToDisplay.Length > 0) {
                DisplayLetters();
            }
        }

        public void DisplayLetters() {
            if (TypingFinished)
                return;

            LetterIndex += 1;

            if (LetterIndex > ContentToDisplay.Length - 1) {
                EmitSignal(SignalName.Finished);
                return;
            }

            IsTyping = true;

            char nextCharacter = ContentToDisplay[LetterIndex];

            if (!BBCodeFlag && nextCharacter.Equals(BBcodeStartFlag)) {
                TypingTimer.Stop();
                BBCodeFlag = true;
            }

            if (BBCodeFlag) {
                CurrentBBcode += nextCharacter;
                BBCodeFlag = !nextCharacter.Equals(BBcodeEndFlag);

                DisplayLetters();

                return;
            }
            else {
                if (CurrentBBcode.Length > 0) {
                    Text += CurrentBBcode + nextCharacter;
                    CurrentBBcode = string.Empty;

                    DisplayLetters();

                    return;
                }
            }

            Text += nextCharacter;

            if (LetterIndex <= ContentToDisplay.Length - 1) {
                char currentCharacter = ContentToDisplay[LetterIndex];

                if (char.IsWhiteSpace(currentCharacter))
                    TypingTimer.Start(SpaceTime);
                else if (Extensionator.StringExtension.AsciiPunctuation.Contains(ContentToDisplay[LetterIndex]))
                    TypingTimer.Start(PunctuationTime);
                else
                    TypingTimer.Start(LetterTime);
            }
        }

        public void ReloadText(string text) {
            if (!IsTyping) {
                SetProcessUnhandledInput(true);
                ContentToDisplay = text;
                DisplayLetters();
            }
        }

        public void Skip() {
            if (IsTyping) {
                Text = string.Empty;
                AppendText(ContentToDisplay);
                EmitSignal(SignalName.Finished);
            }
        }

        private void OnFinishedContentDisplay() {
            LetterIndex = -1;
            ContentToDisplay = string.Empty;
            IsTyping = false;
            TypingFinished = true;
            SetProcessUnhandledInput(false);

            if (IsInstanceValid(TypingTimer))
                TypingTimer.Stop();
        }

        private void CreateTypingTimer() {
            TypingTimer ??= new Timer {
                Name = "TypingTimer",
                WaitTime = LetterTime,
                ProcessCallback = Timer.TimerProcessCallback.Idle,
                Autostart = false,
                OneShot = true
            };

            AddChild(TypingTimer);
            TypingTimer.Timeout += OnTypingTimerTimeout;
        }

        private void OnTypingTimerTimeout() {
            DisplayLetters();
        }

    }
}
