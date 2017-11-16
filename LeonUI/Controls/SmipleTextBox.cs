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
        private Rectangle CenterRectangle = new Rectangle(17, 16, 70, 2);

        public new event EventHandler TextChanged
        {
            add => InnerTextBox.TextChanged += value;
            remove => InnerTextBox.TextChanged -= value;
        }
        
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

        /// <summary>
        /// 文字水平方向
        /// </summary>
        public HorizontalAlignment TextAlign
        {
            get => InnerTextBox.TextAlign;
            set => InnerTextBox.TextAlign = value;
        }

        /// <summary>
        /// 设置控件字体
        /// </summary>
        public new Font Font
        {
            get => InnerTextBox.Font;
            set
            {
                InnerTextBox.Font = value;
                this.MinimumSize = new Size(45, InnerTextBox.Height + 12);
                InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2;
            }
        }

        /// <summary>
        /// 设置控件字体颜色
        /// </summary>
        public new Color ForeColor
        {
            get => InnerTextBox.ForeColor;
            set
            {
                InnerTextBox.ForeColor = value;
            }
        }

        public SmipleTextBox()
        {
            InitializeComponent();

            base.SetStyle(ControlStyles.FixedHeight, false);
            this.OnResize(null);

            this.MinimumSize = new Size(43,34);
        }

        private void SmipleTextBox_Resize(object sender, EventArgs e)
        {
            InnerTextBox.Width = this.Width - 32;
            InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2;

            if (this.Size.Equals(BGImage?.Size)) return;
            this.BackgroundImage = null;
            BitmapProcessor.RenderBGI(UnityResource.TextBoxBGI, this.Size, CenterRectangle, ref BGImage);
            this.BackgroundImage = BGImage;
        }

    }
}
