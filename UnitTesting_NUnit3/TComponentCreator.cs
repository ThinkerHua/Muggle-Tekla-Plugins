using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace UnitTesting_NUnit3 {
    public class TComponentCreator {
        [Test]
        public void CreatDetail_Stiffeners1034() {
            var model = new Model();
            if (!model.GetConnectionStatus()) {
                Assert.Inconclusive("Model connection is not established.");
            }

            var picker = new Picker();
            if (picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "Pick a beam") is not Beam beam) {
                Assert.Inconclusive("No beam was picked.");
                return;
            }
            var point = picker.PickPoint();

            //  系统细部 Stiffeners(1034)
            //  adist4          距离列
            //  adist5          数量
            //  atab1           对齐
            //  hpl2            前面加劲板高度
            //  bpl2            前面加劲板宽度
            //  tpl2            前面加劲板厚度
            //  hpl3            后面加劲板高度
            //  bpl3            后面加劲板宽度
            //  tpl3            后面加劲板厚度
            //  partname10      零件名称
            //  mat10           材质
            //  prefix_pos10    零件前缀
            //  startno_pos10   零件起始号
            //  partname15      抛光
            //  group_no        等级
            var detail = new Detail {
                Name = "Whatever",
                Number = 310001034,
                Class = 99
            };
            detail.SetAttribute("adist4", 100.0);
            detail.SetAttribute("adist5", 3.0);
            detail.SetAttribute("atab1", 2);
            detail.SetAttribute("hpl2", 200.0);
            detail.SetAttribute("bpl2", 100.0);
            detail.SetAttribute("tpl2", 10.0);
            detail.SetAttribute("hpl3", 300.0);
            detail.SetAttribute("bpl3", 200.0);
            detail.SetAttribute("tpl3", 14.0);
            detail.SetAttribute("partname10", "STIF");
            detail.SetAttribute("mat10", "Q235B");
            detail.SetAttribute("prefix_pos10", "STIF");
            detail.SetAttribute("startno_pos10", 1);
            detail.SetAttribute("partname15", "PAINT");
            //detail.SetAttribute("group_no", 99); // 不起作用
            detail.SetPrimaryObject(beam);
            detail.SetReferencePoint(point);

            Assert.That(detail.Insert(), Is.True);
            model.CommitChanges();
        }
    }
}
