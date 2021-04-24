using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Color = System.Drawing.Color;
using System.Drawing.Imaging;
using PdfSharp.Pdf;
using PdfDocument = PdfSharpCore.Pdf.PdfDocument;
using System.Reflection.Metadata;
using PdfSharpCore.Utils;
using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;
using SixLabors.ImageSharp.PixelFormats;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using PdfSharpCore.Drawing;

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

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files) {
                if (ImageHelper.IsImage(file))
                {
                    addPagePreview(System.Drawing.Image.FromFile(file));
                }
                else if (ImageHelper.IsPdf(file))
                {
                    var pdfImages = ImageHelper.GetPDFImages(file);
                    foreach(var img in pdfImages)
                    {
                        addPagePreview(img);
                    }
                }
            }

        }

       
        private void addPagePreview(System.Drawing.Image image)
        {
            var newPanelPreview = new Panel();
            newPanelPreview.Name = NumberOfPanel.ToString();
            NumberOfPanel++;

            newPanelPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            newPanelPreview.BackgroundImage = image;
            var sizeRatio = (flowPanelLayout_pages.Width - 60.0)/image.Width;
            newPanelPreview.Size = new Size(flowPanelLayout_pages.Width-40, (int)(sizeRatio*image.Height));
            newPanelPreview.Anchor = AnchorStyles.Left;
            newPanelPreview.Click += NewPanelPreview_Click;
            newPanelPreview.Cursor = Cursors.Hand;
            

            newPanelPreview.Paint += NewPanelPreview_Paint;

            flowPanelLayout_pages.Controls.Add(newPanelPreview);
        }
        public int NumberOfPanel { get; set; } = 0;
        public List<Panel> selectedPanels = new List<Panel>();

        private void NewPanelPreview_Paint(object sender, PaintEventArgs e)
        {
            if (selectedPanels.Any(p => p.Name == ((Panel)sender).Name))
            {
                //ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).DisplayRectangle, Color.Black, ButtonBorderStyle.Solid);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {

                    //e.Graphics.FillRectangle(brush, ClientRectangle);
                    e.Graphics.DrawRectangle(Pens.Blue, 0, 0, ((Panel)sender).Width - 1, ((Panel)sender).Height - 1);
                }

            }
            else
            {

            }
        }

        private void NewPanelPreview_Click(object sender, EventArgs e)
        {
            if(Control.ModifierKeys == Keys.Shift && selectedPanels.Count>0)
            {
                var lastSelectedPanelIndex = flowPanelLayout_pages.Controls.IndexOf(selectedPanels.Last());
                var currentIndex = flowPanelLayout_pages.Controls.IndexOf((Panel)sender);
                var startindex = (currentIndex - lastSelectedPanelIndex) > 0 ? lastSelectedPanelIndex + 1 : currentIndex; // +1 because we already have the fist element selected
                var endindex = (currentIndex - lastSelectedPanelIndex) > 0 ? currentIndex : lastSelectedPanelIndex-1; // -1 because we already have the last index selected
                for(var pageind = startindex; pageind<=endindex; pageind++)
                {
                    if (selectedPanels.Contains(flowPanelLayout_pages.Controls[pageind]))
                    {
                        selectedPanels.Remove(flowPanelLayout_pages.Controls[pageind] as Panel);
                    }
                    else
                    {
                        selectedPanels.Add(flowPanelLayout_pages.Controls[pageind] as Panel);
                    }
                }
                if(selectedPanels.Count>0)
                panel_preview.BackgroundImage = selectedPanels[selectedPanels.Count-1].BackgroundImage;
            }
            else
            {
                selectedPanels.Clear();
                selectedPanels.Add((Panel)sender);
                //if (SelectedPanel == ((Panel)sender).Name)
                //{
                //    SelectedPanel = null;
                //}
                //else
                //{
                //    SelectedPanel = ((Panel)sender).Name;
                //}
            }

            refreshAllPreviewsPanels();


            panel_preview.BackgroundImage = ((Panel)sender).BackgroundImage;

        }

        private void button_rotate_right_Click(object sender, EventArgs e)
        {
            RotateAllSelectedImages(RotateFlipType.Rotate90FlipNone);
        }

        private void button_rotate_left_Click(object sender, EventArgs e)
        {
            RotateAllSelectedImages(RotateFlipType.Rotate270FlipNone);
        }

        private void RotateAllSelectedImages(RotateFlipType rotateDirection)
        {
            foreach (var panel in selectedPanels)
            {
                var oldWidth = panel.Width;
                var oldHeight = panel.Height;

                //panel.BackgroundImage.Save(@"C:\Users\vince\Documents\Programmation\Scannerapplication\scan\native.png", ImageFormat.Png);
                //System.Drawing.Image img = ImageHelper.RotateImage(panel.BackgroundImage, 90f);
                panel.BackgroundImage.RotateFlip(rotateDirection);
                panel.Width = oldHeight;
                panel.Height = oldWidth;
                panel.BackgroundImage = panel.BackgroundImage;
                //panel.BackgroundImage.Save(@"C:\Users\vince\Documents\Programmation\Scannerapplication\scan\outputImg.png", ImageFormat.Png);
                panel.Refresh();
                panel_preview.BackgroundImage = null;
                panel_preview.BackgroundImage = panel.BackgroundImage;
            }
        }

        private void button_export_pdf_Click(object sender, EventArgs e)
        {
            PdfDocument finalPDF = new PdfDocument();
            foreach(var panel in flowPanelLayout_pages.Controls)
            {
                var page = new PdfSharpCore.Pdf.PdfPage();
                finalPDF.AddPage(page);
                XGraphics xgr = XGraphics.FromPdfPage(page);
                
                page.Height = ((Panel)panel).BackgroundImage.Height;
                page.Width = ((Panel)panel).BackgroundImage.Width;

                using (var ms = new MemoryStream())
                {
                    (((Panel)panel).BackgroundImage).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    xgr.DrawImage(XImage.FromStream(() => new MemoryStream(ms.ToArray())),0,0,page.Width,page.Height);
                }
                
            }

            finalPDF.Save(@"C:\Users\vince\Documents\Programmation\Scannerapplication\scan\finalpdf.pdf");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var panel in selectedPanels)
            {
                flowPanelLayout_pages.Controls.Remove(panel);
            }
            selectedPanels.Clear();
            panel_preview.BackgroundImage = flowPanelLayout_pages.Controls.Count > 0 ? ((Panel)flowPanelLayout_pages.Controls[0]).BackgroundImage : null;
            flowPanelLayout_pages.Refresh();
            refreshAllPreviewsPanels();
        }

        private void refreshAllPreviewsPanels()
        {
            foreach (var ctrl in flowPanelLayout_pages.Controls)
            {
                (ctrl as Panel).Anchor = AnchorStyles.Left;
                (ctrl as Panel).Refresh();
            }
        }

    }
}
