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
 *  Program.cs: entrance of "MainForm"
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.Windows.Forms;

namespace Muggle.TeklaPlugins.MainForm {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
