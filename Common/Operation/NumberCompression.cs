using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Operation {
    /// <summary>
    /// 数值压缩器。
    /// </summary>
    public class NumberCompression {
        /// <summary>
        /// double转换成string。
        /// </summary>
        /// <param name="DValue">要转换的double值</param>
        /// <returns>转换后的字符串。</returns>
        public static string DoubleToString(double DValue) {
            return Convert.ToBase64String(BitConverter.GetBytes(DValue));
        }
        /// <summary>
        /// string转换成double。
        /// </summary>
        /// <remarks><b>* 应仅用于对 <see cref="DoubleToString(double)"/> 输出的字符串进行转换。
        /// 对其他途径产生的字符串进行转换，输出结果可能不正确。</b>
        /// </remarks>
        /// <param name="StrValue">要转换的字符串</param>
        /// <returns>转换后的double值。</returns>
        public static double StringToDouble(string StrValue) {
            return BitConverter.ToDouble(Convert.FromBase64String(StrValue), 0);
        }
    }
}
