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
    public class Tile
    {
        public Tile(String name, String metal, String color, String colorN)
        {
            this.name = name;
            this.metal = metal;
            this.color = color;
            this.colorN = colorN;
            this.quantity = 1;
        }
        public String name { get; set; }
        public String metal { get; set; }
        public String color { get; set; }
        public String colorN { get; set; }
        public Int16 quantity { get; set; }

    }

    public class Image
    {
        public static Bitmap BuildImageFromJsonSource(String json, Bitmap imgFooter)
        {
            Dictionary<String, Bitmap> dictImage = new Dictionary<string, Bitmap>();
            Dictionary<String, Tile> dictTile = new Dictionary<string, Tile>();

            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            //get tile information
            for (int i = 0; i < jsonObject.Count; i++)
            {
                for (int j = 0; j < jsonObject[i].Count; j++)
                {
                    if (jsonObject[i][j].Value == null)
                    {
                        String name = jsonObject[i][j].Name.Value;
                        String metal = jsonObject[i][j].Metal.Value;
                        String color = jsonObject[i][j].Color.Value;
                        String colorN = jsonObject[i][j].ColorN.Value;
                        String key = name + metal + color;
                        if(dictTile.ContainsKey(key))
                        {
                            dictTile[key].quantity ++;
                        }
                        else
                        {
                            dictTile.Add(key, new Tile(name, metal, color, colorN));
                        }
                    }
                }
            }
            //caculater the image size
            int tileTableTrHeight = 28;
            int tileTableTdPadding = 4;
            int imageTileWidth = (imgFooter.Width - 140) / jsonObject.Count;
            int imageTileHeight = imageTileWidth;
            int imageTargetWidth = imgFooter.Width;
            int imageTargetHeight = imgFooter.Width + imgFooter.Height + 70 + dictTile.Keys.Count * tileTableTrHeight;
            //create target image
            Bitmap imgTarget = TransparentToColor(new Bitmap(imageTargetWidth, imageTargetHeight), "#FFFFFF");
            //generate tile table to target image
            using (Graphics g = Graphics.FromImage(imgTarget))
            {
                Pen pen = new Pen(System.Drawing.ColorTranslator.FromHtml("#D7D8D8"));
                pen.Width = 1;
                Brush textBrush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#3B3E45"));
                Font textFont = new Font(new FontFamily("Arial"),18,FontStyle.Regular,GraphicsUnit.Pixel);
                Font textFontHeader = new Font(new FontFamily("Arial"), 18, FontStyle.Bold, GraphicsUnit.Pixel);

                List<string> keyList = new List<string>(dictTile.Keys);
                int xPoint1 = 70;
                int xPoint2 = (int)(imgFooter.Width/2-100);
                int xPoint3 = xPoint2 + (int)(imgFooter.Width - 140 - xPoint2)/3;
                int xPoint4 = xPoint3 + (xPoint3 - xPoint2);
                int xPoint5 = imgFooter.Width - 70;
                int yPointStart = imgFooter.Width;
                int yPointEnd = yPointStart + tileTableTrHeight * (keyList.Count + 1);
                //Draw vertical lines     
                //table header
                g.DrawLine(pen, xPoint1, yPointStart, xPoint5, yPointStart);

                g.DrawString("Pattern", textFontHeader, textBrush, xPoint1 + tileTableTdPadding, yPointStart + tileTableTdPadding);
                g.DrawString("Metal Finish", textFontHeader, textBrush, xPoint2 + tileTableTdPadding, yPointStart + tileTableTdPadding);
                g.DrawString("Color", textFontHeader, textBrush, xPoint3 + tileTableTdPadding, yPointStart + tileTableTdPadding);
                g.DrawString("Quantity", textFontHeader, textBrush, xPoint4 + tileTableTdPadding, yPointStart + tileTableTdPadding);

                for (int i = 0; i < keyList.Count; i++)
                {
                    int yPoint = yPointStart + tileTableTrHeight * (i + 1);
                    g.DrawLine(pen, xPoint1, yPoint, xPoint5, yPoint);
                    Tile tile = dictTile[keyList[i]];

                    g.DrawString(tile.name, textFont, textBrush, xPoint1 + tileTableTdPadding, yPoint + tileTableTdPadding);
                    g.DrawString(tile.metal, textFont, textBrush, xPoint2 + tileTableTdPadding, yPoint + tileTableTdPadding);
                    g.DrawString(tile.colorN, textFont, textBrush, xPoint3 + tileTableTdPadding, yPoint + tileTableTdPadding);
                    g.DrawString(tile.quantity.ToString(), textFont, textBrush, xPoint4 + tileTableTdPadding, yPoint + tileTableTdPadding);

                    Brush brushColor = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#"+tile.color));
                    g.FillRectangle(brushColor, xPoint3 + 40, yPoint + tileTableTdPadding, 40, 20);
                }
                g.DrawLine(pen, xPoint1, yPointEnd, xPoint5, yPointEnd);
                //Draw horizontal lines
                g.DrawLine(pen, xPoint1, yPointStart, xPoint1, yPointEnd);
                g.DrawLine(pen, xPoint2, yPointStart, xPoint2, yPointEnd);
                g.DrawLine(pen, xPoint3, yPointStart, xPoint3, yPointEnd);
                g.DrawLine(pen, xPoint4, yPointStart, xPoint4, yPointEnd);
                g.DrawLine(pen, xPoint5, yPointStart, xPoint5, yPointEnd);
            }
            //copy footer to target image
            imgTarget = CombineImage(imgFooter, imgTarget, 0, imageTargetHeight - imgFooter.Height);
            
            //generate tile image to target image
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
                            imgSource = ResizeImage(ReadImage(img), imageTileWidth, imageTileHeight);
                            dictImage.Add(img, imgSource);
                        }
                        //build img
                        imgTarget = CombineImage(RotateImg(imgSource, rotation, "#" + color), imgTarget, j * imageTileHeight + 70, i * imageTileWidth + 70);
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

        public static Bitmap CombineImage(Bitmap imgSource, Bitmap imgTarget, int x, int y)
        {

            using (Graphics g = Graphics.FromImage(imgTarget))
            {
                g.DrawImage(imgSource, x, y);
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