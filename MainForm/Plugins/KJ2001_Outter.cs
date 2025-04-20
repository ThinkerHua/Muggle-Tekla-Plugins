using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Plugins {
    public static class KJ2001_Outter {
        public static void Run() {
            try {
                var model = new Model();
                if (!model.GetConnectionStatus()) return;

                Picker picker;
                Point position;
                ModelObject mainPart;
                Detail kj2001;
                ArrayList modelObjects;
                while (true) {
                    Tekla.Structures.Model.UI.ModelObjectSelector uiSelecter;
                    picker = new Picker();
                    mainPart = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick main part");
                    position = picker.PickPoint("Pick a position");

                    kj2001 = new Detail {
                        Name = "KJ2001",
                        Number = BaseComponent.PLUGIN_OBJECT_NUMBER,
                        PositionType = Tekla.Structures.PositionTypeEnum.END_END_PLANE,
                        AutoDirectionType = Tekla.Structures.AutoDirectionTypeEnum.AUTODIR_DETAIL,
                        Class = -1,
                    };
                    kj2001.SetPrimaryObject(mainPart);
                    kj2001.SetReferencePoint(position);

                    if (!kj2001.Insert())
                        throw new Exception("Detail \"KJ2001\" failed to insert.");

                    modelObjects = new ArrayList { kj2001 };
                    uiSelecter = new Tekla.Structures.Model.UI.ModelObjectSelector();
                    uiSelecter.Select(modelObjects);
                    model.CommitChanges();
                }
            } catch (Exception e) {
                if (e.Message != "User interrupt")
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {

            }
        }
    }
}
