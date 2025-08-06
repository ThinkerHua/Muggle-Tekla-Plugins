using System;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace UnitTesting_NUnit3 {
    public sealed class TInfoGetter {
        [Test]
        public void GetDetailAutoDirectionType() {
            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Assert.Inconclusive("Model connection is not established.");
            }

            var picker = new Picker();
            if (picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "Pick a detial") is not Detail detail) {
                Assert.Inconclusive("No detail was picked.");
                return;
            }

            Assert.That(detail.AutoDirectionType, Is.EqualTo(Tekla.Structures.AutoDirectionTypeEnum.AUTODIR_DETAIL));
        }

        [Test]
        public void GetBaseComponentInfo() {
            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Assert.Inconclusive("Model connection is not established.");
            }

            var picker = new Picker();
            if (picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT,
                    "Pick a BaseComponent (such as component, connection, customPart, detail or seam.")
                is not BaseComponent baseComponent) {
                Assert.Inconclusive("No BaseComponent was picked.");
                return;
            }

            Console.WriteLine($"Name - {baseComponent.Name}, Number - {baseComponent.Number}");
        }
    }
}
