using System;

using Tekla.Structures.Geometry3d;

namespace Muggle.TeklaPlugins.Common.Geometry3d {
    /// <summary>
    /// <see cref="Tekla.Structures.Geometry3d"/>.<see cref="CoordinateSystem"/> 的扩展。
    /// </summary>
    public static class CoordinateSystemExtension {
        /// <summary>
        /// 获取坐标系的字符串表示形式。
        /// </summary>
        /// <param name="cs">当前坐标系</param>
        /// <param name="format">复合格式字符串。默认值 null。</param>
        /// <returns>坐标系的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToString(this CoordinateSystem cs, string format = default) {
            if (cs is null) {
                throw new ArgumentNullException(nameof(cs));
            }

            return $"Origin = {cs.Origin.ToString(format)}\n" +
                $"AxisX = {cs.AxisX.ToString(format)}\n" +
                $"AxisY = {cs.AxisY.ToString(format)}\n";
        }
    }
}
