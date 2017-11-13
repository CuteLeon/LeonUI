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
    public partial class ImageBitmap : Label
    {
        
        private string bitmapResourceName="";
        /// <summary>
        /// 按钮动态图片资源的前缀名称
        /// </summary>
        public string BitmapResourceName
        {
            get => bitmapResourceName;
            set {
                //防止无意义劳动
                if (bitmapResourceName == value) return;

                //释放引用不为空的图像资源
                if (NormalBitmap != null) NormalBitmap.Dispose();
                if (EnterBitmap != null) EnterBitmap.Dispose();
                if (DownBitmap != null) DownBitmap.Dispose();

                //引用新图像资源
                bitmapResourceName = value;
                NormalBitmap = (Bitmap)UnityResource.ResourceManager.GetObject(bitmapResourceName+ "_0");
                EnterBitmap = (Bitmap)UnityResource.ResourceManager.GetObject(bitmapResourceName + "_1");
                DownBitmap = (Bitmap)UnityResource.ResourceManager.GetObject(bitmapResourceName + "_2");

                //初始化显示与大小
                if (NormalBitmap != null)
                {
                    Image = NormalBitmap;
                    Size = NormalBitmap.Size;
                }
            }
        }

        /// <summary>
        /// 按钮默认图片
        /// </summary>
        private Bitmap NormalBitmap = null;
        /// <summary>
        /// 按钮鼠标进入图片
        /// </summary>
        private Bitmap EnterBitmap = null;
        /// <summary>
        /// 按钮鼠标按下图片
        /// </summary>
        private Bitmap DownBitmap = null;

        public ImageBitmap()
        {
            InitializeComponent();

            this.AutoEllipsis = true;
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.AutoSize = false;
            this.ForeColor = Color.White;

            MouseEnter += new EventHandler((s,e)=> { Image = EnterBitmap; Invalidate();});
            MouseDown += new MouseEventHandler((s,e)=> { Image = DownBitmap; Invalidate();});
            MouseUp += new MouseEventHandler((s,e)=> { Image = EnterBitmap; Invalidate();});
            MouseLeave += new EventHandler((s,e)=> { Image = NormalBitmap; Invalidate();});
        }

    }
}
