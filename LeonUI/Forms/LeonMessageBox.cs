using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonUI.Forms
{
    public partial class LeonMessageBox : Form
    {
        //TIPS: Form.KeyPreview=True 即可让窗体捕捉所有键盘事件，而不是控件

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
            CheckForIllegalCrossThreadCalls = false;
            this.StartPosition = (Owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent);

            Text = Title;
            TitleLabel.Text = Title;
            MessageLabel.Text = Message;
            IconLabel.Image = UnityResource.ResourceManager.GetObject(IconType.ToString()) as Image;

            if (IconType == IconType.Question)
            {
                CancelButton.Show();
                CancelButton.Left = 80;
                OKButton.Left = 196;
            }
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
            e.Graphics.DrawRectangle(Pens.DeepSkyBlue, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                while (this.Opacity > 0)
                {
                    this.Top -= 1;
                    this.Opacity -= 0.1;
                    Thread.Sleep(15);
                }
                this.DialogResult = DialogResult.Cancel;
            })).Start();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                while (this.Opacity > 0)
                {
                    this.Top -= 1;
                    this.Opacity -= 0.1;
                    Thread.Sleep(15);
                }
                this.DialogResult = DialogResult.OK;
            })).Start();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                while (this.Opacity > 0)
                {
                    this.Top -= 1;
                    this.Opacity -= 0.1;
                    Thread.Sleep(15);
                }
                this.DialogResult = DialogResult.Cancel;
            })).Start();
        }

        private void LeonMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None) this.DialogResult = DialogResult.Cancel;
        }

        private void LeonMessageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 27)
            {
                new Thread(new ThreadStart(delegate
                {
                    while (this.Opacity > 0)
                    {
                        this.Top -= 1;
                        this.Opacity -= 0.1;
                        Thread.Sleep(15);
                    }
                    if ((int)e.KeyChar == 13)
                        this.DialogResult = DialogResult.OK;
                    else if ((int)e.KeyChar == 27)
                        this.DialogResult = DialogResult.Cancel;
                })).Start();
            }
        }

    }
}
