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
 *  SelectWeldedObjects.cs: select objects that welded
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
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
