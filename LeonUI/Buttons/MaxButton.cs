using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LeonUI.Controls;

namespace LeonUI.Controls
{
    public class MaxButton:ImageButton
    {
        public MaxButton()
        {
            NormalBitmap = UnityResource.Max_0;
            EnterBitmap = UnityResource.Max_1;
            DownBitmap = UnityResource.Max_2;
            this.Click += new EventHandler((s,e)=> this.FindForm().WindowState = System.Windows.Forms.FormWindowState.Maximized);
        }

    }
}
