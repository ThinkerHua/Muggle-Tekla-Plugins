
namespace MuggleTeklaPlugins.MainForm {
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
            if(disposing && (components != null)) {
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
            this.btnSelectBooleans = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowPartCoordinateSystem = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.btnSelectBooleans.Click += new System.EventHandler(this.ButtonSelectBooleans_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnShowPartCoordinateSystem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectBooleans, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 238);
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
            this.btnShowPartCoordinateSystem.Click += new System.EventHandler(this.ShowModelObjectCoordinateSystem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muggle Tekla-Plugins";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectBooleans;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnShowPartCoordinateSystem;
    }
}

