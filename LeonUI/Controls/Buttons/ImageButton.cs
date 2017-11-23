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
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public partial class ImageButton : Label
    {
        protected Bitmap normalBitmap = null;
        /// <summary>
        /// 按钮默认图片
        /// </summary>
        public Bitmap NormalBitmap
        {
            get => normalBitmap;
            set {
                normalBitmap?.Dispose();
                normalBitmap = value;
                Image = value;
            }
        }

        protected Bitmap enterBitmap = null;
        /// <summary>
        /// 按钮鼠标进入图片
        /// </summary>
        public Bitmap EnterBitmap
        {
            get => enterBitmap;
            set
            {
                enterBitmap?.Dispose();
                enterBitmap = value;
            }
        }

        protected Bitmap downBitmap = null;
        /// <summary>
        /// 按钮鼠标按下图片
        /// </summary>
        public Bitmap DownBitmap
        {
            get => downBitmap;
            set
            {
                downBitmap?.Dispose();
                downBitmap = value;
            }
        }

        public ImageButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            this.AutoEllipsis = true;
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;

            BindingEvents();
        }

        protected void BindingEvents()
        {
            MouseEnter += new EventHandler((s, e) => { Image = EnterBitmap; Invalidate(); });
            MouseDown += new MouseEventHandler((s, e) => { Image = DownBitmap; Invalidate(); });
            MouseUp += new MouseEventHandler((s, e) => { Image = EnterBitmap; Invalidate(); });
            MouseLeave += new EventHandler((s, e) => { Image = NormalBitmap; Invalidate(); });
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }
    }
}
