using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void largeButton1_Click(object sender, EventArgs e)
        {
            new LeonUI.Forms.LeonMessageBox("123", "456", LeonUI.Forms.LeonMessageBox.IconType.Question).Show(this);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            new LeonUI.Forms.ProgressForm("123", "456", true, new Action(() => { Thread.Sleep(100000); })).ShowDialog(this);
        }
    }
}
