using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonUI.Controls
{
    [DefaultEvent("Click")]
    public partial class FlatButton : Label
    {
        private Color normalColor = Color.Transparent;
        /// <summary>
        /// 按钮默认颜色
        /// </summary>
        public Color NormalColor
        {
            get => normalColor;
            set
            {
                normalColor = value;
                BackColor = value;
            }
        }

        private Color enterColor = Color.FromArgb(50, Color.White);
        /// <summary>
        /// 按钮鼠标进入颜色
        /// </summary>
        public Color EnterColor
        {
            get => enterColor;
            set => enterColor = value;
        }

        private Color downColor = Color.FromArgb(100, Color.White);
        /// <summary>
        /// 按钮鼠标按下颜色
        /// </summary>
        public Color DownColor
        {
            get => downColor;
            set => downColor = value;
        }

        public FlatButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            base.AutoSize = false;
            this.AutoEllipsis = true;
            this.BackColor = NormalColor;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;

            MouseEnter += new EventHandler((s, e) => { BackColor = EnterColor; Invalidate(); });
            MouseDown += new MouseEventHandler((s, e) => { BackColor = DownColor; Invalidate(); });
            MouseUp += new MouseEventHandler((s, e) => { BackColor = EnterColor; Invalidate(); });
            MouseLeave += new EventHandler((s, e) => { BackColor = NormalColor; Invalidate(); });
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }
    }
}
