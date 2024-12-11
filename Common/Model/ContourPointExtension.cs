using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Muggle.TeklaPlugins.Common.Model {
    /// <summary>
    /// <see cref="Tekla.Structures.Model"/>.<see cref="ContourPoint"/> 的扩展。
    /// </summary>
    public static class ContourPointExtension {
        /// <summary>
        /// 克隆一个实例。
        /// </summary>
        /// <param name="contourPoint">当前实例</param>
        /// <returns>克隆的实例。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContourPoint Clone(this ContourPoint contourPoint) {
            if (contourPoint is null) {
                throw new ArgumentNullException(nameof(contourPoint));
            }

            var point = new Point(contourPoint.X, contourPoint.Y, contourPoint.Z);
            var chamfer = new Chamfer() {
                Type = contourPoint.Chamfer.Type,
                X = contourPoint.Chamfer.X,
                Y = contourPoint.Chamfer.Y,
                DZ1 = contourPoint.Chamfer.DZ1,
                DZ2 = contourPoint.Chamfer.DZ2,
            };
            return new ContourPoint(point, chamfer);
        }
    }
}
