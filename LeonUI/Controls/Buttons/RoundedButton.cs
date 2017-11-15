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
    public partial class RoundedButton : ImageButton
    {
        protected new Bitmap normalBitmap = UnityResource.DefaultButton_0;
        protected new Bitmap enterBitmap = UnityResource.DefaultButton_1;
        protected new Bitmap downBitmap = UnityResource.DefaultButton_2;
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

                BitmapProcessor.RenderBGI(normalBitmap,this.Size,value,ref renderedNormalBitmap);
                BitmapProcessor.RenderBGI(normalBitmap, this.Size, value, ref renderedEnterBitmap);
                BitmapProcessor.RenderBGI(normalBitmap, this.Size, value, ref renderedDownBitmap);

                this.Image = renderedNormalBitmap;
            }
        }

        /// <summary>
        /// 按钮默认图片
        /// </summary>
        public new Bitmap NormalBitmap
        {
            get => normalBitmap;
            set {
                normalBitmap?.Dispose();
                renderedNormalBitmap?.Dispose();
                normalBitmap = value;
                BitmapProcessor.RenderBGI(value, this.Size, centerRectangle, ref renderedNormalBitmap);
                Image = renderedNormalBitmap;
            }
        }

        /// <summary>
        /// 按钮鼠标进入图片
        /// </summary>
        public new Bitmap EnterBitmap
        {
            get => enterBitmap;
            set
            {
                enterBitmap?.Dispose();
                renderedEnterBitmap?.Dispose();
                enterBitmap = value;
                BitmapProcessor.RenderBGI(value, this.Size, centerRectangle, ref renderedEnterBitmap);
            }
        }

        /// <summary>
        /// 按钮鼠标按下图片
        /// </summary>
        public new Bitmap DownBitmap
        {
            get => downBitmap;
            set
            {
                downBitmap?.Dispose();
                renderedDownBitmap?.Dispose();
                downBitmap = value;
                BitmapProcessor.RenderBGI(value, this.Size, centerRectangle, ref renderedDownBitmap);
            }
        }

        public RoundedButton()
        {
            InitializeComponent();
            
            this.Image = renderedNormalBitmap;

            BindingEvents();
        }

        protected new void BindingEvents()
        {
            Resize += new EventHandler((s, e) => {
                BitmapProcessor.RenderBGI(normalBitmap, this.Size, centerRectangle, ref renderedNormalBitmap);
                BitmapProcessor.RenderBGI(normalBitmap, this.Size, centerRectangle, ref renderedEnterBitmap);
                BitmapProcessor.RenderBGI(normalBitmap, this.Size, centerRectangle, ref renderedDownBitmap);
                
                this.Image = renderedNormalBitmap;
                Invalidate();
            });
            MouseEnter += new EventHandler((s, e) => { Image = renderedEnterBitmap; Invalidate(); });
            MouseDown += new MouseEventHandler((s, e) => { Image = renderedDownBitmap; Invalidate(); });
            MouseUp += new MouseEventHandler((s, e) => { Image = renderedEnterBitmap; Invalidate(); });
            MouseLeave += new EventHandler((s, e) => { Image = renderedNormalBitmap; Invalidate(); });
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }
    }
}
