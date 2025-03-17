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
            var plate = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a contour plate:") as ContourPlate;
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
