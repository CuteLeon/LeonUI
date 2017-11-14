using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeonUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace LeonUI.Tests
{
    [TestClass()]
    public class BitmapProcessorTests
    {
        [TestMethod()]
        public void RenderBGITest()
        {
            Bitmap TestBitmap;
            Size TestSize;
            Rectangle CenterRectangle;

            TestBitmap = Bitmap.FromFile(@"D:\CSharp\LeonUI\LeonUI\Resources\DefaultButton_1.png") as Bitmap;
            CenterRectangle = new Rectangle(17, 16, 70, 2);

            TestSize = TestBitmap.Size;

            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 4, TestSize.Height / 4), CenterRectangle).Save(@"D:\1.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 2, TestSize.Height / 2), CenterRectangle).Save(@"D:\2.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width, TestSize.Height), CenterRectangle).Save(@"D:\3.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 2, TestSize.Height * 2), CenterRectangle).Save(@"D:\4.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 4, TestSize.Height * 4), CenterRectangle).Save(@"D:\5.PNG", ImageFormat.Png);

            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 4, TestSize.Height/4), CenterRectangle).Save(@"D:\6.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 2, TestSize.Height/4), CenterRectangle).Save(@"D:\7.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 2, TestSize.Height/4), CenterRectangle).Save(@"D:\8.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 4, TestSize.Height/4), CenterRectangle).Save(@"D:\9.PNG", ImageFormat.Png);

            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 4, TestSize.Height / 2), CenterRectangle).Save(@"D:\10.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 2, TestSize.Height / 2), CenterRectangle).Save(@"D:\11.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 2, TestSize.Height / 2), CenterRectangle).Save(@"D:\12.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 4, TestSize.Height / 2), CenterRectangle).Save(@"D:\13.PNG", ImageFormat.Png);

            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 4, TestSize.Height), CenterRectangle).Save(@"D:\14.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 2, TestSize.Height), CenterRectangle).Save(@"D:15.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 2, TestSize.Height), CenterRectangle).Save(@"D:\16.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 4, TestSize.Height), CenterRectangle).Save(@"D:\17.PNG", ImageFormat.Png);

            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 4, TestSize.Height * 2), CenterRectangle).Save(@"D:\18.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 2, TestSize.Height * 2), CenterRectangle).Save(@"D:\19.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 2, TestSize.Height * 2), CenterRectangle).Save(@"D:\20.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 4, TestSize.Height * 2), CenterRectangle).Save(@"D:\21.PNG", ImageFormat.Png);

            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 4, TestSize.Height * 4), CenterRectangle).Save(@"D:\22.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width / 2, TestSize.Height * 4), CenterRectangle).Save(@"D:\23.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 2, TestSize.Height * 4), CenterRectangle).Save(@"D:\24.PNG", ImageFormat.Png);
            BitmapProcessor.RenderBGI(TestBitmap, new Size(TestSize.Width * 4, TestSize.Height * 4), CenterRectangle).Save(@"D:\25.PNG", ImageFormat.Png);
        }

    }
}