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
    public partial class CloseButton : UserControl
    {
        public CloseButton()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            BackgroundImageLayout = ImageLayout.Center;
            BackgroundImage = UnityResource.Close_0;
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            MinimumSize = UnityResource.Close_0.Size;

            this.MouseEnter += new EventHandler((s,e)=>BackgroundImage=UnityResource.Close_1);
            this.MouseDown += new MouseEventHandler((s, e) => BackgroundImage = UnityResource.Close_2);
            this.MouseUp += new MouseEventHandler((s, e) => BackgroundImage = UnityResource.Close_1);
            this.MouseLeave += new EventHandler((s, e) => BackgroundImage = UnityResource.Close_0);

            //如果宿主窗体需要在关闭前弹出提示窗口，只需要在宿主窗体的Form_Closing(s,e)事件里Cancel=true;处理即可
            this.Click += new EventHandler((s,e)=>FindForm()?.Close());
        }
    }
}
