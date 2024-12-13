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
 *  ProfileRect_Invariant.cs: profile of invariant rect
 *  written by Huang YongXing
 *==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muggle.TeklaPlugins.Common.Profile {
    /// <summary>
    /// 矩形管（等截面形式）。适用如下形式：
    /// <br/><see cref="PatternCollection.CFH_J_1"/>：<inheritdoc cref="PatternCollection.CFH_J_1"/>
    /// <br/><see cref="PatternCollection.CFH_J_2"/>：<inheritdoc cref="PatternCollection.CFH_J_2"/>
    /// <br/><see cref="PatternCollection.CFH_J_3"/>：<inheritdoc cref="PatternCollection.CFH_J_3"/>
    /// <br/><see cref="PatternCollection.RECT_1"/>：<inheritdoc cref="PatternCollection.RECT_1"/>
    /// <br/><see cref="PatternCollection.RECT_2"/>：<inheritdoc cref="PatternCollection.RECT_2"/>
    /// <br/><see cref="PatternCollection.RECT_3"/>：<inheritdoc cref="PatternCollection.RECT_3"/>
    /// <br/><see cref="PatternCollection.RECT_4"/>：<inheritdoc cref="PatternCollection.RECT_4"/>
    /// <br/><see cref="PatternCollection.RECT_5"/>：<inheritdoc cref="PatternCollection.RECT_5"/>
    /// </summary>
    public class ProfileRect_Invariant : ProfileRect {
        /// <inheritdoc cref="ProfileRect.ProfileText"/>
        public new string ProfileText {
            get { return base.ProfileText; }
            set {
                var temp = (h1, h2, b1, b2, s, t);
                base.ProfileText = value;
                if (h2 != h1 || b2 != b1) {
                    h1 = temp.h1;
                    h2 = temp.h2;
                    b1 = temp.b1;
                    b2 = temp.b2;
                    s = temp.s;
                    t = temp.t;

                    throw new UnAcceptableProfileException(value);
                }
            }
        }
        /// <summary>
        /// 创建各字段值均为 0.0 的实例。
        /// </summary>
        public ProfileRect_Invariant() : base() { }
        /// <summary>
        /// 根据给定截面文本创建实例，同时为字段赋值。
        /// </summary>
        /// <param name="profileText">给定截面文本</param>
        public ProfileRect_Invariant(string profileText) : base(profileText) {
            if (h2 != h1 || b2 != b1)
                throw new UnAcceptableProfileException(profileText);
        }
    }
}
