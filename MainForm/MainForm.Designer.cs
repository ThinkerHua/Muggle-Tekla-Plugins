﻿/*==============================================================================
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
 *  MainForm.Designer.cs: form designer for "MainForm"
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
namespace Muggle.TeklaPlugins.MainForm {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnSelectBooleans = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowPartCoordinateSystem = new System.Windows.Forms.Button();
            this.btnSelectWeldedObjects = new System.Windows.Forms.Button();
            this.btnReorderContourPoints = new System.Windows.Forms.Button();
            this.btnCopyWithDirection = new System.Windows.Forms.Button();
            this.btnThreeDimensionalRotation = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_WK1001 = new System.Windows.Forms.Button();
            this.btn_KJ2001 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectBooleans
            // 
            this.btnSelectBooleans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBooleans.Location = new System.Drawing.Point(3, 35);
            this.btnSelectBooleans.Name = "btnSelectBooleans";
            this.btnSelectBooleans.Size = new System.Drawing.Size(146, 26);
            this.btnSelectBooleans.TabIndex = 1;
            this.btnSelectBooleans.Text = "选择零件的布尔操作对象";
            this.btnSelectBooleans.UseVisualStyleBackColor = true;
            this.btnSelectBooleans.Click += new System.EventHandler(this.SelectBooleans);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel1.Controls.Add(this.btnShowPartCoordinateSystem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectBooleans, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectWeldedObjects, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReorderContourPoints, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCopyWithDirection, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnThreeDimensionalRotation, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 229);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnShowPartCoordinateSystem
            // 
            this.btnShowPartCoordinateSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowPartCoordinateSystem.Location = new System.Drawing.Point(3, 3);
            this.btnShowPartCoordinateSystem.Name = "btnShowPartCoordinateSystem";
            this.btnShowPartCoordinateSystem.Size = new System.Drawing.Size(146, 26);
            this.btnShowPartCoordinateSystem.TabIndex = 0;
            this.btnShowPartCoordinateSystem.Text = "显示模型对象坐标系";
            this.btnShowPartCoordinateSystem.UseVisualStyleBackColor = true;
            this.btnShowPartCoordinateSystem.Click += new System.EventHandler(this.Run_ShowModelObjectCoordinateSystem);
            // 
            // btnSelectWeldedObjects
            // 
            this.btnSelectWeldedObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectWeldedObjects.Location = new System.Drawing.Point(3, 67);
            this.btnSelectWeldedObjects.Name = "btnSelectWeldedObjects";
            this.btnSelectWeldedObjects.Size = new System.Drawing.Size(146, 26);
            this.btnSelectWeldedObjects.TabIndex = 1;
            this.btnSelectWeldedObjects.Text = "选择焊缝的焊接对象";
            this.toolTip1.SetToolTip(this.btnSelectWeldedObjects, "有时个别焊缝比较怪异，但焊缝比较多，不清楚该焊缝的焊接对象是什么。本工具可解决此问题。");
            this.btnSelectWeldedObjects.UseVisualStyleBackColor = true;
            this.btnSelectWeldedObjects.Click += new System.EventHandler(this.Run_SelectWeldedObjects);
            // 
            // btnReorderContourPoints
            // 
            this.btnReorderContourPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReorderContourPoints.Location = new System.Drawing.Point(3, 99);
            this.btnReorderContourPoints.Name = "btnReorderContourPoints";
            this.btnReorderContourPoints.Size = new System.Drawing.Size(146, 26);
            this.btnReorderContourPoints.TabIndex = 1;
            this.btnReorderContourPoints.Text = "调整多边形板轮廓起始点";
            this.btnReorderContourPoints.UseVisualStyleBackColor = true;
            this.btnReorderContourPoints.Click += new System.EventHandler(this.Run_ReorderContourPoints);
            // 
            // btnCopyWithDirection
            // 
            this.btnCopyWithDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyWithDirection.Location = new System.Drawing.Point(3, 131);
            this.btnCopyWithDirection.Name = "btnCopyWithDirection";
            this.btnCopyWithDirection.Size = new System.Drawing.Size(146, 26);
            this.btnCopyWithDirection.TabIndex = 1;
            this.btnCopyWithDirection.Text = "带方向复制";
            this.btnCopyWithDirection.UseVisualStyleBackColor = true;
            this.btnCopyWithDirection.Click += new System.EventHandler(this.Run_CopyWithDirection);
            // 
            // btnThreeDimensionalRotation
            // 
            this.btnThreeDimensionalRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThreeDimensionalRotation.Location = new System.Drawing.Point(3, 163);
            this.btnThreeDimensionalRotation.Name = "btnThreeDimensionalRotation";
            this.btnThreeDimensionalRotation.Size = new System.Drawing.Size(146, 26);
            this.btnThreeDimensionalRotation.TabIndex = 1;
            this.btnThreeDimensionalRotation.Text = "三维旋转";
            this.btnThreeDimensionalRotation.UseVisualStyleBackColor = true;
            this.btnThreeDimensionalRotation.Click += new System.EventHandler(this.Run_ThreeDimensionalRotation);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 261);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tools";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plugins";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_WK1001, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_KJ2001, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(370, 229);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_WK1001
            // 
            this.btn_WK1001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_WK1001.Location = new System.Drawing.Point(3, 131);
            this.btn_WK1001.Name = "btn_WK1001";
            this.btn_WK1001.Size = new System.Drawing.Size(122, 23);
            this.btn_WK1001.TabIndex = 1;
            this.btn_WK1001.Text = "WK1001";
            this.btn_WK1001.UseVisualStyleBackColor = true;
            this.btn_WK1001.Click += new System.EventHandler(this.Run_WK1001);
            // 
            // btn_KJ2001
            // 
            this.btn_KJ2001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_KJ2001.Location = new System.Drawing.Point(131, 131);
            this.btn_KJ2001.Name = "btn_KJ2001";
            this.btn_KJ2001.Size = new System.Drawing.Size(122, 23);
            this.btn_KJ2001.TabIndex = 3;
            this.btn_KJ2001.Text = "KJ2001";
            this.btn_KJ2001.UseVisualStyleBackColor = true;
            this.btn_KJ2001.Click += new System.EventHandler(this.Run_KJ2001);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Muggle.TeklaPlugins.MainForm.Properties.Resources.et_element_WK1001;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Muggle.TeklaPlugins.MainForm.Properties.Resources.et_element_KJ2001;
            this.pictureBox2.Location = new System.Drawing.Point(128, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Muggle.TeklaPlugins.MainForm.Properties.Resources.et_element_WK1001;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Run_WK1001);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muggle Tekla-Plugins";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectBooleans;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnShowPartCoordinateSystem;
        private System.Windows.Forms.Button btnSelectWeldedObjects;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_WK1001;
        private System.Windows.Forms.Button btnReorderContourPoints;
        private System.Windows.Forms.Button btnCopyWithDirection;
        private System.Windows.Forms.Button btnThreeDimensionalRotation;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_KJ2001;
    }
}

