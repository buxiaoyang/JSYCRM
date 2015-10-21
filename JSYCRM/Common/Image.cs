using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace JSYCRM.Common
{
    public class Image
    {
        public static Bitmap BuildImageFromJsonSource(String json)
        {
            Dictionary<String, Bitmap> dictImage = new Dictionary<string, Bitmap>();

            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            int imageWidth = 120;
            int imageHeight = 120;
            Bitmap imgTarget = TransparentToColor(new Bitmap(jsonObject.Count * imageWidth, jsonObject.Count * imageHeight), "#FFFFFF");
            for (int i = 0; i < jsonObject.Count; i++)
            {
                for (int j = 0; j < jsonObject[i].Count; j++)
                {
                    if (jsonObject[i][j].Value == null)
                    {
                        String name = jsonObject[i][j].Name.Value;
                        String img = jsonObject[i][j].Img.Value;
                        String color = jsonObject[i][j].Color.Value;
                        int rotation = (int)jsonObject[i][j].Rotation.Value;
                        //Read img
                        Bitmap imgSource;
                        if (dictImage.ContainsKey(img))
                        {
                            imgSource = dictImage[img];
                        }
                        else
                        {
                            imgSource = ReadImage(img);
                            dictImage.Add(img, imgSource);
                        }
                        //build img
                        imgTarget = CombineImage(imgSource, imgTarget, j * imageHeight, i * imageWidth, color, rotation);
                    }
                }
            }
            return imgTarget;
        }

        public static Bitmap ReadImage(String URL)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(URL);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }

        public static Bitmap CombineImage(Bitmap imgSource, Bitmap imgTarget, int x, int y, String bgColor, int rotation)
        {
            
            using (Graphics g = Graphics.FromImage(imgTarget))
            {
                g.DrawImage(RotateImg(imgSource, rotation, "#" + bgColor), x, y);
            }
            return imgTarget;
        }

        public static Bitmap TransparentToColor(Bitmap bmpOriginal, String color)
        {
            Color colorTarget = System.Drawing.ColorTranslator.FromHtml(color);
            Bitmap bmpTarget = new Bitmap(bmpOriginal.Width, bmpOriginal.Height);
            Rectangle rect = new Rectangle(Point.Empty, bmpOriginal.Size);
            using (Graphics G = Graphics.FromImage(bmpTarget))
            {
                G.Clear(colorTarget);
                G.DrawImageUnscaledAndClipped(bmpOriginal, rect);
            }
            return bmpTarget;
        }

        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        public static Bitmap RotateImg(Bitmap bmp, float angle, String color)
        {
            Color bkColor = System.Drawing.ColorTranslator.FromHtml(color);
            angle = angle % 360;
            if (angle > 180)
                angle -= 360;

            System.Drawing.Imaging.PixelFormat pf = default(System.Drawing.Imaging.PixelFormat);
            if (bkColor == Color.Transparent)
            {
                pf = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }
            float sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
            float cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
            float newImgWidth = sin * bmp.Height + cos * bmp.Width;
            float newImgHeight = sin * bmp.Width + cos * bmp.Height;
            float originX = 0f;
            float originY = 0f;
            if (angle > 0)
            {
                if (angle <= 90)
                    originX = sin * bmp.Height;
                else
                {
                    originX = newImgWidth;
                    originY = newImgHeight - sin * bmp.Width;
                }
            }
            else
            {
                if (angle >= -90)
                    originY = sin * bmp.Width;
                else
                {
                    originX = newImgWidth - sin * bmp.Height;
                    originY = newImgHeight;
                }
            }
            Bitmap newImg = new Bitmap((int)newImgWidth, (int)newImgHeight, pf);
            Graphics g = Graphics.FromImage(newImg);
            g.Clear(bkColor);
            g.TranslateTransform(originX, originY); // offset the origin to our calculated values
            g.RotateTransform(angle); // set up rotate
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(bmp, 0, 0); // draw the image at 0, 0
            g.Dispose();
            return newImg;
        }
    }
}