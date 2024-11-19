using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MuggleTeklaPlugins.Common.UIControls {
    /// <summary>
    /// 可在选项前显示图片的ComboBox。
    /// <para>
    ///     需先设置 <see cref="ImageList"/> 属性，为空则不显示图片。
    ///     <see cref="ImageList.ImageSize"/> 属性需与 <see cref="ComboBox.ItemHeight"/> 属性相匹配，
    ///     否则图片将显示过小或不全。
    /// </para>
    /// <para><see cref="DrawMode"/> 属性在设计器中设置是无效的，初始化时始终设置为 <see cref="DrawMode.OwnerDrawFixed"/>。</para>
    /// <para>
    ///     不允许输入新值的场景下，应将 <see cref="ComboBox.DropDownStyle"/> 属性设置为 <see cref="ComboBoxStyle.DropDownList"/>，
    ///     此场景下，编辑框中也显示图片；
    ///     否则，应设置为 <see cref="ComboBoxStyle.DropDown"/>，此场景下，编辑框中不显示图片。
    /// </para>
    /// </summary>
    public class ComboBoxEx : ComboBox {
        private ImageList _imagelist;
        [Category("Data")]
        [Description("要在选项前面展示的图片。\"ImageList.ImageSize\"属性需与\"ItemHeight\"属性相匹配，以保证图片完整显示。")]
        public ImageList ImageList {
            get => _imagelist;
            set {
                _imagelist = value;
            }
        }
        public ComboBoxEx() {
            InitializeComponent();
        }
        private void DrawImageAndItem(object sender, DrawItemEventArgs e) {
            var graphics = e.Graphics;
            var index = e.Index;
            var rect = e.Bounds;
            var imageSize = _imagelist == null ? new Size() : _imagelist.ImageSize;
            var imageDrawHeight = ItemHeight;
            var imageDrawWidth = imageSize.Width / imageSize.Height * imageDrawHeight;
            var txtDrawPositionX = rect.Left + imageDrawWidth;
            var txtDrawPositionY = rect.Top + (rect.Height - Font.Height) * 0.5f;
            if (index >= 0) {
                string str = Items[index].ToString();
                e.DrawBackground();
                e.DrawFocusRectangle();
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected ||
                    (e.State & DrawItemState.Focus) == DrawItemState.Focus) {
                    graphics.DrawString(str, Font, new SolidBrush(Color.White), txtDrawPositionX, txtDrawPositionY);
                } else {
                    graphics.DrawString(str, Font, new SolidBrush(Color.Black), txtDrawPositionX, txtDrawPositionY);
                }
                if (_imagelist != null && index < _imagelist.Images.Count) {
                    _imagelist.Draw(graphics, rect.Left, rect.Top, imageDrawWidth, ItemHeight, index);
                }
            }
        }
        private void InitializeComponent() {
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += DrawImageAndItem;
        }
    }
}
