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
using System.Drawing.Design;
using System.IO;

namespace LeonUI.Controls
{
    public partial class RoundedTextBox : UserControl
    {
        private Rectangle CenterRectangle = new Rectangle(17, 16, 70, 2);

        public new event EventHandler TextChanged
        {
            add => InnerTextBox.TextChanged += value;
            remove => InnerTextBox.TextChanged -= value;
        }
        
        [Browsable(true)]
        [Description("文本输入框显示的文本"), Category("自定义属性卡"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SettingsBindable(true)]
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
                if (InnerTextBox.Multiline)
                {
                    InnerTextBox.Top = 7;
                }
                else
                {
                    InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2;
                    InnerTextBox.Height = this.Height - 12;
                }
            }
        }

        public bool WordWrap
        {
            get => InnerTextBox.WordWrap;
            set => InnerTextBox.WordWrap = value;
        }

        /// <summary>
        /// 文本框是否允许换行
        /// </summary>
        public bool Multiline
        {
            get => InnerTextBox.Multiline;
            set
            {
                InnerTextBox.Multiline = value;
                if (value)
                {
                    InnerTextBox.Top = 7;
                }
                else
                {
                    InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2;
                    InnerTextBox.Height = this.Height - 12;
                }
            }
        }

        public ScrollBars ScrollBar
        {
            get => InnerTextBox.ScrollBars;
            set => InnerTextBox.ScrollBars=value;
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

        public RoundedTextBox()
        {
            InitializeComponent();

            base.SetStyle(ControlStyles.FixedHeight, false);
            this.OnResize(null);

            this.MinimumSize = new Size(43,34);
        }

        private void RoundedTextBox_Resize(object sender, EventArgs e)
        {
            InnerTextBox.Width = this.Width - 32;
            if (InnerTextBox.Multiline)
            {
                InnerTextBox.Top = 7;
                InnerTextBox.Height = this.Height - 12;
            }
            else
                InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2;


            if (this.Size.Equals(BGImage?.Size)) return;
            this.BackgroundImage = null;
            BitmapProcessor.RenderBGI(UnityResource.TextBoxBGI, this.Size, CenterRectangle, ref BGImage);
            this.BackgroundImage = BGImage;
        }

    }
}
