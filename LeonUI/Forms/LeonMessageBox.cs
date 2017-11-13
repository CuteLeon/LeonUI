using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonUI.Forms
{
    public partial class LeonMessageBox : Form
    {
        private Pen borderPen = new Pen(Color.DeepSkyBlue);
        /// <summary>
        /// 弹窗边框颜色
        /// </summary>
        public Color BorderColor
        {
            get => borderPen.Color;
            set
            {
                borderPen.Color = value;
                this.Invalidate();
            }
        }

        public LeonMessageBox()
        {
            InitializeComponent();
        }

        private void LeonMessageBox_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            TitleLabel.MouseDown += new MouseEventHandler( UnityModule.MoveFormViaMouse);
        }

        private void LeonMessageBox_Shown(object sender, EventArgs e)
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
                {}
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
        }

        private void LeonMessageBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLines(borderPen,
                new Point[]
                {
                    new Point(0,0),
                    new Point(this.Width-1,0),
                    new Point(this.Width-1,this.Height-1),
                    new Point(0,this.Height-1),
                    new Point(0,0)
                }
            );
        }

    }
}
