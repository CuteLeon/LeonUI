using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonUI.Forms
{
    public partial class LeonMessageBox : Form
    {
        private Pen borderPen = new Pen(Color.DeepSkyBlue);
        /// <summary>
       /// 弹窗主题颜色
        /// </summary>
        public Color ThemeColor
        {
            get => borderPen.Color;
            set
            {
                TitleLabel.ForeColor = value;
                MessageLabel.ForeColor = value;
                borderPen.Color = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 弹窗消息类型
        /// </summary>
        public enum IconType
        {
            /// <summary>
            /// 消息
            /// </summary>
            Info,
            /// <summary>
            /// 询问
            /// </summary>
            Question,
            /// <summary>
            /// 警告
            /// </summary>
            Warning,
            /// <summary>
            /// 错误
            /// </summary>
            Error
        }

        public LeonMessageBox(string Title, string Message, IconType IconType, params object[] MessageValues):
            this(Title, string.Format(Message,MessageValues),IconType){ }

        public LeonMessageBox(string Title, string Message, IconType IconType)
        {
            InitializeComponent();

            TitleLabel.Text = Title;
            MessageLabel.Text = Message;
            IconLabel.Image = UnityResource.ResourceManager.GetObject(IconType.ToString()) as Image;
        }

        private void LeonMessageBox_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            TitleLabel.MouseDown += new MouseEventHandler( UnityModule.MoveFormViaMouse);
        }

        private void LeonMessageBox_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                try
                {
                    this.Icon = this.Owner.Icon;
                    this.Font = this.Owner.Font;
                    this.BackgroundImage = Owner.BackgroundImage;
                }
                catch
                { }
            }
            else
            {
                try
                {
                    this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                }
                catch
                { }
            }
        }

        private void LeonMessageBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLines(borderPen,
                new Point[]
                {
                    new Point(0,0),
                    new Point(this.Width-1,0),
                    new Point(this.Width-1,this.Height-1),
                    new Point(0,this.Height-1),
                    new Point(0,0)
                }
            );
        }

    }
}
