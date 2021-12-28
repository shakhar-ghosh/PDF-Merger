using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Merger.Helper
{
    public class PdfHelper2
    {
        public static Rectangle pageSize = PageSize.LEGAL;
        public static void imageToPdf(string input, Stream output)
        {
            using (Document pdfDoc = new Document(pageSize, 10f, 10f, 10f, 10f))
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, output);
                pdfDoc.Open();

                //Add the Image file to the PDF document object.
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(input);
                img.Rotation = 0;
                img.ScaleToFitHeight = false;
                img.ScaleAbsolute(pageSize.Width, pageSize.Height);
                pdfDoc.Add(img);
                pdfDoc.Close();
            }
        }
    }
}
