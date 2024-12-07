using System.Collections;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
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
