﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using MuggleTeklaPlugins.WK1001;
using Tekla.Structures.Plugins;
using MuggleTeklaPlugins.Common.Geometry3d;
using MuggleTeklaPlugins.Common.Model;
using System.Diagnostics;
using System.IO;

namespace MuggleTeklaPlugins.MainForm.Plugins {
    internal class WK1001_Outer {
        public static void Run() {
#if DEBUG
            var streamWriter = new StreamWriter("WK1001_Outer_Debug.log");
            var listener = new TextWriterTraceListener(streamWriter);
            Debug.Listeners.Add(listener);
            var methodinfo = "In \"Run\" method: ";
            Debug.WriteLine(methodinfo);
#endif
            try {
                var model = new Model() ?? throw new Exception("未连接到 Tekla Structures。");

                var picker = new Picker();
                var partEnum = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS);
                var parts = new ArrayList();
                foreach (Beam part in partEnum) {
                    parts.Add(part);
                }

                if (parts.Count < 3)
                    throw new Exception("至少需选择三个杆件。");

                AdjustPartsNormal(parts);

                var wk1001 = new Connection {
                    Name = "WK1001",
                    Number = BaseComponent.PLUGIN_OBJECT_NUMBER,
                    Class = -1,
                };
                wk1001.SetPrimaryObject(parts[0] as ModelObject);
                parts.RemoveAt(0);
                wk1001.SetSecondaryObjects(parts);

                if (!wk1001.Insert())
                    throw new Exception("\"WK1001\"节点创建失败");

                var modelObjects = new ArrayList { wk1001 };
                var uiSelecter = new Tekla.Structures.Model.UI.ModelObjectSelector();
                uiSelecter.Select(modelObjects);
                model.CommitChanges();

            } catch (Exception e) {
                Debug.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            } finally {
#if DEBUG
                Debug.Listeners.Remove(listener);
                listener.Close(); listener.Dispose();
                streamWriter.Close(); streamWriter.Dispose();
#endif
            }
        }
        /// <summary>
        /// 调整杆件法向
        /// </summary>
        private static void AdjustPartsNormal(ArrayList parts) {
#if DEBUG
            var methodinfo = "In \"AdjustPartsNormal\" method: ";
            Debug.WriteLine(methodinfo);
#endif
            if (parts is null) {
                throw new ArgumentNullException(nameof(parts));
            }

            CoordinateSystem partCS;
            GeometricPlane partYZPlane;
            Vector thisProjectedNormal, anotherNormal, anotherProjectedNormal, partNormal;
            double angle;
            var thisNormal = GetThisNormal(parts);
            foreach (Beam beam in parts) {
                partCS = beam.GetCoordinateSystem();
                partYZPlane = new GeometricPlane(partCS.Origin, partCS.AxisX);
                thisProjectedNormal = ProjectionExtension.VectorToPlane(thisNormal, partYZPlane);
                anotherNormal = GetAnotherNormal(beam);
                if (anotherNormal == null) {
                    anotherProjectedNormal = thisProjectedNormal;
                } else {
                    anotherProjectedNormal = ProjectionExtension.VectorToPlane(
                        anotherNormal,
                        partYZPlane);
                }

                partNormal = new Vector(thisProjectedNormal.GetNormal() + anotherProjectedNormal.GetNormal());
                angle = partNormal.GetAngleBetween_WithDirection(partCS.AxisY, partCS.AxisX) + Math.PI * 0.25;
                angle = angle % (Math.PI * 0.5) - Math.PI * 0.25;
                ModelOperation.Move_Rotate(beam, partCS.Origin, partCS.AxisX, -angle);
            }
        }
        /// <summary>
        /// 获取当前节点的法向（在当前变换平面中的值）
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        private static Vector GetThisNormal(ArrayList parts) {
#if DEBUG
            var methodinfo = "In \"GetThisNormal\" method: ";
            Debug.WriteLine(methodinfo);
#endif
            if (parts is null) {
                throw new ArgumentNullException(nameof(parts));
            }

            //根据前三个选择的杆件求共同法向
            var part1 = parts[0] as Beam;
            var part2 = parts[1] as Beam;
            var part3 = parts[2] as Beam;

            var origin = Math.Min(Distance.PointToPoint(part1.StartPoint, part2.StartPoint),
                                    Distance.PointToPoint(part1.StartPoint, part2.EndPoint))
                        < Math.Min(Distance.PointToPoint(part1.EndPoint, part2.StartPoint),
                                    Distance.PointToPoint(part1.EndPoint, part2.EndPoint)) ?
                part1.StartPoint : part1.EndPoint;
            var p0 = Distance.PointToPoint(origin, part1.StartPoint) > Distance.PointToPoint(origin, part1.EndPoint) ?
                part1.StartPoint : part1.EndPoint;
            var p1 = Distance.PointToPoint(origin, part2.StartPoint) > Distance.PointToPoint(origin, part2.EndPoint) ?
                part2.StartPoint : part2.EndPoint;
            var p2 = Distance.PointToPoint(origin, part3.StartPoint) > Distance.PointToPoint(origin, part3.EndPoint) ?
                part3.StartPoint : part3.EndPoint;

            var v0 = new Vector(p0 - origin).GetNormal(500);
            var v1 = new Vector(p1 - origin).GetNormal(500);
            var v2 = new Vector(p2 - origin).GetNormal(500);

            p0 = origin + v0; p1 = origin + v1; p2 = origin + v2;
            var gplane = GeometricPlaneFactory.ByPoints(p0, p1, p2);

            Vector normal;
            if (origin == Projection.PointToPlane(origin, gplane)) {
                //在同一平面上
                normal = gplane.GetNormal();
            } else {
                //不在同一平面上
                normal = new Vector(origin - Geometry3dOperation.CenterOfSphere(origin, p0, p1, p2));
            }

            if (Vector.Dot(normal, new Vector(0, 0, 500).TransformFrom(new TransformationPlane())) < 0)
                normal *= -1;//使法向基本朝上

            return normal;
        }
        private static Vector GetAnotherNormal(Beam beam) {
#if DEBUG
            var methodinfo = "In \"GetAnotherNormal\" method: ";
            Debug.WriteLine(methodinfo);
#endif
            if (beam is null) {
                throw new ArgumentNullException(nameof(beam));
            }

            var cmpntEnum = beam.GetComponents();
            if (cmpntEnum == null) return null;

            foreach (BaseComponent cmpnt in cmpntEnum) {
                if (cmpnt.Name != "WK1001")
                    continue;

                var childrenEnum = cmpnt.GetChildren();
                if (childrenEnum == null) continue;

                foreach (ModelObject child in childrenEnum) {
                    if (child.GetType() != typeof(Beam) || ((Beam) child).PartNumber.Prefix != "O")
                        continue;

                    var tube = child as Beam;
                    var anotherNormal = new Vector(tube.StartPoint - tube.EndPoint);

                    return anotherNormal;
                }
            }
            return null;
        }
    }
}