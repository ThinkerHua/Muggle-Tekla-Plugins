using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.ModelInternal;
using Tekla.Structures.Geometry3d;

using MuggleTeklaPlugins.Common;
using MuggleTeklaPlugins.Geometry3dExtension;
using MuggleTeklaPlugins.ModelExtension;
using MuggleTeklaPlugins.ModelExtension.UIExtension;
using MuggleTeklaPlugins.Internal;

namespace UnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestConnection() {
            var model = new Model();
            if (!model.GetConnectionStatus())
                return;

            var connection = new Connection {
                Name = "MG1001",
                Number = -200000,
                Class = -1
            };

            var picker = new Picker();
            var primPart = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            var secdPart = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            connection.SetPrimaryObject(primPart);
            connection.SetSecondaryObject(secdPart);

            if (connection.Insert()) {
                Console.WriteLine(connection.Name);
                Console.WriteLine(connection.Number);
            }

            model.CommitChanges();
        }
        [TestMethod]
        public void TestLineSegmentLength() {
            var lineSeg = new LineSegment();
            Console.WriteLine("The length of the LineSegment constructed by the default constructor:\n\t" + lineSeg.Length());

            var line1 = new Line(new Point(1, 2, 0), new Vector(1.1, 2.2, 0));
            var line2 = new Line(new Point(11, 12, 0), new Vector(2, 3, 0));
            lineSeg = Tekla.Structures.Geometry3d.Intersection.LineToLine(line1, line2);
            Console.WriteLine("The length of the LineSegmemt constructed by method Intersection.LineToLine:\n\t" + lineSeg.Length());
            Console.WriteLine($"If lineSeg.Length() == 0.0:\n\t{lineSeg.Length() == 0.0}");
            Console.WriteLine($"lineSeg.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"lineSeg.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"If lineSeg.StartPoint == lineSeg.EndPoint:\n\t{lineSeg.StartPoint == lineSeg.EndPoint}");
            Console.WriteLine($"Distance of lineSeg.StartPoint and lineSeg.EndPoint:\n\t{Distance.PointToPoint(lineSeg.StartPoint, lineSeg.EndPoint)}");
            Console.WriteLine($"The second method of calculating the length:\n\t" +
                Math.Sqrt(Math.Pow(lineSeg.StartPoint.X - lineSeg.EndPoint.X, 2) +
                          Math.Pow(lineSeg.StartPoint.Y - lineSeg.EndPoint.Y, 2) +
                          Math.Pow(lineSeg.StartPoint.Z - lineSeg.EndPoint.Z, 2)));
        }
        [TestMethod]
        public void TestShowTransformationTP() {
            Model model = new Model();
            if (!model.GetConnectionStatus())
                return;

            TransformationPlane partTP;
            Picker picker = new Picker();
            var obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "选择展示其零件坐标系的零件：");
            partTP = new TransformationPlane(obj.GetCoordinateSystem());

            Test.ShowTransformationPlane(partTP);

        }
        [TestMethod]
        public void TestPointExtension() {
            var point1 = new Point(1, 2, 3);
            var point2 = new Point(4, 5, 6);
            point1.Translate(point2);
            Console.WriteLine(point1);

            var tp1 = new TransformationPlane(new Point(0, 0, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            var tp2 = new TransformationPlane(new Point(10, 10, 10), new Vector(1, 0, 0), new Vector(0, 1, 0));
            point1.Transform(tp1, tp2);
            Console.WriteLine(point1);

            var sourceCS = new CoordinateSystem(new Point(10, 10, 10), new Vector(0, 1, 0), new Vector(0, 0, 1));
            var targetCS = new CoordinateSystem(new Point(100, 200, 300), new Vector(1, 1, 0), new Vector(0, 1, 1));
            var currentCS = new CoordinateSystem();
            point1.Transform(currentCS, targetCS);
            Console.WriteLine(point1);
            point1.TransformTo(sourceCS);
            Console.WriteLine(point1);
            point1.TransformFrom(targetCS);
            Console.WriteLine(point1);

        }
        [TestMethod]
        public void TestPolygonExtension() {
            var polygon = new Polygon();
            polygon.Points.Add(new Point(1, 2, 3));
            polygon.Points.Add(new Point(4, 5, 6));
            polygon.Points.Add(new Point(7, 8, 9));

            var polygon2 = polygon.Clone();
            var msg = string.Empty;
            foreach (var item in polygon2.Points) {
                msg += $"\n{item}";
            }
            Console.WriteLine(msg);
        }
        [TestMethod]
        public void TestSwap() {
            int a = 1, b = 2;
            CommonOperation.Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");

            Point point1, point2;
            point1 = new Point(1, 2, 3);
            point2 = new Point(4, 5, 6);
            CommonOperation.Swap(ref point1, ref point2);
            Console.WriteLine($"point1 = {point1}");
            Console.WriteLine($"point2 = {point2}");
        }
        [TestMethod]
        public void TestMatrix() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var globalTP = new TransformationPlane();
            var currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            var picker = new Picker();
            var part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            var partCS = part.GetCoordinateSystem();
            var partTP = new TransformationPlane(partCS);
            Console.WriteLine($"Global TransformationPlane:\n{globalTP}");
            Console.WriteLine($"Current TransformationPlane:\n{currentTP}");
            Console.WriteLine($"Part TransformationPlane:\n{partTP}");
            var matrix = partTP.TransformationMatrixToLocal;
            Console.WriteLine($"Matrix:\n{matrix}");
            matrix = matrix.GetTranspose();
            Console.WriteLine($"Matrix:\n{matrix}");

            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(globalTP);
            var globalCS = new CoordinateSystem();
            var targetCS1 = new CoordinateSystem(new Point(100, 200, 300), new Vector(1, 0, 0), new Vector(0, 1, 0));
            var targetCS2 = new CoordinateSystem(new Point(100, 200, 300), new Vector(0, 1, 0), new Vector(-1, 0, 0));
            var targetCS3 = new CoordinateSystem(new Point(100, 200, 300), new Vector(-1, 0, 0), new Vector(0, -1, 0));
            var targetCS4 = new CoordinateSystem(new Point(100, 200, 300), new Vector(0, -1, 0), new Vector(1, 0, 0));
            var targetCS5 = new CoordinateSystem(new Point(100, 200, 300), new Vector(0, 1, 0), new Vector(1, 0, 0));
            var rotationMatrix = Tekla.Structures.Geometry3d.MatrixFactory.Rotate(Math.PI * 0.5, new Vector(0, 0, 1));
            var translationMatrix = new Matrix();
            translationMatrix[0, 0] = 1; translationMatrix[0, 1] = 0; translationMatrix[0, 2] = 0;
            translationMatrix[1, 0] = 0; translationMatrix[1, 1] = 1; translationMatrix[1, 2] = 0;
            translationMatrix[2, 0] = 0; translationMatrix[2, 1] = 0; translationMatrix[2, 2] = 1;
            translationMatrix[3, 0] = -100; translationMatrix[3, 1] = -200; translationMatrix[3, 2] = -300;
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTP);
            Console.WriteLine($"Rotation matrix:\n{rotationMatrix}");
            Console.WriteLine($"Translation matrix:\n{translationMatrix}");
            var point = new Point(100, 200, 300);
            Console.WriteLine($"Point:\n\t{point}");
            Console.WriteLine($"Rotated point:\n\t{rotationMatrix.Transform(point)}");
            Console.WriteLine($"Translated point:\n\t{translationMatrix.Transform(point)}");
            Console.WriteLine($"Rotation matrix multiply translation matrix:\n{rotationMatrix * translationMatrix}");
            Console.WriteLine($"Translation matrix multiply rotation matrix:\n{translationMatrix * rotationMatrix}");
            Console.WriteLine("矩阵乘法一般不满足交换律！");
            Console.WriteLine($"Rotated and translated point:\n\t{(rotationMatrix * translationMatrix).Transform(point)}");
            matrix = Tekla.Structures.Geometry3d.MatrixFactory.ByCoordinateSystems(globalCS, targetCS1);
            Console.WriteLine($"Matrix 1:\n{matrix}");
            matrix = Tekla.Structures.Geometry3d.MatrixFactory.ByCoordinateSystems(globalCS, targetCS2);
            Console.WriteLine($"Matrix 2:\n{matrix}");
            matrix = Tekla.Structures.Geometry3d.MatrixFactory.ByCoordinateSystems(globalCS, targetCS3);
            Console.WriteLine($"Matrix 3:\n{matrix}");
            matrix = Tekla.Structures.Geometry3d.MatrixFactory.ByCoordinateSystems(globalCS, targetCS4);
            Console.WriteLine($"Matrix 4:\n{matrix}");
            matrix = Tekla.Structures.Geometry3d.MatrixFactory.ByCoordinateSystems(globalCS, targetCS5);
            Console.WriteLine($"Matrix 5:\n{matrix}");

        }
        [TestMethod]
        public void TestMatrixTransform() {

            var v1 = new Vector(1, 0, 0);
            var v2 = new Vector(0, 1, 0);
            var v3 = new Vector(0, 0, 1);
            var rM = Tekla.Structures.Geometry3d.MatrixFactory.Rotate(-10 * Math.PI / 180, v3);
            var v4 = new Vector(rM.Transform(v2));
            Console.WriteLine(v1.GetAngleBetween(v4) * 180 / Math.PI);// 输出结果为100

            var currentCS = new CoordinateSystem();
            var targetCS = new CoordinateSystem {
                Origin = new Point(100, 200, 300)
            };
            var tM = Tekla.Structures.Geometry3d.MatrixFactory.ByCoordinateSystems(currentCS, targetCS);
            var point = new Point();
            Console.WriteLine(tM.Transform(point));//输出结果(-100.000, -200.000, -300.000)

            Console.WriteLine($"Current coordinatesystem:\n{currentCS.GetInfo()}");
            Console.WriteLine();
            Console.WriteLine($"Target coordinatesystem:\n{targetCS.GetInfo()}");
            Console.WriteLine();
            Console.WriteLine($"Transformed coordinatesystem:\n{(rM * tM).Transform(currentCS).GetInfo()}");
            //  应当输出为：
            //  AxisX:(1084.8078, 26.3518, 300)
            //  AxisY:(273.6482, 1184.8078, 300)
            //  Origin:(100, 200, 300)
            Console.WriteLine();

            Console.WriteLine($"Rotation matrix:\n{rM}");
            Console.WriteLine($"Translation matrix:\n{tM}");
            Console.WriteLine($"Transposed translation matrix:\n{tM.GetTranspose()}");
            Console.WriteLine($"Combined matrix:\n{rM * tM}");
            Console.WriteLine($"Transposed combined matrix:\n{(rM * tM).GetTranspose()}");
        }
        [TestMethod]
        public void TestContourPointsMirror() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            var beam = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a PolyBeam");
            var type = beam.GetType();
            while (type != typeof(PolyBeam)) {
                beam = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a PolyBeam");
                type = beam.GetType();
            }
            var polyBeam = (PolyBeam) Tekla.Structures.Model.Operations.Operation.CopyObject(beam, new Vector());

            var origin = picker.PickPoint();
            var axisX = picker.PickPoint();
            var plane = new GeometricPlane(origin, new Vector(axisX - origin), new Vector(0, 0, 1));

            ArrayList contourPoints = polyBeam.Contour.ContourPoints;
            contourPoints = Geometry3dOperation.Mirror(contourPoints, plane);
            polyBeam.Contour.ContourPoints = contourPoints;
            //Position属性需编辑
            polyBeam.Modify();

            model.CommitChanges();
        }
        //[TestMethod]
        //public void TestSolidMirror() {
        //    var model = new Model();
        //    if (!model.GetConnectionStatus()) return;

        //    var globalCS = new CoordinateSystem();
        //    var picker = new Picker();
        //    var beam = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a PolyBeam:");
        //    var type = beam.GetType();
        //    while (type != typeof(PolyBeam)) {
        //        beam = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a PolyBeam:");
        //        type = beam.GetType();
        //    }
        //    var polyBeam = (PolyBeam) Tekla.Structures.Model.Operations.Operation.CopyObject(beam, new Vector());

        //    var origin = picker.PickPoint("Select the first point of mirror line:");
        //    var axisX = picker.PickPoint("Select the second point of mirror line:");
        //    var plane = new Plane {
        //        Origin = origin,
        //        AxisX = new Vector(axisX - origin),
        //        AxisY = new Vector(0, 0, 1)
        //    };

        //    // Solid为只读
        //    var solid = polyBeam.GetSolid();
        //    var faceEnum = solid.GetFaceEnumerator();
        //    while (faceEnum.MoveNext()) {
        //        var face = faceEnum.Current;
        //        var loopEnum = face.GetLoopEnumerator();
        //        while (loopEnum.MoveNext()) {
        //            var loop = loopEnum.Current;
        //            var vertexEnum = loop.GetVertexEnumerator();
        //            while (vertexEnum.MoveNext()) {
        //                var point = vertexEnum.Current;
        //                // 只读
        //                vertexEnum.Current = Geometry3dOperation.Mirror(point, globalCS, plane);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void TestConstructorNullParameter() {
            Point point = null;
            try {
                point = new Point(null);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            } finally {
                Console.WriteLine($"Point = {point}");
            }
        }
        [TestMethod]
        public void TestReferencetype() {
            Picker picker = new Picker();
            var obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            var type = obj.GetType();
            while (type != typeof(ContourPlate)) {
                obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
                type = obj.GetType();
            }
            ContourPlate sourceContourPlate = (ContourPlate) obj;

            ContourPlate contourPlate1 = new ContourPlate {
                Contour = sourceContourPlate.Contour,
                Profile = sourceContourPlate.Profile,
                Material = sourceContourPlate.Material,
                Class = "99",
            };
            contourPlate1.Insert();

            ContourPlate contourPlate2 = new ContourPlate {
                Contour = { ContourPoints = new ArrayList(sourceContourPlate.Contour.ContourPoints) },
                Profile = { ProfileString = string.Copy(sourceContourPlate.Profile.ProfileString) },
                Material = { MaterialString = string.Copy(sourceContourPlate.Material.MaterialString) },
                Class = "99",
            };
            contourPlate2.Insert();

            Tekla.Structures.Model.Operations.Operation.MoveObject(contourPlate1, new Vector(1000, 0, 0));
            Tekla.Structures.Model.Operations.Operation.MoveObject(contourPlate2, new Vector(-1000, 0, 0));

            Console.WriteLine($"源对象规格：\n{sourceContourPlate.Profile.ProfileString}");
            sourceContourPlate.Profile.ProfileString = "PL22";
            Console.WriteLine($"改变源对象规格为 PL22 后：");
            Console.WriteLine($"引用源对象属性方式新建对象的规格：\n{contourPlate1.Profile.ProfileString}");
            Console.WriteLine($"构造新实例属性方式新建对象的规格：\n{contourPlate2.Profile.ProfileString}");
        }
        [TestMethod]
        public void TestDefaultConstructorOfLine() {
            var line = new Line();
            Console.WriteLine(line.Origin);
            Console.WriteLine(line.Direction);
        }
        [TestMethod]
        public void TestVectorCross() {
            var v1 = new Vector(1, 0, 0);
            var v2 = v1;
            var zeroVector = new Vector();

            Console.WriteLine(Vector.Cross(v1, v2) == zeroVector);
            Console.WriteLine(v1.Cross(zeroVector).ToString());
        }
        [TestMethod]
        public void TestVectorGetAngle() {
            var v1 = new Vector(1, 0, 0);
            var v2 = new Vector(0, 1, 0);
            var v3 = new Vector(0, 0, 1);
            var v4 = new Vector(1, 2, -1);
            var zeroVector = new Vector();

            Console.WriteLine(v1.GetAngleBetween(v2) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v2, v3) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v2, v4) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v2, zeroVector) * 180 / Math.PI);

            var rM = Tekla.Structures.Geometry3d.MatrixFactory.Rotate(-10 * Math.PI / 180, v3);
            var v5 = new Vector(rM.Transform(v2));
            Console.WriteLine(v1.GetAngleBetween(v5) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v5, v3) * 180 / Math.PI);
            Console.WriteLine(v5.GetAngleBetween(v1) * 180 / Math.PI);
            Console.WriteLine(v5.GetAngleBetween_WithDirection(v1, v3) * 180 / Math.PI);
        }
        [TestMethod]
        public void TestArcGetPoints() {
            var arc = new Arc(new Point(500, 500, 0), new Point(1000, 0, 0), new Vector(0, 0, 1), 3.0 / 4.0 * Math.PI);
            Console.WriteLine(arc.StartPoint);
            Console.WriteLine(arc.EndPoint);
            Console.WriteLine(arc.Angle * 180.0 / Math.PI);
            var points = arc.GetPoints(arc.StartPoint, arc.EndPoint, 5.0 * Math.PI / 180.0);
            foreach (var point in points) {
                Console.WriteLine(point.ToString());
            }
            Console.WriteLine("====================");
            points = arc.GetPointsDivide(3);
            foreach (var point in points) {
                Console.WriteLine(point.ToString());
            }
            Console.WriteLine("====================");
            points = arc.GetPointsMeasure(100);
            foreach (var point in points) {
                Console.WriteLine(point.ToString());
            }
        }
        [TestMethod]
        public void TestProjectionZeroDirectionLine() {
            var point = new Point(1000, 1000, 1000);
            var line = new Line();

            Console.WriteLine(line.Direction.ToString());
            var p = Tekla.Structures.Geometry3d.Projection.PointToLine(point, line);
            Console.WriteLine(p.ToString());
        }
        [TestMethod]
        public void TestCasesOfTheShortestDistanceOfCircleAndLine() {
            Model model = new Model();
            if (!model.GetConnectionStatus()) return;
            var currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());
            TransformationPlane workTP;

            Arc arc;
            Line line;
            var drawer = new GraphicsDrawer();
            //  清屏
            var viewEnum = ViewHandler.GetAllViews();
            while (viewEnum.MoveNext()) {
                ViewHandler.RedrawView(viewEnum.Current);
            }


            //  ====================================    1    ====================================
            workTP = new TransformationPlane(new Point(0, 18000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第1种情形：圆半径为0", new Color());
            //  此构造函数无法构造半径为0的圆弧
            //arc = new Arc(new Point(), new Point(), new Vector(0, 0, 1), 2 * Math.PI);
            //  此构造函数可以构造半径为0的圆弧
            arc = new Arc(new Point(), new Vector(1, 0, 0), new Vector(0, 1, 0), 0, 2 * Math.PI);
            line = new Line(new Point(500, 500, 500), new Point(-500, 800, 500));
            DrawCases(arc, line);


            //  ====================================   2.1   ====================================
            workTP = new TransformationPlane(new Point(7200, 0, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第2.1种情形：直线垂直穿过圆中心", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(), new Point(0, 0, 500));
            DrawCases(arc, line);


            //  ====================================   2.2   ====================================
            workTP = new TransformationPlane(new Point(0, 6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第2.2种情形：直线垂直穿过圆平面（不过圆中心）", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(200, 200, 0), new Point(200, 200, 500));
            DrawCases(arc, line);


            //  ====================================   3.1   ====================================
            workTP = new TransformationPlane(new Point(7200, -6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第3.1种情形：直线平行于圆平面，其投影在圆外或与圆相切", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(1500, 200, 800), new Point(1500, 400, 800));
            DrawCases(arc, line);
            line = new Line(new Point(-1000, 200, 800), new Point(-1000, 400, 800));
            DrawCases(arc, line);


            //  ====================================   3.2   ====================================
            workTP = new TransformationPlane(new Point(0, 6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第3.2种情形：直线平行于圆平面，其投影穿过圆", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(800, 200, 800), new Point(600, 400, 800));
            DrawCases(arc, line);


            //  ====================================   4.1   ====================================
            workTP = new TransformationPlane(new Point(7200, -6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第4.1种情形：直线与圆平面既不垂直也不平行，但与其穿过的圆直径所在直线垂直", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(800, 0, 0), new Point(800, 400, -200));
            var angle = line.Direction.GetAngleBetween(arc.Normal);
            var dis = arc.Radius * (1 - Math.Pow(Math.Cos(angle), 2)) / (1 + Math.Pow(Math.Cos(angle), 2));
            var point = Tekla.Structures.Geometry3d.Intersection.LineToPlane(line, new GeometricPlane(arc.CenterPoint, arc.Normal));
            var vector = new Vector(point - arc.CenterPoint);
            vector.Normalize(dis);
            line.Origin = new Point(arc.CenterPoint);
            line.Origin.Translate(vector);
            DrawCases(arc, line);
            line = new Line(new Point(-200, 0, 0), new Point(-200, 400, -200));
            DrawCases(arc, line);
            line = new Line(new Point(-1800, 0, 0), new Point(-1800, 400, -200));
            DrawCases(arc, line);


            //  ====================================   4.2   ====================================
            workTP = new TransformationPlane(new Point(0, 6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第4.2种情形：直线与圆平面既不垂直也不平等，且与其穿过的圆直径所在直线也不垂直", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(800, 0, 0), new Point(300, 400, -200));
            DrawCases(arc, line);
            line = new Line(new Point(-1800, 0, 0), new Point(-1500, 200, -200));
            DrawCases(arc, line);


            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTP);
        }
        private void DrawCases(Arc arc, Line line) {
            var drawer = new GraphicsDrawer();
            List<LineSegment> segments;
            segments = MuggleTeklaPlugins.Geometry3dExtension.IntersectionExtension.CircleToLine(arc, line);
            drawer.DrawArc(arc, color: ColorExtension.DeepSkyBlue);
            drawer.DrawLine(line, color: ColorExtension.GreenYellow);
            if (segments != null) {
                foreach (LineSegment segment in segments) {
                    drawer.DrawLineSegment(segment, ColorExtension.OrangeRed);
                    drawer.DrawPoint(segment.StartPoint, color: ColorExtension.Orange, size: 25);
                    drawer.DrawPoint(segment.EndPoint, color: ColorExtension.Orange, size: 25);
                }
            }
        }
        [TestMethod]
        public void TestGetLocalExtreme() {
            #region data
            var data1 = new int[] { 2632, 8644, 1405, 5233, 732, 2243, 6493, 7886, 2916, 1870, 4658, 9840, 6375, 3655, 398, 1367, 9506, 9199, 2554, 4738, 2685, 6327, 3888, 1297, 4629, 2843, 654, 8177, 4111, 1623, 585, 2567, 1828, 1917, 7269, 7491, 2490, 4777, 6467, 2302, 5431, 9587, 1359, 2299, 1203, 9973, 4285, 366, 1023, 9695, 8525, 8213, 3926, 4409, 9915, 8281, 8395, 4453, 9525, 8159, 4142, 2651, 6784, 5993, 8549, 2405, 2883, 8398, 6347, 676, 7608, 1636, 5569, 4360, 3829, 9769, 540, 6704, 2253, 9781, 4286, 5546, 8185, 1121, 9639, 8814, 9963, 9470, 382, 1082, 8625, 7995, 268, 6547, 8248, 4741, 9234, 242, 4491, 4626, 6165, 1107, 4569, 1880, 3864, 723, 7150, 2649, 6462, 1345, 7715, 8646, 6266, 3151, 4180, 6034, 4361, 4075, 8984, 9080, 6563, 834, 2464, 3728, 2947, 1952, 9579, 971, 5244, 8708, 6913, 7482, 2851, 7103, 2037, 776, 671, 7173, 1560, 8578, 4854, 8936, 3932, 8751, 273, 3218, 4364, 3838, 4324, 3695, 3064, 4917, 157, 7353, 5410, 6175, 6498, 2250, 4916, 2841, 8203, 159, 3739, 5848, 5412, 1443, 1943, 4594, 3706, 8017, 1735, 2851, 2076, 4641, 6407, 8048, 3190, 7328, 4432, 9680, 532, 7840, 726, 3970, 8123, 3693, 4581, 627, 3594, 2449, 7479, 7332, 4032, 2692, 2372, 1412, 8198, 6379, 1405, 3733, 6442, 7609, 6959, 1583, 4422, 6091, 7442, 3840, 5925, 7317, 1259, 5371, 9077, 9565, 7669, 1697, 9172, 9883, 1490, 1924, 9925, 9659, 5049, 7394, 426, 8670, 5761, 7726, 1257, 9099, 1755, 2411, 6446, 6164, 8518, 3505, 9525, 8011, 6086, 7535, 6469, 7964, 7779, 9046, 5901, 2054, 2792, 4697, 6594, 8434, 3161, 7978, 2389, 2644, 5549, 7726, 598, 2097, 2096, 8488, 5087, 1552, 7849, 4541, 4114, 4584, 465, 5169, 9481, 7692, 8133, 1688, 2540, 3963, 147, 132, 8479, 3212, 6356, 8887, 7858, 400, 6047, 7076, 4285, 5209, 198, 6590, 5554, 9102, 359, 7225, 5451, 2372, 6527, 2888, 3385, 4572, 8984, 8932, 3435, 6375, 3734, 7393, 4873, 5389, 1492, 1662, 7125, 366, 2879, 6893, 4333, 1861, 9863, 9136, 4697, 6646, 3084, 5415, 7448, 9873, 557, 2548, 3846, 9378, 2097, 316, 507, 8800, 7805, 4651, 8872, 3012, 973, 3315, 6633, 4330, 4622, 2252, 6637, 1947, 8221, 2075, 5482, 5274, 6331, 1892, 2056, 601, 7507, 602, 9576, 3738, 815, 9724, 2173, 5857, 5513, 8044, 218, 6222, 2273, 8667, 7264, 8002, 6462, 4891, 510, 3547, 6481, 2779, 6521, 5308, 175, 5491, 704, 4564, 2089, 5207, 4764, 1213, 915, 4743, 688, 1321, 1015, 254, 1308, 5186, 1487, 7637, 769, 9746, 9265, 4073, 9264, 736, 1548, 4278, 1154, 4436, 8923, 1407, 5285, 7898, 4979, 3240, 4329, 485, 5831, 5527, 8336, 6113, 5890, 3194, 2750, 3894, 6669, 881, 827, 6638, 4277, 4221, 3204, 382, 5552, 7192, 2771, 638, 3665, 3663, 215, 8443, 584, 7470, 5036, 4709, 4706, 1941, 6867, 4165, 9018, 4958, 7407, 3811, 2047, 4873, 2204, 4559, 1533, 4124, 3338, 7936, 5571, 7283, 2010, 4555, 6091, 6104, 647, 6807, 9434, 8545, 7743, 9497, 785, 9676, 3862, 4543, 1762, 4149, 3970, 5140, 2052, 3832, 3910, 8996, 7123, 6787, 7242, 5270, 895, 7199, 1553, 4324, 7599, 9346, 8087, 2114, 8506, 3690, 5043, 8890, 862, 4872, 128, 4356, 4681, 5155, 1359, 9856, 8322, 2105, 1748, 4086, 2492, 1124, 3671, 2131, 1028, 7644, 777, 1594, 1188, 730, 7576, 5199, 7848, 9968, 6697, 7876, 6065, 3190, 7120, 4068, 8926, 9483, 4895, 1719, 2479, 1410, 3700, 783, 5048, 4757, 2123, 6256, 9180, 9432, 4301, 8583, 9065, 200, 4257, 6391, 7551, 5671, 2918, 6218, 3038, 7497, 5474, 2879, 2241, 9527, 4819, 7737, 423, 3081, 7740, 7793, 6177, 2486, 6349, 2541, 6844, 7552, 1840, 5990, 5648, 8571, 8695, 1737, 685, 4370, 2161, 216, 1843, 2108, 6669, 8293, 6898, 6075, 5879, 793, 7825, 3972, 6487, 931, 659, 3645, 5505, 1979, 4925, 9396, 7964, 3549, 2982, 6433, 7102, 2892, 3919, 9243, 6014, 3093, 8695, 6523, 1801, 9422, 9686, 1192, 7108, 1174, 8515, 4138, 5892, 5500, 3673, 7288, 2963, 3017, 8681, 4281, 4974, 7801, 2344, 8987, 7872, 8120, 3397, 7245, 9499, 2973, 1984, 2093, 9790, 9988, 3201, 6270, 7889, 3755, 1382, 1547, 9526, 7494, 7471, 4174, 7243, 3825, 453, 930, 4968, 4227, 8071, 2738, 2022, 1907, 1975, 9443, 2085, 6048, 8629, 7837, 9952, 9480, 9231, 8364, 4381, 5007, 4489, 4065, 534, 7723, 2359, 4356, 9719, 709, 4395, 3192, 9649, 8800, 3932, 4298, 7038, 954, 3634, 5077, 803, 3513, 836, 6318, 7286, 3077, 9767, 9314, 7330, 6135, 9538, 9796, 7894, 6517, 8103, 1515, 416, 7611, 2886, 6121, 1018, 6280, 129, 3434, 7416, 5369, 8093, 6343, 1586, 552, 9421, 7704, };
            var data2 = new double[] { 87.16, 173.65, 258.82, 342.02, 422.62, 500, 573.58, 642.79, 707.11, 766.04, 819.15, 866.03, 906.31, 939.69, 965.93, 984.81, 996.19, 1000, 996.19, 984.81, 965.93, 939.69, 906.31, 866.03, 819.15, 766.04, 707.11, 642.79, 573.58, 500, 422.62, 342.02, 258.82, 173.65, 87.16, 0, -87.16, -173.65, -258.82, -342.02, -422.62, -500, -573.58, -642.79, -707.11, -766.04, -819.15, -866.03, -906.31, -939.69, -965.93, -984.81, -996.19, -1000, -996.19, -984.81, -965.93, -939.69, -906.31, -866.03, -819.15, -766.04, -707.11, -642.79, -573.58, -500, -422.62, -342.02, -258.82, -173.65, -87.16, 0, };
            #endregion

            List<int> indexes;
            string resault = string.Empty;
            int cnt = 0;

            indexes = CommonOperation.GetLocalExtremeIndexes(data1, CommonOperation.ExtremeTypeEnum.LocalMinimum, 5);
            if (indexes != null) {
                foreach (var item in indexes) {
                    resault += data1[item] + ", ";
                    cnt++;
                    if (cnt % 10 == 0)
                        resault += "\n";
                }
                Console.WriteLine("Local minimums of data1:\n" + resault);
            }

            resault = string.Empty;
            cnt = 0;
            indexes = CommonOperation.GetLocalExtremeIndexes(data2, CommonOperation.ExtremeTypeEnum.LocalMinimum);
            if (indexes != null) {
                foreach (var item in indexes) {
                    resault += data2[item] + ", ";
                    cnt++;
                    if (cnt % 10 == 0)
                        resault += "\n";
                }
                Console.WriteLine("Local minimums of data2:\n" + resault);
            }

            resault = string.Empty;
            cnt = 0;
            indexes = CommonOperation.GetLocalExtremeIndexes(data2, CommonOperation.ExtremeTypeEnum.LocalMaximum);
            if (indexes != null) {
                foreach (var item in indexes) {
                    resault += data2[item] + ", ";
                    cnt++;
                    if (cnt % 10 == 0)
                        resault += "\n";
                }
                Console.WriteLine("Local maximums of data2:\n" + resault);
            }
        }
        [TestMethod]
        public void TestCurvedBeam() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            var part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a Curved Beam:");

            var type = part.GetType();
            Console.WriteLine($"The type of Curved Beam is:\n\t{type}");

            var centerline = ((Beam) part).GetCenterLine(false);
            Console.WriteLine($"The type of Part's Centerline is:\n\t{centerline[0].GetType()}");
            Console.WriteLine($"This part's Centerline has #{centerline.Count} items.");
            double radius = 0;
            part.GetReportProperty("RADIUS", ref radius);
            Console.WriteLine($"This part's Radius is:\n\t{radius}");

            var beam = (Beam) part;
            Console.WriteLine($"Curved Beam StartPoint:\n\t{beam.StartPoint}");
            Console.WriteLine($"Curved Beam EndPoint:\n\t{beam.EndPoint}");
            var msg = string.Empty;
            int cnt = 0;
            foreach (Point point in centerline) {
                if (cnt == 0) {
                    msg += $"{point}";
                    cnt++;
                } else {
                    msg += $"\n\t{point}";
                }
            }
            Console.WriteLine($"Curved Beam Centerlin Points:\n\t{msg}");

            var polyline = new PolyLine(centerline);
            var graphicPolyline = new GraphicPolyLine(polyline, new Color(), 1, GraphicPolyLine.LineType.Solid);
            var drawer = new GraphicsDrawer();
            drawer.DrawPolyLine(graphicPolyline);
        }
        [TestMethod]
        public void TestCopy_Rotate() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            var obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "Select an object:");
            var point = picker.PickPoint("Select the rotation axis's original point:");
            var direction = picker.PickPoint("Select the rotation axis's direction:");

            ModelOperation.Copy_Rotate(obj, point, new Vector(direction - point), Math.PI);

            model.CommitChanges();
        }
        [TestMethod]
        public void TestMatrixTransposeInverse() {
            var cs1 = new CoordinateSystem {
                AxisX = new Vector(1000, 0, 0),
                AxisY = new Vector(0, 1000, 0),
                Origin = new Point(),
            };
            var cs2 = new CoordinateSystem {
                AxisX = new Vector(737.843, -268.7273, 619.1715),
                AxisY = new Vector(-305.6246, 684.891, 661.4514),
                Origin = new Point(),
            };
            var cs3 = new CoordinateSystem {
                AxisX = new Vector(1000, 0, 0),
                AxisY = new Vector(0, 1000, 0),
                Origin = new Point(895.647, 1098.6734, 521.258),
            };
            var cs4 = new CoordinateSystem {
                AxisX = new Vector(737.843, -268.7273, 619.1715),
                AxisY = new Vector(-305.6246, 684.891, 661.4514),
                Origin = new Point(895.647, 1098.6734, 521.258),
            };

            var rM = MatrixFactory.ByCoordinateSystems(cs1, cs2);
            var tM = MatrixFactory.ByCoordinateSystems(cs1, cs3);
            var cM = MatrixFactory.ByCoordinateSystems(cs1, cs4);

            Console.WriteLine($"Rotation matrix:\n{rM}");
            Console.WriteLine($"Translation matrix:\n{tM}");
            Console.WriteLine($"Combined matrix:\n{cM}");

            var rMxtM = rM * tM;
            Console.WriteLine($"Rotation matrix multiply translation matrix:\n{rMxtM}");

            var cMT = cM.GetTranspose();
            Console.WriteLine($"Transposed combined matrix:\n{cMT}");

            var cMTxrM = cMT * rM;
            Console.WriteLine($"Transposed combined matrix multiply rotation matrix:\n{cMTxrM}");

            var cMTxrM_T = cMTxrM.GetTranspose();
            Console.WriteLine($"Transpose the transposed combined matrix multiply rotation matrix:\n{cMTxrM_T}");
            Console.WriteLine($"Equal translation matrix!\n");

            var cMxrMT = cM * rM.GetTranspose();
            Console.WriteLine($"Combined matrix multiply transposed rotation matrix:\n{cMxrMT}");
        }
        [TestMethod]
        public void TestCenterLine() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            var part = (Part) picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);

            var centerline = part.GetCenterLine(false);
            var drawer = new GraphicsDrawer();
            var color = ColorExtension.Red;
            for (int i = 0; i < centerline.Count - 1; i++) {
                drawer.DrawLineSegment((Point) centerline[i], (Point) centerline[i + 1], color);
            }
        }
        [TestMethod]
        public void TestInfinityRadiusArc() {
            var p1 = new Point();
            var p2 = new Point(100, 0, 0);
            var p3 = new Point(200, 0, 0);
            var arc = new Arc(p1, p3, p2);

            Console.WriteLine($"Radius:\n{arc.Radius}");
        }
    }
}
