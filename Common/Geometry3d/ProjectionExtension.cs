using System;
using Tekla.Structures.Geometry3d;

namespace MuggleTeklaPlugins.Common.Geometry3d {
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
}
