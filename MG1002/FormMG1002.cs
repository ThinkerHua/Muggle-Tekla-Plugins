using System;

namespace MuggleTeklaPlugins.MG1002 {
    public partial class FormMG1002 : Tekla.Structures.Dialog.PluginFormBase {
        public FormMG1002() {
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

        private void ImageListComboBox1_ImageListComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            switch (imageListComboBox1.SelectedIndex) {
            case 0:
                filter_cmf_Outside.Enabled = true;
                tBox_cmf_Outside.Enabled = true;
                break;
            case 1:
                filter_cmf_Outside.Enabled = false;
                tBox_cmf_Outside.Clear();
                tBox_cmf_Outside.Enabled = false;
                break;
            default:
                break;
            }
        }

        private void MaterialCatalog1_SelectClicked(object sender, EventArgs e) {
            materialCatalog1.SelectedMaterial = tBox_materialStr.Text;
        }

        private void MaterialCatalog1_SelectionDone(object sender, EventArgs e) {
            SetAttributeValue(tBox_materialStr, materialCatalog1.SelectedMaterial);
        }

        private void TBox_prfStr_DIAG_TextChanged(object sender, EventArgs e) {
            if (tBox_prfStr_DIAG.Text == string.Empty) {
                filter_pos_DIAG1.Enabled = false;
                tBox_pos_DIAG1.Clear();
                tBox_pos_DIAG1.Enabled = false;
                filter_pos_DIAG2.Enabled = false;
                tBox_pos_DIAG2.Clear();
                tBox_pos_DIAG2.Enabled = false;
            } else {
                filter_pos_DIAG1.Enabled = true;
                tBox_pos_DIAG1.Enabled = true;
                filter_pos_DIAG2.Enabled = true;
                tBox_pos_DIAG2.Enabled = true;
            }
        }
    }
}