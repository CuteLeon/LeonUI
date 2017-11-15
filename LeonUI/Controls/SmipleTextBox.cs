using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace LeonUI.Controls
{
    public partial class SmipleTextBox : UserControl
    {
        /// <summary>
        /// SmipleTextBox 背景图资源
        /// </summary>
        static Bitmap StaticBGImage = UnityResource.TextBoxBGI;

        /// <summary>
        /// 左边切图
        /// </summary>
        static Bitmap LeftBitmap = StaticBGImage.Clone(new Rectangle(0,0,16,32),System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        /// <summary>
        /// 右边切图
        /// </summary>
        static Bitmap RightBitmap = StaticBGImage.Clone(new Rectangle(86, 0, 16, 32), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        /// <summary>
        /// 中间切图
        /// </summary>
        static Bitmap MidBitmap = StaticBGImage.Clone(new Rectangle(16, 0, 70, 32), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        //用于把属性显示在属性面板中，并在代码生成器中储存属性的值
        [Browsable(true)]
        [Description("文本输入框显示的文本"), Category("自定义属性卡"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => InnerTextBox.Text;
            set => InnerTextBox.Text=value;
        }

        /// <summary>
        /// 背景图像
        /// </summary>
        private Bitmap BGImage = null;

        public SmipleTextBox()
        {
            InitializeComponent();

            this.OnResize(null);

            this.MinimumSize = new Size(32,32);
            this.MaximumSize = new Size(0,32);
        }

        private void CreateBGImage(ref Bitmap BGImage)
        {
            BGImage?.Dispose();
            if (this.Width == 0 || this.Height == 0)
            {
                BGImage = null;
                return;
            }

            try
            {
                BGImage = new Bitmap(this.Size.Width, 32);
                using (Graphics graphics = Graphics.FromImage(BGImage))
                {
                    graphics.DrawImage(LeftBitmap, 0, 0, 16, 32);
                    using (TextureBrush MidImageBrush = new TextureBrush(MidBitmap) { WrapMode = System.Drawing.Drawing2D.WrapMode.Tile })
                        graphics.FillRectangle(MidImageBrush, new Rectangle(16, 0, this.Width - 32, 32));
                    graphics.DrawImage(RightBitmap, this.Width - 16, 0, 16, 32);
                }
            }
            catch { }
        }

        private void SmipleTextBox_Resize(object sender, EventArgs e)
        {
            if (this.Size.Equals(BGImage?.Size)) return;

            this.BackgroundImage = null;
            CreateBGImage(ref BGImage);
            this.BackgroundImage = BGImage;

            InnerTextBox.Left = 16;
            InnerTextBox.Width = this.Width - 16 - 16;
            InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2+1;
        }

    }
}
