using System;

namespace HJ1001 {
    public partial class FormHJ1001 : Tekla.Structures.Dialog.PluginFormBase {
        public FormHJ1001() {
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
            materialCatalog1.SelectedMaterial = tBox_material.Text;
        }

        private void materialCatalog1_SelectionDone(object sender, EventArgs e) {
            SetAttributeValue(tBox_material, materialCatalog1.SelectedMaterial);
        }

        private void IfCreatStif(object sender, EventArgs e) {
            if(cBox_creatPrimStif.SelectedIndex == 0 && cBox_creatSecStif.SelectedIndex == 0) {
                tBox_stifTHK.Text = "";
                tBox_stifTHK.Enabled = false;
                tBox_stifWidth.Text = "";
                tBox_stifWidth.Enabled = false;
                tBox_chamX.Text = "";
                tBox_chamX.Enabled = false;
                tBox_chamY.Text = "";
                tBox_chamY.Enabled = false;
                tBox_margin.Text = "";
                tBox_margin.Enabled = false;
                filter_creatPrimStif.Enabled = false;
                filter_creatSecStif.Enabled = false;
                filter_chamX.Enabled = false;
                filter_chamY.Enabled = false;
                filter_margin.Enabled = false;

                if (cBox_creatBolt.SelectedIndex == 0) {
                    tBox_quantity.Text = "";
                    tBox_quantity.Enabled = false;
                    filter_quantity.Enabled = false;
                }
            } else {
                tBox_stifTHK.Enabled = true;
                tBox_stifWidth.Enabled = true;
                tBox_chamX.Enabled = true;
                tBox_chamY.Enabled = true;
                tBox_margin.Enabled = true;
                filter_creatPrimStif.Enabled = true;
                filter_creatSecStif.Enabled = true;
                filter_chamX.Enabled = true;
                filter_chamY.Enabled = true;
                filter_margin.Enabled = true;

                tBox_quantity.Enabled = true;
                filter_quantity.Enabled = true;
            }
        }

        private void IfCreatBolt(object sender, EventArgs e) {
            if(cBox_creatBolt.SelectedIndex == 0) {
                boltCatalogStandard1.Text = "";
                boltCatalogStandard1.Enabled = false;
                boltCatalogSize1.Text = "";
                boltCatalogSize1.Enabled = false;
                tBox_boltCircleDiameter.Text = "";
                tBox_boltCircleDiameter.Enabled = false;
                filter_boltStandard.Enabled = false;
                filter_boltSize.Enabled = false;
                filter_boltCircleDiameter.Enabled = false;

                if(cBox_creatPrimStif.SelectedIndex == 0 && cBox_creatSecStif.SelectedIndex == 0) {
                    tBox_quantity.Text = "";
                    tBox_quantity.Enabled = false;
                    filter_quantity.Enabled = false;
                }
            } else {
                boltCatalogStandard1.Enabled = true;
                boltCatalogSize1.Enabled = true;
                tBox_boltCircleDiameter.Enabled = true;
                filter_boltStandard.Enabled = true;
                filter_boltSize.Enabled = true;
                filter_boltCircleDiameter.Enabled = true;

                tBox_quantity.Enabled = true;
                filter_quantity.Enabled = true;
            }
        }
    }
}