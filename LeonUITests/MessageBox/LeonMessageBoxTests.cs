using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeonUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using LeonUI.Forms;
using LeonUI.Controls;

namespace LeonUI.Tests
{
    [TestClass()]
    public class LeonMessageBoxTests
    {
        [TestMethod()]
        public void LeonMessageBoxTest()
        {
            LeonMessageBox leonMessageBox = new LeonMessageBox();
            leonMessageBox.ShowDialog(
                new Form() {
                    Icon = Icon.FromHandle((Bitmap.FromFile(@"D:\MyPictures\FUI\_0008_19.jpg.jpg_I_R.jpg") as Bitmap).GetHicon()),
                    BackgroundImage = Bitmap.FromFile(@"D:\MyPictures\DesktopBackground\Cloud.jpg")
                }
            );
        }
    }
}