﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// 圆钢或圆管（通用形式，含椭圆）。适用如下形式：
    /// <br/><see cref="PatternCollection.CIRC_1"/>：<inheritdoc cref="PatternCollection.CIRC_1"/>
    /// <br/><see cref="PatternCollection.CIRC_2"/>：<inheritdoc cref="PatternCollection.CIRC_2"/>
    /// <br/><see cref="PatternCollection.CIRC_3"/>：<inheritdoc cref="PatternCollection.CIRC_3"/>
    /// <br/><see cref="PatternCollection.CIRC_4"/>：<inheritdoc cref="PatternCollection.CIRC_4"/>
    /// <br/><see cref="PatternCollection.CIRC_5"/>：<inheritdoc cref="PatternCollection.CIRC_5"/>
    /// </summary>
    public class ProfileCircular : ProfileBase, IProfile {
        private string _profileText;
        /// <summary>
        /// 
        /// </summary>
        public double d1, r1, d2, r2, t;
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
        public ProfileCircular() { }
        /// <summary>
        /// 根据给定截面文本创建实例，同时为字段赋值。
        /// </summary>
        /// <param name="profileText">给定截面文本</param>
        public ProfileCircular(string profileText) {
            ProfileText = profileText;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void SetFieldsValues() {
            d1 = r1 = d2 = r2 = t = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfileException(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.CIRC_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_3);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_4);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_5);
                if (!match.Success)
                    throw new UnAcceptableProfileException(ProfileText);

                double.TryParse(match.Groups["d1"].Value, out d1);
                double.TryParse(match.Groups["r1"].Value, out r1);
                double.TryParse(match.Groups["d2"].Value, out d2);
                double.TryParse(match.Groups["r2"].Value, out r2);
                double.TryParse(match.Groups["t"].Value, out t);

                if (r1 == 0) r1 = d1;
                if (d2 == 0) d2 = d1;
                if (r2 == 0) r2 = r1;
            } catch (UnAcceptableProfileException) {
                d1 = r1 = d2 = r2 = t = 0;
                throw;
            }
        }
    }
}
