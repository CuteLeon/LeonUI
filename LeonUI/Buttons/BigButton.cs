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
    public partial class BigButton : Label
    {

        public BigButton()
        {
            InitializeComponent();

            this.AutoEllipsis = true;
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;
            this.Image = UnityResource.BigButton_0;
            this.MaximumSize = UnityResource.BigButton_0.Size;
            this.MinimumSize = MaximumSize;

            MouseEnter += new EventHandler((s,e)=> { Image = UnityResource.BigButton_1; Invalidate();});
            MouseDown += new MouseEventHandler((s,e)=> { Image = UnityResource.BigButton_2; Invalidate();});
            MouseUp += new MouseEventHandler((s,e)=> { Image = UnityResource.BigButton_1; Invalidate();});
            MouseLeave += new EventHandler((s,e)=> { Image = UnityResource.BigButton_0; Invalidate();});
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
        }

    }
}