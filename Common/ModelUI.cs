using System;
using System.Collections.Generic;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

using MuggleTeklaPlugins.Geometry3dExtension;

namespace MuggleTeklaPlugins.ModelExtension.UIExtension {
    /// <summary>
    /// <see cref="Tekla.Structures.Model.UI"/>.<see cref="Color"/> 的扩展。
    /// <para>
    ///     参见"颜色码对照表.png"。
    ///     表中RGB值是通常定义的0~255整数，但官方文档定义取值范围为0.0~1.0，所以代码中的实际值做了转换，保留4位小数。
    /// </para>
    /// </summary>
    public static class ColorExtension {
        #region 预设属性
        /// <summary>
        /// 纯黑
        /// </summary>
        public static Color Black => new Color(0.0000, 0.0000, 0.0000);
        /// <summary>
        /// 海军蓝
        /// </summary>
        public static Color Navy => new Color(0.0000, 0.0000, 0.5020);
        /// <summary>
        /// 深蓝色
        /// </summary>
        public static Color DarkBlue => new Color(0.0000, 0.0000, 0.5451);
        /// <summary>
        /// 适中的蓝色
        /// </summary>
        public static Color MediumBlue => new Color(0.0000, 0.0000, 0.8039);
        /// <summary>
        /// 纯蓝
        /// </summary>
        public static Color Blue => new Color(0.0000, 0.0000, 1.0000);
        /// <summary>
        /// 深绿色
        /// </summary>
        public static Color DarkGreen => new Color(0.0000, 0.3922, 0.0000);
        /// <summary>
        /// 纯绿
        /// </summary>
        public static Color Green => new Color(0.0000, 0.5020, 0.0000);
        /// <summary>
        /// 水鸭色
        /// </summary>
        public static Color Teal => new Color(0.0000, 0.5020, 0.5020);
        /// <summary>
        /// 深青色
        /// </summary>
        public static Color DarkCyan => new Color(0.0000, 0.5451, 0.5451);
        /// <summary>
        /// 深天蓝
        /// </summary>
        public static Color DeepSkyBlue => new Color(0.0000, 0.7490, 1.0000);
        /// <summary>
        /// 深绿宝石
        /// </summary>
        public static Color DarkTurquoise => new Color(0.0000, 0.8078, 0.8196);
        /// <summary>
        /// 适中的碧绿色
        /// </summary>
        public static Color MediumAquamarine => new Color(0.0000, 0.9804, 0.6039);
        /// <summary>
        /// 酸橙色
        /// </summary>
        public static Color Lime => new Color(0.0000, 1.0000, 0.0000);
        /// <summary>
        /// 适中的春天的绿色
        /// </summary>
        public static Color MediumSpringGreen => new Color(0.0000, 1.0000, 0.4980);
        /// <summary>
        /// 青色
        /// </summary>
        public static Color Cyan => new Color(0.0000, 1.0000, 1.0000);
        /// <summary>
        /// 午夜的蓝色
        /// </summary>
        public static Color MidnightBlue => new Color(0.0980, 0.0980, 0.4392);
        /// <summary>
        /// 道奇蓝
        /// </summary>
        public static Color DoderBlue => new Color(0.1176, 0.5647, 1.0000);
        /// <summary>
        /// 浅海洋绿
        /// </summary>
        public static Color LightSeaGreen => new Color(0.1255, 0.6980, 0.6667);
        /// <summary>
        /// 森林绿
        /// </summary>
        public static Color ForestGreen => new Color(0.1333, 0.5451, 0.1333);
        /// <summary>
        /// 海洋绿
        /// </summary>
        public static Color SeaGreen => new Color(0.1804, 0.5451, 0.3412);
        /// <summary>
        /// 深石板灰
        /// </summary>
        public static Color DarkSlateGray => new Color(0.1843, 0.3098, 0.3098);
        /// <summary>
        /// 酸橙绿
        /// </summary>
        public static Color LimeGreen => new Color(0.1961, 0.8039, 0.1961);
        /// <summary>
        /// 春天的绿色
        /// </summary>
        public static Color SpringGreen => new Color(0.2353, 0.7020, 0.4431);
        /// <summary>
        /// 绿宝石
        /// </summary>
        public static Color Turquoise => new Color(0.2510, 0.8784, 0.8157);
        /// <summary>
        /// 皇家蓝
        /// </summary>
        public static Color RoyalBlue => new Color(0.2549, 0.4118, 0.8824);
        /// <summary>
        /// 钢蓝
        /// </summary>
        public static Color SteelBlue => new Color(0.2745, 0.5098, 0.7059);
        /// <summary>
        /// 深岩暗蓝灰色
        /// </summary>
        public static Color DarkSlateBlue => new Color(0.2824, 0.2392, 0.5451);
        /// <summary>
        /// 适中的绿宝石
        /// </summary>
        public static Color MediumTurquoise => new Color(0.2824, 0.8196, 0.8000);
        /// <summary>
        /// 靛青
        /// </summary>
        public static Color Indigo => new Color(0.2941, 0.0000, 0.5098);
        /// <summary>
        /// 橄榄土褐色
        /// </summary>
        public static Color OliveDrab => new Color(0.3333, 0.4196, 0.1843);
        /// <summary>
        /// 军校蓝
        /// </summary>
        public static Color CadetBlue => new Color(0.3725, 0.6196, 0.6275);
        /// <summary>
        /// 矢车菊的蓝色
        /// </summary>
        public static Color CornflowerBlue => new Color(0.3922, 0.5843, 0.9294);
        /// <summary>
        /// 暗淡的灰色
        /// </summary>
        public static Color DimGray => new Color(0.4118, 0.4118, 0.4118);
        /// <summary>
        /// 板岩暗蓝灰色
        /// </summary>
        public static Color SlateBlue => new Color(0.4157, 0.3529, 0.8039);
        /// <summary>
        /// 石板灰
        /// </summary>
        public static Color SlateGray => new Color(0.4392, 0.5020, 0.5647);
        /// <summary>
        /// 浅石板灰
        /// </summary>
        public static Color LightSlateGray => new Color(0.4667, 0.5333, 0.6000);
        /// <summary>
        /// 适中的板岩暗蓝灰色
        /// </summary>
        public static Color MediumSlateBlue => new Color(0.4824, 0.4078, 0.9333);
        /// <summary>
        /// 草坪绿
        /// </summary>
        public static Color LawnGreen => new Color(0.4863, 0.9882, 0.0000);
        /// <summary>
        /// 查特酒绿
        /// </summary>
        public static Color Chartreuse => new Color(0.4980, 1.0000, 0.0000);
        /// <summary>
        /// 绿玉\碧绿色
        /// </summary>
        public static Color Auqamarin => new Color(0.4980, 1.0000, 0.6667);
        /// <summary>
        /// 栗色
        /// </summary>
        public static Color Maroon => new Color(0.5020, 0.0000, 0.0000);
        /// <summary>
        /// 紫色
        /// </summary>
        public static Color Purple => new Color(0.5020, 0.0000, 0.5020);
        /// <summary>
        /// 橄榄
        /// </summary>
        public static Color Olive => new Color(0.5020, 0.5020, 0.0000);
        /// <summary>
        /// 灰色
        /// </summary>
        public static Color Gray => new Color(0.5020, 0.5020, 0.5020);
        /// <summary>
        /// 天蓝色
        /// </summary>
        public static Color SkyBlue => new Color(0.5294, 0.8078, 0.9216);
        /// <summary>
        /// 淡蓝色
        /// </summary>
        public static Color LightSkyBlue => new Color(0.5294, 0.8078, 0.9804);
        /// <summary>
        /// 深紫罗兰的蓝色
        /// </summary>
        public static Color BlueViolet => new Color(0.5412, 0.1686, 0.8863);
        /// <summary>
        /// 深红色
        /// </summary>
        public static Color DarkRed => new Color(0.5451, 0.0000, 0.0000);
        /// <summary>
        /// 深洋红色
        /// </summary>
        public static Color DarkMagenta => new Color(0.5451, 0.0000, 0.5451);
        /// <summary>
        /// 马鞍棕色
        /// </summary>
        public static Color SaddleBrown => new Color(0.5451, 0.2706, 0.0745);
        /// <summary>
        /// 深海洋绿
        /// </summary>
        public static Color DarkSeaGreen => new Color(0.5608, 0.7373, 0.5608);
        /// <summary>
        /// 淡绿色
        /// </summary>
        public static Color LightGreen => new Color(0.5647, 0.9333, 0.5647);
        /// <summary>
        /// 适中的紫色
        /// </summary>
        public static Color MediumPurple => new Color(0.5765, 0.4392, 0.8588);
        /// <summary>
        /// 深紫罗兰色
        /// </summary>
        public static Color DarkVoilet => new Color(0.5804, 0.0000, 0.8275);
        /// <summary>
        /// 苍白的绿色
        /// </summary>
        public static Color PaleGreen => new Color(0.5961, 0.9843, 0.5961);
        /// <summary>
        /// 深兰花紫
        /// </summary>
        public static Color DarkOrchid => new Color(0.6000, 0.1961, 0.8000);
        /// <summary>
        /// 黄土赭色
        /// </summary>
        public static Color Sienna => new Color(0.6275, 0.3216, 0.1765);
        /// <summary>
        /// 棕色
        /// </summary>
        public static Color Brown => new Color(0.6471, 0.1647, 0.1647);
        /// <summary>
        /// 深灰色
        /// </summary>
        public static Color DarkGray => new Color(0.6627, 0.6627, 0.6627);
        /// <summary>
        /// 淡蓝
        /// </summary>
        public static Color LightBLue => new Color(0.6784, 0.8471, 0.9020);
        /// <summary>
        /// 绿黄色
        /// </summary>
        public static Color GreenYellow => new Color(0.6784, 1.0000, 0.1843);
        /// <summary>
        /// 苍白的绿宝石
        /// </summary>
        public static Color PaleTurquoise => new Color(0.6863, 0.9333, 0.9333);
        /// <summary>
        /// 淡钢蓝
        /// </summary>
        public static Color LightSteelBlue => new Color(0.6902, 0.7686, 0.8706);
        /// <summary>
        /// 火药蓝
        /// </summary>
        public static Color PowDerBlue => new Color(0.6902, 0.8784, 0.9020);
        /// <summary>
        /// 耐火砖
        /// </summary>
        public static Color FireBrick => new Color(0.6980, 0.1333, 0.1333);
        /// <summary>
        /// 适中的兰花紫
        /// </summary>
        public static Color MediumOrchid => new Color(0.7294, 0.3333, 0.8275);
        /// <summary>
        /// 玫瑰棕色
        /// </summary>
        public static Color RosyBrown => new Color(0.7373, 0.5608, 0.5608);
        /// <summary>
        /// 深卡其布
        /// </summary>
        public static Color DarkKhaki => new Color(0.7412, 0.7176, 0.4196);
        /// <summary>
        /// 银白色
        /// </summary>
        public static Color Silver => new Color(0.7529, 0.7529, 0.7529);
        /// <summary>
        /// 适中的紫罗兰红色
        /// </summary>
        public static Color MediumVioletRed => new Color(0.7804, 0.0824, 0.5216);
        /// <summary>
        /// 印度红
        /// </summary>
        public static Color IndianRed => new Color(0.8039, 0.3608, 0.3608);
        /// <summary>
        /// 秘鲁
        /// </summary>
        public static Color Peru => new Color(0.8039, 0.5216, 0.2471);
        /// <summary>
        /// 巧克力
        /// </summary>
        public static Color Chocolate => new Color(0.8235, 0.4118, 0.1176);
        /// <summary>
        /// 晒黑
        /// </summary>
        public static Color Tan => new Color(0.8235, 0.7059, 0.5490);
        /// <summary>
        /// 浅灰色
        /// </summary>
        public static Color LightGrey => new Color(0.8275, 0.8275, 0.8275);
        /// <summary>
        /// 水绿色
        /// </summary>
        public static Color Aqua => new Color(0.8314, 0.9490, 0.9059);
        /// <summary>
        /// 蓟
        /// </summary>
        public static Color Thistle => new Color(0.8471, 0.7490, 0.8471);
        /// <summary>
        /// 兰花的紫色
        /// </summary>
        public static Color Orchid => new Color(0.8549, 0.4392, 0.8392);
        /// <summary>
        /// 秋麒麟
        /// </summary>
        public static Color GoldEnrod => new Color(0.8549, 0.6471, 0.1255);
        /// <summary>
        /// 苍白的紫罗兰红色
        /// </summary>
        public static Color PaleVioletRed => new Color(0.8588, 0.4392, 0.5765);
        /// <summary>
        /// 猩红
        /// </summary>
        public static Color Crimson => new Color(0.8627, 0.0784, 0.2353);
        /// <summary>
        /// 亮灰色
        /// </summary>
        public static Color Gainsboro => new Color(0.8627, 0.8627, 0.8627);
        /// <summary>
        /// 李子
        /// </summary>
        public static Color Plum => new Color(0.8667, 0.6275, 0.8667);
        /// <summary>
        /// 结实的树
        /// </summary>
        public static Color BrulyWood => new Color(0.8706, 0.7216, 0.5294);
        /// <summary>
        /// 淡青色
        /// </summary>
        public static Color LightCyan => new Color(0.8824, 1.0000, 1.0000);
        /// <summary>
        /// 熏衣草花的淡紫色
        /// </summary>
        public static Color Lavender => new Color(0.9020, 0.9020, 0.9804);
        /// <summary>
        /// 深鲜肉(鲑鱼)色
        /// </summary>
        public static Color DarkSalmon => new Color(0.9137, 0.5882, 0.4784);
        /// <summary>
        /// 紫罗兰
        /// </summary>
        public static Color Violet => new Color(0.9333, 0.5098, 0.9333);
        /// <summary>
        /// 灰秋麒麟
        /// </summary>
        public static Color PaleGodenrod => new Color(0.9333, 0.9098, 0.6667);
        /// <summary>
        /// 淡珊瑚色
        /// </summary>
        public static Color LightCoral => new Color(0.9412, 0.5020, 0.5020);
        /// <summary>
        /// 卡其布
        /// </summary>
        public static Color Khaki => new Color(0.9412, 0.9020, 0.5490);
        /// <summary>
        /// 爱丽丝蓝
        /// </summary>
        public static Color AliceBlue => new Color(0.9412, 0.9725, 1.0000);
        /// <summary>
        /// 蜂蜜
        /// </summary>
        public static Color Honeydew => new Color(0.9412, 1.0000, 0.9412);
        /// <summary>
        /// 蔚蓝色
        /// </summary>
        public static Color Azure => new Color(0.9412, 1.0000, 1.0000);
        /// <summary>
        /// 沙棕色
        /// </summary>
        public static Color SandyBrown => new Color(0.9569, 0.6431, 0.3765);
        /// <summary>
        /// 小麦色
        /// </summary>
        public static Color Wheat => new Color(0.9608, 0.8706, 0.7020);
        /// <summary>
        /// 米色(浅褐色)
        /// </summary>
        public static Color Beige => new Color(0.9608, 0.9608, 0.8627);
        /// <summary>
        /// 白烟
        /// </summary>
        public static Color WhiteSmoke => new Color(0.9608, 0.9608, 0.9608);
        /// <summary>
        /// 薄荷奶油
        /// </summary>
        public static Color MintCream => new Color(0.9608, 1.0000, 0.9804);
        /// <summary>
        /// 幽灵的白色
        /// </summary>
        public static Color GhostWhite => new Color(0.9725, 0.9725, 1.0000);
        /// <summary>
        /// 鲜肉(鲑鱼)色
        /// </summary>
        public static Color Salmon => new Color(0.9804, 0.5020, 0.4471);
        /// <summary>
        /// 古代的白色
        /// </summary>
        public static Color AntiqueWhite => new Color(0.9804, 0.9216, 0.8431);
        /// <summary>
        /// 亚麻布
        /// </summary>
        public static Color Linen => new Color(0.9804, 0.9412, 0.9020);
        /// <summary>
        /// 浅秋麒麟黄
        /// </summary>
        public static Color LightGoldenrodYellow => new Color(0.9804, 0.9804, 0.8235);
        /// <summary>
        /// 老饰带
        /// </summary>
        public static Color OldLace => new Color(0.9922, 0.9608, 0.9020);
        /// <summary>
        /// 纯红
        /// </summary>
        public static Color Red => new Color(1.0000, 0.0000, 0.0000);
        /// <summary>
        /// 洋红
        /// </summary>
        public static Color Magenta => new Color(1.0000, 0.0000, 1.0000);
        /// <summary>
        /// 灯笼海棠(紫红色)
        /// </summary>
        public static Color Fuchsia => new Color(1.0000, 0.0000, 1.0000);
        /// <summary>
        /// 深粉色
        /// </summary>
        public static Color DeepPink => new Color(1.0000, 0.0784, 0.5765);
        /// <summary>
        /// 橙红色
        /// </summary>
        public static Color OrangeRed => new Color(1.0000, 0.2706, 0.0000);
        /// <summary>
        /// 番茄
        /// </summary>
        public static Color Tomato => new Color(1.0000, 0.3882, 0.2784);
        /// <summary>
        /// 热情的粉红
        /// </summary>
        public static Color HotPink => new Color(1.0000, 0.4118, 0.7059);
        /// <summary>
        /// 珊瑚
        /// </summary>
        public static Color Coral => new Color(1.0000, 0.4980, 0.3137);
        /// <summary>
        /// 深橙色
        /// </summary>
        public static Color DarkOrange => new Color(1.0000, 0.5490, 0.0000);
        /// <summary>
        /// 浅鲜肉(鲑鱼)色
        /// </summary>
        public static Color LightSalmon => new Color(1.0000, 0.6275, 0.4784);
        /// <summary>
        /// 橙色
        /// </summary>
        public static Color Orange => new Color(1.0000, 0.6471, 0.0000);
        /// <summary>
        /// 浅粉红
        /// </summary>
        public static Color LightPink => new Color(1.0000, 0.7137, 0.7569);
        /// <summary>
        /// 粉红
        /// </summary>
        public static Color Pink => new Color(1.0000, 0.7529, 0.7961);
        /// <summary>
        /// 金
        /// </summary>
        public static Color Gold => new Color(1.0000, 0.8431, 0.0000);
        /// <summary>
        /// 桃色
        /// </summary>
        public static Color PeachPuff => new Color(1.0000, 0.8549, 0.7255);
        /// <summary>
        /// 纳瓦霍白
        /// </summary>
        public static Color NavajoWhite => new Color(1.0000, 0.8706, 0.6784);
        /// <summary>
        /// 鹿皮鞋
        /// </summary>
        public static Color Moccasin => new Color(1.0000, 0.8941, 0.7098);
        /// <summary>
        /// (浓汤)乳脂,番茄等
        /// </summary>
        public static Color Bisque => new Color(1.0000, 0.8941, 0.7686);
        /// <summary>
        /// 薄雾玫瑰
        /// </summary>
        public static Color MistyRose => new Color(1.0000, 0.8941, 0.8824);
        /// <summary>
        /// 漂白的杏仁
        /// </summary>
        public static Color BlanchedAlmond => new Color(1.0000, 0.9216, 0.8039);
        /// <summary>
        /// 番木瓜
        /// </summary>
        public static Color PapayaWhip => new Color(1.0000, 0.9373, 0.8353);
        /// <summary>
        /// 脸红的淡紫色
        /// </summary>
        public static Color LavenderBlush => new Color(1.0000, 0.9412, 0.9608);
        /// <summary>
        /// 海贝壳
        /// </summary>
        public static Color SeaShell => new Color(1.0000, 0.9608, 0.9333);
        /// <summary>
        /// 玉米色
        /// </summary>
        public static Color Cornislk => new Color(1.0000, 0.9725, 0.8627);
        /// <summary>
        /// 柠檬薄纱
        /// </summary>
        public static Color LemonChiffon => new Color(1.0000, 0.9804, 0.8039);
        /// <summary>
        /// 花的白色
        /// </summary>
        public static Color FloralWhite => new Color(1.0000, 0.9804, 0.9412);
        /// <summary>
        /// 雪
        /// </summary>
        public static Color Snow => new Color(1.0000, 0.9804, 0.9804);
        /// <summary>
        /// 纯黄
        /// </summary>
        public static Color Yellow => new Color(1.0000, 1.0000, 0.0000);
        /// <summary>
        /// 浅黄色
        /// </summary>
        public static Color LightYellow => new Color(1.0000, 1.0000, 0.8784);
        /// <summary>
        /// 象牙
        /// </summary>
        public static Color Ivory => new Color(1.0000, 1.0000, 0.9412);
        /// <summary>
        /// 纯白
        /// </summary>
        public static Color White => new Color(1.0000, 1.0000, 1.0000);
        #endregion
        /// <summary>
        /// 获取颜色的字符串表示形式。
        /// </summary>
        /// <param name="color">当前颜色</param>
        /// <param name="format">复合格式字符串。默认值 null。</param>
        /// <returns>颜色的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToString(this Color color, string format = default) {
            if (color is null) {
                throw new ArgumentNullException(nameof(color));
            }

            return $"({color.Red.ToString(format)}, " +
                $"{color.Green.ToString(format)}, " +
                $"{color.Blue.ToString(format)}, " +
                $"{color.Transparency.ToString(format)})";
        }
        /// <summary>
        /// 用给定颜色对当前颜色进行偏移。
        /// </summary>
        /// <param name="color">当前颜色</param>
        /// <param name="shifter">给定颜色</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Shift (this Color color, Color shifter) {
            if (color is null) {
                throw new ArgumentNullException(nameof(color));
            }

            if (shifter is null) {
                throw new ArgumentNullException(nameof(shifter));
            }

            double value;
            value = color.Red + shifter.Red;
            color.Red = value > 1.0 ? value - 1.0 : value;
            value = color.Green + shifter.Green;
            color.Green = value > 1.0 ? value - 1.0 : value;
            value = color.Blue + shifter.Blue;
            color.Blue = value > 1.0 ? value - 1.0 : value;
            value = color.Transparency + shifter.Transparency;
            color.Transparency = value > 1.0 ? value - 1.0 : value;
        }
        /// <summary>
        /// 获取用给定颜色对当前颜色进行偏移后的新颜色。
        /// </summary>
        /// <param name="color">当前颜色</param>
        /// <param name="shifter">给定颜色</param>
        /// <returns>偏移后的新颜色。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Color GetShifted(this Color color, Color shifter) {
            if (color is null) {
                throw new ArgumentNullException(nameof(color));
            }

            if (shifter is null) {
                throw new ArgumentNullException(nameof(shifter));
            }

            var newColor = new Color(color.Red, color.Green, color.Blue, color.Transparency);
            newColor.Shift(shifter);

            return newColor;
        }
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Model.UI"/>.<see cref="GraphicsDrawer"/> 的扩展。
    /// </summary>
    public static class GraphicsDrawerExtension {
        /// <summary>
        /// 在视图中画一个圆弧（用碎线条拟合，线条越短越接近圆形）。
        /// </summary>
        /// <param name="drawer">当前绘图器。</param>
        /// <param name="arc">要画出的圆弧。</param>
        /// <param name="color">线条颜色，默认黑色。</param>
        /// <param name="width">线条宽度，默认1。根据官方文档 <see cref="GraphicPolyLine.Width"/>，当前有效值为 1 或 2 或 4。</param>
        /// <param name="type">线型，默认 <see cref="GraphicPolyLine.LineType.Solid"/>。</param>
        /// <param name="accuracy">模拟圆弧的精细程度，即每多少弧长画一条直线，默认10。不建议设置为太小的数，会十分影响性能。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void DrawArc(this GraphicsDrawer drawer,
            Arc arc,
            Color color = default,
            int width = 1,
            GraphicPolyLine.LineType type = GraphicPolyLine.LineType.Solid,
            double accuracy = 10) {
            if (drawer is null) {
                throw new ArgumentNullException(nameof(drawer));
            }

            if (arc is null) {
                throw new ArgumentNullException(nameof(arc));
            }

            if (width != 1 && width != 2 && width != 4)
                throw new ArgumentException($"根据官方文档，“{nameof(width)}”有效值仅为 1 或 2 或 4。");

            if (accuracy <= 0)
                throw new ArgumentException($"“{nameof(accuracy)}”不应小于等于0.0。");

            var points = arc.GetPointsMeasure(accuracy);
            //必须包含圆弧终点，避免产生缺口
            if (points[points.Count - 1] != arc.EndPoint) points.Add(arc.EndPoint);
            var polyLine = new PolyLine(points);
            if (color == default) color = new Color();
            var graphicPolyLine = new GraphicPolyLine(polyLine, color, width, type);

            drawer.DrawPolyLine(graphicPolyLine);
        }
        /// <summary>
        /// 在视图中画一个点。
        /// </summary>
        /// <param name="drawer">当前绘图器。</param>
        /// <param name="point">要画出的点。</param>
        /// <param name="color">线条颜色，默认黑色。</param>
        /// <param name="width">线条宽度，默认1。根据官方文档 <see cref="GraphicPolyLine.Width"/>，当前有效值为 1 或 2 或 4。</param>
        /// <param name="type">线型，默认 <see cref="GraphicPolyLine.LineType.Solid"/>。</param>
        /// <param name="size">点大小，默认50。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void DrawPoint(this GraphicsDrawer drawer,
            Point point,
            Color color = default,
            int width = 1,
            GraphicPolyLine.LineType type = GraphicPolyLine.LineType.Solid,
            double size = 50) {
            if (drawer is null) {
                throw new ArgumentNullException(nameof(drawer));
            }

            if (point is null) {
                throw new ArgumentNullException(nameof(point));
            }

            if (width != 1 && width != 2 && width != 4)
                throw new ArgumentException($"根据官方文档，“{nameof(width)}”有效值仅为 1 或 2 或 4。");

            if (size <= 0)
                throw new ArgumentException($"“{nameof(size)}”不应小于等于0.0。");

            Point outLT = new Point(-size, size, 0), outRT = new Point(size, size, 0);
            Point outLB = new Point(-size, -size, 0), outRB = new Point(size, -size, 0);
            Point inLT = new Point(-size * 0.5, size * 0.5, 0), inRT = new Point(size * 0.5, size * 0.5, 0);
            Point inLB = new Point(-size * 0.5, -size * 0.5, 0), inRB = new Point(size * 0.5, -size * 0.5, 0);

            outLT.Translate(point); outRT.Translate(point);
            outLB.Translate(point); outRB.Translate(point);
            inLT.Translate(point); inRT.Translate(point);
            inLB.Translate(point); inRB.Translate(point);

            var pl1 = new PolyLine(new Point[] { outLT, outRB });
            var pl2 = new PolyLine(new Point[] { outLB, outRT });
            var pl3 = new PolyLine(new Point[] { inLT, inRT, inRB, inLB, inLT });

            if (color == default) color = new Color();
            var graphicPolyLine1 = new GraphicPolyLine(pl1, color, width, type);
            var graphicPolyLine2 = new GraphicPolyLine(pl2, color, width, type);
            var graphicPolyLine3 = new GraphicPolyLine(pl3, color, width, type);

            drawer.DrawPolyLine(graphicPolyLine1);
            drawer.DrawPolyLine(graphicPolyLine2);
            drawer.DrawPolyLine(graphicPolyLine3);
        }
        /// <summary>
        /// 在视图中画一条直线。由于直线是延伸到无限远的，所以此方法仅画出其一部分长度
        /// （以 <paramref name="point"/> 在直线上的投影点为基准，沿直线向前后共 <paramref name="length"/> 长度）。
        /// </summary>
        /// <param name="drawer">当前绘图器。</param>
        /// <param name="line">要画的直线。</param>
        /// <param name="color">线条颜色，默认黑色。</param>
        /// <param name="width">线条宽度，默认1。根据官方文档 <see cref="GraphicPolyLine.Width"/>，当前有效值为 1 或 2 或 4。</param>
        /// <param name="type">线型，默认 <see cref="GraphicPolyLine.LineType.Solid"/>。</param>
        /// <param name="point">基准控制点，默认为直线原点。</param>
        /// <param name="length">要画出的长度，默认5000。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void DrawLine(this GraphicsDrawer drawer,
            Line line,
            Color color = default,
            int width = 1,
            GraphicPolyLine.LineType type = GraphicPolyLine.LineType.Solid,
            Point point = default,
            double length = 5000) {
            if (drawer is null) {
                throw new ArgumentNullException(nameof(drawer));
            }

            if (line is null) {
                throw new ArgumentNullException(nameof(line));
            }

            if (line.Direction.IsZero())
                throw new ArgumentException($"“{nameof(line)}”.Direction 不应为零向量。");

            if (length <= 0)
                throw new ArgumentException($"“{nameof(length)}”不应小于等于0.0。");

            if (width != 1 && width != 2 && width != 4)
                throw new ArgumentException($"根据官方文档，“{nameof(width)}”有效值仅为 1 或 2 或 4。");

            if (point == default) point = line.Origin;
            var p1 = Projection.PointToLine(point, line);
            var p2 = new Point(p1);

            var v = new Vector(line.Direction);
            v.Normalize();
            p1.Translate(v * length * 0.5);
            p2.Translate(v * length * -0.5);

            var pl = new PolyLine(new Point[] { p1, p2 });
            if (color == default) color = new Color();
            var graphicPolyLine = new GraphicPolyLine(pl, color, width, type);

            drawer.DrawPolyLine(graphicPolyLine);
        }
    }
}
