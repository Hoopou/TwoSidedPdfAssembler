namespace TwoSidedPdfAssembler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_assemblePDF = new System.Windows.Forms.Panel();
            this.panel_MainPage = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPreview = new System.Windows.Forms.TabPage();
            this.panel_preview = new System.Windows.Forms.Panel();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.ConsoleBox = new System.Windows.Forms.RichTextBox();
            this.buttonOCR = new System.Windows.Forms.Button();
            this.button_CropAndAutoCut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_tolerance = new System.Windows.Forms.NumericUpDown();
            this.button_crop = new System.Windows.Forms.Button();
            this.button_export_jpg = new System.Windows.Forms.Button();
            this.button_export_png = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_export_pdf = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_rotate_right = new System.Windows.Forms.Button();
            this.flowPanelLayout_pages = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel_assemblePDF.SuspendLayout();
            this.panel_MainPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPreview.SuspendLayout();
            this.tabConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_assemblePDF
            // 
            this.panel_assemblePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_assemblePDF.Controls.Add(this.panel_MainPage);
            this.panel_assemblePDF.Controls.Add(this.button1);
            this.panel_assemblePDF.Controls.Add(this.button2);
            this.panel_assemblePDF.Controls.Add(this.button3);
            this.panel_assemblePDF.Location = new System.Drawing.Point(1, -1);
            this.panel_assemblePDF.Name = "panel_assemblePDF";
            this.panel_assemblePDF.Size = new System.Drawing.Size(947, 497);
            this.panel_assemblePDF.TabIndex = 3;
            // 
            // panel_MainPage
            // 
            this.panel_MainPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_MainPage.Controls.Add(this.tabControl1);
            this.panel_MainPage.Controls.Add(this.buttonOCR);
            this.panel_MainPage.Controls.Add(this.button_CropAndAutoCut);
            this.panel_MainPage.Controls.Add(this.label1);
            this.panel_MainPage.Controls.Add(this.numericUpDown_tolerance);
            this.panel_MainPage.Controls.Add(this.button_crop);
            this.panel_MainPage.Controls.Add(this.button_export_jpg);
            this.panel_MainPage.Controls.Add(this.button_export_png);
            this.panel_MainPage.Controls.Add(this.button_remove);
            this.panel_MainPage.Controls.Add(this.button_export_pdf);
            this.panel_MainPage.Controls.Add(this.button4);
            this.panel_MainPage.Controls.Add(this.button_rotate_right);
            this.panel_MainPage.Controls.Add(this.flowPanelLayout_pages);
            this.panel_MainPage.Location = new System.Drawing.Point(0, 0);
            this.panel_MainPage.Name = "panel_MainPage";
            this.panel_MainPage.Size = new System.Drawing.Size(947, 497);
            this.panel_MainPage.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPreview);
            this.tabControl1.Controls.Add(this.tabConsole);
            this.tabControl1.Location = new System.Drawing.Point(145, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 412);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPreview
            // 
            this.tabPreview.Controls.Add(this.panel_preview);
            this.tabPreview.Location = new System.Drawing.Point(4, 24);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreview.Size = new System.Drawing.Size(791, 384);
            this.tabPreview.TabIndex = 0;
            this.tabPreview.Text = "Preview";
            this.tabPreview.UseVisualStyleBackColor = true;
            // 
            // panel_preview
            // 
            this.panel_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_preview.Location = new System.Drawing.Point(3, 3);
            this.panel_preview.Name = "panel_preview";
            this.panel_preview.Size = new System.Drawing.Size(782, 375);
            this.panel_preview.TabIndex = 1;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.ConsoleBox);
            this.tabConsole.Location = new System.Drawing.Point(4, 24);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(791, 384);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleBox.Location = new System.Drawing.Point(0, 0);
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.Size = new System.Drawing.Size(788, 388);
            this.ConsoleBox.TabIndex = 0;
            this.ConsoleBox.Text = "";
            // 
            // buttonOCR
            // 
            this.buttonOCR.Location = new System.Drawing.Point(577, 14);
            this.buttonOCR.Name = "buttonOCR";
            this.buttonOCR.Size = new System.Drawing.Size(116, 26);
            this.buttonOCR.TabIndex = 12;
            this.buttonOCR.Text = "OCR";
            this.buttonOCR.UseVisualStyleBackColor = true;
            this.buttonOCR.Click += new System.EventHandler(this.buttonOCR_Click);
            // 
            // button_CropAndAutoCut
            // 
            this.button_CropAndAutoCut.Location = new System.Drawing.Point(388, 42);
            this.button_CropAndAutoCut.Name = "button_CropAndAutoCut";
            this.button_CropAndAutoCut.Size = new System.Drawing.Size(110, 26);
            this.button_CropAndAutoCut.TabIndex = 11;
            this.button_CropAndAutoCut.Text = "Crop +";
            this.button_CropAndAutoCut.UseVisualStyleBackColor = true;
            this.button_CropAndAutoCut.Click += new System.EventHandler(this.button_CropAndAutoCut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "tolerance";
            // 
            // numericUpDown_tolerance
            // 
            this.numericUpDown_tolerance.Location = new System.Drawing.Point(504, 49);
            this.numericUpDown_tolerance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_tolerance.Name = "numericUpDown_tolerance";
            this.numericUpDown_tolerance.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown_tolerance.TabIndex = 9;
            this.numericUpDown_tolerance.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // button_crop
            // 
            this.button_crop.Location = new System.Drawing.Point(388, 13);
            this.button_crop.Name = "button_crop";
            this.button_crop.Size = new System.Drawing.Size(110, 23);
            this.button_crop.TabIndex = 8;
            this.button_crop.Text = "Crop";
            this.button_crop.UseVisualStyleBackColor = true;
            this.button_crop.Click += new System.EventHandler(this.button_crop_Click);
            // 
            // button_export_jpg
            // 
            this.button_export_jpg.Location = new System.Drawing.Point(11, 55);
            this.button_export_jpg.Name = "button_export_jpg";
            this.button_export_jpg.Size = new System.Drawing.Size(128, 23);
            this.button_export_jpg.TabIndex = 7;
            this.button_export_jpg.Text = "Export as jpeg";
            this.button_export_jpg.UseVisualStyleBackColor = true;
            this.button_export_jpg.Click += new System.EventHandler(this.button_export_jpg_Click);
            // 
            // button_export_png
            // 
            this.button_export_png.Location = new System.Drawing.Point(11, 34);
            this.button_export_png.Name = "button_export_png";
            this.button_export_png.Size = new System.Drawing.Size(128, 23);
            this.button_export_png.TabIndex = 6;
            this.button_export_png.Text = "Export as Png";
            this.button_export_png.UseVisualStyleBackColor = true;
            this.button_export_png.Click += new System.EventHandler(this.button_export_png_Click);
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_remove.BackColor = System.Drawing.Color.Red;
            this.button_remove.Location = new System.Drawing.Point(90, 465);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(49, 28);
            this.button_remove.TabIndex = 5;
            this.button_remove.Text = "X";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.button5_Click);
            // 
            // button_export_pdf
            // 
            this.button_export_pdf.Location = new System.Drawing.Point(11, 13);
            this.button_export_pdf.Name = "button_export_pdf";
            this.button_export_pdf.Size = new System.Drawing.Size(128, 23);
            this.button_export_pdf.TabIndex = 4;
            this.button_export_pdf.Text = "Export PDF";
            this.button_export_pdf.UseVisualStyleBackColor = true;
            this.button_export_pdf.Click += new System.EventHandler(this.button_export_pdf_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.Location = new System.Drawing.Point(158, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 58);
            this.button4.TabIndex = 3;
            this.button4.Text = "<-Rotate";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_rotate_left_Click);
            // 
            // button_rotate_right
            // 
            this.button_rotate_right.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_rotate_right.Location = new System.Drawing.Point(259, 14);
            this.button_rotate_right.Name = "button_rotate_right";
            this.button_rotate_right.Size = new System.Drawing.Size(95, 58);
            this.button_rotate_right.TabIndex = 2;
            this.button_rotate_right.Text = "Rotate->";
            this.button_rotate_right.UseVisualStyleBackColor = true;
            this.button_rotate_right.Click += new System.EventHandler(this.button_rotate_right_Click);
            // 
            // flowPanelLayout_pages
            // 
            this.flowPanelLayout_pages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowPanelLayout_pages.AutoScroll = true;
            this.flowPanelLayout_pages.BackColor = System.Drawing.SystemColors.Control;
            this.flowPanelLayout_pages.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowPanelLayout_pages.Location = new System.Drawing.Point(11, 78);
            this.flowPanelLayout_pages.Name = "flowPanelLayout_pages";
            this.flowPanelLayout_pages.Size = new System.Drawing.Size(128, 385);
            this.flowPanelLayout_pages.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choisir le pdf1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(528, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 63);
            this.button2.TabIndex = 1;
            this.button2.Text = "Choisir le pdf2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(350, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 59);
            this.button3.TabIndex = 2;
            this.button3.Text = "Exporter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 497);
            this.Controls.Add(this.panel_assemblePDF);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panel_assemblePDF.ResumeLayout(false);
            this.panel_MainPage.ResumeLayout(false);
            this.panel_MainPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPreview.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tolerance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_assemblePDF;
        private System.Windows.Forms.Panel panel_MainPage;
        private System.Windows.Forms.FlowLayoutPanel flowPanelLayout_pages;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel_preview;
        private System.Windows.Forms.Button button_rotate_right;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_export_pdf;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_export_jpg;
        private System.Windows.Forms.Button button_export_png;
        private System.Windows.Forms.Button button_crop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_tolerance;
        private System.Windows.Forms.Button button_CropAndAutoCut;
        private System.Windows.Forms.Button buttonOCR;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPreview;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.RichTextBox ConsoleBox;
    }
}

