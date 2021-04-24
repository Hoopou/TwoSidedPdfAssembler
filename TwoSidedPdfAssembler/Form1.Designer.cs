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
            this.button_export_pdf = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_rotate_right = new System.Windows.Forms.Button();
            this.panel_preview = new System.Windows.Forms.Panel();
            this.flowPanelLayout_pages = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel_assemblePDF.SuspendLayout();
            this.panel_MainPage.SuspendLayout();
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
            this.panel_MainPage.Controls.Add(this.button5);
            this.panel_MainPage.Controls.Add(this.button_export_pdf);
            this.panel_MainPage.Controls.Add(this.button4);
            this.panel_MainPage.Controls.Add(this.button_rotate_right);
            this.panel_MainPage.Controls.Add(this.panel_preview);
            this.panel_MainPage.Controls.Add(this.flowPanelLayout_pages);
            this.panel_MainPage.Location = new System.Drawing.Point(0, 0);
            this.panel_MainPage.Name = "panel_MainPage";
            this.panel_MainPage.Size = new System.Drawing.Size(947, 497);
            this.panel_MainPage.TabIndex = 3;
            // 
            // button_export_pdf
            // 
            this.button_export_pdf.Location = new System.Drawing.Point(11, 13);
            this.button_export_pdf.Name = "button_export_pdf";
            this.button_export_pdf.Size = new System.Drawing.Size(128, 59);
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
            // panel_preview
            // 
            this.panel_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_preview.Location = new System.Drawing.Point(158, 78);
            this.panel_preview.Name = "panel_preview";
            this.panel_preview.Size = new System.Drawing.Size(740, 385);
            this.panel_preview.TabIndex = 1;
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
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(90, 465);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 28);
            this.button5.TabIndex = 5;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
        private System.Windows.Forms.Button button5;
    }
}

