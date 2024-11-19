using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace MuggleTeklaPlugins.Common.Operation {
    [Obsolete]
    public class StringCompression {
        /// <summary>
        /// 压缩字符串。
        /// </summary>
        /// <param name="rawString">原始字符串</param>
        /// <returns>压缩后的字符串。</returns>
        /// <exception cref="ArgumentException"></exception>
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
        /// <exception cref="ArgumentException"></exception>
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
        /// <para><b>
        ///     * 应仅用于对 <see cref="DoubleToString(double)"/> 输出的字符串进行转换。
        ///     对其他途径产生的字符串进行转换，输出结果可能不正确。
        /// </b></para>
        /// </summary>
        /// <param name="StrValue">要转换的字符串</param>
        /// <returns>转换后的double值。</returns>
        public static double StringToDouble(string StrValue) {
            return BitConverter.ToDouble(Convert.FromBase64String(StrValue), 0);
        }
    }
}
