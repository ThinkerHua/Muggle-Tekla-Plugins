using Muggle.TeklaPlugins.Common.Operation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Muggle.TeklaPlugins.Common.Geometry3d {
    /// <summary>
    /// 三维几何操作相关功能
    /// </summary>
    public static class Geometry3dOperation {
        /// <summary>
        /// 获取一个单位向量，其在XY平面上的投影与X轴之间的夹角，以及其与XY平面之间的夹角为给定值。
        /// </summary>
        /// <param name="angle_between_X">在XY平面上的投影与X轴之间的夹角，弧度制</param>
        /// <param name="angle_between_XY">与XY平面之间的夹角，弧度制</param>
        /// <returns>单位向量，其在XY平面上的投影与X轴之间的夹角，以及其与XY平面之间的夹角为给定值。</returns>
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
        /// 在平面上，有一个固定形状的三角形（位置不固定）和三条已知直线（位置固定）。求当三角形三个顶点分别落在三条直线上时的位置（即三个顶点值）。
        /// <para><b>* 本方法仅处理二维平面情形。</b></para>
        /// <para>作如下约定：</para>
        /// <list type="bullet">
        ///     <item>
        ///         三条直线分别为 <paramref name="lines"/>.L1, <paramref name="lines"/>.L2, <paramref name="lines"/>.L3。
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
        /// <summary>
        /// 根据任意四个不相同的点求球体中心点。
        /// </summary>
        /// <param name="p0">给定任意点0</param>
        /// <param name="p1">给定任意点1</param>
        /// <param name="p2">给定任意点2</param>
        /// <param name="p3">给定任意点3</param>
        /// <returns>球体的中心点。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">给定的四个点必须均不相等。</exception>
        public static Point CenterOfSphere(Point p0, Point p1, Point p2, Point p3) {
            if (p0 is null) {
                throw new ArgumentNullException(nameof(p0));
            }

            if (p1 is null) {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 is null) {
                throw new ArgumentNullException(nameof(p2));
            }

            if (p3 is null) {
                throw new ArgumentNullException(nameof(p3));
            }

            if (p0 == p1 || p0 == p2 || p0 == p3 || p1 == p2 || p1 == p3 || p2 == p3) {
                throw new ArgumentException("给定的四个点必须均不相等。");
            }

            var m = new Matrix();
            m[0, 0] = p0.X - p1.X; m[0, 1] = p0.Y - p1.Y; m[0, 2] = p0.Z - p1.Z;
            m[1, 0] = p2.X - p3.X; m[1, 1] = p2.Y - p3.Y; m[1, 2] = p2.Z - p3.Z;
            m[2, 0] = p1.X - p2.X; m[2, 1] = p1.Y - p2.Y; m[2, 2] = p1.Z - p2.Z;
            m[3, 0] = (p0.X * p0.X - p1.X * p1.X + p0.Y * p0.Y - p1.Y * p1.Y + p0.Z * p0.Z - p1.Z * p1.Z) * 0.5;
            m[3, 1] = (p2.X * p2.X - p3.X * p3.X + p2.Y * p2.Y - p3.Y * p3.Y + p2.Z * p2.Z - p3.Z * p3.Z) * 0.5;
            m[3, 2] = (p1.X * p1.X - p2.X * p2.X + p1.Y * p1.Y - p2.Y * p2.Y + p1.Z * p1.Z - p2.Z * p2.Z) * 0.5;

            return m.Cramer();
        }
    }
}
