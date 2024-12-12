using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// 截面文本变更事件消息。
    /// </summary>
    public class ProfileTextChangedEventArgs : EventArgs {
        /// <summary>
        /// 变更前截面文本。
        /// </summary>
        public string ProfileTextBeforeChanged { get; }
        /// <summary>
        /// 变更后截面文本。
        /// </summary>
        public string ProfileTextAfterChanged { get; }
        /// <summary>
        /// 使用变更前后的截面文本创建新消息实例。
        /// </summary>
        /// <param name="profileTextBeforeChanged">变更前截面文本</param>
        /// <param name="profileTextAfterChanged">变更后截面文本</param>
        public ProfileTextChangedEventArgs(string profileTextBeforeChanged, string profileTextAfterChanged) {
            if (profileTextBeforeChanged == null)
                ProfileTextBeforeChanged = string.Empty;
            else
                ProfileTextBeforeChanged = string.Copy(profileTextBeforeChanged);

            if (profileTextAfterChanged == null)
                ProfileTextAfterChanged = string.Empty;
            else
                ProfileTextAfterChanged = string.Copy(profileTextAfterChanged);
        }
    }
    /// <summary>
    /// 表示将用于处理截面文本变更事件的方法。
    /// </summary>
    /// <param name="profile">事件源</param>
    /// <param name="args">事件消息</param>
    public delegate void ProfileTextChangedEventHandler(IProfile profile, ProfileTextChangedEventArgs args);
    /// <summary>
    /// 定义型材截面的属性、方法。
    /// </summary>
    public interface IProfile {
        /// <summary>
        /// 截面文本
        /// </summary>
        string ProfileText { get; set; }
        /// <summary>
        /// 截面文本变更事件。
        /// </summary>
        event ProfileTextChangedEventHandler ProfileTextChanged;
        
        /*---------------此方法可以曝露吗？---------------*/
        /// <summary>
        /// 处理截面文本变更事件的方法。
        /// </summary>
        /// <param name="profile">事件源</param>
        /// <param name="args">事件消息</param>
        void OnProfileTextChanged(IProfile profile, ProfileTextChangedEventArgs args);
    }
}
