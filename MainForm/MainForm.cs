using System;
using System.Collections;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using MuggleTeklaPlugins.Common.Internal;
using MuggleTeklaPlugins.MainForm.Tools;
using MuggleTeklaPlugins.MainForm.Plugins;

namespace MuggleTeklaPlugins.MainForm {
    public partial class MainForm : Form {
        private SelectBooleans formSelectBooleans;//  SelectBooleans子窗体
        public MainForm() {
            InitializeComponent();
        }

        private void SelectBooleans(object sender, EventArgs e) {
            if (formSelectBooleans == null || formSelectBooleans.IsDisposed) {
                formSelectBooleans = new SelectBooleans();
            }
            formSelectBooleans.Show();
            formSelectBooleans.Activate();
        }

        private void Run_ShowModelObjectCoordinateSystem(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            ShowModelObjectCoordinateSystem.Run();
            WindowState = FormWindowState.Normal;
        }

        private void Run_SelectWeldedObjects(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            SelectWeldedObjects.Run();
            WindowState = FormWindowState.Normal;
        }

        private void Run_WK1001(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            WK1001_Outer.Run();
            WindowState = FormWindowState.Normal;
        }
    }
}
