using Extensionator;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {

    public record Language(string Code, string IsoCode, string NativeName, string EnglishName);
    public static class Localization {
        public enum LANGUAGES {
            ENGLISH,
            CZECH,
            DANISH,
            GERMAN,
            GREEK,
            ESPERANTO,
            SPANISH,
            FRENCH,
            INDONESIAN,
            ITALIAN,
            LATVIAN,
            POLISH,
            PORTUGUESE_BRAZILIAN,
            PORTUGUESE,
            RUSSIAN,
            CHINESE_SIMPLIFIED,
            CHINESE_TRADITIONAL,
            NORWEGIAN_BOKMAL,
            HUNGARIAN,
            ROMANIAN,
            KOREAN,
            TURKISH,
            JAPANESE,
            UKRAINIAN
        }

        public static readonly Dictionary<LANGUAGES, Language> AvailableLanguages = new() {
        { LANGUAGES.ENGLISH,  new Language("en", "en_US", "English", "English") },
        { LANGUAGES.FRENCH, new Language("fr", "fr_FR", "Français", "French") },
        { LANGUAGES.CZECH, new Language("cs", "cs_CZ", "Czech", "Czech") },
        { LANGUAGES.DANISH, new Language("da", "da_DK", "Dansk", "Danish") },
        { LANGUAGES.GERMAN, new Language("de", "de_DE", "Deutsch", "German") },
        { LANGUAGES.GREEK, new Language("el", "el_GR", "Ελληνικά", "Greek") },
        { LANGUAGES.ESPERANTO, new Language("eo", "eo_UY", "Esperanto", "Esperanto") },
        { LANGUAGES.SPANISH, new Language("es", "es_ES", "Español", "Spanish") },
        { LANGUAGES.INDONESIAN, new Language("id", "id_ID", "Indonesian", "Indonesian") },
        { LANGUAGES.ITALIAN, new Language("it", "it_IT", "Italiano", "Italian") },
        { LANGUAGES.LATVIAN, new Language("lv", "lv_LV", "Latvian", "Latvian") },
        { LANGUAGES.POLISH, new Language("pl", "pl_PL", "Polski", "Polish") },
        { LANGUAGES.PORTUGUESE_BRAZILIAN, new Language("pt_BR", "pt_BR", "Português Brasileiro", "Brazilian Portuguese") },
        { LANGUAGES.PORTUGUESE, new Language("pt", "pt_PT", "Português", "Portuguese") },
        { LANGUAGES.RUSSIAN, new Language("ru", "ru_RU", "Русский", "Russian") },
        { LANGUAGES.CHINESE_SIMPLIFIED, new Language("zh_CN", "zh_CN", "简体中文", "Chinese Simplified") },
        { LANGUAGES.CHINESE_TRADITIONAL, new Language("zh_TW", "zh_TW", "繁體中文", "Chinese Traditional") },
        { LANGUAGES.NORWEGIAN_BOKMAL, new Language("nb", "nb_NO", "Norsk Bokmål", "Norwegian Bokmål") },
        { LANGUAGES.HUNGARIAN, new Language("hu", "hu_HU", "Magyar", "Hungarian") },
        { LANGUAGES.ROMANIAN, new Language("ro", "ro_RO", "Română", "Romanian") },
        { LANGUAGES.KOREAN, new Language("ko", "ko_KR", "한국어", "Korean") },
        { LANGUAGES.TURKISH, new Language("tr", "tr_TR", "Türkçe", "Turkish") },
        { LANGUAGES.JAPANESE, new Language("ja", "ja_JP", "日本語", "Japanese") },
        { LANGUAGES.UKRAINIAN, new Language("uk", "uk_UA", "Українська", "Ukrainian") },
    };

        public static Language FindByCode(string code) => AvailableLanguages.Values.First(language => language.Code.EqualsIgnoreCase(code));
        public static Language FindByIsoCode(string isoCode) => AvailableLanguages.Values.First(language => language.IsoCode.EqualsIgnoreCase(isoCode));
        public static Language FindByNativeName(string nativeName) => AvailableLanguages.Values.First(language => language.NativeName.EqualsIgnoreCase(nativeName));
        public static Language FindByEnglishName(string englishName) => AvailableLanguages.Values.First(language => language.EnglishName.EqualsIgnoreCase(englishName));

        public static Language English() => AvailableLanguages[LANGUAGES.ENGLISH];
        public static Language French() => AvailableLanguages[LANGUAGES.FRENCH];
        public static Language Czech() => AvailableLanguages[LANGUAGES.CZECH];
        public static Language Danish() => AvailableLanguages[LANGUAGES.DANISH];
        public static Language German() => AvailableLanguages[LANGUAGES.GERMAN];
        public static Language Greek() => AvailableLanguages[LANGUAGES.GREEK];
        public static Language Esperanto() => AvailableLanguages[LANGUAGES.ESPERANTO];
        public static Language Spanish() => AvailableLanguages[LANGUAGES.SPANISH];
        public static Language Indonesian() => AvailableLanguages[LANGUAGES.INDONESIAN];
        public static Language Italian() => AvailableLanguages[LANGUAGES.ITALIAN];
        public static Language Latvian() => AvailableLanguages[LANGUAGES.LATVIAN];
        public static Language Polish() => AvailableLanguages[LANGUAGES.POLISH];
        public static Language PortugueseBrazilian() => AvailableLanguages[LANGUAGES.PORTUGUESE_BRAZILIAN];
        public static Language Russian() => AvailableLanguages[LANGUAGES.RUSSIAN];
        public static Language ChineseSimplified() => AvailableLanguages[LANGUAGES.CHINESE_SIMPLIFIED];
        public static Language ChineseTraditional() => AvailableLanguages[LANGUAGES.CHINESE_TRADITIONAL];
        public static Language NorwegianBokmal() => AvailableLanguages[LANGUAGES.NORWEGIAN_BOKMAL];
        public static Language Hungarian() => AvailableLanguages[LANGUAGES.HUNGARIAN];
        public static Language Romanian() => AvailableLanguages[LANGUAGES.ROMANIAN];
        public static Language Korean() => AvailableLanguages[LANGUAGES.KOREAN];
        public static Language Turkish() => AvailableLanguages[LANGUAGES.TURKISH];
        public static Language Japanese() => AvailableLanguages[LANGUAGES.JAPANESE];
        public static Language Ukrainian() => AvailableLanguages[LANGUAGES.UKRAINIAN];
    }

}