﻿using System;
using Tekla.Structures.Geometry3d;

namespace MuggleTeklaPlugins.Common.Geometry3d {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Line"/> 的扩展。
    /// </summary>
    public static class LineExtension {
        public enum OffsetDirectionEnum {
            LEFT,
            RIGHT
        }
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
}