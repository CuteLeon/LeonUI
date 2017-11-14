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
    public partial class RoundedButton : Label
    {
        private Bitmap normalBitmap = UnityResource.DefaultButton_0;
        private Bitmap enterBitmap = UnityResource.DefaultButton_1;
        private Bitmap downBitmap = UnityResource.DefaultButton_2;
        private Rectangle centerRectangle = new Rectangle(17,16,70,2);
        private Bitmap renderedNormalBitmap = UnityResource.DefaultButton_0;
        private Bitmap renderedEnterBitmap = UnityResource.DefaultButton_1;
        private Bitmap renderedDownBitmap = UnityResource.DefaultButton_2;

        //切图中心区域
        public Rectangle CenterRectangle
        {
            get => centerRectangle;
            set
            {
                centerRectangle = value;

                renderedNormalBitmap = BitmapProcessor.RenderBGI(normalBitmap,this.Size,value);
                renderedEnterBitmap = BitmapProcessor.RenderBGI(enterBitmap, this.Size, value);
                renderedDownBitmap = BitmapProcessor.RenderBGI(downBitmap, this.Size, value);

                this.Image = renderedNormalBitmap;
            }
        }

        /// <summary>
        /// 按钮默认图片
        /// </summary>
        public Bitmap NormalBitmap
        {
            get => normalBitmap;
            set {
                normalBitmap?.Dispose();
                renderedNormalBitmap?.Dispose();
                normalBitmap = value;
                renderedNormalBitmap = BitmapProcessor.RenderBGI(value, this.Size, centerRectangle);
                Image = renderedNormalBitmap;
            }
        }

        /// <summary>
        /// 按钮鼠标进入图片
        /// </summary>
        public Bitmap EnterBitmap
        {
            get => enterBitmap;
            set
            {
                enterBitmap?.Dispose();
                renderedEnterBitmap?.Dispose();
                enterBitmap = value;
                renderedEnterBitmap = BitmapProcessor.RenderBGI(value, this.Size, centerRectangle);
            }
        }

        /// <summary>
        /// 按钮鼠标按下图片
        /// </summary>
        public Bitmap DownBitmap
        {
            get => downBitmap;
            set
            {
                downBitmap?.Dispose();
                renderedDownBitmap?.Dispose();
                downBitmap = value;
                renderedDownBitmap = BitmapProcessor.RenderBGI(value, this.Size, centerRectangle);
            }
        }

        public RoundedButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            this.AutoEllipsis = true;
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;
            this.Image = renderedNormalBitmap;

            Resize += new EventHandler((s,e)=> {
                renderedNormalBitmap = BitmapProcessor.RenderBGI(normalBitmap, this.Size, centerRectangle);
                renderedEnterBitmap = BitmapProcessor.RenderBGI(enterBitmap, this.Size, centerRectangle);
                renderedDownBitmap = BitmapProcessor.RenderBGI(downBitmap, this.Size, centerRectangle);
                this.Image = renderedNormalBitmap;
                Invalidate();
            });
            MouseEnter += new EventHandler((s,e)=> { Image = renderedEnterBitmap; Invalidate();});
            MouseDown += new MouseEventHandler((s,e)=> { Image = renderedDownBitmap; Invalidate();});
            MouseUp += new MouseEventHandler((s,e)=> { Image = renderedEnterBitmap; Invalidate();});
            MouseLeave += new EventHandler((s,e)=> { Image = renderedNormalBitmap; Invalidate();});
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }
    }
}
