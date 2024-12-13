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
 *  ProfilePlate.cs: profile of plate
 *  written by Huang YongXing
 *==============================================================================*/
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
    public class ProfilePlate : IProfile {
        private string _profileText;
        private ProfileTextChangedEventHandler _profileTextChangedEventHandler;
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
        public ProfilePlate() {
            ProfileTextChanged += OnProfileTextChanged;
        }
        /// <summary>
        /// 根据给定截面文本创建实例，同时为字段赋值。
        /// </summary>
        /// <param name="profileText">给定截面文本</param>
        public ProfilePlate(string profileText) {
            ProfileTextChanged += OnProfileTextChanged;
            ProfileText = profileText;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="profile"><inheritdoc path="/param[1]"/></param>
        /// <param name="args"><inheritdoc path="/param[2]"/></param>
        /// <exception cref="UnAcceptableProfileException"></exception>
        public void OnProfileTextChanged(IProfile profile, ProfileTextChangedEventArgs args) {
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
