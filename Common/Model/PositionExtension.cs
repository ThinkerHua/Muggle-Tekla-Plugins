using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Muggle.TeklaPlugins.Common.Model {
    /// <summary>
    /// <see cref="Tekla.Structures.Model"/>.<see cref="Position"/> 的扩展。
    /// </summary>
    public static class PositionExtension {
        /// <summary>
        /// 克隆一个实例。
        /// </summary>
        /// <param name="position">当前实例</param>
        /// <returns>克隆的实例。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Position Clone(this Position position) {
            if (position is null) {
                throw new ArgumentNullException(nameof(position));
            }

            return new Position() {
                Plane = position.Plane,
                PlaneOffset = position.PlaneOffset,
                Rotation = position.Rotation,
                RotationOffset = position.RotationOffset,
                Depth = position.Depth,
                DepthOffset = position.DepthOffset,
            };
        }
    }
}
