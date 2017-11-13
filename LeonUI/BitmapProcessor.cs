using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LeonUI
{
    static class BitmapProcessor
    {

        /// <summary>
        /// 使用九宫格切图拉伸背景图尺寸
        /// </summary>
        /// <param name="ResourceImage">背景资源图像</param>
        /// <param name="BorderSize">九宫格切图大小</param>
        /// <param name="TargetSize">背景图像目标尺寸</param>
        /// <returns>九宫格拉伸后的背景图像</returns>
        static public Bitmap ResizeBackgroundImage(Bitmap ResourceImage,Size BorderSize,Size TargetSize)
        {
            return new Bitmap(10,10);
        }
    }
}
