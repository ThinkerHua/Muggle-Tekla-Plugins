using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting_NUnit3 {
    public class TValueParser {

        [TestCase("+0.000")]
        [TestCase("+3.200")]
        [TestCase("-0.000")]
        [TestCase("-4.000")]
        [TestCase("±0.000")]
        public void DoubleParse(string text) {
            Assert.That(double.TryParse(text, out double value), Is.True);

            Console.WriteLine(value);
        }
    }
}
