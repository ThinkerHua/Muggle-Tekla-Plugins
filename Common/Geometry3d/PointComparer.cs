using System.Collections.Generic;
using Tekla.Structures.Geometry3d;

namespace MuggleTeklaPlugins.Common.Geometry3d {
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
}
