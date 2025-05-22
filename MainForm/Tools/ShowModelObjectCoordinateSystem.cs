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
 *  ShowModelObjectCoordinateSystem.cs: show model object's coordinatesystem
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using Muggle.TeklaPlugins.Common.Internal;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
    internal class ShowModelObjectCoordinateSystem {
        public static void Run() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            ModelObject obj;
            try {
                while (true) {
                    obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                    if (obj is PolyBeam polyBeam) {
                        var css = polyBeam.GetPolybeamCoordinateSystems();
                        foreach (CoordinateSystem cs in css) {
                            Internal.ShowCoordinateSystem(cs);
                        }
                    } else {
                        Internal.ShowCoordinateSystem(obj.GetCoordinateSystem());
                    }
                }
            } catch {

            }
        }
    }
}
