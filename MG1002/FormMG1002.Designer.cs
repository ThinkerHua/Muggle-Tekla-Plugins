
using System.Drawing;

namespace MuggleTeklaPlugins.MG1002 {
    partial class FormMG1002 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMG1002));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OkApplyModifyGetOnOffCancel = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tBox_pos_DIAG2 = new System.Windows.Forms.TextBox();
            this.tBox_pos_DIAG1 = new System.Windows.Forms.TextBox();
            this.tBox_prfStr_DIAG = new System.Windows.Forms.TextBox();
            this.tBox_prfStr_VERT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.filter_pos_DIAG2 = new System.Windows.Forms.CheckBox();
            this.filter_pos_DIAG1 = new System.Windows.Forms.CheckBox();
            this.filter_prfStr_DIAG = new System.Windows.Forms.CheckBox();
            this.filter_prfStr_VERT = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCatalog1 = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.tBox_materialStr = new System.Windows.Forms.TextBox();
            this.filter_materialStr = new System.Windows.Forms.CheckBox();
            this.tBox_prfStr_EndPlate = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.filter_prfStr_EndPlate = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.boltCatalogStandard1 = new Tekla.Structures.Dialog.UIControls.BoltCatalogStandard();
            this.boltCatalogSize1 = new Tekla.Structures.Dialog.UIControls.BoltCatalogSize();
            this.tBox_group_no = new System.Windows.Forms.TextBox();
            this.filter_goup_no = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tBox_disListStr_bolt_Y = new System.Windows.Forms.TextBox();
            this.tBox_disListStr_bolt_X = new System.Windows.Forms.TextBox();
            this.tBox_disListStr_STIF_WEB = new System.Windows.Forms.TextBox();
            this.filter_disListStr_bolt_Y = new System.Windows.Forms.CheckBox();
            this.filter_disListStr_bolt_X = new System.Windows.Forms.CheckBox();
            this.filter_bolt_Size = new System.Windows.Forms.CheckBox();
            this.filter_bolt_Standard = new System.Windows.Forms.CheckBox();
            this.filter_disListStr_STIF_WEB = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.imageListComboBox1 = new Tekla.Structures.Dialog.UIControls.ImageListComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tBox_cmf_Outside = new System.Windows.Forms.TextBox();
            this.tBox_cmf_Inside = new System.Windows.Forms.TextBox();
            this.tBox_prfStr_STIF_WEB = new System.Windows.Forms.TextBox();
            this.filter_cmf_Outside = new System.Windows.Forms.CheckBox();
            this.tBox_prfStr_STIF_FLNG = new System.Windows.Forms.TextBox();
            this.filter_cmf_Inside = new System.Windows.Forms.CheckBox();
            this.filter_prfStr_STIF_WEB = new System.Windows.Forms.CheckBox();
            this.filter_prfStr_STIF_FLNG = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.saveLoad = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tableLayoutPanel.Size = new System.Drawing.Size(611, 438);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // OkApplyModifyGetOnOffCancel
            // 
            this.structuresExtender.SetAttributeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetAttributeTypeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetBindPropertyName(this.OkApplyModifyGetOnOffCancel, null);
            this.OkApplyModifyGetOnOffCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkApplyModifyGetOnOffCancel.Location = new System.Drawing.Point(3, 408);
            this.OkApplyModifyGetOnOffCancel.Name = "OkApplyModifyGetOnOffCancel";
            this.OkApplyModifyGetOnOffCancel.Size = new System.Drawing.Size(605, 27);
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
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(605, 353);
            this.tabControl.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.structuresExtender.SetAttributeName(this.tabPage1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage1, null);
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.structuresExtender.SetBindPropertyName(this.tabPage1, null);
            this.tabPage1.Controls.Add(this.tBox_pos_DIAG2);
            this.tabPage1.Controls.Add(this.tBox_pos_DIAG1);
            this.tabPage1.Controls.Add(this.tBox_prfStr_DIAG);
            this.tabPage1.Controls.Add(this.tBox_prfStr_VERT);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.filter_pos_DIAG2);
            this.tabPage1.Controls.Add(this.filter_pos_DIAG1);
            this.tabPage1.Controls.Add(this.filter_prfStr_DIAG);
            this.tabPage1.Controls.Add(this.filter_prfStr_VERT);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 327);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "参数 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tBox_pos_DIAG2
            // 
            this.structuresExtender.SetAttributeName(this.tBox_pos_DIAG2, "pos_DIAG2");
            this.structuresExtender.SetAttributeTypeName(this.tBox_pos_DIAG2, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_pos_DIAG2, "Text");
            this.tBox_pos_DIAG2.Enabled = false;
            this.tBox_pos_DIAG2.Location = new System.Drawing.Point(491, 105);
            this.tBox_pos_DIAG2.Name = "tBox_pos_DIAG2";
            this.tBox_pos_DIAG2.Size = new System.Drawing.Size(100, 21);
            this.tBox_pos_DIAG2.TabIndex = 8;
            // 
            // tBox_pos_DIAG1
            // 
            this.structuresExtender.SetAttributeName(this.tBox_pos_DIAG1, "pos_DIAG1");
            this.structuresExtender.SetAttributeTypeName(this.tBox_pos_DIAG1, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_pos_DIAG1, "Text");
            this.tBox_pos_DIAG1.Enabled = false;
            this.tBox_pos_DIAG1.Location = new System.Drawing.Point(491, 78);
            this.tBox_pos_DIAG1.Name = "tBox_pos_DIAG1";
            this.tBox_pos_DIAG1.Size = new System.Drawing.Size(100, 21);
            this.tBox_pos_DIAG1.TabIndex = 6;
            // 
            // tBox_prfStr_DIAG
            // 
            this.structuresExtender.SetAttributeName(this.tBox_prfStr_DIAG, "prfStr_DIAG");
            this.structuresExtender.SetAttributeTypeName(this.tBox_prfStr_DIAG, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_prfStr_DIAG, "Text");
            this.tBox_prfStr_DIAG.Location = new System.Drawing.Point(491, 51);
            this.tBox_prfStr_DIAG.Name = "tBox_prfStr_DIAG";
            this.tBox_prfStr_DIAG.Size = new System.Drawing.Size(100, 21);
            this.tBox_prfStr_DIAG.TabIndex = 4;
            this.tBox_prfStr_DIAG.TextChanged += new System.EventHandler(this.TBox_prfStr_DIAG_TextChanged);
            // 
            // tBox_prfStr_VERT
            // 
            this.structuresExtender.SetAttributeName(this.tBox_prfStr_VERT, "prfStr_VERT");
            this.structuresExtender.SetAttributeTypeName(this.tBox_prfStr_VERT, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_prfStr_VERT, "Text");
            this.tBox_prfStr_VERT.Location = new System.Drawing.Point(491, 24);
            this.tBox_prfStr_VERT.Name = "tBox_prfStr_VERT";
            this.tBox_prfStr_VERT.Size = new System.Drawing.Size(100, 21);
            this.tBox_prfStr_VERT.TabIndex = 2;
            // 
            // label10
            // 
            this.structuresExtender.SetAttributeName(this.label10, null);
            this.structuresExtender.SetAttributeTypeName(this.label10, null);
            this.label10.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label10, null);
            this.label10.Location = new System.Drawing.Point(489, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "PL t [* b]";
            // 
            // filter_pos_DIAG2
            // 
            this.structuresExtender.SetAttributeName(this.filter_pos_DIAG2, "pos_DIAG2");
            this.structuresExtender.SetAttributeTypeName(this.filter_pos_DIAG2, null);
            this.filter_pos_DIAG2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_pos_DIAG2, "Checked");
            this.filter_pos_DIAG2.Checked = true;
            this.filter_pos_DIAG2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filter_pos_DIAG2.Enabled = false;
            this.structuresExtender.SetIsFilter(this.filter_pos_DIAG2, true);
            this.filter_pos_DIAG2.Location = new System.Drawing.Point(470, 108);
            this.filter_pos_DIAG2.Name = "filter_pos_DIAG2";
            this.filter_pos_DIAG2.Size = new System.Drawing.Size(15, 14);
            this.filter_pos_DIAG2.TabIndex = 7;
            this.filter_pos_DIAG2.UseVisualStyleBackColor = true;
            // 
            // filter_pos_DIAG1
            // 
            this.structuresExtender.SetAttributeName(this.filter_pos_DIAG1, "pos_DIAG1");
            this.structuresExtender.SetAttributeTypeName(this.filter_pos_DIAG1, null);
            this.filter_pos_DIAG1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_pos_DIAG1, "Checked");
            this.filter_pos_DIAG1.Checked = true;
            this.filter_pos_DIAG1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filter_pos_DIAG1.Enabled = false;
            this.structuresExtender.SetIsFilter(this.filter_pos_DIAG1, true);
            this.filter_pos_DIAG1.Location = new System.Drawing.Point(470, 80);
            this.filter_pos_DIAG1.Name = "filter_pos_DIAG1";
            this.filter_pos_DIAG1.Size = new System.Drawing.Size(15, 14);
            this.filter_pos_DIAG1.TabIndex = 5;
            this.filter_pos_DIAG1.UseVisualStyleBackColor = true;
            // 
            // filter_prfStr_DIAG
            // 
            this.structuresExtender.SetAttributeName(this.filter_prfStr_DIAG, "prfStr_DIAG");
            this.structuresExtender.SetAttributeTypeName(this.filter_prfStr_DIAG, null);
            this.filter_prfStr_DIAG.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_prfStr_DIAG, "Checked");
            this.filter_prfStr_DIAG.Checked = true;
            this.filter_prfStr_DIAG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_prfStr_DIAG, true);
            this.filter_prfStr_DIAG.Location = new System.Drawing.Point(470, 54);
            this.filter_prfStr_DIAG.Name = "filter_prfStr_DIAG";
            this.filter_prfStr_DIAG.Size = new System.Drawing.Size(15, 14);
            this.filter_prfStr_DIAG.TabIndex = 3;
            this.filter_prfStr_DIAG.UseVisualStyleBackColor = true;
            // 
            // filter_prfStr_VERT
            // 
            this.structuresExtender.SetAttributeName(this.filter_prfStr_VERT, "prfStr_VERT");
            this.structuresExtender.SetAttributeTypeName(this.filter_prfStr_VERT, null);
            this.filter_prfStr_VERT.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_prfStr_VERT, "Checked");
            this.filter_prfStr_VERT.Checked = true;
            this.filter_prfStr_VERT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_prfStr_VERT, true);
            this.filter_prfStr_VERT.Location = new System.Drawing.Point(470, 27);
            this.filter_prfStr_VERT.Name = "filter_prfStr_VERT";
            this.filter_prfStr_VERT.Size = new System.Drawing.Size(15, 14);
            this.filter_prfStr_VERT.TabIndex = 1;
            this.filter_prfStr_VERT.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(387, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "对角板定位 d";
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(387, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "对角板定位 c";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(387, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "对角板规格 b";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(399, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "竖板规格 a";
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(238, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "d";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(132, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "c";
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(194, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "b";
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(292, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "a";
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(162, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "a";
            // 
            // tabPage2
            // 
            this.structuresExtender.SetAttributeName(this.tabPage2, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage2, null);
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.structuresExtender.SetBindPropertyName(this.tabPage2, null);
            this.tabPage2.Controls.Add(this.materialCatalog1);
            this.tabPage2.Controls.Add(this.tBox_materialStr);
            this.tabPage2.Controls.Add(this.filter_materialStr);
            this.tabPage2.Controls.Add(this.tBox_prfStr_EndPlate);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.filter_prfStr_EndPlate);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.boltCatalogStandard1);
            this.tabPage2.Controls.Add(this.boltCatalogSize1);
            this.tabPage2.Controls.Add(this.tBox_group_no);
            this.tabPage2.Controls.Add(this.filter_goup_no);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.tBox_disListStr_bolt_Y);
            this.tabPage2.Controls.Add(this.tBox_disListStr_bolt_X);
            this.tabPage2.Controls.Add(this.tBox_disListStr_STIF_WEB);
            this.tabPage2.Controls.Add(this.filter_disListStr_bolt_Y);
            this.tabPage2.Controls.Add(this.filter_disListStr_bolt_X);
            this.tabPage2.Controls.Add(this.filter_bolt_Size);
            this.tabPage2.Controls.Add(this.filter_bolt_Standard);
            this.tabPage2.Controls.Add(this.filter_disListStr_STIF_WEB);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.imageListComboBox1);
            this.tabPage2.Controls.Add(this.tBox_cmf_Outside);
            this.tabPage2.Controls.Add(this.tBox_cmf_Inside);
            this.tabPage2.Controls.Add(this.tBox_prfStr_STIF_WEB);
            this.tabPage2.Controls.Add(this.filter_cmf_Outside);
            this.tabPage2.Controls.Add(this.tBox_prfStr_STIF_FLNG);
            this.tabPage2.Controls.Add(this.filter_cmf_Inside);
            this.tabPage2.Controls.Add(this.filter_prfStr_STIF_WEB);
            this.tabPage2.Controls.Add(this.filter_prfStr_STIF_FLNG);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 327);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "参数 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.materialCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.materialCatalog1, null);
            this.materialCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.materialCatalog1, null);
            this.materialCatalog1.ButtonText = "albl_Select__";
            this.materialCatalog1.Location = new System.Drawing.Point(483, 265);
            this.materialCatalog1.Name = "materialCatalog1";
            this.materialCatalog1.SelectedMaterial = "";
            this.materialCatalog1.Size = new System.Drawing.Size(70, 20);
            this.materialCatalog1.TabIndex = 25;
            this.materialCatalog1.SelectClicked += new System.EventHandler(this.MaterialCatalog1_SelectClicked);
            this.materialCatalog1.SelectionDone += new System.EventHandler(this.MaterialCatalog1_SelectionDone);
            // 
            // tBox_materialStr
            // 
            this.structuresExtender.SetAttributeName(this.tBox_materialStr, "materialStr");
            this.structuresExtender.SetAttributeTypeName(this.tBox_materialStr, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_materialStr, "Text");
            this.tBox_materialStr.Location = new System.Drawing.Point(377, 264);
            this.tBox_materialStr.Name = "tBox_materialStr";
            this.tBox_materialStr.Size = new System.Drawing.Size(100, 21);
            this.tBox_materialStr.TabIndex = 22;
            // 
            // filter_materialStr
            // 
            this.structuresExtender.SetAttributeName(this.filter_materialStr, "materialStr");
            this.structuresExtender.SetAttributeTypeName(this.filter_materialStr, null);
            this.filter_materialStr.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_materialStr, "Checked");
            this.filter_materialStr.Checked = true;
            this.filter_materialStr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_materialStr, true);
            this.filter_materialStr.Location = new System.Drawing.Point(356, 267);
            this.filter_materialStr.Name = "filter_materialStr";
            this.filter_materialStr.Size = new System.Drawing.Size(15, 14);
            this.filter_materialStr.TabIndex = 21;
            this.filter_materialStr.UseVisualStyleBackColor = true;
            // 
            // tBox_prfStr_EndPlate
            // 
            this.structuresExtender.SetAttributeName(this.tBox_prfStr_EndPlate, "prfStr_EndPlate");
            this.structuresExtender.SetAttributeTypeName(this.tBox_prfStr_EndPlate, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_prfStr_EndPlate, "Text");
            this.tBox_prfStr_EndPlate.Location = new System.Drawing.Point(377, 24);
            this.tBox_prfStr_EndPlate.Name = "tBox_prfStr_EndPlate";
            this.tBox_prfStr_EndPlate.Size = new System.Drawing.Size(100, 21);
            this.tBox_prfStr_EndPlate.TabIndex = 2;
            // 
            // label26
            // 
            this.structuresExtender.SetAttributeName(this.label26, null);
            this.structuresExtender.SetAttributeTypeName(this.label26, null);
            this.label26.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label26, null);
            this.label26.Location = new System.Drawing.Point(261, 269);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 12);
            this.label26.TabIndex = 0;
            this.label26.Text = "节点零件材质  ";
            // 
            // filter_prfStr_EndPlate
            // 
            this.structuresExtender.SetAttributeName(this.filter_prfStr_EndPlate, "prfStr_EndPlate");
            this.structuresExtender.SetAttributeTypeName(this.filter_prfStr_EndPlate, null);
            this.filter_prfStr_EndPlate.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_prfStr_EndPlate, "Checked");
            this.filter_prfStr_EndPlate.Checked = true;
            this.filter_prfStr_EndPlate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_prfStr_EndPlate, true);
            this.filter_prfStr_EndPlate.Location = new System.Drawing.Point(356, 27);
            this.filter_prfStr_EndPlate.Name = "filter_prfStr_EndPlate";
            this.filter_prfStr_EndPlate.Size = new System.Drawing.Size(15, 14);
            this.filter_prfStr_EndPlate.TabIndex = 1;
            this.filter_prfStr_EndPlate.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.structuresExtender.SetAttributeName(this.label25, null);
            this.structuresExtender.SetAttributeTypeName(this.label25, null);
            this.label25.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label25, null);
            this.label25.Location = new System.Drawing.Point(285, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 12);
            this.label25.TabIndex = 0;
            this.label25.Text = "端板规格  ";
            // 
            // boltCatalogStandard1
            // 
            this.structuresExtender.SetAttributeName(this.boltCatalogStandard1, "bolt_Standard");
            this.structuresExtender.SetAttributeTypeName(this.boltCatalogStandard1, "String");
            this.structuresExtender.SetBindPropertyName(this.boltCatalogStandard1, "Text");
            this.boltCatalogStandard1.FormattingEnabled = true;
            this.boltCatalogStandard1.LinkedBoltCatalogSize = this.boltCatalogSize1;
            this.boltCatalogStandard1.Location = new System.Drawing.Point(377, 132);
            this.boltCatalogStandard1.Name = "boltCatalogStandard1";
            this.boltCatalogStandard1.Size = new System.Drawing.Size(100, 20);
            this.boltCatalogStandard1.TabIndex = 14;
            // 
            // boltCatalogSize1
            // 
            this.structuresExtender.SetAttributeName(this.boltCatalogSize1, "bolt_Size");
            this.structuresExtender.SetAttributeTypeName(this.boltCatalogSize1, "Distance");
            this.structuresExtender.SetBindPropertyName(this.boltCatalogSize1, "Text");
            this.boltCatalogSize1.FormattingEnabled = true;
            this.boltCatalogSize1.Location = new System.Drawing.Point(377, 158);
            this.boltCatalogSize1.Name = "boltCatalogSize1";
            this.boltCatalogSize1.Size = new System.Drawing.Size(100, 20);
            this.boltCatalogSize1.TabIndex = 16;
            // 
            // tBox_group_no
            // 
            this.structuresExtender.SetAttributeName(this.tBox_group_no, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.tBox_group_no, "Integer");
            this.structuresExtender.SetBindPropertyName(this.tBox_group_no, "Text");
            this.tBox_group_no.Location = new System.Drawing.Point(377, 291);
            this.tBox_group_no.Name = "tBox_group_no";
            this.tBox_group_no.Size = new System.Drawing.Size(100, 21);
            this.tBox_group_no.TabIndex = 24;
            // 
            // filter_goup_no
            // 
            this.structuresExtender.SetAttributeName(this.filter_goup_no, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.filter_goup_no, null);
            this.filter_goup_no.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_goup_no, "Checked");
            this.filter_goup_no.Checked = true;
            this.filter_goup_no.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_goup_no, true);
            this.filter_goup_no.Location = new System.Drawing.Point(356, 294);
            this.filter_goup_no.Name = "filter_goup_no";
            this.filter_goup_no.Size = new System.Drawing.Size(15, 14);
            this.filter_goup_no.TabIndex = 23;
            this.filter_goup_no.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.structuresExtender.SetAttributeName(this.label24, null);
            this.structuresExtender.SetAttributeTypeName(this.label24, null);
            this.label24.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label24, null);
            this.label24.Location = new System.Drawing.Point(309, 296);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "等级  ";
            // 
            // tBox_disListStr_bolt_Y
            // 
            this.structuresExtender.SetAttributeName(this.tBox_disListStr_bolt_Y, "disListStr_bolt_Y");
            this.structuresExtender.SetAttributeTypeName(this.tBox_disListStr_bolt_Y, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_disListStr_bolt_Y, "Text");
            this.tBox_disListStr_bolt_Y.Location = new System.Drawing.Point(377, 213);
            this.tBox_disListStr_bolt_Y.Name = "tBox_disListStr_bolt_Y";
            this.tBox_disListStr_bolt_Y.Size = new System.Drawing.Size(214, 21);
            this.tBox_disListStr_bolt_Y.TabIndex = 20;
            // 
            // tBox_disListStr_bolt_X
            // 
            this.structuresExtender.SetAttributeName(this.tBox_disListStr_bolt_X, "disListStr_bolt_X");
            this.structuresExtender.SetAttributeTypeName(this.tBox_disListStr_bolt_X, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_disListStr_bolt_X, "Text");
            this.tBox_disListStr_bolt_X.Location = new System.Drawing.Point(377, 186);
            this.tBox_disListStr_bolt_X.Name = "tBox_disListStr_bolt_X";
            this.tBox_disListStr_bolt_X.Size = new System.Drawing.Size(214, 21);
            this.tBox_disListStr_bolt_X.TabIndex = 18;
            // 
            // tBox_disListStr_STIF_WEB
            // 
            this.structuresExtender.SetAttributeName(this.tBox_disListStr_STIF_WEB, "disListStr_STIF_WEB");
            this.structuresExtender.SetAttributeTypeName(this.tBox_disListStr_STIF_WEB, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_disListStr_STIF_WEB, "Text");
            this.tBox_disListStr_STIF_WEB.Location = new System.Drawing.Point(377, 105);
            this.tBox_disListStr_STIF_WEB.Name = "tBox_disListStr_STIF_WEB";
            this.tBox_disListStr_STIF_WEB.Size = new System.Drawing.Size(214, 21);
            this.tBox_disListStr_STIF_WEB.TabIndex = 12;
            // 
            // filter_disListStr_bolt_Y
            // 
            this.structuresExtender.SetAttributeName(this.filter_disListStr_bolt_Y, "disListStr_bolt_Y");
            this.structuresExtender.SetAttributeTypeName(this.filter_disListStr_bolt_Y, null);
            this.filter_disListStr_bolt_Y.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_disListStr_bolt_Y, "Checked");
            this.filter_disListStr_bolt_Y.Checked = true;
            this.filter_disListStr_bolt_Y.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_disListStr_bolt_Y, true);
            this.filter_disListStr_bolt_Y.Location = new System.Drawing.Point(356, 216);
            this.filter_disListStr_bolt_Y.Name = "filter_disListStr_bolt_Y";
            this.filter_disListStr_bolt_Y.Size = new System.Drawing.Size(15, 14);
            this.filter_disListStr_bolt_Y.TabIndex = 19;
            this.filter_disListStr_bolt_Y.UseVisualStyleBackColor = true;
            // 
            // filter_disListStr_bolt_X
            // 
            this.structuresExtender.SetAttributeName(this.filter_disListStr_bolt_X, "disListStr_bolt_X");
            this.structuresExtender.SetAttributeTypeName(this.filter_disListStr_bolt_X, null);
            this.filter_disListStr_bolt_X.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_disListStr_bolt_X, "Checked");
            this.filter_disListStr_bolt_X.Checked = true;
            this.filter_disListStr_bolt_X.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_disListStr_bolt_X, true);
            this.filter_disListStr_bolt_X.Location = new System.Drawing.Point(356, 189);
            this.filter_disListStr_bolt_X.Name = "filter_disListStr_bolt_X";
            this.filter_disListStr_bolt_X.Size = new System.Drawing.Size(15, 14);
            this.filter_disListStr_bolt_X.TabIndex = 17;
            this.filter_disListStr_bolt_X.UseVisualStyleBackColor = true;
            // 
            // filter_bolt_Size
            // 
            this.structuresExtender.SetAttributeName(this.filter_bolt_Size, "bolt_Size");
            this.structuresExtender.SetAttributeTypeName(this.filter_bolt_Size, null);
            this.filter_bolt_Size.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_bolt_Size, "Checked");
            this.filter_bolt_Size.Checked = true;
            this.filter_bolt_Size.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_bolt_Size, true);
            this.filter_bolt_Size.Location = new System.Drawing.Point(356, 162);
            this.filter_bolt_Size.Name = "filter_bolt_Size";
            this.filter_bolt_Size.Size = new System.Drawing.Size(15, 14);
            this.filter_bolt_Size.TabIndex = 15;
            this.filter_bolt_Size.UseVisualStyleBackColor = true;
            // 
            // filter_bolt_Standard
            // 
            this.structuresExtender.SetAttributeName(this.filter_bolt_Standard, "bolt_Standard");
            this.structuresExtender.SetAttributeTypeName(this.filter_bolt_Standard, null);
            this.filter_bolt_Standard.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_bolt_Standard, "Checked");
            this.filter_bolt_Standard.Checked = true;
            this.filter_bolt_Standard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_bolt_Standard, true);
            this.filter_bolt_Standard.Location = new System.Drawing.Point(356, 135);
            this.filter_bolt_Standard.Name = "filter_bolt_Standard";
            this.filter_bolt_Standard.Size = new System.Drawing.Size(15, 14);
            this.filter_bolt_Standard.TabIndex = 13;
            this.filter_bolt_Standard.UseVisualStyleBackColor = true;
            // 
            // filter_disListStr_STIF_WEB
            // 
            this.structuresExtender.SetAttributeName(this.filter_disListStr_STIF_WEB, "disListStr_STIF_WEB");
            this.structuresExtender.SetAttributeTypeName(this.filter_disListStr_STIF_WEB, null);
            this.filter_disListStr_STIF_WEB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_disListStr_STIF_WEB, "Checked");
            this.filter_disListStr_STIF_WEB.Checked = true;
            this.filter_disListStr_STIF_WEB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_disListStr_STIF_WEB, true);
            this.filter_disListStr_STIF_WEB.Location = new System.Drawing.Point(356, 108);
            this.filter_disListStr_STIF_WEB.Name = "filter_disListStr_STIF_WEB";
            this.filter_disListStr_STIF_WEB.Size = new System.Drawing.Size(15, 14);
            this.filter_disListStr_STIF_WEB.TabIndex = 11;
            this.filter_disListStr_STIF_WEB.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.structuresExtender.SetAttributeName(this.label23, null);
            this.structuresExtender.SetAttributeTypeName(this.label23, null);
            this.label23.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label23, null);
            this.label23.Location = new System.Drawing.Point(279, 218);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "螺栓间距Y g";
            // 
            // label22
            // 
            this.structuresExtender.SetAttributeName(this.label22, null);
            this.structuresExtender.SetAttributeTypeName(this.label22, null);
            this.label22.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label22, null);
            this.label22.Location = new System.Drawing.Point(279, 191);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "螺栓间距X f";
            // 
            // label21
            // 
            this.structuresExtender.SetAttributeName(this.label21, null);
            this.structuresExtender.SetAttributeTypeName(this.label21, null);
            this.label21.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label21, null);
            this.label21.Location = new System.Drawing.Point(285, 164);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "螺栓尺寸  ";
            // 
            // label20
            // 
            this.structuresExtender.SetAttributeName(this.label20, null);
            this.structuresExtender.SetAttributeTypeName(this.label20, null);
            this.label20.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label20, null);
            this.label20.Location = new System.Drawing.Point(285, 137);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "螺栓标准  ";
            // 
            // label19
            // 
            this.structuresExtender.SetAttributeName(this.label19, null);
            this.structuresExtender.SetAttributeTypeName(this.label19, null);
            this.label19.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label19, null);
            this.label19.Location = new System.Drawing.Point(249, 110);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "腹板加劲板间距 e";
            // 
            // label18
            // 
            this.structuresExtender.SetAttributeName(this.label18, null);
            this.structuresExtender.SetAttributeTypeName(this.label18, null);
            this.label18.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label18, null);
            this.label18.Location = new System.Drawing.Point(483, 81);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "外倒角";
            // 
            // label17
            // 
            this.structuresExtender.SetAttributeName(this.label17, null);
            this.structuresExtender.SetAttributeTypeName(this.label17, null);
            this.label17.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label17, null);
            this.label17.Location = new System.Drawing.Point(483, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "内倒角";
            // 
            // imageListComboBox1
            // 
            this.structuresExtender.SetAttributeName(this.imageListComboBox1, "type_STIF_WEB");
            this.structuresExtender.SetAttributeTypeName(this.imageListComboBox1, "Integer");
            this.imageListComboBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imageListComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.imageListComboBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.structuresExtender.SetBindPropertyName(this.imageListComboBox1, "SelectedIndex");
            this.imageListComboBox1.DefaultValue = "";
            this.imageListComboBox1.HoverColor = System.Drawing.Color.DodgerBlue;
            this.imageListComboBox1.ImageList = this.imageList1;
            this.imageListComboBox1.Location = new System.Drawing.Point(182, 110);
            this.imageListComboBox1.MaximumSize = new System.Drawing.Size(5000, 5000);
            this.imageListComboBox1.MinimumSize = new System.Drawing.Size(65, 44);
            this.imageListComboBox1.Name = "imageListComboBox1";
            this.imageListComboBox1.SelectedIndex = 0;
            this.imageListComboBox1.SelectedItem = ((object)(resources.GetObject("imageListComboBox1.SelectedItem")));
            this.imageListComboBox1.Size = new System.Drawing.Size(65, 44);
            this.imageListComboBox1.TabIndex = 21;
            this.imageListComboBox1.ToolTipText = "";
            this.imageListComboBox1.ImageListComboBoxSelectedIndexChanged += new System.EventHandler(this.ImageListComboBox1_ImageListComboBoxSelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "3.bmp");
            this.imageList1.Images.SetKeyName(1, "4.bmp");
            // 
            // tBox_cmf_Outside
            // 
            this.structuresExtender.SetAttributeName(this.tBox_cmf_Outside, "cmf_Outside");
            this.structuresExtender.SetAttributeTypeName(this.tBox_cmf_Outside, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_cmf_Outside, "Text");
            this.tBox_cmf_Outside.Location = new System.Drawing.Point(551, 78);
            this.tBox_cmf_Outside.Name = "tBox_cmf_Outside";
            this.tBox_cmf_Outside.Size = new System.Drawing.Size(40, 21);
            this.tBox_cmf_Outside.TabIndex = 10;
            // 
            // tBox_cmf_Inside
            // 
            this.structuresExtender.SetAttributeName(this.tBox_cmf_Inside, "cmf_Inside");
            this.structuresExtender.SetAttributeTypeName(this.tBox_cmf_Inside, "Double");
            this.structuresExtender.SetBindPropertyName(this.tBox_cmf_Inside, "Text");
            this.tBox_cmf_Inside.Location = new System.Drawing.Point(551, 51);
            this.tBox_cmf_Inside.Name = "tBox_cmf_Inside";
            this.tBox_cmf_Inside.Size = new System.Drawing.Size(40, 21);
            this.tBox_cmf_Inside.TabIndex = 8;
            // 
            // tBox_prfStr_STIF_WEB
            // 
            this.structuresExtender.SetAttributeName(this.tBox_prfStr_STIF_WEB, "prfStr_STIF_WEB");
            this.structuresExtender.SetAttributeTypeName(this.tBox_prfStr_STIF_WEB, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_prfStr_STIF_WEB, "Text");
            this.tBox_prfStr_STIF_WEB.Location = new System.Drawing.Point(377, 78);
            this.tBox_prfStr_STIF_WEB.Name = "tBox_prfStr_STIF_WEB";
            this.tBox_prfStr_STIF_WEB.Size = new System.Drawing.Size(100, 21);
            this.tBox_prfStr_STIF_WEB.TabIndex = 6;
            // 
            // filter_cmf_Outside
            // 
            this.structuresExtender.SetAttributeName(this.filter_cmf_Outside, "cmf_Outside");
            this.structuresExtender.SetAttributeTypeName(this.filter_cmf_Outside, null);
            this.filter_cmf_Outside.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_cmf_Outside, "Checked");
            this.filter_cmf_Outside.Checked = true;
            this.filter_cmf_Outside.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_cmf_Outside, true);
            this.filter_cmf_Outside.Location = new System.Drawing.Point(530, 81);
            this.filter_cmf_Outside.Name = "filter_cmf_Outside";
            this.filter_cmf_Outside.Size = new System.Drawing.Size(15, 14);
            this.filter_cmf_Outside.TabIndex = 9;
            this.filter_cmf_Outside.UseVisualStyleBackColor = true;
            // 
            // tBox_prfStr_STIF_FLNG
            // 
            this.structuresExtender.SetAttributeName(this.tBox_prfStr_STIF_FLNG, "prfStr_STIF_FLNG");
            this.structuresExtender.SetAttributeTypeName(this.tBox_prfStr_STIF_FLNG, "String");
            this.structuresExtender.SetBindPropertyName(this.tBox_prfStr_STIF_FLNG, "Text");
            this.tBox_prfStr_STIF_FLNG.Location = new System.Drawing.Point(377, 51);
            this.tBox_prfStr_STIF_FLNG.Name = "tBox_prfStr_STIF_FLNG";
            this.tBox_prfStr_STIF_FLNG.Size = new System.Drawing.Size(100, 21);
            this.tBox_prfStr_STIF_FLNG.TabIndex = 4;
            // 
            // filter_cmf_Inside
            // 
            this.structuresExtender.SetAttributeName(this.filter_cmf_Inside, "cmf_Inside");
            this.structuresExtender.SetAttributeTypeName(this.filter_cmf_Inside, null);
            this.filter_cmf_Inside.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_cmf_Inside, "Checked");
            this.filter_cmf_Inside.Checked = true;
            this.filter_cmf_Inside.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_cmf_Inside, true);
            this.filter_cmf_Inside.Location = new System.Drawing.Point(530, 54);
            this.filter_cmf_Inside.Name = "filter_cmf_Inside";
            this.filter_cmf_Inside.Size = new System.Drawing.Size(15, 14);
            this.filter_cmf_Inside.TabIndex = 7;
            this.filter_cmf_Inside.UseVisualStyleBackColor = true;
            // 
            // filter_prfStr_STIF_WEB
            // 
            this.structuresExtender.SetAttributeName(this.filter_prfStr_STIF_WEB, "prfStr_STIF_WEB");
            this.structuresExtender.SetAttributeTypeName(this.filter_prfStr_STIF_WEB, null);
            this.filter_prfStr_STIF_WEB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_prfStr_STIF_WEB, "Checked");
            this.filter_prfStr_STIF_WEB.Checked = true;
            this.filter_prfStr_STIF_WEB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_prfStr_STIF_WEB, true);
            this.filter_prfStr_STIF_WEB.Location = new System.Drawing.Point(356, 80);
            this.filter_prfStr_STIF_WEB.Name = "filter_prfStr_STIF_WEB";
            this.filter_prfStr_STIF_WEB.Size = new System.Drawing.Size(15, 14);
            this.filter_prfStr_STIF_WEB.TabIndex = 5;
            this.filter_prfStr_STIF_WEB.UseVisualStyleBackColor = true;
            // 
            // filter_prfStr_STIF_FLNG
            // 
            this.structuresExtender.SetAttributeName(this.filter_prfStr_STIF_FLNG, "prfStr_STIF_FLNG");
            this.structuresExtender.SetAttributeTypeName(this.filter_prfStr_STIF_FLNG, null);
            this.filter_prfStr_STIF_FLNG.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.filter_prfStr_STIF_FLNG, "Checked");
            this.filter_prfStr_STIF_FLNG.Checked = true;
            this.filter_prfStr_STIF_FLNG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.filter_prfStr_STIF_FLNG, true);
            this.filter_prfStr_STIF_FLNG.Location = new System.Drawing.Point(356, 54);
            this.filter_prfStr_STIF_FLNG.Name = "filter_prfStr_STIF_FLNG";
            this.filter_prfStr_STIF_FLNG.Size = new System.Drawing.Size(15, 14);
            this.filter_prfStr_STIF_FLNG.TabIndex = 3;
            this.filter_prfStr_STIF_FLNG.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.structuresExtender.SetAttributeName(this.label16, null);
            this.structuresExtender.SetAttributeTypeName(this.label16, null);
            this.label16.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label16, null);
            this.label16.Location = new System.Drawing.Point(249, 82);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "腹板加劲板规格  ";
            // 
            // label15
            // 
            this.structuresExtender.SetAttributeName(this.label15, null);
            this.structuresExtender.SetAttributeTypeName(this.label15, null);
            this.label15.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label15, null);
            this.label15.Location = new System.Drawing.Point(249, 56);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "翼缘加劲板规格  ";
            // 
            // label14
            // 
            this.structuresExtender.SetAttributeName(this.label14, null);
            this.structuresExtender.SetAttributeTypeName(this.label14, null);
            this.label14.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label14, null);
            this.label14.Location = new System.Drawing.Point(375, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "PL t * b * l";
            // 
            // label13
            // 
            this.structuresExtender.SetAttributeName(this.label13, null);
            this.structuresExtender.SetAttributeTypeName(this.label13, null);
            this.label13.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label13, null);
            this.label13.Location = new System.Drawing.Point(94, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "g";
            // 
            // label12
            // 
            this.structuresExtender.SetAttributeName(this.label12, null);
            this.structuresExtender.SetAttributeTypeName(this.label12, null);
            this.label12.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label12, null);
            this.label12.Location = new System.Drawing.Point(38, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "f";
            // 
            // label11
            // 
            this.structuresExtender.SetAttributeName(this.label11, null);
            this.structuresExtender.SetAttributeTypeName(this.label11, null);
            this.label11.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label11, null);
            this.label11.Location = new System.Drawing.Point(154, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "e";
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
            this.saveLoad.Size = new System.Drawing.Size(605, 40);
            this.saveLoad.TabIndex = 0;
            this.saveLoad.UserDefinedHelpFilePath = null;
            // 
            // FormMG1002
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(611, 438);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMG1002";
            this.Text = "门刚中柱与梁水平连接";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel OkApplyModifyGetOnOffCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tBox_pos_DIAG2;
        private System.Windows.Forms.TextBox tBox_pos_DIAG1;
        private System.Windows.Forms.TextBox tBox_prfStr_DIAG;
        private System.Windows.Forms.TextBox tBox_prfStr_VERT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox filter_pos_DIAG2;
        private System.Windows.Forms.CheckBox filter_pos_DIAG1;
        private System.Windows.Forms.CheckBox filter_prfStr_DIAG;
        private System.Windows.Forms.CheckBox filter_prfStr_VERT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBox_cmf_Inside;
        private System.Windows.Forms.TextBox tBox_prfStr_STIF_WEB;
        private System.Windows.Forms.TextBox tBox_prfStr_STIF_FLNG;
        private System.Windows.Forms.CheckBox filter_cmf_Inside;
        private System.Windows.Forms.CheckBox filter_prfStr_STIF_WEB;
        private System.Windows.Forms.CheckBox filter_prfStr_STIF_FLNG;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Tekla.Structures.Dialog.UIControls.ImageListComboBox imageListComboBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tBox_cmf_Outside;
        private System.Windows.Forms.CheckBox filter_cmf_Outside;
        private System.Windows.Forms.TextBox tBox_disListStr_bolt_Y;
        private System.Windows.Forms.TextBox tBox_disListStr_bolt_X;
        private System.Windows.Forms.TextBox tBox_disListStr_STIF_WEB;
        private System.Windows.Forms.CheckBox filter_disListStr_bolt_Y;
        private System.Windows.Forms.CheckBox filter_disListStr_bolt_X;
        private System.Windows.Forms.CheckBox filter_bolt_Size;
        private System.Windows.Forms.CheckBox filter_bolt_Standard;
        private System.Windows.Forms.CheckBox filter_disListStr_STIF_WEB;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tBox_group_no;
        private System.Windows.Forms.CheckBox filter_goup_no;
        private System.Windows.Forms.Label label24;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogStandard boltCatalogStandard1;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogSize boltCatalogSize1;
        private System.Windows.Forms.TextBox tBox_prfStr_EndPlate;
        private System.Windows.Forms.CheckBox filter_prfStr_EndPlate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tBox_materialStr;
        private System.Windows.Forms.CheckBox filter_materialStr;
        private System.Windows.Forms.Label label26;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog materialCatalog1;
    }
}