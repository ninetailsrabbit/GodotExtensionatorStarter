using Extensionator;
using Godot;
using GodotExtensionator;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class LanguageSelector : OptionButton {

        public Localization.LANGUAGES[] LanguagesIncluded = [
            Localization.LANGUAGES.English,
            Localization.LANGUAGES.Spanish
        ];

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public Dictionary<int, Language> LanguageByOptionButtonId = [];

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            ItemSelected += OnLanguageSelected;
        }

        public override void _Ready() {
            int id = 0;

            foreach (var languageIncluded in LanguagesIncluded) {
                Language language = Localization.AvailableLanguages[languageIncluded];

                AddItem(language.NativeName, id);

                if (language.Code.EqualsIgnoreCase(SettingsFileHandlerAutoload.GetLocalizationSection("current_language").ToString()))
                    Select(ItemCount - 1);

                LanguageByOptionButtonId.Add(id, language);

                id += 1;
            }
        }

        private void OnLanguageSelected(long idx) {
            Language currentLanguage = LanguageByOptionButtonId[GetItemId((int)idx)];
            SettingsFileHandlerAutoload.UpdateLocalizationSection("current_language", currentLanguage.IsoCode);
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }


}