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
        public LeonMessageBox()
        {
            InitializeComponent();
        }

        private void LeonMessageBox_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackgroundImageLayout = ImageLayout.Stretch;
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
    }
}
