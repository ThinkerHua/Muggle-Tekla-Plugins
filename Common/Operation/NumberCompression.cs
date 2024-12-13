/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures             
 *                                                                            
 *  Copyright © 2024 Huang YongXing (thinkerhua@hotmail.com).                 
 *                                                                            
 *  This library is free software, licensed under the terms of the GNU        
 *  General Public License as published by the Free Software Foundation,      
 *  either version 3 of the License, or (at your option) any later version.   
 *  You should have received a copy of the GNU General Public License         
 *  along with this program. If not, see <http://www.gnu.org/licenses/>.      
 *==============================================================================
 *  NumberCompression.cs: compression and decompression for number
 *  written by Huang YongXing
 *==============================================================================*/
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
