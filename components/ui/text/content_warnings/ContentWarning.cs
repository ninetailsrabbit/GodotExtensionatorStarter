using Godot;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class ContentWarning : Resource {
        [Export] public bool CanBeSkipped = false;
        [ExportGroup("Time")]
        [Export] public float TimeOnScreen = 5f;
        [Export] public float TimeToDisplayContentWarning = 2f;
        [Export] public float TimeToHideContentWarning = 2f;
        [ExportGroup("Original text")]
        [Export] public string Title = string.Empty;
        [Export] public string Subtitle = string.Empty;
        [Export] public string Description = string.Empty;
        [Export] public string SecondaryDescription = string.Empty;
        [ExportGroup("Translation keys")]
        [Export] public string TitleTranslationKey = string.Empty;
        [Export] public string SubtitleTranslationKey = string.Empty;
        [Export] public string DescriptionTranslationKey = string.Empty;
        [Export] public string SecondaryDescriptionTranslationKey = string.Empty;
    }
}
