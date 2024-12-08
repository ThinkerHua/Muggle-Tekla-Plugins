using System.Collections.Generic;
using Tekla.Structures.Geometry3d;

namespace Muggle.TeklaPlugins.Common.Geometry3d {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Point"/> 类的比较器。
    /// </summary>
    public class PointComparer : IEqualityComparer<Point> {
        /// <summary>
        /// 判断给定两个点是否相等。
        /// </summary>
        /// <param name="point1">给定点1</param>
        /// <param name="point2">给定点2</param>
        /// <returns>相等返回 true，否则返回 false。</returns>
        public bool Equals(Point point1, Point point2) {
            if (object.ReferenceEquals(point1, point2)) return true;

            if (point1 is null || point2 is null) return false;

            return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
        }
        /// <summary>
        /// 获取给定点的哈希代码。
        /// </summary>
        /// <param name="point">给定点</param>
        /// <returns>给定点的哈希代码。</returns>
        public int GetHashCode(Point point) {
            if (point is null) return 0;

            return point.GetHashCode();
        }
    }
}
