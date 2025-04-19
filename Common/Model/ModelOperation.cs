/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2024 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  ModelOperation.cs: operations of model object
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Tekla.Structures.Datatype;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Muggle.TeklaPlugins.Common.Model {
    /// <summary>
    /// 模型操作。
    /// </summary>
    public static class ModelOperation {
        /// <summary>
        /// 用给定轮廓点集合创建布尔操作多边形。
        /// </summary>
        /// <param name="contourPoints">轮廓点集合</param>
        /// <param name="thickness">厚度</param>
        /// <returns>布尔操作多边形。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="thickness"/> 不能是 <see cref="double.NaN"/>，
        /// 也不应小于等于 0.0。</exception>
        public static ContourPlate CreatBooleanOperationPolygon(ArrayList contourPoints, double thickness) {
            if (contourPoints is null) {
                throw new ArgumentNullException(nameof(contourPoints));
            }
            if (double.IsNaN(thickness) || thickness <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(thickness)}”不能是 double.NaN，也不应小于等于 0.0。");
            }

            ContourPlate contourPlate = new ContourPlate {
                Contour = { ContourPoints = contourPoints },
                Profile = { ProfileString = "PL" + thickness },
                Material = { MaterialString = "ANTIMATERIAL" },
                Class = BooleanPart.BooleanOperativeClassName,
            };
            if (!contourPlate.Insert())
                throw new Exception("Failed to insert BooleanOperationPolygon.");

            return contourPlate;
        }
        /// <summary>
        /// 用给定点集合创建布尔操作多边形。倒角为 <see cref="Chamfer.ChamferTypeEnum.CHAMFER_NONE"/>。
        /// </summary>
        /// <param name="points">点集合</param>
        /// <param name="thickness">厚度</param>
        /// <returns>布尔操作多边形。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="thickness"/> 不能是 <see cref="double.NaN"/>，
        /// 也不应小于等于 0.0。</exception>
        public static ContourPlate CreatBooleanOperationPolygon(IEnumerable<Point> points, double thickness) {
            if (points is null) {
                throw new ArgumentNullException(nameof(points));
            }
            if (double.IsNaN(thickness) || thickness <= 0) {
                throw new ArgumentOutOfRangeException($"“{nameof(thickness)}”不能是 double.NaN，也不应小于等于 0.0。");
            }

            var chamfer = new Chamfer();
            ArrayList contourPoints = new ArrayList();
            foreach (var point in points) {
                contourPoints.Add(new ContourPoint(point, chamfer));
            }

            var contourPlate = new ContourPlate {
                Contour = { ContourPoints = contourPoints },
                Profile = { ProfileString = "PL" + thickness },
                Material = { MaterialString = "ANTIMATERIAL" },
                Class = BooleanPart.BooleanOperativeClassName,
            };
            if (!contourPlate.Insert())
                throw new Exception("Failed to insert BooleanOperationPolygon.");

            return contourPlate;
        }
        /// <summary>
        /// 用给定多边形板创建布尔操作多边形。
        /// </summary>
        /// <param name="sourceContourPlate">用作布尔操作的多边形板</param>
        /// <returns>布尔操作多边形</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContourPlate CreatBooleanOperationPolygon(ContourPlate sourceContourPlate) {
            if (sourceContourPlate is null) {
                throw new ArgumentNullException(nameof(sourceContourPlate));
            }

            var cps = new ArrayList();
            foreach (ContourPoint cp in sourceContourPlate.Contour.ContourPoints) {
                cps.Add(cp.Clone());
            }
            ContourPlate contourPlate = new ContourPlate {
                Contour = { ContourPoints = cps },
                Profile = { ProfileString = sourceContourPlate.Profile.ProfileString },
                Material = { MaterialString = "ANTIMATERIAL" },
                Class = BooleanPart.BooleanOperativeClassName,
            };
            if (!contourPlate.Insert())
                throw new Exception("Failed to insert BooleanOperationPolygon.");

            return contourPlate;
        }
        /// <summary>
        /// 应用布尔操作。
        /// </summary>
        /// <param name="father">被布尔操作的对象</param>
        /// <param name="operativePart">布尔操作对象</param>
        /// <param name="typeEnum">布尔操作类型，默认值 <see cref="BooleanPart.BooleanTypeEnum.BOOLEAN_CUT"/></param>
        /// <returns>操作成功返回 true，失败返回 false。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool ApplyBooleanOperation(
            ModelObject father,
            Part operativePart,
            BooleanPart.BooleanTypeEnum typeEnum = BooleanPart.BooleanTypeEnum.BOOLEAN_CUT) {

            if (father is null) {
                throw new ArgumentNullException(nameof(father));
            }

            if (operativePart is null) {
                throw new ArgumentNullException(nameof(operativePart));
            }

            if (operativePart.Class != BooleanPart.BooleanOperativeClassName) {
                //不需要下面这句，会产生重复对象。设置Class属性后，会自动生成BooleanPart对象
                //operativePart = Tekla.Structures.Model.Operations.Operation.CopyObject(operativePart, new Vector()) as Part;
                operativePart.Class = BooleanPart.BooleanOperativeClassName;
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
        /// <param name="name">梁名称，默认值 "BEAM"</param>
        /// <param name="profileStr">梁截面，默认值 "HM244*175*7*11"</param>
        /// <param name="materialStr">梁材质，默认值 "Q345B"</param>
        /// <param name="assemblyPrefix">梁构件编号前缀，默认值 "GL-"</param>
        /// <param name="assemblyStartNumber">梁构件编号起始编号，默认值 1</param>
        /// <param name="partPrefix">梁零件编号前缀，默认值 "P"</param>
        /// <param name="partStartNumber">梁零件编号起始编号，默认值 1</param>
        /// <param name="class">梁的等级，默认值 "99"</param>
        /// <param name="planeEnum">位置属性的平面类型，默认值 <see cref="Position.PlaneEnum.MIDDLE"/></param>
        /// <param name="planeOffset">位置属性的平面偏移，默认值 0.0</param>
        /// <param name="depthEnum">位置属性的深度类型，默认值 <see cref="Position.DepthEnum.MIDDLE"/></param>
        /// <param name="depthOffset">位置属性的深度偏移，默认值 0.0</param>
        /// <param name="rotationEnum">位置属性的旋转类型，默认值 <see cref="Position.RotationEnum.FRONT"/></param>
        /// <param name="rotationOffset">位置属性的旋转偏移，默认值 0.0</param>
        /// <returns>创建的梁</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="name"/>、<paramref name="profileStr"/>、<paramref name="materialStr"/>、
        /// <paramref name="assemblyPrefix"/>、<paramref name="partPrefix"/>、<paramref name="class"/>为 null 或 <see cref="string.Empty"/>
        /// 时引发。</exception>
        public static Beam CreatBeam(
            Point startPoint,
            Point endPoint,
            string name = "BEAM",
            string profileStr = "HM244*175*7*11",
            string materialStr = "Q345B",
            string assemblyPrefix = "GL-", int assemblyStartNumber = 1,
            string partPrefix = "P", int partStartNumber = 1,
            string @class = "99",
            Position.PlaneEnum planeEnum = Position.PlaneEnum.MIDDLE,
            double planeOffset = 0.0,
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE,
            double depthOffset = 0.0,
            Position.RotationEnum rotationEnum = Position.RotationEnum.FRONT,
            double rotationOffset = 0.0) {

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

            Beam beam = new Beam {
                StartPoint = startPoint,
                EndPoint = endPoint,
                Name = name,
                Profile = { ProfileString = profileStr },
                Material = { MaterialString = materialStr },
                AssemblyNumber = { Prefix = assemblyPrefix, StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = partPrefix, StartNumber = partStartNumber },
                Class = @class,
                Position = {
                    Plane = planeEnum, PlaneOffset = planeOffset,
                    Depth = depthEnum, DepthOffset = depthOffset,
                    Rotation = rotationEnum, RotationOffset = rotationOffset,
                }
            };
            if (!beam.Insert())
                throw new Exception("Failed to insert Beam.");

            return beam;
        }

        /// <summary>
        /// 用给定轮廓点集合创建折梁。
        /// </summary>
        /// <param name="contour">折梁的轮廓</param>
        /// <param name="name">折梁名称，默认值 "BEAM"</param>
        /// <param name="profileStr">折梁截面，默认值 "HM244*175*7*11"</param>
        /// <param name="materialStr">折梁材质，默认值 "Q345B"</param>
        /// <param name="assemblyPrefix">折梁构件编号前缀，默认值 "GL-"</param>
        /// <param name="assemblyStartNumber">折梁构件编号起始编号，默认值 1</param>
        /// <param name="partPrefix">折梁零件编号前缀，默认值 "P"</param>
        /// <param name="partStartNumber">折梁零件编号起始编号，默认值 1</param>
        /// <param name="class">折梁的等级，默认值 "99"</param>
        /// <param name="planeEnum">位置属性的平面类型，默认值 <see cref="Position.PlaneEnum.MIDDLE"/></param>
        /// <param name="planeOffset">位置属性的平面偏移，默认值 0.0</param>
        /// <param name="depthEnum">位置属性的深度类型，默认值 <see cref="Position.DepthEnum.MIDDLE"/></param>
        /// <param name="depthOffset">位置属性的深度偏移，默认值 0.0</param>
        /// <param name="rotationEnum">位置属性的旋转类型，默认值 <see cref="Position.RotationEnum.FRONT"/></param>
        /// <param name="rotationOffset">位置属性的旋转偏移，默认值 0.0</param>
        /// <returns>创建的折梁</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="name"/>、<paramref name="profileStr"/>、<paramref name="materialStr"/>、
        /// <paramref name="assemblyPrefix"/>、<paramref name="partPrefix"/>、<paramref name="class"/>为 null 或 <see cref="string.Empty"/>
        /// 时引发。</exception>
        public static PolyBeam CreatPolyBeam(
            Contour contour,
            string name = "BEAM",
            string profileStr = "HM244*175*7*11",
            string materialStr = "Q345B",
            string assemblyPrefix = "GL-", int assemblyStartNumber = 1,
            string partPrefix = "P", int partStartNumber = 1,
            string @class = "99",
            Position.PlaneEnum planeEnum = Position.PlaneEnum.MIDDLE,
            double planeOffset = 0.0,
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE,
            double depthOffset = 0.0,
            Position.RotationEnum rotationEnum = Position.RotationEnum.FRONT,
            double rotationOffset = 0.0) {

            if (contour is null) {
                throw new ArgumentNullException(nameof(contour));
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

            var polybeam = new PolyBeam {
                Contour = contour,
                Name = name,
                Profile = { ProfileString = profileStr },
                Material = { MaterialString = materialStr },
                AssemblyNumber = { Prefix = assemblyPrefix, StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = partPrefix, StartNumber = partStartNumber },
                Class = @class,
                Position = {
                    Plane = planeEnum, PlaneOffset = planeOffset,
                    Depth = depthEnum, DepthOffset = depthOffset,
                    Rotation = rotationEnum, RotationOffset = rotationOffset,
                }
            };
            if (!polybeam.Insert())
                throw new Exception("Failed to insert Beam.");

            return polybeam;
        }

        /// <summary>
        /// 用给定点集合创建折梁，各轮廓点倒角均为 <see cref="Chamfer.ChamferTypeEnum.CHAMFER_NONE"/>。
        /// </summary>
        /// <param name="points">折梁的控制点集合</param>
        /// <param name="name">折梁名称，默认值 "BEAM"</param>
        /// <param name="profileStr">折梁截面，默认值 "HM244*175*7*11"</param>
        /// <param name="materialStr">折梁材质，默认值 "Q345B"</param>
        /// <param name="assemblyPrefix">折梁构件编号前缀，默认值 "GL-"</param>
        /// <param name="assemblyStartNumber">折梁构件编号起始编号，默认值 1</param>
        /// <param name="partPrefix">折梁零件编号前缀，默认值 "P"</param>
        /// <param name="partStartNumber">折梁零件编号起始编号，默认值 1</param>
        /// <param name="class">折梁的等级，默认值 "99"</param>
        /// <param name="planeEnum">位置属性的平面类型，默认值 <see cref="Position.PlaneEnum.MIDDLE"/></param>
        /// <param name="planeOffset">位置属性的平面偏移，默认值 0.0</param>
        /// <param name="depthEnum">位置属性的深度类型，默认值 <see cref="Position.DepthEnum.MIDDLE"/></param>
        /// <param name="depthOffset">位置属性的深度偏移，默认值 0.0</param>
        /// <param name="rotationEnum">位置属性的旋转类型，默认值 <see cref="Position.RotationEnum.FRONT"/></param>
        /// <param name="rotationOffset">位置属性的旋转偏移，默认值 0.0</param>
        /// <returns>创建的折梁</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="name"/>、<paramref name="profileStr"/>、<paramref name="materialStr"/>、
        /// <paramref name="assemblyPrefix"/>、<paramref name="partPrefix"/>、<paramref name="class"/>为 null 或 <see cref="string.Empty"/>
        /// 时引发。</exception>
        public static PolyBeam CreatPolyBeam(
            IEnumerable<Point> points,
            string name = "BEAM",
            string profileStr = "HM244*175*7*11",
            string materialStr = "Q345B",
            string assemblyPrefix = "GL-", int assemblyStartNumber = 1,
            string partPrefix = "P", int partStartNumber = 1,
            string @class = "99",
            Position.PlaneEnum planeEnum = Position.PlaneEnum.MIDDLE,
            double planeOffset = 0.0,
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE,
            double depthOffset = 0.0,
            Position.RotationEnum rotationEnum = Position.RotationEnum.FRONT,
            double rotationOffset = 0.0) {

            if (points is null) {
                throw new ArgumentNullException(nameof(points));
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

            var contour = new Contour();
            foreach (var p in points) {
                contour.ContourPoints.Add(new ContourPoint(p, new Chamfer()));
            }

            var polybeam = new PolyBeam {
                Contour = contour,
                Name = name,
                Profile = { ProfileString = profileStr },
                Material = { MaterialString = materialStr },
                AssemblyNumber = { Prefix = assemblyPrefix, StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = partPrefix, StartNumber = partStartNumber },
                Class = @class,
                Position = {
                    Plane = planeEnum, PlaneOffset = planeOffset,
                    Depth = depthEnum, DepthOffset = depthOffset,
                    Rotation = rotationEnum, RotationOffset = rotationOffset,
                }
            };
            if (!polybeam.Insert())
                throw new Exception("Failed to insert Beam.");

            return polybeam;
        }

        /// <summary>
        /// 用给定轮廓点集合创建多边形板。
        /// </summary>
        /// <param name="contourPoints">板轮廓点</param>
        /// <param name="name">名称，默认值 "PLATE"</param>
        /// <param name="profileStr">截面，默认值 "PL10"</param>
        /// <param name="materialStr">材质，默认值 "Q345B"</param>
        /// <param name="assemblyPrefix">构件编号前缀，默认值 "PLATE"</param>
        /// <param name="assemblyStartNumber">构件编号起始编号，默认值 1</param>
        /// <param name="partPrefix">零件编号前缀，默认值 "P"</param>
        /// <param name="partStartNumber">零件编号起始编号，默认值 1</param>
        /// <param name="class">等级，默认值 "99"</param>
        /// <param name="depthEnum">位置属性的深度类型，默认值 <see cref="Position.DepthEnum.MIDDLE"/></param>
        /// <param name="depthOffset">位置属性的深度偏移，默认值 0.0</param>
        /// <returns>创建的多边形板。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="name"/>、<paramref name="profileStr"/>、<paramref name="materialStr"/>、
        /// <paramref name="assemblyPrefix"/>、<paramref name="partPrefix"/>、<paramref name="class"/>为 null 或 <see cref="string.Empty"/>
        /// 时引发。</exception>
        public static ContourPlate CreatContourPlate(
            ArrayList contourPoints,
            string name = "PLATE",
            string profileStr = "PL10",
            string materialStr = "Q345B",
            string assemblyPrefix = "PLATE",
            int assemblyStartNumber = 1,
            string partPrefix = "P",
            int partStartNumber = 1,
            string @class = "99",
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE,
            double depthOffset = 0.0) {

            if (contourPoints is null) {
                throw new ArgumentNullException(nameof(contourPoints));
            }

            if (contourPoints.Count == 0) {
                throw new ArgumentException($"“{nameof(contourPoints)}”元素数量不应为 0。");
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
                Contour = { ContourPoints = contourPoints },
                Name = name,
                Profile = { ProfileString = profileStr },
                Material = { MaterialString = materialStr },
                AssemblyNumber = { Prefix = assemblyPrefix, StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = partPrefix, StartNumber = partStartNumber },
                Class = @class,
                Position = { Depth = depthEnum, DepthOffset = depthOffset },
            };
            if (!contourPlate.Insert())
                throw new Exception("Failed to insert ContourPlate.");

            return contourPlate;
        }
        /// <summary>
        /// 用给定点集合创建多边形板。倒角为 <see cref="Chamfer.ChamferTypeEnum.CHAMFER_NONE"/>。
        /// </summary>
        /// <param name="points">点集合</param>
        /// <param name="name">名称，默认值 "PLATE"</param>
        /// <param name="profileStr">截面，默认值 "PL10"</param>
        /// <param name="materialStr">材质，默认值 "Q345B"</param>
        /// <param name="assemblyPrefix">构件编号前缀，默认值 "PLATE"</param>
        /// <param name="assemblyStartNumber">构件编号起始编号，默认值 1</param>
        /// <param name="partPrefix">零件编号前缀，默认值 "P"</param>
        /// <param name="partStartNumber">零件编号起始编号，默认值 1</param>
        /// <param name="class">等级，默认值 "99"</param>
        /// <param name="depthEnum">位置属性的深度类型，默认值 <see cref="Position.DepthEnum.MIDDLE"/></param>
        /// <param name="depthOffset">位置属性的深度偏移，默认值 0.0</param>
        /// <returns>创建的多边形板。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="name"/>、<paramref name="profileStr"/>、<paramref name="materialStr"/>、
        /// <paramref name="assemblyPrefix"/>、<paramref name="partPrefix"/>、<paramref name="class"/>为 null 或 <see cref="string.Empty"/>
        /// 时引发。</exception>
        public static ContourPlate CreatContourPlate(
            IEnumerable<Point> points,
            string name = "PLATE",
            string profileStr = "PL10",
            string materialStr = "Q345B",
            string assemblyPrefix = "PLATE",
            int assemblyStartNumber = 1,
            string partPrefix = "P",
            int partStartNumber = 1,
            string @class = "99",
            Position.DepthEnum depthEnum = Position.DepthEnum.MIDDLE,
            double depthOffset = 0.0) {

            if (points is null) {
                throw new ArgumentNullException(nameof(points));
            }

            if (points.Count() == 0) {
                throw new ArgumentException($"“{nameof(points)}”元素数量不应为 0。", nameof(points));
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

            var contourPoints = new ArrayList();
            var chamfer = new Chamfer();
            foreach (var point in points) {
                contourPoints.Add(new ContourPoint(point, chamfer));
            }

            ContourPlate contourPlate = new ContourPlate {
                Contour = { ContourPoints = contourPoints },
                Name = name,
                Profile = { ProfileString = profileStr },
                Material = { MaterialString = materialStr },
                AssemblyNumber = { Prefix = assemblyPrefix, StartNumber = assemblyStartNumber },
                PartNumber = { Prefix = partPrefix, StartNumber = partStartNumber },
                Class = @class,
                Position = { Depth = depthEnum, DepthOffset = depthOffset },
            };
            if (!contourPlate.Insert())
                throw new Exception("Failed to insert ContourPlate.");

            return contourPlate;
        }
        /// <summary>
        /// 创建焊缝。
        /// </summary>
        /// <param name="mainObject">焊接到对象</param>
        /// <param name="secondaryObject">焊接对象</param>
        /// <param name="arroundWeld">环焊缝(true)或边缘焊缝(false)，默认值 true</param>
        /// <param name="shopWeld">车间焊接(true)或现场焊接(false)，默认值 true</param>
        /// <param name="position">位置，默认值 <see cref="Weld.WeldPositionEnum.WELD_POSITION_PLUS_X"/></param>
        /// <param name="typeAbove">上焊缝类型，默认值 <see cref="BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET"/></param>
        /// <param name="sizeAbove">上焊缝尺寸，默认值 6.0</param>
        /// <param name="typeBelow">下焊缝类型，默认值 <see cref="BaseWeld.WeldTypeEnum.WELD_TYPE_NONE"/></param>
        /// <param name="sizeBelow">下焊缝尺寸，默认值 0.0</param>
        /// <returns>创建的焊缝</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Weld CreatWeld(
            ModelObject mainObject,
            ModelObject secondaryObject,
            bool arroundWeld = true, bool shopWeld = true,
            Weld.WeldPositionEnum position = Weld.WeldPositionEnum.WELD_POSITION_PLUS_X,
            Weld.WeldTypeEnum typeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET,
            double sizeAbove = 6,
            Weld.WeldTypeEnum typeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE,
            double sizeBelow = 0) {

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
                ShopWeld = shopWeld,
                Position = position,
                TypeAbove = typeAbove,
                SizeAbove = sizeAbove,
                TypeBelow = typeBelow,
                SizeBelow = sizeBelow,
            };
            if (!weld.Insert())
                throw new Exception("Failed to insert Weld.");

            return weld;
        }
        /// <summary>
        /// 创建多边形焊缝。
        /// </summary>
        /// <param name="mainObject">焊接到对象</param>
        /// <param name="secondaryObject">焊接的对象</param>
        /// <param name="polygon">多边形</param>
        /// <param name="arroundWeld">环焊缝(true)或边缘焊缝(false)，默认值 true</param>
        /// <param name="shopWeld">车间焊接(true)或现场焊接(false)，默认值 true</param>
        /// <returns>创建的多边形焊缝</returns>
        public static PolygonWeld CreatPolygonWeld(
            ModelObject mainObject,
            ModelObject secondaryObject,
            Polygon polygon,
            bool arroundWeld = false,
            bool shopWeld = true) {

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
                Polygon = polygon,
                AroundWeld = arroundWeld,
                ShopWeld = shopWeld
            };
            if (!pw.Insert())
                throw new Exception("Failed to insert PolygonWeld.");

            return pw;
        }
        /// <summary>
        /// 创建阵列螺栓组。
        /// </summary>
        /// <param name="boltTo">栓接到的零件</param>
        /// <param name="beBolted">要栓接的零件</param>
        /// <param name="otherBeBolted">其他要栓接的零件集合</param>
        /// <param name="firstPosition">第一定位点</param>
        /// <param name="secondPosition">第二定位点</param>
        /// <param name="bolt_dist_X">X方向距离列</param>
        /// <param name="bolt_dist_Y">Y方向距离列</param>
        /// <param name="position">螺栓组定位，默认值旋转定位 <see cref="Position.RotationEnum.TOP"/>，平面定位 0.0，深度定位 0.0</param>
        /// <param name="startOffset">起点偏移值，默认值 new Offset()</param>
        /// <param name="endOffset">终点偏移值，默认值 new Offset()</param>
        /// <param name="bolt_standard">螺栓等级，默认值 "HS10.9"</param>
        /// <param name="bolt_size">螺栓尺寸，默认值 20.0</param>
        /// <param name="bolttype">车间(true)或现场(false)，默认值 true</param>
        /// <param name="tolerance">孔公差，默认值 2.0</param>
        /// <param name="bolt">螺栓(true)或孔(false)，默认值 true</param>
        /// <param name="washer1">是否使用垫圈1，默认值 true</param>
        /// <param name="washer2">是否使用垫圈2，默认值 true</param>
        /// <param name="washer3">是否使用垫圈3，默认值 true</param>
        /// <param name="nut1">是否使用螺母1，默认值 true</param>
        /// <param name="nut2">是否使用螺母1，默认值 true</param>
        /// <returns>创建的阵列螺栓组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="bolt_dist_X"/> 或 <paramref name="bolt_dist_Y"/>
        /// 中元素数量少于 1 时引发。</exception>
        public static BoltArray CreatBoltArray(
            Part boltTo,
            Part beBolted,
            IEnumerable<Part> otherBeBolted,
            Point firstPosition,
            Point secondPosition,
            DistanceList bolt_dist_X,
            DistanceList bolt_dist_Y,
            Position position = default,
            Offset startOffset = default,
            Offset endOffset = default,
            string bolt_standard = "HS10.9",
            double bolt_size = 20.0,
            BoltGroup.BoltTypeEnum bolttype = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
            double tolerance = 2.0,
            bool bolt = true,
            bool washer1 = true,
            bool washer2 = true,
            bool washer3 = true,
            bool nut1 = true,
            bool nut2 = true) {

            if (boltTo is null) {
                throw new ArgumentNullException(nameof(boltTo));
            }

            if (firstPosition is null) {
                throw new ArgumentNullException(nameof(firstPosition));
            }

            if (secondPosition is null) {
                throw new ArgumentNullException(nameof(secondPosition));
            }

            if (bolt_dist_X.Count < 1)
                throw new ArgumentException($"“{nameof(bolt_dist_X)}”中项目数至少需要1个。");

            if (bolt_dist_Y.Count < 1)
                throw new ArgumentException($"“{nameof(bolt_dist_Y)}”中项目数至少需要1个。");

            if (position == null) position = new Position { Rotation = Position.RotationEnum.TOP };

            if (startOffset == null) startOffset = new Offset();

            if (endOffset == null) endOffset = new Offset();

            BoltArray boltArray = new BoltArray {
                PartToBoltTo = boltTo,
                PartToBeBolted = beBolted,
                FirstPosition = firstPosition,
                SecondPosition = secondPosition,
                Position = position,
                StartPointOffset = startOffset,
                EndPointOffset = endOffset,
                BoltStandard = bolt_standard,
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
                foreach (var part in otherBeBolted) {
                    boltArray.AddOtherPartToBolt(part);
                }
            }

            foreach (var d in bolt_dist_X) {
                boltArray.AddBoltDistX(d.Value);
            }

            foreach (var d in bolt_dist_Y) {
                boltArray.AddBoltDistY(d.Value);
            }

            if (!boltArray.Insert())
                throw new Exception("Failed to insert BoltArray.");

            return boltArray;
        }
        /// <summary>
        /// 创建环形螺栓组。
        /// </summary>
        /// <param name="boltTo">栓接到的零件</param>
        /// <param name="beBolted">要栓接的零件</param>
        /// <param name="otherBeBolted">其他要栓接的零件集合</param>
        /// <param name="firstPosition">第一定位点</param>
        /// <param name="secondPosition">第二定准点</param>
        /// <param name="num">螺栓数量，默认值 8</param>
        /// <param name="diameter">环形直径，默认值 200.0</param>
        /// <param name="position">螺栓组定位，默认值旋转定位 <see cref="Position.RotationEnum.TOP"/>，平面定位 0.0，深度定位 0.0</param>
        /// <param name="bolt_standard">螺栓等级，默认值 "HS10.9"</param>
        /// <param name="bolt_size">螺栓尺寸，默认值 20.0</param>
        /// <param name="bolttype">车间(true)或现场(false)，默认值 true</param>
        /// <param name="tolerance">孔公差，默认值 2.0</param>
        /// <param name="bolt">螺栓(true)或孔(false)，默认值 true</param>
        /// <param name="washer1">是否使用垫圈1，默认值 true</param>
        /// <param name="washer2">是否使用垫圈2，默认值 true</param>
        /// <param name="washer3">是否使用垫圈3，默认值 true</param>
        /// <param name="nut1">是否使用螺母1，默认值 true</param>
        /// <param name="nut2">是否使用螺母1，默认值 true</param>
        /// <returns>创建的环形螺栓组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BoltCircle CreatBoltCircle(
            Part boltTo,
            Part beBolted,
            IEnumerable<Part> otherBeBolted,
            Point firstPosition,
            Point secondPosition,
            int num = 8,
            double diameter = 200.0,
            Position position = default,
            string bolt_standard = "HS10.9",
            double bolt_size = 20.0,
            BoltGroup.BoltTypeEnum bolttype = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
            double tolerance = 2.0,
            bool bolt = true,
            bool washer1 = true,
            bool washer2 = true,
            bool washer3 = true,
            bool nut1 = true,
            bool nut2 = true) {

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

            var boltCircle = new BoltCircle {
                PartToBoltTo = boltTo,
                PartToBeBolted = beBolted,
                FirstPosition = firstPosition,
                SecondPosition = secondPosition,
                NumberOfBolts = num,
                Diameter = diameter,
                Position = position,
                BoltStandard = bolt_standard,
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
                foreach (var part in otherBeBolted) {
                    boltCircle.AddOtherPartToBolt(part);
                }
            }

            if (!boltCircle.Insert())
                throw new Exception("Failed to insert BoltCircle.");

            return boltCircle;
        }

        /// <summary>
        /// 创建列表螺栓组。
        /// </summary>
        /// <param name="boltTo">栓接到的零件</param>
        /// <param name="beBolted">要栓接的零件</param>
        /// <param name="otherBeBolted">其他要栓接的零件集合</param>
        /// <param name="firstPosition">第一定位点</param>
        /// <param name="secondPosition">第二定位点</param>
        /// <param name="bolt_dist_X">X方向距离列</param>
        /// <param name="bolt_dist_Y">Y方向距离列</param>
        /// <param name="position">螺栓组定位，默认值旋转定位 <see cref="Position.RotationEnum.TOP"/>，平面定位 0.0，深度定位 0.0</param>
        /// <param name="startOffset">起点偏移值，默认值 new Offset()</param>
        /// <param name="endOffset">终点偏移值，默认值 new Offset()</param>
        /// <param name="bolt_standard">螺栓等级，默认值 "HS10.9"</param>
        /// <param name="bolt_size">螺栓尺寸，默认值 20.0</param>
        /// <param name="bolttype">车间(true)或现场(false)，默认值 true</param>
        /// <param name="tolerance">孔公差，默认值 2.0</param>
        /// <param name="bolt">螺栓(true)或孔(false)，默认值 true</param>
        /// <param name="washer1">是否使用垫圈1，默认值 true</param>
        /// <param name="washer2">是否使用垫圈2，默认值 true</param>
        /// <param name="washer3">是否使用垫圈3，默认值 true</param>
        /// <param name="nut1">是否使用螺母1，默认值 true</param>
        /// <param name="nut2">是否使用螺母1，默认值 true</param>
        /// <returns>创建的阵列螺栓组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="bolt_dist_X"/> 或 <paramref name="bolt_dist_Y"/>
        /// 中元素数量少于 1 时引发。</exception>
        public static BoltXYList CreatBoltXYList(
            Part boltTo,
            Part beBolted,
            IEnumerable<Part> otherBeBolted,
            Point firstPosition,
            Point secondPosition,
            DistanceList bolt_dist_X,
            DistanceList bolt_dist_Y,
            Position position = default,
            Offset startOffset = default,
            Offset endOffset = default,
            string bolt_standard = "HS10.9",
            double bolt_size = 20.0,
            BoltGroup.BoltTypeEnum bolttype = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
            double tolerance = 2.0,
            bool bolt = true,
            bool washer1 = true,
            bool washer2 = true,
            bool washer3 = true,
            bool nut1 = true,
            bool nut2 = true) {

            if (boltTo is null) {
                throw new ArgumentNullException(nameof(boltTo));
            }

            if (firstPosition is null) {
                throw new ArgumentNullException(nameof(firstPosition));
            }

            if (secondPosition is null) {
                throw new ArgumentNullException(nameof(secondPosition));
            }

            if (bolt_dist_X.Count < 1)
                throw new ArgumentException($"“{nameof(bolt_dist_X)}”中项目数至少需要1个。");

            if (bolt_dist_Y.Count < 1)
                throw new ArgumentException($"“{nameof(bolt_dist_Y)}”中项目数至少需要1个。");

            if (position == null) position = new Position { Rotation = Position.RotationEnum.TOP };

            if (startOffset == null) startOffset = new Offset();

            if (endOffset == null) endOffset = new Offset();

            var boltXYList = new BoltXYList {
                PartToBoltTo = boltTo,
                PartToBeBolted = beBolted,
                FirstPosition = firstPosition,
                SecondPosition = secondPosition,
                Position = position,
                StartPointOffset = startOffset,
                EndPointOffset = endOffset,
                BoltStandard = bolt_standard,
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
                foreach (var part in otherBeBolted) {
                    boltXYList.AddOtherPartToBolt(part);
                }
            }

            foreach (var d in bolt_dist_X) {
                boltXYList.AddBoltDistX(d.Value);
            }

            foreach (var d in bolt_dist_Y) {
                boltXYList.AddBoltDistY(d.Value);
            }

            if (!boltXYList.Insert())
                throw new Exception("Failed to insert BoltXYList.");

            return boltXYList;

        }
        /// <summary>
        /// 沿给定轴线每隔给定角度旋转复制一份对象。
        /// </summary>
        /// <param name="obj">要旋转复制的对象</param>
        /// <param name="Axis_Origin">旋转轴起点</param>
        /// <param name="Axis_Direction">旋转轴方向</param>
        /// <param name="radians">旋转角度，弧度制</param>
        /// <param name="num">要复制的数量，默认值 1</param>
        /// <returns>成功旋转复制的对象集合（不包括初始对象）。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="num"/> &lt;= 0 时引发。</exception>
        [Obsolete("应改为使用 Muggle.TeklaPlugins.Model.ModelOperation.CopyObject(ModelObject obj, Matrix matrix, int num)方法", true)]
        public static List<ModelObject> Copy_Rotate(
            ModelObject obj,
            Point Axis_Origin,
            Vector Axis_Direction,
            double radians,
            int num = 1) {

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
                throw new ArgumentException($"“{nameof(num)}”不应小于等于 0。");

            var objs = new List<ModelObject>();
            ModelObject copy;

            for (int i = 1; i <= num; i++) {
                copy = Tekla.Structures.Model.Operations.Operation.CopyObject(obj, new Vector());
                if (Move_Rotate(copy, Axis_Origin, Axis_Direction, radians * i)) objs.Add(copy);
            }

            return objs;
        }
        /// <summary>
        /// 沿给定轴线和角度旋转移动对象。
        /// </summary>
        /// <param name="obj">要旋转移动的对象</param>
        /// <param name="Axis_Origin">旋转轴起点</param>
        /// <param name="Axis_Direction">旋转轴方向</param>
        /// <param name="radians">旋转角度，弧度制</param>
        /// <returns>成功返回 True，失败返回 False。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Obsolete("应改为使用 Muggle.TeklaPlugins.Model.ModelOperation.MoveObject(ModelObject obj, Matrix matrix)方法", true)]
        public static bool Move_Rotate(
            ModelObject obj,
            Point Axis_Origin,
            Vector Axis_Direction,
            double radians) {

            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            if (Axis_Origin is null) {
                throw new ArgumentNullException(nameof(Axis_Origin));
            }

            if (Axis_Direction is null) {
                throw new ArgumentNullException(nameof(Axis_Direction));
            }

            var matrix = MatrixFactoryExtension.Rotate(new Line(Axis_Origin, Axis_Direction), radians);
            var currentCS = new CoordinateSystem();
            var targetCS = matrix.Transform(currentCS);

            return Tekla.Structures.Model.Operations.Operation.MoveObject(obj, currentCS, targetCS);
        }
        /// <summary>
        /// 按给定矩阵移动模型对象。
        /// </summary>
        /// <param name="obj">要移动的模型对象</param>
        /// <param name="matrix">给定矩阵</param>
        /// <returns>成功返回 True，失败返回 False。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>由于 Tekla Open API 底层限制，
        /// 诸如镜像、缩放、切变等“变形”矩阵无法产生（完全）作用，
        /// 仅平移、旋转矩阵可产生作用。</remarks>
        public static bool MoveObject(ModelObject obj, Matrix matrix) {
            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            var currentCS = new CoordinateSystem();
            var targetCS = matrix.Transform(currentCS);

            return Tekla.Structures.Model.Operations.Operation.MoveObject(obj, currentCS, targetCS);
        }
        /// <summary>
        /// 按给定矩阵连续复制模型对象。
        /// </summary>
        /// <param name="obj">要复制的模型对象</param>
        /// <param name="matrix">给定矩阵</param>
        /// <param name="num">复制份数，默认值 1</param>
        /// <returns>成功复制的对象集合（不包括初始对象）。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"><paramref name="num"/> &lt;= 0 时引发。</exception>
        /// <remarks>由于 Tekla Open API 底层限制，
        /// 诸如镜像、缩放、切变等“变形”矩阵无法产生（完全）作用，
        /// 仅平移、旋转矩阵可产生作用。</remarks>
        public static List<ModelObject> CopyObject(ModelObject obj, Matrix matrix, int num = 1) {
            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (num <= 0)
                throw new ArgumentException($"“{nameof(num)}”应大于 0。", nameof(num));

            var objs = new List<ModelObject>();
            var zeroVector = new Vector();
            ModelObject copy = obj;

            for (int i = 0; i < num; i++) {
                copy = Tekla.Structures.Model.Operations.Operation.CopyObject(copy, zeroVector);
                if (MoveObject(copy, matrix)) objs.Add(copy);
            }

            return objs;
        }
    }
}
