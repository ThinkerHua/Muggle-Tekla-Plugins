using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.Internal;
using Muggle.TeklaPlugins.Common.Model;
using Muggle.TeklaPlugins.Common.ModelUI;
using Muggle.TeklaPlugins.Common.Operation;
using Muggle.TeklaPlugins.Common.Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.UnitTest {
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
        public void TestDistance() {
            var line1 = new Line(new Point(236, 457, 7981), new Vector(0, 1, 0));
            var line2 = new Line();

            Console.WriteLine($"Line1:\n\tOrigin - {line1.Origin}\n\tDirection - {line1.Direction}");
            Console.WriteLine($"Line2:\n\tOrigin - {line2.Origin}\n\tDirection - {line2.Direction}");
            Console.WriteLine(DistanceExtension.LineToLine(line1, line2));

            line2.Direction = new Vector(349, 87, 908);
            Console.WriteLine($"Line1:\n\tOrigin - {line1.Origin}\n\tDirection - {line1.Direction}");
            Console.WriteLine($"Line2:\n\tOrigin - {line2.Origin}\n\tDirection - {line2.Direction}");
            Console.WriteLine(DistanceExtension.LineToLine(line1, line2));

        }
        [TestMethod]
        public void TestLineSegmentLength() {
            var lineSeg = new LineSegment();
            Console.WriteLine("无参构造函数构造的LineSegment的长度：\n\t" + lineSeg.Length());

            var line1 = new Line(new Point(1, 2, 0), new Vector(1.1, 2.2, 0));
            var line2 = new Line(new Point(11, 12, 0), new Vector(2, 3, 0));
            lineSeg = Intersection.LineToLine(line1, line2);
            Console.WriteLine($"Intersection.LineToLine方法构造的LineSegment的长度：\n\t{lineSeg.Length()}");
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

            Internal.ShowTransformationPlane(partTP);

        }
        [TestMethod]
        public void TestPointExtension() {
            var point1 = new Point(1, 2, 3);
            var point2 = new Point(4, 5, 6);
            point1.Translate(point2);
            Console.WriteLine(point1);

            try {
                var tp1 = new TransformationPlane(new Point(0, 0, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
                var tp2 = new TransformationPlane(new Point(10, 10, 10), new Vector(1, 0, 0), new Vector(0, 1, 0));
                point1 = point1.Transform(tp1, tp2);
                Console.WriteLine(point1);
            } catch (Exception e) {
                Console.WriteLine(e);
            }

            var sourceCS = new CoordinateSystem(new Point(10, 10, 10), new Vector(0, 1, 0), new Vector(0, 0, 1));
            var targetCS = new CoordinateSystem(new Point(100, 200, 300), new Vector(1, 1, 0), new Vector(0, 1, 1));
            var currentCS = new CoordinateSystem();
            point1 = point1.Transform(currentCS, targetCS);
            Console.WriteLine(point1);
            point1 = point1.TransformTo(sourceCS);
            Console.WriteLine(point1);
            point1 = point1.TransformFrom(targetCS);
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
            int c = a, d = b;
            (c, d) = (d, c);
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"c = {c}, d = {d}");


            Point point1, point2;
            point1 = new Point(1, 2, 3);
            point2 = new Point(4, 5, 6);
            CommonOperation.Swap(ref point1, ref point2);
            Console.WriteLine($"point1 = {point1}");
            Console.WriteLine($"point2 = {point2}");
            var p3 = point1; var p4 = point2;
            (p3, p4) = (p4, p3);
            Console.WriteLine($"point1 = {point1}");
            Console.WriteLine($"point2 = {point2}");
            Console.WriteLine($"point3 = {p3}");
            Console.WriteLine($"point4 = {p4}");

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
            var targetCS1 = new CoordinateSystem(new Point(100, 200, 300), new Vector(1, 0, 0), new Vector(0, 1, 0));//平移
            var targetCS2 = new CoordinateSystem(new Point(100, 200, 300), new Vector(0, 1, 0), new Vector(-1, 0, 0));//平移+绕Z轴旋转90度
            var targetCS3 = new CoordinateSystem(new Point(100, 200, 300), new Vector(-1, 0, 0), new Vector(0, -1, 0));//平移+绕Z轴旋转180度
            var targetCS4 = new CoordinateSystem(new Point(100, 200, 300), new Vector(0, -1, 0), new Vector(1, 0, 0));//平移+绕Z轴旋转270度
            var targetCS5 = new CoordinateSystem(new Point(100, 200, 300), new Vector(0, 1, 0), new Vector(1, 0, 0));//平移+绕XY平面45度轴旋转180度
            var rotationMatrix = MatrixFactory.Rotate(Math.PI * 0.5, new Vector(0, 0, 1));
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
            matrix = MatrixFactory.ByCoordinateSystems(globalCS, targetCS1);
            Console.WriteLine($"Matrix 1:\n{matrix}");
            matrix = MatrixFactory.ByCoordinateSystems(globalCS, targetCS2);
            Console.WriteLine($"Matrix 2:\n{matrix}");
            matrix = MatrixFactory.ByCoordinateSystems(globalCS, targetCS3);
            Console.WriteLine($"Matrix 3:\n{matrix}");
            matrix = MatrixFactory.ByCoordinateSystems(globalCS, targetCS4);
            Console.WriteLine($"Matrix 4:\n{matrix}");
            matrix = MatrixFactory.ByCoordinateSystems(globalCS, targetCS5);
            Console.WriteLine($"Matrix 5:\n{matrix}");

        }
        [TestMethod]
        public void TestMatrixTransform() {

            var v1 = new Vector(1, 0, 0);
            var v2 = new Vector(0, 1, 0);
            var v3 = new Vector(0, 0, 1);
            var rM = MatrixFactory.Rotate(-10 * Math.PI / 180, v3);
            var v4 = new Vector(rM.Transform(v2));
            Console.WriteLine(v1.GetAngleBetween(v4) * 180 / Math.PI);// 输出结果为100

            var currentCS = new CoordinateSystem();
            var targetCS = new CoordinateSystem {
                Origin = new Point(100, 200, 300)
            };
            var tM = MatrixFactory.ByCoordinateSystems(currentCS, targetCS);
            var point = new Point();
            Console.WriteLine(tM.Transform(point));//输出结果(-100.000, -200.000, -300.000)

            var rM2 = MatrixFactory.Rotate(0.2 * Math.PI, v1);
            Console.WriteLine($"Current coordinatesystem:\n{currentCS.ToString("f4")}");
            Console.WriteLine();
            Console.WriteLine($"Target coordinatesystem:\n{targetCS.ToString("f4")}");
            Console.WriteLine();
            Console.WriteLine($"Transformed coordinatesystem:\n{(rM2 * rM * tM).Transform(currentCS).ToString("f4")}");
            //  应当输出为：
            //  Origin = (100, 200, 300)
            //  AxisX = (984.8078, -140.4843, -102.0678)
            //  AxisY = (173.6482, 796.7262, 578.8555)
            Console.WriteLine();
            Console.WriteLine($"Transformed coordinatesystem:\n{(tM * rM2 * rM).Transform(currentCS).ToString("f4")}");
            //  应当输出为：
            //  Origin = (133.2104, -31.0388, 348.2694)
            //  AxisX = (984.8078, -140.4843, -102.0678)
            //  AxisY = (173.6482, 796.7262, 578.8555)
            Console.WriteLine();
            Console.WriteLine($"Transformed coordinatesystem:\n{(rM * rM2 * tM).Transform(currentCS).ToString("f4")}");
            //  应当输出为：
            //  Origin = (100, 200, 300)
            //  AxisX = (984.8078, -173.6482, 0)
            //  AxisY = (140.4843, 796.7262, 587.7853)
            Console.WriteLine();
            Console.WriteLine("多个矩阵组合，应用顺序为从右向左。\n" +
                "平移操作在完成旋转操作后的新坐标系上进行平移。");
            Console.WriteLine();

            Console.WriteLine($"Rotation matrix:\n{rM}");
            Console.WriteLine($"Translation matrix:\n{tM}");
            Console.WriteLine($"Transposed translation matrix:\n{tM.GetTranspose()}");
            Console.WriteLine($"Combined matrix:\n{rM * tM}");
            Console.WriteLine($"Transposed combined matrix:\n{(rM * tM).GetTranspose()}");
        }
        [TestMethod]
        public void TestPointMirror() {
            var point = new Point(1, 2, 3);
            var plane = new GeometricPlane(new Point(), new Vector(1, 0, 0));
            Console.WriteLine(Geometry3dOperation.Mirror(point, plane));
        }
        [TestMethod]
        public void TestContourPointsMirror() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            ModelObject beam;
            do {
                beam = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a PolyBeam");
            } while (!(beam is PolyBeam));
            var polyBeam = (PolyBeam) Tekla.Structures.Model.Operations.Operation.CopyObject(beam, new Vector());

            var origin = picker.PickPoint("Select the first point of mirror line:");
            var axisX = picker.PickPoint("Select the second point of mirror line:");
            var plane = new GeometricPlane(origin, new Vector(axisX - origin), new Vector(0, 0, 1));

            polyBeam.Contour.ContourPoints = Geometry3dOperation.Mirror(polyBeam.Contour.ContourPoints, plane);
            //某些情况下，Position属性需编辑，否则不是正确的镜像对象
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
            if (!new Model().GetConnectionStatus()) return;
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
        public void TestVectorCrossDot() {
            var v1 = new Vector(1, 0, 0);
            var v2 = v1;
            var zeroVector = new Vector();

            Console.WriteLine(Vector.Cross(v1, v2) == zeroVector);
            Console.WriteLine(v1.Cross(zeroVector).ToString());
            Console.WriteLine(v1.Dot(zeroVector));
            try {
                Console.WriteLine(v1.Cross(null).ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            var v3 = new Vector(235.505, 9365.872, -8923.8461);
            Console.WriteLine(Vector.Dot(v3, v3));
            Console.WriteLine(v3.GetLength());
        }
        [TestMethod]
        public void TestVectorGetAngleWithDirection() {
            var v1 = new Vector(1, 0, 0);
            var v2 = new Vector(0, 1, 0);
            var v3 = new Vector(0, 0, 1);
            var v4 = new Vector(1, 2, -1);
            var zeroVector = new Vector();

            Console.WriteLine(v1.GetAngleBetween(v2) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v2, v3) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v2, v4) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v2, zeroVector) * 180 / Math.PI);

            var rM = MatrixFactory.Rotate(-10 * Math.PI / 180, v3);
            var v5 = new Vector(rM.Transform(v2));
            Console.WriteLine(v1.GetAngleBetween(v5) * 180 / Math.PI);
            Console.WriteLine(v1.GetAngleBetween_WithDirection(v5, v3) * 180 / Math.PI);
            Console.WriteLine(v5.GetAngleBetween(v1) * 180 / Math.PI);
            Console.WriteLine(v5.GetAngleBetween_WithDirection(v1, v3) * 180 / Math.PI);
        }
        [TestMethod]
        public void TestVectorGetAngleBetween() {
            var v1 = new Vector(1, 0, 0);
            var v2 = new Vector(999.99999882477846, -0.048481368091977083, 0);

            Console.WriteLine(v1.GetAngleBetween(v2));
            var dot = v1.Dot(v2);
            var angel = Math.Acos(dot / (v1.GetLength() * v2.GetLength()));
            Console.WriteLine(angel);

            var v3 = new Vector(-1, 0, 0);
            Console.WriteLine(v1.GetAngleBetween(v3));
            Console.WriteLine(v1.GetAngleBetween_Precisely(v3));

            var v0 = new Vector();
            Console.WriteLine(v0.GetAngleBetween(v3));
            Console.WriteLine(v0.GetAngleBetween_Precisely(v3));
            Console.WriteLine(v0.GetAngleBetween(v0));
            try {
                Console.WriteLine(v0.GetAngleBetween(null));
                Console.WriteLine(v0.GetAngleBetween_Precisely(null));
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
        [TestMethod]
        public void TestVectorNormalize() {
            var v = new Vector();
            v.Normalize(100);
            Console.WriteLine(v);
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

            Console.WriteLine(line.Direction);
            var p = Projection.PointToLine(point, line);
            Console.WriteLine(p.ToString());
        }
        [TestMethod]
        public void TestIntersectionExtensionLineToLine() {
            var line1 = new Line(new Point(100, 100, 0), new Vector());
            var line2 = new Line(new Point(0, 100, 100), new Vector());

            var lineSeg = Intersection.LineToLine(line1, line2);
            try {
                Console.WriteLine("官方实现：");
                Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
                Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
                Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");
            } catch {

            }
            lineSeg = IntersectionExtension.LineToLine(line1, line2);
            Console.WriteLine("扩展实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");

            line1.Direction.X = 1;
            line2.Direction.Y = 1;
            lineSeg = Intersection.LineToLine(line1, line2);
            Console.WriteLine();
            Console.WriteLine("官方实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");
            lineSeg = IntersectionExtension.LineToLine(line1, line2);
            Console.WriteLine("扩展实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");

            var line3 = new Line(new Point(), new Vector(0, 1, 0));
            lineSeg = Intersection.LineToLine(line1, line3);
            Console.WriteLine();
            Console.WriteLine("官方实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");
            lineSeg = IntersectionExtension.LineToLine(line1, line3);
            Console.WriteLine("扩展实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");

            var line4 = new Line(new Point(1, 2, 0), new Vector(1.1, 2.2, 0));
            var line5 = new Line(new Point(11, 12, 0), new Vector(2, 3, 0));
            lineSeg = Intersection.LineToLine(line4, line5);
            Console.WriteLine();
            Console.WriteLine("官方实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");
            Console.WriteLine("扩展实现：");
            lineSeg = IntersectionExtension.LineToLine(line4, line5);
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");

            line4.Direction.Z = 1;
            line5.Direction.Z = 2;
            lineSeg = Intersection.LineToLine(line4, line5);
            Console.WriteLine();
            Console.WriteLine("官方实现：");
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");
            Console.WriteLine("扩展实现：");
            lineSeg = IntersectionExtension.LineToLine(line4, line5);
            Console.WriteLine($"LineSegment.StartPoint:\n\t{lineSeg.StartPoint}");
            Console.WriteLine($"LineSegment.EndPoint:\n\t{lineSeg.EndPoint}");
            Console.WriteLine($"LineSegment.Length():\n\t{lineSeg.Length()}");
        }
        [TestMethod]
        public void TestCircleToLine() {
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

            Func<Arc, Line, double, double, List<LineSegment>> func = IntersectionExtension.CircleToLine;

            //  ====================================    1    ====================================
            workTP = new TransformationPlane(new Point(0, 12000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第1种情形：圆半径为0", new Color());
            //  此构造函数无法构造半径为0的圆弧
            //arc = new Arc(new Point(), new Point(), new Vector(0, 0, 1), 2 * Math.PI);
            //  此构造函数可以构造半径为0的圆弧
            arc = new Arc(new Point(), new Vector(1, 0, 0), new Vector(0, 1, 0), 0, 2 * Math.PI);
            line = new Line(new Point(500, 500, 500), new Point(-500, 800, 500));
            DrawCases(arc, line, func);


            //  ====================================   2.1   ====================================
            workTP = new TransformationPlane(new Point(7200, 0, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第2.1种情形：直线垂直穿过圆中心", new Color());
            arc = new Arc(new Point(), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            line = new Line(new Point(), new Point(0, 0, 500));
            DrawCases(arc, line, func);


            //  ====================================   2.2   ====================================
            workTP = new TransformationPlane(new Point(0, 6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第2.2种情形：直线垂直穿过圆平面（不过圆中心）", new Color());
            line = new Line(new Point(200, 200, 0), new Point(200, 200, 500));
            DrawCases(arc, line, func);


            //  ====================================   3.1   ====================================
            workTP = new TransformationPlane(new Point(7200, -6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第3.1种情形：直线平行于圆平面，其投影在圆外或与圆相切", new Color());
            line = new Line(new Point(1500, 200, 800), new Point(1500, 400, 800));
            DrawCases(arc, line, func);
            line = new Line(new Point(-1000, 200, 800), new Point(-1000, 400, 800));
            DrawCases(arc, line, func);


            //  ====================================   3.2   ====================================
            workTP = new TransformationPlane(new Point(0, 6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第3.2种情形：直线平行于圆平面，其投影穿过圆", new Color());
            line = new Line(new Point(800, 200, 800), new Point(600, 400, 800));
            DrawCases(arc, line, func);


            //  ====================================   4.1   ====================================
            workTP = new TransformationPlane(new Point(7200, -6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第4.1种情形：直线与圆平面既不垂直也不平行，但与其穿过的圆直径所在直线垂直", new Color());
            line = new Line(new Point(800, 0, 0), new Point(800, 400, -200));
            DrawCases(arc, line, func);
            line = new Line(new Point(-200, 0, 0), new Point(-200, 400, -200));
            DrawCases(arc, line, func);
            line = new Line(new Point(-1800, 0, 0), new Point(-1800, 400, -200));
            DrawCases(arc, line, func);


            //  ====================================   4.2   ====================================
            workTP = new TransformationPlane(new Point(0, 6000, 0), new Vector(1, 0, 0), new Vector(0, 1, 0));
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
            drawer.DrawText(new Point(-1500, -2000, 0), "第4.2种情形：直线与圆平面既不垂直也不平等，且与其穿过的圆直径所在直线也不垂直", new Color());
            line = new Line(new Point(800, 0, 0), new Point(300, 400, -200));
            DrawCases(arc, line, func);
            line = new Line(new Point(-1800, 0, 0), new Point(-1500, 200, -200));
            DrawCases(arc, line, func);


            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTP);
        }
        private void DrawCases(Arc arc, Line line, Func<Arc, Line, double, double, List<LineSegment>> func) {
            if (!new Model().GetConnectionStatus()) return;
            var drawer = new GraphicsDrawer();
            List<LineSegment> segments;
            segments = func(arc, line, 0, GeometryConstants.DISTANCE_EPSILON);
            drawer.DrawArc(arc, color: ColorExtension.DeepSkyBlue);
            drawer.DrawLine(line, color: ColorExtension.GreenYellow);
            if (segments != null) {
                foreach (LineSegment segment in segments) {
                    drawer.DrawLineSegment(segment, ColorExtension.OrangeRed);
                    //Console.WriteLine($"LineSegment.StartPoint:\n\t{segment.StartPoint}\nLineSegment.EndPoint:\n\t{segment.EndPoint}");
                    drawer.DrawText(segment.StartPoint, segment.Length().ToString(), ColorExtension.OrangeRed);
                    drawer.DrawPoint(segment.StartPoint, color: ColorExtension.Orange, size: 25);
                    drawer.DrawPoint(segment.EndPoint, color: ColorExtension.Orange, size: 25);
                }
            }
        }
        [TestMethod]
        public void TestArcToLine() {
            var arc = new Arc(new Point(0, 0, 0), new Point(1000, 0, 0), new Vector(0, 0, 1), 2 * Math.PI);
            var line = new Line(new Point(800, 0, 0), new Point(800, 400, -200));
            var angle = line.Direction.GetAngleBetween(arc.Normal);
            var dis = arc.Radius * (1 - Math.Pow(Math.Cos(angle), 2)) / (1 + Math.Pow(Math.Cos(angle), 2));
            var point = Intersection.LineToPlane(line, new GeometricPlane(arc.CenterPoint, arc.Normal));
            var vector = new Vector(point - arc.CenterPoint);
            vector.Normalize(dis);
            line.Origin = new Point(arc.CenterPoint);
            line.Origin.Translate(vector);
            Console.WriteLine($"Line.Origin:\n\t{line.Origin}\nLine.Direction:\n\t{line.Direction}");
            DrawCases(arc, line, IntersectionExtension.ArcToLine);
            line = new Line(new Point(-200, 0, 0), new Point(-200, 400, -200));
            DrawCases(arc, line, IntersectionExtension.ArcToLine);
            line = new Line(new Point(-1800, 0, 0), new Point(-1800, 400, -200));
            DrawCases(arc, line, IntersectionExtension.ArcToLine);
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

            ModelOperation.Copy_Rotate(obj, point, new Vector(direction - point), Math.PI * 0.25);

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
            try {
                var arc = new Arc(p1, p3, p2);
                Console.WriteLine($"Radius:\n{arc.Radius}");
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
        [TestMethod]
        public void TestPointsIntervalGetValueAndPoint() {
            try {
                var itvl = new PointsInterval {
                    Origin = new Point(2436.482, 96.548, 4136.183),
                    Direction = new Vector(284.851, 2948.615, 893.513),
                    Start = double.NegativeInfinity,
                    End = double.PositiveInfinity,
                };

                var value = 961.492;
                var point = itvl.GetPoint(value);
                Console.WriteLine(value);
                Console.WriteLine(PointExtension.ToString(point));
                for (int i = 0; i < 10000; i++) {
#pragma warning disable CS0618
                    value = itvl.GetValue(point);
#pragma warning restore CS0618
                    point = itvl.GetPoint(value);
                }
                Console.WriteLine();
                Console.WriteLine(value);
                Console.WriteLine(PointExtension.ToString(point));
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        [TestMethod]
        public void TestPointsIntervalContains() {
            /* “point = (16400, 9045.71823334187, 0)”不在区间
             * “Origin = (16400, 9200, 0), 
             * Direction = (0, -1, 0), 
             * Start = 154.281766658129, 
             * End = 955.436861635746, 
             * StartPoint = (16400, 9045.71823334187, 0), 
             * EndPoint = (16400, 8244.56313836425, 0)”内。*/
            var itvl = new PointsInterval {
                Origin = new Point(16400, 9200, 0),
                Direction = new Vector(0, -1, 0),
                Start = 154.281766658129,
                End = 955.436861635746,
            };
            var point = new Point(16400, 9045.71823334187, 0);
#pragma warning disable CS0618
            var value = itvl.GetValue(point);
            Console.WriteLine(value);
            Console.WriteLine(itvl.Contains(point));
#pragma warning restore CS0618
        }
        [TestMethod]
        public void TestPositionOfTriangleOnLines() {
            /*var line1 = new Line {
                Origin = new Point {
                    X = 6018.3122115426,
                    Y = -79.5701806502621,
                    Z = 0
                },
                Direction = new Vector {
                    X = 5990.01247658099,
                    Y = 499.750468074976,
                    Z = 0
                },
            };
            var line2 = new Line {
                Origin = new Point {
                    X = -5980.35851658643,
                    Y = -679.503717657217,
                    Z = 0
                },
                Direction = new Vector {
                    X = -6009.98752340033,
                    Y = -100.249532525383,
                    Z = 0
                },
            };
            var line3 = new Line {
                Origin = new Point {
                    X = 0,
                    Y = -7800.00000060075,
                    Z = 0
                },
                Direction = new Vector {
                    X = 0,
                    Y = 7800.00000060075,
                    Z = 0
                },
            };*/
            var line1 = new Line {
                Origin = new Point(16463.9147592418, 8641.7048158889, 0),
                Direction = new Vector(-2030.38042685396, 109.147295669016, 0)
            };
            var line2 = new Line {
                Origin = new Point(16463.914759266, 8641.70481589111, 0),
                Direction = new Vector(2203.02100951981, 341.120543598396, 0)
            };
            var line3 = new Line {
                Origin = new Point(16400, 9200, 0),
                Direction = new Vector(0, -1881.45235694476, 0)
            };
            var e1 = Math.Sqrt(122900);
            try {
                var position = Geometry3dOperation.PositionOfTriangleOnLines(
                    (line1, line2, line3), (e1, e1, 700));
                if (position is null) {
                    Console.WriteLine("\nNo solution!");
                } else {
                    var model = new Model();
                    var gdrawer = new GraphicsDrawer();
                    var doDraw = model.GetConnectionStatus();
                    if (doDraw) {
                        gdrawer.DrawLine(line1, color: ColorExtension.Orange, length: 50000);
                        gdrawer.DrawLine(line2, color: ColorExtension.Orange, length: 50000);
                        gdrawer.DrawLine(line3, color: ColorExtension.Orange, length: 50000);
                    }
                    var num = 0;
                    var color = new Color[] {
                        ColorExtension.Blue,
                        ColorExtension.Lime,
                        ColorExtension.MediumOrchid,
                        ColorExtension.Red,
                    };
                    var i = 0;
                    foreach (var (P1, P2, P3) in position) {
                        num++;
                        Console.WriteLine();
                        Console.WriteLine($"Solution #{num}:");
                        Console.WriteLine($"P1 = {P1}, P2 = {P2}, P3 = {P3}");
                        Console.WriteLine(
                            $"E1 = {Distance.PointToPoint(P1, P3)}, " +
                            $"E2 = {Distance.PointToPoint(P2, P3)}, " +
                            $"E3 = {Distance.PointToPoint(P1, P2)}");
                        if (doDraw) {
                            gdrawer.DrawLineSegment(P1, P2, color[i]);
                            gdrawer.DrawLineSegment(P1, P3, color[i]);
                            gdrawer.DrawLineSegment(P2, P3, color[i]);
                            i++;
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        [TestMethod]
        public void TestCircleToLine_2D_Epsilon() {
            Console.WriteLine(string.Format("{0:f13}", 1e-12));

            var point = new Point(0.0, -930.36814213834532, 0.0);
            var line = new Line {
                Origin = new Point(-5980.35851658643, -679.503717657217, 0.0),
                Direction = new Vector(-6009.98752340033, -100.249532525383, 0.0)
            };
            var (X1, X2) = IntersectionExtension.CircleToLine_2D(point, 350.57096285916208, line);

            var itvl = new PointsInterval(line);
#pragma warning disable CS0618
            Console.WriteLine($"X1 = {X1}, value = {itvl.GetValue(X1)}");
            Console.WriteLine($"X2 = {X2}, value = {itvl.GetValue(X2)}");
#pragma warning restore CS0618
        }
        [TestMethod]
        public void TestColorToString() {
            var color = ColorExtension.AliceBlue;
            Console.WriteLine(color.ToString());
            Console.WriteLine(color.ToString(null));
            Console.WriteLine(color.ToString("f3"));
            Console.WriteLine(ColorExtension.ToString(color));
        }
        [TestMethod]
        public void TestInheritProperty() {
            var prfbase = new ProfileRect("RHS400*300-350*250*14");
            Console.WriteLine($"prfbase: h1 = {prfbase.h1}, h2 = {prfbase.h2}, " +
                $"b1 = {prfbase.b1}, b2 = {prfbase.b2}, " +
                $"s = {prfbase.s}, t = {prfbase.t}");

            ProfileRect_Invariant prfinherit1, prfinherit2 = null;
            try {
                prfinherit1 = new ProfileRect_Invariant("RHS400*300-350*250*14");
                Console.WriteLine($"prfinherit1: h1 = {prfinherit1.h1}, h2 = {prfinherit1.h2}, " +
                    $"b1 = {prfinherit1.b1}, b2 = {prfinherit1.b2}, " +
                    $"s = {prfinherit1.s}, t = {prfinherit1.t}");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            try {
                prfinherit2 = new ProfileRect_Invariant("RHS400*300-400*300*14");
                Console.WriteLine($"prfinherit2: h1 = {prfinherit2.h1}, h2 = {prfinherit2.h2}, " +
                    $"b1 = {prfinherit2.b1}, b2 = {prfinherit2.b2}, " +
                    $"s = {prfinherit2.s}, t = {prfinherit2.t}");

                prfinherit2.ProfileText = "RHS400*300-350*250*14";
                Console.WriteLine($"prfinherit2: h1 = {prfinherit2.h1}, h2 = {prfinherit2.h2}, " +
                    $"b1 = {prfinherit2.b1}, b2 = {prfinherit2.b2}, " +
                    $"s = {prfinherit2.s}, t = {prfinherit2.t}");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            } finally {
                Console.WriteLine($"prfinherit2: h1 = {prfinherit2.h1}, h2 = {prfinherit2.h2}, " +
                    $"b1 = {prfinherit2.b1}, b2 = {prfinherit2.b2}, " +
                    $"s = {prfinherit2.s}, t = {prfinherit2.t}");
            }
        }
        [TestMethod]
        public void TestComponentReflection() {
            if (!new Model().GetConnectionStatus()) return;

            var picker = new Picker();
            var obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
            var type = obj.GetType();
            Console.WriteLine($"Type is {type}");
            var propertyInfo = type.GetProperties();
            FieldInfo[] fieldInfo;
            foreach (var property in propertyInfo) {
                Console.WriteLine($"Property {property.Name}'s type is {property.PropertyType.Name}, value is {property.GetValue(obj)}");
                if (property.Name == "UpVector") {
                    fieldInfo = property.PropertyType.GetFields();
                    foreach (var field in fieldInfo) {
                        Console.WriteLine($"\tField {field.Name} = {field.GetValue(property.GetValue(obj))}");
                    }
                }
            }
            double x = 0, y = 0, z = 0;
            if (type == typeof(Connection) && ((Connection) obj).Name == "WJ1001") {
                if (((Connection) obj).GetAttribute("normal_x", ref x)
                    && ((Connection) obj).GetAttribute("normal_y", ref y)
                    && ((Connection) obj).GetAttribute("normal_z", ref z)) {
                    Console.WriteLine($"Normal = ({x}, {y}, {z})");
                } else {
                    Console.WriteLine("GetAttribute failed.");
                }

            }
        }
        [TestMethod]
        public void TestStringCompression() {
            var rawString = "<188032>(-223.180370446127, -2796.25668730194, 12022.0182501074);" +
                "<188317>(-2554.56716509891, -11230.1652854544, 56896.6903083333);";
#pragma warning disable CS0612
            var compressedString = StringCompression.Compress(rawString);
            var decompressedString = StringCompression.Decompress(compressedString);
#pragma warning restore CS0612
            Console.WriteLine(compressedString);
            Console.WriteLine(decompressedString);
        }
        [TestMethod]
        public void TestByteConvert() {
            try {
                var dValue = -223.180370446127;
                var bytes = Convert.ChangeType(dValue, typeof(byte[])) as byte[];

                var str = string.Empty;
                foreach (var item in bytes) {
                    str += item;
                }
                Console.WriteLine(str);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            try {
                var dValue = -2796.25668730194;
                var bytes = BitConverter.GetBytes(dValue);
                var str = Convert.ToBase64String(bytes);

                Console.WriteLine(str);
                Console.WriteLine(BitConverter.ToDouble(Convert.FromBase64String(str), 0));
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
