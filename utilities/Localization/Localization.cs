using Extensionator;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {
    public record Language(string Code, string IsoCode, string NativeName, string EnglishName);
    public static class Localization {
        public enum LANGUAGES {
            English,
            Czech,
            Danish,
            Dutch,
            German,
            Greek,
            Esperanto,
            Spanish,
            French,
            Indonesian,
            Italian,
            Latvian,
            Polish,
            PortugueseBrazilian,
            Portuguese,
            Russian,
            ChineseSimplified,
            ChineseTraditional,
            NorwegianBokmal,
            Hungarian,
            Romanian,
            Korean,
            Turkish,
            Japanese,
            Ukrainian
        }

        public static readonly Dictionary<LANGUAGES, Language> AvailableLanguages = new() {
        { LANGUAGES.English,  new Language("en", "en_US", "English", "English") },
        { LANGUAGES.French, new Language("fr", "fr_FR", "Français", "French") },
        { LANGUAGES.Czech, new Language("cs", "cs_CZ", "Czech", "Czech") },
        { LANGUAGES.Danish, new Language("da", "da_DK", "Dansk", "Danish") },
        { LANGUAGES.Dutch, new Language("nl", "nl_NL", "Nederlands", "Dutch") },
        { LANGUAGES.German, new Language("de", "de_DE", "Deutsch", "German") },
        { LANGUAGES.Greek, new Language("el", "el_GR", "Ελληνικά", "Greek") },
        { LANGUAGES.Esperanto, new Language("eo", "eo_UY", "Esperanto", "Esperanto") },
        { LANGUAGES.Spanish, new Language("es", "es_ES", "Español", "Spanish") },
        { LANGUAGES.Indonesian, new Language("id", "id_ID", "Indonesian", "Indonesian") },
        { LANGUAGES.Italian, new Language("it", "it_IT", "Italiano", "Italian") },
        { LANGUAGES.Latvian, new Language("lv", "lv_LV", "Latvian", "Latvian") },
        { LANGUAGES.Polish, new Language("pl", "pl_PL", "Polski", "Polish") },
        { LANGUAGES.PortugueseBrazilian, new Language("pt_BR", "pt_BR", "Português Brasileiro", "Brazilian Portuguese") },
        { LANGUAGES.Portuguese, new Language("pt", "pt_PT", "Português", "Portuguese") },
        { LANGUAGES.Russian, new Language("ru", "ru_RU", "Русский", "Russian") },
        { LANGUAGES.ChineseSimplified, new Language("zh_CN", "zh_CN", "简体中文", "Chinese Simplified") },
        { LANGUAGES.ChineseTraditional, new Language("zh_TW", "zh_TW", "繁體中文", "Chinese Traditional") },
        { LANGUAGES.NorwegianBokmal, new Language("nb", "nb_NO", "Norsk Bokmål", "Norwegian Bokmål") },
        { LANGUAGES.Hungarian, new Language("hu", "hu_HU", "Magyar", "Hungarian") },
        { LANGUAGES.Romanian, new Language("ro", "ro_RO", "Română", "Romanian") },
        { LANGUAGES.Korean, new Language("ko", "ko_KR", "한국어", "Korean") },
        { LANGUAGES.Turkish, new Language("tr", "tr_TR", "Türkçe", "Turkish") },
        { LANGUAGES.Japanese, new Language("ja", "ja_JP", "日本語", "Japanese") },
        { LANGUAGES.Ukrainian, new Language("uk", "uk_UA", "Українська", "Ukrainian") },
    };

        #region Helpers
        public static Language FindByCode(string code) => AvailableLanguages.Values.First(language => language.Code.EqualsIgnoreCase(code));
        public static Language FindByIsoCode(string isoCode) => AvailableLanguages.Values.First(language => language.IsoCode.EqualsIgnoreCase(isoCode));
        public static Language FindByNativeName(string nativeName) => AvailableLanguages.Values.First(language => language.NativeName.EqualsIgnoreCase(nativeName));
        public static Language FindByEnglishName(string englishName) => AvailableLanguages.Values.First(language => language.EnglishName.EqualsIgnoreCase(englishName));
        #endregion

        #region Language functions
        public static Language English() => AvailableLanguages[LANGUAGES.English];
        public static Language French() => AvailableLanguages[LANGUAGES.French];
        public static Language Czech() => AvailableLanguages[LANGUAGES.Czech];
        public static Language Danish() => AvailableLanguages[LANGUAGES.Danish];
        public static Language Dutch() => AvailableLanguages[LANGUAGES.Dutch];
        public static Language German() => AvailableLanguages[LANGUAGES.German];
        public static Language Greek() => AvailableLanguages[LANGUAGES.Greek];
        public static Language Esperanto() => AvailableLanguages[LANGUAGES.Esperanto];
        public static Language Spanish() => AvailableLanguages[LANGUAGES.Spanish];
        public static Language Indonesian() => AvailableLanguages[LANGUAGES.Indonesian];
        public static Language Italian() => AvailableLanguages[LANGUAGES.Italian];
        public static Language Latvian() => AvailableLanguages[LANGUAGES.Latvian];
        public static Language Polish() => AvailableLanguages[LANGUAGES.Polish];
        public static Language PortugueseBrazilian() => AvailableLanguages[LANGUAGES.PortugueseBrazilian];
        public static Language Russian() => AvailableLanguages[LANGUAGES.Russian];
        public static Language ChineseSimplified() => AvailableLanguages[LANGUAGES.ChineseSimplified];
        public static Language ChineseTraditional() => AvailableLanguages[LANGUAGES.ChineseTraditional];
        public static Language NorwegianBokmal() => AvailableLanguages[LANGUAGES.NorwegianBokmal];
        public static Language Hungarian() => AvailableLanguages[LANGUAGES.Hungarian];
        public static Language Romanian() => AvailableLanguages[LANGUAGES.Romanian];
        public static Language Korean() => AvailableLanguages[LANGUAGES.Korean];
        public static Language Turkish() => AvailableLanguages[LANGUAGES.Turkish];
        public static Language Japanese() => AvailableLanguages[LANGUAGES.Japanese];
        public static Language Ukrainian() => AvailableLanguages[LANGUAGES.Ukrainian];
        #endregion

        #region Translation keys
        //Here lives all the keys that are pretended to be used with Tr()
        public static readonly string NoTranslationKey = "GENERAL_NO";
        public static readonly string YesTranslationKey = "GENERAL_YES";

        public static readonly string AudioTabTranslationKey = "AUDIO_TAB";
        public static readonly string ScreenTabTranslationKey = "SCREEN_TAB";
        public static readonly string GraphicsTabTranslationKey = "GRAPHICS_TAB";
        public static readonly string GeneralTabTranslationKeyTr = "GENERAL_TAB";

        public static readonly string DeuteranopiaTranslationKey = "DALTONISM_DEUTERANOPIA";
        public static readonly string ProtanopiaTranslationKey = "DALTONISM_PROTANOPIA";
        public static readonly string TritanopiaTranslationKey = "DALTONISM_TRITANOPIA";
        public static readonly string AchromatopsiaTranslationKey = "DALTONISM_ACHROMATOPSIA";

        public static readonly string GraphicsQualityTranslationKey = "GRAPHICS_QUALITY";

        public static readonly string QualityLowTranslationKey = "QUALITY_LOW";
        public static readonly string QualityMediumTranslationKey = "QUALITY_MEDIUM";
        public static readonly string QualityHighTranslationKey = "QUALITY_HIGH";
        public static readonly string QualityUltraTranslationKey = "QUALITY_ULTRA";
        #endregion
    }

}