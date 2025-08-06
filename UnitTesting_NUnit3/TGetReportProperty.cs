using System;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace UnitTesting_NUnit3 {
    public class TGetReportProperty {

        private static Part part;

        [SetUp]
        public void Setup() {
            if (part != null) return;

            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Assert.Inconclusive("Model connection is not established.");
            }

            var picker = new Picker();
            try {
                part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "Pick a part.") as Part;
            } catch (Exception e) when (e.Message == "User interrupt") {
                Assert.Inconclusive("Interrupted by user");
            } catch (Exception e) {
                Assert.Inconclusive(e.ToString());
            }

        }


        [TestCase("WIDTH")]
        [TestCase("HEIGHT")]
        [TestCase("LEVEL")]
        [TestCase("BOTTOM_LEVEL")]
        [TestCase("ASSEMBLY_BOTTOM_LEVEL")]
        [TestCase("COG_X")]
        [TestCase("COG_Y")]
        [TestCase("COG_Z")]
        public void GetDoubleReportProperty(string propertyName) {
            var value = 0.0;

            if (!part.GetReportProperty(propertyName, ref value)) {
                Assert.Fail($"Failed to get value of \"{propertyName}\".");
            } else {
                Console.WriteLine($"{propertyName} = {value}");
            }

        }

        [TestCase("PROFILE")]
        [TestCase("PROFILE_TYPE")]
        [TestCase("BOTTOM_LEVEL")]
        public void GetStringReportProperty(string propertyName) {
            var value = string.Empty;

            if (!part.GetReportProperty(propertyName, ref value)) {
                Assert.Fail($"Failed to get value of \"{propertyName}\".");
            } else {
                Console.WriteLine($"{propertyName} = {value}");
            }
        }
    }
}