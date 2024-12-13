/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2024 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  SelectBooleans.cs: form and main method of select part's boolean operation objects
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.Collections;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
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
            WindowState = FormWindowState.Minimized;

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
                    ((BooleanPart) item).Type == BooleanPart.BooleanTypeEnum.BOOLEAN_ADD) {
                    objects.Add(item);
                    continue;
                }

                if (filter_BooleanCut.Checked &&
                    type == typeof(BooleanPart) &&
                    ((BooleanPart) item).Type == BooleanPart.BooleanTypeEnum.BOOLEAN_CUT) {
                    objects.Add(item);
                    continue;
                }

                if (filter_BooleanWeldPrep.Checked &&
                    type == typeof(BooleanPart) &&
                    ((BooleanPart) item).Type == BooleanPart.BooleanTypeEnum.BOOLEAN_WELDPREP) {
                    objects.Add(item);
                    continue;
                }

                if (filter_CutPlane.Checked &&
                    type == typeof(CutPlane)) {
                    objects.Add(item);
                    continue;
                }

                if (filter_EdgeChamfer.Checked &&
                    type == typeof(EdgeChamfer)) {
                    objects.Add(item);
                    continue;
                }

                if (filter_Fitting.Checked &&
                    type == typeof(Fitting)) {
                    objects.Add(item);
                    continue;
                }
            }

            var ms = new Tekla.Structures.Model.UI.ModelObjectSelector();
            ms.Select(objects, false);

            model.CommitChanges();

            WindowState = FormWindowState.Normal;
        }
    }
}
