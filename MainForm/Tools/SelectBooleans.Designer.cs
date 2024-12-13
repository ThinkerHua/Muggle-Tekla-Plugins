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
 *  SelectBooleans.Designer.cs: form designer for "SelectBooleans"
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
namespace Muggle.TeklaPlugins.MainForm.Tools {
    partial class SelectBooleans {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.filter_BooleanAdd = new System.Windows.Forms.CheckBox();
            this.filter_BooleanCut = new System.Windows.Forms.CheckBox();
            this.filter_BooleanWeldPrep = new System.Windows.Forms.CheckBox();
            this.filter_CutPlane = new System.Windows.Forms.CheckBox();
            this.filter_EdgeChamfer = new System.Windows.Forms.CheckBox();
            this.filter_Fitting = new System.Windows.Forms.CheckBox();
            this.start = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Controls.Add(this.filter_BooleanAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.filter_BooleanCut, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.filter_BooleanWeldPrep, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.filter_CutPlane, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.filter_EdgeChamfer, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.filter_Fitting, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.start, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(133, 225);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // filter_BooleanAdd
            // 
            this.filter_BooleanAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_BooleanAdd.AutoSize = true;
            this.filter_BooleanAdd.Location = new System.Drawing.Point(3, 3);
            this.filter_BooleanAdd.Name = "filter_BooleanAdd";
            this.filter_BooleanAdd.Size = new System.Drawing.Size(126, 26);
            this.filter_BooleanAdd.TabIndex = 0;
            this.filter_BooleanAdd.Text = "布尔增";
            this.filter_BooleanAdd.UseVisualStyleBackColor = true;
            // 
            // filter_BooleanCut
            // 
            this.filter_BooleanCut.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_BooleanCut.AutoSize = true;
            this.filter_BooleanCut.Checked = true;
            this.filter_BooleanCut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filter_BooleanCut.Location = new System.Drawing.Point(3, 35);
            this.filter_BooleanCut.Name = "filter_BooleanCut";
            this.filter_BooleanCut.Size = new System.Drawing.Size(126, 26);
            this.filter_BooleanCut.TabIndex = 1;
            this.filter_BooleanCut.Text = "布尔减 - 零件切割";
            this.filter_BooleanCut.UseVisualStyleBackColor = true;
            // 
            // filter_BooleanWeldPrep
            // 
            this.filter_BooleanWeldPrep.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_BooleanWeldPrep.AutoSize = true;
            this.filter_BooleanWeldPrep.Location = new System.Drawing.Point(3, 67);
            this.filter_BooleanWeldPrep.Name = "filter_BooleanWeldPrep";
            this.filter_BooleanWeldPrep.Size = new System.Drawing.Size(126, 26);
            this.filter_BooleanWeldPrep.TabIndex = 2;
            this.filter_BooleanWeldPrep.Text = "焊接准备";
            this.filter_BooleanWeldPrep.UseVisualStyleBackColor = true;
            // 
            // filter_CutPlane
            // 
            this.filter_CutPlane.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_CutPlane.AutoSize = true;
            this.filter_CutPlane.Location = new System.Drawing.Point(3, 99);
            this.filter_CutPlane.Name = "filter_CutPlane";
            this.filter_CutPlane.Size = new System.Drawing.Size(126, 26);
            this.filter_CutPlane.TabIndex = 3;
            this.filter_CutPlane.Text = "切割平面 - 线切割";
            this.filter_CutPlane.UseVisualStyleBackColor = true;
            // 
            // filter_EdgeChamfer
            // 
            this.filter_EdgeChamfer.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_EdgeChamfer.AutoSize = true;
            this.filter_EdgeChamfer.Location = new System.Drawing.Point(3, 131);
            this.filter_EdgeChamfer.Name = "filter_EdgeChamfer";
            this.filter_EdgeChamfer.Size = new System.Drawing.Size(126, 26);
            this.filter_EdgeChamfer.TabIndex = 4;
            this.filter_EdgeChamfer.Text = "边缘倒角";
            this.filter_EdgeChamfer.UseVisualStyleBackColor = true;
            // 
            // filter_Fitting
            // 
            this.filter_Fitting.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_Fitting.AutoSize = true;
            this.filter_Fitting.Location = new System.Drawing.Point(3, 163);
            this.filter_Fitting.Name = "filter_Fitting";
            this.filter_Fitting.Size = new System.Drawing.Size(126, 26);
            this.filter_Fitting.TabIndex = 5;
            this.filter_Fitting.Text = "末端对齐";
            this.filter_Fitting.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(3, 195);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(126, 26);
            this.start.TabIndex = 6;
            this.start.Text = "启动选择";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.StartSelect);
            // 
            // SelectBooleans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 249);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectBooleans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectBooleans";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox filter_BooleanAdd;
        private System.Windows.Forms.CheckBox filter_BooleanCut;
        private System.Windows.Forms.CheckBox filter_BooleanWeldPrep;
        private System.Windows.Forms.CheckBox filter_CutPlane;
        private System.Windows.Forms.CheckBox filter_EdgeChamfer;
        private System.Windows.Forms.CheckBox filter_Fitting;
        private System.Windows.Forms.Button start;
    }
}