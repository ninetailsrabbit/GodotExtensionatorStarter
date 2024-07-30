using Extensionator;
using Godot;

namespace GodotExtensionatorStarter {
    public partial class GlobalFade : Node {

        [Signal]
        public delegate void FadeStartedEventHandler();

        [Signal]
        public delegate void FadeFinishedEventHandler();

        [Export] public Color DefaultFadeColor = new("040404");

        public ColorRect FadeBackground { get; set; } = default!;

        public bool IsFading = false;

        public override void _Ready() {
            FadeBackground = GetNode<ColorRect>($"%{nameof(FadeBackground)}");
            FadeBackground.Color = DefaultFadeColor;
            FadeBackground.Modulate = FadeBackground.Modulate with { A = 0 };

        }

        public async void FadeIn(float duration = 0.5f, Color? color = null) {
            if (!IsFading && FadeBackground.Modulate.A.IsZero()) {
                IsFading = true;
                EmitSignal(SignalName.FadeStarted);

                FadeBackground.Color = color ?? DefaultFadeColor;

                var tween = CreateTween();
                tween.TweenProperty(FadeBackground, "modulate:a", 1f, duration)
                    .SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Quad);

                await ToSignal(tween, Tween.SignalName.Finished);

                IsFading = false;

                EmitSignal(SignalName.FadeFinished);
            }
        }

        public async void FadeOut(float duration = 0.5f, Color? color = null) {
            if (!IsFading && FadeBackground.Modulate.A.IsGreaterThanZero()) {
                IsFading = true;

                EmitSignal(SignalName.FadeStarted);

                FadeBackground.Color = color ?? DefaultFadeColor;

                var tween = CreateTween();
                tween.TweenProperty(FadeBackground, "modulate:a", 0, duration)
                    .SetEase(Tween.EaseType.Out).SetTrans(Tween.TransitionType.Quad);

                await ToSignal(tween, Tween.SignalName.Finished);

                IsFading = false;

                EmitSignal(SignalName.FadeFinished);
            }
        }
    }
}
