﻿/*==============================================================================
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
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.ModelUI;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.Test {
    internal class Test_Console {
        private const string NOTRUNNING_MESSAGE = "Tekla structures not running.";
        private const string USER_INTERRUPT = "User interrupt";
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main() {
        Start:
            Console.WriteLine("选择要运行的测试：");
            Console.WriteLine("[1] Position of triangle on lines");
            Console.WriteLine("[2] Tekla structures infomation");
            Console.WriteLine("[3] Get model object type");
            Console.WriteLine("[4] Select model object with bounding box");
            Console.WriteLine("[5] Solid.IntersectAllFaces(Point, Point, Point)");
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
                case 2:
                    TSInfo();
                    Console.WriteLine();
                    goto Start;
                case 3:
                    GetModelObjectType();
                    Console.WriteLine();
                    goto Start;
                case 4:
                    SelectModelObjectWithBoundingBox();
                    Console.WriteLine();
                    goto Start;
                case 5:
                    TestSolidIntersectAllFaces();
                    goto Start;
                default:
                    Console.WriteLine("没有此选项，请重新选择。");
                    goto Start;
            }
        }

        private static void TestPositionOfTriangleOnLines() {
            if (!new Model().GetConnectionStatus()) {
                Console.WriteLine(NOTRUNNING_MESSAGE);
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

        private static void TSInfo() {
            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Console.WriteLine(NOTRUNNING_MESSAGE);
                return;
            }

            var info = TeklaStructuresInfo.GetFullTSRegistryKeyText();
            var commonAppDataFolder = TeklaStructuresInfo.GetCommonAppDataFolder();
            var localAppDataFolder = TeklaStructuresInfo.GetLocalAppDataFolder();
            var XSDATADIR = string.Empty;
            TeklaStructuresSettings.GetAdvancedOption("XSDATADIR", ref XSDATADIR);
            Console.WriteLine(string.Format("Full registry key: {0}", info));
            Console.WriteLine(string.Format("Common app data folder: {0}", commonAppDataFolder));
            Console.WriteLine(string.Format("Local app data folder: {0}", localAppDataFolder));
            Console.WriteLine(string.Format("XSDATADIR: {0}", XSDATADIR));
        }

        private static void GetModelObjectType() {
            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Console.WriteLine(NOTRUNNING_MESSAGE);
                return;
            }

            var picker = new Picker();
            try {
                while (true) {
                    var mo = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                    var type = mo.GetType();
                    Console.WriteLine(string.Format("Selected object's type is {0}, full name is {1}", type.Name, type.FullName));
                }
            } catch (Exception e) when (e.Message == USER_INTERRUPT) {

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SelectModelObjectWithBoundingBox() {
            var columnNames = new string[] { "column", "柱" };
            var model = new Model();
            var picker = new Picker();
            var selector = model.GetModelObjectSelector();
            try {
                while (true) {
                    var p = picker.PickPoint();
                    var minPoint = new Point(p.X - 10, p.Y - 10, p.Z - 10);
                    var maxPoint = new Point(p.X + 10, p.Y + 10, p.Z + 10);
                    var objEnumerator = selector.GetObjectsByBoundingBox(minPoint, maxPoint);
                    Console.WriteLine($"Found {objEnumerator.GetSize()} model object(s).");
                    foreach (ModelObject obj in objEnumerator) {
                        Console.WriteLine($"Found a {obj.GetType()}");

                        if (!(obj is Beam beam) || !columnNames.Any(item => beam.Name.ToLower().Contains(item)))
                            continue;

                        Console.WriteLine($"Found a column - identifier is: {beam.Identifier}, GUID is: {beam.Identifier.GUID}");
                    }
                }
            } catch (Exception e) when (e.Message == USER_INTERRUPT) {

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private static void TestSolidIntersectAllFaces() {
            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Console.WriteLine(NOTRUNNING_MESSAGE);
                return;
            }

            try {
                var picker = new Picker();
                var part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;
                var points = new Point[3];
                var totalNum = 3;
                for (int i = 0; i < totalNum; i++) {
                    var referencePoint = i == 0 ? null : points[i - 1];
                    points[i] = picker.PickPoint($"Pick {totalNum} points to form a plane ({i}/{totalNum} completed).", referencePoint);
                }
                Operation.DisplayPrompt(string.Empty);

                var drawer = new GraphicsDrawer();
                var solid = part.GetSolid(Solid.SolidCreationTypeEnum.RAW);
                var faceEnum = solid.IntersectAllFaces(points[0], points[1], points[2]);
                var faceIndex = -1;
                while (faceEnum.MoveNext()) {
                    ++faceIndex;

                    var face = faceEnum.Current as ArrayList;
                    var loopEnum = face.GetEnumerator();
                    var loopIndex = -1;
                    while (loopEnum.MoveNext()) {
                        ++loopIndex;

                        var vertices = loopEnum.Current as ArrayList;
                        var vertexEnum = vertices.GetEnumerator();
                        var vertexIndex = -1;
                        while (vertexEnum.MoveNext()) {
                            ++vertexIndex;

                            var v = vertexEnum.Current as Point;

                            drawer.DrawText(v, $"F{faceIndex}L{loopIndex}V{vertexIndex}", ColorExtension.DarkBlue);
                        }
                    }
                }

                model.CommitChanges();

            } catch (Exception e) when (e.Message == USER_INTERRUPT) {
                Console.WriteLine(USER_INTERRUPT);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
