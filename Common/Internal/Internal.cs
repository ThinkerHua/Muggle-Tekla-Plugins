﻿using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.ModelUI;
using System;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.Common.Internal {
    /// <summary>
    /// 内部使用的类。
    /// </summary>
    public static class Internal {
        /// <summary>
        /// 显示给定变换平面。
        /// </summary>
        /// <param name="tp">给定变换平面</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">当 Tekla Structures 不在运行时引发。</exception>
        public static void ShowTransformationPlane(TransformationPlane tp) {
            if (tp is null) {
                throw new ArgumentNullException(nameof(tp));
            }

            var model = new Tekla.Structures.Model.Model();
            if (!model.GetConnectionStatus()) throw new Exception("Tekla Structures 不在运行。");
            var currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            var origin = new Point(0, 0, 0).Transform(tp, currentTP);
            var axisX = new Point(500, 0, 0).Transform(tp, currentTP);
            var axisY = new Point(0, 500, 0).Transform(tp, currentTP);
            var axisZ = new Point(0, 0, 500).Transform(tp, currentTP);

            var drawer = new GraphicsDrawer();
            drawer.DrawLineSegment(origin, axisX, ColorExtension.Red);
            drawer.DrawLineSegment(origin, axisY, ColorExtension.Green);
            drawer.DrawLineSegment(origin, axisZ, ColorExtension.Blue);
        }
        /// <summary>
        /// 显示给定坐标系。
        /// </summary>
        /// <param name="cs">给定坐标系</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">当 Tekla Structures 不在运行时引发。</exception>
        public static void ShowCoordinateSystem(CoordinateSystem cs) {
            if (cs is null) {
                throw new ArgumentNullException(nameof(cs));
            }

            var model = new Tekla.Structures.Model.Model();
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
