using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.Model;
using Muggle.TeklaPlugins.Common.Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Plugins;

namespace Muggle.TeklaPlugins.WK1001 {
    public class PluginData {
        [StructuresField("prfStr_Tube")]
        public string prfStr_Tube;
        [StructuresField("thick_TEndplate")]
        public double thick_TEndplate;
        [StructuresField("thick_BEndplate")]
        public double thick_BEndplate;
        [StructuresField("diam_BEndplate")]
        public double diam_BEndplate;
        [StructuresField("thick_Stiffneer")]
        public double thick_Stiffneer;
        [StructuresField("minDis")]
        public double minDis;
        [StructuresField("extLenght_T")]
        public double extLenght_T;
        [StructuresField("extLength_B")]
        public double extLength_B;
        [StructuresField("materialStr")]
        public string materialStr;
        [StructuresField("group_no")]
        public int group_no;

    }
    [Plugin("WK1001")]
    [PluginUserInterface("Muggle.TeklaPlugins.WK1001.FormWK1001")]
    [SecondaryType(SecondaryType.SECONDARYTYPE_MULTIPLE)]
    public class WK1001 : ConnectionBase {
        #region Fields
        private Model _model;
        private PluginData _data;

        private string _prfStr_Tube;
        private double _thick_TEndplate;
        private double _thick_BEndplate;
        private double _diam_BEndplate;
        private double _thick_Stiffneer;
        private double _minDis;
        private double _extLenght_T;
        private double _extLength_B;
        private string _materialStr;
        private int _group_no;

        private List<Beam> parts;
        private List<ProfileRect_Invariant> profiles;
        private List<Line> centerlines;
        private List<double> angles;//杆件间依次角度，即2号与1号之间、3号与2号之间...
        private bool ordered = false;

        private TransformationPlane globalTP, originTP, workTP;
        #endregion

        #region Properties
        public Model Model {
            get => _model;
            set => _model = value;
        }
        public PluginData Data {
            get => _data;
            set {
                _data = value;
                GetValuesFromDialog();
            }
        }
        #endregion

        #region Constructor
        public WK1001(PluginData data) {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region MainMethod

        public override bool Run() {
            bool flag = false;
            try {

                if (parts == null) GetParts();

                if (globalTP == null) globalTP = new TransformationPlane();
                if (originTP == null) originTP = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
                if (workTP == null) workTP = GetWorkTransformationPlane();
                _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(workTP);

                if (!ordered) {
                    OrderParts();
                    ordered = true;
                }

                flag = CreatConnection();

            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }

            return flag;
        }
        #endregion

        #region PrivateMethods
        private void GetValuesFromDialog() {
            _prfStr_Tube = _data.prfStr_Tube;
            _thick_TEndplate = _data.thick_TEndplate;
            _thick_BEndplate = _data.thick_BEndplate;
            _diam_BEndplate = _data.diam_BEndplate;
            _thick_Stiffneer = _data.thick_Stiffneer;
            _minDis = _data.minDis;
            _extLenght_T = _data.extLenght_T;
            _extLength_B = _data.extLength_B;
            _materialStr = _data.materialStr;
            _group_no = _data.group_no;

            if (IsDefaultValue(_thick_TEndplate))
                _thick_TEndplate = 40;
            if (IsDefaultValue(_thick_BEndplate))
                _thick_BEndplate = 40;
            if (IsDefaultValue(_thick_Stiffneer))
                _thick_Stiffneer = 25;
            if (IsDefaultValue(_minDis))
                _minDis = 50;
            if (IsDefaultValue(_extLenght_T))
                _extLenght_T = 20;
            if (IsDefaultValue(_extLength_B))
                _extLength_B = 20;
            if (IsDefaultValue(_materialStr))
                _materialStr = "Q345B";
            if (IsDefaultValue(_group_no))
                _group_no = -1;
        }
        private void GetParts() {

            if (parts != null) return;

            parts = new List<Beam> {
                    _model.SelectModelObject(Primary) as Beam,
                };
            foreach (var identifier in Secondaries) {
                parts.Add(_model.SelectModelObject(identifier) as Beam);
            }

            ArrayList centerline;
            Point point1, point2, origin = new Point();

            profiles = new List<ProfileRect_Invariant>();
            centerlines = new List<Line>();
            angles = new List<double>();
            foreach (var part in parts) {
                profiles.Add(new ProfileRect_Invariant(part.Profile.ProfileString));
                centerline = part.GetCenterLine(false);
                point1 = centerline[0] as Point;
                point2 = centerline[1] as Point;
                centerlines.Add(Distance.PointToPoint(origin, point1) < Distance.PointToPoint(origin, point2) ?
                    new Line(point1, point2) : new Line(point2, point1));//统一成从中心指向外围
            }
        }
        private TransformationPlane GetWorkTransformationPlane() {

            Vector normal;

            //根据前三个选择的杆件求共同法向（此时零件尚未排序）
            var origin = Math.Min(Distance.PointToPoint(parts[0].StartPoint, parts[1].StartPoint),
                                    Distance.PointToPoint(parts[0].StartPoint, parts[1].EndPoint))
                        < Math.Min(Distance.PointToPoint(parts[0].EndPoint, parts[1].StartPoint),
                                    Distance.PointToPoint(parts[0].EndPoint, parts[1].EndPoint)) ?
                parts[0].StartPoint : parts[0].EndPoint;
            var p0 = Distance.PointToPoint(origin, parts[0].StartPoint) > Distance.PointToPoint(origin, parts[0].EndPoint) ?
                parts[0].StartPoint : parts[0].EndPoint;
            var p1 = Distance.PointToPoint(origin, parts[1].StartPoint) > Distance.PointToPoint(origin, parts[1].EndPoint) ?
                parts[1].StartPoint : parts[1].EndPoint;
            var p2 = Distance.PointToPoint(origin, parts[2].StartPoint) > Distance.PointToPoint(origin, parts[2].EndPoint) ?
                parts[2].StartPoint : parts[2].EndPoint;

            var v0 = new Vector(p0 - origin).GetNormal(500);
            var v1 = new Vector(p1 - origin).GetNormal(500);
            var v2 = new Vector(p2 - origin).GetNormal(500);

            p0 = origin + v0; p1 = origin + v1; p2 = origin + v2;

            var gplane = GeometricPlaneFactory.ByPoints(p0, p1, p2);

            if (origin == Projection.PointToPlane(origin, gplane)) {
                //在同一平面上
                normal = gplane.GetNormal();
            } else {
                //不在同一平面上
                normal = new Vector(origin - Geometry3dOperation.CenterOfSphere(origin, p0, p1, p2));
            }

            if (Vector.Dot(normal, new Vector(0, 0, 500).TransformFrom(globalTP)) < 0)
                normal *= -1;//使法向基本朝上

            var axisY = Vector.Cross(normal, v0);
            var axisX = Vector.Cross(axisY, normal);

            return new TransformationPlane(origin, axisX, axisY);
        }
        /// <summary>
        /// 按模型中实际的顺序（逆时针方向）调整零件顺序，
        /// 字段parts, profiles, centerlines, angles均调整。
        /// 同时将centerlines的原点和方向转换到workTP。
        /// </summary>
        private void OrderParts() {

            var axisX = new Vector(1, 0, 0);
            var axisZ = new Vector(0, 0, 1);
            var XYPlane = new GeometricPlane(new Point(), axisZ);
            angles = new List<double>();
            foreach (var line in centerlines) {
                line.Origin = new Point();
                line.Direction = line.Direction.TransformFrom(originTP);
                //当前先均按与X轴间角度赋值，后面再调整为杆件间依次角度
                angles.Add(axisX.GetAngleBetween_WithDirection(
                    ProjectionExtension.VectorToPlane(line.Direction, XYPlane),
                    axisZ));
            }

            var sort = angles.Select((value, index) => (Value: value, OriginalIndex: index)).OrderBy(resault => resault.Value).ToArray();
            var sortedIndex = sort.Select(x => x.OriginalIndex).ToArray();

            var newParts = new Beam[sortedIndex.Length];
            var newProfiles = new ProfileRect_Invariant[sortedIndex.Length];
            var newCenterlines = new Line[sortedIndex.Length];
            var newAngles = new double[sortedIndex.Length];
            for (int i = 0; i < sortedIndex.Length; i++) {
                newParts[i] = parts[sortedIndex[i]];
                newProfiles[i] = profiles[sortedIndex[i]];
                newCenterlines[i] = centerlines[sortedIndex[i]];
                newAngles[i] = angles[sortedIndex[i]];
            }
            //调整为杆件间依次角度
            angles[0] = Math.PI * 2 + newAngles[0] - newAngles[newAngles.Length - 1];
            for (int i = 1; i < newAngles.Length; i++) {
                angles[i] = newAngles[i] - newAngles[i - 1];
            }

            parts.Clear(); parts.AddRange(newParts);
            profiles.Clear(); profiles.AddRange(newProfiles);
            centerlines.Clear(); centerlines.AddRange(newCenterlines);
        }
        private bool CreatConnection() {

            Point point1, point2, point3, point4;
            bool typeA = IsDefaultValue(_diam_BEndplate) || _diam_BEndplate == 0;
            var chamferNone = new Chamfer();
            var chamferArcPoint = new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT);

            #region 创建连接筒
            if (_prfStr_Tube != string.Empty)
                goto Skip_prfStr_Tube;

            var maxWidth = (from prf in profiles select prf.b1).Max();
            var minAngle = angles.Min();

            //此处求半径做了简化处理，正确值应当用以下公式计算
            //arcsin(0.5a/r)+arcsin(0.5b/r)+2*arcsin(0.5w/r)=angle
            //其中a, b分别为相邻杆件的宽度，angle为相邻杆件夹角
            //w为相邻杆件间最小间距，r为连接筒半径
            var diameter = (maxWidth + _minDis) / minAngle * 2;
            var diameterArray = from prf in ProfileCircular_Perfect.CommonlyUsed
                                where prf.d1 > diameter
                                select prf.d1;
            if (diameterArray.Count() != 0) {
                diameter = diameterArray.Min();
            } else {
                diameter = Math.Ceiling(diameter * 0.1) * 10;
            }

            var thickness = Math.Max(_thick_TEndplate, _thick_BEndplate);
            var thicknessArray = from prf in ProfileCircular_Perfect.CommonlyUsed
                                 where prf.d1 == diameter && prf.t >= thickness
                                 select prf.t;
            if (thicknessArray.Count() != 0) {
                thickness = thicknessArray.Min();
            } else {
                thickness = Math.Ceiling(thickness / 2) * 2;
            }

            _prfStr_Tube = $"O{diameter}*{thickness}";

        Skip_prfStr_Tube:;
            var prfTube = new ProfileCircular_Perfect(_prfStr_Tube);
            var maxHeight = (from prf in profiles select prf.h1).Max();
            point1 = new Point(0, 0, maxHeight * 0.5 + _extLenght_T);
            point2 = new Point(0, 0, -maxHeight * 0.5 - _extLength_B + (typeA ? 0 : _thick_BEndplate));
            var tube = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: _prfStr_Tube,
                materialStr: _materialStr,
                partPrefix: "O");
            #endregion

            #region 创建端板
            point1.X = (prfTube.d1 - prfTube.t * 2) * 0.5 - 2;
            point2 = new Point(0, point1.X, point1.Z);
            point3 = new Point(-point1.X, 0, point1.Z);
            point4 = new Point(0, -point1.X, point1.Z);
            var contour = new ArrayList {
                new ContourPoint(point1, chamferNone),
                new ContourPoint(point2, chamferArcPoint),
                new ContourPoint(point3, chamferNone),
                new ContourPoint(point4, chamferArcPoint),
            };
            var tEndPlate = ModelOperation.CreatContourPlate(contour, profileStr: "PL" + _thick_TEndplate, materialStr: _materialStr, depthEnum: Position.DepthEnum.BEHIND);

            point1.Z = typeA ? tube.EndPoint.Z : tube.EndPoint.Z - _thick_BEndplate;
            point2.Z = point1.Z;
            point3.Z = point1.Z;
            point4.Z = point1.Z;
            point1.X = typeA ? point1.X : _diam_BEndplate * 0.5;
            point2.Y = point1.X;
            point3.X = -point1.X;
            point4.Y = -point1.X;
            contour = new ArrayList {
                new ContourPoint(point1, chamferNone),
                new ContourPoint(point2, chamferArcPoint),
                new ContourPoint(point3, chamferNone),
                new ContourPoint(point4, chamferArcPoint),
            };
            var bEndPlate = ModelOperation.CreatContourPlate(contour, profileStr: "PL" + _thick_TEndplate, materialStr: _materialStr, depthEnum: Position.DepthEnum.FRONT);
            #endregion

            #region 创建加劲肋
            point1 = tube.StartPoint;
            point1.Z -= _thick_TEndplate;
            point2 = tube.EndPoint;
            point2.Z += typeA ? _thick_BEndplate : 0;
            var stif1 = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{_thick_Stiffneer}*{prfTube.d1 - prfTube.t * 2 - 4}",
                materialStr: _materialStr);
            var stif2 = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{_thick_Stiffneer}*{prfTube.d1 * 0.5 - prfTube.t - _thick_Stiffneer * 0.5 - 2}",
                materialStr: _materialStr,
                depthEnum: Position.DepthEnum.FRONT,
                depthOffset: _thick_Stiffneer * 0.5,
                rotationEnum: Position.RotationEnum.TOP);
            var stif3 = ModelOperation.CreatBeam(
                point1, point2,
                profileStr: $"PL{_thick_Stiffneer}*{prfTube.d1 * 0.5 - prfTube.t - _thick_Stiffneer * 0.5 - 2}",
                materialStr: _materialStr,
                depthEnum: Position.DepthEnum.BEHIND,
                depthOffset: _thick_Stiffneer * 0.5,
                rotationEnum: Position.RotationEnum.TOP);

            #endregion

            #region 切割、焊接
            point1 = tube.StartPoint;
            point2 = tube.EndPoint;
            point1.Z += 100;
            point2.Z -= 100;
            var booleanPart = ModelOperation.CreatBeam(point1, point2, profileStr: $"D{prfTube.d1}", @class: BooleanPart.BooleanOperativeClassName);
            foreach (var part in parts) {
                ModelOperation.ApplyBooleanOperation(part, booleanPart);
                ModelOperation.CreatWeld(part, tube);
            }
            booleanPart.Delete();

            ModelOperation.CreatWeld(
                tube, tEndPlate,
                typeAbove: BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET, sizeAbove: 6,
                typeBelow: BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET, sizeBelow: 6);
            var weld = ModelOperation.CreatWeld(
                tube, bEndPlate,
                typeAbove: BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET, sizeAbove: 6,
                typeBelow: BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET, sizeBelow: 6);
            ModelOperation.CreatWeld(tube, stif1);
            ModelOperation.CreatWeld(tube, stif2);
            ModelOperation.CreatWeld(tube, stif3);
            ModelOperation.CreatWeld(tEndPlate, stif1);
            ModelOperation.CreatWeld(tEndPlate, stif2);
            ModelOperation.CreatWeld(tEndPlate, stif3);
            ModelOperation.CreatWeld(bEndPlate, stif1);
            ModelOperation.CreatWeld(bEndPlate, stif2);
            ModelOperation.CreatWeld(bEndPlate, stif3);
            ModelOperation.CreatWeld(stif1, stif2);
            ModelOperation.CreatWeld(stif1, stif3);

            #endregion
            return true;
        }
        #endregion
    }
}
