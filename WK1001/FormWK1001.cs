using System;

namespace MuggleTeklaPlugins.WK1001 {
    public partial class FormWK1001 : Tekla.Structures.Dialog.PluginFormBase {
        public FormWK1001() {
            InitializeComponent();
        }

        private void OkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e) {
            this.Apply();
            this.Close();
        }

        private void OkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e) {
            this.Apply();
        }

        private void OkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e) {
            this.Modify();
        }

        private void OkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e) {
            this.Get();
        }

        private void OkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e) {
            this.ToggleSelection();
        }

        private void OkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e) {
            this.Close();
        }

        private void materialCatalog1_SelectClicked(object sender, EventArgs e) {
            materialCatalog1.SelectedMaterial = tbox_materialStr.Text;
        }

        private void materialCatalog1_SelectionDone(object sender, EventArgs e) {
            SetAttributeValue(tbox_materialStr, materialCatalog1.SelectedMaterial);
        }

        private void tbox_prfStr_Tube_TextChanged(object sender, EventArgs e) {
            if (tbox_prfStr_Tube.Text.Length > 0) {
                tbox_minDis.Clear();
                tbox_minDis.Enabled = false;
                filter_minDis.Enabled = false;
            } else {
                tbox_minDis.Enabled = true;
                filter_minDis.Enabled = true;
            }
        }
    }
}