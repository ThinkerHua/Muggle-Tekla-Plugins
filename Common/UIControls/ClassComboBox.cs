using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MuggleTeklaPlugins.Common.UIControls {
    /// <summary>
    /// 等级选择组合框。
    /// </summary>
    public class ClassComboBox : UserControl {
        private readonly Bitmap[] bitmaps = new Bitmap[] {
            Properties.Resources.class_0,
            Properties.Resources.class_1,
            Properties.Resources.class_2,
            Properties.Resources.class_3,
            Properties.Resources.class_4,
            Properties.Resources.class_5,
            Properties.Resources.class_6,
            Properties.Resources.class_7,
            Properties.Resources.class_8,
            Properties.Resources.class_9,
            Properties.Resources.class_10,
            Properties.Resources.class_11,
            Properties.Resources.class_12,
            Properties.Resources.class_13,
            Properties.Resources.class_14, 
        };
        private const int _imageWidth = 64;
        private const int _imageHeight = 16;
        private ComboBox innerComboBox;
        public ClassComboBox() {
            InitializeComponent();
            this.innerComboBox.BeginUpdate();
            for (int i = 0; i < 100; i++) {
                this.innerComboBox.Items.Add(i.ToString());
            }
            this.innerComboBox.EndUpdate();
            this.innerComboBox.DrawItem += DrawImageAndItem;
            this.innerComboBox.DropDownStyle = ComboBoxStyle.DropDown;
        }
        [Browsable(false)]//禁止在设计器属性面板中显示，避免用户输入额外不相关项目
        public ComboBox.ObjectCollection Items { get { return innerComboBox.Items; } }
        private void DrawImageAndItem(object sender, DrawItemEventArgs e) {
            var graphics = e.Graphics;
            var index = e.Index;
            var rect = e.Bounds;
            var txtDrawPositionX = rect.Left + _imageWidth;
            var txtDrawPositionY = rect.Top + (rect.Height - Font.Height) * 0.5f;
            string str = Items[index].ToString();
            e.DrawBackground();
            e.DrawFocusRectangle();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected ||
                (e.State & DrawItemState.Focus) == DrawItemState.Focus) {
                graphics.DrawString(str, Font, new SolidBrush(Color.White), txtDrawPositionX, txtDrawPositionY);
            } else {
                graphics.DrawString(str, Font, new SolidBrush(Color.Black), txtDrawPositionX, txtDrawPositionY);
            }

            var imageIndex = index % 14;
            imageIndex = imageIndex == 0 ? (index == 0 ? 0 : 14) : imageIndex;
            graphics.DrawImage(bitmaps[imageIndex], rect.Left, rect.Top, _imageWidth, _imageHeight);
        }

        private void InitializeComponent() {
            this.innerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // innerComboBox
            // 
            this.innerComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.innerComboBox.FormattingEnabled = true;
            this.innerComboBox.Location = new System.Drawing.Point(0, 0);
            this.innerComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.innerComboBox.Name = "innerComboBox";
            this.innerComboBox.Size = new System.Drawing.Size(150, 22);
            this.innerComboBox.TabIndex = 0;
            // 
            // ClassComboBox
            // 
            this.Controls.Add(this.innerComboBox);
            this.Name = "ClassComboBox";
            this.ResumeLayout(false);

        }
    }
}
