using System;
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

            var sampleText = "j_d_jd_Pos_no";
            var resultText = localization.GetText(sampleText);

            if (language == "enu") {
                Assert.That(resultText, Is.EqualTo("Pos_No"));
            } else if (language == "chs") {
                Assert.That(resultText, Is.EqualTo("位置编号"));
            } else {
                Console.WriteLine(string.Format(
                    "Current language is: {0}, and \"j_d_jd_Pos_no\" be translated to: {1}",
                    language,
                    resultText)
                );
            }
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
