using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace MuggleTeklaPlugins.MainForm.Tools {
    internal class SelectWeldedObjects {
        public static void Run() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            try {
                var weld = new Picker().PickObject(Picker.PickObjectEnum.PICK_ONE_WELD) as Weld;
                var parts = new ArrayList {
                    weld.MainObject,
                    weld.SecondaryObject,
                };
                var UISelector = new Tekla.Structures.Model.UI.ModelObjectSelector();
                UISelector.Select(parts);

                model.CommitChanges();
            } catch {

            }
        }
    }
}
