﻿using System;
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
    public partial class ImageButton : Label
    {
        private Bitmap normalBitmap = null;
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

        private Bitmap enterBitmap = null;
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

        private Bitmap downBitmap = null;
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

            this.AutoEllipsis = true;
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;

            MouseEnter += new EventHandler((s,e)=> { Image = EnterBitmap; Invalidate();});
            MouseDown += new MouseEventHandler((s,e)=> { Image = DownBitmap; Invalidate();});
            MouseUp += new MouseEventHandler((s,e)=> { Image = EnterBitmap; Invalidate();});
            MouseLeave += new EventHandler((s,e)=> { Image = NormalBitmap; Invalidate();});
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }
    }
}