using System;
using Tekla.Structures.Geometry3d;

namespace Muggle.TeklaPlugins.Common.Geometry3d {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="MatrixFactory"/> 的扩展。
    /// </summary>
    public static class MatrixFactoryExtension {
        /// <summary>
        /// 使用给定向量创建平移矩阵。
        /// <para><b>
        ///     注：Tekla Open API内部，矩阵操作对象为坐标系。
        ///     参考官方库的<see cref="MatrixFactory.Rotate(double, Vector)"/> 方法，
        ///     产生的矩阵对向量进行变换操作，实际得到的结果是反方向旋转的。
        ///     因此，本方法创建的平移矩阵，也是以坐标系为操作对象的，
        ///     用所得矩阵对点进行变换，得到的结果是反方向移动的。
        /// </b></para>
        /// </summary>
        /// <param name="vector">给定向量</param>
        /// <returns>平移矩阵（线性变换部分为单位矩阵）。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Matrix Translate(Vector vector) {
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
}
