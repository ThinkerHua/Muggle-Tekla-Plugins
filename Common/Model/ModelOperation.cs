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

            if (assemblyPrefix is null) {
                assemblyPrefix = string.Empty;
            }

            if (partPrefix is null) {
                partPrefix = string.Empty;
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

            if (assemblyPrefix is null) {
                assemblyPrefix = string.Empty;
            }

            if (partPrefix is null) {
                partPrefix = string.Empty;
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

            if (assemblyPrefix is null) {
                assemblyPrefix = string.Empty;
            }

            if (partPrefix is null) {
                partPrefix = string.Empty;
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

            if (assemblyPrefix is null) {
                assemblyPrefix = string.Empty;
            }

            if (partPrefix is null) {
                partPrefix = string.Empty;
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

            if (assemblyPrefix is null) {
                assemblyPrefix = string.Empty;
            }

            if (partPrefix is null) {
                partPrefix = string.Empty;
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
        /// <param name="preparation">焊接准备，默认值 <see cref="BaseWeld.WeldPreparationTypeEnum.PREPARATION_NONE"/></param>
        /// <param name="typeAbove">上焊缝类型，默认值 <see cref="BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET"/></param>
        /// <param name="sizeAbove">上焊缝尺寸，默认值 6.0</param>
        /// <param name="angleAbove">上焊缝角度，默认值 0.0</param>
        /// <param name="typeBelow">下焊缝类型，默认值 <see cref="BaseWeld.WeldTypeEnum.WELD_TYPE_NONE"/></param>
        /// <param name="sizeBelow">下焊缝尺寸，默认值 0.0</param>
        /// <param name="angleBelow">下焊缝角度，默认值 0.0</param>
        /// <returns>创建的焊缝</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Weld CreatWeld(
            ModelObject mainObject,
            ModelObject secondaryObject,
            bool arroundWeld = true, 
            bool shopWeld = true,
            Weld.WeldPositionEnum position = Weld.WeldPositionEnum.WELD_POSITION_PLUS_X,
            BaseWeld.WeldPreparationTypeEnum preparation = BaseWeld.WeldPreparationTypeEnum.PREPARATION_NONE,
            Weld.WeldTypeEnum typeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET,
            double sizeAbove = 6.0,
            double angleAbove = 0.0,
            Weld.WeldTypeEnum typeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE,
            double sizeBelow = 0.0, 
            double angleBelow = 0.0) {

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
                Preparation = preparation,
                TypeAbove = typeAbove,
                SizeAbove = sizeAbove,
                AngleAbove = angleAbove,
                TypeBelow = typeBelow,
                SizeBelow = sizeBelow,
                AngleBelow = angleBelow,
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
        /// <param name="preparation">焊接准备，默认值 <see cref="BaseWeld.WeldPreparationTypeEnum.PREPARATION_NONE"/></param>
        /// <param name="typeAbove">上焊缝类型，默认值 <see cref="BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET"/></param>
        /// <param name="sizeAbove">上焊缝尺寸，默认值 6.0</param>
        /// <param name="angleAbove">上焊缝角度，默认值 0.0</param>
        /// <param name="typeBelow">下焊缝类型，默认值 <see cref="BaseWeld.WeldTypeEnum.WELD_TYPE_NONE"/></param>
        /// <param name="sizeBelow">下焊缝尺寸，默认值 0.0</param>
        /// <param name="angleBelow">下焊缝角度，默认值 0.0</param>
        /// <returns>创建的多边形焊缝</returns>
        public static PolygonWeld CreatPolygonWeld(
            ModelObject mainObject,
            ModelObject secondaryObject,
            Polygon polygon,
            bool arroundWeld = false,
            bool shopWeld = true,
            BaseWeld.WeldPreparationTypeEnum preparation = BaseWeld.WeldPreparationTypeEnum.PREPARATION_NONE,
            Weld.WeldTypeEnum typeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET,
            double sizeAbove = 6.0,
            double angleAbove = 0.0,
            Weld.WeldTypeEnum typeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE,
            double sizeBelow = 0.0,
            double angleBelow = 0.0) {

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
                ShopWeld = shopWeld,
                Preparation = preparation,
                TypeAbove = typeAbove,
                SizeAbove = sizeAbove,
                AngleAbove = angleAbove,
                TypeBelow = typeBelow,
                SizeBelow = sizeBelow,
                AngleBelow = angleBelow,
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
        /// 创建锚杆。
        /// </summary>
        /// <remarks>参考1047系统组件，锚杆、垫圈、螺母等均用零件模拟。</remarks>
        /// <param name="firstPosition">锚杆第一控制点，一般为底板底标高处</param>
        /// <param name="secondPosition">锚杆第二控制点</param>
        /// <param name="length1">锚杆上端至第一控制点长度</param>
        /// <param name="length2">锚杆第一控制点到螺纹截止处长度</param>
        /// <param name="length3">螺纹截止处到锚杆终点或第一弯折点长度</param>
        /// <param name="length4">锚杆第一弯折点到锚杆终点或第二弯折点长度，默认值 0.0</param>
        /// <param name="length5">锚杆第二弯折点到锚杆终点长度，默认值 0.0</param>
        /// <param name="hookDirection">弯钩朝向，不应与锚杆控制方向平行，默认值 null</param>
        /// <param name="bendRadiusFactor">弯曲半径相对于锚杆尺寸的系数，默认值 3.5</param>
        /// <param name="material">锚杆材质，默认值 "Q235B"</param>
        /// <param name="size">锚杆尺寸，默认值 20.0</param>
        /// <param name="tolerance">孔公差，默认值 2.0</param>
        /// <param name="class">等级，默认值 "0"</param>
        /// <param name="useWasherPlate">是否使用垫板，默认值 true</param>
        /// <param name="washerPlateThickness">垫板厚度，默认值 10.0</param>
        /// <param name="washerPlateWidth">垫板宽度，默认值 70.0</param>
        /// <param name="washerPlatePosition">垫板到锚杆第一控制点的距离，默认值 20.0</param>
        /// <param name="washerPlateHoleDiameter">垫板开孔孔径，默认值 26.0</param>
        /// <param name="useWasher1">是否使用垫圈1，默认值 true</param>
        /// <param name="useWasher2">是否使用垫圈2，默认值 true</param>
        /// <param name="useWasher3">是否使用垫圈3，默认值 true</param>
        /// <param name="useNut1">是否使用螺母1，默认值 true</param>
        /// <param name="useNut2">是否使用螺母2，默认值 true</param>
        /// <param name="useNut3">是否使用螺母3，默认值 true</param>
        /// <returns>创建的锚杆。</returns>
        public static List<Part> CreatAnchorRod(
            Point firstPosition,
            Point secondPosition,
            double length1,
            double length2,
            double length3,
            double length4 = 0.0,
            double length5 = 0.0,
            Vector hookDirection = null,
            double bendRadiusFactor = 3.5,
            string material = "Q235B",
            double size = 20.0,
            double tolerance = 2.0,
            string @class = "0",
            bool useWasherPlate = true,
            double washerPlateThickness = 10.0,
            double washerPlateWidth = 70.0,
            double washerPlatePosition = 20.0,
            double washerPlateHoleDiameter = 26.0,
            bool useWasher1 = true,
            bool useWasher2 = true,
            bool useWasher3 = true,
            bool useNut1 = true,
            bool useNut2 = true,
            bool useNut3 = true) {

            #region 参数检查
            if (firstPosition is null) {
                throw new ArgumentNullException(nameof(firstPosition));
            }

            if (secondPosition is null) {
                throw new ArgumentNullException(nameof(secondPosition));
            }

            var anchorDirection = new Vector(secondPosition - firstPosition).GetNormal();
            if (anchorDirection.IsZero()) {
                throw new ArgumentException($"锚杆控制方向不能为零向量。");
            }
            if (length4 > 0.0 || length5 > 0.0) {
                if (hookDirection is null) {
                    throw new ArgumentNullException(nameof(hookDirection));
                }

                if (hookDirection.IsZero()) {
                    throw new ArgumentException($"弯钩方向不能为零向量。");
                }

                var cross = anchorDirection.Cross(hookDirection);
                if (cross.IsZero()) {
                    throw new ArgumentException($"弯钩方向不能与锚杆控制方向平行。");
                }

                hookDirection = cross.Cross(anchorDirection).GetNormal();
            }

            if (string.IsNullOrEmpty(material)) {
                throw new ArgumentException($"“{nameof(material)}”不能为 null 或空。", nameof(material));
            }

            if (length1 <= 0.0) {
                throw new ArgumentException($"“{nameof(length1)}”不应小于等于 0。", nameof(length1));
            }
            if (length2 <= 0.0) {
                throw new ArgumentException($"“{nameof(length2)}”不应小于等于 0。", nameof(length2));
            }
            if (length3 <= 0.0) {
                throw new ArgumentException($"“{nameof(length3)}”不应小于等于 0。", nameof(length3));
            }
            if (length4 < 0.0) {
                throw new ArgumentException($"“{nameof(length4)}”不应小于 0。", nameof(length4));
            }
            if (length5 < 0.0) {
                throw new ArgumentException($"“{nameof(length5)}”不应小于 0。", nameof(length5));
            }
            if (size <= 0.0) {
                throw new ArgumentException($"“{nameof(size)}”不应小于等于 0。", nameof(size));
            }
            if (tolerance < 0.0) {
                throw new ArgumentException($"“{nameof(tolerance)}”不应小于 0。", nameof(tolerance));
            }

            if (useWasherPlate) {
                if (washerPlateThickness <= 0.0) {
                    throw new ArgumentException($"“{nameof(washerPlateThickness)}”不应小于等于 0。", nameof(washerPlateThickness));
                }
                if (washerPlateWidth <= 0.0) {
                    throw new ArgumentException($"“{nameof(washerPlateWidth)}”不应小于等于 0。", nameof(washerPlateWidth));
                }
                if (washerPlateHoleDiameter <= 0.0) {
                    throw new ArgumentException($"“{nameof(washerPlateHoleDiameter)}”不应小于等于 0。", nameof(washerPlateHoleDiameter));
                }
            }

            if (!useWasher1 && useWasher2) {
                useWasher1 = true;
                useWasher2 = false;
            }

            if (!useNut1 && useNut2) {
                useNut1 = true;
                useNut2 = false;
            }
            #endregion

            if (length5 > 0.0) {
                if (length5 < bendRadiusFactor * size) {
                    length5 = bendRadiusFactor * size;
                }

                if (length4 < 2 * bendRadiusFactor * size) {
                    length4 = 2 * bendRadiusFactor * size;
                }
            } else {
                if (length4 < bendRadiusFactor * size) {
                    length4 = bendRadiusFactor * size;
                }
            }

            Part anchorRod = null, screw = null, washerPlate = null,
                washer1 = null, washer2 = null, washer3 = null,
                nut1 = null, nut2 = null, nut3 = null;

            var point1 = firstPosition - anchorDirection * length1;
            var point2 = firstPosition + anchorDirection * length2;
            screw = CreatBeam(point1, point2, "SCREW", $"D{size - 1}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);

            var point3 = point2 + anchorDirection * length3;
            Point point4 = null, point5 = null, point6 = null;
            if (length4 == 0.0) {
                anchorRod = CreatBeam(point2, point3, "ANCHORROD", $"D{size}", material,
                    assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);
            } else {
                var chamferNone = new Chamfer();
                var chamferRounding = new Chamfer {
                    Type = Chamfer.ChamferTypeEnum.CHAMFER_ROUNDING,
                    X = bendRadiusFactor * size,
                    Y = bendRadiusFactor * size,
                };
                ContourPoint cp2, cp3, cp4, cp5;
                cp2 = new ContourPoint(point2, chamferNone);
                cp3 = new ContourPoint(point3, chamferRounding);

                point4 = point3 + hookDirection * length4;
                if (length5 == 0.0) {
                    cp4 = new ContourPoint(point4, chamferNone);

                    anchorRod = CreatPolyBeam(
                        new Contour { ContourPoints = new ArrayList { cp2, cp3, cp4 } },
                        "ANCHORROD", $"D{size}", material,
                        assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);
                } else {
                    point5 = point4 - anchorDirection * length5;
                    cp4 = new ContourPoint(point4, chamferRounding);
                    cp5 = new ContourPoint(point5, chamferNone);

                    anchorRod = CreatPolyBeam(
                        new Contour { ContourPoints = new ArrayList { cp2, cp3, cp4, cp5 } },
                        "ANCHORROD", $"D{size}", material,
                        assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);
                }
            }

            if (!useWasherPlate)
                goto SkipWasherPlate;
            point1 = firstPosition - anchorDirection * washerPlatePosition + hookDirection * (washerPlateWidth * 0.5);
            point2 = point1 - hookDirection * washerPlateWidth;
            washerPlate = CreatBeam(
                point1, point2, "WASHERPLATE", $"PL{washerPlateThickness}*{washerPlateWidth}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class, depthEnum: Position.DepthEnum.FRONT);

            point1 = firstPosition - anchorDirection * washerPlatePosition;
            point2 = point1 - anchorDirection * washerPlateThickness;
            var hole = CreatBeam(
                point1, point2, "HOLE", $"D{washerPlateHoleDiameter}", "ANTIMATERIAL",
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: BooleanPart.BooleanOperativeClassName);
            ApplyBooleanOperation(washerPlate, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
            hole.Delete();
        SkipWasherPlate:

            if (!useWasher1)
                goto SkipWasher1;
            point1 = firstPosition - anchorDirection * (washerPlatePosition + (useWasherPlate ? washerPlateThickness : 0.0));
            point2 = point1 - anchorDirection * (size * 0.5);
            washer1 = CreatBeam(
                point1, point2, "WASHER", $"O{size * 2 + 6}*{size * 0.5 + 3}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);
        SkipWasher1:

            if (!useWasher2)
                goto SkipWasher2;
            point1 = firstPosition - anchorDirection * (washerPlatePosition + (useWasherPlate ? washerPlateThickness : 0.0) + size * 0.5);
            point2 = point1 - anchorDirection * (size * 0.5);
            washer2 = CreatBeam(
                point1, point2, "WASHER", $"O{size * 2 + 6}*{size * 0.5 + 3}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);
        SkipWasher2:

            if (!useWasher3)
                goto SkipWasher3;
            point1 = firstPosition;
            point2 = point1 + anchorDirection * (size * 0.5);
            washer3 = CreatBeam(
                point1, point2, "WASHER", $"O{size * 2 + 6}*{size * 0.5 + 3}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class);
        SkipWasher3:

            var matrix = MatrixFactoryExtension.Rotate(new Line(firstPosition, secondPosition), Math.PI / 3);
            if (!useNut1)
                goto SkipNut1;
            point1 = firstPosition - anchorDirection *
                (washerPlatePosition + (useWasherPlate ? washerPlateThickness : 0.0) +
                (useWasher1 ? (useWasher2 ? size : size * 0.5) : 0.0)) + hookDirection * size;
            point2 = matrix.Transform(point1);
            point3 = matrix.Transform(point2);
            point4 = matrix.Transform(point3);
            point5 = matrix.Transform(point4);
            point6 = matrix.Transform(point5);
            nut1 = CreatContourPlate(
                new[] { point1, point2, point3, point4, point5, point6 }, "NUT", $"PL{size}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class, depthEnum: Position.DepthEnum.FRONT);
        SkipNut1:

            if (!useNut2)
                goto SkipNut2;
            point1 = firstPosition - anchorDirection *
                (washerPlatePosition + (useWasherPlate ? washerPlateThickness : 0.0) +
                (useWasher1 ? (useWasher2 ? size : size * 0.5) : 0.0) +
                (useNut1 ? size : 0.0)) + hookDirection * size;
            point2 = matrix.Transform(point1);
            point3 = matrix.Transform(point2);
            point4 = matrix.Transform(point3);
            point5 = matrix.Transform(point4);
            point6 = matrix.Transform(point5);
            nut2 = CreatContourPlate(
                new[] { point1, point2, point3, point4, point5, point6 }, "NUT", $"PL{size}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class, depthEnum: Position.DepthEnum.FRONT);
        SkipNut2:

            if (!useNut3)
                goto SkipNut3;
            point1 = firstPosition + anchorDirection * (useWasher3 ? size * 0.5 : 0.0) + hookDirection * size;
            point2 = matrix.Transform(point1);
            point3 = matrix.Transform(point2);
            point4 = matrix.Transform(point3);
            point5 = matrix.Transform(point4);
            point6 = matrix.Transform(point5);
            nut3 = CreatContourPlate(
                new[] { point1, point2, point3, point4, point5, point6 }, "NUT", $"PL{size}", material,
                assemblyPrefix: string.Empty, partPrefix: string.Empty, @class: @class, depthEnum: Position.DepthEnum.BEHIND);
        SkipNut3:

            ApplyBooleanOperation(anchorRod, screw, BooleanPart.BooleanTypeEnum.BOOLEAN_ADD);

            var parts = new List<Part> { anchorRod };

            hole = CreatBeam(
                firstPosition + anchorDirection * (size * 1.5),
                firstPosition - anchorDirection * (washerPlatePosition + washerPlateThickness + size * 3),
                "HOLE", $"D{size}", "ANTIMATERIAL", @class: BooleanPart.BooleanOperativeClassName,
                assemblyPrefix: string.Empty, partPrefix: string.Empty);
            if (washer1 != null) {
                ApplyBooleanOperation(washer1, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
                parts.Add(washer1);
            }
            if (washer2 != null) {
                ApplyBooleanOperation(washer2, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
                parts.Add(washer2);
            }
            if (washer3 != null) {
                ApplyBooleanOperation(washer3, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
                parts.Add(washer3);
            }
            if (nut1 != null) {
                ApplyBooleanOperation(nut1, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
                parts.Add(nut1);
            }
            if (nut2 != null) {
                ApplyBooleanOperation(nut2, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
                parts.Add(nut2);
            }
            if (nut3 != null) {
                ApplyBooleanOperation(nut3, hole, BooleanPart.BooleanTypeEnum.BOOLEAN_CUT);
                parts.Add(nut3);
            }
            hole.Delete();

            return parts;
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
