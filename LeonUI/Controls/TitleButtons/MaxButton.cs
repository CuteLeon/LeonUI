using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonUI.TitleButtons
{
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public partial class MaxButton : UserControl
    {
        public MaxButton()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            BackgroundImageLayout = ImageLayout.Center;
            BackgroundImage = UnityResource.Max_0;
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            MinimumSize = UnityResource.Max_0.Size;

            this.MouseEnter += new EventHandler((s,e)=>BackgroundImage=UnityResource.Max_1);
            this.MouseDown += new MouseEventHandler((s, e) => BackgroundImage = UnityResource.Max_2);
            this.MouseUp += new MouseEventHandler((s, e) => BackgroundImage = UnityResource.Max_1);
            this.MouseLeave += new EventHandler((s, e) => BackgroundImage = UnityResource.Max_0);

            this.Click += new EventHandler((s,e)=>FindForm().WindowState= FormWindowState.Maximized);
        }

    }
}
