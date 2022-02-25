using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TwoSidedPdfAssembler
{
    public static class ImageHelper
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF" };


        //public static Image RotateImage(Image img, float rotationAngle)
        //{
        //    //return img.RotateFlip();
        //}

        public static bool IsImage(string filePath)
        {
            return ImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant());
        }

        public static bool IsPdf(string filePath)
        {
            return PdfExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant());
        }

        public static List<Image> GetPDFImages(string filePath)
        {
            var imageList = new List<Image>();

            PdfDocument document = PdfReader.Open(filePath);

            // Iterate pages

            foreach (PdfPage page in document.Pages)

            {

                // Get resources dictionary

                PdfDictionary resources = page.Elements.GetDictionary("/Resources");

                if (resources != null)

                {

                    // Get external objects dictionary

                    PdfDictionary xObjects = resources.Elements.GetDictionary("/XObject");

                    if (xObjects != null)

                    {

                        ICollection<PdfItem> items = xObjects.Elements.Values;

                        // Iterate references to external object

                        foreach (PdfItem item in items)

                        {

                            PdfReference reference = item as PdfReference;

                            if (reference != null)

                            {

                                PdfDictionary xObject = reference.Value as PdfDictionary;

                                // Is external object an image?
                                if (xObject != null && xObject.Elements.GetString("/Subtype") == "/Image")

                                {
                                    try
                                    {

                                        var currentImg = GetImage(xObject);

                                        if (currentImg != null)
                                            imageList.Add(currentImg);

                                    }
                                    catch (Exception) { }
                                }

                            }

                        }

                    }

                }
            }

            return imageList;
        }

        private static Image GetImage(PdfDictionary image)
        {
            string filter = image.Elements.GetName("/Filter");
            switch (filter)
            {
                case "/DCTDecode":
                    return ExportJpegImage(image);
                    break;

                case "/FlateDecode":
                    return ExportAsPngImage(image);
                    break;
            }
            return null;
        }

        private static Image ExportJpegImage(PdfDictionary image)
        {
            // Fortunately JPEG has native support in PDF and exporting an image is just writing the stream to a file.
            byte[] stream = image.Stream.Value;
            //FileStream fs = new FileStream(path + @"\" + String.Format("Image{0}.jpeg", count++), FileMode.Create, FileAccess.Write);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Write(stream);
            //bw.Close();
            using (var ms = new MemoryStream(stream))
            {
                return Image.FromStream(ms);
            }

        }

        private static Image ExportAsPngImage(PdfDictionary image)
        {

            //byte[] stream = image.Stream.Value;
            //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            //Image img = (Image)converter.ConvertFrom(stream);
            //img.Save(path + @"\" + String.Format("Image{0}.png", ImageFormat.Png));  // Or Png



            int width = image.Elements.GetInteger(PdfImage.Keys.Width);
            int height = image.Elements.GetInteger(PdfImage.Keys.Height);

            var canUnfilter = image.Stream.TryUnfilter();
            byte[] decodedBytes;

            if (canUnfilter)
            {
                decodedBytes = image.Stream.Value;
            }
            else
            {
                PdfSharp.Pdf.Filters.FlateDecode flate = new PdfSharp.Pdf.Filters.FlateDecode();
                decodedBytes = flate.Decode(image.Stream.Value);
            }

            int bitsPerComponent = 0;
            while (decodedBytes.Length - ((width * height) * bitsPerComponent / 8) != 0)
            {
                bitsPerComponent++;
            }

            System.Drawing.Imaging.PixelFormat pixelFormat;
            switch (bitsPerComponent)
            {
                case 1:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
                    break;
                case 8:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    break;
                case 16:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format16bppArgb1555;
                    break;
                case 24:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                    break;
                case 32:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
                    break;
                case 64:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format64bppArgb;
                    break;
                default:
                    throw new Exception("Unknown pixel format " + bitsPerComponent);
            }

            decodedBytes = decodedBytes.Reverse().ToArray();

            Bitmap bmp = new Bitmap(width, height, pixelFormat);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            int length = (int)Math.Ceiling(width * (bitsPerComponent / 8.0));
            for (int i = 0; i < height; i++)
            {
                int offset = i * length;
                int scanOffset = i * bmpData.Stride;
                Marshal.Copy(decodedBytes, offset, new IntPtr(bmpData.Scan0.ToInt64() + scanOffset), length);
            }
            bmp.UnlockBits(bmpData);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);

            return (Image)bmp;
            //bmp.Save(path + @"\" + String.Format("Image{0}.png", count++), System.Drawing.Imaging.ImageFormat.Png);
        }

        public static Image CropImage(Image sourceImage, Color grey, int tolerance = 80)
        {
            //using (var ms = new MemoryStream(ImageToByteArray(sourceImage)))
            //{
            //var Img = new Bitmap(sourceImage);

            //using (Bitmap bmp = new Bitmap(Img))
            //{
            //    var midX = bmp.Width / 2;
            //    var midY = bmp.Height / 2;
            //    var yTop = 0;
            //    var yBottom = bmp.Height;
            //    var xLeft = 0;
            //    var xRight = bmp.Width;

            //    for (int y = 0; y < bmp.Height; y++)
            //    {
            //        Color pxl = bmp.GetPixel(midX, y);
            //        if (pxl != grey)
            //        {
            //            yTop = y;
            //            break;
            //        }
            //    }

            //    for (int x = 0; x < bmp.Width; x++)
            //    {
            //        Color pxl = bmp.GetPixel(x, midX);
            //        if (pxl != grey)
            //        {
            //            xLeft = x;
            //            break;
            //        }
            //    }

            //    for (int x = bmp.Width - 1; x > midX; x--)
            //    {
            //        Color pxl = bmp.GetPixel(x, midX);
            //        if (pxl != grey)
            //        {
            //            xRight = x;
            //            break;
            //        }
            //    }

            //    for (int y = bmp.Height - 1; y > midY; y--)
            //    {
            //        Color pxl = bmp.GetPixel(midX, y);
            //        if (pxl != grey)
            //        {
            //            yBottom = y;
            //            break;
            //        }
            //    }
            //    Image redBmp = bmp.Clone(new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop), System.Drawing.Imaging.PixelFormat.DontCare);

            //    return redBmp;


            //}

            var bmp = new Bitmap(sourceImage);
            int w = bmp.Width;
            int h = bmp.Height;
            //int white = 0xffffff;
            var basecolor = bmp.GetPixel(w - 1, h - 1);

            Func<Color, Color, bool> isSameColorWithTolerance = (c1, c2) =>
            {
                var tolelanceColor = Color.FromArgb(0, 0, 0, tolerance);
                if(Math.Abs(c1.A-c2.A)<= tolerance && Math.Abs(c1.R - c2.R) <= tolerance && Math.Abs(c1.G - c2.G) <= tolerance && Math.Abs(c1.B - c2.B) <= tolerance)
                    return true;
                return false;
            };

            Func<int, bool> allWhiteRow = r =>
            {
                for (int i = 0; i < w; ++i)
                {
                    if (bmp.GetPixel(i, r) != basecolor && !isSameColorWithTolerance(bmp.GetPixel(i, r), basecolor))
                        return false;
                }
                return true;
            };

            Func<int, bool> allWhiteColumn = c =>
            {
                for (int i = 0; i < h; ++i)
                    if (bmp.GetPixel(c, i) != basecolor && !isSameColorWithTolerance(bmp.GetPixel(c, i), basecolor))
                        return false;
                return true;
            };

            int topmost = 0;
            for (int row = 0; row < h; ++row)
            {
                if (!allWhiteRow(row))
                    break;
                topmost = row;
            }

            int bottommost = 0;
            for (int row = h - 1; row >= 0; --row)
            {
                if (!allWhiteRow(row))
                    break;
                bottommost = row;
            }

            int leftmost = 0, rightmost = 0;
            for (int col = 0; col < w; ++col)
            {
                if (!allWhiteColumn(col))
                    break;
                leftmost = col;
            }

            for (int col = w - 1; col >= 0; --col)
            {
                if (!allWhiteColumn(col))
                    break;
                rightmost = col;
            }

            if (rightmost == 0) rightmost = w; // As reached left
            if (bottommost == 0) bottommost = h; // As reached top.

            int croppedWidth = rightmost - leftmost;
            int croppedHeight = bottommost - topmost;

            if (croppedWidth == 0) // No border on left or right
            {
                leftmost = 0;
                croppedWidth = w;
            }

            if (croppedHeight == 0) // No border on top or bottom
            {
                topmost = 0;
                croppedHeight = h;
            }

            try
            {
                var target = new Bitmap(croppedWidth, croppedHeight);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(bmp,
                        new RectangleF(0, 0, croppedWidth, croppedHeight),
                        new RectangleF(leftmost, topmost, croppedWidth, croppedHeight),
                        GraphicsUnit.Pixel);
                }
                return ((Image)target);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("Values are topmost={0} btm={1} left={2} right={3} croppedWidth={4} croppedHeight={5}", topmost, bottommost, leftmost, rightmost, croppedWidth, croppedHeight),
                    ex);
            }
            
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
