using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeonUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace LeonUI.Forms.Tests
{
    [TestClass()]
    public class LeonMessageBoxTests
    {
        [TestMethod()]
        public void LeonMessageBoxTest()
        {
            LeonMessageBox leonMessageBox = new LeonMessageBox("123", "456", LeonMessageBox.IconType.Question) ;
            leonMessageBox.ShowDialog(
                new Form()
                {
                    Icon = Icon.FromHandle((Bitmap.FromFile(@"D:\MyPictures\FUI\_0008_19.jpg.jpg_I_R.jpg") as Bitmap).GetHicon()),
                    BackgroundImage = Bitmap.FromFile(@"D:\MyPictures\DesktopBackground\gamersky_03origin_05_20171014155457C.jpg")
                }
            );
        }

    }
}