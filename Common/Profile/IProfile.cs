using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// 定义型材截面的属性、方法。
    /// </summary>
    public interface IProfile {
        /// <summary>
        /// 截面文本
        /// </summary>
        string ProfileText { get; set; }
    }
}
