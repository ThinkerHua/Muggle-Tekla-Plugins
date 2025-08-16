using System;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace UnitTesting_NUnit3 {
    public class TDetailAttributes {
        private Model model;
        private Detail detail;
        [SetUp]
        public void Setup() {
            model = new Model();
            if (!model.GetConnectionStatus()) {
                throw new Exception("Failed to connect to Tekla Structures model.");
            }

            var picker = new Picker();
            try {
                detail = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "Pick a detail") as Detail;
            } catch (Exception e) when (e.Message == "User interrupted") {
                Assert.Inconclusive("Testing cancelled.");
            } catch (Exception e) {
                Assert.Fail(string.Format("Failed to pick a detail: \n{0}", e));
            }

            if (detail == null) {
                Assert.Fail("Picked object is not a detail.");
            }
        }

        [TestCase(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)]
        public void GetVerticalAndHorizontalPosition(
            int upMiddleLeft, int upMiddleMiddle, int upMiddleRight,
            int topLeft, int topMiddle, int topRight,
            int middleLeft, int middleMiddle, int middleRight,
            int bottomLeft, int bottomMiddle, int bottomRight) {
            detail.SetAttribute("UpMiddleLeft", upMiddleLeft);
            detail.SetAttribute("UpMiddleMiddle", upMiddleMiddle);
            detail.SetAttribute("UpMiddleRight", upMiddleRight);
            detail.SetAttribute("TopLeft", topLeft);
            detail.SetAttribute("TopMiddle", topMiddle);
            detail.SetAttribute("TopRight", topRight);
            detail.SetAttribute("MiddleLeft", middleLeft);
            detail.SetAttribute("MiddleMiddle", middleMiddle);
            detail.SetAttribute("MiddleRight", middleRight);
            detail.SetAttribute("BottomLeft", bottomLeft);
            detail.SetAttribute("BottomMiddle", bottomMiddle);
            detail.SetAttribute("BottomRight", bottomRight);

            int vertical_position = 0, horizontal_position = 0;
            detail.GetAttribute("vertical_position", ref vertical_position);
            detail.GetAttribute("horizontal_position", ref horizontal_position);
            detail.Modify();

            Console.WriteLine(string.Format("vertical_position = {0}", vertical_position));
            Console.WriteLine(string.Format("horizontal_position = {0}", horizontal_position));
        }
    }
}
