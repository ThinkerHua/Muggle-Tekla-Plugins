using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;

using MuggleTeklaPlugins.Internal;

namespace MuggleTeklaPlugins.MainForm {
    public partial class MainForm : Form {
        private SelectBooleans formSelectBooleans;//  SelectBooleans子窗体
        public MainForm() {
            InitializeComponent();
        }

        private void ButtonSelectBooleans_Click(object sender, EventArgs e) {
            if (formSelectBooleans == null || formSelectBooleans.IsDisposed) {
                formSelectBooleans = new SelectBooleans();
            }
            formSelectBooleans.Show();
            formSelectBooleans.Activate();
        }

        private void ShowModelObjectCoordinateSystem(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;

            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            ModelObject obj;
            try {
                obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                while (obj != null) {
                    Test.ShowCoordinateSystem(obj.GetCoordinateSystem());
                    obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                }
            } catch {

            }

            WindowState = FormWindowState.Normal;
        }
    }
}
