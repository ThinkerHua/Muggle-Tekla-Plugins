using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Solid;

namespace UnitTesting_NUnit3;

public class SampleCode_SolidGetCutPart {
    [SetUp]
    public void Setup() { }

    private static Beam CreateBeam(Point p1, Point p2, string profileName, bool SetAsOperativeClass) {
        Beam beam1 = new Beam {
            StartPoint = p1,
            EndPoint = p2,
            Profile = { ProfileString = profileName },
            Finish = "PAINT",
            Material = { MaterialString = "S235JR" },
            Position = { Depth = Position.DepthEnum.MIDDLE },
            Class = SetAsOperativeClass ? BooleanPart.BooleanOperativeClassName : "1"
        };

        return beam1;
    }

    [Test]
    public void Example1() {
        Beam beam1 = CreateBeam(new Point(1000.0, 1000.0, 0.0), new Point(1000.0, 2000.0, 0.0), "500*500", false);
        Beam beam2 = CreateBeam(new Point(500.0, 1500.0, 250.0), new Point(1500.0, 1500.0, 250.0), "500*500", true);
        beam1.Insert();
        beam2.Insert();
        BooleanPart cut = new BooleanPart { Father = beam1 };
        cut.SetOperativePart(beam2);
        cut.Insert();
        beam2.Delete();

        Solid solid1 = beam1.GetSolid(Solid.SolidCreationTypeEnum.RAW);
        Solid solid2 = beam1.GetSolid(Solid.SolidCreationTypeEnum.NORMAL);

        ShellEnumerator shells = solid1.GetCutPart(solid2);

        int shellCount = 0;
        List<int> faceCounts = new List<int>();

        while (shells.MoveNext()) {
            var shell = shells.Current as Shell;
            if (shell != null) {
                FaceEnumerator faces = shell.GetFaceEnumerator();
                faceCounts.Insert(shellCount, 0);
                while (faces.MoveNext()) {
                    faceCounts[shellCount]++;

                    var face = faces.Current;
                    var loopEnum = face.GetLoopEnumerator();
                    while (loopEnum.MoveNext()) {
                        var loop = loopEnum.Current;
                        var vertexEnum = loop.GetVertexEnumerator();
                        while (vertexEnum.MoveNext()) {
                            var vertex = vertexEnum.Current;
                            var controlPoint = new ControlPoint(vertex);
                            controlPoint.Insert();
                        }
                    }
                }
            }
            Console.WriteLine($"Shell {shellCount}# has {faceCounts[shellCount]} faces.");
            shellCount++;
        }

        new Model().CommitChanges();
    }

}
