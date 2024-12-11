using System;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Muggle.TeklaPlugins.Common.Model {
    /// <summary>
    /// <see cref="Tekla.Structures.Model"/>.<see cref="Polygon"/> 的扩展。
    /// </summary>
    public static class PolygonExtension {
        /// <summary>
        /// 克隆一个实例。
        /// </summary>
        /// <param name="polygon">当前实例</param>
        /// <returns>克隆的实例。</returns>
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
}
