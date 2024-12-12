using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// 不支持的截面或不支持的截面参数引发的异常。
    /// </summary>
    public class UnAcceptableProfileException : Exception {
        private readonly string _message;
        /// <summary>
        /// 创建引发异常的信息为空的实例。
        /// </summary>
        public UnAcceptableProfileException() { }
        /// <summary>
        /// 根据给定引发异常的信息创建实例。
        /// </summary>
        /// <param name="message">引发异常的信息</param>
        public UnAcceptableProfileException(string message) {
            _message = message;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override public string ToString() {
            return $"不支持此类型截面 或 不支持此类型截面的当前参数：\n{_message}";
        }
    }
}
