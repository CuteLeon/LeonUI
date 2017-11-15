using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace LeonUI
{
    static public class BitmapProcessor
    {

        /// <summary>
        /// 使用九宫格切图拉伸背景图像
        /// </summary>
        /// <param name="ResourceImage">背景资源图像</param>
        /// <param name="TargetSize">背景图像目标尺寸</param>
        /// <param name="CenterRectangle">九宫格切图中心块区域</param>
        /// <returns>九宫格拉伸后的背景图像</returns>
        static public void RenderBGI(Bitmap ResourceImage,Size TargetSize,Rectangle CenterRectangle,ref Bitmap TargetBGI)
        {
            try
            {
                TargetBGI?.Dispose();
                if (TargetSize.Equals(ResourceImage.Size))
                {
                    TargetBGI = ResourceImage.Clone() as Bitmap;
                    return;
                }
                else
                {
                    //左上角块尺寸
                    Size LTCellSize = new Size(CenterRectangle.Left, CenterRectangle.Top);
                    //右下角块尺寸
                    Size RBCellSize = new Size(ResourceImage.Width - CenterRectangle.Right, ResourceImage.Height - CenterRectangle.Bottom);

                    if ((TargetSize.Width >= LTCellSize.Width + RBCellSize.Width) && (TargetSize.Height >= LTCellSize.Height + RBCellSize.Height))//4
                    {
                        TargetBGI = new Bitmap(TargetSize.Width, TargetSize.Height);
                        //九宫格切分
                        using (Graphics TargetGraphics = Graphics.FromImage(TargetBGI))
                        {
                            //TargetGraphics.SmoothingMode = SmoothingMode.HighQuality;
                            //TargetGraphics.InterpolationMode = InterpolationMode.High;
                            //TargetGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                            //绘制左上角
                            TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(Point.Empty, LTCellSize), PixelFormat.Format32bppArgb), new Rectangle(Point.Empty, LTCellSize));
                            //绘制右上角
                            TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(CenterRectangle.Right, 0, RBCellSize.Width, LTCellSize.Height), PixelFormat.Format32bppArgb), new Rectangle(TargetSize.Width - RBCellSize.Width, 0, LTCellSize.Width, LTCellSize.Height));
                            //绘制左下角
                            TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(0, CenterRectangle.Bottom, LTCellSize.Width, RBCellSize.Height), PixelFormat.Format32bppArgb), new Rectangle(0, TargetSize.Height - RBCellSize.Height, LTCellSize.Width, RBCellSize.Height));
                            //绘制右下角
                            TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(CenterRectangle.Right, CenterRectangle.Bottom, RBCellSize.Width, RBCellSize.Height), PixelFormat.Format32bppArgb), new Rectangle(TargetSize.Width - RBCellSize.Width, TargetSize.Height - RBCellSize.Height, RBCellSize.Width, RBCellSize.Height));

                            //绘制上边框
                            using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(LTCellSize.Width, 0, CenterRectangle.Width, LTCellSize.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                            {
                                TargetTextureBrush.TranslateTransform(LTCellSize.Width, 0);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, 0, TargetSize.Width - LTCellSize.Width - RBCellSize.Width, LTCellSize.Height));
                            }
                            //绘制下边框
                            using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(LTCellSize.Width, CenterRectangle.Bottom, CenterRectangle.Width, RBCellSize.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                            {
                                TargetTextureBrush.TranslateTransform(LTCellSize.Width, TargetSize.Height - RBCellSize.Height);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, TargetSize.Height - RBCellSize.Height, TargetSize.Width - LTCellSize.Width - RBCellSize.Width, RBCellSize.Height));
                            }
                            //绘制左边框
                            using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(0, LTCellSize.Height, LTCellSize.Width, CenterRectangle.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                            {
                                TargetTextureBrush.TranslateTransform(0, LTCellSize.Height);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(0, LTCellSize.Height, LTCellSize.Width, TargetSize.Height - LTCellSize.Height - RBCellSize.Height));
                            }
                            //绘制右边框
                            using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(CenterRectangle.Right, LTCellSize.Height, RBCellSize.Width, CenterRectangle.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                            {
                                TargetTextureBrush.TranslateTransform(TargetSize.Width - RBCellSize.Width, LTCellSize.Height);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(TargetSize.Width - RBCellSize.Width, LTCellSize.Height, RBCellSize.Width, TargetSize.Height - LTCellSize.Height - RBCellSize.Height));
                            }

                            //绘制中心区域
                            using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(CenterRectangle, PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                            {
                                TargetTextureBrush.TranslateTransform(LTCellSize.Width, LTCellSize.Height);
                                TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, LTCellSize.Height, TargetSize.Width - LTCellSize.Width - RBCellSize.Width, TargetSize.Height - LTCellSize.Height - RBCellSize.Height));
                            }
                        }
                    }
                    else if (TargetSize.Width < LTCellSize.Width + RBCellSize.Width && TargetSize.Height >= LTCellSize.Height + RBCellSize.Height)//2
                    {
                        //垂直方向拉伸
                        using (Bitmap TempBitmap = new Bitmap(ResourceImage.Width, TargetSize.Height))
                        {
                            using (Graphics TargetGraphics = Graphics.FromImage(TempBitmap))
                            {
                                //TargetGraphics.SmoothingMode = SmoothingMode.HighQuality;
                                //TargetGraphics.InterpolationMode = InterpolationMode.High;
                                //TargetGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                //绘制上边
                                TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(0, 0, ResourceImage.Width, LTCellSize.Height), PixelFormat.Format32bppArgb), new Rectangle(0, 0, ResourceImage.Width, LTCellSize.Height));
                                //绘制下边
                                TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(0, CenterRectangle.Bottom, ResourceImage.Width, RBCellSize.Height), PixelFormat.Format32bppArgb), new Rectangle(0, TargetSize.Height - RBCellSize.Height, ResourceImage.Width, RBCellSize.Height));

                                //绘制左边框
                                using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(0, LTCellSize.Height, LTCellSize.Width, CenterRectangle.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                                {
                                    TargetTextureBrush.TranslateTransform(0, LTCellSize.Height);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                    TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(0, LTCellSize.Height, LTCellSize.Width, TargetSize.Height - LTCellSize.Height - RBCellSize.Height));
                                }
                                //绘制右边框
                                using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(CenterRectangle.Right, LTCellSize.Height, RBCellSize.Width, CenterRectangle.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                                {
                                    TargetTextureBrush.TranslateTransform(ResourceImage.Width - RBCellSize.Width, LTCellSize.Height);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                    TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(ResourceImage.Width - RBCellSize.Width, LTCellSize.Height, RBCellSize.Width, TargetSize.Height - LTCellSize.Height - RBCellSize.Height));
                                }

                                //绘制中心区域
                                using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(CenterRectangle, PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                                {
                                    TargetTextureBrush.TranslateTransform(LTCellSize.Width, LTCellSize.Height);
                                    TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, LTCellSize.Height, ResourceImage.Width - LTCellSize.Width - RBCellSize.Width, TargetSize.Height - LTCellSize.Height - RBCellSize.Height));
                                }
                            }

                            TargetBGI = new Bitmap(TempBitmap, TargetSize);
                        }
                    }
                    else if (TargetSize.Width >= LTCellSize.Width + RBCellSize.Width && TargetSize.Height < LTCellSize.Height + RBCellSize.Height)//2
                    {
                        //水平方向拉伸
                        using (Bitmap TempBitmap = new Bitmap(TargetSize.Width, ResourceImage.Height))
                        {
                            using (Graphics TargetGraphics = Graphics.FromImage(TempBitmap))
                            {
                                //TargetGraphics.SmoothingMode = SmoothingMode.HighQuality;
                                //TargetGraphics.InterpolationMode = InterpolationMode.High;
                                //TargetGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                //绘制左边
                                TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(0, 0, LTCellSize.Width, ResourceImage.Height), PixelFormat.Format32bppArgb), new Rectangle(0, 0, LTCellSize.Width, ResourceImage.Height));
                                //绘制右边
                                TargetGraphics.DrawImageUnscaledAndClipped(ResourceImage.Clone(new Rectangle(CenterRectangle.Right, 0, RBCellSize.Width, ResourceImage.Height), PixelFormat.Format32bppArgb), new Rectangle(TargetSize.Width - RBCellSize.Width, 0, RBCellSize.Width, ResourceImage.Height));

                                //绘制上边框
                                using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(LTCellSize.Width, 0, CenterRectangle.Width, LTCellSize.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                                {
                                    TargetTextureBrush.TranslateTransform(LTCellSize.Width, 0);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                    TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, 0, TargetSize.Width - LTCellSize.Width - RBCellSize.Width, LTCellSize.Height));
                                }
                                //绘制下边框
                                using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(new Rectangle(LTCellSize.Width, CenterRectangle.Bottom, CenterRectangle.Width, RBCellSize.Height), PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                                {
                                    TargetTextureBrush.TranslateTransform(LTCellSize.Width, ResourceImage.Height - RBCellSize.Height);//应用一个几何变化，把贴图平移与绘制区域对其对齐
                                    TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, ResourceImage.Height - RBCellSize.Height, TargetSize.Width - LTCellSize.Width - RBCellSize.Width, RBCellSize.Height));
                                }

                                //绘制中心区域
                                using (TextureBrush TargetTextureBrush = new TextureBrush(ResourceImage.Clone(CenterRectangle, PixelFormat.Format32bppArgb)) { WrapMode = WrapMode.Tile })
                                {
                                    TargetTextureBrush.TranslateTransform(LTCellSize.Width, LTCellSize.Height);
                                    TargetGraphics.FillRectangle(TargetTextureBrush, new Rectangle(LTCellSize.Width, LTCellSize.Height, TargetSize.Width - LTCellSize.Width - RBCellSize.Width, ResourceImage.Height - LTCellSize.Height - RBCellSize.Height));
                                }
                            }

                            TargetBGI = new Bitmap(TempBitmap, TargetSize);
                        }
                    }
                    else
                    {
                        TargetBGI = new Bitmap(ResourceImage, TargetSize);
                    }

                }
            } catch{
                TargetBGI = ResourceImage.Clone() as Bitmap;
            }
        }

    }
}
