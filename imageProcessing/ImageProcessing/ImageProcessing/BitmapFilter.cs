using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public class ConvMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;

        public void SetAll(int value)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =
            BottomLeft = BottomMid = BottomRight = value;
        }
    }

    public class BitmapFilter
    {
        public static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            if (m.Factor == 0)
                return false;

            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                           ImageLockMode.ReadWrite,
                           PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                           ImageLockMode.ReadWrite,
                           PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;

            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0;
                byte* pSrc = (byte*)(void*)bmSrc.Scan0;

                int nOffset = stride + 6;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        for (int color = 0; color < 3; color++)
                        {
                            nPixel = 0;

                            nPixel += pSrc[color + x * 3 + y * stride] * m.TopLeft;
                            nPixel += pSrc[color + (x + 1) * 3 + y * stride] * m.TopMid;
                            nPixel += pSrc[color + (x + 2) * 3 + y * stride] * m.TopRight;

                            nPixel += pSrc[color + x * 3 + (y + 1) * stride] * m.MidLeft;
                            nPixel += pSrc[color + (x + 1) * 3 + (y + 1) * stride] * m.Pixel;
                            nPixel += pSrc[color + (x + 2) * 3 + (y + 1) * stride] * m.MidRight;

                            nPixel += pSrc[color + x * 3 + (y + 2) * stride] * m.BottomLeft;
                            nPixel += pSrc[color + (x + 1) * 3 + (y + 2) * stride] * m.BottomMid;
                            nPixel += pSrc[color + (x + 2) * 3 + (y + 2) * stride] * m.BottomRight;

                            nPixel /= m.Factor;
                            nPixel += m.Offset;

                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;

                            p[color + (x + 1) * 3 + (y + 1) * stride] = (byte)nPixel;
                        }
                    }
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

        //Smooth filter
        public static bool Smooth(Bitmap b, int nWeight = 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;

            return Conv3x3(b, m);
        }

        //Gaussian Blur filter
        public static bool GaussianBlur(Bitmap b, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = 1; m.TopMid = 2; m.TopRight = 1;
            m.MidLeft = 2; m.Pixel = 4; m.MidRight = 2;
            m.BottomLeft = 1; m.BottomMid = 2; m.BottomRight = 1;
            m.Factor = 16;
            return Conv3x3(b, m);
        }

        //Sharpen filter
        public static bool Sharpen(Bitmap b, int nWeight = 11)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;

            return Conv3x3(b, m);
        }

        //Mean Removal filter
        public static bool MeanRemoval(Bitmap b, int nWeight = 9)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;

            return Conv3x3(b, m);
        }

        //Emboss filter
        public static bool Emboss(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = -1; m.TopMid = 0; m.TopRight = -1;
            m.MidLeft = 0; m.Pixel = 4; m.MidRight = 0;
            m.BottomLeft = -1; m.BottomMid = 0; m.BottomRight = -1;
            m.Offset = 127;
            return Conv3x3(b, m);
        }
    }
}

