namespace Muggle.TeklaPlugins.MainForm.Tools {
    partial class ThreeDimensionalRotation {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtn_SelectShaft = new System.Windows.Forms.RadioButton();
            this.rBtn_PartCS_Z = new System.Windows.Forms.RadioButton();
            this.rBtn_PartCS_X = new System.Windows.Forms.RadioButton();
            this.rBtn_PartCS_Y = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBox_NormalOfPlane = new System.Windows.Forms.CheckBox();
            this.tBox_AngleValue = new System.Windows.Forms.TextBox();
            this.rBtn_SelectDirection = new System.Windows.Forms.RadioButton();
            this.rBtn_AngleValue = new System.Windows.Forms.RadioButton();
            this.btn_Action = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Action, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(174, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.rBtn_SelectShaft);
            this.groupBox1.Controls.Add(this.rBtn_PartCS_Z);
            this.groupBox1.Controls.Add(this.rBtn_PartCS_X);
            this.groupBox1.Controls.Add(this.rBtn_PartCS_Y);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "旋转轴";
            // 
            // rBtn_SelectShaft
            // 
            this.rBtn_SelectShaft.AutoSize = true;
            this.rBtn_SelectShaft.Location = new System.Drawing.Point(6, 86);
            this.rBtn_SelectShaft.Name = "rBtn_SelectShaft";
            this.rBtn_SelectShaft.Size = new System.Drawing.Size(107, 16);
            this.rBtn_SelectShaft.TabIndex = 0;
            this.rBtn_SelectShaft.Text = "点选指定旋转轴";
            this.rBtn_SelectShaft.UseVisualStyleBackColor = true;
            // 
            // rBtn_PartCS_Z
            // 
            this.rBtn_PartCS_Z.AutoSize = true;
            this.rBtn_PartCS_Z.Location = new System.Drawing.Point(6, 64);
            this.rBtn_PartCS_Z.Name = "rBtn_PartCS_Z";
            this.rBtn_PartCS_Z.Size = new System.Drawing.Size(101, 16);
            this.rBtn_PartCS_Z.TabIndex = 0;
            this.rBtn_PartCS_Z.Text = "零件坐标系Z轴";
            this.rBtn_PartCS_Z.UseVisualStyleBackColor = true;
            // 
            // rBtn_PartCS_X
            // 
            this.rBtn_PartCS_X.AutoSize = true;
            this.rBtn_PartCS_X.Checked = true;
            this.rBtn_PartCS_X.Location = new System.Drawing.Point(6, 20);
            this.rBtn_PartCS_X.Name = "rBtn_PartCS_X";
            this.rBtn_PartCS_X.Size = new System.Drawing.Size(101, 16);
            this.rBtn_PartCS_X.TabIndex = 0;
            this.rBtn_PartCS_X.TabStop = true;
            this.rBtn_PartCS_X.Text = "零件坐标系X轴";
            this.rBtn_PartCS_X.UseVisualStyleBackColor = true;
            // 
            // rBtn_PartCS_Y
            // 
            this.rBtn_PartCS_Y.AutoSize = true;
            this.rBtn_PartCS_Y.Location = new System.Drawing.Point(6, 42);
            this.rBtn_PartCS_Y.Name = "rBtn_PartCS_Y";
            this.rBtn_PartCS_Y.Size = new System.Drawing.Size(101, 16);
            this.rBtn_PartCS_Y.TabIndex = 0;
            this.rBtn_PartCS_Y.Text = "零件坐标系Y轴";
            this.rBtn_PartCS_Y.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.cBox_NormalOfPlane);
            this.groupBox2.Controls.Add(this.tBox_AngleValue);
            this.groupBox2.Controls.Add(this.rBtn_SelectDirection);
            this.groupBox2.Controls.Add(this.rBtn_AngleValue);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "旋转角度";
            // 
            // cBox_NormalOfPlane
            // 
            this.cBox_NormalOfPlane.AutoSize = true;
            this.cBox_NormalOfPlane.Checked = true;
            this.cBox_NormalOfPlane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox_NormalOfPlane.Enabled = false;
            this.cBox_NormalOfPlane.Location = new System.Drawing.Point(26, 64);
            this.cBox_NormalOfPlane.Name = "cBox_NormalOfPlane";
            this.cBox_NormalOfPlane.Size = new System.Drawing.Size(132, 16);
            this.cBox_NormalOfPlane.TabIndex = 3;
            this.cBox_NormalOfPlane.Text = "终止方向为平面法向";
            this.cBox_NormalOfPlane.UseVisualStyleBackColor = true;
            // 
            // tBox_AngleValue
            // 
            this.tBox_AngleValue.Location = new System.Drawing.Point(59, 19);
            this.tBox_AngleValue.Name = "tBox_AngleValue";
            this.tBox_AngleValue.Size = new System.Drawing.Size(102, 21);
            this.tBox_AngleValue.TabIndex = 2;
            this.tBox_AngleValue.Text = "90";
            this.tBox_AngleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBox_AngleValue.Validating += new System.ComponentModel.CancelEventHandler(this.tBox_AngleValue_Validating);
            // 
            // rBtn_SelectDirection
            // 
            this.rBtn_SelectDirection.AutoSize = true;
            this.rBtn_SelectDirection.Location = new System.Drawing.Point(6, 42);
            this.rBtn_SelectDirection.Name = "rBtn_SelectDirection";
            this.rBtn_SelectDirection.Size = new System.Drawing.Size(155, 16);
            this.rBtn_SelectDirection.TabIndex = 1;
            this.rBtn_SelectDirection.Text = "点选指定起始和终止方向";
            this.rBtn_SelectDirection.UseVisualStyleBackColor = true;
            this.rBtn_SelectDirection.CheckedChanged += new System.EventHandler(this.rBtn_SelectDirection_CheckedChanged);
            // 
            // rBtn_AngleValue
            // 
            this.rBtn_AngleValue.AutoSize = true;
            this.rBtn_AngleValue.Checked = true;
            this.rBtn_AngleValue.Location = new System.Drawing.Point(6, 20);
            this.rBtn_AngleValue.Name = "rBtn_AngleValue";
            this.rBtn_AngleValue.Size = new System.Drawing.Size(47, 16);
            this.rBtn_AngleValue.TabIndex = 0;
            this.rBtn_AngleValue.TabStop = true;
            this.rBtn_AngleValue.Text = "角度";
            this.rBtn_AngleValue.UseVisualStyleBackColor = true;
            this.rBtn_AngleValue.CheckedChanged += new System.EventHandler(this.rBtn_AngleValue_CheckedChanged);
            // 
            // btn_Action
            // 
            this.btn_Action.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Action.Location = new System.Drawing.Point(3, 237);
            this.btn_Action.Name = "btn_Action";
            this.btn_Action.Size = new System.Drawing.Size(168, 30);
            this.btn_Action.TabIndex = 2;
            this.btn_Action.Text = "执行";
            this.btn_Action.UseVisualStyleBackColor = true;
            this.btn_Action.Click += new System.EventHandler(this.btn_Action_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ThreeDimensionalRotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 270);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThreeDimensionalRotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3DRotation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtn_PartCS_Z;
        private System.Windows.Forms.RadioButton rBtn_PartCS_Y;
        private System.Windows.Forms.RadioButton rBtn_PartCS_X;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rBtn_SelectDirection;
        private System.Windows.Forms.RadioButton rBtn_AngleValue;
        private System.Windows.Forms.RadioButton rBtn_SelectShaft;
        private System.Windows.Forms.TextBox tBox_AngleValue;
        private System.Windows.Forms.CheckBox cBox_NormalOfPlane;
        private System.Windows.Forms.Button btn_Action;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}