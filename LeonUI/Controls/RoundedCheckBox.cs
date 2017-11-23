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
    [ToolboxBitmap(typeof(CheckBox))]
    public partial class RoundedCheckBox : UserControl
    {
        public event EventHandler CheckedChanged;

        private bool MouseIn = false;
        private bool checkedValue = false;
        public bool Checked
        {
            get => checkedValue;
            set
            {
                if (checkedValue == value) return;

                checkedValue = value;
                this.BackgroundImage = UnityResource.ResourceManager.GetObject(string.Format("CheckBox_{0}_{1}",(value?"On":"Off"),(MouseIn? "1":"0"))) as Image;
                
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public RoundedCheckBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

        private void RoundedCheckBox_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = UnityResource.CheckBox_Off_0;
        }

        private void RoundedCheckBox_MouseEnter(object sender, EventArgs e)
        {
            MouseIn = true;
            this.BackgroundImage = UnityResource.ResourceManager.GetObject(string.Format("CheckBox_{0}_1", (checkedValue ? "On" : "Off"))) as Image;
        }

        private void RoundedCheckBox_MouseLeave(object sender, EventArgs e)
        {
            MouseIn = false;
            this.BackgroundImage = UnityResource.ResourceManager.GetObject(string.Format("CheckBox_{0}_0", (checkedValue ? "On" : "Off"))) as Image;
        }

        private void RoundedCheckBox_Click(object sender, EventArgs e)
        {
            Checked = !Checked;
        }

    }
}
