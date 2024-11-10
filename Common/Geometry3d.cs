using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

using MuggleTeklaPlugins.Common;

namespace MuggleTeklaPlugins.Geometry3dExtension {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="CoordinateSystem"/> 的扩展。
    /// </summary>
    public static class CoordinateSystemExtension {
        /// <summary>
        /// 获取坐标系的字符串表示形式。
        /// </summary>
        /// <param name="cs">当前坐标系</param>
        /// <param name="format">复合格式字符串。默认值 null。</param>
        /// <returns>坐标系的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToString(this CoordinateSystem cs, string format = default) {
            if (cs is null) {
                throw new ArgumentNullException(nameof(cs));
            }

            return $"Origin = {cs.Origin.ToString(format)}\n" +
                $"AxisX = {cs.AxisX.ToString(format)}\n" +
                $"AxisY = {cs.AxisY.ToString(format)}\n";
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Distance"/> 的扩展。
    /// </summary>
    public static class DistanceExtension {
        /// <summary>
        /// 求两条给定直线间的最短距离。对直线退化成点，即 Direction 为零向量的情形也能适用。
        /// </summary>
        /// <param name="line1">给定直线</param>
        /// <param name="line2">给定直线</param>
        /// <returns>两条直线间的最短距离。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double LineToLine(Line line1, Line line2) {
            if (line1 is null) {
                throw new ArgumentNullException(nameof(line1));
            }

            if (line2 is null) {
                throw new ArgumentNullException(nameof(line2));
            }

            var v = new Vector(line2.Origin - line1.Origin);
            if (v.IsZero()) return 0;

            var n = Vector.Cross(line1.Direction, line2.Direction);

            double dis;
            var situation = 0b00;
            situation |= line1.Direction.IsZero() ? 0b01 : 0b00;
            situation |= line2.Direction.IsZero() ? 0b10 : 0b00;
            switch (situation) {
            case 0b00:
                if (n.IsZero()) {
                    dis = Vector.Cross(v, line2.Direction).GetLength() / line2.Direction.GetLength();
                } else {
                    dis = Math.Abs(Vector.Dot(v, n) / n.GetLength());
                }
                break;
            case 0b01:
                dis = Vector.Cross(v, line2.Direction).GetLength() / line2.Direction.GetLength();
                break;
            case 0b10:
                dis = Vector.Cross(v, line1.Direction).GetLength() / line1.Direction.GetLength();
                break;
            case 0b11:
            default:
                dis = v.GetLength();
                break;
            }

            return dis;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Point"/> 的扩展。
    /// </summary>
    public static class PointExtension {
        /// <summary>
        /// 获取点的字符串表示形式。
        /// <para><b>
        ///     * 官方实现的 <see cref="Point.ToString()"/> 方法，输出的是保留3位有效数字的字符串，
        ///     不能输出其他样式。本实现可自定义输出样式。
        /// </b></para>
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="format">复合格式字符串。默认 null。</param>
        /// <returns>点的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToString(this Point p, string format = default) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            return $"({p.X.ToString(format)}, {p.Y.ToString(format)}, {p.Z.ToString(format)})";
        }
        /// <summary>
        /// 判断给定点是否是零点。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="epsilon">容许误差，小于等于此误差当做0处理。默认值0。</param>
        /// <returns>是零点则返回true, 否则返回false。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsZero(this Point p, double epsilon = 0) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (Math.Abs(p.X) <= epsilon && Math.Abs(p.Y) <= epsilon && Math.Abs(p.Z) <= epsilon)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 点与标量的乘法。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="multiplier">乘数</param>
        /// <returns>点与标量的乘积。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Point Multiplication(this Point p, double multiplier) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            return new Point(p.X * multiplier, p.Y * multiplier, p.Z * multiplier);
        }
        /// <summary>
        /// 点与标量的除法。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="divisor">除数</param>
        /// <returns>点与标量的商。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">除数 <paramref name="divisor"/> 不应为 0.0。</exception>
        public static Point Division(this Point p, double divisor) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (divisor == 0.0) {
                throw new ArgumentException($"除数“{nameof(divisor)}”不应为 0.0。");
            }

            return new Point(p.X / divisor, p.Y / divisor, p.Z / divisor);
        }
        /// <summary>
        /// 从给定点复制字段值。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="point">给定点</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Copy(this Point p, Point point) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            p.X = point.X;
            p.Y = point.Y;
            p.Z = point.Z;
        }
        /// <summary>
        /// 使用给定点平移当前点。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="point">给定点</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Translate(this Point p, Point point) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            p.X += point.X;
            p.Y += point.Y;
            p.Z += point.Z;
        }
        /// <summary>
        /// 将点从一个变换平面转换到另一个变换平面。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="sourceTP">源变换平面</param>
        /// <param name="targetTP">目标变换平面</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Transform(this Point p, TransformationPlane sourceTP, TransformationPlane targetTP) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (sourceTP is null) {
                throw new ArgumentNullException(nameof(sourceTP));
            }

            if (targetTP is null) {
                throw new ArgumentNullException(nameof(targetTP));
            }

            //p = targetTP.TransformationMatrixToLocal.Transform(sourceTP.TransformationMatrixToGlobal.Transform(p));//无效
            var point = new Point(targetTP.TransformationMatrixToLocal.Transform(sourceTP.TransformationMatrixToGlobal.Transform(p)));
            p.X = point.X;
            p.Y = point.Y;
            p.Z = point.Z;
        }
        /// <summary>
        /// 将点从源变换平面转换到当前变换平面。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="sourceTP">源变换平面</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TransformFrom(this Point p, TransformationPlane sourceTP) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (sourceTP is null) {
                throw new ArgumentNullException(nameof(sourceTP));
            }

            var currentTP = new TransformationPlane(new CoordinateSystem());
            p.Transform(sourceTP, currentTP);
        }
        /// <summary>
        /// 将点从当前变换平面转换到目标变换平面。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="targetTP">目标变换平面</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TransformTo(this Point p, TransformationPlane targetTP) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (targetTP is null) {
                throw new ArgumentNullException(nameof(targetTP));
            }

            var currentTP = new TransformationPlane(new CoordinateSystem());
            p.Transform(currentTP, targetTP);
        }
        /// <summary>
        /// 将点从一个坐标系转换到另一个坐标系。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="sourceCS">源坐标系</param>
        /// <param name="targetCS">目标坐标系</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Transform(this Point p, CoordinateSystem sourceCS, CoordinateSystem targetCS) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (sourceCS is null) {
                throw new ArgumentNullException(nameof(sourceCS));
            }

            if (targetCS is null) {
                throw new ArgumentNullException(nameof(targetCS));
            }

            var matrix = MatrixFactory.ByCoordinateSystems(sourceCS, targetCS);
            var point = matrix.Transform(p);
            p.X = point.X;
            p.Y = point.Y;
            p.Z = point.Z;
        }
        /// <summary>
        /// 将点从源坐标系转换到当前坐标系。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="sourceCS">源坐标系</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TransformFrom(this Point p, CoordinateSystem sourceCS) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (sourceCS is null) {
                throw new ArgumentNullException(nameof(sourceCS));
            }

            p.Transform(sourceCS, new CoordinateSystem());
        }
        /// <summary>
        /// 将点从当前坐标系转换到目标坐标系。
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="targetCS">目标坐标系</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TransformTo(this Point p, CoordinateSystem targetCS) {
            if (p is null) {
                throw new ArgumentNullException(nameof(p));
            }

            if (targetCS is null) {
                throw new ArgumentNullException(nameof(targetCS));
            }

            p.Transform(new CoordinateSystem(), targetCS);
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Point"/> 类的自定义比较器。
    /// </summary>
    public class PointComparer : IEqualityComparer<Point> {
        public bool Equals(Point point1, Point point2) {
            if (object.ReferenceEquals(point1, point2)) return true;

            if (point1 is null || point2 is null) return false;

            return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
        }

        public int GetHashCode(Point point) {
            if (point is null) return 0;

            return point.GetHashCode();
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Vector"/> 的扩展。
    /// </summary>
    public static class VectorExtension {
        /// <summary>
        /// 获取向量之间更精确的角度。
        /// <para><b>
        ///     * 官方实现的 <see cref="Vector.GetAngleBetween(Vector)"/> 方法，对于一些比较小的角度，会按 0 返回。
        ///     本方法可以返回更精确一些的角度。根据以下计算公式计算：
        ///     <code>cos(θ) = U∙V / (||U|| * ||V||)</code>
        /// </b></para>
        /// <para><b>
        ///     * 官方实现的 <see cref="Vector.GetAngleBetween(Vector)"/> 方法，约定零向量与任意有效向量的角度均为π/2，
        ///     本方法也依此约定实现。
        /// </b></para>
        /// <para><b>
        ///     * 官方实现的 <see cref="Vector.GetAngleBetween(Vector)"/> 方法，输入参数为null时将引发异常：System.NullReferenceException，
        ///     本方法与此行为一致。
        /// </b></para>
        /// </summary>
        /// <param name="v">当前向量</param>
        /// <param name="vector">给定向量</param>
        /// <returns>向量之间的角度,取值范围 [0.0, π]。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double GetAngleBetween_Precisely(this Vector v, Vector vector) {
            if (v is null) {
                throw new ArgumentNullException(nameof(v));
            }

            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

            if (vector.IsZero() || v.IsZero()) return Math.PI * 0.5;

            return Math.Acos(v.Dot(vector) / (v.GetLength() * vector.GetLength()));
        }
        /// <summary>
        /// 获取向量之间具有方向性的角度。正方向由 <paramref name="normal"/> 决定（仅需指示大致方向）。
        /// </summary>
        /// <param name="v">当前向量</param>
        /// <param name="vector">给定向量</param>
        /// <param name="normal">法向（仅需指示大致方向）</param>
        /// <returns>向量之间具有方向性的角度（弧度制），取值范围 [0.0, 2π)。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double GetAngleBetween_WithDirection(this Vector v, Vector vector, Vector normal) {
            if (v is null) {
                throw new ArgumentNullException(nameof(v));
            }

            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

            if (normal is null) {
                throw new ArgumentNullException(nameof(normal));
            }

            var angle = v.GetAngleBetween_Precisely(vector);
            var cross = v.Cross(vector);
            var dot = Vector.Dot(cross, normal);

            return dot >= 0 ? angle : 2 * Math.PI - angle;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Matrix"/> 的扩展。
    /// </summary>
    public static class MatrixExtension {
        /// <summary>
        /// 计算矩阵的行列式。<b>* 非方阵行列式未定义，此处忽略矩阵的平移部分。</b>
        /// </summary>
        /// <returns>矩阵（旋转部分）的行列式。</returns>
        /// <param name="matrix">当前矩阵</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static double Determinant(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

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
        /// <param name="matrix">当前矩阵</param>
        /// <param name="coordinateSystem">给定坐标系</param>
        /// <returns>转换后的坐标系，X轴、Y轴向量标准化为1000。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CoordinateSystem Transform(this Matrix matrix, CoordinateSystem coordinateSystem) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (coordinateSystem is null) {
                throw new ArgumentNullException(nameof(coordinateSystem));
            }

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
        /// 移除当前矩阵的平移部分，即仅保留旋转部分。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveTranslation(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix[3, 0] = matrix[3, 1] = matrix[3, 2] = 0;
        }
        /// <summary>
        /// 移除当前矩阵的旋转部分，即仅保留平移部分。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveRotation(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

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
        /// 获取当前矩阵旋转部分的新矩阵。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <returns>矩阵旋转部分的新矩阵。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Matrix GetRotationPart(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            var m = new Matrix(matrix);
            m.RemoveTranslation();

            return m;
        }
        /// <summary>
        /// 获取当前矩阵平移部分的新矩阵。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <returns>矩阵平移部分的新矩阵。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Matrix GetTranslationPart(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

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
        ///     参考官方库的<see cref="MatrixFactory.Rotate(double, Vector)"/> 方法，产生的矩阵对向量进行变换操作，实际得到的结果是反方向旋转的。
        ///     因此，本方法创建的平移矩阵，也是以坐标系为操作对象的，用所得矩阵对点进行变换，得到的结果是反方向移动的。
        /// </b></para>
        /// </summary>
        /// <param name="vector">给定向量</param>
        /// <returns>平移矩阵（线性变换部分为单位矩阵）。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Matrix Translate(Point vector) {
            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

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
        /// <param name="line">当前直线</param>
        /// <param name="distance">偏移距离</param>
        /// <param name="direction">偏移方向，向左或向右。</param>
        /// <returns>偏移后的直线。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Line Offset(this Line line, double distance, OffsetDirectionEnum direction) {
            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            Vector vector = line.Direction.Cross(new Vector(0, 0, direction > 0 ? 1 : -1));
            vector.Normalize(distance);

            return Offset(line, vector);
        }
        /// <summary>
        /// 适用于三维坐标系。
        /// </summary>
        /// <param name="line">当前直线</param>
        /// <param name="vector">偏移向量</param>
        /// <returns>偏移后的直线。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Line Offset(this Line line, Vector vector) {
            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

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
        /// 获取圆弧上指定方向的点。
        /// </summary>
        /// <param name="arc">当前圆弧</param>
        /// <param name="vector">指定方向，从圆弧中心点指出。不应平行于圆弧法向，也不应为零向量。</param>
        /// <returns>指定方向的点，如指定方向不在圆弧区间内，则返回null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Point GetPointOnDirection(this Arc arc, Vector vector) {
            if (arc is null) {
                throw new ArgumentNullException(nameof(arc));
            }

            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

            if (vector == new Vector() || Parallel.VectorToVector(vector, arc.Normal))
                throw new ArgumentException(nameof(vector));

            var v = ProjectionExtension.VectorToPlane(vector, new GeometricPlane(arc.CenterPoint, arc.Normal));
            var angle = arc.StartDirection.GetAngleBetween_WithDirection(v, arc.Normal);
            if (angle > arc.Angle) return null;

            v.Normalize(arc.Radius);
            v.Translate(arc.CenterPoint);

            return v;
        }
        /// <summary>
        /// 获取弧线上在 <paramref name="startPoint"/> 与 <paramref name="endPoint"/> 之间每隔 <paramref name="stepRadians"/> 角度的点的集合。
        /// <para><b>
        ///     * 约定计算夹角时遵循圆弧的方向。 
        ///     如果 <paramref name="startPoint"/> 与 <paramref name="endPoint"/> 之间夹角为0，则按2π处理。
        /// </b></para>
        /// </summary>
        /// <param name="arc">当前圆弧</param>
        /// <param name="startPoint">
        ///     起始计算点。（在弧平面上的投影）不应与弧中心点重合。
        ///     如果不在弧线上，则按弧中心点与该点构成的射线在完整弧线（圆）上投影的点计算。
        /// </param>
        /// <param name="endPoint">
        ///     终止计算点。（在弧平面上的投影）不应与弧中心点重合。
        ///     如果不在弧线上，则按弧中心点与该点构成的射线在完整弧线（圆）上投影的点计算。
        /// </param>
        /// <param name="stepRadians">每隔给定角度收集弧线上的点。弧度制。</param>
        /// <returns>
        ///     弧线上的点的集合，是弧线上区间 [ <paramref name="startPoint"/>, <paramref name="endPoint"/> ] 与 
        ///     [ <see cref="Arc.StartPoint"/>, <see cref="Arc.EndPoint"/> ] 的<b>交集</b>的<b>子集</b>。
        ///     没有有效值则返回null。
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">输入点在圆弧平面上投影与弧中心点重合。</exception>
        public static List<Point> GetPoints(this Arc arc, Point startPoint, Point endPoint, double stepRadians) {
            if (arc is null) {
                throw new ArgumentNullException(nameof(arc));
            }

            if (startPoint is null) {
                throw new ArgumentNullException(nameof(startPoint));
            }

            if (endPoint is null) {
                throw new ArgumentNullException(nameof(endPoint));
            }

            var gPlane = new GeometricPlane(arc.CenterPoint, arc.Normal);

            if (Projection.PointToPlane(startPoint, gPlane) == arc.CenterPoint)
                throw new ArgumentException($"“{nameof(startPoint)}”在圆弧平面上的投影，不应与弧中心点重合。");

            if (Projection.PointToPlane(endPoint, gPlane) == arc.CenterPoint)
                throw new ArgumentException($"“{nameof(endPoint)}”在圆弧平面上的投影，不应与弧中心点重合。");

            //  0半径特解
            if (arc.Radius == 0) return new List<Point> { arc.StartPoint };

            //  取值区间
            var startVector = new Vector(startPoint - arc.CenterPoint);
            var endVector = new Vector(endPoint - arc.CenterPoint);
            startVector = ProjectionExtension.VectorToPlane(startVector, gPlane);
            endVector = ProjectionExtension.VectorToPlane(endVector, gPlane);
            startVector.Normalize(arc.Radius);
            endVector.Normalize(arc.Radius);
            var angleStart = arc.StartDirection.GetAngleBetween_WithDirection(startVector, arc.Normal);
            var angleEnd = arc.StartDirection.GetAngleBetween_WithDirection(endVector, arc.Normal);

            //  情形1：angleStart <= angleEnd, 区间为 [ angleStart, Min(angleEnd, arc.Angle) ]
            //  情形2：angleStart >  angleEnd, 区间为 [ 0, Min(angleEnd, arc.Angle) ] + [ angleStart, arc.Angle ]
            //  此情形第一个区间段必然有效，第二个区间段当angleStart<arc.Angle时存在

            //  无有效区间
            if (angleStart <= angleEnd && angleStart > arc.Angle) return null;

            double angleCurrent;
            Point point;
            bool inAngleRange;
            double angleRange = startVector.GetAngleBetween_WithDirection(endVector, gPlane.Normal);
            angleRange += angleRange == 0 ? Math.PI * 2 : 0;
            var uBound = angleEnd < arc.Angle ? angleEnd : arc.Angle;
            var rotationMatrix = MatrixFactory.Rotate(-stepRadians, gPlane.Normal);
            var currentVector = new Vector(startVector);
            var points = new List<Point>();
            for (int i = 0; i <= angleRange / stepRadians; i++) {

                inAngleRange = false;

                angleCurrent = arc.StartDirection.GetAngleBetween_WithDirection(currentVector, gPlane.Normal);
                if (angleStart > angleEnd) {
                    //  不需要判断是否大于等于0
                    if (angleCurrent <= uBound || angleCurrent >= angleStart && angleCurrent <= arc.Angle)
                        inAngleRange = true;
                } else {
                    if (angleCurrent >= angleStart && angleCurrent <= uBound)
                        inAngleRange = true;
                }

                if (inAngleRange) {
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
        /// <param name="arc">当前圆弧</param>
        /// <param name="num">等分数</param>
        /// <returns>定数等分点集合。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="num"/>必须大于0。</exception>
        public static List<Point> GetPointsDivide(this Arc arc, int num) {
            if (arc is null) {
                throw new ArgumentNullException(nameof(arc));
            }
            if (num <= 0) throw new ArgumentOutOfRangeException(nameof(num));

            var radians = arc.Angle / num;
            return arc.GetPoints(arc.StartPoint, arc.EndPoint, radians);
        }
        /// <summary>
        /// 获取弧线上定距等分点集合。
        /// </summary>
        /// <param name="arc">当前圆弧</param>
        /// <param name="length">等分弧长</param>
        /// <returns>定距等分点集合。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/>必须大于0。</exception>
        public static List<Point> GetPointsMeasure(this Arc arc, double length) {
            if (arc is null) {
                throw new ArgumentNullException(nameof(arc));
            }
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

            if (arc.Radius == 0) return new List<Point> { arc.StartPoint };

            var radians = length / arc.Radius;
            return arc.GetPoints(arc.StartPoint, arc.EndPoint, radians);
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
        ///     <para><code>gPlane.Origin == line1.Origin</code></para>
        ///     <para>两线平行时：<code>gPlane.Normal == line1.Direction.Cross(new Vector(line2.Origin - line1.Origin))</code></para>
        ///     <para>两线相交时：<code>gPlane.Normal == line1.Direction.Cross(line2.Direction)</code></para>
        /// </param>
        /// <returns>
        /// <list type="bullet">
        ///     <item>-1: <paramref name="gPlane"/> == null。
        ///         有无数个解，即两条直线共线。
        ///     </item>
        ///     <item>0: <paramref name="gPlane"/> == null。无解，两条直线不共面。</item>
        ///     <item>1: 有且仅有唯一解，此时由输出参数<paramref name="gPlane"/>输出成功构造的几何平面。</item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">参数的 Direction 属性不得为零向量。</exception>
        public static int ByLines(Line line1, Line line2, out GeometricPlane gPlane) {
            if (line1 is null) {
                throw new ArgumentNullException(nameof(line1));
            }

            if (line2 is null) {
                throw new ArgumentNullException(nameof(line2));
            }

            if (line1.Direction.IsZero())
                throw new ArgumentException($"“{nameof(line1)}”.Direction 不应为零向量。");

            if (line2.Direction.IsZero())
                throw new ArgumentException($"“{nameof(line2)}”.Direction 不应为零向量。");

            gPlane = null;
            if (Vector.Cross(line1.Direction, line2.Direction).IsZero()) {
                //平行

                //共线
                if (Distance.PointToLine(line1.Origin, line2) == 0) return -1;

                //不共线
                gPlane = new GeometricPlane(line1.Origin, line1.Direction, new Vector(line2.Origin - line1.Origin));
            } else {
                //不平行
                var lineSegment = IntersectionExtension.LineToLine(line1, line2);
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
        /// <returns>成功构造的几何平面。
        ///     <code>Origin == point1</code>
        ///     <code>Normal == new Vector(point2 - point1).Cross(new Vector(point3 - point1))</code>
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">给定点不应相等。</exception>
        public static GeometricPlane ByPoints(Point point1, Point point2, Point point3) {
            if (point1 is null) {
                throw new ArgumentNullException(nameof(point1));
            }

            if (point2 is null) {
                throw new ArgumentNullException(nameof(point2));
            }

            if (point3 is null) {
                throw new ArgumentNullException(nameof(point3));
            }

            if (point1.Equals(point2) || point1.Equals(point3) || point2.Equals(point3))
                throw new ArgumentException("给定点不应相等。");

            return new GeometricPlane(point1, new Vector(point2 - point1), new Vector(point3 - point1));
        }
        /// <summary>
        /// 用 <see cref="Tekla.Structures.Model"/>.<see cref="Plane"/> 构造一个几何平面。
        /// </summary>
        /// <param name="plane"></param>
        /// <returns>成功构造的几何平面。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GeometricPlane ByPlane(Plane plane) {
            if (plane is null) {
                throw new ArgumentNullException(nameof(plane));
            }

            return new GeometricPlane(plane.Origin, plane.AxisX, plane.AxisY);
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
        /// <returns>最短线段。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LineSegment PointToLine(Point point, Line line) {
            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            if (line.Direction.IsZero()) return new LineSegment(point, line.Origin);

            return new LineSegment(point, Projection.PointToLine(point, line));
        }
        /// <summary>
        /// <para>两条直线间最短线段。</para>
        /// <para>
        ///     本实现旨在解决在两直线相交的情况下，官方实现求得的线段长度不等于0的问题。
        ///     同时也实现了求直线退化成点，即 <see cref="Line.Direction"/> 为零向量时的解。
        /// </para>
        /// <para>主要求解公式推导过程如下(<a href="https://math.stackexchange.com/a/4764188">参考</a>)：</para>
        /// <para>L1上的点方程：P=P1+s*V1, L2上的点方程：P=P2+t*V2，最短线段所在直线上的方程：P=P3+r*V3</para>
        /// <para>由于最短线段两端分别落在L1、L2上，则有：(P2+t*V2)+r*V3=P1+s*V1</para>
        /// <para>可令V3=(P2+t*V2)-(P1+s*V1)，代入上述方程，则有：</para>
        /// <para>(1) P1+s*V1=P2+t*V2，即s*V1-t*V2=P2-P1</para>
        /// <para>由于向量与其自身叉积为0，则有：</para>
        /// <para>(2) s*V1×V2=(P2-P1)×V2</para>
        /// <para>这是一个向量方程，要得到实数方程，可以对两边用V1×V2做点积：</para>
        /// <para>s*(V1×V2)∙(V1×V2)=((P2-P1)×V2)∙(V1×V2)，求解出：</para>
        /// <para>(3) s=((P2-P1)×V2)∙(V1×V2)/||V1×V2||^2</para>
        /// <para>再将s代入步骤(1)方程即可求解出：</para>
        /// <para>(4) t=(s*V1-(P2-P1))∙V2/(V2∙V2) - 由于向量没有除法，所以此处需用点积形式做除法</para>
        /// <para>据此即可算出最短线段的两个端点。</para>
        /// <para>
        ///     上述方程中，P1、P2可分别取值为L1、L2的 <see cref="Line.Origin"/> 属性，
        ///     V1、V2分别为L1、L2的 <see cref="Line.Direction"/> 属性。
        /// </para>
        /// <para>另外，最短距离可用公式 d = (P2-P1)∙(V1×V2)/||V1×V2|| 求得。</para>
        /// </summary>
        /// <param name="line1">给定直线1</param>
        /// <param name="line2">给定直线2</param>
        /// <returns>两条直线之间的最短线段。如果直线平行，则为null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LineSegment LineToLine(Line line1, Line line2) {
            if (line1 is null) {
                throw new ArgumentNullException(nameof(line1));
            }

            if (line2 is null) {
                throw new ArgumentNullException(nameof(line2));
            }

            var v = new Vector(line2.Origin - line1.Origin);
            if (v.IsZero()) return new LineSegment(line1.Origin, line2.Origin);

            var s = 0.0;
            var t = 0.0;
            var situation = 0b00;
            situation |= line1.Direction.IsZero() ? 0b01 : 0b00;
            situation |= line2.Direction.IsZero() ? 0b10 : 0b00;
            switch (situation) {
            case 0b00:
                var n = Vector.Cross(line1.Direction, line2.Direction);
                if (n.IsZero()) return null;//  平行

                s = Vector.Dot(Vector.Cross(v, line2.Direction), n) / Math.Pow(n.GetLength(), 2);
                t = Vector.Dot(new Vector(line1.Direction * s - v), line2.Direction) / Vector.Dot(line2.Direction, line2.Direction);
                break;
            case 0b01:
                t = Vector.Dot(-1 * v, line2.Direction) / Vector.Dot(line2.Direction, line2.Direction);
                break;
            case 0b10:
                s = Vector.Dot(v, line1.Direction) / Vector.Dot(line1.Direction, line1.Direction);
                break;
            case 0b11:
            default:
                break;
            }

            return new LineSegment(line1.Origin + s * line1.Direction, line2.Origin + t * line2.Direction);
        }
        /// <summary>
        /// 圆弧与直线间最短线段的集合。
        /// <para>
        ///     <b>* 有可能不是最优解。</b>
        ///     本方法是在圆弧上循环采样（逐步缩小采样间隔）取点计算最短距离，采样区域有可能错过最优解。
        ///     可以设置更小的 <paramref name="samplingSpacingAtStart"/> 值以获得更精确的采样间隔。
        ///     但不宜设置过小的值，一是影响计算速度，二是可能导致大批距离值相等影响判断。
        /// </para>
        /// </summary>
        /// <param name="arc">给定的圆弧</param>
        /// <param name="line">给定的直线</param>
        /// <param name="samplingSpacingAtStart">
        ///     初始采样间隔弧长。
        ///     输入正值以指定初始采样间隔弧长，
        ///     或输入非正值由方法自动确定一个适当的值。
        ///     默认值0。
        /// </param>
        /// <param name="epsilon">
        ///     容许误差，小于此差异的距离值当作相等处理。默认值为
        ///     <see cref="GeometryConstants.DISTANCE_EPSILON"/> 。
        /// </param>
        /// <returns>最短线段集合。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="line"/>.Direction 不应为零向量。</exception>
        public static List<LineSegment> ArcToLine(
            Arc arc,
            Line line,
            double samplingSpacingAtStart = 0,
            double epsilon = GeometryConstants.DISTANCE_EPSILON) {

            if (arc is null) {
                throw new ArgumentNullException(nameof(arc));
            }

            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            if (line.Direction.IsZero())
                throw new ArgumentException($"“{nameof(line)}”.Direction 不应为零向量。");

            //  0半径圆弧
            if (arc.Radius == 0)
                return new List<LineSegment> {
                    new LineSegment(arc.CenterPoint, Projection.PointToLine(arc.CenterPoint, line))
                };

            //  直线垂直圆弧平面穿过弧心的情形
            if (Distance.PointToLine(arc.CenterPoint, line) == 0 && Parallel.VectorToVector(arc.Normal, line.Direction))
                return null;

            //  以下为一般情形
            if (samplingSpacingAtStart <= 0) {
                //  取一个适当的采样间隔
                //  采样太密集影响计算速度，太宽松可能会错过最优解
                samplingSpacingAtStart = arc.Length / 360 > 0.1 ? arc.Length / 360 : 0.1;
            }

            List<LineSegment> segList;
            var spacing = samplingSpacingAtStart;//  采样弧长
            var angle = spacing / arc.Radius;//  采样角度

            #region 初始极值点
            var points = arc.GetPoints(arc.StartPoint, arc.EndPoint, angle);
            var disList = new List<double>();
            foreach (var point in points) {
                disList.Add(Distance.PointToLine(point, line));
            }
            var minExtremeIndexs = CommonOperation.GetLocalExtremeIndexes(disList, CommonOperation.ExtremeTypeEnum.LocalMinimum);
            var minExtremePoints = new List<Point>();//  极小值点集合
            foreach (var index in minExtremeIndexs) {
                minExtremePoints.Add(points[index]);
            }
            var comparer = new PointComparer();
            List<Point> tmpList;
            tmpList = Enumerable.Distinct(minExtremePoints, comparer).ToList();//  剔除重复值
            minExtremePoints.Clear();
            minExtremePoints.AddRange(tmpList);
            #endregion

            Point vector, leftPoint, rightPoint;
            Matrix rotationMatrix;
            while (spacing > epsilon) {
                rotationMatrix = MatrixFactory.Rotate(angle, arc.Normal);

                spacing *= 0.1;//  步进弧长，每次缩小一个数量级
                angle = spacing / arc.Radius;//  步进角度

                points.Clear();
                //  以极小值点左右相邻点为新起止点，取得新细分等分点集合
                foreach (var point in minExtremePoints) {
                    vector = point - arc.CenterPoint;
                    leftPoint = arc.GetPointOnDirection(new Vector(rotationMatrix.Transform(vector)));
                    rightPoint = arc.GetPointOnDirection(new Vector(rotationMatrix.GetTranspose().Transform(vector)));

                    points.AddRange(arc.GetPoints(leftPoint, rightPoint, angle));
                }

                disList.Clear();
                foreach (var point in points) {
                    disList.Add(Distance.PointToLine(point, line));
                }

                minExtremeIndexs = CommonOperation.GetLocalExtremeIndexes(disList, CommonOperation.ExtremeTypeEnum.LocalMinimum);
                minExtremePoints.Clear();
                foreach (var index in minExtremeIndexs) {
                    minExtremePoints.Add(points[index]);
                }
                tmpList = Enumerable.Distinct(minExtremePoints, comparer).ToList();//  剔除重复值
                minExtremePoints.Clear();
                minExtremePoints.AddRange(tmpList);
            }

            segList = new List<LineSegment>();
            foreach (var point in minExtremePoints) {
                segList.Add(new LineSegment(point, Projection.PointToLine(point, line)));
            }

            var cnt = segList.Count;
            double minLength = double.MaxValue;
            for (int i = 0; i < cnt; i++) {
                if (segList[i].Length() < minLength) {
                    minLength = segList[i].Length();
                }
            }
            minLength += epsilon;//  容许误差
            for (int i = 0; i < cnt; i++) {
                if (segList[i].Length() > minLength) {
                    segList.RemoveAt(i);
                    i--; cnt--;
                }
            }

            return segList;
        }
        /// <summary>
        /// 圆与直线间最短线段的集合。
        /// </summary>
        /// <param name="circle">给定的圆（弧），不是整圆依然当成整圆处理。</param>
        /// <param name="line">给定的直线。</param>
        /// <param name="samplingIntervalAtStart">用于情形4.2下调用关联方法时输入的参数，详情参见 <see cref="ArcToLine(Arc, Line, double, double)"/> 。</param>
        /// <param name="epsilon">
        ///     容许误差，小于此差异的距离值当作相等处理。默认值为
        ///     <see cref="GeometryConstants.DISTANCE_EPSILON"/> 。
        /// </param>
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
        ///             <item>与穿过的圆直径所在直线垂直：直线与圆平面交点在圆内时，有两个解；在圆上或圆外时，有一个解。
        ///                 <para>此情形下最优解可通过求以下方程最小值时的 α 得到：</para>
        ///                     <code>y = ((d*tan(α)/tan(θ))^2 + (r-d/cos(α))^2)^0.5</code>
        ///                     <code>y - 圆上取点到直线的距离, y >= 0</code>
        ///                     <code>r - 圆半径, r > 0</code>
        ///                     <code>d - 圆心到直线的距离, 0 &lt;= d &lt;= r</code>
        ///                     <code>θ - 直线方向与圆平面法向的夹角, 0 &lt; θ &lt; 0.5π</code>
        ///                     <code>α - 圆上取点与圆心的连线 和 直线与圆平面的交点与圆心的连线之间的夹角, 0 &lt; α &lt; 0.5π</code>
        ///                 <b>* 上述方程不会解，暂时调用采样方法实现</b>，参见 <see cref="ArcToLine(Arc, Line, double, double)"/> 。
        ///             </item>
        ///             <item>与穿过的圆直径所在直线不垂直：只有一个解。
        ///                 <para><b>* 此情形下是通过取样逼近最小值的方法实现。</b>
        ///                 参见 <see cref="ArcToLine(Arc, Line, double, double)"/> 。</para>
        ///             </item>
        ///         </list>
        ///     </item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="line"/>.Direction 不应为零向量。</exception>
        public static List<LineSegment> CircleToLine(
            Arc circle,
            Line line,
            double samplingIntervalAtStart = 0,
            double epsilon = GeometryConstants.DISTANCE_EPSILON) {

            if (circle is null) {
                throw new ArgumentNullException(nameof(circle));
            }

            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            if (line.Direction.IsZero())
                throw new ArgumentException($"“{nameof(line)}”.Direction 不应为零向量。");

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
            var lineProjected = Projection.LineToPlane(line, gPlane);
            var disCenterToLineProjected = Distance.PointToLine(cFull.CenterPoint, lineProjected);

            var angleLineWithNormal = line.Direction.GetAngleBetween(cFull.Normal);
            if (angleLineWithNormal == 0) {
                //  情形2.1：直线垂直于圆平面，穿过圆中心点
                if (Distance.PointToLine(cFull.CenterPoint, line) == 0) return null;

                //  情形2.2：直线垂直于圆平面，不穿过圆中心点
                var p1 = new Point(cFull.CenterPoint);
                var p2 = Projection.PointToLine(p1, line);
                var v = new Vector(p2 - p1);
                p1 = cFull.GetPointOnDirection(v);
                seg = new LineSegment(p1, p2);
                segList.Add(seg);
            } else if (angleLineWithNormal == Math.PI * 0.5) {

                var p1 = new Point(cFull.CenterPoint);
                var p2 = Projection.PointToLine(p1, line);
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
                    p2 = Projection.PointToLine(p1, line);
                    seg = new LineSegment(p1, p2);
                    segList.Add(seg);

                    rotationMatrix = MatrixFactory.Rotate(-2 * angle, cFull.Normal);
                    v = new Vector(rotationMatrix.Transform(v));
                    p1 = cFull.GetPointOnDirection(v);
                    p2 = Projection.PointToLine(p1, line);
                    seg = new LineSegment(p1, p2);
                    segList.Add(seg);
                }
            } else {
                var pointLineIntersectPlane = Intersection.LineToLine(line, lineProjected).StartPoint;
                var vDiameter = new Vector(pointLineIntersectPlane - cFull.CenterPoint);

                var angleDiameterWithLine = vDiameter.GetAngleBetween(line.Direction);
                if (angleDiameterWithLine == Math.PI * 0.5) {
                    //  情形4.1：直线既不垂直也不平行于圆平面，与穿过的圆直径所在直线垂直

                    /*
                        //  ==========此段代码不正确，不是最优解==========
                     
                        //  边界条件 d == r * (1 - cos(θ)^2) / (1 + cos(θ)^2)
                        var disBoundary = cFull.Radius * (1 - Math.Pow(Math.Cos(angleLineWithNormal), 2))
                                                        / (1 + Math.Pow(Math.Cos(angleLineWithNormal), 2));
                        var disCenterToIntersection = vDiameter.GetLength();
                        if (disCenterToIntersection <= disBoundary) {
                            var angle = Math.Acos(disCenterToIntersection / cFull.Radius);
                            var rotationMatrix = MatrixFactory.Rotate(angle, cFull.Normal);
                            var v = new Vector(rotationMatrix.Transform(vDiameter));
                            var p1 = cFull.GetPointOnDirection(v);
                            var p2 = Projection.PointToLine(p1, line);
                            seg = new LineSegment(p1, p2);
                            segList.Add(seg);
                     
                            rotationMatrix = MatrixFactory.Rotate(-angle, cFull.Normal);
                            v = new Vector(rotationMatrix.Transform(vDiameter));
                            p1 = cFull.GetPointOnDirection(v);
                            p2 = Projection.PointToLine(p1, line);
                            seg = new LineSegment(p1, p2);
                            segList.Add(seg);
                        }
                        if (disCenterToIntersection >= disBoundary) {
                            var p3 = cFull.GetPointOnDirection(vDiameter);
                            seg = new LineSegment(p3, pointLineIntersectPlane);
                            segList.Add(seg);
                        }
                    */

                    //  代数计算法待研究，暂时调用采样方法来实现
                    var arc = new Arc(circle.CenterPoint, circle.StartPoint, circle.Normal, 2 * Math.PI);
                    segList = ArcToLine(arc, line, samplingIntervalAtStart, epsilon);
                } else {
                    //  情形4.2：直线既不垂直也不平行于圆平面，与穿过的圆直径所在直线不垂直
                    var arc = new Arc(circle.CenterPoint, circle.StartPoint, circle.Normal, 2 * Math.PI);
                    segList = ArcToLine(arc, line, samplingIntervalAtStart, epsilon);
                }
            }

            return segList;
        }
        /// <summary>
        /// 圆与直线的交点。适用于二维平面。
        /// </summary>
        /// <param name="centerPoint">圆的中心点</param>
        /// <param name="radius">圆的半径</param>
        /// <param name="line">给定的直线</param>
        /// <param name="epsilon">容许误差，小于此误差判定为相切</param>
        /// <returns>
        ///     圆与直线的交点组成的元组，其中元素 X1, X2 的顺序符合顺直线方向。
        ///     圆与直线相切时，元素相等；圆与直线既不相交也不相切时，元素为 null。
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static (Point X1, Point X2) CircleToLine_2D(
            Point centerPoint,
            double radius,
            Line line,
            double epsilon = 1e-10) {

            if (centerPoint is null) {
                throw new ArgumentNullException(nameof(centerPoint));
            }

            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            var d = Distance.PointToLine(centerPoint, line);
            if (d - radius > epsilon) return (null, null);
            if (d > radius) d = radius;

            var X2 = Projection.PointToLine(centerPoint, line);
            var X1 = new Point(X2);

            var t = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(d, 2));
            var v = new Vector(line.Direction);
            v.Normalize(t);
            X2.Translate(v);
            X1.Translate(-1 * v);

            return (X1, X2);
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Projection"/> 的扩展。
    /// </summary>
    public static class ProjectionExtension {
        /// <summary>
        /// 获取向量在平面上投影的向量。根据以下公式计算：<code>P = V - (V∙N / ||N||^2) * N</code>
        /// </summary>
        /// <param name="vector">要投影的向量</param>
        /// <param name="gPlane">要投影的平面</param>
        /// <returns>投影的向量。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Vector VectorToPlane(Vector vector, GeometricPlane gPlane) {
            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

            if (gPlane is null) {
                throw new ArgumentNullException(nameof(gPlane));
            }

            // GeometricPlane.Normal 不可能是零向量，不需要验证
            return new Vector(vector - Vector.Dot(vector, gPlane.Normal) / Math.Pow(gPlane.Normal.GetLength(), 2) * gPlane.Normal);
        }
    }
    /// <summary>
    /// 点的取值区间（闭区间，不支持开区间）。
    /// <para>
    ///     虽然可以直接用 [StartPoint, EndPoint] 来表示点区间，但实际应用中可能存在精度问题。
    ///     本实现旨在提供一种解决方案，规避这种误差，因此在本类内部，不采用容许误差的设计。
    /// </para>
    /// <para>
    ///     具体方案为：
    ///     使用原点 Origin 和<b>单位向量</b> Direction 建立数轴，用实数 Start 和 End 来表示区间。
    ///     将点转化成在此数轴上对应的实数（用与原点之间带有方向的距离表示，也即 Direction 的倍数）。
    ///     在具体问题中，使用实数来讨论，得出结论后，再将实数转换成点。
    /// </para>
    /// <para>
    ///     同时本类还实现了枚举，在枚举前应先设置枚举间隔 EnumInterval 。
    /// </para>
    /// </summary>
    public class PointsInterval : IEnumerable, IEnumerator<Point> {
        private readonly Point _origin = new Point();
        private readonly Vector _direction = new Vector(1, 0, 0);
        private double _start = 0;
        private double _end = 0;
        private double _enumInterval = GeometryConstants.DISTANCE_EPSILON;
        private int _position = -1;
        /// <summary>
        /// 数轴的原点，默认为零点。
        /// </summary>
        public Point Origin {
            get => _origin;
            set => _origin.Copy(value);
        }
        /// <summary>
        /// 数轴的方向，默认为单位X向量。不接受零向量（赋值为零向量时不处理）。自动设置成单位向量。
        /// </summary>
        public Vector Direction {
            get => _direction;
            set {
                //  不接受零向量
                if (!value.IsZero()) {
                    _direction.Copy(value);
                    _direction.Normalize();
                }
            }
        }
        /// <summary>
        /// 区间起点值。将始终保持 Start &lt;= End，若赋值大于 End，则自动将 End 设置为等于 Start。
        /// </summary>
        public double Start {
            get => _start;
            set {
                _start = value;
                if (_start > _end) _end = _start;
            }
        }
        /// <summary>
        /// 区间终点值。将始终保持 Start &lt;= End，若赋值小于 Start，则自动将 Start 设置为等于 End。
        /// </summary>
        public double End {
            get => _end;
            set {
                _end = value;
                if (_start > _end) _start = _end;
            }
        }
        /// <summary>
        /// 区间的宽度。
        /// </summary>
        /// <returns>区间的宽度。</returns>
        public double Width => _end - _start;
        /// <summary>
        /// 区间起点。
        /// </summary>
        public Point StartPoint => _origin + _start * _direction;
        /// <summary>
        /// 区间终点。
        /// </summary>
        public Point EndPoint => _origin + _end * _direction;
        /// <summary>
        /// 枚举间隔。
        /// </summary>
        public double EnumInterval {
            get => _enumInterval;
            set {
                if (value >= 0) _enumInterval = value;
            }
        }

        public Point Current => GetPoint(_start + _position * _enumInterval);

        object IEnumerator.Current => Current;
        /// <summary>
        /// 使用默认值构造点区间，Origin 为零点，Direction 为单位X向量，Start 和 End 均为0。
        /// </summary>
        public PointsInterval() { }
        /// <summary>
        /// 使用给定属性值构造点区间。
        /// </summary>
        /// <param name="origin">原点</param>
        /// <param name="direction">方向</param>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PointsInterval(Point origin, Vector direction, double start, double end) {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Direction = direction ?? throw new ArgumentNullException(nameof(direction));
            Start = start;
            End = end;
        }
        /// <summary>
        /// 用一条直线构造点区间，起点、终点分别为负无穷和正无穷。
        /// </summary>
        /// <param name="line">给定直线</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="line"/>.Direction 不应为零向量。</exception>
        public PointsInterval(Line line) {
            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }
            if (line.Direction.IsZero())
                throw new ArgumentException($"“{nameof(line)}”.Direction 不应为零向量。");

            Origin = line.Origin;
            Direction = line.Direction;
            Start = double.NegativeInfinity;
            End = double.PositiveInfinity;
        }
        /// <summary>
        /// 用一条线段构造点区间，起点值为0，终点值为线段长度。
        /// </summary>
        /// <param name="lineSegment">给定线段</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="lineSegment"/>的长度不应等于0.0。</exception>
        public PointsInterval(LineSegment lineSegment) {
            if (lineSegment is null) {
                throw new ArgumentNullException(nameof(lineSegment));
            }

            Direction = lineSegment.GetDirectionVector();
            if (Direction.IsZero())
                throw new ArgumentException($"“{nameof(lineSegment)}”长度不应等于0.0。");

            Origin = lineSegment.StartPoint;
            End = lineSegment.Length();
        }
        /// <summary>
        /// 使用给定点区间构造新实例。
        /// </summary>
        /// <param name="itvl">给定点区间</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PointsInterval(PointsInterval itvl) {
            if (itvl is null) {
                throw new ArgumentNullException(nameof(itvl));
            }
            Origin = itvl.Origin;
            Direction = itvl.Direction;
            Start = itvl.Start;
            End = itvl.End;
        }
        /// <summary>
        /// 获取当前点区间的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串</param>
        /// <returns>当前点区间的字符串表示形式。</returns>
        public string ToString(string format = default) {
            return $"Origin = {_origin.ToString(format)},\n" +
                $"Direction = {_direction.ToString(format)},\n" +
                $"Start = {_start.ToString(format)}, StartPoint = {StartPoint.ToString(format)},\n" +
                $"End = {_end.ToString(format)}, EndPoint = {EndPoint.ToString(format)}\n";
        }
        /// <summary>
        /// 判断区间是否包含给定点。
        /// </summary>
        /// <param name="point">给定点</param>
        /// <param name="entireLine">是否用整个实数轴判断，默认 false。</param>
        /// <returns>包含返回 true，不包含返回 false。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Obsolete("由于计算精度问题，可能不能得出正确结果，谨慎使用。" +
            "应优先转换思路，使用“PointsInterval.Contains(double value)”方法。", false)]
        public bool Contains(Point point, bool entireLine = false) {
            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            var value = GetValue(point);

            if (double.IsNaN(value) || !entireLine && (value < Start || value > End))
                return false;

            return true;
        }
        /// <summary>
        /// 判断区间是否包含给定实数。
        /// </summary>
        /// <param name="value">给定实数。</param>
        /// <returns>包含返回 true，不包含返回 false。</returns>
        public bool Contains(double value) {
            if (double.IsNaN(value) || value < Start || value > End) return false;
            return true;
        }
        /// <summary>
        /// 获取给定点在整个数轴上对应的实数值。
        /// </summary>
        /// <param name="point">给定点</param>
        /// <returns>给定点在整个数轴上对应的实数值。如果不在数轴上，则返回 <see cref="double.NaN"/>。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Obsolete("由于计算精度问题，可能不能得出正确结果，谨慎使用。" +
            "应优先转换思路，使用“PointsInterval.GetPoint(double value)”方法。", false)]
        public double GetValue(Point point) {
            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }
            if (double.IsNaN(point.X) || double.IsNaN(point.Y) || double.IsNaN(point.Z))
                return double.NaN;

            var vector = new Vector(point - Origin);
            if (vector.IsZero()) return 0;

            //  不共线
            if (!Vector.Cross(vector, Direction).IsZero()) return double.NaN;

            //  完整表达式应该是 Vector.Dot(vector, Direction) / Vector.Dot(Direction, Direction)
            //  由于 Direction 是单位向量，其自身的点积必定等于1，所以除数可以简化掉
            return Vector.Dot(vector, Direction);
        }
        /// <summary>
        /// 获取给定实数值在整个数轴上对应的点。
        /// </summary>
        /// <param name="value">给定实数值</param>
        /// <returns>实数值对应的点。</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> 应当是有效数值，不应是 <see cref="double.NaN"/>。</exception>
        public Point GetPoint(double value) {
            if (double.IsNaN(value)) {
                throw new ArgumentException($"“{nameof(value)} = NaN”，不是有效数值。");
            }

            return Origin + value * Direction;
        }
        /// <summary>
        /// 获取<b>区间内</b>给定实数值左右各数个连续间距的值的集合。
        /// </summary>
        /// <param name="value">给定实数值。</param>
        /// <param name="dis">要获取的连续值之间的间距，正数。</param>
        /// <param name="num">左右各指定数量个值，正整数。</param>
        /// <returns>区间内给定实数值左右各数个连续间距的值的集合。</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/>不在区间内。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dis"/>不应&lt;=0，<paramref name="num"/>不应&lt;=0。</exception>
        public IEnumerable<double> GetValuesArround(double value, double dis, int num) {
            if (double.IsNaN(value) || value < _start || value > _end) {
                var msg = ToString(null);
                msg = msg.Replace("\n", " ");
                msg = msg.Remove(msg.Length - 1, 1);
                throw new ArgumentException($"“{nameof(value)} = {value}”不在区间“{msg}”内。");
            }
            if (dis <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(dis)} = {dis}”不应小于等于0.0。");
            }
            if (num <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(num)} = {num}”不应小于等于0。");
            }


            var num_Left = (value - num * dis) > _start ? num : (int) ((value - _start) / dis);
            var num_Right = (value + num * dis) < _end ? num : (int) ((_end - value) / dis);
            value -= dis * num_Left;
            var values = new double[num_Left + num_Right + 1];
            for (int i = 0; i <= num_Left + num_Right; i++) {
                values[i] = value + i * dis;
            }

            return values;
        }
        /// <summary>
        /// 获取<b>区间内</b>给定点左右各数个连续间距的点的集合。
        /// </summary>
        /// <param name="point">区间内给定点。</param>
        /// <param name="dis">要获取的连续点之间的间距，正数。</param>
        /// <param name="num">左右各指定数量个点，正整数。</param>
        /// <returns>区间内给定点左右各数个连续间距的点的集合。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="point"/>不在区间内。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dis"/>不应&lt;=0，<paramref name="num"/>不应&lt;=0。</exception>
        [Obsolete("由于计算精度问题，可能出现误判参数“point”不在区间内，谨慎使用。" +
            "应优先转换思路，使用“PointsInterval.GetPointsArround(double value, double dis, int num)”方法。", false)]
        public IEnumerable<Point> GetPointsArround(Point point, double dis, int num) {
            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            var value = GetValue(point);
            if (double.IsNaN(value) || value < _start || value > _end) {
                var msg = ToString(null);
                msg = msg.Replace("\n", " ");
                msg = msg.Remove(msg.Length - 1, 1);
                throw new ArgumentException($"“{nameof(point)} = {point.ToString(null)}”不在区间“{msg}”内。");
            }
            if (dis <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(dis)} = {dis}”不应小于等于0.0。");
            }
            if (num <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(num)} = {num}”不应小于等于0。");
            }

            return GetPointsArround(value, dis, num);
        }
        /// <summary>
        /// 获取<b>区间内</b>给定实数值对应的点左右各数个连续间距的点的集合。
        /// </summary>
        /// <param name="value">给定实数值。</param>
        /// <param name="dis">要获取的连续点之间的间距，正数。</param>
        /// <param name="num">左右各指定数量个点，正整数。</param>
        /// <returns>区间内给定实数值对应的点左右各数个连续间距的点的集合。</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/>不在区间内。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dis"/>不应&lt;=0，<paramref name="num"/>不应&lt;=0。</exception>
        public IEnumerable<Point> GetPointsArround(double value, double dis, int num) {
            if (double.IsNaN(value) || value < _start || value > _end) {
                var msg = ToString(null);
                msg = msg.Replace("\n", " ");
                msg = msg.Remove(msg.Length - 1, 1);
                throw new ArgumentException($"“{nameof(value)} = {value}”不在区间“{msg}”内。");
            }
            if (dis <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(dis)} = {dis}”不应小于等于0.0。");
            }
            if (num <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(num)} = {num}”不应小于等于0。");
            }


            var num_Left = (value - num * dis) > _start ? num : (int) ((value - _start) / dis);
            var num_Right = (value + num * dis) < _end ? num : (int) ((_end - value) / dis);
            value -= dis * num_Left;
            var points = new Point[num_Left + num_Right + 1];
            for (int i = 0; i <= num_Left + num_Right; i++) {
                points[i] = GetPoint(value + i * dis);
            }

            return points;
        }
        /// <summary>
        /// 用当前点区间的原点和方向变换给定点区间。
        /// </summary>
        /// <param name="itvl">给定点区间</param>
        /// <returns>
        ///     如果给定点区间与当前点区间在同一数轴上，则返回true，同时变换给定点区间；
        ///     否则返回false，不处理给定点区间。
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Obsolete]
        public bool Transform(PointsInterval itvl) {
            if (itvl is null) {
                throw new ArgumentNullException(nameof(itvl));
            }

            //  不平行
            if (!Vector.Cross(Direction, itvl.Direction).IsZero()) return false;
            //  平行但不共线
            if (!Contains(itvl.Origin, true)) return false;

            var startPoint = itvl.GetPoint(itvl.Start);
            var endPoint = itvl.GetPoint(itvl.End);

            var start = GetValue(startPoint);
            var end = GetValue(endPoint);
            if (start > end) (start, end) = (end, start);

            itvl.Origin = Origin;
            itvl.Direction = Direction;
            itvl.Start = start;
            itvl.End = end;

            return true;
        }
        /// <summary>
        /// 获取当前点区间与给定点区间的交集。交集原点和方向与当前点区间相同。
        /// </summary>
        /// <param name="itvl">给定点区间</param>
        /// <returns>当前点区间与给定点区间的交集。不存在交集则返回 null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public PointsInterval Intersect(PointsInterval itvl) {
            if (itvl is null) {
                throw new ArgumentNullException(nameof(itvl));
            }

            return Intersect(this, itvl);
        }
        /// <summary>
        /// 获取两个给定点区间的交集，其原点和方向与 <paramref name="itvl1"/> 相同。
        /// </summary>
        /// <param name="itvl1">给定点区间1</param>
        /// <param name="itvl2">给定点区间2</param>
        /// <returns>两个给定点区间的交集。不存在交集则返回 null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static PointsInterval Intersect(PointsInterval itvl1, PointsInterval itvl2) {
            if (itvl1 is null) {
                throw new ArgumentNullException(nameof(itvl1));
            }
            if (itvl2 is null) {
                throw new ArgumentNullException(nameof(itvl2));
            }

            var normal = Vector.Cross(itvl1.Direction, itvl2.Direction);
            if (normal.IsZero()) {
                //  平行

                //  不共线
#pragma warning disable CS0618 // 类型或成员已过时
                if (!itvl1.Contains(itvl2.Origin, true)) return null;
#pragma warning restore CS0618 // 类型或成员已过时

                //  共线
                var p1 = itvl2.GetPoint(itvl2.Start);
                var p2 = itvl2.GetPoint(itvl2.End);
#pragma warning disable CS0618 // 类型或成员已过时
                var v1 = itvl1.GetValue(p1);
                var v2 = itvl1.GetValue(p2);
#pragma warning restore CS0618 // 类型或成员已过时
                if (v1 > v2) (v1, v2) = (v2, v1);

                if (v1 > itvl1.End || v2 < itvl1.Start) return null;

                return new PointsInterval(itvl1.Origin, itvl1.Direction,
                    itvl1.Start > v1 ? itvl1.Start : v1,
                    itvl1.End < v2 ? itvl1.End : v2);
            } else {
                //  不平行，转变成求两条直线交点的问题

                var vector = new Vector(itvl2.Origin - itvl1.Origin);
                //  交点就是原点
                if (vector.IsZero()) return new PointsInterval(itvl1.Origin, itvl1.Direction, 0, 0);

                var dot = Vector.Dot(vector, normal);
                //  不相交
                if (dot != 0) return null;

                //  公式 s = ((P2 - P1)×V2)∙(V1×V2)/|| V1×V2 || ^2
                //  参见IntersectionExtension.LineToLine注释
                var value = Vector.Dot(Vector.Cross(vector, itvl2.Direction), normal) / Math.Pow(normal.GetLength(), 2);
                return new PointsInterval(itvl1.Origin, itvl1.Direction, value, value);
            }
        }
        public IEnumerator<Point> GetEnumerator() {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this;
        }

        public void Dispose() { }

        public bool MoveNext() {
            _position++;
            return _position * _enumInterval <= Width;
        }

        public void Reset() {
            _position = -1;
        }
    }
    /// <summary>
    /// 三维几何操作相关功能
    /// </summary>
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
        /// <returns>镜像后的点。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Point Mirror(Point point, GeometricPlane byPlane) {
            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            if (byPlane is null) {
                throw new ArgumentNullException(nameof(byPlane));
            }

            var p = Projection.PointToPlane(point, byPlane);
            var v = new Vector(p - point);
            p.Translate(v);

            return p;
        }
        /// <summary>
        /// 对轮廓点进行镜像。
        /// </summary>
        /// <param name="contourPoint">要镜像的轮廓点</param>
        /// <param name="byPlane">镜像平面</param>
        /// <returns>镜像后的轮廓点。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContourPoint Mirror(ContourPoint contourPoint, GeometricPlane byPlane) {
            if (contourPoint is null) {
                throw new ArgumentNullException(nameof(contourPoint));
            }

            if (byPlane is null) {
                throw new ArgumentNullException(nameof(byPlane));
            }

            var point = new Point(contourPoint.X, contourPoint.Y, contourPoint.Z);
            point = Mirror(point, byPlane);

            return new ContourPoint(point, contourPoint.Chamfer);
        }
        /// <summary>
        /// 对 ContourPoints 进行镜像。
        /// </summary>
        /// <param name="contourPoints">要镜像的ContourPoints</param>
        /// <param name="byPlane">镜像平面</param>
        /// <returns>镜像后的ContourPoints</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ArrayList Mirror(ArrayList contourPoints, GeometricPlane byPlane) {
            if (contourPoints is null) {
                throw new ArgumentNullException(nameof(contourPoints));
            }

            if (byPlane is null) {
                throw new ArgumentNullException(nameof(byPlane));
            }

            ArrayList arrayList;
            try {
                arrayList = new ArrayList();
                foreach (ContourPoint cp in contourPoints) {
                    arrayList.Add(Mirror(cp, byPlane));
                }
            } catch {
                arrayList = null;
            }

            return arrayList;
        }
        /// <summary>
        /// 在平面上，有一个固定形状的三角形（位置不固定）和三条已知直线（位置固定）。求当三角形三个顶点分别落三条直线上时的位置（即三个顶点值）。
        /// <para><b>* 本方法仅处理二维平面情形。</b></para>
        /// <para>作如下约定：</para>
        /// <list type="bullet">
        ///     <item>
        ///         三条直线分别为 <paramref name="lines"/>.L1, <paramref name="lines"/>L2, <paramref name="lines"/>L3。
        ///     </item>
        ///     <item>  
        ///         三角形三条边分别为 <paramref name="edges"/>.E1, <paramref name="edges"/>.E2, <paramref name="edges"/>.E3。
        ///     </item>
        ///     <item>
        ///         <para>三角形三个顶点分别为 P1, P2, P3, 分别落在 L1, L2, L3上。</para>
        ///         <para>E1 = [P1, P3], E2 = [P2, P3], E3 = [P1, P2]</para>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="lines">给定的三条直线</param>
        /// <param name="edges">给定的三角形三条边</param>
        /// <param name="samplingSpacingAtStart">
        ///     初始采样间隔长度。
        ///     输入正值以指定初始采样间隔，或输入非正值由方法自动确定一个适当的值。
        ///     默认值0。
        /// </param>
        /// <param name="epsilon">
        ///     容许误差，小于此差异的距离值当作相等处理。默认值为
        ///     <see cref="GeometryConstants.DISTANCE_EPSILON"/> 。
        /// </param>
        /// <returns>符合要求的三角形三个顶点的集合。无解则返回 null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="lines"/>的元素的Direction属性为零向量或不在同一个平面上，
        ///     或<paramref name="edges"/>的元素不构成三角形。
        /// </exception>
        public static List<(Point P1, Point P2, Point P3)> PositionOfTriangleOnLines(
            (Line L1, Line L2, Line L3) lines,
            (double E1, double E2, double E3) edges,
            double samplingSpacingAtStart = 0,
            double epsilon = GeometryConstants.DISTANCE_EPSILON) {

            var l1 = lines.L1; var l2 = lines.L2; var l3 = lines.L3;
            var e1 = edges.E1; var e2 = edges.E2; var e3 = edges.E3;

            #region 验证数据有效性
            if (l1 is null) {
                throw new ArgumentNullException($"{nameof(lines)}.{nameof(lines.L1)}");
            }
            if (l2 is null) {
                throw new ArgumentNullException($"{nameof(lines)}.{nameof(lines.L2)}");
            }
            if (l3 is null) {
                throw new ArgumentNullException($"{nameof(lines)}.{nameof(lines.L3)}");
            }
            if (l1.Direction.IsZero()) {
                throw new ArgumentException(
                    $"“{nameof(lines)}”的元素" +
                    $"“L1 = {{" +
                    $"Origin = {l1.Origin.ToString(null)}, " +
                    $"Direction = {l1.Direction.ToString(null)} }}”" +
                    $"的Direction属性不应为零向量。");
            }
            if (l2.Direction.IsZero()) {
                throw new ArgumentException(
                    $"“{nameof(lines)}”的元素" +
                    $"“L2 = {{" +
                    $"Origin = {l2.Origin.ToString(null)}, " +
                    $"Direction = {l2.Direction.ToString(null)} }}”" +
                    $"的Direction属性不应为零向量。");
            }
            if (l3.Direction.IsZero()) {
                throw new ArgumentException(
                    $"“{nameof(lines)}”的元素" +
                    $"“L3 = {{" +
                    $"Origin = {l3.Origin.ToString(null)}, " +
                    $"Direction = {l3.Direction.ToString(null)} }}”" +
                    $"的Direction属性不应为零向量。");
            }

            //不构成三角形
            if (e1 <= 0 || e2 <= 0 || e3 <= 0) {
                throw new ArgumentException($"“{nameof(edges)}”的元素" +
                    $"E1 = “{e1}, E2 = {e2}, E3 = {e3}”不应小于等于0.0。");
            }
            if ((e1 + e2) <= e3 || (e1 + e3) <= e2 || (e2 + e3) <= e1) {
                throw new ArgumentException($"“{nameof(edges)}”的元素" +
                    $"E1 = “{e1}, E2 = {e2}, E3 = {e3}”不构成三角形。");
            }

            //任意一对不共面 或 均共线
            var sign12 = GeometricPlaneFactory.ByLines(l1, l2, out GeometricPlane gPlane12);
            var sign13 = GeometricPlaneFactory.ByLines(l1, l3, out GeometricPlane gPlane13);
            var sign23 = GeometricPlaneFactory.ByLines(l2, l3, out _);
            if (sign12 == 0 || sign13 == 0 || sign23 == 0 || sign12 + sign13 + sign23 == -3) {
                throw new ArgumentException($"“{nameof(lines)}”的元素不在同一个平面上。");
            }

            //共同平面法向
            //只可能有一对线共线，不需要判断两次
            var normal = sign12 == 1 ? gPlane12.Normal : gPlane13.Normal;
            #endregion

            #region 求p1, p2, p3取值范围，并验证是否有解
            var itvlP1 = new PointsInterval(l1);
            var itvlP1_e1_left = new PointsInterval(itvlP1);
            var itvlP1_e1_right = new PointsInterval(itvlP1);
            var itvlP1_e3_left = new PointsInterval(itvlP1);
            var itvlP1_e3_right = new PointsInterval(itvlP1);
            var itvlP2 = new PointsInterval(l2);
            var itvlP2_e2_left = new PointsInterval(itvlP2);
            var itvlP2_e2_right = new PointsInterval(itvlP2);
            var itvlP2_e3_left = new PointsInterval(itvlP2);
            var itvlP2_e3_right = new PointsInterval(itvlP2);
            var itvlP3 = new PointsInterval(l3);
            var itvlP3_e1_left = new PointsInterval(itvlP3);
            var itvlP3_e1_right = new PointsInterval(itvlP3);
            var itvlP3_e2_left = new PointsInterval(itvlP3);
            var itvlP3_e2_right = new PointsInterval(itvlP3);

            var transVector = Vector.Cross(normal, itvlP1.Direction);
            transVector.Normalize(e1);
            itvlP1_e1_left.Origin += transVector;
            itvlP1_e1_right.Origin -= transVector;
            transVector.Normalize(e3);
            itvlP1_e3_left.Origin += transVector;
            itvlP1_e3_right.Origin -= transVector;

            transVector = Vector.Cross(normal, itvlP2.Direction);
            transVector.Normalize(e2);
            itvlP2_e2_left.Origin += transVector;
            itvlP2_e2_right.Origin -= transVector;
            transVector.Normalize(e3);
            itvlP2_e3_left.Origin += transVector;
            itvlP2_e3_right.Origin -= transVector;

            transVector = Vector.Cross(normal, itvlP3.Direction);
            transVector.Normalize(e1);
            itvlP3_e1_left.Origin += transVector;
            itvlP3_e1_right.Origin -= transVector;
            transVector.Normalize(e2);
            itvlP3_e2_left.Origin += transVector;
            itvlP3_e2_right.Origin -= transVector;

            double value1, value2, value3, value4;
            //  P1取值范围
            if (sign12 == -1) {
                value1 = double.NegativeInfinity;
                value2 = double.PositiveInfinity;
            } else {
                value1 = itvlP1.Intersect(itvlP2_e3_left).Start;
                value2 = itvlP1.Intersect(itvlP2_e3_right).Start;
                if (value1 > value2) (value1, value2) = (value2, value1);
            }
            if (sign13 == -1) {
                value3 = double.NegativeInfinity;
                value4 = double.PositiveInfinity;
            } else {
                value3 = itvlP1.Intersect(itvlP3_e1_left).Start;
                value4 = itvlP1.Intersect(itvlP3_e1_right).Start;
                if (value3 > value4) (value3, value4) = (value4, value3);
            }
            if (value1 > value4 || value2 < value3) return null;

            //  P2取值范围
            if (sign12 == -1) {
                value1 = double.NegativeInfinity;
                value2 = double.PositiveInfinity;
            } else {
                value1 = itvlP2.Intersect(itvlP1_e3_left).Start;
                value2 = itvlP2.Intersect(itvlP1_e3_right).Start;
                if (value1 > value2) (value1, value2) = (value2, value1);
            }
            if (sign23 == -1) {
                value3 = double.NegativeInfinity;
                value4 = double.PositiveInfinity;
            } else {
                value3 = itvlP2.Intersect(itvlP3_e2_left).Start;
                value4 = itvlP2.Intersect(itvlP3_e2_right).Start;
                if (value3 > value4) (value3, value4) = (value4, value3);
            }
            if (value1 > value4 || value2 < value3) return null;

            //  P3取值范围
            if (sign13 == -1) {
                value1 = double.NegativeInfinity;
                value2 = double.PositiveInfinity;
            } else {
                value1 = itvlP3.Intersect(itvlP1_e1_left).Start;
                value2 = itvlP3.Intersect(itvlP1_e1_right).Start;
                if (value1 > value2) (value1, value2) = (value2, value1);
            }
            if (sign23 == -1) {
                value3 = double.NegativeInfinity;
                value4 = double.PositiveInfinity;
            } else {
                value3 = itvlP3.Intersect(itvlP2_e2_left).Start;
                value4 = itvlP3.Intersect(itvlP2_e2_right).Start;
                if (value3 > value4) (value3, value4) = (value4, value3);
            }
            if (value1 > value4 || value2 < value3) return null;
            itvlP3.Start = value1 < value3 ? value3 : value1;
            itvlP3.End = value2 < value4 ? value2 : value4;

            #endregion

            #region 确定一个适当的初始采样间距
            if (samplingSpacingAtStart <= 0) {
                samplingSpacingAtStart = new double[] { itvlP3.Width, e1, e2, e3, 100 }.Min() * 0.01;
            }
            if (samplingSpacingAtStart < epsilon)
                samplingSpacingAtStart = epsilon;
            #endregion

            var spacing = samplingSpacingAtStart; //  循环体内使用的采样间距

            //  半径e1的圆与l1的交点，半径e2的圆与l2的交点
            //  已对取值区间判断过，X1、X2必定不等于null
            (Point X1, Point X2) intersection_l1, intersection_l2;
            Point x1 = null, x2 = null, point; //  循环体内使用的引用
            List<double>
                disList11 = new List<double>(), //  itst1.X1 <-> itst2.X1
                disList12 = new List<double>(), //  itst1.X1 <-> itst2.X2
                disList21 = new List<double>(), //  itst1.X2 <-> itst2.X1
                disList22 = new List<double>(), //  itst1.X2 <-> itst2.X2
                disList = null; //  循环体内使用的引用
            List<double>
                values_11 = new List<double>(), //  disList11对应的P3_Value集合
                values_12 = new List<double>(), //  disList12对应的P3_Value集合
                values_21 = new List<double>(), //  disList21对应的P3_Value集合
                values_22 = new List<double>(), //  disList22对应的P3_Value集合
                values; //  循环体内使用的引用
            List<double>
                minExtremeValues_11 = new List<double>(), //  disList11对应的极小值P3_Value集合
                minExtremeValues_12 = new List<double>(), //  disList12对应的极小值P3_Value集合
                minExtremeValues_21 = new List<double>(), //  disList21对应的极小值P3_Value集合
                minExtremeValues_22 = new List<double>(), //  disList22对应的极小值P3_Value集合
                minExtremeValues = null; //  循环体内使用的引用
            List<int> minExtremeIndex; //  极小值索引
            List<double> tmpList;

            #region 求初始极小值点集合
            itvlP3.EnumInterval = spacing;
            values = values_11;
            int j = 0;
            foreach (var p in itvlP3) {
                values.Add(itvlP3.Start + j++ * spacing);
                intersection_l1 = IntersectionExtension.CircleToLine_2D(p, e1, l1);
                intersection_l2 = IntersectionExtension.CircleToLine_2D(p, e2, l2);
                for (int i = 0; i < 4; i++) {
                    //  每次循环分别对四个组合求解
                    switch (i) {
                    case 0:
                        disList = disList11;
                        x1 = intersection_l1.X1;
                        x2 = intersection_l2.X1;
                        break;
                    case 1:
                        disList = disList12;
                        x1 = intersection_l1.X1;
                        x2 = intersection_l2.X2;
                        break;
                    case 2:
                        disList = disList21;
                        x1 = intersection_l1.X2;
                        x2 = intersection_l2.X1;
                        break;
                    case 3:
                        disList = disList22;
                        x1 = intersection_l1.X2;
                        x2 = intersection_l2.X2;
                        break;
                    default:
                        break;
                    }
                    disList.Add(Math.Abs(Distance.PointToPoint(x1, x2) - e3)); //  构造一个最小值为e3的集合
                }
            }
            if (itvlP3.Start + --j * spacing < itvlP3.End) {
                values.Add(itvlP3.End);
                var endPoint = itvlP3.GetPoint(itvlP3.End);
                intersection_l1 = IntersectionExtension.CircleToLine_2D(endPoint, e1, l1);
                intersection_l2 = IntersectionExtension.CircleToLine_2D(endPoint, e2, l2);
                disList11.Add(Math.Abs(Distance.PointToPoint(intersection_l1.X1, intersection_l2.X1) - e3));
                disList12.Add(Math.Abs(Distance.PointToPoint(intersection_l1.X1, intersection_l2.X2) - e3));
                disList21.Add(Math.Abs(Distance.PointToPoint(intersection_l1.X2, intersection_l2.X1) - e3));
                disList22.Add(Math.Abs(Distance.PointToPoint(intersection_l1.X2, intersection_l2.X2) - e3));
            }//  避免遗漏区间终点

            for (int i = 0; i < 4; i++) {
                //  每次循环分别对四个组合求解
                switch (i) {
                case 0:
                    disList = disList11;
                    minExtremeValues = minExtremeValues_11;
                    break;
                case 1:
                    disList = disList12;
                    minExtremeValues = minExtremeValues_12;
                    break;
                case 2:
                    disList = disList21;
                    minExtremeValues = minExtremeValues_21;
                    break;
                case 3:
                    disList = disList22;
                    minExtremeValues = minExtremeValues_22;
                    break;
                default:
                    break;
                }

                minExtremeIndex = CommonOperation.GetLocalExtremeIndexes(disList, CommonOperation.ExtremeTypeEnum.LocalMinimum);
                minExtremeValues.Clear();
                foreach (var index in minExtremeIndex) {
                    minExtremeValues.Add(values[index]);
                }
                tmpList = Enumerable.Distinct(minExtremeValues).ToList(); //  剔除重复值
                minExtremeValues.Clear();
                minExtremeValues.AddRange(tmpList);
            }
            #endregion

            #region 迭代求极小值点集合
            while (spacing > epsilon) {

                spacing *= 0.1;//  每步进一次缩小一个数量级

                for (int i = 0; i < 4; i++) {
                    //  每次循环分别对四个组合求解
                    switch (i) {
                    case 0:
                        disList = disList11;
                        values = values_11;
                        minExtremeValues = minExtremeValues_11;
                        break;
                    case 1:
                        disList = disList12;
                        values = values_12;
                        minExtremeValues = minExtremeValues_12;
                        break;
                    case 2:
                        disList = disList21;
                        values = values_21;
                        minExtremeValues = minExtremeValues_21;
                        break;
                    case 3:
                        disList = disList22;
                        values = values_22;
                        minExtremeValues = minExtremeValues_22;
                        break;
                    default:
                        break;
                    }

                    values.Clear();
                    foreach (var value in minExtremeValues) {
                        values.AddRange(itvlP3.GetValuesArround(value, spacing, 10));
                    }
                    tmpList = Enumerable.Distinct(values).ToList(); //  剔除重复值
                    values.Clear();
                    values.AddRange(tmpList);

                    disList.Clear();
                    foreach (var value in values) {
                        point = itvlP3.GetPoint(value);
                        intersection_l1 = IntersectionExtension.CircleToLine_2D(point, e1, l1);
                        intersection_l2 = IntersectionExtension.CircleToLine_2D(point, e2, l2);
                        switch (i) {
                        case 0:
                            x1 = intersection_l1.X1;
                            x2 = intersection_l2.X1;
                            break;
                        case 1:
                            x1 = intersection_l1.X1;
                            x2 = intersection_l2.X2;
                            break;
                        case 2:
                            x1 = intersection_l1.X2;
                            x2 = intersection_l2.X1;
                            break;
                        case 3:
                            x1 = intersection_l1.X2;
                            x2 = intersection_l2.X2;
                            break;
                        default:
                            break;
                        }
                        disList.Add(Math.Abs(Distance.PointToPoint(x1, x2) - e3)); //  构造一个最小值为e3的集合
                    }

                    minExtremeIndex = CommonOperation.GetLocalExtremeIndexes(disList, CommonOperation.ExtremeTypeEnum.LocalMinimum);
                    minExtremeValues.Clear();
                    foreach (var index in minExtremeIndex) {
                        minExtremeValues.Add(values[index]);
                    }
                    tmpList = Enumerable.Distinct(minExtremeValues).ToList(); //  剔除重复值
                    minExtremeValues.Clear();
                    minExtremeValues.AddRange(tmpList);
                }

            }
            #endregion

            #region 最终解
            double dis;
            var resault = new List<(Point P1, Point P2, Point P3)>();
            for (int i = 0; i < 4; i++) {
                switch (i) {
                case 0:
                    minExtremeValues = minExtremeValues_11;
                    break;
                case 1:
                    minExtremeValues = minExtremeValues_12;
                    break;
                case 2:
                    minExtremeValues = minExtremeValues_21;
                    break;
                case 3:
                    minExtremeValues = minExtremeValues_22;
                    break;
                default:
                    break;
                }

                foreach (var value in minExtremeValues) {
                    point = itvlP3.GetPoint(value);
                    intersection_l1 = IntersectionExtension.CircleToLine_2D(point, e1, l1);
                    intersection_l2 = IntersectionExtension.CircleToLine_2D(point, e2, l2);
                    switch (i) {
                    case 0:
                        x1 = intersection_l1.X1;
                        x2 = intersection_l2.X1;
                        break;
                    case 1:
                        x1 = intersection_l1.X1;
                        x2 = intersection_l2.X2;
                        break;
                    case 2:
                        x1 = intersection_l1.X2;
                        x2 = intersection_l2.X1;
                        break;
                    case 3:
                        x1 = intersection_l1.X2;
                        x2 = intersection_l2.X2;
                        break;
                    default:
                        break;
                    }
                    dis = Distance.PointToPoint(x1, x2);

                    if (Math.Abs(dis - e3) <= epsilon)
                        resault.Add((x1, x2, itvlP3.GetPoint(value)));
                }
            }

            if (resault.Count == 0) resault = null;
            return resault;
            #endregion

        }
    }
}
