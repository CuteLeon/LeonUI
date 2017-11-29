using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeonUI.Controls
{
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public partial class TabButton : Label
    {

        public static EventHandler TabChanged;
        
        private static TabButton activatedButton = null;
        /// <summary>
        /// 当前按钮组激活按钮
        /// </summary>
        public static TabButton ActivatedButton
        {
            get => activatedButton;
            set
            {
                if (activatedButton == value) return;
                if (activatedButton != null)
                {
                    activatedButton.DrawBorder = false;
                    activatedButton.BackColor = normalColor;
                    activatedButton.ForeColor = NormalForeColor;
                    activatedButton.Font = new Font(activatedButton.Font,FontStyle.Regular);
                    activatedButton.OnPaint(new PaintEventArgs(activatedButton.CreateGraphics(),activatedButton.ClientRectangle));
                }
                if (value != null)
                {
                    activatedButton = value;
                    value.ForeColor = ActiveColor;
                    value.Font = new Font(activatedButton.Font, FontStyle.Bold);
                    value.DrawBorder = true;
                    value.OnPaint(new PaintEventArgs(activatedButton.CreateGraphics(), activatedButton.ClientRectangle));
                    TabChanged?.Invoke(value,new EventArgs());
                }
            }
        }
        /// <summary>
        /// 按钮指向的容器
        /// </summary>
        public Panel TargetPanel = null;

        private static Color normalColor = Color.Transparent;
        /// <summary>
        /// 按钮默认颜色
        /// </summary>
        public static Color NormalColor
        {
            get => normalColor;
            set
            {
                normalColor = value;
            }
        }

        private static Color enterColor = Color.FromArgb(50, Color.White);
        /// <summary>
        /// 按钮鼠标进入颜色
        /// </summary>
        public static Color EnterColor
        {
            get => enterColor;
            set => enterColor = value;
        }

        private static Color downColor = Color.FromArgb(100, Color.White);
        /// <summary>
        /// 按钮鼠标按下颜色
        /// </summary>
        public static Color DownColor
        {
            get => downColor;
            set => downColor = value;
        }

        private static Pen borderPen = new Pen(Color.DeepSkyBlue, 4);
        /// <summary>
        /// 激活主题颜色
        /// </summary>
        public static Color ActiveColor
        {
            get => borderPen.Color;
            set => borderPen.Color = value;
        }

        private static Color normalForeColor = Color.White;
        /// <summary>
        /// 正常字体颜色
        /// </summary>
        public static Color NormalForeColor
        {
            get => normalForeColor;
            set => normalForeColor = value;
        }

        /// <summary>
        /// 是否绘制边框
        /// </summary>
        private bool DrawBorder = false;

        public TabButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            
            base.AutoSize = false;
            this.AutoEllipsis = true;
            this.BackColor = NormalColor;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = NormalForeColor;

            Click += new EventHandler((s,e)=> 
            {
                ActivatedButton = this;
            });
            MouseEnter += new EventHandler((s, e) => 
            {
                if (ActivatedButton == this) return;
                BackColor = EnterColor;
                Invalidate();
            });
            MouseDown += new MouseEventHandler((s, e) => 
            {
                if (ActivatedButton == this) return;
                BackColor = DownColor;
                Invalidate();
            });
            MouseUp += new MouseEventHandler((s, e) =>
            {
                if (ActivatedButton == this) return;
                BackColor = EnterColor;
                Invalidate();
            });
            MouseLeave += new EventHandler((s, e) => 
            {
                if (ActivatedButton == this) return;
                BackColor = NormalColor;
                Invalidate();
            });
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }

        private void TabButton_Paint(object sender, PaintEventArgs e)
        {
            if (DrawBorder)
            {
                e.Graphics.DrawLine( borderPen, 2, 0, 2, this.Height);
            }
        }

    }
}
