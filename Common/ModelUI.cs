using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

using MuggleTeklaPlugins.Geometry3dExtension;
using System.Diagnostics;

namespace MuggleTeklaPlugins.ModelExtension.UIExtension {
    /// <summary>
    /// <see cref="Tekla.Structures.Model.UI"/>.<see cref="Color"/> 的扩展。
    /// </summary>
    public static class ColorExtension {
        /// <summary>
        /// 纯黑
        /// </summary>
        public static Color Black => new Color(0.00000000, 0.00000000, 0.00000000);
        /// <summary>
        /// 海军蓝
        /// </summary>
        public static Color Navy => new Color(0.00000000, 0.00000000, 0.50196078);
        /// <summary>
        /// 深蓝色
        /// </summary>
        public static Color DarkBlue => new Color(0.00000000, 0.00000000, 0.54509804);
        /// <summary>
        /// 适中的蓝色
        /// </summary>
        public static Color MediumBlue => new Color(0.00000000, 0.00000000, 0.80392157);
        /// <summary>
        /// 纯蓝
        /// </summary>
        public static Color Blue => new Color(0.00000000, 0.00000000, 1.00000000);
        /// <summary>
        /// 深绿色
        /// </summary>
        public static Color DarkGreen => new Color(0.00000000, 0.39215686, 0.00000000);
        /// <summary>
        /// 纯绿
        /// </summary>
        public static Color Green => new Color(0.00000000, 0.50196078, 0.00000000);
        /// <summary>
        /// 水鸭色
        /// </summary>
        public static Color Teal => new Color(0.00000000, 0.50196078, 0.50196078);
        /// <summary>
        /// 深青色
        /// </summary>
        public static Color DarkCyan => new Color(0.00000000, 0.54509804, 0.54509804);
        /// <summary>
        /// 深天蓝
        /// </summary>
        public static Color DeepSkyBlue => new Color(0.00000000, 0.74901961, 1.00000000);
        /// <summary>
        /// 深绿宝石
        /// </summary>
        public static Color DarkTurquoise => new Color(0.00000000, 0.80784314, 0.81960784);
        /// <summary>
        /// 适中的碧绿色
        /// </summary>
        public static Color MediumAquamarine => new Color(0.00000000, 0.98039216, 0.60392157);
        /// <summary>
        /// 酸橙色
        /// </summary>
        public static Color Lime => new Color(0.00000000, 1.00000000, 0.00000000);
        /// <summary>
        /// 适中的春天的绿色
        /// </summary>
        public static Color MediumSpringGreen => new Color(0.00000000, 1.00000000, 0.49803922);
        /// <summary>
        /// 青色
        /// </summary>
        public static Color Cyan => new Color(0.00000000, 1.00000000, 1.00000000);
        /// <summary>
        /// 午夜的蓝色
        /// </summary>
        public static Color MidnightBlue => new Color(0.09803922, 0.09803922, 0.43921569);
        /// <summary>
        /// 道奇蓝
        /// </summary>
        public static Color DoderBlue => new Color(0.11764706, 0.56470588, 1.00000000);
        /// <summary>
        /// 浅海洋绿
        /// </summary>
        public static Color LightSeaGreen => new Color(0.12549020, 0.69803922, 0.66666667);
        /// <summary>
        /// 森林绿
        /// </summary>
        public static Color ForestGreen => new Color(0.13333333, 0.54509804, 0.13333333);
        /// <summary>
        /// 海洋绿
        /// </summary>
        public static Color SeaGreen => new Color(0.18039216, 0.54509804, 0.34117647);
        /// <summary>
        /// 深石板灰
        /// </summary>
        public static Color DarkSlateGray => new Color(0.18431373, 0.30980392, 0.30980392);
        /// <summary>
        /// 酸橙绿
        /// </summary>
        public static Color LimeGreen => new Color(0.19607843, 0.80392157, 0.19607843);
        /// <summary>
        /// 春天的绿色
        /// </summary>
        public static Color SpringGreen => new Color(0.23529412, 0.70196078, 0.44313725);
        /// <summary>
        /// 绿宝石
        /// </summary>
        public static Color Turquoise => new Color(0.25098039, 0.87843137, 0.81568627);
        /// <summary>
        /// 皇家蓝
        /// </summary>
        public static Color RoyalBlue => new Color(0.25490196, 0.41176471, 0.88235294);
        /// <summary>
        /// 钢蓝
        /// </summary>
        public static Color SteelBlue => new Color(0.27450980, 0.50980392, 0.70588235);
        /// <summary>
        /// 深岩暗蓝灰色
        /// </summary>
        public static Color DarkSlateBlue => new Color(0.28235294, 0.23921569, 0.54509804);
        /// <summary>
        /// 适中的绿宝石
        /// </summary>
        public static Color MediumTurquoise => new Color(0.28235294, 0.81960784, 0.80000000);
        /// <summary>
        /// 靛青
        /// </summary>
        public static Color Indigo => new Color(0.29411765, 0.00000000, 0.50980392);
        /// <summary>
        /// 橄榄土褐色
        /// </summary>
        public static Color OliveDrab => new Color(0.33333333, 0.41960784, 0.18431373);
        /// <summary>
        /// 军校蓝
        /// </summary>
        public static Color CadetBlue => new Color(0.37254902, 0.61960784, 0.62745098);
        /// <summary>
        /// 矢车菊的蓝色
        /// </summary>
        public static Color CornflowerBlue => new Color(0.39215686, 0.58431373, 0.92941176);
        /// <summary>
        /// 暗淡的灰色
        /// </summary>
        public static Color DimGray => new Color(0.41176471, 0.41176471, 0.41176471);
        /// <summary>
        /// 板岩暗蓝灰色
        /// </summary>
        public static Color SlateBlue => new Color(0.41568627, 0.35294118, 0.80392157);
        /// <summary>
        /// 石板灰
        /// </summary>
        public static Color SlateGray => new Color(0.43921569, 0.50196078, 0.56470588);
        /// <summary>
        /// 浅石板灰
        /// </summary>
        public static Color LightSlateGray => new Color(0.46666667, 0.53333333, 0.60000000);
        /// <summary>
        /// 适中的板岩暗蓝灰色
        /// </summary>
        public static Color MediumSlateBlue => new Color(0.48235294, 0.40784314, 0.93333333);
        /// <summary>
        /// 草坪绿
        /// </summary>
        public static Color LawnGreen => new Color(0.48627451, 0.98823529, 0.00000000);
        /// <summary>
        /// 查特酒绿
        /// </summary>
        public static Color Chartreuse => new Color(0.49803922, 1.00000000, 0.00000000);
        /// <summary>
        /// 绿玉\碧绿色
        /// </summary>
        public static Color Auqamarin => new Color(0.49803922, 1.00000000, 0.66666667);
        /// <summary>
        /// 栗色
        /// </summary>
        public static Color Maroon => new Color(0.50196078, 0.00000000, 0.00000000);
        /// <summary>
        /// 紫色
        /// </summary>
        public static Color Purple => new Color(0.50196078, 0.00000000, 0.50196078);
        /// <summary>
        /// 橄榄
        /// </summary>
        public static Color Olive => new Color(0.50196078, 0.50196078, 0.00000000);
        /// <summary>
        /// 灰色
        /// </summary>
        public static Color Gray => new Color(0.50196078, 0.50196078, 0.50196078);
        /// <summary>
        /// 天蓝色
        /// </summary>
        public static Color SkyBlue => new Color(0.52941176, 0.80784314, 0.92156863);
        /// <summary>
        /// 淡蓝色
        /// </summary>
        public static Color LightSkyBlue => new Color(0.52941176, 0.80784314, 0.98039216);
        /// <summary>
        /// 深紫罗兰的蓝色
        /// </summary>
        public static Color BlueViolet => new Color(0.54117647, 0.16862745, 0.88627451);
        /// <summary>
        /// 深红色
        /// </summary>
        public static Color DarkRed => new Color(0.54509804, 0.00000000, 0.00000000);
        /// <summary>
        /// 深洋红色
        /// </summary>
        public static Color DarkMagenta => new Color(0.54509804, 0.00000000, 0.54509804);
        /// <summary>
        /// 马鞍棕色
        /// </summary>
        public static Color SaddleBrown => new Color(0.54509804, 0.27058824, 0.07450980);
        /// <summary>
        /// 深海洋绿
        /// </summary>
        public static Color DarkSeaGreen => new Color(0.56078431, 0.73725490, 0.56078431);
        /// <summary>
        /// 淡绿色
        /// </summary>
        public static Color LightGreen => new Color(0.56470588, 0.93333333, 0.56470588);
        /// <summary>
        /// 适中的紫色
        /// </summary>
        public static Color MediumPurple => new Color(0.57647059, 0.43921569, 0.85882353);
        /// <summary>
        /// 深紫罗兰色
        /// </summary>
        public static Color DarkVoilet => new Color(0.58039216, 0.00000000, 0.82745098);
        /// <summary>
        /// 苍白的绿色
        /// </summary>
        public static Color PaleGreen => new Color(0.59607843, 0.98431373, 0.59607843);
        /// <summary>
        /// 深兰花紫
        /// </summary>
        public static Color DarkOrchid => new Color(0.60000000, 0.19607843, 0.80000000);
        /// <summary>
        /// 黄土赭色
        /// </summary>
        public static Color Sienna => new Color(0.62745098, 0.32156863, 0.17647059);
        /// <summary>
        /// 棕色
        /// </summary>
        public static Color Brown => new Color(0.64705882, 0.16470588, 0.16470588);
        /// <summary>
        /// 深灰色
        /// </summary>
        public static Color DarkGray => new Color(0.66274510, 0.66274510, 0.66274510);
        /// <summary>
        /// 淡蓝
        /// </summary>
        public static Color LightBLue => new Color(0.67843137, 0.84705882, 0.90196078);
        /// <summary>
        /// 绿黄色
        /// </summary>
        public static Color GreenYellow => new Color(0.67843137, 1.00000000, 0.18431373);
        /// <summary>
        /// 苍白的绿宝石
        /// </summary>
        public static Color PaleTurquoise => new Color(0.68627451, 0.93333333, 0.93333333);
        /// <summary>
        /// 淡钢蓝
        /// </summary>
        public static Color LightSteelBlue => new Color(0.69019608, 0.76862745, 0.87058824);
        /// <summary>
        /// 火药蓝
        /// </summary>
        public static Color PowDerBlue => new Color(0.69019608, 0.87843137, 0.90196078);
        /// <summary>
        /// 耐火砖
        /// </summary>
        public static Color FireBrick => new Color(0.69803922, 0.13333333, 0.13333333);
        /// <summary>
        /// 适中的兰花紫
        /// </summary>
        public static Color MediumOrchid => new Color(0.72941176, 0.33333333, 0.82745098);
        /// <summary>
        /// 玫瑰棕色
        /// </summary>
        public static Color RosyBrown => new Color(0.73725490, 0.56078431, 0.56078431);
        /// <summary>
        /// 深卡其布
        /// </summary>
        public static Color DarkKhaki => new Color(0.74117647, 0.71764706, 0.41960784);
        /// <summary>
        /// 银白色
        /// </summary>
        public static Color Silver => new Color(0.75294118, 0.75294118, 0.75294118);
        /// <summary>
        /// 适中的紫罗兰红色
        /// </summary>
        public static Color MediumVioletRed => new Color(0.78039216, 0.08235294, 0.52156863);
        /// <summary>
        /// 印度红
        /// </summary>
        public static Color IndianRed => new Color(0.80392157, 0.36078431, 0.36078431);
        /// <summary>
        /// 秘鲁
        /// </summary>
        public static Color Peru => new Color(0.80392157, 0.52156863, 0.24705882);
        /// <summary>
        /// 巧克力
        /// </summary>
        public static Color Chocolate => new Color(0.82352941, 0.41176471, 0.11764706);
        /// <summary>
        /// 晒黑
        /// </summary>
        public static Color Tan => new Color(0.82352941, 0.70588235, 0.54901961);
        /// <summary>
        /// 浅灰色
        /// </summary>
        public static Color LightGrey => new Color(0.82745098, 0.82745098, 0.82745098);
        /// <summary>
        /// 水绿色
        /// </summary>
        public static Color Aqua => new Color(0.83137255, 0.94901961, 0.90588235);
        /// <summary>
        /// 蓟
        /// </summary>
        public static Color Thistle => new Color(0.84705882, 0.74901961, 0.84705882);
        /// <summary>
        /// 兰花的紫色
        /// </summary>
        public static Color Orchid => new Color(0.85490196, 0.43921569, 0.83921569);
        /// <summary>
        /// 秋麒麟
        /// </summary>
        public static Color GoldEnrod => new Color(0.85490196, 0.64705882, 0.12549020);
        /// <summary>
        /// 苍白的紫罗兰红色
        /// </summary>
        public static Color PaleVioletRed => new Color(0.85882353, 0.43921569, 0.57647059);
        /// <summary>
        /// 猩红
        /// </summary>
        public static Color Crimson => new Color(0.86274510, 0.07843137, 0.23529412);
        /// <summary>
        /// 亮灰色
        /// </summary>
        public static Color Gainsboro => new Color(0.86274510, 0.86274510, 0.86274510);
        /// <summary>
        /// 李子
        /// </summary>
        public static Color Plum => new Color(0.86666667, 0.62745098, 0.86666667);
        /// <summary>
        /// 结实的树
        /// </summary>
        public static Color BrulyWood => new Color(0.87058824, 0.72156863, 0.52941176);
        /// <summary>
        /// 淡青色
        /// </summary>
        public static Color LightCyan => new Color(0.88235294, 1.00000000, 1.00000000);
        /// <summary>
        /// 熏衣草花的淡紫色
        /// </summary>
        public static Color Lavender => new Color(0.90196078, 0.90196078, 0.98039216);
        /// <summary>
        /// 深鲜肉(鲑鱼)色
        /// </summary>
        public static Color DarkSalmon => new Color(0.91372549, 0.58823529, 0.47843137);
        /// <summary>
        /// 紫罗兰
        /// </summary>
        public static Color Violet => new Color(0.93333333, 0.50980392, 0.93333333);
        /// <summary>
        /// 灰秋麒麟
        /// </summary>
        public static Color PaleGodenrod => new Color(0.93333333, 0.90980392, 0.66666667);
        /// <summary>
        /// 淡珊瑚色
        /// </summary>
        public static Color LightCoral => new Color(0.94117647, 0.50196078, 0.50196078);
        /// <summary>
        /// 卡其布
        /// </summary>
        public static Color Khaki => new Color(0.94117647, 0.90196078, 0.54901961);
        /// <summary>
        /// 爱丽丝蓝
        /// </summary>
        public static Color AliceBlue => new Color(0.94117647, 0.97254902, 1.00000000);
        /// <summary>
        /// 蜂蜜
        /// </summary>
        public static Color Honeydew => new Color(0.94117647, 1.00000000, 0.94117647);
        /// <summary>
        /// 蔚蓝色
        /// </summary>
        public static Color Azure => new Color(0.94117647, 1.00000000, 1.00000000);
        /// <summary>
        /// 沙棕色
        /// </summary>
        public static Color SandyBrown => new Color(0.95686275, 0.64313725, 0.37647059);
        /// <summary>
        /// 小麦色
        /// </summary>
        public static Color Wheat => new Color(0.96078431, 0.87058824, 0.70196078);
        /// <summary>
        /// 米色(浅褐色)
        /// </summary>
        public static Color Beige => new Color(0.96078431, 0.96078431, 0.86274510);
        /// <summary>
        /// 白烟
        /// </summary>
        public static Color WhiteSmoke => new Color(0.96078431, 0.96078431, 0.96078431);
        /// <summary>
        /// 薄荷奶油
        /// </summary>
        public static Color MintCream => new Color(0.96078431, 1.00000000, 0.98039216);
        /// <summary>
        /// 幽灵的白色
        /// </summary>
        public static Color GhostWhite => new Color(0.97254902, 0.97254902, 1.00000000);
        /// <summary>
        /// 鲜肉(鲑鱼)色
        /// </summary>
        public static Color Salmon => new Color(0.98039216, 0.50196078, 0.44705882);
        /// <summary>
        /// 古代的白色
        /// </summary>
        public static Color AntiqueWhite => new Color(0.98039216, 0.92156863, 0.84313725);
        /// <summary>
        /// 亚麻布
        /// </summary>
        public static Color Linen => new Color(0.98039216, 0.94117647, 0.90196078);
        /// <summary>
        /// 浅秋麒麟黄
        /// </summary>
        public static Color LightGoldenrodYellow => new Color(0.98039216, 0.98039216, 0.82352941);
        /// <summary>
        /// 老饰带
        /// </summary>
        public static Color OldLace => new Color(0.99215686, 0.96078431, 0.90196078);
        /// <summary>
        /// 纯红
        /// </summary>
        public static Color Red => new Color(1.00000000, 0.00000000, 0.00000000);
        /// <summary>
        /// 洋红
        /// </summary>
        public static Color Magenta => new Color(1.00000000, 0.00000000, 1.00000000);
        /// <summary>
        /// 灯笼海棠(紫红色)
        /// </summary>
        public static Color Fuchsia => new Color(1.00000000, 0.00000000, 1.00000000);
        /// <summary>
        /// 深粉色
        /// </summary>
        public static Color DeepPink => new Color(1.00000000, 0.07843137, 0.57647059);
        /// <summary>
        /// 橙红色
        /// </summary>
        public static Color OrangeRed => new Color(1.00000000, 0.27058824, 0.00000000);
        /// <summary>
        /// 番茄
        /// </summary>
        public static Color Tomato => new Color(1.00000000, 0.38823529, 0.27843137);
        /// <summary>
        /// 热情的粉红
        /// </summary>
        public static Color HotPink => new Color(1.00000000, 0.41176471, 0.70588235);
        /// <summary>
        /// 珊瑚
        /// </summary>
        public static Color Coral => new Color(1.00000000, 0.49803922, 0.31372549);
        /// <summary>
        /// 深橙色
        /// </summary>
        public static Color DarkOrange => new Color(1.00000000, 0.54901961, 0.00000000);
        /// <summary>
        /// 浅鲜肉(鲑鱼)色
        /// </summary>
        public static Color LightSalmon => new Color(1.00000000, 0.62745098, 0.47843137);
        /// <summary>
        /// 橙色
        /// </summary>
        public static Color Orange => new Color(1.00000000, 0.64705882, 0.00000000);
        /// <summary>
        /// 浅粉红
        /// </summary>
        public static Color LightPink => new Color(1.00000000, 0.71372549, 0.75686275);
        /// <summary>
        /// 粉红
        /// </summary>
        public static Color Pink => new Color(1.00000000, 0.75294118, 0.79607843);
        /// <summary>
        /// 金
        /// </summary>
        public static Color Gold => new Color(1.00000000, 0.84313725, 0.00000000);
        /// <summary>
        /// 桃色
        /// </summary>
        public static Color PeachPuff => new Color(1.00000000, 0.85490196, 0.72549020);
        /// <summary>
        /// 纳瓦霍白
        /// </summary>
        public static Color NavajoWhite => new Color(1.00000000, 0.87058824, 0.67843137);
        /// <summary>
        /// 鹿皮鞋
        /// </summary>
        public static Color Moccasin => new Color(1.00000000, 0.89411765, 0.70980392);
        /// <summary>
        /// (浓汤)乳脂,番茄等
        /// </summary>
        public static Color Bisque => new Color(1.00000000, 0.89411765, 0.76862745);
        /// <summary>
        /// 薄雾玫瑰
        /// </summary>
        public static Color MistyRose => new Color(1.00000000, 0.89411765, 0.88235294);
        /// <summary>
        /// 漂白的杏仁
        /// </summary>
        public static Color BlanchedAlmond => new Color(1.00000000, 0.92156863, 0.80392157);
        /// <summary>
        /// 番木瓜
        /// </summary>
        public static Color PapayaWhip => new Color(1.00000000, 0.93725490, 0.83529412);
        /// <summary>
        /// 脸红的淡紫色
        /// </summary>
        public static Color LavenderBlush => new Color(1.00000000, 0.94117647, 0.96078431);
        /// <summary>
        /// 海贝壳
        /// </summary>
        public static Color SeaShell => new Color(1.00000000, 0.96078431, 0.93333333);
        /// <summary>
        /// 玉米色
        /// </summary>
        public static Color Cornislk => new Color(1.00000000, 0.97254902, 0.86274510);
        /// <summary>
        /// 柠檬薄纱
        /// </summary>
        public static Color LemonChiffon => new Color(1.00000000, 0.98039216, 0.80392157);
        /// <summary>
        /// 花的白色
        /// </summary>
        public static Color FloralWhite => new Color(1.00000000, 0.98039216, 0.94117647);
        /// <summary>
        /// 雪
        /// </summary>
        public static Color Snow => new Color(1.00000000, 0.98039216, 0.98039216);
        /// <summary>
        /// 纯黄
        /// </summary>
        public static Color Yellow => new Color(1.00000000, 1.00000000, 0.00000000);
        /// <summary>
        /// 浅黄色
        /// </summary>
        public static Color LightYellow => new Color(1.00000000, 1.00000000, 0.87843137);
        /// <summary>
        /// 象牙
        /// </summary>
        public static Color Ivory => new Color(1.00000000, 1.00000000, 0.94117647);
        /// <summary>
        /// 纯白
        /// </summary>
        public static Color White => new Color(1.00000000, 1.00000000, 1.00000000);
    }
    /// <summary>
    /// <see cref="Tekla.Structures.Model.UI"/>.<see cref="GraphicsDrawer"/> 的扩展。
    /// </summary>
    public static class GraphicsDrawerExtension {
        /// <summary>
        /// 在视图中画一个圆弧（用碎线条拟合，线条越短越接近圆形）。
        /// </summary>
        /// <param name="drawer"></param>
        /// <param name="arc">要画出的圆弧。</param>
        /// <param name="color">线条颜色，默认黑色。</param>
        /// <param name="width">线条宽度，默认1。</param>
        /// <param name="type">线型，默认 <see cref="GraphicPolyLine.LineType.Solid"/>。</param>
        /// <param name="accuracy">模拟圆弧的精细程度，即每多少弧长画一条直线，默认10。不建议设置为太小的数，会十分影响性能。</param>
        public static void DrawArc(this GraphicsDrawer drawer, 
            Arc arc,
            Color color = default, 
            int width = 1, 
            GraphicPolyLine.LineType type = GraphicPolyLine.LineType.Solid,
            double accuracy = 10) {

            if (arc == null || accuracy <= 0) return;

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
        /// <param name="drawer"></param>
        /// <param name="point">要画出的点。</param>
        /// <param name="color">线条颜色，默认黑色。</param>
        /// <param name="width">线条宽度，默认1。</param>
        /// <param name="type">线型，默认 <see cref="GraphicPolyLine.LineType.Solid"/>。</param>
        /// <param name="size">点大小，默认50。</param>
        public static void DrawPoint(this GraphicsDrawer drawer, 
            Point point,
            Color color = default, 
            int width = 1, 
            GraphicPolyLine.LineType type = GraphicPolyLine.LineType.Solid,
            double size = 50) {

            if (point == null || size <= 0) return;

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
        /// <param name="drawer"></param>
        /// <param name="line">要画的直线。</param>
        /// <param name="color">线条颜色，默认黑色。</param>
        /// <param name="width">线条宽度，默认1。</param>
        /// <param name="type">线型，默认 <see cref="GraphicPolyLine.LineType.Solid"/>。</param>
        /// <param name="point">基准控制点，默认为直线原点。</param>
        /// <param name="length">要画出的长度，默认5000。</param>
        public static void DrawLine(this GraphicsDrawer drawer, 
            Line line,
            Color color = default, 
            int width = 1, 
            GraphicPolyLine.LineType type = GraphicPolyLine.LineType.Solid,
            Point point = default, 
            double length = 5000) {

            if (line == null || line.Direction == new Vector() || length <= 0) return;

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
