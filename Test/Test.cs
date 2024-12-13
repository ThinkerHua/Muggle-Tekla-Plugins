/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2024 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  Test.cs: something testing method without GUI
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.ModelUI;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.Test {
    internal class Test {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main() {
        Start:
            Console.WriteLine("选择要运行的测试：");
            Console.WriteLine("[1] PositionOfTriangleOnLines");
            Console.WriteLine("[0] 结束运行");
            int CASE;
            while (true) {
                if (int.TryParse(Console.ReadLine(), out CASE)) {
                    break;
                } else {
                    Console.WriteLine("输入不正确，请重新输入。");
                }
            }
            switch (CASE) {
            case 0:
                break;
            case 1:
                TestPositionOfTriangleOnLines();
                Console.WriteLine();
                goto Start;
            default:
                Console.WriteLine("没有此选项，请重新选择。");
                goto Start;
            }
        }
        public static void TestPositionOfTriangleOnLines() {
            if (!new Model().GetConnectionStatus()) {
                Console.WriteLine("Tekla structures 不在运行。");
                return;
            }

            Console.WriteLine("在Tekla structures 中指定3条直线。");
            var picker = new Picker();
            var gdrawer = new GraphicsDrawer();
            Point p1, p2;
            Line[] lines = new Line[3];
            try {
                for (int i = 0; i < 3; i++) {
                    p1 = picker.PickPoint($"为第{i + 1}条直线指定第1个控制点：");
                    p2 = picker.PickPoint($"为第{i + 1}条直线指定第2个控制点：");
                    lines[i] = new Line(p1, p2);
                    gdrawer.DrawLineSegment(p1, p2, ColorExtension.Orange);
                }
            } catch {
                Console.WriteLine("无效输入。");
                return;
            }

            var hWnd = Process.GetCurrentProcess().MainWindowHandle;
            SetForegroundWindow(hWnd);

            string str;
            string[] inputs;
            double[] edges = new double[3];
            bool flag = false;
            do {
                Console.WriteLine("请输入三条边长，以空格分隔：");
                str = Console.ReadLine();
                try {
                    inputs = str.Split(' ');
                    flag = double.TryParse(inputs[0], out edges[0]) &&
                        double.TryParse(inputs[1], out edges[1]) &&
                        double.TryParse(inputs[2], out edges[2]);
                } catch {
                    Console.WriteLine("无效输入。");
                }
            } while (!flag);

            try {
                var position = Geometry3dOperation.PositionOfTriangleOnLines(
                    (lines[0], lines[1], lines[2]), (edges[0], edges[1], edges[2]));
                if (position.Count == 0) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNo solution!");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    var color = new Color[] {
                        ColorExtension.Blue,
                        ColorExtension.Lime,
                        ColorExtension.MediumOrchid,
                        ColorExtension.Red,
                    };
                    var num = 0;
                    foreach (var (P1, P2, P3) in position) {
                        Console.WriteLine();
                        Console.WriteLine($"Solution #{num + 1}:");
                        Console.WriteLine($"P1 = {P1}, P2 = {P2}, P3 = {P3}");
                        Console.WriteLine(
                            $"E1 = {Distance.PointToPoint(P1, P3)}, " +
                            $"E2 = {Distance.PointToPoint(P2, P3)}, " +
                            $"E3 = {Distance.PointToPoint(P1, P2)}");
                        gdrawer.DrawLineSegment(P1, P2, color[num]);
                        gdrawer.DrawLineSegment(P1, P3, color[num]);
                        gdrawer.DrawLineSegment(P2, P3, color[num]);
                        num++;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
