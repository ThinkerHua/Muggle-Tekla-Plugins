/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2024 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  FormWK1001.Designer.cs: form designer for "WK1001" connection
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
namespace Muggle.TeklaPlugins.WK1001 {
    partial class FormWK1001 {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWK1001));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OkApplyModifyGetOnOffCancel = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ParametersTabPage = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.filter_diam_BEndplate = new System.Windows.Forms.CheckBox();
            this.filter_thick_BEndplate = new System.Windows.Forms.CheckBox();
            this.tbox_thick_BEndplate = new System.Windows.Forms.TextBox();
            this.filter_thick_Stiffneer = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.filter_prfStr_Tube = new System.Windows.Forms.CheckBox();
            this.filter_thick_TEndplate = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbox_diam_BEndplate = new System.Windows.Forms.TextBox();
            this.tbox_thick_TEndplate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.filter_group_no = new System.Windows.Forms.CheckBox();
            this.filter_materialStr = new System.Windows.Forms.CheckBox();
            this.filter_extLength_B = new System.Windows.Forms.CheckBox();
            this.filter_extLenght_T = new System.Windows.Forms.CheckBox();
            this.filter_minDis = new System.Windows.Forms.CheckBox();
            this.tbox_thick_Stiffneer = new System.Windows.Forms.TextBox();
            this.tbox_prfStr_Tube = new System.Windows.Forms.TextBox();
            this.tbox_minDis = new System.Windows.Forms.TextBox();
            this.tbox_extLenght_T = new System.Windows.Forms.TextBox();
            this.tbox_extLength_B = new System.Windows.Forms.TextBox();
            this.tbox_materialStr = new System.Windows.Forms.TextBox();
            this.materialCatalog1 = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.tbox_group_no = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveLoad = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ParametersTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel.Size = new System.Drawing.Size(834, 591);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // OkApplyModifyGetOnOffCancel
            // 
            this.structuresExtender.SetAttributeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetAttributeTypeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetBindPropertyName(this.OkApplyModifyGetOnOffCancel, null);
            this.OkApplyModifyGetOnOffCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkApplyModifyGetOnOffCancel.Location = new System.Drawing.Point(3, 561);
            this.OkApplyModifyGetOnOffCancel.Name = "OkApplyModifyGetOnOffCancel";
            this.OkApplyModifyGetOnOffCancel.Size = new System.Drawing.Size(828, 27);
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
            this.tabControl.Size = new System.Drawing.Size(828, 506);
            this.tabControl.TabIndex = 1;
            // 
            // ParametersTabPage
            // 
            this.structuresExtender.SetAttributeName(this.ParametersTabPage, null);
            this.structuresExtender.SetAttributeTypeName(this.ParametersTabPage, null);
            this.ParametersTabPage.BackgroundImage = global::Muggle.TeklaPlugins.WK1001.Properties.Resources._01;
            this.ParametersTabPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.structuresExtender.SetBindPropertyName(this.ParametersTabPage, null);
            this.ParametersTabPage.Controls.Add(this.label21);
            this.ParametersTabPage.Controls.Add(this.label18);
            this.ParametersTabPage.Controls.Add(this.tableLayoutPanel1);
            this.ParametersTabPage.Controls.Add(this.label14);
            this.ParametersTabPage.Controls.Add(this.label13);
            this.ParametersTabPage.Controls.Add(this.label12);
            this.ParametersTabPage.Controls.Add(this.label11);
            this.ParametersTabPage.Controls.Add(this.label10);
            this.ParametersTabPage.Controls.Add(this.label9);
            this.ParametersTabPage.Controls.Add(this.label8);
            this.ParametersTabPage.Controls.Add(this.label7);
            this.ParametersTabPage.Controls.Add(this.label6);
            this.ParametersTabPage.Controls.Add(this.label5);
            this.ParametersTabPage.Controls.Add(this.label4);
            this.ParametersTabPage.Controls.Add(this.label3);
            this.ParametersTabPage.Controls.Add(this.label2);
            this.ParametersTabPage.Controls.Add(this.label1);
            this.ParametersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ParametersTabPage.Name = "ParametersTabPage";
            this.ParametersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ParametersTabPage.Size = new System.Drawing.Size(820, 480);
            this.ParametersTabPage.TabIndex = 2;
            this.ParametersTabPage.Text = "albl_Parameters";
            this.ParametersTabPage.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.structuresExtender.SetAttributeName(this.label21, null);
            this.structuresExtender.SetAttributeTypeName(this.label21, null);
            this.label21.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label21, null);
            this.label21.Location = new System.Drawing.Point(485, 290);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 12);
            this.label21.TabIndex = 16;
            this.label21.Text = "h";
            // 
            // label18
            // 
            this.structuresExtender.SetAttributeName(this.label18, null);
            this.structuresExtender.SetAttributeTypeName(this.label18, null);
            this.label18.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label18, null);
            this.label18.Location = new System.Drawing.Point(602, 295);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "d";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel1, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel1, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Controls.Add(this.filter_diam_BEndplate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.filter_thick_BEndplate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbox_thick_BEndplate, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.filter_thick_Stiffneer, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.filter_prfStr_Tube, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filter_thick_TEndplate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbox_diam_BEndplate, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbox_thick_TEndplate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label22, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label23, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label24, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label25, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label26, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.filter_group_no, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.filter_materialStr, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.filter_extLength_B, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.filter_extLenght_T, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.filter_minDis, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbox_thick_Stiffneer, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbox_prfStr_Tube, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbox_minDis, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbox_extLenght_T, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbox_extLength_B, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbox_materialStr, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.materialCatalog1, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbox_group_no, 6, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 337);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 135);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // filter_diam_BEndplate
            // 
            this.filter_diam_BEndplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_diam_BEndplate, "diam_BEndplate");
            this.structuresExtender.SetAttributeTypeName(this.filter_diam_BEndplate, null);
            this.filter_diam_BEndplate.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_diam_BEndplate, "Checked");
            this.filter_diam_BEndplate.Checked = true;
            this.filter_diam_BEndplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_diam_BEndplate, true);
            this.filter_diam_BEndplate.Location = new System.Drawing.Point(93, 87);
            this.filter_diam_BEndplate.Name = "filter_diam_BEndplate";
            this.filter_diam_BEndplate.Size = new System.Drawing.Size(14, 14);
            this.filter_diam_BEndplate.TabIndex = 9;
            this.filter_diam_BEndplate.UseVisualStyleBackColor = true;
            // 
            // filter_thick_BEndplate
            // 
            this.filter_thick_BEndplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_thick_BEndplate, "thick_BEndplate");
            this.structuresExtender.SetAttributeTypeName(this.filter_thick_BEndplate, null);
            this.filter_thick_BEndplate.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_thick_BEndplate, "Checked");
            this.filter_thick_BEndplate.Checked = true;
            this.filter_thick_BEndplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_thick_BEndplate, true);
            this.filter_thick_BEndplate.Location = new System.Drawing.Point(93, 60);
            this.filter_thick_BEndplate.Name = "filter_thick_BEndplate";
            this.filter_thick_BEndplate.Size = new System.Drawing.Size(14, 14);
            this.filter_thick_BEndplate.TabIndex = 7;
            this.filter_thick_BEndplate.UseVisualStyleBackColor = true;
            // 
            // tbox_thick_BEndplate
            // 
            this.tbox_thick_BEndplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_thick_BEndplate, "thick_BEndplate");
            this.structuresExtender.SetAttributeTypeName(this.tbox_thick_BEndplate, "Double");
            this.structuresExtender.SetBindPropertyName(this.tbox_thick_BEndplate, "Text");
            this.tbox_thick_BEndplate.Location = new System.Drawing.Point(113, 57);
            this.tbox_thick_BEndplate.Name = "tbox_thick_BEndplate";
            this.tbox_thick_BEndplate.Size = new System.Drawing.Size(114, 21);
            this.tbox_thick_BEndplate.TabIndex = 8;
            // 
            // filter_thick_Stiffneer
            // 
            this.filter_thick_Stiffneer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_thick_Stiffneer, "thick_Stiffneer");
            this.structuresExtender.SetAttributeTypeName(this.filter_thick_Stiffneer, null);
            this.filter_thick_Stiffneer.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_thick_Stiffneer, "Checked");
            this.filter_thick_Stiffneer.Checked = true;
            this.filter_thick_Stiffneer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_thick_Stiffneer, true);
            this.filter_thick_Stiffneer.Location = new System.Drawing.Point(93, 114);
            this.filter_thick_Stiffneer.Name = "filter_thick_Stiffneer";
            this.filter_thick_Stiffneer.Size = new System.Drawing.Size(14, 14);
            this.filter_thick_Stiffneer.TabIndex = 11;
            this.filter_thick_Stiffneer.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label15, null);
            this.structuresExtender.SetAttributeTypeName(this.label15, null);
            this.label15.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label15, null);
            this.label15.Location = new System.Drawing.Point(10, 7);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "连接筒规格 a";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // filter_prfStr_Tube
            // 
            this.filter_prfStr_Tube.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_prfStr_Tube, "prfStr_Tube");
            this.structuresExtender.SetAttributeTypeName(this.filter_prfStr_Tube, null);
            this.filter_prfStr_Tube.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_prfStr_Tube, "Checked");
            this.filter_prfStr_Tube.Checked = true;
            this.filter_prfStr_Tube.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_prfStr_Tube, true);
            this.filter_prfStr_Tube.Location = new System.Drawing.Point(93, 6);
            this.filter_prfStr_Tube.Name = "filter_prfStr_Tube";
            this.filter_prfStr_Tube.Size = new System.Drawing.Size(14, 14);
            this.filter_prfStr_Tube.TabIndex = 3;
            this.filter_prfStr_Tube.UseVisualStyleBackColor = true;
            // 
            // filter_thick_TEndplate
            // 
            this.filter_thick_TEndplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_thick_TEndplate, "thick_TEndplate");
            this.structuresExtender.SetAttributeTypeName(this.filter_thick_TEndplate, null);
            this.filter_thick_TEndplate.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_thick_TEndplate, "Checked");
            this.filter_thick_TEndplate.Checked = true;
            this.filter_thick_TEndplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_thick_TEndplate, true);
            this.filter_thick_TEndplate.Location = new System.Drawing.Point(93, 33);
            this.filter_thick_TEndplate.Name = "filter_thick_TEndplate";
            this.filter_thick_TEndplate.Size = new System.Drawing.Size(14, 14);
            this.filter_thick_TEndplate.TabIndex = 5;
            this.filter_thick_TEndplate.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label17, null);
            this.structuresExtender.SetAttributeTypeName(this.label17, null);
            this.label17.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label17, null);
            this.label17.Location = new System.Drawing.Point(10, 34);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "上端板厚度 b";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label19, null);
            this.structuresExtender.SetAttributeTypeName(this.label19, null);
            this.label19.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label19, null);
            this.label19.Location = new System.Drawing.Point(10, 61);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "下端板厚度 c";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label20, null);
            this.structuresExtender.SetAttributeTypeName(this.label20, null);
            this.label20.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label20, null);
            this.label20.Location = new System.Drawing.Point(10, 88);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "下端板直径 d";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbox_diam_BEndplate
            // 
            this.tbox_diam_BEndplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_diam_BEndplate, "diam_BEndplate");
            this.structuresExtender.SetAttributeTypeName(this.tbox_diam_BEndplate, "Double");
            this.structuresExtender.SetBindPropertyName(this.tbox_diam_BEndplate, "Text");
            this.tbox_diam_BEndplate.Location = new System.Drawing.Point(113, 84);
            this.tbox_diam_BEndplate.Name = "tbox_diam_BEndplate";
            this.tbox_diam_BEndplate.Size = new System.Drawing.Size(114, 21);
            this.tbox_diam_BEndplate.TabIndex = 10;
            this.toolTip1.SetToolTip(this.tbox_diam_BEndplate, "不填则节点类型为TYPE A，填写此项则节点类型为TYPE B。");
            // 
            // tbox_thick_TEndplate
            // 
            this.tbox_thick_TEndplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_thick_TEndplate, "thick_TEndplate");
            this.structuresExtender.SetAttributeTypeName(this.tbox_thick_TEndplate, "Double");
            this.structuresExtender.SetBindPropertyName(this.tbox_thick_TEndplate, "Text");
            this.tbox_thick_TEndplate.Location = new System.Drawing.Point(113, 30);
            this.tbox_thick_TEndplate.Name = "tbox_thick_TEndplate";
            this.tbox_thick_TEndplate.Size = new System.Drawing.Size(114, 21);
            this.tbox_thick_TEndplate.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label16, null);
            this.structuresExtender.SetAttributeTypeName(this.label16, null);
            this.label16.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label16, null);
            this.label16.Location = new System.Drawing.Point(10, 115);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "加劲板厚度 e";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label22, null);
            this.structuresExtender.SetAttributeTypeName(this.label22, null);
            this.label22.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label22, null);
            this.label22.Location = new System.Drawing.Point(358, 34);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "上端伸出长度 g";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label23, null);
            this.structuresExtender.SetAttributeTypeName(this.label23, null);
            this.label23.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label23, null);
            this.label23.Location = new System.Drawing.Point(358, 61);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "下端伸出长度 h";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label24, null);
            this.structuresExtender.SetAttributeTypeName(this.label24, null);
            this.label24.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label24, null);
            this.label24.Location = new System.Drawing.Point(358, 88);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "节点零件材质  ";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label25, null);
            this.structuresExtender.SetAttributeTypeName(this.label25, null);
            this.label25.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label25, null);
            this.label25.Location = new System.Drawing.Point(406, 115);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 0;
            this.label25.Text = "等级  ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.structuresExtender.SetAttributeName(this.label26, null);
            this.structuresExtender.SetAttributeTypeName(this.label26, null);
            this.label26.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label26, null);
            this.label26.Location = new System.Drawing.Point(346, 7);
            this.label26.Margin = new System.Windows.Forms.Padding(3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 12);
            this.label26.TabIndex = 0;
            this.label26.Text = "杆件间最小间距 f";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // filter_group_no
            // 
            this.filter_group_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_group_no, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.filter_group_no, null);
            this.filter_group_no.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_group_no, "Checked");
            this.filter_group_no.Checked = true;
            this.filter_group_no.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_group_no, true);
            this.filter_group_no.Location = new System.Drawing.Point(453, 114);
            this.filter_group_no.Name = "filter_group_no";
            this.filter_group_no.Size = new System.Drawing.Size(14, 14);
            this.filter_group_no.TabIndex = 23;
            this.filter_group_no.UseVisualStyleBackColor = true;
            // 
            // filter_materialStr
            // 
            this.filter_materialStr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_materialStr, "materialStr");
            this.structuresExtender.SetAttributeTypeName(this.filter_materialStr, null);
            this.filter_materialStr.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_materialStr, "Checked");
            this.filter_materialStr.Checked = true;
            this.filter_materialStr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_materialStr, true);
            this.filter_materialStr.Location = new System.Drawing.Point(453, 87);
            this.filter_materialStr.Name = "filter_materialStr";
            this.filter_materialStr.Size = new System.Drawing.Size(14, 14);
            this.filter_materialStr.TabIndex = 19;
            this.filter_materialStr.UseVisualStyleBackColor = true;
            // 
            // filter_extLength_B
            // 
            this.filter_extLength_B.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_extLength_B, "extLength_B");
            this.structuresExtender.SetAttributeTypeName(this.filter_extLength_B, null);
            this.filter_extLength_B.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_extLength_B, "Checked");
            this.filter_extLength_B.Checked = true;
            this.filter_extLength_B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_extLength_B, true);
            this.filter_extLength_B.Location = new System.Drawing.Point(453, 60);
            this.filter_extLength_B.Name = "filter_extLength_B";
            this.filter_extLength_B.Size = new System.Drawing.Size(14, 14);
            this.filter_extLength_B.TabIndex = 17;
            this.filter_extLength_B.UseVisualStyleBackColor = true;
            // 
            // filter_extLenght_T
            // 
            this.filter_extLenght_T.AccessibleDescription = "";
            this.filter_extLenght_T.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_extLenght_T, "extLenght_T");
            this.structuresExtender.SetAttributeTypeName(this.filter_extLenght_T, null);
            this.filter_extLenght_T.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_extLenght_T, "Checked");
            this.filter_extLenght_T.Checked = true;
            this.filter_extLenght_T.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_extLenght_T, true);
            this.filter_extLenght_T.Location = new System.Drawing.Point(453, 33);
            this.filter_extLenght_T.Name = "filter_extLenght_T";
            this.filter_extLenght_T.Size = new System.Drawing.Size(14, 14);
            this.filter_extLenght_T.TabIndex = 15;
            this.filter_extLenght_T.UseVisualStyleBackColor = true;
            // 
            // filter_minDis
            // 
            this.filter_minDis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.filter_minDis, "minDis");
            this.structuresExtender.SetAttributeTypeName(this.filter_minDis, null);
            this.filter_minDis.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_minDis, "Checked");
            this.filter_minDis.Checked = true;
            this.filter_minDis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_minDis, true);
            this.filter_minDis.Location = new System.Drawing.Point(453, 6);
            this.filter_minDis.Name = "filter_minDis";
            this.filter_minDis.Size = new System.Drawing.Size(14, 14);
            this.filter_minDis.TabIndex = 13;
            this.filter_minDis.UseVisualStyleBackColor = true;
            // 
            // tbox_thick_Stiffneer
            // 
            this.tbox_thick_Stiffneer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_thick_Stiffneer, "thick_Stiffneer");
            this.structuresExtender.SetAttributeTypeName(this.tbox_thick_Stiffneer, "Double");
            this.structuresExtender.SetBindPropertyName(this.tbox_thick_Stiffneer, "Text");
            this.tbox_thick_Stiffneer.Location = new System.Drawing.Point(113, 111);
            this.tbox_thick_Stiffneer.Name = "tbox_thick_Stiffneer";
            this.tbox_thick_Stiffneer.Size = new System.Drawing.Size(114, 21);
            this.tbox_thick_Stiffneer.TabIndex = 12;
            // 
            // tbox_prfStr_Tube
            // 
            this.tbox_prfStr_Tube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_prfStr_Tube, "prfStr_Tube");
            this.structuresExtender.SetAttributeTypeName(this.tbox_prfStr_Tube, "String");
            this.structuresExtender.SetBindPropertyName(this.tbox_prfStr_Tube, "Text");
            this.tbox_prfStr_Tube.Location = new System.Drawing.Point(113, 3);
            this.tbox_prfStr_Tube.Name = "tbox_prfStr_Tube";
            this.tbox_prfStr_Tube.Size = new System.Drawing.Size(114, 21);
            this.tbox_prfStr_Tube.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbox_prfStr_Tube, "形式为Od*t，例如O377*18。不填表示根据参数“杆件间最小间距 f”、“上端板厚度 b”、“下端板厚度 c”自动确定一个合适的规格。");
            this.tbox_prfStr_Tube.TextChanged += new System.EventHandler(this.Tbox_prfStr_Tube_TextChanged);
            // 
            // tbox_minDis
            // 
            this.tbox_minDis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_minDis, "minDis");
            this.structuresExtender.SetAttributeTypeName(this.tbox_minDis, "Distance");
            this.structuresExtender.SetBindPropertyName(this.tbox_minDis, "Text");
            this.tbox_minDis.Location = new System.Drawing.Point(473, 3);
            this.tbox_minDis.Name = "tbox_minDis";
            this.tbox_minDis.Size = new System.Drawing.Size(114, 21);
            this.tbox_minDis.TabIndex = 14;
            // 
            // tbox_extLenght_T
            // 
            this.tbox_extLenght_T.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_extLenght_T, "extLenght_T");
            this.structuresExtender.SetAttributeTypeName(this.tbox_extLenght_T, "Distance");
            this.structuresExtender.SetBindPropertyName(this.tbox_extLenght_T, "Text");
            this.tbox_extLenght_T.Location = new System.Drawing.Point(473, 30);
            this.tbox_extLenght_T.Name = "tbox_extLenght_T";
            this.tbox_extLenght_T.Size = new System.Drawing.Size(114, 21);
            this.tbox_extLenght_T.TabIndex = 16;
            // 
            // tbox_extLength_B
            // 
            this.tbox_extLength_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_extLength_B, "extLength_B");
            this.structuresExtender.SetAttributeTypeName(this.tbox_extLength_B, "Distance");
            this.structuresExtender.SetBindPropertyName(this.tbox_extLength_B, "Text");
            this.tbox_extLength_B.Location = new System.Drawing.Point(473, 57);
            this.tbox_extLength_B.Name = "tbox_extLength_B";
            this.tbox_extLength_B.Size = new System.Drawing.Size(114, 21);
            this.tbox_extLength_B.TabIndex = 18;
            // 
            // tbox_materialStr
            // 
            this.tbox_materialStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_materialStr, "materialStr");
            this.structuresExtender.SetAttributeTypeName(this.tbox_materialStr, "String");
            this.structuresExtender.SetBindPropertyName(this.tbox_materialStr, "Text");
            this.tbox_materialStr.Location = new System.Drawing.Point(473, 84);
            this.tbox_materialStr.Name = "tbox_materialStr";
            this.tbox_materialStr.Size = new System.Drawing.Size(114, 21);
            this.tbox_materialStr.TabIndex = 20;
            // 
            // materialCatalog1
            // 
            this.materialCatalog1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.structuresExtender.SetAttributeName(this.materialCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.materialCatalog1, null);
            this.materialCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.materialCatalog1, null);
            this.materialCatalog1.ButtonText = "Select...";
            this.materialCatalog1.Location = new System.Drawing.Point(593, 84);
            this.materialCatalog1.Name = "materialCatalog1";
            this.materialCatalog1.SelectedMaterial = "";
            this.materialCatalog1.Size = new System.Drawing.Size(88, 21);
            this.materialCatalog1.TabIndex = 21;
            this.materialCatalog1.SelectClicked += new System.EventHandler(this.MaterialCatalog1_SelectClicked);
            this.materialCatalog1.SelectionDone += new System.EventHandler(this.MaterialCatalog1_SelectionDone);
            // 
            // tbox_group_no
            // 
            this.tbox_group_no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.structuresExtender.SetAttributeName(this.tbox_group_no, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.tbox_group_no, "Integer");
            this.structuresExtender.SetBindPropertyName(this.tbox_group_no, "Text");
            this.tbox_group_no.Location = new System.Drawing.Point(473, 111);
            this.tbox_group_no.Name = "tbox_group_no";
            this.tbox_group_no.Size = new System.Drawing.Size(114, 21);
            this.tbox_group_no.TabIndex = 24;
            // 
            // label14
            // 
            this.structuresExtender.SetAttributeName(this.label14, null);
            this.structuresExtender.SetAttributeTypeName(this.label14, null);
            this.label14.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label14, null);
            this.label14.Location = new System.Drawing.Point(632, 223);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "e";
            // 
            // label13
            // 
            this.structuresExtender.SetAttributeName(this.label13, null);
            this.structuresExtender.SetAttributeTypeName(this.label13, null);
            this.label13.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label13, null);
            this.label13.Location = new System.Drawing.Point(572, 255);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "c";
            // 
            // label12
            // 
            this.structuresExtender.SetAttributeName(this.label12, null);
            this.structuresExtender.SetAttributeTypeName(this.label12, null);
            this.label12.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label12, null);
            this.label12.Location = new System.Drawing.Point(700, 174);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "a";
            // 
            // label11
            // 
            this.structuresExtender.SetAttributeName(this.label11, null);
            this.structuresExtender.SetAttributeTypeName(this.label11, null);
            this.label11.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label11, null);
            this.label11.Location = new System.Drawing.Point(572, 174);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "b";
            // 
            // label10
            // 
            this.structuresExtender.SetAttributeName(this.label10, null);
            this.structuresExtender.SetAttributeTypeName(this.label10, null);
            this.label10.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label10, null);
            this.label10.Location = new System.Drawing.Point(632, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "e";
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(570, 88);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "c";
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(501, 193);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "g";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(501, 125);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "h";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(501, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "g";
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(700, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "a";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(570, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "b";
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(288, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "a";
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(226, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "e";
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(191, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "f";
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
            this.saveLoad.Size = new System.Drawing.Size(828, 40);
            this.saveLoad.TabIndex = 0;
            this.saveLoad.UserDefinedHelpFilePath = null;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 10;
            // 
            // FormWK1001
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(834, 591);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormWK1001";
            this.Text = "方管网壳杆件连接";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ParametersTabPage.ResumeLayout(false);
            this.ParametersTabPage.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel OkApplyModifyGetOnOffCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ParametersTabPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox filter_prfStr_Tube;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbox_prfStr_Tube;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox filter_thick_BEndplate;
        private System.Windows.Forms.TextBox tbox_thick_BEndplate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox filter_diam_BEndplate;
        private System.Windows.Forms.TextBox tbox_thick_TEndplate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox filter_thick_Stiffneer;
        private System.Windows.Forms.TextBox tbox_diam_BEndplate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox filter_thick_TEndplate;
        private System.Windows.Forms.TextBox tbox_thick_Stiffneer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox filter_group_no;
        private System.Windows.Forms.CheckBox filter_materialStr;
        private System.Windows.Forms.CheckBox filter_extLength_B;
        private System.Windows.Forms.CheckBox filter_extLenght_T;
        private System.Windows.Forms.CheckBox filter_minDis;
        private System.Windows.Forms.TextBox tbox_minDis;
        private System.Windows.Forms.TextBox tbox_extLenght_T;
        private System.Windows.Forms.TextBox tbox_extLength_B;
        private System.Windows.Forms.TextBox tbox_materialStr;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog materialCatalog1;
        private System.Windows.Forms.TextBox tbox_group_no;
    }
}