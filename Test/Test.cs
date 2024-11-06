using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

using MuggleTeklaPlugins.Common;
using MuggleTeklaPlugins.Geometry3dExtension;
using MuggleTeklaPlugins.ModelExtension;
using MuggleTeklaPlugins.ModelExtension.UIExtension;
using MuggleTeklaPlugins.Internal;
using System.Runtime.InteropServices;

namespace Test {
    internal class Test {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main(string[] args) {
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
            Point p1, p2;
            Line[] lines = new Line[3];
            try {
                for (int i = 0; i < 3; i++) {
                    p1 = picker.PickPoint($"为第{i + 1}条直线指定第1个控制点：");
                    p2 = picker.PickPoint($"为第{i + 1}条直线指定第2个控制点：");
                    lines[i] = new Line(p1, p2);
                }
            } catch {
                Console.WriteLine("无效输入。");
                return;
            }

            var hWnd = Process.GetCurrentProcess().MainWindowHandle;
            SetForegroundWindow(hWnd);
            double[] edges = new double[3];
            for (int i = 0; i < 3; i++) {
                while (true) {
                    Console.WriteLine($"请输入第{i + 1}条边长：");
                    if (double.TryParse(Console.ReadLine(), out edges[i])) {
                        break;
                    } else {
                        Console.WriteLine("输入不正确，请重新输入。");
                    }
                }
            }

            try {
                var position = Geometry3dOperation.PositionOfTriangleOnLines(
                    (lines[0], lines[1], lines[2]), (edges[0], edges[1], edges[2]));
                if (position is null) {
                    Console.WriteLine("\nNo solution!");
                } else {
                    var model = new Model();
                    var gdrawer = new GraphicsDrawer();
                    var doDraw = model.GetConnectionStatus();
                    if (doDraw) {
                        gdrawer.DrawLine(lines[0], color: ColorExtension.Orange, length: 50000);
                        gdrawer.DrawLine(lines[1], color: ColorExtension.Orange, length: 50000);
                        gdrawer.DrawLine(lines[2], color: ColorExtension.Orange, length: 50000);
                    }
                    var num = 0;
                    var color = new Color[] {
                        ColorExtension.Blue,
                        ColorExtension.Lime,
                        ColorExtension.MediumOrchid,
                        ColorExtension.Red,
                    };
                    var i = 0;
                    foreach (var (P1, P2, P3) in position) {
                        num++;
                        Console.WriteLine();
                        Console.WriteLine($"Solution #{num}:");
                        Console.WriteLine($"P1 = {P1}, P2 = {P2}, P3 = {P3}");
                        Console.WriteLine(
                            $"E1 = {Distance.PointToPoint(P1, P3)}, " +
                            $"E2 = {Distance.PointToPoint(P2, P3)}, " +
                            $"E3 = {Distance.PointToPoint(P1, P2)}");
                        if (doDraw) {
                            gdrawer.DrawLineSegment(P1, P2, color[i]);
                            gdrawer.DrawLineSegment(P1, P3, color[i]);
                            gdrawer.DrawLineSegment(P2, P3, color[i]);
                            i++;
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
