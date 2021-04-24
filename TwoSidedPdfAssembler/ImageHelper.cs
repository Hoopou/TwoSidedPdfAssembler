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

                                    var currentImg = GetImage(xObject);

                                    if (currentImg != null)
                                        imageList.Add(currentImg);

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
    }
}
