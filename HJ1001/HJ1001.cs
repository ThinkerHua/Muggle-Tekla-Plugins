using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures;
using Tekla.Structures.Datatype;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using TSD = Tekla.Structures.Datatype;
using TSG = Tekla.Structures.Geometry3d;
using TSM = Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;
using TSP = Tekla.Structures.Plugins;

using MuggleTeklaPlugins.Common;
using MuggleTeklaPlugins.Geometry3dExtension;
using MuggleTeklaPlugins.ModelExtension;
using MuggleTeklaPlugins.ModelExtension.UIExtension;
using MuggleTeklaPlugins.Internal;

namespace HJ1001 {
    public class PluginData {
        #region Fields
        [StructuresField("endPlateTHK")]
        public double endPlateTHK;
        [StructuresField("endPlateDIAM")]
        public double endPlateDIAM;
        [StructuresField("creatPrimStif")]
        public int creatPrimStif;
        [StructuresField("creatSecStif")]
        public int creatSecStif;
        [StructuresField("stifTHK")]
        public double stifTHK;
        [StructuresField("stifWidth")]
        public double stifWidth;
        [StructuresField("chamX")]
        public double chamX;
        [StructuresField("chamY")]
        public double chamY;
        [StructuresField("margin")]
        public double margin;
        [StructuresField("quantity")]
        public int quantity;
        [StructuresField("creatBolt")]
        public int creatBolt;
        [StructuresField("boltStandard")]
        public string boltStandard;
        [StructuresField("boltSize")]
        public double boltSize;
        [StructuresField("boltCircleDiameter")]
        public double boltCircleDiameter;
        [StructuresField("material")]
        public string material;
        [StructuresField("group_no")]
        public int group_no;
        #endregion
    }

    [Plugin("HJ1001")]
    [PluginUserInterface("HJ1001.FormHJ1001")]
    [InputObjectType(InputObjectType.INPUTOBJECT_PART)]
    [SecondaryType(SecondaryType.SECONDARYTYPE_ONE)]
    [PositionType(PositionTypeEnum.END_END_PLANE)]
    public class HJ1001 : ConnectionBase {
        #region Fields
        private Model _Model;
        private PluginData _Data;

        private double endPlateTHK;
        private double endPlateDIAM;
        private int creatPrimStif;
        private int creatSecStif;
        private double stifTHK;
        private double stifWidth;
        private double chamX;
        private double chamY;
        private double margin;
        private int quantity;
        private int creatBolt;
        private string boltStandard;
        private double boltSize;
        private double boltCircleDiameter;
        private string material;
        private int group_no;

        private ProfileCircular_Perfect primProfile;
        private ProfileCircular_Perfect secProfile;
        private double primDiameter;
        private double secDiameter;

        private readonly TransformationPlane globalTP = new TransformationPlane();
        private TransformationPlane originTP;
        private TransformationPlane workTP;
        #endregion

        #region Properties
        private Model Model {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private PluginData Data {
            get { return this._Data; }
            set {
                this._Data = value;
                GetValuesFromDialog();
            }
        }
        #endregion

        #region Constructor
        public HJ1001(PluginData data) {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region Overrides
        public override bool Run() {
            try {
                CheckIfAcceptableProfile();

                //Test.ShowTransformationPlane(workTP);
                SetWorkTransformationPlane();
                //Test.ShowTransformationPlane(workTP);

                CreatConnection();
            } catch (Exception) {
                throw;
            }

            return true;
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog() {
            endPlateTHK = Data.endPlateTHK;
            endPlateDIAM = Data.endPlateDIAM;
            creatPrimStif = Data.creatPrimStif;
            creatSecStif = Data.creatSecStif;
            stifTHK = Data.stifTHK;
            stifWidth = Data.stifWidth;
            chamX = Data.chamX;
            chamY = Data.chamY;
            margin = Data.margin;
            quantity = Data.quantity;
            creatBolt = Data.creatBolt;
            boltStandard = Data.boltStandard;
            boltSize = Data.boltSize;
            boltCircleDiameter = Data.boltCircleDiameter;
            material = Data.material;
            group_no = Data.group_no;

            if (IsDefaultValue(endPlateTHK))
                endPlateTHK = 20;
            if (IsDefaultValue(endPlateDIAM))
                endPlateDIAM = 554;
            if (IsDefaultValue(creatPrimStif))
                creatPrimStif = 1;
            if (IsDefaultValue(creatSecStif))
                creatSecStif = 1;
            if (IsDefaultValue(stifTHK))
                stifTHK = 10;
            if (IsDefaultValue(stifWidth))
                stifWidth = 140;
            if (IsDefaultValue(chamX))
                chamX = 40;
            if (IsDefaultValue(chamY))
                chamY = 40;
            if (IsDefaultValue(margin))
                margin = 0;
            if (IsDefaultValue(quantity))
                quantity = 16;
            if (IsDefaultValue(creatBolt))
                creatBolt = 1;
            if (IsDefaultValue(boltStandard))
                boltStandard = "HS10.9";
            if (IsDefaultValue(boltSize))
                boltSize = 20;
            if (IsDefaultValue(boltCircleDiameter))
                boltCircleDiameter = 466;
            if (IsDefaultValue(material))
                material = "Q345B";
            if (IsDefaultValue(group_no))
                group_no = 99;

        }
        /// <summary>
        /// Ŀǰ��֧��Բ�ֻ�Բ�ܵ���Բ��ʽ������������Σ�����֧����Բ��ʽ��
        /// </summary>
        private void CheckIfAcceptableProfile() {
            var prim = (Part) Model.SelectModelObject(Primary);
            var sec = (Part) Model.SelectModelObject(Secondaries[0]);
            try {
                primProfile = new ProfileCircular_Perfect(prim.Profile.ProfileString);
                secProfile = new ProfileCircular_Perfect(sec.Profile.ProfileString);
            } catch (UnAcceptableProfile) {
                throw;
            }
        }
        private void SetWorkTransformationPlane() {

            if (workTP != null) return;

            originTP = Model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            var prim = (Part) Model.SelectModelObject(Primary);
            var sec = (Part) Model.SelectModelObject(Secondaries[0]);

            var primCenterline = prim.GetCenterLine(false);
            var secCenterline = sec.GetCenterLine(false);
            var primStartPoint = (Point) primCenterline[0];
            var primEndPoint = (Point) primCenterline[primCenterline.Count - 1];
            var secStartPoint = (Point) secCenterline[0];
            var secEndPoint = (Point) secCenterline[secCenterline.Count - 1];

            var dis1 = Math.Min(
                TSG.Distance.PointToPoint(primStartPoint, secStartPoint),
                TSG.Distance.PointToPoint(primStartPoint, secEndPoint));
            var dis2 = Math.Min(
                TSG.Distance.PointToPoint(primEndPoint, secStartPoint),
                TSG.Distance.PointToPoint(primEndPoint, secEndPoint));

            bool isCurve = false;

            var beamType = prim.GetType();
            switch (beamType.Name) {
            case nameof(Beam):
                if (primCenterline.Count == 2)
                    isCurve = false;
                else
                    isCurve = true;
                break;
            case nameof(PolyBeam):
                var contourPoints = ((PolyBeam) prim).Contour.ContourPoints;
                var secondOrPenultimateIndex = dis1 < dis2 ? 1 : contourPoints.Count - 2;
                var chamfer = ((ContourPoint) contourPoints[secondOrPenultimateIndex]).Chamfer;
                if (chamfer.Type == Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT)
                    isCurve = true;
                else
                    isCurve = false;
                break;
            default:
                break;
            }

            var origin = dis1 < dis2 ? new Point(primStartPoint) : new Point(primEndPoint);
            Vector axisX, axisY;

            int index = dis1 < dis2 ? 0 : primCenterline.Count - 1;
            int step = dis1 < dis2 ? 1 : -1;
            Point p1, p2, p3;
            p1 = (Point) primCenterline[index];
            p2 = (Point) primCenterline[index + step];

            if (isCurve) {
                p3 = (Point) primCenterline[index + step + step];
                var arc = new Arc(p1, p3, p2);
                axisX = arc.StartTangent;
                axisY = arc.StartDirection;
            } else {
                var cs = prim.GetCoordinateSystem();
                axisX = new Vector(p2 - p1);
                //  PolyBeamĩ�ο��������������ϵ��һ��ƽ�У���Ӧֱ�� axisY = cs.AxisY;
                if (Parallel.VectorToVector(cs.AxisY, axisX))
                    axisY = cs.AxisX.Cross(cs.AxisY);
                else
                    axisY = cs.AxisY;
            }

            workTP = new TransformationPlane(origin, axisX, axisY);

            Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);
        }

        private void CreatConnection() {

            #region ��ʼ��Ϣ
            var origin = new Point();
            var axisX = new Vector(1, 0, 0);
            var axisY = new Vector(0, 1, 0);
            var axisZ = new Vector(0, 0, 1);

            var prim = (Part) Model.SelectModelObject(Primary);
            var sec = (Part) Model.SelectModelObject(Secondaries[0]);

            var primCenterline = prim.GetCenterLine(false);
            var secCenterline = sec.GetCenterLine(false);
            var primStartPoint = (Point) primCenterline[0];
            var primEndPoint = (Point) primCenterline[primCenterline.Count - 1];
            var secStartPoint = (Point) secCenterline[0];
            var secEndPoint = (Point) secCenterline[secCenterline.Count - 1];

            var dis1 = TSG.Distance.PointToPoint(origin, primStartPoint);
            var dis2 = TSG.Distance.PointToPoint(origin, primEndPoint);
            primDiameter = dis1 < dis2 ? primProfile.d1 : primProfile.d2;
            dis1 = TSG.Distance.PointToPoint(origin, secStartPoint);
            dis2 = TSG.Distance.PointToPoint(origin, secEndPoint);
            secDiameter = dis1 < dis2 ? secProfile.d1 : secProfile.d2;

            var rotationAngel = 2 * Math.PI / quantity;
            #endregion

            Point p1, p2, p3, p4;
            Chamfer chamfer;
            ContourPoint cp1, cp2, cp3, cp4;

            #region �������
            var plane = new Plane {
                Origin = new Point(endPlateTHK, 0, 0),
                AxisX = axisY,
                AxisY = axisZ,
            };
            var fitting = new Fitting {
                Father = prim,
                Plane = plane,
            };
            fitting.Insert();
            plane.Origin.X *= -1;
            fitting = new Fitting {
                Father = sec,
                Plane = plane,
            };
            fitting.Insert();
            #endregion

            #region �����˰岢����
            var width = endPlateDIAM * 0.5;
            p1 = new Point(0, 0, width);
            p2 = new Point(0, width, 0);
            p3 = new Point(0, 0, -1 * width);
            p4 = new Point(0, -1 * width, 0);
            chamfer = new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT);
            cp1 = new ContourPoint(p1, new Chamfer());
            cp2 = new ContourPoint(p2, chamfer);
            cp3 = new ContourPoint(p3, new Chamfer());
            cp4 = new ContourPoint(p4, chamfer);
            var endplate1 = ModelOperation.CreatContourPlate(
                new ArrayList { cp1, cp2, cp3, cp4 },
                profileStr: "PL" + endPlateTHK,
                materialStr: material,
                depthEnum: Position.DepthEnum.BEHIND);
            var endplate2 = ModelOperation.CreatContourPlate(
                new ArrayList { cp1, cp2, cp3, cp4 },
                profileStr: "PL" + endPlateTHK,
                materialStr: material,
                depthEnum: Position.DepthEnum.FRONT);

            ModelOperation.CreatWeld(prim, endplate1);
            ModelOperation.CreatWeld(sec, endplate2);
            #endregion

            #region �����Ӿ��岢����
            var height = (endPlateDIAM - primDiameter) * 0.5 - margin;

            p1 = new Point(endPlateTHK, 0, height + primDiameter * 0.5);
            p2 = new Point(endPlateTHK + stifWidth, 0, height + primDiameter * 0.5);
            p3 = new Point(endPlateTHK + stifWidth, 0, primDiameter * 0.5);
            p4 = new Point(endPlateTHK, 0, primDiameter * 0.5);
            chamfer = new Chamfer(chamX, chamY, Chamfer.ChamferTypeEnum.CHAMFER_LINE);

            if (creatPrimStif == 0) goto skipPrimStif;
            cp1 = new ContourPoint(p1, new Chamfer());
            cp2 = new ContourPoint(p2, chamfer);
            cp3 = new ContourPoint(p3, new Chamfer());
            cp4 = new ContourPoint(p4, new Chamfer());
            var stifPrim = ModelOperation.CreatContourPlate(
                new ArrayList { cp1, cp2, cp3, cp4 },
                profileStr: "PL" + stifTHK,
                materialStr: material);
            var listStifPrim = ModelOperation.Copy_Rotate(stifPrim, origin, axisX, rotationAngel, quantity - 1);
            listStifPrim.Add(stifPrim);
            foreach (var item in listStifPrim) {
                ModelOperation.CreatWeld(prim, item);
                ModelOperation.CreatWeld(endplate1, item);
            }
        skipPrimStif:

            if (creatSecStif == 0) goto skipSecStif;
            p1.X *= -1;
            p2.X *= -1;
            p3.X *= -1;
            p4.X *= -1;
            p3.Z += (secDiameter - primDiameter) * 0.5;
            p4.Z += (secDiameter - primDiameter) * 0.5;
            cp1 = new ContourPoint(p1, new Chamfer());
            cp2 = new ContourPoint(p2, chamfer);
            cp3 = new ContourPoint(p3, new Chamfer());
            cp4 = new ContourPoint(p4, new Chamfer());
            var stifSec = ModelOperation.CreatContourPlate(
                new ArrayList { cp1, cp2, cp3, cp4 },
                profileStr: "PL" + stifTHK,
                materialStr: material);
            var listStifSec = ModelOperation.Copy_Rotate(stifSec, origin, axisX, rotationAngel, quantity - 1);
            listStifSec.Add(stifSec);
            foreach (var item in listStifSec) {
                ModelOperation.CreatWeld(sec, item);
                ModelOperation.CreatWeld(endplate2, item);
            }
        skipSecStif:
            #endregion

            #region ������˨
            if (creatBolt == 0) goto skipBolt;
            p2 = new Point(0, 100, 0);
            var rM = MatrixFactory.Rotate(rotationAngel * 0.5, axisX);
            p2 = rM.Transform(p2);
            ModelOperation.CreatBoltCircle(endplate1, endplate2, null,
                firstPosition: origin, secondPosition: p2, num: quantity, diameter: boltCircleDiameter,
                bolt_standard: boltStandard, bolt_size: boltSize);
        skipBolt:
            ;
            #endregion
        }
        #endregion
    }
}