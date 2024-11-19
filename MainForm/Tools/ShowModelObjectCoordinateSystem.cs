using MuggleTeklaPlugins.Common.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace MuggleTeklaPlugins.MainForm.Tools {
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
