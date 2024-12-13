/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures             
 *                                                                            
 *  Copyright © 2024 Huang YongXing (thinkerhua@hotmail.com).                 
 *                                                                            
 *  This library is free software, licensed under the terms of the GNU        
 *  General Public License as published by the Free Software Foundation,      
 *  either version 3 of the License, or (at your option) any later version.   
 *  You should have received a copy of the GNU General Public License         
 *  along with this program. If not, see <http://www.gnu.org/licenses/>.      
 *==============================================================================
 *  FormWK1001.cs: user interface of "WK1001" connection
 *  written by Huang YongXing
 *==============================================================================*/
using System;

namespace Muggle.TeklaPlugins.WK1001 {
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

        private void MaterialCatalog1_SelectClicked(object sender, EventArgs e) {
            materialCatalog1.SelectedMaterial = tbox_materialStr.Text;
        }

        private void MaterialCatalog1_SelectionDone(object sender, EventArgs e) {
            SetAttributeValue(tbox_materialStr, materialCatalog1.SelectedMaterial);
        }

        private void Tbox_prfStr_Tube_TextChanged(object sender, EventArgs e) {
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