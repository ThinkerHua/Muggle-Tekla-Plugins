/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2024 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  StringCompression.cs: compression and decompression for string
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Muggle.TeklaPlugins.Common.Operation {
    /// <summary>
    /// 字符串压缩器。
    /// </summary>
    [Obsolete]
    public class StringCompression {
        /// <summary>
        /// 压缩字符串。
        /// </summary>
        /// <param name="rawString">原始字符串</param>
        /// <returns>压缩后的字符串。</returns>
        /// <exception cref="ArgumentException"><paramref name="rawString"/> 为 null 或 <see cref="string.Empty"/> 时引发。</exception>
        public static string Compress(string rawString) {
            if (string.IsNullOrEmpty(rawString)) {
                throw new ArgumentException($"“{nameof(rawString)}”不能为 null 或空。", nameof(rawString));
            }

            var rawData = Encoding.UTF8.GetBytes(rawString);
            var zippedData = Compress(rawData);

            return Convert.ToBase64String(zippedData);
        }
        /// <summary>
        /// 解压缩字符串。
        /// </summary>
        /// <param name="zippedString">压缩的字符串</param>
        /// <returns>解压后的（原始）字符串。</returns>
        /// <exception cref="ArgumentException"><paramref name="zippedString"/> 为 null 或 <see cref="string.Empty"/> 时引发。</exception>
        public static string Decompress(string zippedString) {
            if (string.IsNullOrEmpty(zippedString)) {
                throw new ArgumentException($"“{nameof(zippedString)}”不能为 null 或空。", nameof(zippedString));
            }

            var zippedData = Convert.FromBase64String(zippedString);
            var rawData = Decompress(zippedData);

            return Encoding.UTF8.GetString(rawData);
        }
        /// <summary>
        /// 压缩字节数组。
        /// </summary>
        /// <param name="rawData">原始字节数组</param>
        /// <returns>压缩后的字节数组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static byte[] Compress(byte[] rawData) {
            if (rawData is null) {
                throw new ArgumentNullException(nameof(rawData));
            }

            var memoryStream = new MemoryStream();
            var compressGZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);
            compressGZipStream.Write(rawData, 0, rawData.Length);
            compressGZipStream.Close();

            return memoryStream.ToArray();
        }
        /// <summary>
        /// 解压缩字节数组。
        /// </summary>
        /// <param name="zippedData">压缩的字节数组</param>
        /// <returns>解压后的（原始）字节数组。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static byte[] Decompress(byte[] zippedData) {
            if (zippedData is null) {
                throw new ArgumentNullException(nameof(zippedData));
            }

            var memoryStream = new MemoryStream(zippedData);
            var decompressGZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            var outBuffer = new MemoryStream();
            var block = new byte[1024];
            while (true) {
                int bytesRead = decompressGZipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;

                outBuffer.Write(block, 0, bytesRead);
            }
            decompressGZipStream.Close();

            return outBuffer.ToArray();
        }
    }
}
