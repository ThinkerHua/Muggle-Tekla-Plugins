using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.Model;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
    public partial class ThreeDimensionalRotation : Form {
        enum ShaftEnum {
            PartCS_AxisX,
            PartCS_AxisY,
            PartCS_AxisZ,
            ManualSelect,
        }

        enum AngleEnum {
            AngleValue,
            ManualSelect,
        }
        public ThreeDimensionalRotation() {
            InitializeComponent();
        }

        private void rBtn_SelectDirection_CheckedChanged(object sender, EventArgs e) {
            var rBtn = sender as RadioButton;
            if (rBtn.Checked == true) {
                cBox_NormalOfPlane.Enabled = true;
            } else {
                cBox_NormalOfPlane.Enabled = false;
            }
        }

        private void tBox_AngleValue_Validating(object sender, CancelEventArgs e) {
            var tBox = sender as TextBox;
            if (!double.TryParse(tBox.Text, out _)) {
                errorProvider1.SetError(tBox, "只能输入数值!");
                e.Cancel = true;
            } else {
                errorProvider1.SetError(tBox, null);
            }
        }

        private void rBtn_AngleValue_CheckedChanged(object sender, EventArgs e) {
            var rBtn = sender as RadioButton;
            if (rBtn.Checked == true) {
                tBox_AngleValue.Enabled = true;
                tBox_AngleValue.Focus();
            } else {
                tBox_AngleValue.Enabled = false;
            }
        }

        private void btn_Action_Click(object sender, EventArgs e) {
            var shaftEnum =
                rBtn_PartCS_X.Checked ? ShaftEnum.PartCS_AxisX :
                rBtn_PartCS_Y.Checked ? ShaftEnum.PartCS_AxisY :
                rBtn_PartCS_Z.Checked ? ShaftEnum.PartCS_AxisZ :
                ShaftEnum.ManualSelect;
            var angleEnum =
                rBtn_AngleValue.Checked ? AngleEnum.AngleValue :
                AngleEnum.ManualSelect;
            double.TryParse(tBox_AngleValue.Text, out double angleValue);
            WindowState = FormWindowState.Minimized;
            try {
                while (true) {
                    Action(shaftEnum, angleEnum, angleValue, cBox_NormalOfPlane.Checked);
                };
            } catch {

            }
            WindowState = FormWindowState.Normal;
        }

        private static void Action(ShaftEnum shaftEnum, AngleEnum angleEnum, double degrees, bool targetDirectionIsNormalOfPlane) {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var picker = new Picker();
            var selectedObjects = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "选择要旋转的对象。");
            if (selectedObjects == null || selectedObjects.GetSize() == 0) {
                Operation.DisplayPrompt("没有选择对象。");
                return;
            }

            ModelObject modelObject;
            CoordinateSystem partCS;
            Line shaft = null;
            Matrix matrix = null;
            Point origin = null, directionPoint = null;
            switch (shaftEnum) {
            case ShaftEnum.ManualSelect:
                origin = picker.PickPoint("选择旋转轴的起点。");
                directionPoint = picker.PickPoint("选择旋转轴的方向。", origin);
                var direction = new Vector(directionPoint - origin);
                if (direction.IsZero()) {
                    Operation.DisplayPrompt("旋转轴的方向不能为零向量。");
                    return;
                }

                shaft = new Line(origin, direction);
                break;
            default:
                selectedObjects.MoveNext();
                modelObject = selectedObjects.Current;
                selectedObjects.Reset();

                partCS = modelObject.GetCoordinateSystem();
                switch (shaftEnum) {
                case ShaftEnum.PartCS_AxisX:
                    shaft = new Line(partCS.Origin, partCS.AxisX);
                    break;
                case ShaftEnum.PartCS_AxisY:
                    shaft = new Line(partCS.Origin, partCS.AxisY);
                    break;
                case ShaftEnum.PartCS_AxisZ:
                    shaft = new Line(partCS.Origin, partCS.AxisX.Cross(partCS.AxisY));
                    break;
                default:
                    break;
                }
                break;
            }

            switch (angleEnum) {
            case AngleEnum.AngleValue:
                matrix = MatrixFactoryExtension.Rotate(shaft, degrees * Math.PI / 180.0);
                break;
            case AngleEnum.ManualSelect:
                var pointStart = picker.PickPoint("选择旋转起始方向。", directionPoint);
                var directionStart = new Vector(pointStart - Projection.PointToLine(pointStart, shaft));
                if (directionStart.IsZero()) {
                    Operation.DisplayPrompt("旋转起始方向不能为零向量。");
                    return;
                }
                Vector directionEnd = null;

                if (!targetDirectionIsNormalOfPlane) {
                    var pointEnd = picker.PickPoint("选择旋转结束方向。", pointStart);
                    directionEnd = new Vector(pointEnd - Projection.PointToLine(pointEnd, shaft));
                    if (directionEnd.IsZero()) {
                        Operation.DisplayPrompt("旋转结束方向不能为零向量。");
                        return;
                    }
                } else {
                    var face = picker.PickFace("选择平面。");
                    var enumerator = face.GetEnumerator();
                    while (enumerator.MoveNext()) {
                        var inputItem = enumerator.Current as InputItem;
                        if (inputItem.GetInputType() == InputItem.InputTypeEnum.INPUT_POLYGON) {
                            var points = inputItem.GetData() as ArrayList;
                            directionEnd = new Vector((points[2] as Point) - (points[1] as Point))
                                .Cross(new Vector((points[0] as Point) - (points[1] as Point)));


                            break;
                        }
                    }
                }

                var radians = directionStart.GetAngleBetween_WithDirection(directionEnd, shaft.Direction);
                matrix = MatrixFactoryExtension.Rotate(shaft, radians);
                break;
            default:
                break;
            }

            foreach (ModelObject obj in selectedObjects) {
                ModelOperation.MoveObject(obj, matrix);
            }

            model.CommitChanges();
        }
    }
}
