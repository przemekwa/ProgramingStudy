using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ProgramingStudy.Study
{
    class PDFFun : IStudyTest
    {
        public string FileName { get; set; }

        public PDFFun()
        {
            this.FileName = "HelloWorld.pdf";
        }

        public void Study()
        {
            this.CreatePdf(this.FileName);
            this.ModifyPdf(this.FileName);
        }

        private void ModifyPdf(string pathToOldPdf)
        {
            PdfSharp.Pdf.PdfDocument PDFDoc = PdfSharp.Pdf.IO.PdfReader.Open(pathToOldPdf, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import);
            PdfSharp.Pdf.PdfDocument PDFNewDoc = new PdfSharp.Pdf.PdfDocument();
            for (int Pg = 0; Pg < PDFDoc.Pages.Count; Pg++)
            {
                PDFNewDoc.AddPage(PDFDoc.Pages[Pg]);

                var page = PDFNewDoc.Pages[Pg];

                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

                gfx.DrawString("Hello, World 2", font, XBrushes.Black, new XRect(10, 10, page.Width, page.Height), XStringFormats.Center);
            }

            PDFNewDoc.Save($"{pathToOldPdf}_new.PDF");
        }

        private void CreatePdf(string filename)
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            document.Save(filename);

            //Process.Start(filename);
        }
    }
}
