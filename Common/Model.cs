﻿using System;
using System.Collections;
using System.Collections.Generic;

using Tekla.Structures.Datatype;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;

using MuggleTeklaPlugins.Geometry3dExtension;

namespace MuggleTeklaPlugins.ModelExtension {
    /// <summary>
    /// <see cref="Tekla.Structures.Model"/>.<see cref="Polygon"/> 的扩展。
    /// </summary>
    public static class PolygonExtension {
        /// <summary>
        /// 克隆一个多边形。
        /// </summary>
        /// <param name="polygon">当前多边形</param>
        /// <returns>克隆的多边形。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polygon Clone(this Polygon polygon) {
            if (polygon is null) {
                throw new ArgumentNullException(nameof(polygon));
            }

            var np = new Polygon();
            foreach (Point point in polygon.Points) {
                np.Points.Add(new Point(point));
            }

            return np;
        }
    }
    /// <summary>
    /// 模型操作。
    /// </summary>
    public static class ModelOperation {
        /// <summary>
        /// 创建布尔操作多边形。
        /// </summary>
        /// <param name="contourPoints">轮廓点</param>
        /// <param name="thickness">厚度</param>
        /// <returns>布尔操作多边形</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContourPlate CreatBooleanOperationPolygon(ArrayList contourPoints, double thickness) {
            if (contourPoints is null) {
                throw new ArgumentNullException(nameof(contourPoints));
            }

            ContourPlate contourPlate = new ContourPlate {
                Contour = { ContourPoints = new ArrayList(contourPoints) },
                Profile = { ProfileString = "PL" + thickness },
                Material = { MaterialString = "ANTIMATERIAL" },
                Class = BooleanPart.BooleanOperativeClassName,
            };
            contourPlate.Insert();

            return contourPlate;
        }
        /// <summary>
        /// 创建布尔操作多边形。
        /// </summary>
        /// <param name="sourceContourPlate">用作布尔操作的多边形板</param>
        /// <returns>布尔操作多边形</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContourPlate CreatBooleanOperationPolygon(ContourPlate sourceContourPlate) {
            if (sourceContourPlate is null) {
                throw new ArgumentNullException(nameof(sourceContourPlate));
            }

            ContourPlate contourPlate = new ContourPlate {
                Contour = { ContourPoints = new ArrayList(sourceContourPlate.Contour.ContourPoints) },
                Profile = { ProfileString = string.Copy(sourceContourPlate.Profile.ProfileString) },
                Material = { MaterialString = "ANTIMATERIAL" },
                Class = BooleanPart.BooleanOperativeClassName,
            };
            contourPlate.Insert();

            return contourPlate;
        }
        /// <summary>
        /// 应用布尔操作。
        /// </summary>
        /// <param name="father">被布尔操作的对象</param>
        /// <param name="operativePart">布尔操作对象</param>
        /// <param name="typeEnum">布尔操作类型，默认值<see cref="Tekla.Structures.Model.BooleanPart.BooleanTypeEnum.BOOLEAN_CUT"/></param>
        /// <returns>布尔操作是否成功</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool ApplyBooleanOperation(ModelObject father, Part operativePart,
            BooleanPart.BooleanTypeEnum typeEnum = BooleanPart.BooleanTypeEnum.BOOLEAN_CUT) {
            if (father is null) {
                throw new ArgumentNullException(nameof(father));
            }

            if (operativePart is null) {
                throw new ArgumentNullException(nameof(operativePart));
            }

            BooleanPart bp = new BooleanPart {
                Father = father,
                Type = typeEnum,
            };
            bp.SetOperativePart(operativePart);

            return bp.Insert();
        }
        /// <summary>
        /// 创建梁。
        /// </summary>
        /// <param name="startPoint">梁起点</param>
        /// <param name="endPoint">梁终点</param>
        /// <param name="name">梁名称，默认值BEAM</param>
        /// <param name="profileStr">梁截面，默认值HM244*175*7*11</param>
        /// <param name="materialStr">梁材质，默认值Q345B</param>
        /// <param name="assemblyPrefix">梁构件编号前缀，默认值GL-</param>
        /// <param name="assemblyStartNumber">梁构件编号起始编号，默认值1</param>
        /// <param name="partPrefix">梁零件编号前缀，默认值P</param>
        /// <param name="partStartNumber">梁零件编号起始编号，默认值1</param>
        /// <param name="planeEnum">位置属性的平面类型，默认值<see cref="Tekla.Structures.Model.Position.PlaneEnum.MIDDLE"/></param>
        /// <param name="depthEnum">位置属性的深度类型，默认值<see cref="Tekla.Structures.Model.Position.DepthEnum.MIDDLE"/></param>
        /// <param name="rotationEnum">位置属性的旋转类型，默认值<see cref="Tekla.Structures.Model.Position.RotationEnum.FRONT"/></param>
        /// <returns>创建的梁</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Beam CreatBeam(Point startPoint, Point endPoint,
            string name = "BEAM",
            string profileStr = "HM244*175*7*11",
            string materialStr = "Q345B",
            string assemblyPrefix = "GL-", int assemblyStartNumber = 1,
            string partPrefix = "P", int partStartNumber = 1,
            string @class = "99",
            Position.PlaneEnum planeEnum = Position.PlaneEnum.MIDDLE,
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE,
            Position.RotationEnum rotationEnum = Position.RotationEnum.FRONT) {
            if (startPoint is null) {
                throw new ArgumentNullException(nameof(startPoint));
            }

            if (endPoint is null) {
                throw new ArgumentNullException(nameof(endPoint));
            }

            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentException($"“{nameof(name)}”不能为 null 或空。", nameof(name));
            }

            if (string.IsNullOrEmpty(profileStr)) {
                throw new ArgumentException($"“{nameof(profileStr)}”不能为 null 或空。", nameof(profileStr));
            }

            if (string.IsNullOrEmpty(materialStr)) {
                throw new ArgumentException($"“{nameof(materialStr)}”不能为 null 或空。", nameof(materialStr));
            }

            if (string.IsNullOrEmpty(assemblyPrefix)) {
                throw new ArgumentException($"“{nameof(assemblyPrefix)}”不能为 null 或空。", nameof(assemblyPrefix));
            }

            if (string.IsNullOrEmpty(partPrefix)) {
                throw new ArgumentException($"“{nameof(partPrefix)}”不能为 null 或空。", nameof(partPrefix));
            }

            if (string.IsNullOrEmpty(@class)) {
                throw new ArgumentException($"“{nameof(@class)}”不能为 null 或空。", nameof(@class));
            }

            //使用new，防止引用类型值变化
            Beam beam = new Beam {
                StartPoint = new Point(startPoint),
                EndPoint = new Point(endPoint),
                Name = string.Copy(name),
                Profile = { ProfileString = string.Copy(profileStr) },
                Material = { MaterialString = string.Copy(materialStr) },
                AssemblyNumber = { Prefix = string.Copy(assemblyPrefix), StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = string.Copy(partPrefix), StartNumber = partStartNumber },
                Class = string.Copy(@class),
                Position = {
                    Plane = planeEnum,
                    Depth = depthEnum,
                    Rotation = rotationEnum,
                }
            };
            beam.Insert();

            return beam;
        }
        /// <summary>
        /// 创建多边形板。
        /// </summary>
        /// <param name="contourPoints">板轮廓点</param>
        /// <param name="name">名称，默认值PLATE</param>
        /// <param name="profileStr">截面，默认值PL10</param>
        /// <param name="materialStr">材质，默认值Q345B</param>
        /// <param name="assemblyPrefix">构件编号前缀，默认值PLATE</param>
        /// <param name="assemblyStartNumber">构件编号起始编号，默认值1</param>
        /// <param name="partPrefix">零件编号前缀，默认值P</param>
        /// <param name="partStartNumber">零件编号起始编号，默认值1</param>
        /// <param name="depthEnum">位置属性的深度类型，默认值<see cref="Tekla.Structures.Model.Position.DepthEnum.MIDDLE"/></param>
        /// <returns>创建的多边形</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static ContourPlate CreatContourPlate(ArrayList contourPoints,
            string name = "PLATE",
            string profileStr = "PL10",
            string materialStr = "Q345B",
            string assemblyPrefix = "PLATE",
            int assemblyStartNumber = 1,
            string partPrefix = "P",
            int partStartNumber = 1,
            string @class = "99",
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE) {
            if (contourPoints is null) {
                throw new ArgumentNullException(nameof(contourPoints));
            }

            if (contourPoints.Count == 0) {
                throw new ArgumentException($"“{nameof(contourPoints)}”中项目数应大于0。");
            }

            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentException($"“{nameof(name)}”不能为 null 或空。", nameof(name));
            }

            if (string.IsNullOrEmpty(profileStr)) {
                throw new ArgumentException($"“{nameof(profileStr)}”不能为 null 或空。", nameof(profileStr));
            }

            if (string.IsNullOrEmpty(materialStr)) {
                throw new ArgumentException($"“{nameof(materialStr)}”不能为 null 或空。", nameof(materialStr));
            }

            if (string.IsNullOrEmpty(assemblyPrefix)) {
                throw new ArgumentException($"“{nameof(assemblyPrefix)}”不能为 null 或空。", nameof(assemblyPrefix));
            }

            if (string.IsNullOrEmpty(partPrefix)) {
                throw new ArgumentException($"“{nameof(partPrefix)}”不能为 null 或空。", nameof(partPrefix));
            }

            if (string.IsNullOrEmpty(@class)) {
                throw new ArgumentException($"“{nameof(@class)}”不能为 null 或空。", nameof(@class));
            }

            ContourPlate contourPlate = new ContourPlate {
                Contour = { ContourPoints = new ArrayList(contourPoints) },
                Name = string.Copy(name),
                Profile = { ProfileString = string.Copy(profileStr) },
                Material = { MaterialString = string.Copy(materialStr) },
                AssemblyNumber = { Prefix = string.Copy(assemblyPrefix), StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = string.Copy(partPrefix), StartNumber = partStartNumber },
                Class = string.Copy(@class),
                Position = { Depth = depthEnum },
            };
            contourPlate.Insert();

            return contourPlate;
        }
        /// <summary>
        /// 创建焊缝。
        /// </summary>
        /// <param name="mainObject">焊接到对象</param>
        /// <param name="secondaryObject">焊接对象</param>
        /// <param name="arroundWeld">环焊缝(true)或边缘焊缝(false)，默认值true</param>
        /// <param name="shopWeld">车间焊接(true)或现场焊接(false)，默认值true</param>
        /// <returns>创建的焊缝</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Weld CreatWeld(ModelObject mainObject, ModelObject secondaryObject,
            bool arroundWeld = true, bool shopWeld = true) {
            if (mainObject is null) {
                throw new ArgumentNullException(nameof(mainObject));
            }

            if (secondaryObject is null) {
                throw new ArgumentNullException(nameof(secondaryObject));
            }

            Weld weld = new Weld {
                MainObject = mainObject,
                SecondaryObject = secondaryObject,
                AroundWeld = arroundWeld,
                ShopWeld = shopWeld
            };
            weld.Insert();

            return weld;
        }
        /// <summary>
        /// 创建多边形焊缝。
        /// </summary>
        /// <param name="mainObject">焊接到对象</param>
        /// <param name="secondaryObject">焊接的对象</param>
        /// <param name="polygon">多边形</param>
        /// <param name="arroundWeld">环焊缝(true)或边缘焊缝(false)，默认值true</param>
        /// <param name="shopWeld">车间焊接(true)或现场焊接(false)，默认值true</param>
        /// <returns>创建的多边形焊缝</returns>
        public static PolygonWeld CreatWeld(ModelObject mainObject, ModelObject secondaryObject, Polygon polygon,
            bool arroundWeld = false, bool shopWeld = true) {
            if (mainObject is null) {
                throw new ArgumentNullException(nameof(mainObject));
            }

            if (secondaryObject is null) {
                throw new ArgumentNullException(nameof(secondaryObject));
            }

            if (polygon is null) {
                throw new ArgumentNullException(nameof(polygon));
            }

            PolygonWeld pw = new PolygonWeld {
                MainObject = mainObject,
                SecondaryObject = secondaryObject,
                Polygon = polygon.Clone(),
                AroundWeld = arroundWeld,
                ShopWeld = shopWeld
            };
            pw.Insert();

            return pw;
        }
        /// <summary>
        /// 创建阵列螺栓组。
        /// </summary>
        /// <param name="boltTo">栓接到的零件</param>
        /// <param name="beBolted">要栓接的零件</param>
        /// <param name="otherBeBolted">其他要栓接的零件集合</param>
        /// <param name="firstPosition">第一点位置</param>
        /// <param name="secondPosition">第二点位置</param>
        /// <param name="bolt_dist_X">X方向距离列(第一个值为起点偏移)</param>
        /// <param name="bolt_dist_Y">Y方向距离列</param>
        /// <param name="position">螺栓组定位，默认值旋转定位Top，平面定位0，深度定位0</param>
        /// <param name="bolt_standard">螺栓等级，默认值HS10.9</param>
        /// <param name="bolt_size">螺栓尺寸，默认值20</param>
        /// <param name="bolttype">车间(true)或现场(false)，默认值true</param>
        /// <param name="tolerance">孔公差，默认值2</param>
        /// <param name="bolt">螺栓(true)或孔(false)，默认值true</param>
        /// <param name="washer1">是否使用垫圈1，默认值true</param>
        /// <param name="washer2">是否使用垫圈2，默认值true</param>
        /// <param name="washer3">是否使用垫圈3，默认值true</param>
        /// <param name="nut1">是否使用螺母1，默认值true</param>
        /// <param name="nut2">是否使用螺母1，默认值true</param>
        /// <returns>创建的阵列螺栓组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static BoltArray CreatBoltArray(
            Part boltTo, Part beBolted, List<Part> otherBeBolted,
            Point firstPosition, Point secondPosition,
            DistanceList bolt_dist_X, DistanceList bolt_dist_Y,
            Position position = default,
            string bolt_standard = "HS10.9", double bolt_size = 20,
            BoltGroup.BoltTypeEnum bolttype = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
            double tolerance = 2, bool bolt = true,
            bool washer1 = true, bool washer2 = true, bool washer3 = true,
            bool nut1 = true, bool nut2 = true) {
            if (boltTo is null) {
                throw new ArgumentNullException(nameof(boltTo));
            }

            if (firstPosition is null) {
                throw new ArgumentNullException(nameof(firstPosition));
            }

            if (secondPosition is null) {
                throw new ArgumentNullException(nameof(secondPosition));
            }

            if (bolt_dist_X.Count < 2 || bolt_dist_Y.Count < 1)
                throw new ArgumentException($"“{nameof(bolt_dist_X)}”中项目数至少需要2个。");

            if (bolt_dist_Y.Count < 1)
                throw new ArgumentException($"“{nameof(bolt_dist_Y)}”中项目数至少需要1个。");

            if (position == null) position = new Position { Rotation = Position.RotationEnum.TOP };

            //使用new，防止引用类型值变化
            firstPosition = new Point(firstPosition);
            secondPosition = new Point(secondPosition);

            BoltArray boltArray = new BoltArray {
                PartToBoltTo = boltTo,
                PartToBeBolted = beBolted,
                FirstPosition = firstPosition,
                SecondPosition = secondPosition,
                Position = position,
                BoltStandard = string.Copy(bolt_standard),
                BoltSize = bolt_size,
                BoltType = bolttype,
                Tolerance = tolerance,
                Bolt = bolt,
                Washer1 = washer1,
                Washer2 = washer2,
                Washer3 = washer3,
                Nut1 = nut1,
                Nut2 = nut2,
            };
            if (otherBeBolted != null) {
                for (int i = 0; i < otherBeBolted.Count; i++)
                    boltArray.AddOtherPartToBolt(otherBeBolted[i]);
            }

            boltArray.StartPointOffset.Dx = bolt_dist_X[0].Value;
            bolt_dist_X.RemoveAt(0);
            foreach (var d in bolt_dist_X) {
                boltArray.AddBoltDistX(d.Value);
            }
            foreach (var d in bolt_dist_Y) {
                boltArray.AddBoltDistY(d.Value);
            }

            boltArray.Insert();

            return boltArray;
        }
        /// <summary>
        /// 创建环形螺栓组。
        /// </summary>
        /// <param name="boltTo">栓接到的零件</param>
        /// <param name="beBolted">要栓接的零件</param>
        /// <param name="otherBeBolted">其他要栓接的零件集合</param>
        /// <param name="firstPosition">第一点位置</param>
        /// <param name="secondPosition">第二点位置</param>
        /// <param name="num">螺栓数量，默认值8</param>
        /// <param name="diameter">环形直径，默认值200</param>
        /// <param name="position">螺栓组定位，默认值旋转定位Top，平面定位0，深度定位0</param>
        /// <param name="bolt_standard">螺栓等级，默认值HS10.9</param>
        /// <param name="bolt_size">螺栓尺寸，默认值20</param>
        /// <param name="bolttype">车间(true)或现场(false)，默认值true</param>
        /// <param name="tolerance">孔公差，默认值2</param>
        /// <param name="bolt">螺栓(true)或孔(false)，默认值true</param>
        /// <param name="washer1">是否使用垫圈1，默认值true</param>
        /// <param name="washer2">是否使用垫圈2，默认值true</param>
        /// <param name="washer3">是否使用垫圈3，默认值true</param>
        /// <param name="nut1">是否使用螺母1，默认值true</param>
        /// <param name="nut2">是否使用螺母1，默认值true</param>
        /// <returns>创建的环形螺栓组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BoltCircle CreatBoltCircle(
            Part boltTo, Part beBolted, List<Part> otherBeBolted,
            Point firstPosition, Point secondPosition,
            int num = 8, double diameter = 200,
            Position position = default,
            string bolt_standard = "HS10.9", double bolt_size = 20,
            BoltGroup.BoltTypeEnum bolttype = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
            double tolerance = 2, bool bolt = true,
            bool washer1 = true, bool washer2 = true, bool washer3 = true,
            bool nut1 = true, bool nut2 = true) {
            if (boltTo is null) {
                throw new ArgumentNullException(nameof(boltTo));
            }

            if (firstPosition is null) {
                throw new ArgumentNullException(nameof(firstPosition));
            }

            if (secondPosition is null) {
                throw new ArgumentNullException(nameof(secondPosition));
            }

            if (position == default) position = new Position { Rotation = Position.RotationEnum.TOP };

            firstPosition = new Point(firstPosition);
            secondPosition = new Point(secondPosition);

            var boltCircle = new BoltCircle {
                PartToBoltTo = boltTo,
                PartToBeBolted = beBolted,
                FirstPosition = firstPosition,
                SecondPosition = secondPosition,
                NumberOfBolts = num,
                Diameter = diameter,
                Position = position,
                BoltStandard = string.Copy(bolt_standard),
                BoltSize = bolt_size,
                BoltType = bolttype,
                Tolerance = tolerance,
                Bolt = bolt,
                Washer1 = washer1,
                Washer2 = washer2,
                Washer3 = washer3,
                Nut1 = nut1,
                Nut2 = nut2,
            };

            if (otherBeBolted != null) {
                for (int i = 0; i < otherBeBolted.Count; i++) {
                    boltCircle.AddOtherPartToBolt(otherBeBolted[i]);
                }
            }

            boltCircle.Insert();

            return boltCircle;
        }
        /// <summary>
        /// 沿给定轴线每隔给定角度旋转复制一份对象。
        /// </summary>
        /// <param name="obj">要旋转复制的对象</param>
        /// <param name="Axis_Origin">旋转轴起点</param>
        /// <param name="Axis_Direction">旋转轴方向</param>
        /// <param name="angle">旋转角度，弧度制</param>
        /// <param name="num">要复制的数量，默认值1</param>
        /// <returns>成功旋转复制的对象集合（不包括初始对象）。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static List<ModelObject> Copy_Rotate(ModelObject obj, Point Axis_Origin, Vector Axis_Direction, double angle, int num = 1) {
            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            if (Axis_Origin is null) {
                throw new ArgumentNullException(nameof(Axis_Origin));
            }

            if (Axis_Direction is null) {
                throw new ArgumentNullException(nameof(Axis_Direction));
            }

            if (num <= 0)
                throw new ArgumentException($"“{nameof(num)}”不应小于等于0。");

            var objs = new List<ModelObject>();
            ModelObject copy;

            for (int i = 1; i <= num; i++) {
                copy = Operation.CopyObject(obj, new Vector());
                if (Move_Rotate(copy, Axis_Origin, Axis_Direction, angle * i)) objs.Add(copy);
            }

            return objs;
        }
        /// <summary>
        /// 沿给定轴线和角度旋转移动对象。
        /// </summary>
        /// <param name="obj">要旋转移动的对象</param>
        /// <param name="Axis_Origin">旋转轴起点</param>
        /// <param name="Axis_Direction">旋转轴方向</param>
        /// <param name="angle">旋转角度，弧度制</param>
        /// <returns>成功返回 True，失败返回 False。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool Move_Rotate(ModelObject obj, Point Axis_Origin, Vector Axis_Direction, double angle) {
            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            if (Axis_Origin is null) {
                throw new ArgumentNullException(nameof(Axis_Origin));
            }

            if (Axis_Direction is null) {
                throw new ArgumentNullException(nameof(Axis_Direction));
            }

            var rotationMatrix = MatrixFactory.Rotate(angle, Axis_Direction);

            var currentCS = new CoordinateSystem();
            var line = new Line(Axis_Origin, Axis_Direction);
            var projectedPoint = Projection.PointToLine(currentCS.Origin, line);
            var vector = currentCS.Origin - projectedPoint;

            var translationMatrix = MatrixFactoryExtension.Translate(rotationMatrix.GetTranspose().Transform(vector) - vector);

            var targetCS = (rotationMatrix * translationMatrix).Transform(currentCS);

            return Operation.MoveObject(obj, currentCS, targetCS);
        }
    }
}