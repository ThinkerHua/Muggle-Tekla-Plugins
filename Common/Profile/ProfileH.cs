using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// H型钢（通用形式）。适用如下形式：
    /// <br/><see cref="PatternCollection.H_1"/>：<inheritdoc cref="PatternCollection.H_1"/>
    /// <br/><see cref="PatternCollection.H_2"/>：<inheritdoc cref="PatternCollection.H_2"/>
    /// <br/><see cref="PatternCollection.H_4"/>：<inheritdoc cref="PatternCollection.H_4"/>
    /// <br/><see cref="PatternCollection.H_5"/>：<inheritdoc cref="PatternCollection.H_5"/>
    /// <br/><see cref="PatternCollection.H_6"/>：<inheritdoc cref="PatternCollection.H_6"/>
    /// <br/><see cref="PatternCollection.H_7"/>：<inheritdoc cref="PatternCollection.H_7"/>
    /// </summary>
    public class ProfileH : IProfile {
        private string _profileText;
        private ProfileTextChangedEventHandler _profileTextChangedEventHandler;
        /// <summary>
        /// 
        /// </summary>
        public double h1, h2, b1, b2, s, t1, t2;


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ProfileText {
            get => _profileText;
            set {
                var eventArgs = new ProfileTextChangedEventArgs(_profileText, value);
                _profileText = value;
                _profileTextChangedEventHandler?.Invoke(this, eventArgs);
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event ProfileTextChangedEventHandler ProfileTextChanged {
            add {
                _profileTextChangedEventHandler += value;
            }
            remove {
                _profileTextChangedEventHandler -= value;
            }
        }
        /// <summary>
        /// 创建各字段值均为 0.0 的实例。
        /// </summary>
        public ProfileH() {
            ProfileTextChanged += OnProfileTextChanged;
        }
        /// <summary>
        /// 根据给定截面文本创建实例，同时为字段赋值。
        /// </summary>
        /// <param name="profileText">给定截面文本</param>
        public ProfileH(string profileText) {
            ProfileTextChanged += OnProfileTextChanged;
            ProfileText = profileText;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="profile"><inheritdoc path="/param[1]"/></param>
        /// <param name="args"><inheritdoc path="/param[2]"/></param>
        public void OnProfileTextChanged(IProfile profile, ProfileTextChangedEventArgs args) {
            h1 = h2 = b1 = b2 = s = t1 = t2 = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfileException(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.H_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_4);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_5);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_6);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_7);
                if (!match.Success)
                    throw new UnAcceptableProfileException(ProfileText);

                double.TryParse(match.Groups["h1"].Value, out h1);
                double.TryParse(match.Groups["h2"].Value, out h2);
                double.TryParse(match.Groups["b1"].Value, out b1);
                double.TryParse(match.Groups["b2"].Value, out b2);
                double.TryParse(match.Groups["s"].Value, out s);
                double.TryParse(match.Groups["t1"].Value, out t1);
                double.TryParse(match.Groups["t2"].Value, out t2);

                if (h2 == 0) h2 = h1;
                if (b2 == 0) b2 = b1;
                if (t2 == 0) t2 = t1;
            } catch (UnAcceptableProfileException) {
                h1 = h2 = b1 = b2 = s = t1 = t2 = 0;
                throw;
            }
        }
    }
}
