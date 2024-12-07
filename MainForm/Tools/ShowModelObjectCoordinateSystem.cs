using Muggle.TeklaPlugins.Common.Internal;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
    internal class ShowModelObjectCoordinateSystem {
        public static void Run() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            ModelObject obj;
            try {
                obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                while (obj != null) {
                    Internal.ShowCoordinateSystem(obj.GetCoordinateSystem());
                    obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                }
            } catch {

            }
        }
    }
}
