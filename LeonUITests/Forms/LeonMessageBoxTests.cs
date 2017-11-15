using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeonUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace LeonUI.Forms.Tests
{
    [TestClass()]
    public class LeonMessageBoxTests
    {
        [TestMethod()]
        [STAThread]
        public void LeonMessageBoxTest()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form HostForm = new Form()
            {
                Icon = Icon.FromHandle((Bitmap.FromFile(@"D:\MyPictures\FUI\_0008_19.jpg.jpg_I_R.jpg") as Bitmap).GetHicon()),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = Bitmap.FromFile(@"D:\MyPictures\DesktopBackground\gamersky_03origin_05_20171014155457C.jpg")
            };
            HostForm.Shown += new EventHandler((s, e) =>
            {
                HostForm.Activate();
                new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(1000);
                    HostForm.Invoke(new Action(()=> {
                        LeonMessageBox leonMessageBox = new LeonMessageBox("123", "456", LeonMessageBox.IconType.Info);
                        Debug.Print(leonMessageBox.ShowDialog(HostForm).ToString());
                    }));
                })).Start();
            });

            Application.Run(HostForm);
        }

    }
}