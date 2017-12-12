using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeonUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonUI.Controls.Tests
{
    [TestClass()]
    public class RoundedTextBoxTests
    {
        [TestMethod()]
        public void RoundedTextBoxTest()
        {
            Form form = new Form();
            form.Controls.Add(new RoundedTextBox() { Location=new System.Drawing.Point(0,0)});
            form.ShowDialog();
        }
    }
}