using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LeonUI.Forms
{
    public partial class ProgressForm : Form
    {
        private bool _allowToClose = false;
        private bool _allowToCancel = false;
        private Thread _workThread;
        public Action WorkAction
        {
            set
            {
                _workThread = new Thread(new ThreadStart(delegate () {
                    value();
                    _allowToClose = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }));
            }
        }

        protected ProgressForm()
        {
            InitializeComponent();
        }

        public new void Close()
        {
            _allowToClose = true;
            base.Close();
        }

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

        public ProgressForm(string Title, string Message, bool AllowToCancel, params object[] MessageValues) :
            this(Title, string.Format(Message, MessageValues), AllowToCancel) { }

        public ProgressForm(string Title, string Message,bool AllowToCancel, Action workAction, params object[] MessageValues) :
            this(Title, string.Format(Message,MessageValues), AllowToCancel, workAction){ }

        public ProgressForm(string Title, string Message, bool AllowToCancel, Action workAction) :
            this(Title, Message, AllowToCancel)
        {
            WorkAction = workAction;
        }

        public ProgressForm(string Title, string Message, bool AllowToCancel)
        {
            InitializeComponent();

            if (!DesignMode)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.StartPosition = (Owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent);
            }

            Text = Title;
            TitleLabel.Text = Title;
            MessageLabel.Text = Message;
            _allowToCancel = AllowToCancel;

            if (AllowToCancel)
            {
                CloseButton.Show();
                CancelButton.Show();
            }
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                this.DoubleBuffered = true;
                this.AutoScaleMode = AutoScaleMode.Dpi;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                TitleLabel.MouseDown += new MouseEventHandler(UnityModule.MoveFormViaMouse);
            }
        }

        private void ProgressForm_Shown(object sender, EventArgs e)
        {
            if (!DesignMode)
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
                if (_workThread != null)
                {
                    _workThread.Start();
                    ProgressTimer.Start();
                }
                else
                {
                    _allowToClose = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void ProgressForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DeepSkyBlue, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;
            _allowToClose = true;
            _workThread?.Abort();
            ProgressTimer.Stop();
            new Thread(new ThreadStart(delegate
            {
                while (this.Opacity > 0)
                {
                    this.Top -= 1;
                    this.Opacity -= 0.1;
                    Thread.Sleep(15);
                }
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            })).Start();
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (! (_allowToCancel || _allowToClose))
            {
                e.Cancel = true; return;
            }
            if (_workThread.ThreadState == ThreadState.WaitSleepJoin || _workThread.ThreadState == ThreadState.Running) _workThread.Abort();
            if (this.DialogResult == DialogResult.None) this.DialogResult = DialogResult.Cancel;
        }

        int ImageIndex = 0;
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            IconLabel.Image = UnityResource.ResourceManager.GetObject("Ring_"+ ImageIndex.ToString()) as Image;
            ImageIndex = (ImageIndex + 1) % 20;
        }

    }
}
