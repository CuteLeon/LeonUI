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

        public new event EventHandler TextChanged;
        
        //用于把属性显示在属性面板中，并在代码生成器中储存属性的值
        [Browsable(true)]
        [Description("文本输入框显示的文本"), Category("自定义属性卡"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => InnerTextBox.Text;
            set
            {
                InnerTextBox.Text=value;
                TextChanged?.Invoke(this, new EventArgs());
            }
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

        private void SmipleTextBox_Resize(object sender, EventArgs e)
        {
            if (this.Size.Equals(BGImage?.Size)) return;

            this.BackgroundImage = null;
            //CreateBGImage(ref BGImage);
            this.BackgroundImage = BGImage;

            InnerTextBox.Left = 16;
            InnerTextBox.Width = this.Width - 16 - 16;
            InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2+1;
        }

    }
}
