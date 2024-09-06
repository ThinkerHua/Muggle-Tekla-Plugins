using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace MuggleTeklaPlugins.MainForm {
    public partial class SelectBooleans : Form {
        /*private enum BooleanTypeEnum {
            NONE = 0,
            BOOLEAN_ADD = 1,
            BOOLEAN_CUT = 2,
            BOOLEAN_WELDPREP = 4,
            CUTPLANE = 8,
            EDGECHAMFER = 16,
            FITTING = 32,
        }*/
        public SelectBooleans() {
            InitializeComponent();
        }

        private void StartSelect(object sender, EventArgs e) {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            var part = (Part) picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);

            var objectEnumerator = part.GetBooleans();
            Type type;
            var objects = new ArrayList();

            foreach (var item in objectEnumerator) {
                type = item.GetType();
                if (filter_BooleanAdd.Checked &&
                    type == typeof(BooleanPart) &&
                    ((BooleanPart) item).Type == BooleanPart.BooleanTypeEnum.BOOLEAN_ADD)
                    objects.Add(item);

                if (filter_BooleanCut.Checked &&
                    type == typeof(BooleanPart) &&
                    ((BooleanPart) item).Type == BooleanPart.BooleanTypeEnum.BOOLEAN_CUT)
                    objects.Add(item);

                if (filter_BooleanWeldPrep.Checked &&
                    type == typeof(BooleanPart) &&
                    ((BooleanPart) item).Type == BooleanPart.BooleanTypeEnum.BOOLEAN_WELDPREP)
                    objects.Add(item);

                if (filter_CutPlane.Checked &&
                    type == typeof(CutPlane))
                    objects.Add(item);

                if (filter_EdgeChamfer.Checked &&
                    type == typeof(EdgeChamfer))
                    objects.Add(item);

                if (filter_Fitting.Checked &&
                    type == typeof(Fitting))
                    objects.Add(item);
            }

            var ms = new Tekla.Structures.Model.UI.ModelObjectSelector();
            ms.Select(objects, false);

            model.CommitChanges();
        }
    }
}
