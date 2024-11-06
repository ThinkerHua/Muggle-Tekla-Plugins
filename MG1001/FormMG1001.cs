using System;

namespace MuggleTeklaPlugins.MG1001 {
    public partial class FormMG1001 : Tekla.Structures.Dialog.PluginFormBase {
        public FormMG1001() {
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

        private void textBox_len_Eave_TextChanged(object sender, EventArgs e) {
            if (textBox_len_Eave.Text == string.Empty) {
                filter_hgt_Eave.Enabled = false;
                textBox_hgt_Eave.Enabled = false;
                filter_thk_Eave.Enabled = false;
                textBox_thk_Eave.Enabled = false;
            } else {
                filter_hgt_Eave.Enabled = true;
                textBox_hgt_Eave.Enabled = true;
                filter_thk_Eave.Enabled = true;
                textBox_thk_Eave.Enabled = true;
            }
        }

        private void textBox_thk_THKED_TextChanged(object sender, EventArgs e) {
            if (textBox_thk_THKED.Text == string.Empty) {
                filter_pos_THKED.Enabled = false;
                textBox_pos_THKED.Enabled = false;
            } else {
                filter_pos_THKED.Enabled = true;
                textBox_pos_THKED.Enabled = true;
            }
        }

        private void textBox_prfStr_DIAG_TextChanged(object sender, EventArgs e) {
            if (textBox_prfStr_DIAG.Text == string.Empty) {
                filter_pos_DIAG1.Enabled = false;
                textBox_pos_DIAG1.Enabled = false;
                filter_pos_DIAG2.Enabled = false;
                textBox_pos_DIAG2.Enabled = false;
            } else {
                filter_pos_DIAG1.Enabled = true;
                textBox_pos_DIAG1.Enabled = true;
                filter_pos_DIAG2.Enabled = true;
                textBox_pos_DIAG2.Enabled = true;
            }
        }

        private void imageListComboBox_type_STIF_Web_ImageListComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            switch (imageListComboBox_type_STIF_Web.SelectedIndex) {
            case 0:
                filter_chamfer_STIF_out.Enabled = false;
                SetAttributeValue(textBox_chamfer_STIF_out, 0);
                textBox_chamfer_STIF_out.Enabled = false;
                break;
            case 1:
                filter_chamfer_STIF_out.Enabled = true;
                textBox_chamfer_STIF_out.Enabled = true;
                break;
            default:
                break;
            }
        }

        private void materialCatalog1_SelectClicked(object sender, EventArgs e) {
            materialCatalog1.SelectedMaterial = textBox_materialStr.Text;
        }

        private void materialCatalog1_SelectionDone(object sender, EventArgs e) {
            SetAttributeValue(textBox_materialStr, materialCatalog1.SelectedMaterial);
        }
    }
}