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
    public partial class NoBorderSizableForm : Form
    {
        private Pen themePen = new Pen(Color.FromArgb(245, 200, 200, 200), 2);
        private SolidBrush themeBrush = new SolidBrush(Color.FromArgb(245, 200, 200, 200));
        public Color ThemeColor
        {
            get => themePen.Color;
            set
            {
                themeBrush.Color = value;
                themePen.Color = value;
                this.Invalidate();
            }
        }

        public Font TitleFont
        {
            get => TitleLabel.Font;
            set => TitleLabel.Font = value;
        }

        public new bool MinimizeBox => MinButton.Visible;
        public new bool MaximizeBox
        {
            get => MaxButton.Visible || RestoreButton.Visible;
            set
            {
                MaxButton.Visible = value && WindowState == FormWindowState.Normal;
                RestoreButton.Visible = value && WindowState == FormWindowState.Maximized;
            }
        }

        public NoBorderSizableForm()
        {
            InitializeComponent();
        }

        public new string Text
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        public Color TitleForeColor
        {
            get => TitleLabel.ForeColor;
            set => TitleLabel.ForeColor = value;
        }

        public new Icon Icon
        {
            get => this.Icon;
            set
            {
                this.Icon = value;
                IconLabel.Image = value.ToBitmap();
            }
        }

        public string CloseTitle = "确定要关闭吗？";
        public string CloseMessage = "您确定要关闭窗口吗？";
        public bool ShowMessageBeforeClose = false;
        private bool AllowToClose = false;

        public ContentAlignment TitleAglin
        {
            get => TitleLabel.TextAlign;
            set => TitleLabel.TextAlign = value;
        }

        private void NoBorderSizableForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //CheckForIllegalCrossThreadCalls = false;
                TitleLabel.MouseDown += new MouseEventHandler(UnityModule.MoveFormViaMouse);
                IconLabel.MouseDown += new MouseEventHandler(UnityModule.MoveFormViaMouse);
            }
        }

        [Browsable(false)]
        public new bool ControlBox
        {
            get
            {
                return false;
            }
            set
            {
                base.ControlBox = false;
            }
        }


        //为窗体添加阴影
        protected override CreateParams CreateParams
        {
            get
            {
                if (!DesignMode)
                {
                    CreateParams baseParams = base.CreateParams;
                    baseParams.ClassStyle |= 131072;
                    baseParams.ExStyle |= 33554432;
                    return baseParams;
                }
                else
                {
                    return base.CreateParams;
                }
            }
        }

        //鼠标拖动边框
        protected override void WndProc(ref Message Msg)
        {
            if (DesignMode)
            {
                base.WndProc(ref Msg);
                return;
            }

            switch (Msg.Msg)
            {
                case UnityModule.WM_NCCALCSIZE:
                    {

                        break;
                    }
                case UnityModule.WM_NCHITTEST:
                    {
                        if (this.WindowState == FormWindowState.Maximized) return;

                        // 获取鼠标位置
                        int nPosX = (Msg.LParam.ToInt32() & 65535);
                        int nPosY = (Msg.LParam.ToInt32() >> 16);

                        if (nPosX >= this.Right - 5 && nPosY >= this.Bottom - 5)
                        {
                            //右下角
                            Msg.Result = new IntPtr(UnityModule.HT_BOTTOMRIGHT);
                        }
                        else if (nPosX <= this.Left + 5 && nPosY <= this.Top + 5)
                        {
                            //左上角
                            Msg.Result = new IntPtr(UnityModule.HT_TOPLEFT);
                        }
                        else if (nPosX <= this.Left + 5 && nPosY >= this.Bottom - 5)
                        {
                            //左下角
                            Msg.Result = new IntPtr(UnityModule.HT_BOTTOMLEFT);
                        }
                        else if (nPosX >= this.Right - 5 && nPosY <= this.Top + 5)
                        {
                            //右上角
                            Msg.Result = new IntPtr(UnityModule.HT_TOPRIGHT);
                        }
                        else if (nPosX >= this.Right - 5)
                        {
                            //右边框
                            Msg.Result = new IntPtr(UnityModule.HT_RIGHT);
                        }
                        else if (nPosY >= this.Bottom - 5)
                        {
                            //底边框
                            Msg.Result = new IntPtr(UnityModule.HT_BOTTOM);
                        }
                        else if (nPosX <= this.Left + 5)
                        {
                            //左边框
                            Msg.Result = new IntPtr(UnityModule.HT_LEFT);
                        }
                        else if (nPosY <= this.Top + 5)
                        {
                            //上边框
                            Msg.Result = new IntPtr(UnityModule.HT_TOP);
                        }
                        else
                        {
                            //其他区域返回拖动标题栏消息
                            Msg.Result = new IntPtr(UnityModule.HT_CAPTION);
                        }
                        break;
                    }
                default:
                    {
                        base.WndProc(ref Msg);
                        break;
                    }
            }
        }

        private void NoBorderSizableForm_Resize(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    {
                        if (MaximizeBox)
                        {
                            MaxButton.Hide();
                            RestoreButton.Show();
                        }
                        break;
                    }
                case FormWindowState.Minimized:
                    {
                        break;
                    }
                case FormWindowState.Normal:
                    {
                        if (MaximizeBox)
                        {
                            RestoreButton.Hide();
                            MaxButton.Show();
                        }
                        break;
                    }
            }
            this.Invalidate();
        }

        private void NoBorderSizableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ShowMessageBeforeClose) return;

            if (!AllowToClose)
            {
                e.Cancel = true;
                if (new LeonMessageBox(CloseTitle, CloseMessage, LeonMessageBox.IconType.Question).ShowDialog(this) == DialogResult.OK)
                {
                    AllowToClose = true;

                    new Thread(new ThreadStart(delegate
                    {
                        while (this.Opacity > 0)
                        {
                            this.Invoke(new Action(() => {
                                this.Top -= 1;
                                this.Opacity -= 0.1;
                            }));
                            Thread.Sleep(30);
                        }

                        this.Close();
                    })).Start();
                }
            }
        }

        private void NoBorderSizableForm_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode) return;
            e.Graphics.FillRectangle(themeBrush,new Rectangle(0,0,this.Width,TitlePanel.Bottom));

            if (this.WindowState == FormWindowState.Maximized) return;
            this.Invoke(new Action(()=> {
                e.Graphics.DrawRectangle(themePen,1,1,this.Width-2,this.Height-2);
            }));
        }

    }
}
