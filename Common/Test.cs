using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

using MuggleTeklaPlugins.Geometry3dExtension;
using MuggleTeklaPlugins.ModelExtension.UIExtension;

namespace MuggleTeklaPlugins.Internal {
    public static class Test {
        public static void ShowTransformationPlane(TransformationPlane tp) {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;
            var currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            var origio = new Point(0, 0, 0);
            var axisX = new Point(500, 0, 0);
            var axisY = new Point(0, 500, 0);
            var axisZ = new Point(0, 0, 500);

            origio.Transform(tp, currentTP);
            axisX.Transform(tp, currentTP);
            axisY.Transform(tp, currentTP);
            axisZ.Transform(tp, currentTP);

            var drawer = new GraphicsDrawer();
            drawer.DrawLineSegment(origio, axisX, ColorExtension.Red);
            drawer.DrawLineSegment(origio, axisY, ColorExtension.Green);
            drawer.DrawLineSegment(origio, axisZ, ColorExtension.Blue);
        }
    }
}