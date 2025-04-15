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
 *  MainForm.cs: main form of tools and plugins
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.Windows.Forms;
using Muggle.TeklaPlugins.MainForm.Plugins;
using Muggle.TeklaPlugins.MainForm.Tools;

namespace Muggle.TeklaPlugins.MainForm {
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

        private void Run_ReorderContourPoints(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            ReorderContourPoints.Run();
            WindowState = FormWindowState.Normal;
        }

        private void Run_CopyWithDirection(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            CopyWithDirection.Run();
            WindowState = FormWindowState.Normal;
        }
    }
}
