﻿/*==============================================================================
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
 *  ProfileCircular_Perfect.cs: profile of perfect circular
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
    /// 圆钢或圆管（正圆形式，不含椭圆，含正圆变截面）。适用如下形式：
    /// <br/><see cref="PatternCollection.CIRC_1"/>：<inheritdoc cref="PatternCollection.CIRC_1"/>
    /// <br/><see cref="PatternCollection.CIRC_2"/>：<inheritdoc cref="PatternCollection.CIRC_2"/>
    /// <br/><see cref="PatternCollection.CIRC_3"/>：<inheritdoc cref="PatternCollection.CIRC_3"/>
    /// </summary>
    public class ProfileCircular_Perfect : IProfile {
        private string _profileText;
        private ProfileTextChangedEventHandler _profileTextChangedEventHandler;
        /// <summary>
        /// 
        /// </summary>
        public double d1, d2, t;
        private static readonly ProfileCircular_Perfect[] _commonlyUsed = new ProfileCircular_Perfect[] {
            new ProfileCircular_Perfect{ ProfileText = "PIP32*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP32*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP32*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP32*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*16"},
        };


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ProfileText {
            get => _profileText;
            set {
                var eventArgs = new ProfileTextChangedEventArgs(_profileText,  value);
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
        /// 常用规格
        /// </summary>
        public static ProfileCircular_Perfect[] CommonlyUsed => _commonlyUsed;
        /// <summary>
        /// 创建各字段值均为 0.0 的实例。
        /// </summary>
        public ProfileCircular_Perfect() {
            ProfileTextChanged += OnProfileTextChanged;
        }
        /// <summary>
        /// 根据给定截面文本创建实例，同时为字段赋值。
        /// </summary>
        /// <param name="profileText">给定截面文本</param>
        public ProfileCircular_Perfect(string profileText) {
            ProfileTextChanged += OnProfileTextChanged;
            ProfileText = profileText;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="profile"><inheritdoc path="/param[1]"/></param>
        /// <param name="args"><inheritdoc path="/param[2]"/></param>
        public void OnProfileTextChanged(IProfile profile, ProfileTextChangedEventArgs args) {
            d1 = d2 = t = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfileException(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.CIRC_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_3);
                if (!match.Success)
                    throw new UnAcceptableProfileException(ProfileText);

                double.TryParse(match.Groups["d1"].Value, out d1);
                double.TryParse(match.Groups["d2"].Value, out d2);
                double.TryParse(match.Groups["t"].Value, out t);

                if (d2 == 0) d2 = d1;
            } catch (UnAcceptableProfileException) {
                d1 = d2 = t = 0;
                throw;
            }
        }
    }
}
