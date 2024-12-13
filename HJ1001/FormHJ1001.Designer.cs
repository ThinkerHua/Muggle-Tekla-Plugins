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
 *  FormHJ1001.Designer.cs: form designer for "HJ1001" connection
 *  written by Huang YongXing
 *==============================================================================*/
using System.Drawing;

namespace Muggle.TeklaPlugins.HJ1001 {
    partial class FormHJ1001 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHJ1001));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OkApplyModifyGetOnOffCancel = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ParametersTabPage = new System.Windows.Forms.TabPage();
            this.filter_group_no = new System.Windows.Forms.CheckBox();
            this.filter_material = new System.Windows.Forms.CheckBox();
            this.filter_boltCircleDiameter = new System.Windows.Forms.CheckBox();
            this.filter_boltSize = new System.Windows.Forms.CheckBox();
            this.filter_boltStandard = new System.Windows.Forms.CheckBox();
            this.filter_creatBolt = new System.Windows.Forms.CheckBox();
            this.filter_quantity = new System.Windows.Forms.CheckBox();
            this.filter_margin = new System.Windows.Forms.CheckBox();
            this.filter_chamY = new System.Windows.Forms.CheckBox();
            this.filter_chamX = new System.Windows.Forms.CheckBox();
            this.filter_stifWidth = new System.Windows.Forms.CheckBox();
            this.filter_stifTHK = new System.Windows.Forms.CheckBox();
            this.filter_creatSecStif = new System.Windows.Forms.CheckBox();
            this.filter_creatPrimStif = new System.Windows.Forms.CheckBox();
            this.filter_endPlateDIAM = new System.Windows.Forms.CheckBox();
            this.filter_endPlateTHK = new System.Windows.Forms.CheckBox();
            this.materialCatalog1 = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.cBox_creatBolt = new System.Windows.Forms.ComboBox();
            this.cBox_creatSecStif = new System.Windows.Forms.ComboBox();
            this.cBox_creatPrimStif = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tBox_quantity = new System.Windows.Forms.TextBox();
            this.tBox_boltCircleDiameter = new System.Windows.Forms.TextBox();
            this.tBox_margin = new System.Windows.Forms.TextBox();
            this.tBox_chamY = new System.Windows.Forms.TextBox();
            this.tBox_chamX = new System.Windows.Forms.TextBox();
            this.tBox_stifWidth = new System.Windows.Forms.TextBox();
            this.tBox_stifTHK = new System.Windows.Forms.TextBox();
            this.tBox_group_no = new System.Windows.Forms.TextBox();
            this.tBox_material = new System.Windows.Forms.TextBox();
            this.tBox_endPlateDIAM = new System.Windows.Forms.TextBox();
            this.tBox_endPlateTHK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boltCatalogStandard1 = new Tekla.Structures.Dialog.UIControls.BoltCatalogStandard();
            this.boltCatalogSize1 = new Tekla.Structures.Dialog.UIControls.BoltCatalogSize();
            this.saveLoad = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ParametersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel, null);
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.OkApplyModifyGetOnOffCancel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.saveLoad, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(576, 497);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // OkApplyModifyGetOnOffCancel
            // 
            this.structuresExtender.SetAttributeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetAttributeTypeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetBindPropertyName(this.OkApplyModifyGetOnOffCancel, null);
            this.OkApplyModifyGetOnOffCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkApplyModifyGetOnOffCancel.Location = new System.Drawing.Point(3, 467);
            this.OkApplyModifyGetOnOffCancel.Name = "OkApplyModifyGetOnOffCancel";
            this.OkApplyModifyGetOnOffCancel.Size = new System.Drawing.Size(570, 27);
            this.OkApplyModifyGetOnOffCancel.TabIndex = 19;
            this.OkApplyModifyGetOnOffCancel.OkClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OkClicked);
            this.OkApplyModifyGetOnOffCancel.ApplyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ApplyClicked);
            this.OkApplyModifyGetOnOffCancel.ModifyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ModifyClicked);
            this.OkApplyModifyGetOnOffCancel.GetClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_GetClicked);
            this.OkApplyModifyGetOnOffCancel.OnOffClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OnOffClicked);
            this.OkApplyModifyGetOnOffCancel.CancelClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_CancelClicked);
            // 
            // tabControl
            // 
            this.structuresExtender.SetAttributeName(this.tabControl, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl, null);
            this.tabControl.Controls.Add(this.ParametersTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(570, 412);
            this.tabControl.TabIndex = 18;
            // 
            // ParametersTabPage
            // 
            this.structuresExtender.SetAttributeName(this.ParametersTabPage, null);
            this.structuresExtender.SetAttributeTypeName(this.ParametersTabPage, null);
            var bitmap = new Bitmap(global::Muggle.TeklaPlugins.HJ1001.Properties.Resources._2);
            bitmap.MakeTransparent(Color.White);
            this.ParametersTabPage.BackgroundImage = bitmap;
            this.ParametersTabPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.structuresExtender.SetBindPropertyName(this.ParametersTabPage, null);
            this.ParametersTabPage.Controls.Add(this.filter_group_no);
            this.ParametersTabPage.Controls.Add(this.filter_material);
            this.ParametersTabPage.Controls.Add(this.filter_boltCircleDiameter);
            this.ParametersTabPage.Controls.Add(this.filter_boltSize);
            this.ParametersTabPage.Controls.Add(this.filter_boltStandard);
            this.ParametersTabPage.Controls.Add(this.filter_creatBolt);
            this.ParametersTabPage.Controls.Add(this.filter_quantity);
            this.ParametersTabPage.Controls.Add(this.filter_margin);
            this.ParametersTabPage.Controls.Add(this.filter_chamY);
            this.ParametersTabPage.Controls.Add(this.filter_chamX);
            this.ParametersTabPage.Controls.Add(this.filter_stifWidth);
            this.ParametersTabPage.Controls.Add(this.filter_stifTHK);
            this.ParametersTabPage.Controls.Add(this.filter_creatSecStif);
            this.ParametersTabPage.Controls.Add(this.filter_creatPrimStif);
            this.ParametersTabPage.Controls.Add(this.filter_endPlateDIAM);
            this.ParametersTabPage.Controls.Add(this.filter_endPlateTHK);
            this.ParametersTabPage.Controls.Add(this.materialCatalog1);
            this.ParametersTabPage.Controls.Add(this.cBox_creatBolt);
            this.ParametersTabPage.Controls.Add(this.cBox_creatSecStif);
            this.ParametersTabPage.Controls.Add(this.cBox_creatPrimStif);
            this.ParametersTabPage.Controls.Add(this.label13);
            this.ParametersTabPage.Controls.Add(this.label17);
            this.ParametersTabPage.Controls.Add(this.label12);
            this.ParametersTabPage.Controls.Add(this.label11);
            this.ParametersTabPage.Controls.Add(this.label10);
            this.ParametersTabPage.Controls.Add(this.label9);
            this.ParametersTabPage.Controls.Add(this.label16);
            this.ParametersTabPage.Controls.Add(this.label15);
            this.ParametersTabPage.Controls.Add(this.label14);
            this.ParametersTabPage.Controls.Add(this.label8);
            this.ParametersTabPage.Controls.Add(this.label7);
            this.ParametersTabPage.Controls.Add(this.label6);
            this.ParametersTabPage.Controls.Add(this.label19);
            this.ParametersTabPage.Controls.Add(this.label5);
            this.ParametersTabPage.Controls.Add(this.label18);
            this.ParametersTabPage.Controls.Add(this.label4);
            this.ParametersTabPage.Controls.Add(this.tBox_quantity);
            this.ParametersTabPage.Controls.Add(this.tBox_boltCircleDiameter);
            this.ParametersTabPage.Controls.Add(this.tBox_margin);
            this.ParametersTabPage.Controls.Add(this.tBox_chamY);
            this.ParametersTabPage.Controls.Add(this.tBox_chamX);
            this.ParametersTabPage.Controls.Add(this.tBox_stifWidth);
            this.ParametersTabPage.Controls.Add(this.tBox_stifTHK);
            this.ParametersTabPage.Controls.Add(this.tBox_group_no);
            this.ParametersTabPage.Controls.Add(this.tBox_material);
            this.ParametersTabPage.Controls.Add(this.tBox_endPlateDIAM);
            this.ParametersTabPage.Controls.Add(this.tBox_endPlateTHK);
            this.ParametersTabPage.Controls.Add(this.label3);
            this.ParametersTabPage.Controls.Add(this.label2);
            this.ParametersTabPage.Controls.Add(this.label1);
            this.ParametersTabPage.Controls.Add(this.boltCatalogStandard1);
            this.ParametersTabPage.Controls.Add(this.boltCatalogSize1);
            this.ParametersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ParametersTabPage.Name = "ParametersTabPage";
            this.ParametersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ParametersTabPage.Size = new System.Drawing.Size(562, 386);
            this.ParametersTabPage.TabIndex = 2;
            this.ParametersTabPage.Text = "albl_Parameters";
            this.ParametersTabPage.UseVisualStyleBackColor = true;
            // 
            // filter_group_no
            // 
            this.structuresExtender.SetAttributeName(this.filter_group_no, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.filter_group_no, null);
            this.filter_group_no.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_group_no, "Checked");
            this.filter_group_no.Checked = true;
            this.filter_group_no.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_group_no, true);
            this.filter_group_no.Location = new System.Drawing.Point(89, 355);
            this.filter_group_no.Name = "filter_group_no";
            this.filter_group_no.Size = new System.Drawing.Size(15, 14);
            this.filter_group_no.TabIndex = 32;
            this.filter_group_no.UseVisualStyleBackColor = true;
            // 
            // filter_material
            // 
            this.structuresExtender.SetAttributeName(this.filter_material, "material");
            this.structuresExtender.SetAttributeTypeName(this.filter_material, null);
            this.filter_material.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_material, "Checked");
            this.filter_material.Checked = true;
            this.filter_material.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_material, true);
            this.filter_material.Location = new System.Drawing.Point(89, 329);
            this.filter_material.Name = "filter_material";
            this.filter_material.Size = new System.Drawing.Size(15, 14);
            this.filter_material.TabIndex = 29;
            this.filter_material.UseVisualStyleBackColor = true;
            // 
            // filter_boltCircleDiameter
            // 
            this.structuresExtender.SetAttributeName(this.filter_boltCircleDiameter, "boltCircleDiameter");
            this.structuresExtender.SetAttributeTypeName(this.filter_boltCircleDiameter, null);
            this.filter_boltCircleDiameter.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_boltCircleDiameter, "Checked");
            this.filter_boltCircleDiameter.Checked = true;
            this.filter_boltCircleDiameter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_boltCircleDiameter, true);
            this.filter_boltCircleDiameter.Location = new System.Drawing.Point(435, 355);
            this.filter_boltCircleDiameter.Name = "filter_boltCircleDiameter";
            this.filter_boltCircleDiameter.Size = new System.Drawing.Size(15, 14);
            this.filter_boltCircleDiameter.TabIndex = 27;
            this.filter_boltCircleDiameter.UseVisualStyleBackColor = true;
            // 
            // filter_boltSize
            // 
            this.structuresExtender.SetAttributeName(this.filter_boltSize, "boltSize");
            this.structuresExtender.SetAttributeTypeName(this.filter_boltSize, null);
            this.filter_boltSize.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_boltSize, "Checked");
            this.filter_boltSize.Checked = true;
            this.filter_boltSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_boltSize, true);
            this.filter_boltSize.Location = new System.Drawing.Point(435, 329);
            this.filter_boltSize.Name = "filter_boltSize";
            this.filter_boltSize.Size = new System.Drawing.Size(15, 14);
            this.filter_boltSize.TabIndex = 25;
            this.filter_boltSize.UseVisualStyleBackColor = true;
            // 
            // filter_boltStandard
            // 
            this.structuresExtender.SetAttributeName(this.filter_boltStandard, "boltStandard");
            this.structuresExtender.SetAttributeTypeName(this.filter_boltStandard, null);
            this.filter_boltStandard.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_boltStandard, "Checked");
            this.filter_boltStandard.Checked = true;
            this.filter_boltStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_boltStandard, true);
            this.filter_boltStandard.Location = new System.Drawing.Point(435, 303);
            this.filter_boltStandard.Name = "filter_boltStandard";
            this.filter_boltStandard.Size = new System.Drawing.Size(15, 14);
            this.filter_boltStandard.TabIndex = 23;
            this.filter_boltStandard.UseVisualStyleBackColor = true;
            // 
            // filter_creatBolt
            // 
            this.structuresExtender.SetAttributeName(this.filter_creatBolt, "creatBolt");
            this.structuresExtender.SetAttributeTypeName(this.filter_creatBolt, null);
            this.filter_creatBolt.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_creatBolt, "Checked");
            this.filter_creatBolt.Checked = true;
            this.filter_creatBolt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_creatBolt, true);
            this.filter_creatBolt.Location = new System.Drawing.Point(435, 277);
            this.filter_creatBolt.Name = "filter_creatBolt";
            this.filter_creatBolt.Size = new System.Drawing.Size(15, 14);
            this.filter_creatBolt.TabIndex = 21;
            this.filter_creatBolt.UseVisualStyleBackColor = true;
            // 
            // filter_quantity
            // 
            this.structuresExtender.SetAttributeName(this.filter_quantity, "quantity");
            this.structuresExtender.SetAttributeTypeName(this.filter_quantity, null);
            this.filter_quantity.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_quantity, "Checked");
            this.filter_quantity.Checked = true;
            this.filter_quantity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_quantity, true);
            this.filter_quantity.Location = new System.Drawing.Point(435, 250);
            this.filter_quantity.Name = "filter_quantity";
            this.filter_quantity.Size = new System.Drawing.Size(15, 14);
            this.filter_quantity.TabIndex = 19;
            this.filter_quantity.UseVisualStyleBackColor = true;
            // 
            // filter_margin
            // 
            this.structuresExtender.SetAttributeName(this.filter_margin, "margin");
            this.structuresExtender.SetAttributeTypeName(this.filter_margin, null);
            this.filter_margin.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_margin, "Checked");
            this.filter_margin.Checked = true;
            this.filter_margin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_margin, true);
            this.filter_margin.Location = new System.Drawing.Point(435, 223);
            this.filter_margin.Name = "filter_margin";
            this.filter_margin.Size = new System.Drawing.Size(15, 14);
            this.filter_margin.TabIndex = 17;
            this.filter_margin.UseVisualStyleBackColor = true;
            // 
            // filter_chamY
            // 
            this.structuresExtender.SetAttributeName(this.filter_chamY, "chamY");
            this.structuresExtender.SetAttributeTypeName(this.filter_chamY, null);
            this.filter_chamY.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_chamY, "Checked");
            this.filter_chamY.Checked = true;
            this.filter_chamY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_chamY, true);
            this.filter_chamY.Location = new System.Drawing.Point(435, 196);
            this.filter_chamY.Name = "filter_chamY";
            this.filter_chamY.Size = new System.Drawing.Size(15, 14);
            this.filter_chamY.TabIndex = 15;
            this.filter_chamY.UseVisualStyleBackColor = true;
            // 
            // filter_chamX
            // 
            this.structuresExtender.SetAttributeName(this.filter_chamX, "chamX");
            this.structuresExtender.SetAttributeTypeName(this.filter_chamX, null);
            this.filter_chamX.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_chamX, "Checked");
            this.filter_chamX.Checked = true;
            this.filter_chamX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_chamX, true);
            this.filter_chamX.Location = new System.Drawing.Point(435, 169);
            this.filter_chamX.Name = "filter_chamX";
            this.filter_chamX.Size = new System.Drawing.Size(15, 14);
            this.filter_chamX.TabIndex = 13;
            this.filter_chamX.UseVisualStyleBackColor = true;
            // 
            // filter_stifWidth
            // 
            this.structuresExtender.SetAttributeName(this.filter_stifWidth, "stifWidth");
            this.structuresExtender.SetAttributeTypeName(this.filter_stifWidth, null);
            this.filter_stifWidth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_stifWidth, "Checked");
            this.filter_stifWidth.Checked = true;
            this.filter_stifWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_stifWidth, true);
            this.filter_stifWidth.Location = new System.Drawing.Point(435, 142);
            this.filter_stifWidth.Name = "filter_stifWidth";
            this.filter_stifWidth.Size = new System.Drawing.Size(15, 14);
            this.filter_stifWidth.TabIndex = 11;
            this.filter_stifWidth.UseVisualStyleBackColor = true;
            // 
            // filter_stifTHK
            // 
            this.structuresExtender.SetAttributeName(this.filter_stifTHK, "stifTHK");
            this.structuresExtender.SetAttributeTypeName(this.filter_stifTHK, null);
            this.filter_stifTHK.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_stifTHK, "Checked");
            this.filter_stifTHK.Checked = true;
            this.filter_stifTHK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_stifTHK, true);
            this.filter_stifTHK.Location = new System.Drawing.Point(435, 115);
            this.filter_stifTHK.Name = "filter_stifTHK";
            this.filter_stifTHK.Size = new System.Drawing.Size(15, 14);
            this.filter_stifTHK.TabIndex = 9;
            this.filter_stifTHK.UseVisualStyleBackColor = true;
            // 
            // filter_creatSecStif
            // 
            this.structuresExtender.SetAttributeName(this.filter_creatSecStif, "creatSecStif");
            this.structuresExtender.SetAttributeTypeName(this.filter_creatSecStif, null);
            this.filter_creatSecStif.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_creatSecStif, "Checked");
            this.filter_creatSecStif.Checked = true;
            this.filter_creatSecStif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_creatSecStif, true);
            this.filter_creatSecStif.Location = new System.Drawing.Point(435, 89);
            this.filter_creatSecStif.Name = "filter_creatSecStif";
            this.filter_creatSecStif.Size = new System.Drawing.Size(15, 14);
            this.filter_creatSecStif.TabIndex = 7;
            this.filter_creatSecStif.UseVisualStyleBackColor = true;
            // 
            // filter_creatPrimStif
            // 
            this.structuresExtender.SetAttributeName(this.filter_creatPrimStif, "creatPrimStif");
            this.structuresExtender.SetAttributeTypeName(this.filter_creatPrimStif, null);
            this.filter_creatPrimStif.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_creatPrimStif, "Checked");
            this.filter_creatPrimStif.Checked = true;
            this.filter_creatPrimStif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_creatPrimStif, true);
            this.filter_creatPrimStif.Location = new System.Drawing.Point(435, 63);
            this.filter_creatPrimStif.Name = "filter_creatPrimStif";
            this.filter_creatPrimStif.Size = new System.Drawing.Size(15, 14);
            this.filter_creatPrimStif.TabIndex = 5;
            this.filter_creatPrimStif.UseVisualStyleBackColor = true;
            // 
            // filter_endPlateDIAM
            // 
            this.structuresExtender.SetAttributeName(this.filter_endPlateDIAM, "endPlateDIAM");
            this.structuresExtender.SetAttributeTypeName(this.filter_endPlateDIAM, null);
            this.filter_endPlateDIAM.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_endPlateDIAM, "Checked");
            this.filter_endPlateDIAM.Checked = true;
            this.filter_endPlateDIAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_endPlateDIAM, true);
            this.filter_endPlateDIAM.Location = new System.Drawing.Point(435, 36);
            this.filter_endPlateDIAM.Name = "filter_endPlateDIAM";
            this.filter_endPlateDIAM.Size = new System.Drawing.Size(15, 14);
            this.filter_endPlateDIAM.TabIndex = 3;
            this.filter_endPlateDIAM.UseVisualStyleBackColor = true;
            // 
            // filter_endPlateTHK
            // 
            this.structuresExtender.SetAttributeName(this.filter_endPlateTHK, "endPlateTHK");
            this.structuresExtender.SetAttributeTypeName(this.filter_endPlateTHK, null);
            this.filter_endPlateTHK.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_endPlateTHK, "Checked");
            this.filter_endPlateTHK.Checked = true;
            this.filter_endPlateTHK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_endPlateTHK, true);
            this.filter_endPlateTHK.Location = new System.Drawing.Point(435, 9);
            this.filter_endPlateTHK.Name = "filter_endPlateTHK";
            this.filter_endPlateTHK.Size = new System.Drawing.Size(15, 14);
            this.filter_endPlateTHK.TabIndex = 1;
            this.filter_endPlateTHK.UseVisualStyleBackColor = true;
            // 
            // materialCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.materialCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.materialCatalog1, null);
            this.materialCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.materialCatalog1, null);
            this.materialCatalog1.ButtonText = "Select...";
            this.materialCatalog1.Location = new System.Drawing.Point(216, 322);
            this.materialCatalog1.Name = "materialCatalog1";
            this.materialCatalog1.SelectedMaterial = "";
            this.materialCatalog1.Size = new System.Drawing.Size(70, 25);
            this.materialCatalog1.TabIndex = 31;
            this.materialCatalog1.SelectClicked += new System.EventHandler(this.MaterialCatalog1_SelectClicked);
            this.materialCatalog1.SelectionDone += new System.EventHandler(this.MaterialCatalog1_SelectionDone);
            // 
            // cBox_creatBolt
            // 
            this.structuresExtender.SetAttributeName(this.cBox_creatBolt, "creatBolt");
            this.structuresExtender.SetAttributeTypeName(this.cBox_creatBolt, "Integer");
            this.structuresExtender.SetBindPropertyName(this.cBox_creatBolt, "SelectedIndex");
            this.cBox_creatBolt.FormattingEnabled = true;
            this.cBox_creatBolt.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cBox_creatBolt.Location = new System.Drawing.Point(456, 274);
            this.cBox_creatBolt.Name = "cBox_creatBolt";
            this.cBox_creatBolt.Size = new System.Drawing.Size(100, 20);
            this.cBox_creatBolt.TabIndex = 22;
            this.cBox_creatBolt.SelectedIndexChanged += new System.EventHandler(this.IfCreatBolt);
            // 
            // cBox_creatSecStif
            // 
            this.structuresExtender.SetAttributeName(this.cBox_creatSecStif, "creatSecStif");
            this.structuresExtender.SetAttributeTypeName(this.cBox_creatSecStif, "Integer");
            this.structuresExtender.SetBindPropertyName(this.cBox_creatSecStif, "SelectedIndex");
            this.cBox_creatSecStif.FormattingEnabled = true;
            this.cBox_creatSecStif.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cBox_creatSecStif.Location = new System.Drawing.Point(456, 86);
            this.cBox_creatSecStif.Name = "cBox_creatSecStif";
            this.cBox_creatSecStif.Size = new System.Drawing.Size(100, 20);
            this.cBox_creatSecStif.TabIndex = 8;
            this.cBox_creatSecStif.SelectedIndexChanged += new System.EventHandler(this.IfCreatStif);
            // 
            // cBox_creatPrimStif
            // 
            this.structuresExtender.SetAttributeName(this.cBox_creatPrimStif, "creatPrimStif");
            this.structuresExtender.SetAttributeTypeName(this.cBox_creatPrimStif, "Integer");
            this.structuresExtender.SetBindPropertyName(this.cBox_creatPrimStif, "SelectedIndex");
            this.cBox_creatPrimStif.FormattingEnabled = true;
            this.cBox_creatPrimStif.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cBox_creatPrimStif.Location = new System.Drawing.Point(456, 60);
            this.cBox_creatPrimStif.Name = "cBox_creatPrimStif";
            this.cBox_creatPrimStif.Size = new System.Drawing.Size(100, 20);
            this.cBox_creatPrimStif.TabIndex = 6;
            this.cBox_creatPrimStif.SelectedIndexChanged += new System.EventHandler(this.IfCreatStif);
            // 
            // label13
            // 
            this.structuresExtender.SetAttributeName(this.label13, null);
            this.structuresExtender.SetAttributeTypeName(this.label13, null);
            this.label13.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label13, null);
            this.label13.Location = new System.Drawing.Point(322, 250);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "加劲板/螺栓数量  ";
            // 
            // label17
            // 
            this.structuresExtender.SetAttributeName(this.label17, null);
            this.structuresExtender.SetAttributeTypeName(this.label17, null);
            this.label17.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label17, null);
            this.label17.Location = new System.Drawing.Point(352, 355);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 20;
            this.label17.Text = "螺栓组直径 d";
            // 
            // label12
            // 
            this.structuresExtender.SetAttributeName(this.label12, null);
            this.structuresExtender.SetAttributeTypeName(this.label12, null);
            this.label12.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label12, null);
            this.label12.Location = new System.Drawing.Point(292, 223);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "加劲板到端板边缘间隙 a";
            // 
            // label11
            // 
            this.structuresExtender.SetAttributeName(this.label11, null);
            this.structuresExtender.SetAttributeTypeName(this.label11, null);
            this.label11.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label11, null);
            this.label11.Location = new System.Drawing.Point(346, 196);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "加劲板倒角Y  ";
            // 
            // label10
            // 
            this.structuresExtender.SetAttributeName(this.label10, null);
            this.structuresExtender.SetAttributeTypeName(this.label10, null);
            this.label10.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label10, null);
            this.label10.Location = new System.Drawing.Point(346, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "加劲板倒角X  ";
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(352, 142);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "加劲板宽度  ";
            // 
            // label16
            // 
            this.structuresExtender.SetAttributeName(this.label16, null);
            this.structuresExtender.SetAttributeTypeName(this.label16, null);
            this.label16.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label16, null);
            this.label16.Location = new System.Drawing.Point(364, 329);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 17;
            this.label16.Text = "螺栓尺寸  ";
            // 
            // label15
            // 
            this.structuresExtender.SetAttributeName(this.label15, null);
            this.structuresExtender.SetAttributeTypeName(this.label15, null);
            this.label15.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label15, null);
            this.label15.Location = new System.Drawing.Point(364, 303);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 17;
            this.label15.Text = "螺栓标准  ";
            // 
            // label14
            // 
            this.structuresExtender.SetAttributeName(this.label14, null);
            this.structuresExtender.SetAttributeTypeName(this.label14, null);
            this.label14.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label14, null);
            this.label14.Location = new System.Drawing.Point(376, 277);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "螺栓组  ";
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(352, 115);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "加劲板厚度  ";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(328, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "次零件侧加劲板  ";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(328, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "主零件侧加劲板  ";
            // 
            // label19
            // 
            this.structuresExtender.SetAttributeName(this.label19, null);
            this.structuresExtender.SetAttributeTypeName(this.label19, null);
            this.label19.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label19, null);
            this.label19.Location = new System.Drawing.Point(42, 356);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "等级  ";
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(364, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "端板直径 D";
            // 
            // label18
            // 
            this.structuresExtender.SetAttributeName(this.label18, null);
            this.structuresExtender.SetAttributeTypeName(this.label18, null);
            this.label18.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label18, null);
            this.label18.Location = new System.Drawing.Point(6, 329);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "节点板材质  ";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(364, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "端板厚度  ";
            // 
            // tBox_quantity
            // 
            this.structuresExtender.SetAttributeName(this.tBox_quantity, "quantity");
            this.structuresExtender.SetAttributeTypeName(this.tBox_quantity, "Integer");
            this.structuresExtender.SetBindPropertyName(this.tBox_quantity, "Text");
            this.tBox_quantity.Location = new System.Drawing.Point(456, 247);
            this.tBox_quantity.Name = "tBox_quantity";
            this.tBox_quantity.Size = new System.Drawing.Size(100, 21);
            this.tBox_quantity.TabIndex = 20;
            // 
            // tBox_boltCircleDiameter
            // 
            this.structuresExtender.SetAttributeName(this.tBox_boltCircleDiameter, "boltCircleDiameter");
            this.structuresExtender.SetAttributeTypeName(this.tBox_boltCircleDiameter, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_boltCircleDiameter, "Text");
            this.tBox_boltCircleDiameter.Location = new System.Drawing.Point(456, 352);
            this.tBox_boltCircleDiameter.Name = "tBox_boltCircleDiameter";
            this.tBox_boltCircleDiameter.Size = new System.Drawing.Size(100, 21);
            this.tBox_boltCircleDiameter.TabIndex = 28;
            // 
            // tBox_margin
            // 
            this.structuresExtender.SetAttributeName(this.tBox_margin, "margin");
            this.structuresExtender.SetAttributeTypeName(this.tBox_margin, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_margin, "Text");
            this.tBox_margin.Location = new System.Drawing.Point(456, 220);
            this.tBox_margin.Name = "tBox_margin";
            this.tBox_margin.Size = new System.Drawing.Size(100, 21);
            this.tBox_margin.TabIndex = 18;
            // 
            // tBox_chamY
            // 
            this.structuresExtender.SetAttributeName(this.tBox_chamY, "chamY");
            this.structuresExtender.SetAttributeTypeName(this.tBox_chamY, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_chamY, "Text");
            this.tBox_chamY.Location = new System.Drawing.Point(456, 193);
            this.tBox_chamY.Name = "tBox_chamY";
            this.tBox_chamY.Size = new System.Drawing.Size(100, 21);
            this.tBox_chamY.TabIndex = 16;
            // 
            // tBox_chamX
            // 
            this.structuresExtender.SetAttributeName(this.tBox_chamX, "chamX");
            this.structuresExtender.SetAttributeTypeName(this.tBox_chamX, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_chamX, "Text");
            this.tBox_chamX.Location = new System.Drawing.Point(456, 166);
            this.tBox_chamX.Name = "tBox_chamX";
            this.tBox_chamX.Size = new System.Drawing.Size(100, 21);
            this.tBox_chamX.TabIndex = 14;
            // 
            // tBox_stifWidth
            // 
            this.structuresExtender.SetAttributeName(this.tBox_stifWidth, "stifWidth");
            this.structuresExtender.SetAttributeTypeName(this.tBox_stifWidth, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_stifWidth, "Text");
            this.tBox_stifWidth.Location = new System.Drawing.Point(456, 139);
            this.tBox_stifWidth.Name = "tBox_stifWidth";
            this.tBox_stifWidth.Size = new System.Drawing.Size(100, 21);
            this.tBox_stifWidth.TabIndex = 12;
            // 
            // tBox_stifTHK
            // 
            this.structuresExtender.SetAttributeName(this.tBox_stifTHK, "stifTHK");
            this.structuresExtender.SetAttributeTypeName(this.tBox_stifTHK, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_stifTHK, "Text");
            this.tBox_stifTHK.Location = new System.Drawing.Point(456, 112);
            this.tBox_stifTHK.Name = "tBox_stifTHK";
            this.tBox_stifTHK.Size = new System.Drawing.Size(100, 21);
            this.tBox_stifTHK.TabIndex = 10;
            // 
            // tBox_group_no
            // 
            this.structuresExtender.SetAttributeName(this.tBox_group_no, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.tBox_group_no, "Integer");
            this.structuresExtender.SetBindPropertyName(this.tBox_group_no, "Text");
            this.tBox_group_no.Location = new System.Drawing.Point(110, 353);
            this.tBox_group_no.Name = "tBox_group_no";
            this.tBox_group_no.Size = new System.Drawing.Size(100, 21);
            this.tBox_group_no.TabIndex = 33;
            // 
            // tBox_material
            // 
            this.structuresExtender.SetAttributeName(this.tBox_material, "material");
            this.structuresExtender.SetAttributeTypeName(this.tBox_material, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_material, "Text");
            this.tBox_material.Location = new System.Drawing.Point(110, 326);
            this.tBox_material.Name = "tBox_material";
            this.tBox_material.Size = new System.Drawing.Size(100, 21);
            this.tBox_material.TabIndex = 30;
            // 
            // tBox_endPlateDIAM
            // 
            this.structuresExtender.SetAttributeName(this.tBox_endPlateDIAM, "endPlateDIAM");
            this.structuresExtender.SetAttributeTypeName(this.tBox_endPlateDIAM, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_endPlateDIAM, "Text");
            this.tBox_endPlateDIAM.Location = new System.Drawing.Point(456, 33);
            this.tBox_endPlateDIAM.Name = "tBox_endPlateDIAM";
            this.tBox_endPlateDIAM.Size = new System.Drawing.Size(100, 21);
            this.tBox_endPlateDIAM.TabIndex = 4;
            // 
            // tBox_endPlateTHK
            // 
            this.structuresExtender.SetAttributeName(this.tBox_endPlateTHK, "endPlateTHK");
            this.structuresExtender.SetAttributeTypeName(this.tBox_endPlateTHK, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_endPlateTHK, "Text");
            this.tBox_endPlateTHK.Location = new System.Drawing.Point(456, 6);
            this.tBox_endPlateTHK.Name = "tBox_endPlateTHK";
            this.tBox_endPlateTHK.Size = new System.Drawing.Size(100, 21);
            this.tBox_endPlateTHK.TabIndex = 2;
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(187, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "a";
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(120, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "D";
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(120, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "d";
            // 
            // boltCatalogStandard1
            // 
            this.structuresExtender.SetAttributeName(this.boltCatalogStandard1, "boltStandard");
            this.structuresExtender.SetAttributeTypeName(this.boltCatalogStandard1, "String");
            this.structuresExtender.SetBindPropertyName(this.boltCatalogStandard1, "Text");
            this.boltCatalogStandard1.FormattingEnabled = true;
            this.boltCatalogStandard1.LinkedBoltCatalogSize = this.boltCatalogSize1;
            this.boltCatalogStandard1.Location = new System.Drawing.Point(456, 300);
            this.boltCatalogStandard1.Name = "boltCatalogStandard1";
            this.boltCatalogStandard1.Size = new System.Drawing.Size(100, 20);
            this.boltCatalogStandard1.TabIndex = 24;
            // 
            // boltCatalogSize1
            // 
            this.structuresExtender.SetAttributeName(this.boltCatalogSize1, "boltSize");
            this.structuresExtender.SetAttributeTypeName(this.boltCatalogSize1, "Double");
            this.structuresExtender.SetBindPropertyName(this.boltCatalogSize1, "Text");
            this.boltCatalogSize1.FormattingEnabled = true;
            this.boltCatalogSize1.Location = new System.Drawing.Point(456, 326);
            this.boltCatalogSize1.Name = "boltCatalogSize1";
            this.boltCatalogSize1.Size = new System.Drawing.Size(100, 20);
            this.boltCatalogSize1.TabIndex = 26;
            // 
            // saveLoad
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad, null);
            this.saveLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad, null);
            this.saveLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.saveLoad.HelpKeyword = "";
            this.saveLoad.HelpUrl = "";
            this.saveLoad.Location = new System.Drawing.Point(3, 3);
            this.saveLoad.Name = "saveLoad";
            this.saveLoad.SaveAsText = "";
            this.saveLoad.Size = new System.Drawing.Size(570, 40);
            this.saveLoad.TabIndex = 0;
            this.saveLoad.UserDefinedHelpFilePath = null;
            // 
            // FormHJ1001
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(576, 497);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHJ1001";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "圆管对接";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ParametersTabPage.ResumeLayout(false);
            this.ParametersTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel OkApplyModifyGetOnOffCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ParametersTabPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogStandard boltCatalogStandard1;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogSize boltCatalogSize1;
        private System.Windows.Forms.TextBox tBox_endPlateTHK;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog materialCatalog1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBox_quantity;
        private System.Windows.Forms.TextBox tBox_boltCircleDiameter;
        private System.Windows.Forms.TextBox tBox_margin;
        private System.Windows.Forms.TextBox tBox_chamY;
        private System.Windows.Forms.TextBox tBox_chamX;
        private System.Windows.Forms.TextBox tBox_stifWidth;
        private System.Windows.Forms.TextBox tBox_stifTHK;
        private System.Windows.Forms.TextBox tBox_group_no;
        private System.Windows.Forms.TextBox tBox_material;
        private System.Windows.Forms.TextBox tBox_endPlateDIAM;
        private System.Windows.Forms.CheckBox filter_group_no;
        private System.Windows.Forms.CheckBox filter_material;
        private System.Windows.Forms.CheckBox filter_boltCircleDiameter;
        private System.Windows.Forms.CheckBox filter_boltSize;
        private System.Windows.Forms.CheckBox filter_boltStandard;
        private System.Windows.Forms.CheckBox filter_creatBolt;
        private System.Windows.Forms.CheckBox filter_quantity;
        private System.Windows.Forms.CheckBox filter_margin;
        private System.Windows.Forms.CheckBox filter_chamY;
        private System.Windows.Forms.CheckBox filter_chamX;
        private System.Windows.Forms.CheckBox filter_stifWidth;
        private System.Windows.Forms.CheckBox filter_stifTHK;
        private System.Windows.Forms.CheckBox filter_creatSecStif;
        private System.Windows.Forms.CheckBox filter_creatPrimStif;
        private System.Windows.Forms.CheckBox filter_endPlateDIAM;
        private System.Windows.Forms.CheckBox filter_endPlateTHK;
        private System.Windows.Forms.ComboBox cBox_creatBolt;
        private System.Windows.Forms.ComboBox cBox_creatSecStif;
        private System.Windows.Forms.ComboBox cBox_creatPrimStif;
    }
}