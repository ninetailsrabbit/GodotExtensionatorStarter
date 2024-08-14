using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class ContentWarningsDisplayer : Control {
        [Signal]
        public delegate void ContentWarningDisplayedEventHandler(ContentWarning contentWarning);
        [Signal]
        public delegate void AllContentWarningsDisplayedEventHandler();

        [Export] public string[] InputActionsThatSkipWarning = ["ui_accept"];
        [Export] public Array<ContentWarning> ContentWarningsToDisplay = [];

        public Label ContentWarningTitle { get; set; } = null!;
        public Label ContentWarningSubtitle { get; set; } = null!;
        public RichTextLabel ContentWarningDescription { get; set; } = default!;
        public RichTextLabel ContentWarningSecondaryDescription { get; set; } = default!;

        private Array<ContentWarning> _remainingContentWarnings = [];
        private ContentWarning? CurrentContentWarning { get; set; } = default!;
        private Tween DisplayTween { get; set; } = default!;


        public override void _UnhandledInput(InputEvent @event) {
            if (InputExtension.IsAnyActionJustPressed(InputActionsThatSkipWarning)) {
                if (CurrentContentWarning is not null && CurrentContentWarning.CanBeSkipped) {
                    DisplayTween?.Kill();
                    EmitSignal(SignalName.ContentWarningDisplayed, CurrentContentWarning);
                }
            }
        }

        public override void _ExitTree() {
            ContentWarningDisplayed -= OnContentWarningDisplayed;
        }

        public override void _EnterTree() {
            ContentWarningTitle = GetNode<Label>($"%{nameof(ContentWarningTitle)}");
            ContentWarningSubtitle = GetNode<Label>($"%{nameof(ContentWarningSubtitle)}");
            ContentWarningDescription = GetNode<RichTextLabel>($"%{nameof(ContentWarningDescription)}");
            ContentWarningSecondaryDescription = GetNode<RichTextLabel>($"%{nameof(ContentWarningSecondaryDescription)}");

            HideAllTexts();

            ContentWarningDisplayed += OnContentWarningDisplayed;

        }

        public override void _Ready() {
            if (ContentWarningsToDisplay.IsEmpty()) {
                EmitSignal(SignalName.AllContentWarningsDisplayed);
            }
            else {
                _remainingContentWarnings = ContentWarningsToDisplay.Duplicate();

                DisplayContentWarning(_remainingContentWarnings.PopFront());
            }
        }

        private void HideAllTexts() {
            ContentWarningTitle.Modulate = ContentWarningTitle.Modulate with { A = 0 };
            ContentWarningSubtitle.Modulate = ContentWarningSubtitle.Modulate with { A = 0 };
            ContentWarningDescription.Modulate = ContentWarningDescription.Modulate with { A = 0 };
            ContentWarningSecondaryDescription.Modulate = ContentWarningSecondaryDescription.Modulate with { A = 0 };

            ContentWarningTitle.Text = string.Empty;
            ContentWarningSubtitle.Text = string.Empty;
            ContentWarningDescription.Text = string.Empty;
            ContentWarningSecondaryDescription.Text = string.Empty;
        }

        private async void DisplayContentWarning(ContentWarning contentWarning) {
            HideAllTexts();

            CurrentContentWarning = contentWarning;

            ContentWarningTitle.Text = Tr(contentWarning.TitleTranslationKey);
            ContentWarningSubtitle.Text = Tr(contentWarning.SubtitleTranslationKey);
            ContentWarningDescription.Text = Tr(contentWarning.DescriptionTranslationKey);
            ContentWarningSecondaryDescription.Text = Tr(contentWarning.SecondaryDescriptionTranslationKey);

            DisplayTween = CreateTween().SetParallel(true);
            DisplayTween.TweenProperty(ContentWarningTitle, "modulate:a", 1f, contentWarning.TimeToDisplayContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);
            DisplayTween.TweenProperty(ContentWarningSubtitle, "modulate:a", 1f, contentWarning.TimeToDisplayContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

            DisplayTween.Chain();
            DisplayTween.TweenProperty(ContentWarningDescription, "modulate:a", 1f, contentWarning.TimeToDisplayContentWarning / 2)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);
            DisplayTween.TweenProperty(ContentWarningSecondaryDescription, "modulate:a", 1f, contentWarning.TimeToDisplayContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

            await ToSignal(DisplayTween, Tween.SignalName.Finished);
            await ToSignal(GetTree().CreateTimer(contentWarning.TimeOnScreen), Timer.SignalName.Timeout);

            HideContentWarning(contentWarning);

        }

        private async void HideContentWarning(ContentWarning contentWarning) {
            DisplayTween = CreateTween().SetParallel(true);
            DisplayTween.TweenProperty(ContentWarningTitle, "modulate:a", 0, contentWarning.TimeToHideContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);
            DisplayTween.TweenProperty(ContentWarningSubtitle, "modulate:a", 0, contentWarning.TimeToHideContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

            DisplayTween.TweenProperty(ContentWarningDescription, "modulate:a", 0, contentWarning.TimeToHideContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);
            DisplayTween.TweenProperty(ContentWarningSecondaryDescription, "modulate:a", 0, contentWarning.TimeToHideContentWarning)
                .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

            await ToSignal(DisplayTween, Tween.SignalName.Finished);

            EmitSignal(SignalName.ContentWarningDisplayed, contentWarning);
        }

        private void OnContentWarningDisplayed(ContentWarning _) {
            if (_remainingContentWarnings.IsEmpty()) {
                EmitSignal(SignalName.AllContentWarningsDisplayed);
                SetProcessUnhandledInput(false);
                CurrentContentWarning = null;
            }
            else {
                DisplayContentWarning(_remainingContentWarnings.PopFront());
            }
        }
    }
}