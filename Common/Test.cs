using System;
using System.Collections.Generic;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

using MuggleTeklaPlugins.Geometry3dExtension;
using MuggleTeklaPlugins.ModelExtension.UIExtension;

namespace MuggleTeklaPlugins.Internal {
    public static class Test {
        public static void ShowTransformationPlane(TransformationPlane tp) {
            if (tp is null) {
                throw new ArgumentNullException(nameof(tp));
            }

            var model = new Model();
            if (!model.GetConnectionStatus()) throw new Exception("Tekla Structures 不在运行。");
            var currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            var origin = new Point(0, 0, 0);
            var axisX = new Point(500, 0, 0);
            var axisY = new Point(0, 500, 0);
            var axisZ = new Point(0, 0, 500);

            origin.Transform(tp, currentTP);
            axisX.Transform(tp, currentTP);
            axisY.Transform(tp, currentTP);
            axisZ.Transform(tp, currentTP);

            var drawer = new GraphicsDrawer();
            drawer.DrawLineSegment(origin, axisX, ColorExtension.Red);
            drawer.DrawLineSegment(origin, axisY, ColorExtension.Green);
            drawer.DrawLineSegment(origin, axisZ, ColorExtension.Blue);
        }
        public static void ShowCoordinateSystem(CoordinateSystem cs) {
            if (cs is null) {
                throw new ArgumentNullException(nameof(cs));
            }

            var model = new Model();
            if (!model.GetConnectionStatus()) throw new Exception("Tekla Structures 不在运行。");

            var axisX = new Vector(cs.AxisX);
            var axisY = new Vector(cs.AxisY);
            var axisZ = axisX.Cross(axisY);
            axisX.Normalize(500);
            axisY.Normalize(500);
            axisZ.Normalize(500);

            var drawer = new GraphicsDrawer();
            drawer.DrawLineSegment(cs.Origin, cs.Origin + axisX, ColorExtension.Red);
            drawer.DrawLineSegment(cs.Origin, cs.Origin + axisY, ColorExtension.Green);
            drawer.DrawLineSegment(cs.Origin, cs.Origin + axisZ, ColorExtension.Blue);
        }
    }
}