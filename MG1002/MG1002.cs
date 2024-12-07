using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.Model;
using Muggle.TeklaPlugins.Common.Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Datatype;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Plugins;
using TSG3d = Tekla.Structures.Geometry3d;

namespace Muggle.TeklaPlugins.MG1002 {
    public class MG1002Data {
        [StructuresField("prfStr_EndPlate")]
        public string prfStr_EndPlate;
        [StructuresField("prfStr_STIF_FLNG")]
        public string prfStr_STIF_FLNG;
        [StructuresField("type_STIF_WEB")]
        public int type_STIF_WEB;
        [StructuresField("prfStr_STIF_WEB")]
        public string prfStr_STIF_WEB;
        [StructuresField("cmf_Inside")]
        public double cmf_Inside;
        [StructuresField("cmf_Outside")]
        public double cmf_Outside;
        [StructuresField("disListStr_STIF_WEB")]
        public string disListStr_STIF_WEB;
        [StructuresField("prfStr_VERT")]
        public string prfStr_VERT;
        [StructuresField("prfStr_DIAG")]
        public string prfStr_DIAG;
        [StructuresField("pos_DIAG1")]
        public double pos_DIAG1;
        [StructuresField("pos_DIAG2")]
        public double pos_DIAG2;
        [StructuresField("bolt_Standard")]
        public string bolt_Standard;
        [StructuresField("bolt_Size")]
        public double bolt_Size;
        [StructuresField("disListStr_bolt_X")]
        public string disListStr_bolt_X;
        [StructuresField("disListStr_bolt_Y")]
        public string disListStr_bolt_Y;
        [StructuresField("materialStr")]
        public string materialStr;
        [StructuresField("group_no")]
        public int group_no;
    }

    [Plugin("MG1002")]
    [PluginUserInterface("MuggleTeklaPlugins.MG1002.FormMG1002")]
    [SecondaryType(SecondaryType.SECONDARYTYPE_TWO)]
    [AutoDirectionType(AutoDirectionTypeEnum.AUTODIR_BASIC)]
    public class MG1002 : ConnectionBase {
        #region Fields
        private readonly Model _model;
        private readonly MG1002Data _data;

        private string prfStr_EndPlate;
        private string prfStr_STIF_FLNG;
        private int type_STIF_WEB;
        private string prfStr_STIF_WEB;
        private double cmf_Inside;
        private double cmf_Outside;
        private string disListStr_STIF_WEB;
        private DistanceList disList_STIF_WEB;
        private string prfStr_VERT;
        private string prfStr_DIAG;
        private double pos_DIAG1;
        private double pos_DIAG2;
        private string bolt_Standard;
        private double bolt_Size;
        private string disListStr_bolt_X;
        private DistanceList disList_bolt_X;
        private string disListStr_bolt_Y;
        private DistanceList disList_bolt_Y;
        private string materialStr;
        private int group_no;

        private ProfileH_Symmetrical prfPrim;
        private ProfileH prfSecL, prfSecR;
        private ProfilePlate prfEndPlate, prfVert, prfDiag, prfStifFlange, prfStifWeb;
        private TransformationPlane originTP, workTP;
        #endregion

        #region Constructor
        public MG1002(MG1002Data data) {
            _model = new Model();
            _data = data;
            GetValuesFromDialog();
        }
        #endregion

        #region Overrides

        public override bool Run() {
            bool resault = false;
            try {
                if (Primary == null || Secondaries == null || Secondaries.Count != 2)
                    throw new Exception("需要一个主零件，两个次零件！");

                var PRIMPart = (Beam) _model.SelectModelObject(Primary);
                var SECPart1 = (Beam) _model.SelectModelObject(Secondaries[0]);
                var SECPart2 = (Beam) _model.SelectModelObject(Secondaries[1]);

                CheckIfAcceptableProfile(PRIMPart, SECPart1, SECPart2);

                if (originTP == null)
                    originTP = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

                if (workTP == null)
                    workTP = GetWorkTransformationPlane(PRIMPart);
                _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);

                CreatConnection(PRIMPart, SECPart1, SECPart2);

                resault = true;
            } catch (Exception Exc) {
                MessageBox.Show(Exc.ToString());
            }

            return resault;
        }
        #endregion

        #region Private methods
        private void GetValuesFromDialog() {
            prfStr_EndPlate = _data.prfStr_EndPlate;
            prfStr_STIF_FLNG = _data.prfStr_STIF_FLNG;
            type_STIF_WEB = _data.type_STIF_WEB;
            prfStr_STIF_WEB = _data.prfStr_STIF_WEB;
            cmf_Inside = _data.cmf_Inside;
            cmf_Outside = _data.cmf_Outside;
            disListStr_STIF_WEB = _data.disListStr_STIF_WEB;
            prfStr_VERT = _data.prfStr_VERT;
            prfStr_DIAG = _data.prfStr_DIAG;
            pos_DIAG1 = _data.pos_DIAG1;
            pos_DIAG2 = _data.pos_DIAG2;
            bolt_Standard = _data.bolt_Standard;
            bolt_Size = _data.bolt_Size;
            disListStr_bolt_X = _data.disListStr_bolt_X;
            disListStr_bolt_Y = _data.disListStr_bolt_Y;
            materialStr = _data.materialStr;
            group_no = _data.group_no;

            if (IsDefaultValue(prfStr_EndPlate) || prfStr_EndPlate == string.Empty)
                prfStr_EndPlate = "PL30*460*1093";
            prfEndPlate = new ProfilePlate(prfStr_EndPlate);
            if (prfEndPlate.t == 0.0 || prfEndPlate.b == 0.0 || prfEndPlate.l == 0.0)
                throw new ArgumentException("端板规格应提供完整参数，不得省略。例如：PL30*460*1093。");

            if (IsDefaultValue(prfStr_STIF_FLNG) || prfStr_STIF_FLNG == string.Empty)
                prfStr_STIF_FLNG = "PL10*115*175";
            prfStifFlange = new ProfilePlate(prfStr_STIF_FLNG);
            if (prfStifFlange.t == 0.0 || prfStifFlange.b == 0.0 || prfStifFlange.l == 0.0)
                throw new ArgumentException("翼缘加劲板规格应提供完整参数，不得省略。例如：PL10*115*175。");

            if (IsDefaultValue(type_STIF_WEB))
                type_STIF_WEB = 0;

            if (IsDefaultValue(prfStr_STIF_WEB) || prfStr_STIF_WEB == string.Empty)
                prfStr_STIF_WEB = "PL10*225*225";
            prfStifWeb = new ProfilePlate(prfStr_STIF_WEB);
            if (prfStifWeb.t == 0.0 || prfStifWeb.b == 0.0 || prfStifWeb.l == 0.0)
                throw new ArgumentException("腹板加劲板规格应提供完整参数，不得省略。例如：PL10*225*225。");

            if (IsDefaultValue(cmf_Inside))
                cmf_Inside = 20;
            if (IsDefaultValue(cmf_Outside))
                cmf_Outside = 25;
            if (IsDefaultValue(disListStr_STIF_WEB) || disListStr_STIF_WEB == string.Empty)
                disListStr_STIF_WEB = "233 387";

            if (IsDefaultValue(prfStr_VERT) || prfStr_VERT == string.Empty)
                prfStr_VERT = "PL18";
            prfVert = new ProfilePlate(prfStr_VERT);
            if (prfVert.t == 0.0 || prfVert.l != 0.0)
                throw new ArgumentException("竖板规格必须提供厚度参数，可省略宽度参数，不需要长度参数。例如：PL18 或 PL18*150。");

            if (IsDefaultValue(prfStr_DIAG) || prfStr_DIAG == string.Empty)
                prfStr_DIAG = string.Empty;
            if (prfStr_DIAG != string.Empty) {
                prfDiag = new ProfilePlate(prfStr_DIAG);
                if (prfDiag.t == 0.0 && prfDiag.b != 0.0 || prfDiag.l != 0.0)
                    throw new ArgumentException("对角板规格可不填 或 仅提供厚度参数 或 同时提供厚度和宽度参数，不需要长度参数。" +
                        "例如：PL8 或 PL8*150。");
            }

            if (IsDefaultValue(pos_DIAG1))
                pos_DIAG1 = 100;
            if (IsDefaultValue(pos_DIAG2))
                pos_DIAG2 = 100;
            if (IsDefaultValue(bolt_Standard) || bolt_Standard == string.Empty)
                bolt_Standard = "HS10.9";
            if (IsDefaultValue(bolt_Size) || bolt_Size == 0)
                bolt_Size = 27;
            if (IsDefaultValue(disListStr_bolt_X) || disListStr_bolt_X == string.Empty)
                disListStr_bolt_X = "60 138 90 130 257 130 90 138";
            if (IsDefaultValue(disListStr_bolt_Y) || disListStr_bolt_Y == string.Empty)
                disListStr_bolt_Y = "220";
            if (IsDefaultValue(materialStr) || materialStr == string.Empty)
                materialStr = "Q345B";
            if (IsDefaultValue(group_no))
                group_no = -1;

            disList_STIF_WEB = DistanceList.Parse(disListStr_STIF_WEB, System.Globalization.CultureInfo.InvariantCulture, Tekla.Structures.Datatype.Distance.CurrentUnitType);
            disList_bolt_X = DistanceList.Parse(disListStr_bolt_X, System.Globalization.CultureInfo.InvariantCulture, Tekla.Structures.Datatype.Distance.CurrentUnitType);
            disList_bolt_Y = DistanceList.Parse(disListStr_bolt_Y, System.Globalization.CultureInfo.InvariantCulture, Tekla.Structures.Datatype.Distance.CurrentUnitType);
        }
        /// <summary>
        /// 主零件仅支持等截面和对称变截面H型钢，次零件仅支持等截面和楔形H型钢
        /// </summary>
        /// <param name="primPart"></param>
        /// <param name="secPart_L"></param>
        /// <param name="secPart_R"></param>
        /// <exception cref="UnAcceptableProfile">当选择的零件不支持时抛出。</exception>
        private void CheckIfAcceptableProfile(Beam primPart, Beam secPart_L, Beam secPart_R) {
            try {
                prfPrim = new ProfileH_Symmetrical(primPart.Profile.ProfileString);
                prfSecL = new ProfileH(secPart_L.Profile.ProfileString);
                prfSecR = new ProfileH(secPart_R.Profile.ProfileString);

                if (prfPrim.b2 != prfPrim.b1)
                    throw new UnAcceptableProfile(prfPrim.ProfileText);
                if (prfSecL.ProfileText.Contains("I_VAR_A") && prfSecL.h2 != prfSecL.h1 || prfSecL.b2 != prfSecL.b1)
                    throw new UnAcceptableProfile(prfSecL.ProfileText);
                if (prfSecR.ProfileText.Contains("I_VAR_A") && prfSecR.h2 != prfSecR.h1 || prfSecR.b2 != prfSecR.b1)
                    throw new UnAcceptableProfile(prfSecR.ProfileText);
            } catch (UnAcceptableProfile) {
                throw;
            }
        }
        /// <summary>
        /// 获取工作平面。
        /// </summary>
        /// <param name="primPart"></param>
        /// <returns>原点为柱顶点，X轴为柱的零件坐标系Y轴，Y轴为柱的零件坐标系X轴，若柱是从上往下绘制则Y轴反向。</returns>
        private TransformationPlane GetWorkTransformationPlane(Beam primPart) {
            Point origin;
            Vector axisX, axisY;
            double disStart, disEnd;

            var zeroPoint = new Point();
            disStart = TSG3d.Distance.PointToPoint(zeroPoint, primPart.StartPoint);
            disEnd = TSG3d.Distance.PointToPoint(zeroPoint, primPart.EndPoint);

            origin = new Point(disStart > disEnd ? primPart.EndPoint : primPart.StartPoint);
            axisX = new Vector(primPart.GetCoordinateSystem().AxisY);
            axisY = new Vector(primPart.GetCoordinateSystem().AxisX);
            axisY *= disStart > disEnd ? 1 : -1;

            return new TransformationPlane(origin, axisX, axisY);
        }
        private void CreatConnection(Beam primPart, Beam secPart1, Beam secPart2) {

            Point origin = new Point();
            var axisX = new Vector(1, 0, 0);
            var axisY = new Vector(0, 1, 0);
            var axisZ = new Vector(0, 0, 1);

            #region 定义左、右梁
            //  与柱零件坐标系Y轴同向为右梁，反向为左梁

            var disStart = TSG3d.Distance.PointToPoint(origin, secPart1.StartPoint);
            var disEnd = TSG3d.Distance.PointToPoint(origin, secPart1.EndPoint);
            var direction = new Vector(disStart > disEnd ? secPart1.StartPoint : secPart1.EndPoint);

            var secPartL = secPart1;
            var secPartR = secPart2;
            if (direction.Dot(axisX) > 0) (secPartL, secPartR) = (secPartR, secPartL);
            #endregion

            #region 主次零件规格、边线
            CoordinateSystem primCS, secLCS, secRCS;
            primCS = primPart.GetCoordinateSystem();
            secLCS = secPartL.GetCoordinateSystem();
            secRCS = secPartR.GetCoordinateSystem();

            Point point1, point2, point3, point4, point5, point6;
            Line prim_CLine, prim_LLine, prim_RLine, secL_TLine, secL_BLine, secR_TLine, secR_BLine;
            ArrayList centerline;
            centerline = primPart.GetCenterLine(false);
            //  不清楚什么原因，有时候Z坐标会是一个很小的数，这里要消除误差
            foreach (Point point in centerline) {
                if (Math.Abs(point.Z) < GeometryConstants.DISTANCE_EPSILON) point.Z = 0;
            }
            point1 = (Point) centerline[0];
            point2 = (Point) centerline[1];
            prim_CLine = new Line(point1, point2);

            point3 = new Point(point1).TransformTo(primCS);
            point4 = new Point(point2).TransformTo(primCS);
            point3.Translate(0, prfPrim.h1 * -0.5, 0);
            point4.Translate(0, prfPrim.h2 * -0.5, 0);
            point3 = point3.TransformFrom(primCS);
            point4 = point4.TransformFrom(primCS);
            prim_LLine = new Line(point3, point4);

            point5 = new Point(point1).TransformTo(primCS);
            point6 = new Point(point2).TransformTo(primCS);
            point5.Translate(0, prfPrim.h1 * 0.5, 0);
            point6.Translate(0, prfPrim.h2 * 0.5, 0);
            point5 = point5.TransformFrom(primCS);
            point6 = point6.TransformFrom(primCS);
            prim_RLine = new Line(point5, point6);

            if (axisY.Dot(primCS.AxisX) < 0) {
                prim_CLine.Direction *= -1;
                prim_LLine.Direction *= -1;
                prim_RLine.Direction *= -1;
            }//  方向统一成从底指向顶

            centerline = secPartL.GetCenterLine(false);
            //  不清楚什么原因，有时候Z坐标会是一个很小的数，这里要消除误差
            foreach (Point point in centerline) {
                if (Math.Abs(point.Z) < GeometryConstants.DISTANCE_EPSILON) point.Z = 0;
            }
            point1 = new Point((Point) centerline[0]).TransformTo(secLCS);
            point2 = new Point((Point) centerline[1]).TransformTo(secLCS);
            point3 = new Point(point1);
            point4 = new Point(point2);

            //  楔形梁中心线穿过末端截面的中点，所以此处均为h2
            point1.Translate(0, prfSecL.h2 * -0.5, 0);
            point2.Translate(0, prfSecL.h2 * -0.5, 0);
            point3.Translate(0, prfSecL.h1 - prfSecL.h2 * 0.5, 0);
            point4.Translate(0, prfSecL.h2 * 0.5, 0);
            point1 = point1.TransformFrom(secLCS);
            point2 = point2.TransformFrom(secLCS);
            point3 = point3.TransformFrom(secLCS);
            point4 = point4.TransformFrom(secLCS);

            secL_TLine = new Line(point1, point2);
            secL_BLine = new Line(point3, point4);

            if (axisX.Dot(secLCS.AxisX) < 0) {
                secL_TLine.Direction *= -1;
                secL_BLine.Direction *= -1;
            }//  方向统一成从远端指向近端

            centerline = secPartR.GetCenterLine(false);
            //  不清楚什么原因，有时候Z坐标会是一个很小的数，这里要消除误差
            foreach (Point point in centerline) {
                if (Math.Abs(point.Z) < GeometryConstants.DISTANCE_EPSILON) point.Z = 0;
            }
            point1 = new Point((Point) centerline[0]).TransformTo(secRCS);
            point2 = new Point((Point) centerline[1]).TransformTo(secRCS);
            point3 = new Point(point1);
            point4 = new Point(point2);

            point1.Translate(0, prfSecR.h2 * -0.5, 0);
            point2.Translate(0, prfSecR.h2 * -0.5, 0);
            point3.Translate(0, prfSecR.h1 - prfSecR.h2 * 0.5, 0);
            point4.Translate(0, prfSecR.h2 * 0.5, 0);
            point1 = point1.TransformFrom(secRCS);
            point2 = point2.TransformFrom(secRCS);
            point3 = point3.TransformFrom(secRCS);
            point4 = point4.TransformFrom(secRCS);

            secR_TLine = new Line(point1, point2);
            secR_BLine = new Line(point3, point4);

            if (axisX.Dot(secRCS.AxisX) > 0) {
                secR_TLine.Direction *= -1;
                secR_BLine.Direction *= -1;
            }//  方向统一成从远端指向近端

            #endregion

            #region 创建端板
            var e1 = Math.Sqrt(Math.Pow(prfEndPlate.t, 2) + Math.Pow(prfEndPlate.l * 0.5, 2));
            var secL_BLine_inside = secL_BLine.Offset(prfSecL.t2, LineExtension.OffsetDirectionEnum.LEFT);
            var secR_BLine_inside = secR_BLine.Offset(prfSecR.t2, LineExtension.OffsetDirectionEnum.RIGHT);

            Line endPlateLine;
            Beam endPlate1, endPlate2;
            Vector translateVector = null;
            var xPoint = IntersectionExtension.LineToLine(secL_BLine_inside, secR_BLine_inside).StartPoint;
            var positionOfTriangle = Geometry3dOperation.PositionOfTriangleOnLines(
                    (secL_BLine_inside, secR_BLine_inside, prim_CLine),
                    (e1, e1, prfEndPlate.l)) ?? throw new Exception("根据现有参数，端板无法放置，请检查并调整参数。");
            foreach (var (P1, P2, P3) in positionOfTriangle) {

                //  抛弃P3在上方的组合
                translateVector = new Vector(P3 - (P1 + P2).Multiply(0.5));
                if (Vector.Dot(translateVector, axisY) >= 0)
                    continue;
                //  抛弃P1在延长线上的组合
                if (Vector.Dot(new Vector(P1 - xPoint), secL_BLine_inside.Direction) >= 0)
                    continue;
                //  抛弃P2在延长线上的组合
                if (Vector.Dot(new Vector(P2 - xPoint), secR_BLine_inside.Direction) >= 0)
                    continue;

                //  最多可能仍有2组解，不做区分，直接使用第1组解
                point1 = P1;
                point2 = P2;
                point3 = P3;

                break;//  跳过可能存在的第2组解
            }
            point1.Translate(translateVector);
            point2.Translate(translateVector);
            point3.Translate(translateVector);

            endPlateLine = new Line(point1, point2);

            endPlate1 =
                ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{prfEndPlate.t}*{prfEndPlate.b}",
                materialStr: materialStr,
                planeEnum: Position.PlaneEnum.LEFT,
                rotationEnum: Position.RotationEnum.TOP);
            endPlate2 =
                ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{prfEndPlate.t}*{prfEndPlate.b}",
                materialStr: materialStr,
                planeEnum: Position.PlaneEnum.RIGHT,
                rotationEnum: Position.RotationEnum.TOP);
            #endregion

            #region 柱末端对齐，梁末端对齐、切割
            var fitting = new Fitting {
                Father = primPart,
                Plane = new Plane {
                    Origin = new Point(point3),
                    AxisX = endPlateLine.Direction.GetNormal(),
                    AxisY = new Vector(axisZ),
                },
            };
            fitting.Insert();

            fitting = new Fitting {
                Father = secPartL,
                Plane = new Plane {
                    Origin = new Point(origin),
                    AxisX = new Vector(axisY),
                    AxisY = new Vector(axisZ),
                }
            };
            fitting.Insert();

            fitting = new Fitting {
                Father = secPartR,
                Plane = new Plane {
                    Origin = new Point(origin),
                    AxisX = new Vector(axisY),
                    AxisY = new Vector(axisZ),
                }
            };
            fitting.Insert();

            var endPlate_TLine = endPlateLine.Offset(-1 * translateVector);
            var endPlate_BLine = endPlateLine.Offset(translateVector);
            point1 = IntersectionExtension.LineToLine(secL_BLine_inside, endPlate_TLine).StartPoint;
            point2 = IntersectionExtension.LineToLine(prim_CLine, endPlate_TLine).StartPoint;
            point3 = IntersectionExtension.LineToLine(prim_CLine, secL_BLine).StartPoint;
            point4 = point1 + translateVector;
            var booleanOperator = ModelOperation.CreatBooleanOperationPolygon(new Point[] { point1, point2, point3, point4 }, prfSecL.b1);
            ModelOperation.ApplyBooleanOperation(secPartL, booleanOperator);
            booleanOperator.Delete();

            point1 = IntersectionExtension.LineToLine(secR_BLine_inside, endPlate_TLine).StartPoint;
            point3 = IntersectionExtension.LineToLine(prim_CLine, secR_BLine).StartPoint;
            point4 = point1 + translateVector;
            booleanOperator = ModelOperation.CreatBooleanOperationPolygon(new Point[] { point1, point2, point3, point4 }, prfSecR.b1);
            ModelOperation.ApplyBooleanOperation(secPartR, booleanOperator);
            booleanOperator.Delete();
            #endregion

            #region 创建竖板
            Beam vertPlate_LF, vertPlate_LB, vertPlate_RF, vertPlate_RB;

            if (prfVert.b == 0.0) prfVert.b = (prfPrim.b1 - prfSecL.s) * 0.5;

            var secL_TLine_inside = secL_TLine.Offset(prfSecL.t1, LineExtension.OffsetDirectionEnum.RIGHT);
            var secR_TLine_inside = secR_TLine.Offset(prfSecR.t1, LineExtension.OffsetDirectionEnum.LEFT);
            var vert_LLine = new Line {
                Origin = IntersectionExtension.LineToLine(prim_LLine, endPlate_BLine).StartPoint,
                Direction = new Vector(axisY),
            };
            var vert_RLine = new Line {
                Origin = IntersectionExtension.LineToLine(prim_RLine, endPlate_BLine).StartPoint,
                Direction = new Vector(axisY),
            };

            point1 = IntersectionExtension.LineToLine(vert_LLine, secL_TLine_inside).StartPoint;
            point2 = IntersectionExtension.LineToLine(vert_LLine, endPlate_TLine).StartPoint;
            point3 = IntersectionExtension.LineToLine(vert_LLine.Offset(prfVert.t, LineExtension.OffsetDirectionEnum.RIGHT), secL_TLine_inside).StartPoint;
            point4 = IntersectionExtension.LineToLine(vert_LLine.Offset(prfVert.t, LineExtension.OffsetDirectionEnum.RIGHT), endPlate_TLine).StartPoint;

            point1.Y = point1.Y < point3.Y ? point1.Y : point3.Y;
            point2.Y = point2.Y > point4.Y ? point2.Y : point4.Y;
            point1.Z = prfSecL.s * 0.5;
            point2.Z = point1.Z;

            vertPlate_LF = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{prfVert.t}*{prfVert.b}",
                materialStr: materialStr,
                planeEnum: Position.PlaneEnum.LEFT,
                depthEnum: Position.DepthEnum.FRONT,
                rotationEnum: Position.RotationEnum.TOP);

            point1.Z *= -1; point2.Z *= -1;
            vertPlate_LB = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{prfVert.t}*{prfVert.b}",
                materialStr: materialStr,
                planeEnum: Position.PlaneEnum.LEFT,
                depthEnum: Position.DepthEnum.BEHIND,
                rotationEnum: Position.RotationEnum.BELOW);

            point1 = IntersectionExtension.LineToLine(vert_RLine, secR_TLine_inside).StartPoint;
            point2 = IntersectionExtension.LineToLine(vert_RLine, endPlate_TLine).StartPoint;
            point3 = IntersectionExtension.LineToLine(vert_RLine.Offset(prfVert.t, LineExtension.OffsetDirectionEnum.LEFT), secR_TLine_inside).StartPoint;
            point4 = IntersectionExtension.LineToLine(vert_RLine.Offset(prfVert.t, LineExtension.OffsetDirectionEnum.LEFT), endPlate_TLine).StartPoint;

            point1.Y = point1.Y < point3.Y ? point1.Y : point3.Y;
            point2.Y = point2.Y > point4.Y ? point2.Y : point4.Y;
            point1.Z = prfSecR.s * 0.5;
            point2.Z = point1.Z;

            vertPlate_RF = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{prfVert.t}*{prfVert.b}",
                materialStr: materialStr,
                planeEnum: Position.PlaneEnum.RIGHT,
                depthEnum: Position.DepthEnum.FRONT,
                rotationEnum: Position.RotationEnum.TOP);

            point1.Z *= -1; point2.Z *= -1;
            vertPlate_RB = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{prfVert.t}*{prfVert.b}",
                materialStr: materialStr,
                planeEnum: Position.PlaneEnum.RIGHT,
                depthEnum: Position.DepthEnum.BEHIND,
                rotationEnum: Position.RotationEnum.BELOW);
            #endregion

            #region 创建对角板
            Beam diagPlate_F = null, diagPlate_B = null;
            if (prfStr_DIAG == string.Empty)
                goto SkipDiagPlate;

            if (prfDiag.b == 0.0) prfDiag.b = (prfPrim.b1 - prfSecL.s) * 0.5;

            var dis_vertL_to_primC = DistanceExtension.LineToLine(vert_LLine, prim_CLine);
            var diagLine = new Line(
                IntersectionExtension.LineToLine(
                    pos_DIAG1 < dis_vertL_to_primC ? secL_TLine_inside : secR_TLine_inside,
                    vert_LLine.Offset(pos_DIAG1, LineExtension.OffsetDirectionEnum.RIGHT)).StartPoint,
                IntersectionExtension.LineToLine(
                    endPlate_TLine,
                    vert_RLine.Offset(pos_DIAG2, LineExtension.OffsetDirectionEnum.LEFT)).StartPoint);
            point1 = pos_DIAG1 < dis_vertL_to_primC ?
                IntersectionExtension.LineToLine(
                    secL_TLine_inside,
                    diagLine.Offset(prfDiag.t * 0.5, LineExtension.OffsetDirectionEnum.LEFT)).StartPoint :
                IntersectionExtension.LineToLine(
                    secR_TLine_inside,
                    diagLine.Offset(prfDiag.t * 0.5, LineExtension.OffsetDirectionEnum.RIGHT)).StartPoint;
            point2 = pos_DIAG1 < dis_vertL_to_primC ?
                IntersectionExtension.LineToLine(
                    endPlate_TLine,
                    diagLine.Offset(
                        prfDiag.t * 0.5,
                         LineExtension.OffsetDirectionEnum.RIGHT)).StartPoint :
                IntersectionExtension.LineToLine(
                    endPlate_TLine,
                    diagLine.Offset(
                        prfDiag.t * 0.5,
                        LineExtension.OffsetDirectionEnum.LEFT)).StartPoint;
            point1 = Projection.PointToLine(point1, diagLine);
            point2 = Projection.PointToLine(point2, diagLine);
            point1.Z = prfSecL.s > prfSecR.s ? prfSecL.s * 0.5 : prfSecR.s * 0.5;
            point2.Z = point1.Z;

            diagPlate_F = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: "PL" + prfDiag.t + "*" + prfDiag.b,
                materialStr: materialStr,
                depthEnum: Position.DepthEnum.FRONT,
                rotationEnum: Position.RotationEnum.TOP);
            point1.Z *= -1; point2.Z *= -1;
            diagPlate_B = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: "PL" + prfDiag.t + "*" + prfDiag.b,
                materialStr: materialStr,
                depthEnum: Position.DepthEnum.BEHIND,
                rotationEnum: Position.RotationEnum.BELOW);
        SkipDiagPlate:;
            #endregion

            #region 创建翼缘加劲板
            var chamferNone = new Chamfer();
            var chamferLine_inside = new Chamfer(cmf_Inside, cmf_Inside, Chamfer.ChamferTypeEnum.CHAMFER_LINE);
            point1 = IntersectionExtension.LineToLine(endPlate_BLine, prim_LLine).StartPoint;
            point2 = IntersectionExtension.LineToLine(
                endPlate_BLine,
                vert_LLine.Offset(prfStifFlange.b, LineExtension.OffsetDirectionEnum.LEFT)).StartPoint;
            point3 = IntersectionExtension.LineToLine(
                endPlate_BLine.Offset(prfStifFlange.l, LineExtension.OffsetDirectionEnum.RIGHT),
                prim_LLine).StartPoint;

            var stifFlange_L = ModelOperation.CreatContourPlate(
                new ArrayList {
                    new ContourPoint(point1, chamferLine_inside),
                    new ContourPoint(point2, chamferNone),
                    new ContourPoint(point3,chamferNone) },
                profileStr: "PL" + prfStifFlange.t,
                materialStr: materialStr);

            point1 = IntersectionExtension.LineToLine(endPlate_BLine, prim_RLine).StartPoint;
            point2 = IntersectionExtension.LineToLine(
                endPlate_BLine,
                vert_RLine.Offset(prfStifFlange.b, LineExtension.OffsetDirectionEnum.RIGHT)).StartPoint;
            point3 = IntersectionExtension.LineToLine(
                endPlate_BLine.Offset(prfStifFlange.l, LineExtension.OffsetDirectionEnum.RIGHT),
                prim_RLine).StartPoint;

            var stifFlange_R = ModelOperation.CreatContourPlate(
                new ArrayList {
                    new ContourPoint(point1, chamferLine_inside),
                    new ContourPoint(point2, chamferNone),
                    new ContourPoint(point3, chamferNone) },
                profileStr: "PL" + prfStifFlange.t,
                materialStr: materialStr);
            #endregion

            #region 创建腹板加劲板
            var transX = new Vector(endPlateLine.Direction);
            var transY = Vector.Cross(axisZ, transX);
            var transZ = new Vector(axisZ);
            transY.Normalize(prfStifWeb.b);
            transZ.Normalize(prfStifWeb.l);
            point1 = IntersectionExtension.LineToLine(vert_LLine, endPlate_TLine).StartPoint;
            point1.Z = prfSecL.s > prfSecR.s ? prfSecL.s * 0.5 : prfSecR.s * 0.5;
            point2 = point1 + transY;
            point3 = point2 + transZ;
            point4 = point1 + transZ;
            var chamferLine_outside = new Chamfer(cmf_Outside, cmf_Outside, Chamfer.ChamferTypeEnum.CHAMFER_LINE);
            var contourPoints = new ArrayList {
                new ContourPoint(point1, chamferLine_inside),
                new ContourPoint(point2, chamferNone),
            };
            if (type_STIF_WEB == 0)
                contourPoints.Add(new ContourPoint(point3, chamferLine_outside));
            contourPoints.Add(new ContourPoint(point4, chamferNone));
            var mirrorPlane_XY = new GeometricPlane(origin, axisZ);
            var mirrorPlane_endPlate = new GeometricPlane(endPlateLine.Origin, Vector.Cross(axisZ, endPlateLine.Direction));
            var list_StifWeb_Up = new List<ContourPlate>();
            var list_StifWeb_Down = new List<ContourPlate>();
            foreach (var dis in disList_STIF_WEB) {
                transX.Normalize(dis.Millimeters);
                foreach (ContourPoint cp in contourPoints) {
                    cp.Translate(transX);
                }
                list_StifWeb_Up.Add(ModelOperation.CreatContourPlate(
                    contourPoints,
                    profileStr: "PL" + prfStifWeb.t,
                    materialStr: materialStr));
                list_StifWeb_Up.Add(ModelOperation.CreatContourPlate(
                    Geometry3dOperation.Mirror(contourPoints, mirrorPlane_XY),
                    profileStr: "PL" + prfStifWeb.t,
                    materialStr: materialStr));
                list_StifWeb_Down.Add(ModelOperation.CreatContourPlate(
                    Geometry3dOperation.Mirror(contourPoints, mirrorPlane_endPlate),
                    profileStr: "PL" + prfStifWeb.t,
                    materialStr: materialStr));
                list_StifWeb_Down.Add(ModelOperation.CreatContourPlate(
                    Geometry3dOperation.Mirror(Geometry3dOperation.Mirror(contourPoints, mirrorPlane_XY), mirrorPlane_endPlate),
                    profileStr: "PL" + prfStifWeb.t,
                    materialStr: materialStr));
            }
            #endregion

            #region 创建螺栓
            var position = new Position {
                Rotation = Position.RotationEnum.BELOW,
            };
            ModelOperation.CreatBoltArray(
                endPlate1, endPlate2, null, endPlate1.StartPoint, endPlate1.EndPoint, disList_bolt_X, disList_bolt_Y,
                position: position, bolt_standard: bolt_Standard, bolt_size: bolt_Size);
            #endregion

            #region 焊接
            ModelOperation.CreatWeld(primPart, endPlate2);
            ModelOperation.CreatWeld(secPartL, endPlate1);
            ModelOperation.CreatWeld(secPartR, endPlate1);
            ModelOperation.CreatWeld(secPartL, secPartR);
            ModelOperation.CreatWeld(secPartL, vertPlate_LF);
            ModelOperation.CreatWeld(secPartL, vertPlate_LB);
            ModelOperation.CreatWeld(secPartR, vertPlate_RF);
            ModelOperation.CreatWeld(secPartR, vertPlate_RB);
            ModelOperation.CreatWeld(endPlate1, vertPlate_LF);
            ModelOperation.CreatWeld(endPlate1, vertPlate_LB);
            ModelOperation.CreatWeld(endPlate1, vertPlate_RF);
            ModelOperation.CreatWeld(endPlate1, vertPlate_RB);
            if (prfStr_DIAG != string.Empty) {
                ModelOperation.CreatWeld(secPartL, diagPlate_F);
                ModelOperation.CreatWeld(secPartL, diagPlate_B);
                ModelOperation.CreatWeld(secPartR, diagPlate_F);
                ModelOperation.CreatWeld(secPartR, diagPlate_B);
                ModelOperation.CreatWeld(endPlate1, diagPlate_F);
                ModelOperation.CreatWeld(endPlate1, diagPlate_B);
            }
            ModelOperation.CreatWeld(primPart, stifFlange_L);
            ModelOperation.CreatWeld(endPlate2, stifFlange_L);
            ModelOperation.CreatWeld(primPart, stifFlange_R);
            ModelOperation.CreatWeld(endPlate2, stifFlange_R);
            foreach (var stifWeb in list_StifWeb_Up) {
                ModelOperation.CreatWeld(secPartL, stifWeb);
                ModelOperation.CreatWeld(secPartR, stifWeb);
                ModelOperation.CreatWeld(endPlate1, stifWeb);
            }
            foreach (var stifWeb in list_StifWeb_Down) {
                ModelOperation.CreatWeld(primPart, stifWeb);
                ModelOperation.CreatWeld(primPart, stifWeb);
                ModelOperation.CreatWeld(endPlate2, stifWeb);
            }
            #endregion
        }

        #endregion
    }
}
