using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Merger.Helper
{
    using System.Drawing;
    using System.IO;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;

    public sealed class PdfHelper
    {
        public PdfHelper()
        {
        }

        public static PdfHelper Instance { get; } = new PdfHelper();
        private void RotateAndSaveImage(String input, String output)
        {
            if (File.Exists(output))
                File.Delete(output);
            //create an object that we can use to examine an image file
            using (Image img = Image.FromFile(input))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                img.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void SaveImageAsPdf(string imageFileName, string pdfFileName, int width = 700, bool deleteImage = false)
        {
            RotateAndSaveImage(imageFileName, "output.jpeg");
            using (var document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                using (XImage img = XImage.FromFile("output.jpeg"))
                {
                    
                    // Calculate new height to keep image ratio
                    var height = (int)(((double)width / (double)img.PixelWidth) * img.PixelHeight);

                    // Change PDF Page size to match image
                    page.Width = width;
                    page.Height = height;

                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    
                    gfx.DrawImage(img, 0, 0, width, height);

                }
                document.Save(pdfFileName);
            }

            if (deleteImage)
                File.Delete(imageFileName);
        }
    }
}
