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
            HostForm.Click += new EventHandler((s, e) =>
            {
                new Thread(new ThreadStart(() =>
                {
                    //Thread.Sleep(1000);
                    HostForm.Invoke(new Action(()=> {
                        ProgressForm progressForm = new ProgressForm("123", "234", true, new Action(() => { Thread.Sleep(1000000); }));
                        //ProgressForm progressForm = new ProgressForm("123", "234", false, new Action(() => { Thread.Sleep(1000); }));
                        //ProgressForm progressForm = new ProgressForm("123", "234", false, null as Action);
                        //ProgressForm progressForm = new ProgressForm("123", "234 {0}", true, "123");
                        progressForm.ShowDialog(HostForm);
                        MessageBox.Show(progressForm.DialogResult.ToString());
                        /*
                        LeonMessageBox leonMessageBox = new LeonMessageBox("123", "456", LeonMessageBox.IconType.Question);
                        leonMessageBox.ShowDialog(HostForm);
                        MessageBox.Show(leonMessageBox.DialogResult.ToString());
                         */
                    }));
                })).Start();
            });

            Application.Run(HostForm);
        }

    }
}