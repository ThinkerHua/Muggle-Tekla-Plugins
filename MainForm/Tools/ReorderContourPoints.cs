/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2025 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  ReorderContourPoints.cs: reorder contour points of a contour plate
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.Collections;
using System.Linq;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
    public static class ReorderContourPoints {
        public static void Run() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            ContourPlate plate;
            try {
                plate = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a contour plate:") as ContourPlate;
            } catch {
                return;
            }

            if (plate == null) {
                Operation.DisplayPrompt("No contour plate selected.");
                return;
            }
            var point = picker.PickPoint("Select a point as the first point:");

            var contour = plate.Contour.ContourPoints.Cast<ContourPoint>();
            var index = contour
                .Select((p, i) => (i, Distance.PointToPoint(p, point)))
                .OrderBy(item => item.Item2).First().i;

            var newContour = contour.Skip(index).Concat(contour.Take(index)).ToList();
            plate.Contour.ContourPoints = new ArrayList(newContour);
            plate.Modify();
            model.CommitChanges();
        }
    }
}
