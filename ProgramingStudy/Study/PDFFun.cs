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
        public void Study()
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();


            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            string filename = "HelloWorld.pdf";

            document.Save(filename);

            Process.Start(filename);


        }
    }
}
