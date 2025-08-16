using System.IO;
using Tekla.Structures;
using Tekla.Structures.Dialog;

namespace UnitTesting_NUnit3 {
    public class TLocalization {
        [Test]
        public void TestLocalization() {
            var language = string.Empty;
            TeklaStructuresSettings.GetAdvancedOption("XS_LANGUAGE", ref language);
            language = GetShortLanguage(language);

            var dir = string.Empty;
            TeklaStructuresSettings.GetAdvancedOption("XSDATADIR", ref dir);
            dir = Path.Combine(dir, @"Environments\common\extensions\messages\MuggleTeklaPlugins\General.ail");

            var localization = new Localization(dir, language);

            Assert.That(localization.GetText("j_d_jd_Pos_no"), Is.EqualTo("位置编号"));
        }

        private static string GetShortLanguage(string Language) {
            return Language switch {
                "ENGLISH" => "enu",
                "DUTCH" => "nld",
                "FRENCH" => "fra",
                "GERMAN" => "deu",
                "ITALIAN" => "ita",
                "SPANISH" => "esp",
                "JAPANESE" => "jpn",
                "CHINESE SIMPLIFIED" => "chs",
                "CHINESE TRADITIONAL" => "cht",
                "CZECH" => "csy",
                "PORTUGUESE BRAZILIAN" => "ptb",
                "HUNGARIAN" => "hun",
                "POLISH" => "plk",
                "RUSSIAN" => "rus",
                _ => "enu",
            };
        }
    }
}
