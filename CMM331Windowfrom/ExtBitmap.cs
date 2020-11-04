using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMM331Windowfrom
{
    class ExtBitmap
    {
        private static Bitmap getArgbCopy(Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage,
                    new Rectangle(0, 0, bmpNew.Width, bmpNew.Height),
                    new Rectangle(0, 0, bmpNew.Width, bmpNew.Height),
                    GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return bmpNew;
        }

        public static byte[] toByteArray(Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage);
            BitmapData bmpData = bmpNew.LockBits(
                new Rectangle(0, 0, bmpNew.Width, bmpNew.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb) ; 

            IntPtr ptr = bmpData.Scan0;
            byte[] byteBuffer = new byte[bmpData.Stride * bmpData.Height];
            Marshal.Copy(ptr, byteBuffer,0,byteBuffer.Length);
            return byteBuffer;
        }

        public static Bitmap CopyAsBrightness(Image sourceImage ,int brightness)
        {
            Bitmap bmpNew = new Bitmap(sourceImage);
            BitmapData bmpData = bmpNew.LockBits(
                new Rectangle(0, 0, bmpNew.Width, bmpNew.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr ptr = bmpData.Scan0;

            byte[] byteBuffer = new byte[bmpData.Stride*bmpData.Height];
            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);
            for (int k = 0; k < byteBuffer.Length; k++)
            {
                int red = byteBuffer[k] + brightness;
                int green = byteBuffer[k+1] + brightness;
                int blue = byteBuffer[k + 2] + brightness;

                byteBuffer[k] = (red < 0) ? (byte)0 : (red > 255) ? (byte)255 : (byte)red;
                byteBuffer[k+1] = (green < 0) ? (byte)0 : (green > 255) ? (byte)255 : (byte)green;
                byteBuffer[k+2] = (blue < 0) ? (byte)0 : (blue > 255) ? (byte)255 : (byte)blue;
            }
            
            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);
            bmpNew.UnlockBits(bmpData);
            bmpData = null;
            byteBuffer = null;
            return bmpNew;
        }
    }
}
