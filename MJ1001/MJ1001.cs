using System;
using System.Windows;
using System.Runtime.CompilerServices;
using Tekla.Structures.Datatype;
using Tekla.Structures.Model;
using Tekla.Structures.Plugins;
using Tekla.Structures;
using System.Collections.Generic;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Dialog;
using Tekla.Structures.Geometry3d;
using System.Collections;
using System.Collections.ObjectModel;
using TSG = Tekla.Structures.Geometry3d;
using TSD = Tekla.Structures.Datatype;
using System.Runtime.InteropServices;
using System.Linq;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.Internal;
using Muggle.TeklaPlugins.Common.Model;
using System.Windows.Media.Media3D;
using Muggle.TeklaPlugins.Common.Profile;

namespace Muggle.TeklaPlugins.MJ1001 {
    public class PluginData {
        #region Fields
        [StructuresField("gap")]
        public double gap;

        [StructuresField("ratHole_radius")]
        public double ratHole_radius;

        [StructuresField("embedment_THK")]
        public double embedment_thickness;

        [StructuresField("embedment_WDTH")]
        public double embedment_width;

        [StructuresField("embedment_EXTN")]
        public double embedment_exten;

        [StructuresField("embedment_MATL")]
        public string embedment_material;

        [StructuresField("anchorRod_LEN")]
        public double anchorRod_length;

        [StructuresField("anchorRod_size")]
        public double anchorRod_size;

        [StructuresField("anchorRod_MATL")]
        public string anchorRod_material;

        [StructuresField("anchorRod_disList_X")]
        public string anchorRod_disListStr_X;

        [StructuresField("anchorRod_disList_Y")]
        public string anchorRod_disListStr_Y;

        [StructuresField("cleat_THK")]
        public double cleat_thickness;

        [StructuresField("cleat_WDTH")]
        public double cleat_width;

        [StructuresField("cleat_dis_innerEdge")]
        public double cleat_dis_with_innerEdge;

        [StructuresField("cleat_MATL")]
        public string cleat_material;

        [StructuresField("bolt_STD")]
        public string bolt_standard;

        [StructuresField("bolt_size")]
        public double bolt_size;

        [StructuresField("bolt_disList_X")]
        public string bolt_disListStr_X;

        [StructuresField("bolt_disList_Y")]
        public string bolt_distListStr_Y;

        [StructuresField("group_no")]
        public int group_no;
        #endregion
    }

    [Plugin("MJ1001")]
    [PluginUserInterface("Muggle.TeklaPlugins.MJ1001.MainWindow")]
    [InputObjectDependency(InputObjectDependency.DEPENDENT)]
    public class LT1001 : PluginBase {
        #region Fields
        private Model _Model;
        private PluginData _Data;

        private double gap;
        private double ratHole_radius;
        private double embedment_thickness;
        private double embedment_width;
        private double embedment_exten;
        private string embedment_material;
        private double anchorRod_length;
        private double anchorRod_size;
        private string anchorRod_material;
        private string anchorRod_disListStr_X;
        private string anchorRod_disListStr_Y;
        private double cleat_thickness;
        private double cleat_width;
        private double cleat_dis_with_innerEdge;
        private string cleat_material;
        private string bolt_standard;
        private double bolt_size;
        private string bolt_disListStr_X;
        private string bolt_distListStr_Y;
        private int group_no;

        private DistanceList anchorRod_disList_X;
        private DistanceList anchorRod_disList_Y;
        private DistanceList bolt_disList_X;
        private DistanceList bolt_disList_Y;

        private TransformationPlane originTP;
        private TransformationPlane workTP;

        private Identifier beamID;
        private Identifier concreteID;
        private TSG.Point[] points;
        #endregion

        #region Properties
        private Model Model {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private PluginData Data {
            get { return this._Data; }
            set { this._Data = value; }
        }
        #endregion

        #region Constructor
        public LT1001(PluginData data) {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region Overrides

        public override bool Run(List<InputDefinition> Input) {
            try {
                GetValuesFromDialog();

                beamID = Input[0].GetInput() as Identifier;
                concreteID = Input[1].GetInput() as Identifier;
                points = (Input[2].GetInput() as ArrayList).Cast<TSG.Point>().ToArray();

                originTP ??= Model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
                workTP ??= GetWorkPlane();

                Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
                points = points.Select(p => p.Transform(originTP, workTP)).ToArray();//ת��������ƽ��
                CreatConnection();

                return true;
            } catch (UnAcceptableProfileException) {
                MessageBox.Show("Only H-Beam is supported.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

        /// <summary>
        /// �������롣
        /// </summary>
        /// <returns>���ϵ�һ��Ԫ��Ϊ��ID���ڶ���Ԫ��Ϊ����Ԥ����Ļ���������ID��
        /// ������Ԫ�����棨�㼯�ϣ�ArraryList���ͣ���</returns>
        public override List<InputDefinition> DefineInput() {
            InputDefinition beamInput = null, concreteInput = null, faceInput = null;
            try {
                var picker = new Picker();
                var beam = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
                var face = picker.PickFace();

                beamInput = new InputDefinition(beam.Identifier);

                var enumerator = face.GetEnumerator();
                while (enumerator.MoveNext()) {
                    var item = enumerator.Current as InputItem;
                    if (item.GetInputType() == InputItem.InputTypeEnum.INPUT_POLYGON) {
                        var points = item.GetData() as ArrayList;
                        faceInput = new InputDefinition(points);
                    }
                    if (item.GetInputType() == InputItem.InputTypeEnum.INPUT_1_OBJECT) {
                        var obj = item.GetData() as ModelObject;
                        concreteInput = new InputDefinition(obj.Identifier);
                    }
                }
            } catch (Exception e) {
                if (e.Message != "User interrupt")
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return new List<InputDefinition>();
            }

            return new List<InputDefinition> { beamInput, concreteInput, faceInput };
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog() {
            gap = Data.gap;
            ratHole_radius = Data.ratHole_radius;
            embedment_thickness = Data.embedment_thickness;
            embedment_width = Data.embedment_width;
            embedment_exten = Data.embedment_exten;
            embedment_material = Data.embedment_material;
            anchorRod_length = Data.anchorRod_length;
            anchorRod_size = Data.anchorRod_size;
            anchorRod_material = Data.anchorRod_material;
            anchorRod_disListStr_X = Data.anchorRod_disListStr_X;
            anchorRod_disListStr_Y = Data.anchorRod_disListStr_Y;
            cleat_thickness = Data.cleat_thickness;
            cleat_width = Data.cleat_width;
            cleat_dis_with_innerEdge = Data.cleat_dis_with_innerEdge;
            cleat_material = Data.cleat_material;
            bolt_standard = Data.bolt_standard;
            bolt_size = Data.bolt_size;
            bolt_disListStr_X = Data.bolt_disListStr_X;
            bolt_distListStr_Y = Data.bolt_distListStr_Y;
            group_no = Data.group_no;

            if (IsDefaultValue(gap))
                gap = 15.0;
            if (IsDefaultValue(ratHole_radius))
                ratHole_radius = 30.0;
            if (IsDefaultValue(embedment_thickness))
                embedment_thickness = 20.0;
            if (IsDefaultValue(embedment_width))
                embedment_width = 300.0;
            if (IsDefaultValue(embedment_exten))
                embedment_exten = 90.0;
            if (IsDefaultValue(embedment_material))
                embedment_material = "Q345B";
            if (IsDefaultValue(anchorRod_length))
                anchorRod_length = 150.0;
            if (IsDefaultValue(anchorRod_size))
                anchorRod_size = 20.0;
            if (IsDefaultValue(anchorRod_material))
                anchorRod_material = "Q345B";
            if (IsDefaultValue(anchorRod_disListStr_X))
                anchorRod_disListStr_X = "250 4*125";
            if (IsDefaultValue(anchorRod_disListStr_Y))
                anchorRod_disListStr_Y = "160";
            if (IsDefaultValue(cleat_thickness))
                cleat_thickness = 12.0;
            if (IsDefaultValue(cleat_width))
                cleat_width = 95.0;
            if (IsDefaultValue(cleat_dis_with_innerEdge))
                cleat_dis_with_innerEdge = 40.0;
            if (IsDefaultValue(cleat_material))
                cleat_material = "Q345B";
            if (IsDefaultValue(bolt_standard))
                bolt_standard = "HS10.9";
            if (IsDefaultValue(bolt_size))
                bolt_size = 20.0;
            if (IsDefaultValue(bolt_disListStr_X))
                bolt_disListStr_X = "40 7*70";
            if (IsDefaultValue(bolt_distListStr_Y))
                bolt_distListStr_Y = "0";
            if (IsDefaultValue(group_no))
                group_no = 99;

            anchorRod_disList_X = DistanceList.Parse(
                anchorRod_disListStr_X,
                System.Globalization.CultureInfo.InvariantCulture,
                TSD.Distance.CurrentUnitType);
            anchorRod_disList_Y = DistanceList.Parse(
                anchorRod_disListStr_Y,
                System.Globalization.CultureInfo.InvariantCulture,
                TSD.Distance.CurrentUnitType);
            //  ���Ӵ˲�����Ϊ��ģ��ϵͳ��˨�����Ϊ
            //  ����ʵ��ʹ��ʱ�������е�һ��ֵҪ�ֶ���дΪ0
            if (anchorRod_disList_Y.First().Value != 0.0)
                anchorRod_disList_Y.Insert(0, new TSD.Distance(0.0, TSD.Distance.CurrentUnitType));
            bolt_disList_X = DistanceList.Parse(
                bolt_disListStr_X,
                System.Globalization.CultureInfo.InvariantCulture,
                TSD.Distance.CurrentUnitType);
            bolt_disList_Y = DistanceList.Parse(
                bolt_distListStr_Y,
                System.Globalization.CultureInfo.InvariantCulture,
                TSD.Distance.CurrentUnitType);
            //  ���Ӵ˲�����Ϊ��ģ��ϵͳ��˨�����Ϊ
            //  ����ʵ��ʹ��ʱ�������е�һ��ֵҪ�ֶ���дΪ0
            if (bolt_disList_Y.First().Value != 0.0)
                bolt_disList_Y.Insert(0, new TSD.Distance(0.0, TSD.Distance.CurrentUnitType));
        }

        private TransformationPlane GetWorkPlane() {
            var part = Model.SelectModelObject(beamID) as Part;
            var plane = GeometricPlaneFactory.ByPoints(points[0], points[1], points[2]);

            var centerLine = part.GetCenterLine(false).Cast<TSG.Point>().ToArray();
            var firstPoint = centerLine.First();
            var lastPoint = centerLine.Last();
            var sameDirection = true;

            TSG.Point origin;
            TSG.Vector axisX, axisY;
            if (TSG.Distance.PointToPlane(firstPoint, plane) < TSG.Distance.PointToPlane(lastPoint, plane)) {
                origin = Intersection.LineToPlane(
                    new Line(firstPoint, centerLine[1]),
                    plane);
            } else {
                origin = Intersection.LineToPlane(
                    new Line(lastPoint, centerLine[centerLine.Length - 2]),
                    plane);
                sameDirection = false;
            }

            if (part is Beam beam) {
                axisX = sameDirection ? beam.GetCoordinateSystem().AxisX : beam.GetCoordinateSystem().AxisX * -1;
                axisY = beam.GetCoordinateSystem().AxisY;
            } else if (part is PolyBeam polyBeam) {
                var css = polyBeam.GetPolybeamCoordinateSystems().Cast<CoordinateSystem>();
                var cs = sameDirection ? css.First() : css.Last();
                axisX = sameDirection ? cs.AxisX : cs.AxisX * -1;
                axisY = cs.AxisY;
            } else {
                throw new NotSupportedException($"Unsupported part type: {part.GetType()}.");
            }

            return new TransformationPlane(origin, axisX, axisY);
        }

        private void CreatConnection() {
#if DEBUG
            var msg = string.Empty;
#endif
            double height = 0.0, width = 0.0, webThickness = 0.0, flangeThickness = 0.0;
            var beam = Model.SelectModelObject(beamID) as Part;
            if (!beam.GetReportProperty("HEIGHT", ref height) || !beam.GetReportProperty("WIDTH", ref width)) {
                throw new Exception("Failed to get the height and width of the beam.");
            }
            /*  ��δ������ĳЩ�������Ͳ����ã���ȡ������ֵ
             *  beam.GetReportProperty("WEB_THICKNESS", ref webThickness);
             *  if (!beam.GetReportProperty("FLANGE_THICKNESS", ref flangeThickness)) {
             *      beam.GetReportProperty("FlANGE_THICKNESS_U", ref flangeThickness);
             *  }
            */

            var profile = new ProfileH_Symmetrical(beam.Profile.ProfileString);
            if (profile.h1 != profile.h2 || profile.t1 != profile.t2)  //������Ƚ���H�͸�
                throw new UnAcceptableProfileException(beam.Profile.ProfileString);
            webThickness = profile.s;
            flangeThickness = profile.t1;

            var concrete = Model.SelectModelObject(concreteID) as Part;

            var axisX = new TSG.Vector(1, 0, 0);
            var axisY = new TSG.Vector(0, 1, 0);
            var axisZ = new TSG.Vector(0, 0, 1);

            var beamTopLine = new Line(new TSG.Point(0, height / 2, 0), axisX);
            var beamBottomLine = new Line(new TSG.Point(0, -height / 2, 0), axisX);
            var embedmentPlane = GeometricPlaneFactory.ByPoints(points[0], points[1], points[2]);

            #region ����Ԥ���
            var topIntersection = Intersection.LineToPlane(beamTopLine, embedmentPlane);
            var bottomIntersection = Intersection.LineToPlane(beamBottomLine, embedmentPlane);

            var embedmentDirection = new TSG.Vector(topIntersection).GetNormal(1.0);
            var point1 = topIntersection + embedmentDirection * embedment_exten;
            var point2 = bottomIntersection - embedmentDirection * embedment_exten;

            var embedment = ModelOperation.CreatBeam(
                point1, point2,
                name: "EMBEDMENT",
                profileStr: $"PL{embedment_thickness}*{embedment_width}",
                materialStr: embedment_material,
                planeEnum: Position.PlaneEnum.RIGHT,
                rotationEnum: Position.RotationEnum.TOP);

            ModelOperation.ApplyBooleanOperation(concrete, embedment);
            #endregion

            #region ����ê��
            var anchorRod_EndOffset = embedmentPlane.Normal.GetNormal(-anchorRod_length);
            var x = 0.0; var y = 0.0;
            var yTotal = anchorRod_disList_Y.Sum(y => y.Value);
            for (int i = 0; i < anchorRod_disList_X.Count; i++) {
                x += anchorRod_disList_X[i].Value;
                for (int j = 0; j < anchorRod_disList_Y.Count; j++) {
                    y += anchorRod_disList_Y[j].Value;
                    point2 = point1 - embedmentDirection * x + axisZ * (yTotal * 0.5 - y) - embedmentPlane.Normal.GetNormal(embedment_thickness);
                    var rod = ModelOperation.CreatBeam(
                        point2, point2 + anchorRod_EndOffset,
                        name: "ANCHOR ROD",
                        profileStr: "D" + anchorRod_size,
                        materialStr: anchorRod_material,
                        partPrefix: "D");
                    ModelOperation.CreatWeld(embedment, rod);
                }
                y = 0.0;
            }
            #endregion

            #region ĩ�˶���
            var fittingGeometryPlane = new GeometricPlane(
                (topIntersection + bottomIntersection).Multiply(0.5) + embedmentPlane.Normal.GetNormal(gap),
                embedmentDirection,
                axisZ);
            var fitting = new Fitting {
                Father = beam,
                Plane = new Plane {
                    Origin = fittingGeometryPlane.Origin,
                    AxisX = embedmentDirection,
                    AxisY = axisZ
                }
            };
            fitting.Insert();
            #endregion

            #region ����
            var chamferNone = new Chamfer();
            var chamferArcPoint = new Chamfer { Type = Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT };
            point1 = Intersection.LineToPlane(
                beamTopLine.Offset(flangeThickness, LineExtension.OffsetDirectionEnum.RIGHT),
                fittingGeometryPlane);
            point2 = point1 + axisX * ratHole_radius;
            var point3 = point1 - axisY * ratHole_radius;
            var point4 = point1 - axisX * ratHole_radius;

            var contour = new ArrayList{
                new ContourPoint(point2, chamferNone),
                new ContourPoint(point3, chamferArcPoint),
                new ContourPoint(point4, chamferNone),
            };
            var cutPart = ModelOperation.CreatBooleanOperationPolygon(contour, width);
            ModelOperation.ApplyBooleanOperation(beam, cutPart);
            cutPart.Delete();

            point1 = Intersection.LineToPlane(
                beamBottomLine.Offset(flangeThickness, LineExtension.OffsetDirectionEnum.LEFT),
                fittingGeometryPlane);
            point2 = point1 + axisX * ratHole_radius;
            point3 = point1 + axisY * ratHole_radius;
            point4 = point1 - axisX * ratHole_radius;

            contour = new ArrayList{
                new ContourPoint(point2, chamferNone),
                new ContourPoint(point3, chamferArcPoint),
                new ContourPoint(point4, chamferNone),
            };
            cutPart = ModelOperation.CreatBooleanOperationPolygon(contour, width);
            ModelOperation.ApplyBooleanOperation(beam, cutPart);
            cutPart.Delete();
            #endregion

            #region �������Ӱ�
            point1 = Intersection.LineToPlane(
                beamTopLine.Offset(flangeThickness + cleat_dis_with_innerEdge, LineExtension.OffsetDirectionEnum.RIGHT),
                embedmentPlane);
            point4 = Intersection.LineToPlane(
                beamBottomLine.Offset(flangeThickness + cleat_dis_with_innerEdge, LineExtension.OffsetDirectionEnum.LEFT),
                embedmentPlane);

            var angle = axisX.GetAngleBetween_WithDirection(embedmentDirection, axisZ);
            var vector = axisX.GetNormal(cleat_width / Math.Sin(angle));
            point2 = point1 + vector;
            point3 = point4 + vector;

            var cleat1 = ModelOperation.CreatContourPlate(
                new TSG.Point[] { point1, point2, point3, point4 },
                name: "CLEAT",
                profileStr: $"PL{cleat_thickness}",
                materialStr: cleat_material,
                depthEnum: Position.DepthEnum.FRONT,
                depthOffset: webThickness * 0.5);
            var cleat2 = ModelOperation.CreatContourPlate(
                new TSG.Point[] { point1, point2, point3, point4 },
                name: "CLEAT",
                profileStr: $"PL{cleat_thickness}",
                materialStr: cleat_material,
                depthEnum: Position.DepthEnum.BEHIND,
                depthOffset: webThickness * 0.5);

            ModelOperation.CreatWeld(embedment, cleat1);
            ModelOperation.CreatWeld(embedment, cleat2);
            #endregion

            #region ������˨
            point1 += axisX.GetNormal((cleat_width + gap) * 0.5 / Math.Sin(angle));
            y = 0.0;
            yTotal = bolt_disList_Y.Sum(y => y.Value);
            var zeroDisList = new DistanceList { new TSD.Distance(0.0, TSD.Distance.CurrentUnitType) };
            for (int j = 0; j < bolt_disList_Y.Count; j++) {
                y += bolt_disList_Y[j].Value;
                point2 = point1 + axisX * (y / Math.Sin(angle));
                ModelOperation.CreatBoltArray(
                    beam, cleat1, new[] { cleat2 },
                    point2, point2 - embedmentDirection * 100,
                    bolt_disList_X, zeroDisList,
                    position: new Position { Rotation = Position.RotationEnum.FRONT },
                    bolt_standard: bolt_standard, bolt_size: bolt_size);
            }
            #endregion
        }

        #endregion
    }
}
