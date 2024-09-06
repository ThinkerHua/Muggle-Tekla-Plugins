using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace MuggleTeklaPlugins.Geometry3dExtension {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="CoordinateSystem"/> 的扩展。
    /// </summary>
    public static class CoordinateSystemExtension {
        public static string GetInfo(this CoordinateSystem cs) {
            return $"AxisX:{cs.AxisX}\nAxisY:{cs.AxisY}\nOrigin:{cs.Origin}";
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Point"/> 的扩展。
    /// </summary>
    public static class PointExtension {
        /// <summary>
        /// 使用给定点平移点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="point"></param>
        public static void Translate(this Point p, Point point) {
            if (point == null)
                return;

            p.X += point.X;
            p.Y += point.Y;
            p.Z += point.Z;
        }
        /// <summary>
        /// 将点从一个变换平面转换到另一个变换平面。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sourceTP">源变换平面</param>
        /// <param name="targetTP">目标变换平面</param>
        public static void Transform(this Point p, TransformationPlane sourceTP, TransformationPlane targetTP) {
            if (sourceTP == null || targetTP == null) return;

            //p = targetTP.TransformationMatrixToLocal.Transform(sourceTP.TransformationMatrixToGlobal.Transform(p));//无效
            var point = new Point(targetTP.TransformationMatrixToLocal.Transform(sourceTP.TransformationMatrixToGlobal.Transform(p)));
            p.X = point.X;
            p.Y = point.Y;
            p.Z = point.Z;
        }
        /// <summary>
        /// 将点从源变换平面转换到当前变换平面。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sourceTP">源变换平面</param>
        public static void TransformFrom(this Point p, TransformationPlane sourceTP) {
            if (sourceTP == null) return;

            var currentTP = new TransformationPlane(new CoordinateSystem());
            p.Transform(sourceTP, currentTP);
        }
        /// <summary>
        /// 将点从当前变换平面转换到目标变换平面。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="targetTP">目标变换平面</param>
        public static void TransformTo(this Point p, TransformationPlane targetTP) {
            if (targetTP == null) return;

            var currentTP = new TransformationPlane(new CoordinateSystem());
            p.Transform(currentTP, targetTP);
        }
        /// <summary>
        /// 将点从一个坐标系转换到另一个坐标系。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sourceCS">源坐标系</param>
        /// <param name="targetCS">目标坐标系</param>
        public static void Transform(this Point p, CoordinateSystem sourceCS, CoordinateSystem targetCS) {
            if (sourceCS == null || targetCS == null) return;

            var matrix = MatrixFactory.ByCoordinateSystems(sourceCS, targetCS);
            var point = matrix.Transform(p);
            p.X = point.X;
            p.Y = point.Y;
            p.Z = point.Z;
        }
        /// <summary>
        /// 将点从源坐标系转换到当前坐标系。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sourceCS">源坐标系</param>
        public static void TransformFrom(this Point p, CoordinateSystem sourceCS) {
            if (sourceCS == null) return;

            p.Transform(sourceCS, new CoordinateSystem());
        }
        /// <summary>
        /// 将点从当前坐标系转换到目标坐标系。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="targetCS">目标坐标系</param>
        public static void TransformTo(this Point p, CoordinateSystem targetCS) {
            if (targetCS == null) return;

            p.Transform(new CoordinateSystem(), targetCS);
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Vector"/> 的扩展。
    /// </summary>
    public static class VectorExtension {
        /// <summary>
        /// 获取向量之间具有方向性的角度。正方向由 <paramref name="normal"/> 决定（仅需指示大致方向）。
        /// </summary>
        /// <param name="v">当前向量</param>
        /// <param name="vector">给定向量</param>
        /// <param name="normal">法向（仅需指示大致方向）</param>
        /// <returns>向量之间具有方向性的角度（弧度制），取值范围为 [0.0, 2π)。</returns>
        public static double GetAngleBetween_WithDirection(this Vector v, Vector vector, Vector normal) {
            if (vector == null || normal == null) return 0;

            var angel = v.GetAngleBetween(vector);

            var cross = v.Cross(vector);
            //var zeroVector = new Vector();
            //if (v == zeroVector || vector == zeroVector || cross == zeroVector || normal == zeroVector) return angel;

            var dot = Vector.Dot(cross, normal);
            return dot >= 0 ? angel : 2 * Math.PI - angel;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Matrix"/> 的扩展。
    /// </summary>
    public static class MatrixExtension {
        /// <summary>
        /// 计算行列式。<b>*非方阵行列式未定义，此处忽略矩阵的平移部分。</b>
        /// </summary>
        /// <returns>矩阵（旋转部分）的行列式。</returns>
        public static double Determinant(this Matrix matrix) {
            double det = 0;

            // det = M00 * M11 * M22 + M01 * M12 * M20 + M02 * M10 * M21
            //      -M00 * M12 * M21 - M01 * M10 * M22 - M02 * M11 * M20
            for (int i = 0; i < 3; i++) {
                det += matrix[0, (i + 0) % 3] * matrix[1, (i + 1) % 3] * matrix[2, (i + 2) % 3]
                     - matrix[0, (i + 0) % 3] * matrix[1, (i + 2) % 3] * matrix[2, (i + 1) % 3];
            }

            return det;
        }
        /// <summary>
        /// 使用当前矩阵变换给定坐标系。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="coordinateSystem">给定坐标系</param>
        /// <returns>转换后的坐标系。</returns>
        public static CoordinateSystem Transform(this Matrix matrix, CoordinateSystem coordinateSystem) {

            if (coordinateSystem == null) return null;

            var transposed = matrix.GetTranspose();
            var transposedRotation = transposed.GetRotationPart();

            var origin = transposed.Transform(coordinateSystem.Origin);
            var axisX = new Vector(transposedRotation.Transform(coordinateSystem.AxisX));
            var axisY = new Vector(transposedRotation.Transform(coordinateSystem.AxisY));
            axisX.Normalize(1000);
            axisY.Normalize(1000);

            return new CoordinateSystem(origin, axisX, axisY);
        }
        /// <summary>
        /// 移除矩阵平移部分，即仅保留旋转部分。
        /// </summary>
        /// <param name="matrix"></param>
        public static void RemoveTranslation(this Matrix matrix) {
            matrix[3, 0] = matrix[3, 1] = matrix[3, 2] = 0;
        }
        /// <summary>
        /// 移除矩阵旋转部分，即仅保留平移部分。
        /// </summary>
        /// <param name="matrix"></param>
        public static void RemoveRotation(this Matrix matrix) {
            var transposed = matrix.GetTranspose();
            var rotation = matrix.GetRotationPart();
            var translation = (transposed * rotation).GetTranspose();

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 2; j++) {
                    matrix[i, j] = translation[i, j];
                }
            }
        }
        /// <summary>
        /// 获取当前矩阵平移部分被移除后的新矩阵。
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>矩阵平移部分被移除后的新矩阵。</returns>
        public static Matrix GetRotationPart(this Matrix matrix) {
            var m = new Matrix(matrix);
            m.RemoveTranslation();

            return m;
        }
        /// <summary>
        /// 获取当前矩阵旋转部分被移除后的新矩阵。
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>矩阵旋转部分被移除后的新矩阵。</returns>
        public static Matrix GetTranslationPart(this Matrix matrix) {
            var m = new Matrix(matrix);
            m.RemoveRotation();

            return m;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="MatrixFactory"/> 的扩展。
    /// </summary>
    public static class MatrixFactoryExtension {
        /// <summary>
        /// 使用给定向量创建平移矩阵。
        /// <para><b>
        ///     注：Tekla Open API内部，矩阵操作对象为坐标系。
        ///     参考官方库的<see cref="MatrixFactoryExtension.Rotate(double, Vector)"/> 方法，产生的矩阵对向量进行变换操作，实际得到的结果是反方向旋转的。
        ///     因此，本方法创建的平移矩阵，也是以坐标系为操作对象的，用所得矩阵对点进行变换，得到的结果是反方向移动的。
        /// </b></para>
        /// </summary>
        /// <param name="vector">给定向量</param>
        /// <returns>平移矩阵（线性变换部分为单位矩阵）。</returns>
        public static Matrix Translate(Point vector) {
            if (vector == null) return null;

            var matrix = new Matrix();
            matrix[0, 0] = 1.0; matrix[0, 1] = 0.0; matrix[0, 2] = 0.0;
            matrix[1, 0] = 0.0; matrix[1, 1] = 1.0; matrix[1, 2] = 0.0;
            matrix[2, 0] = 0.0; matrix[2, 1] = 0.0; matrix[2, 2] = 1.0;
            matrix[3, 0] = -vector.X; matrix[3, 1] = -vector.Y; matrix[3, 2] = -vector.Z;

            return matrix;
        }
    }
    public enum OffsetDirectionEnum {
        LEFT,
        RIGHT
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Line"/> 的扩展。
    /// </summary>
    public static class LineExtension {
        /// <summary>
        /// 适用于XY平面。
        /// </summary>
        /// <param name="line"></param>
        /// <param name="distance"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Line Offset(this Line line, double distance, OffsetDirectionEnum direction) {
            if (line == null)
                return line;

            Vector vector = line.Direction.Cross(new Vector(0, 0, direction > 0 ? 1 : -1));
            vector.Normalize(distance);

            return Offset(line, vector);
        }
        /// <summary>
        /// 适用于三维坐标系。
        /// </summary>
        /// <param name="line"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Line Offset(this Line line, Vector vector) {
            if (line == null || vector == null)
                return line;

            Point point = new Point(line.Origin);
            point.Translate(vector);
            Line newline = new Line(point, new Vector(line.Direction));

            return newline;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Arc"/> 的扩展。
    /// </summary>
    public static class ArcExtension {
        /// <summary>
        /// 获取圆弧上指定方向的点。从圆弧中心点指向给定方向。
        /// </summary>
        /// <param name="arc"></param>
        /// <param name="vector">指定方向。不应平行于圆弧法向，也不应是零向量。</param>
        /// <returns>指定方向的点。</returns>
        public static Point GetPointOnDirection(this Arc arc, Vector vector) {
            if (vector == null || vector == new Vector() ||
                Tekla.Structures.Geometry3d.Parallel.VectorToVector(vector, arc.Normal)) return null;

            var v = ProjectionExtension.VectorToPlane(vector, new GeometricPlane(arc.CenterPoint, arc.Normal));
            var angle = arc.StartDirection.GetAngleBetween_WithDirection(v, arc.Normal);
            if (angle > arc.Angle) return null;

            v.Normalize(arc.Radius);
            v.Translate(arc.CenterPoint);

            return v;
        }
        /// <summary>
        /// 获取弧线上在 <paramref name="startPoint"/> 与 <paramref name="endPoint"/> 之间每隔 <paramref name="stepDegrees"/> 角度的点的集合。
        /// </summary>
        /// <param name="arc"></param>
        /// <param name="startPoint">起始计算点。（在弧平面上的投影）不应与弧中心点重合。
        ///     如果不在弧线上，则按弧中心点与该点构成的射线在完整弧线（圆）上投影的点计算。</param>
        /// <param name="endPoint">终止计算点。（在弧平面上的投影）不应与弧中心点重合。
        ///     如果不在弧线上，则按弧中心点与该点构成的射线在完整弧线（圆）上投影的点计算。</param>
        /// <param name="stepDegrees">每隔 <paramref name="stepDegrees"/> 角度收集弧线上的点。弧度制。</param>
        /// <returns>弧线上的点的集合，是弧线上区间 [ <paramref name="startPoint"/>, <paramref name="endPoint"/> ] 与 
        ///     [ <see cref="Arc.StartPoint"/>, <see cref="Arc.EndPoint"/> ] 的<b>交集</b>的<b>子集</b>。
        /// </returns>
        public static List<Point> GetPoints(this Arc arc, Point startPoint, Point endPoint, double stepDegrees) {
            List<Point> points = null;

            // 空参或输入点在平面上投影与弧中心点重合
            if (startPoint == null || endPoint == null) return points;
            var gPlane = new GeometricPlane(arc.CenterPoint, arc.Normal);
            if (Tekla.Structures.Geometry3d.Projection.PointToPlane(startPoint, gPlane) == arc.CenterPoint ||
                Tekla.Structures.Geometry3d.Projection.PointToPlane(endPoint, gPlane) == arc.CenterPoint) return points;

            if (arc.Radius == 0) return new List<Point> { arc.StartPoint };

            var startVector = new Vector(startPoint - arc.CenterPoint);
            var endVector = new Vector(endPoint - arc.CenterPoint);
            startVector = ProjectionExtension.VectorToPlane(startVector, gPlane);
            endVector = ProjectionExtension.VectorToPlane(endVector, gPlane);
            startVector.Normalize(arc.Radius);
            endVector.Normalize(arc.Radius);

            var rotationMatrix = MatrixFactory.Rotate(-stepDegrees, gPlane.Normal);
            var currentVector = new Vector(startVector);

            double angleRange = startVector.GetAngleBetween_WithDirection(endVector, gPlane.Normal);

            points = new List<Point>();
            double angleWithArcStart;
            Point point;
            for (int i = 0; i <= angleRange / stepDegrees; i++) {
                angleWithArcStart = arc.StartDirection.GetAngleBetween_WithDirection(currentVector, gPlane.Normal);
                if (angleWithArcStart <= angleRange) {
                    point = new Point(currentVector);
                    point.Translate(arc.CenterPoint);
                    points.Add(point);
                }

                currentVector = new Vector(rotationMatrix.Transform(currentVector));
            }

            return points;
        }
        /// <summary>
        /// 获取弧线上定数等分点集合。
        /// </summary>
        /// <param name="arc"></param>
        /// <param name="num">等分数。</param>
        /// <returns>定数等分点集合。</returns>
        public static List<Point> GetPointsDivide(this Arc arc, int num) {
            if (num <= 0) return null;

            var degrees = arc.Angle / num;
            return arc.GetPoints(arc.StartPoint, arc.EndPoint, degrees);
        }
        /// <summary>
        /// 获取弧线上定距等分点集合。
        /// </summary>
        /// <param name="arc"></param>
        /// <param name="length">等分弧长。</param>
        /// <returns>定距等分点集合。</returns>
        public static List<Point> GetPointsMeasure(this Arc arc, double length) {
            if (length <= 0) return null;
            if (arc.Radius == 0) return new List<Point> { arc.StartPoint };

            var degrees = length / arc.Radius;
            return arc.GetPoints(arc.StartPoint, arc.EndPoint, degrees);
        }
    }
    /// <summary>
    /// 几何平面构造器。
    /// </summary>
    public static class GeometricPlaneFactory {
        /// <summary>
        /// 根据两条直线构造一个几何平面。
        /// </summary>
        /// <param name="line1">构造几何平面所需的直线</param>
        /// <param name="line2">构造几何平面所需的直线</param>
        /// <param name="gPlane">成功构造时由此参数输出几何平面。
        ///     <para>gPlane.Origin == line.Origin</para>
        ///     <para>两线平行时, gPlane.Normal == line1.Direction.Cross(new Vector(line2.Origin - line1.Origin))</para>
        ///     <para>两线相交时，gPlane.Normal == line1.Direction.Cross(line2.Direction)</para>
        /// </param>
        /// <returns>
        /// <list type="bullet">
        ///     <item>-1: <paramref name="gPlane"/> = null。
        ///         有无数个解，即两条直线共线，或至少有一条直线 Direction 属性为零长度向量，或至少有一条直线为 null。
        ///     </item>
        ///     <item>0: <paramref name="gPlane"/> = null。无解，两条直线不共面。</item>
        ///     <item>1: 有且仅有唯一解，此时由输出参数<paramref name="gPlane"/>输出成功构造的几何平面。</item>
        /// </list>
        /// </returns>
        public static int ByLines(Line line1, Line line2, out GeometricPlane gPlane) {
            gPlane = null;

            if (line1 == null || line2 == null) return -1;//参数为null
            var zeroVector = new Vector();
            if (line1.Direction.Equals(zeroVector) || line2.Direction.Equals(zeroVector)) return -1;//Direction属性零长度

            if (Tekla.Structures.Geometry3d.Parallel.VectorToVector(line1.Direction, line2.Direction)) {
                if (line1.Origin.Equals(Tekla.Structures.Geometry3d.Projection.PointToLine(line1.Origin, line2))) return -1;//共线

                gPlane = new GeometricPlane(line1.Origin, line1.Direction, new Vector(line2.Origin - line1.Origin));
            } else {
                var lineSegment = Tekla.Structures.Geometry3d.Intersection.LineToLine(line1, line2);
                if (!lineSegment.StartPoint.Equals(lineSegment.EndPoint)) return 0;//不共面

                gPlane = new GeometricPlane(line1.Origin, line1.Direction, line2.Direction);
            }

            return 1;
        }
        /// <summary>
        /// 根据三点构造一个几何平面。
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <returns>构造的几何平面。当至少有一点为null，或至少有两点共点时，则返回null。
        ///     <para>成功构造时，几何平面的：</para>
        ///     <para>Origin == point1</para>
        ///     <para>Normal == new Vector(point2 - point1).Cross(new Vector(point3 - point1))</para>
        /// </returns>
        public static GeometricPlane ByPoints(Point point1, Point point2, Point point3) {
            GeometricPlane gPlane = null;

            if (point1 == null || point2 == null || point3 == null) return gPlane;
            if (point1.Equals(point2) || point1.Equals(point3) || point2.Equals(point3)) return gPlane;

            gPlane = new GeometricPlane(point1, new Vector(point2 - point1), new Vector(point3 - point1));

            return gPlane;
        }
        /// <summary>
        /// 用 <see cref="Tekla.Structures.Model"/>.<see cref="Plane"/> 构造一个几何平面。
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static GeometricPlane ByPlane(Plane plane) {
            if (plane == null) return null;

            var gPlane = new GeometricPlane(plane.Origin, plane.AxisX, plane.AxisY);

            return gPlane;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Intersection"/> 的扩展。
    /// </summary>
    public static class IntersectionExtension {
        /// <summary>
        /// 点与直线间最短线段。
        /// </summary>
        /// <param name="point">给定点。</param>
        /// <param name="line">给定直线。</param>
        /// <returns>线段。</returns>
        public static LineSegment PointToLine(Point point, Line line) {
            if (point == null || line == null) return null;
            if (line.Direction == new Vector()) return new LineSegment(point, line.Origin);

            return new LineSegment(point, Tekla.Structures.Geometry3d.Projection.PointToLine(point, line));
        }
        /// <summary>
        /// 圆（满弧）与直线间最短线段。
        /// </summary>
        /// <param name="circle">给定的圆，不是满弧依然当成满弧处理。</param>
        /// <param name="line">给定的直线。直线 Direction 属性不应为零向量。</param>
        /// <returns>最短线段集合。符合条件的解有多种情形：
        /// <list type="number">
        ///     <item>圆半径为0：此时相当于求圆中心点与直线间的最短线段。</item>
        ///     <item>直线垂直于圆平面：
        ///         <list type="bullet">
        ///             <item>穿过圆中心点：此时有无数个解，返回null。</item>
        ///             <item>不穿过圆中心点：此时仅有一个解。</item>
        ///         </list>
        ///     </item>
        ///     <item>直线平行于圆平面：
        ///         <list type="bullet">
        ///             <item>直线在圆平面上投影与圆不相交或相切：有一个解。</item>
        ///             <item>直线在圆平面上投影在与圆相交：有两个解。</item>
        ///         </list>
        ///     </item>
        ///     <item>直线既不垂直也不平行于圆平面：
        ///         <list type="bullet">
        ///             <item>与穿过的圆直径所在直线垂直：
        ///                 当圆中心点到直线的距离在一个恰当的位置时，有三个解。
        ///                 小于这个数值有两个解，大于这个数值只有一个解。
        ///                 具体值为：d == r * (1 - cos(θ)^2) / (1 + cos(θ)^2) || d == r，
        ///                 只需考虑第一个边界条件值。
        ///             </item>
        ///             <item>与穿过的圆直径所在直线不垂直：只有一个解。</item>
        ///         </list>
        ///     </item>
        /// </list>
        /// </returns>
        public static List<LineSegment> CircleToLine(Arc circle, Line line) {
            if (circle == null || line == null || line.Direction == new Vector()) return null;

            var segList = new List<LineSegment>();
            LineSegment seg;
            //  情形1：圆半径为0
            if (circle.Radius == 0) {
                seg = PointToLine(circle.CenterPoint, line);
                segList.Add(seg);
                return segList;
            }

            var cFull = new Arc(circle.CenterPoint, circle.StartPoint, circle.Normal, 2 * Math.PI);
            var gPlane = new GeometricPlane(cFull.CenterPoint, cFull.Normal);
            var lineProjected = Tekla.Structures.Geometry3d.Projection.LineToPlane(line, gPlane);
            var disCenterToLineProjected = Distance.PointToLine(cFull.CenterPoint, lineProjected);

            var angleLineWithNormal = line.Direction.GetAngleBetween(cFull.Normal);
            if (angleLineWithNormal == 0) {
                //  情形2.1：直线垂直于圆平面，穿过圆中心点
                if (Distance.PointToLine(cFull.CenterPoint, line) == 0) return null;

                //  情形2.2：直线垂直于圆平面，不穿过圆中心点
                var p1 = new Point(cFull.CenterPoint);
                var p2 = Tekla.Structures.Geometry3d.Projection.PointToLine(p1, line);
                var v = new Vector(p2 - p1);
                p1 = cFull.GetPointOnDirection(v);
                seg = new LineSegment(p1, p2);
                segList.Add(seg);
            } else if (angleLineWithNormal == Math.PI * 0.5) {

                var p1 = new Point(cFull.CenterPoint);
                var p2 = Tekla.Structures.Geometry3d.Projection.PointToLine(p1, line);
                var v = new Vector(p2 - p1);

                if (disCenterToLineProjected >= cFull.Radius) {
                    //  情形3.1：直线平行于圆平面，直线在圆平面上投影与圆不相交或相切
                    p1 = cFull.GetPointOnDirection(v);
                    seg = new LineSegment(p1, p2);
                    segList.Add(seg);
                } else {
                    //  情形3.2：直线平行于圆平面，直线在圆平面上投影在与圆相交
                    var angle = Math.Acos(disCenterToLineProjected / cFull.Radius);
                    var rotationMatrix = MatrixFactory.Rotate(angle, cFull.Normal);

                    v = new Vector(rotationMatrix.Transform(v));
                    p1 = cFull.GetPointOnDirection(v);
                    p2 = Tekla.Structures.Geometry3d.Projection.PointToLine(p1, line);
                    seg = new LineSegment(p1, p2);
                    segList.Add(seg);

                    rotationMatrix = MatrixFactory.Rotate(-2 * angle, cFull.Normal);
                    v = new Vector(rotationMatrix.Transform(v));
                    p1 = cFull.GetPointOnDirection(v);
                    p2 = Tekla.Structures.Geometry3d.Projection.PointToLine(p1, line);
                    seg = new LineSegment(p1, p2);
                    segList.Add(seg);
                }
            } else {
                var pointLineIntersectPlane = Tekla.Structures.Geometry3d.Intersection.LineToLine(line, lineProjected).StartPoint;
                var vDiameter = new Vector(pointLineIntersectPlane - cFull.CenterPoint);

                var angleDiameterWithLine = vDiameter.GetAngleBetween(line.Direction);
                if (angleDiameterWithLine == Math.PI * 0.5) {
                    //  情形4.1：直线既不垂直也不平行于圆平面，与穿过的圆直径所在直线垂直

                    //  边界条件 d == r * (1 - cos(θ)^2) / (1 + cos(θ)^2)
                    var disBoundary = cFull.Radius * (1 - Math.Pow(Math.Cos(angleLineWithNormal), 2))
                                                    / (1 + Math.Pow(Math.Cos(angleLineWithNormal), 2));
                    var disCenterToIntersection = vDiameter.GetLength();
                    if (disCenterToIntersection <= disBoundary) {
                        var angle = Math.Acos(disCenterToIntersection / cFull.Radius);
                        var rotationMatrix = MatrixFactory.Rotate(angle, cFull.Normal);
                        var v = new Vector(rotationMatrix.Transform(vDiameter));
                        var p1 = cFull.GetPointOnDirection(v);
                        var p2 = Tekla.Structures.Geometry3d.Projection.PointToLine(p1, line);
                        seg = new LineSegment(p1, p2);
                        segList.Add(seg);

                        rotationMatrix = MatrixFactory.Rotate(-angle, cFull.Normal);
                        v = new Vector(rotationMatrix.Transform(vDiameter));
                        p1 = cFull.GetPointOnDirection(v);
                        p2 = Tekla.Structures.Geometry3d.Projection.PointToLine(p1, line);
                        seg = new LineSegment(p1, p2);
                        segList.Add(seg);
                    }
                    if (disCenterToIntersection >= disBoundary) {
                        var p3 = cFull.GetPointOnDirection(vDiameter);
                        seg = new LineSegment(p3, pointLineIntersectPlane);
                        segList.Add(seg);
                    }
                } else {
                    //  情形4.2：直线既不垂直也不平行于圆平面，与穿过的圆直径所在直线不垂直
                    throw new NotImplementedException();
                }
            }

            return segList;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Projection"/> 的扩展。
    /// </summary>
    public static class ProjectionExtension {
        /// <summary>
        /// 获取向量在平面上投影的向量。
        /// </summary>
        /// <param name="vector">要投影的向量</param>
        /// <param name="gPlane">要投影的平面</param>
        /// <returns>投影的向量。</returns>
        public static Vector VectorToPlane(Vector vector, GeometricPlane gPlane) {
            if (vector == null || gPlane == null) return null;

            // 公式 P = V - V * N / ||N||^2 * N
            // GeometricPlane.Normal 不可能是零向量，不需要验证
            return new Vector(vector - Vector.Dot(vector, gPlane.Normal) / Math.Pow(gPlane.Normal.GetLength(), 2) * gPlane.Normal);
        }
    }
    public static class Geometry3dOperation {
        /// <summary>
        /// 输入与X轴正方向 及 与XY平面之间的夹角，返回方向向量。
        /// </summary>
        /// <param name="angle_between_X">弧度制，与X轴正方向之间的夹角</param>
        /// <param name="angle_between_XY">弧度制，与XY平面之间的夹角</param>
        /// <returns><b>单位长度向量</b></returns>
        public static Vector GetDirectionByAngle(double angle_between_X, double angle_between_XY = 0) {
            Vector direction = new Vector {
                X = Math.Cos(angle_between_X),
                Y = Math.Sin(angle_between_X),
                Z = Math.Sin(angle_between_XY)
            };

            return direction;
        }
        /// <summary>
        /// 对点进行镜像。
        /// </summary>
        /// <param name="point">要镜像的点</param>
        /// <param name="byPlane">镜像平面</param>
        /// <returns>镜像后的点</returns>
        public static Point Mirror(Point point, GeometricPlane byPlane) {

            var p = Tekla.Structures.Geometry3d.Projection.PointToPlane(point, byPlane);
            var v = new Vector(p - point);
            v *= 2;
            p.Translate(v);

            return p;
        }
        /// <summary>
        /// 对 ContourPoints 进行镜像。
        /// </summary>
        /// <param name="contourPoints">要镜像的ContourPoints</param>
        /// <param name="byPlane">镜像平面</param>
        /// <returns>镜像后的ContourPoints</returns>
        public static ArrayList Mirror(ArrayList contourPoints, GeometricPlane byPlane) {
            ArrayList arrayList = null;
            if (contourPoints == null || byPlane == null) return arrayList;

            try {
                arrayList = new ArrayList(contourPoints);
                Point point;
                ContourPoint contourPoint;
                for (int i = 0; i < arrayList.Count; i++) {
                    contourPoint = (ContourPoint) arrayList[i];
                    point = new Point(contourPoint.X, contourPoint.Y, contourPoint.Z);
                    point = Mirror(point, byPlane);
                    contourPoint.X = point.X;
                    contourPoint.Y = point.Y;
                    contourPoint.Z = point.Z;
                    //arrayList[i] = contourPoint;
                }
            } catch {
                arrayList = null;
            }

            return arrayList;
        }
        /// <summary>
        /// 在平面上，有一个固定形状的三角形（位置不固定）和三条已知直线（位置固定）。求当三角形三个顶点分别落三条直线上时的位置（即三个顶点值）。
        /// <para>作如下约定：</para>
        /// <list type="bullet">
        ///     <item>  <para>三角形三个顶点分别为 <paramref name="p1"/>, <paramref name="p2"/>, <paramref name="p3"/>。
        ///                   三条边分别为 <paramref name="edge1"/>, <paramref name="edge2"/>, <paramref name="edge3"/>。</para>
        ///             <para><paramref name="edge1"/>: <paramref name="p1"/>&lt;--><paramref name="p2"/></para>
        ///             <para><paramref name="edge2"/>: <paramref name="p1"/>&lt;--><paramref name="p3"/></para>
        ///             <para><paramref name="edge3"/>: <paramref name="p2"/>&lt;--><paramref name="p3"/></para>
        ///     </item>
        ///     <item>  三条直线为 <paramref name="line1"/>, <paramref name="line2"/>, <paramref name="line3"/>。
        ///             <paramref name="p1"/>, <paramref name="p2"/>, <paramref name="p3"/> 
        ///             分别落在 <paramref name="line1"/>, <paramref name="line2"/>, <paramref name="line3"/>上。
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="line3"></param>
        /// <param name="edge1"></param>
        /// <param name="edge2"></param>
        /// <param name="edge3"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public static void DeterminePositionOfTriangle(
            Line line1, Line line2, Line line3,
            double edge1, double edge2, double edge3,
            out Point p1, out Point p2, out Point p3) {

            p1 = p2 = p3 = null;

            //不构成三角形
            if (edge1 <= 0 || edge2 <= 0 || edge3 <= 0) return;
            if ((edge1 + edge2) <= edge3 || (edge1 + edge3) <= edge2 || (edge2 + edge3) <= edge1) return;

            //空参或零向量
            if (line1 == null || line2 == null || line3 == null) return;
            var zeroVector = new Vector();
            if (line1.Direction == zeroVector || line2.Direction == zeroVector || line3.Direction == zeroVector) return;

            //不共面
            if (GeometricPlaneFactory.ByLines(line1, line2, out _) == 0 ||
                GeometricPlaneFactory.ByLines(line1, line3, out _) == 0 ||
                GeometricPlaneFactory.ByLines(line2, line3, out _) == 0)
                return;

            Vector vector1, vector2, vector3;
            vector1 = new Vector(line1.Direction);
            vector2 = new Vector(line2.Direction);
            vector3 = new Vector(line3.Direction);
            p1 = Tekla.Structures.Geometry3d.Intersection.LineToLine(line1, line2).StartPoint;
            p2 = new Point(p1);

            Vector func(Vector vector, double length) { vector.Normalize(length); return vector; }
            p2.Translate(func(vector2, edge1));

            throw new NotImplementedException();
        }
    }
}
