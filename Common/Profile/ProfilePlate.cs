using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// 板。适用如下形式：
    /// <br/><see cref="PatternCollection.PL_1"/>：<inheritdoc cref="PatternCollection.PL_1"/>
    /// </summary>
    public class ProfilePlate : ProfileBase, IProfile {
        private string _profileText;
        /// <summary>
        /// 
        /// </summary>
        public double t, b, l;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        /// <summary>
        /// 创建各字段值均为 0.0 的实例。
        /// </summary>
        public ProfilePlate() { }
        /// <summary>
        /// 根据给定截面文本创建实例，同时为字段赋值。
        /// </summary>
        /// <param name="profileText">给定截面文本</param>
        public ProfilePlate(string profileText) {
            ProfileText = profileText;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void SetFieldsValues() {
            t = b = l = 0;
            if (ProfileText == null || ProfileText == string.Empty)
                throw new UnAcceptableProfileException(ProfileText);

            Match match = Regex.Match(ProfileText, PatternCollection.PL_1);
            if (!match.Success)
                throw new UnAcceptableProfileException(ProfileText);

            double.TryParse(match.Groups["t"].Value, out t);
            double.TryParse(match.Groups["b"].Value, out b);
            double.TryParse(match.Groups["l"].Value, out l);
        }
    }
}
