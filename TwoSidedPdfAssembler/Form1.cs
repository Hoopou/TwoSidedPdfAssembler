using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoSidedPdfAssembler
{
    public partial class Form1 : Form
    {
        private PdfDocument PDFDoc1;
        private PdfDocument PDFDoc2;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PdfDocument document = new PdfDocument();
            //PdfPage page = document.AddPage();
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter =
            "PDF (*.PDF)|*.PDF";

            // Allow the user to select multiple images.
            fileDialog.Multiselect = true;
            fileDialog.Title = "My PDF Browser";

            DialogResult dr = fileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach(var file in fileDialog.FileNames)
                PDFDoc1 = AppendPDFFileToPdfDocument(PDFDoc1, file);
            }               
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter =
            "PDF (*.PDF)|*.PDF";

            // Allow the user to select multiple images.
            fileDialog.Multiselect = true;
            fileDialog.Title = "My PDF Browser";
            
            DialogResult dr = fileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var file in fileDialog.FileNames)
                    PDFDoc2 = AppendPDFFileToPdfDocument(PDFDoc2, file);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //export 
            PdfDocument FinalPDF = new PdfDocument();


            
            var biggerpagecount = ((PDFDoc1.Pages.Count > PDFDoc2.Pages.Count ? PDFDoc1.Pages.Count : PDFDoc2.Pages.Count));

            for (var i = 0; i < biggerpagecount; i++)
            {
                if (i < PDFDoc1.Pages.Count)
                {
                    FinalPDF.AddPage(PDFDoc1.Pages[i]);
                }
                if (((PDFDoc2.Pages.Count - 1) - i) >= 0)
                {
                    //PdfReader.Open(PDFNewDoc2Reversed., PdfDocumentOpenMode.Import);
                    FinalPDF.AddPage(PDFDoc2.Pages[((PDFDoc2.Pages.Count-1)-i)]);
                }
            }


            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter =
            "PDF (*.pdf)|*.pdf";

            // Allow the user to select multiple images.
            fileDialog.Multiselect = false;
            fileDialog.Title = "My PDF Browser";
            fileDialog.CheckFileExists = false;

            DialogResult dr = fileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                FinalPDF.Save(fileDialog.FileName);
            }

        }

        private static PdfDocument AppendPDFFileToPdfDocument(PdfDocument currentDocument, string PdfFile)
        {
            if (!File.Exists(PdfFile))
                return currentDocument;

            if(currentDocument == null)
            {
                currentDocument = PdfReader.Open(PdfFile, PdfDocumentOpenMode.Import);
            }
            else
            {
                PdfDocument tempDocument = PdfReader.Open(PdfFile, PdfDocumentOpenMode.Import);
                foreach(var page in tempDocument.Pages)
                {
                    currentDocument.AddPage(page);
                }
            }

            return currentDocument;
        }
    }
}
