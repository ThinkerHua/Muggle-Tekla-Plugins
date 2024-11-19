using System;
using Tekla.Structures.Geometry3d;

namespace MuggleTeklaPlugins.Common.Geometry3d {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="Matrix"/> 的扩展。
    /// </summary>
    public static class MatrixExtension {
        /// <summary>
        /// 计算矩阵的行列式。<b>* 非方阵行列式未定义，此处忽略矩阵的平移部分。</b>
        /// </summary>
        /// <returns>矩阵（线性变换部分）的行列式。</returns>
        /// <param name="matrix">当前矩阵</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static double Determinant(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            double det = 0;

            // det = M00 * M11 * M22 + M01 * M12 * M20 + M02 * M10 * M21
            //      -M00 * M12 * M21 - M01 * M10 * M22 - M02 * M11 * M20
            for (int i = 0; i < 3; i++) {
                det += matrix[0, (i + 0) % 3] * matrix[1, (i + 1) % 3] * matrix[2, (i + 2) % 3]
                     - matrix[0, (i + 0) % 3] * matrix[1, (i + 2) % 3] * matrix[2, (i + 1) % 3];
            }

            return det;
        }
        /// <summary>
        /// 克莱姆法则求解线性方程组。
        /// 系数项以列向量形式储存在矩阵的线性变换部分中，
        /// 常数项以行向量形式储存在矩阵的平移部分中。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <returns>以点的形式返回方程组的解。无解则返回null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Point Cramer(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            var m = new Matrix(matrix);
            var det = m.Determinant();
            if (det == 0) return null;

            for (int i = 0; i < 3; i++) {
                m[i, 0] = matrix[3, i];
            }
            var det1 = m.Determinant();

            for (int i = 0; i < 3; i++) {
                m[i, 0] = matrix[i, 0];
                m[i, 1] = matrix[3, i];
            }
            var det2 = m.Determinant();

            for (int i = 0; i < 3; i++) {
                m[i, 1] = matrix[i, 1];
                m[i, 2] = matrix[3, i];
            }
            var det3 = m.Determinant();

            return new Point(det1 / det, det2 / det, det3 / det);
        }
        public static Vector Transform(this Matrix matrix, Vector vector) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (vector is null) {
                throw new ArgumentNullException(nameof(vector));
            }

            //对于向量，可以只使用矩阵的旋转部分进行变换
            //也可使用完整矩阵对表示向量的点和零点进行变换后，生成新向量
            var head = matrix.Transform(vector);
            var tail = matrix.Transform(new Point());

            return new Vector(head - tail);
        }
        /// <summary>
        /// 使用当前矩阵变换给定坐标系。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <param name="coordinateSystem">给定坐标系</param>
        /// <returns>转换后的坐标系，X轴、Y轴向量标准化为1000。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CoordinateSystem Transform(this Matrix matrix, CoordinateSystem coordinateSystem) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (coordinateSystem is null) {
                throw new ArgumentNullException(nameof(coordinateSystem));
            }

            var transposed = matrix.GetTranspose();

            var origin = transposed.Transform(coordinateSystem.Origin);
            var axisX = Transform(transposed, coordinateSystem.AxisX);
            var axisY = Transform(transposed, coordinateSystem.AxisY);
            axisX.Normalize(1000);
            axisY.Normalize(1000);

            return new CoordinateSystem(origin, axisX, axisY);
        }
        /// <summary>
        /// 移除当前矩阵的平移部分，即仅保留旋转部分。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveTranslation(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix[3, 0] = matrix[3, 1] = matrix[3, 2] = 0;
        }
        /// <summary>
        /// 移除当前矩阵的旋转部分，即仅保留平移部分。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveRotation(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            var transposed = matrix.GetTranspose();
            var rotation = matrix.GetRotationPart();
            var translation = (transposed * rotation).GetTranspose();

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 2; j++) {
                    matrix[i, j] = translation[i, j];
                }
            }
        }
        /// <summary>
        /// 获取当前矩阵旋转部分的新矩阵。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <returns>矩阵旋转部分的新矩阵。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Matrix GetRotationPart(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            var m = new Matrix(matrix);
            m.RemoveTranslation();

            return m;
        }
        /// <summary>
        /// 获取当前矩阵平移部分的新矩阵。
        /// </summary>
        /// <param name="matrix">当前矩阵</param>
        /// <returns>矩阵平移部分的新矩阵。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Matrix GetTranslationPart(this Matrix matrix) {
            if (matrix is null) {
                throw new ArgumentNullException(nameof(matrix));
            }

            var m = new Matrix(matrix);
            m.RemoveRotation();

            return m;
        }
    }
}
