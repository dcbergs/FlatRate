namespace FlatRate
{
    partial class SavePdfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavePdfForm));
            this.pdfTitleLabel = new System.Windows.Forms.Label();
            this.pdfTitleText = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorText = new System.Windows.Forms.TextBox();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.coverImageGroupBox = new System.Windows.Forms.GroupBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.imagePathText = new System.Windows.Forms.TextBox();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.generatePdfButton = new System.Windows.Forms.Button();
            this.exportPDFDialog = new System.Windows.Forms.SaveFileDialog();
            this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.coverImageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pdfTitleLabel
            // 
            this.pdfTitleLabel.AutoSize = true;
            this.pdfTitleLabel.Location = new System.Drawing.Point(13, 13);
            this.pdfTitleLabel.Name = "pdfTitleLabel";
            this.pdfTitleLabel.Size = new System.Drawing.Size(50, 13);
            this.pdfTitleLabel.TabIndex = 0;
            this.pdfTitleLabel.Text = "PDF title:";
            // 
            // pdfTitleText
            // 
            this.pdfTitleText.Location = new System.Drawing.Point(69, 10);
            this.pdfTitleText.Name = "pdfTitleText";
            this.pdfTitleText.Size = new System.Drawing.Size(187, 20);
            this.pdfTitleText.TabIndex = 1;
            this.pdfTitleText.Text = "Favinger Plumbing Flat Rate Book";
            this.pdfTitleText.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(22, 39);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(41, 13);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Author:";
            // 
            // authorText
            // 
            this.authorText.Location = new System.Drawing.Point(69, 36);
            this.authorText.Name = "authorText";
            this.authorText.Size = new System.Drawing.Size(187, 20);
            this.authorText.TabIndex = 3;
            this.authorText.Text = "CAZ Electric, LLC";
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Location = new System.Drawing.Point(6, 19);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(59, 17);
            this.radioButtonDefault.TabIndex = 5;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "Default";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            this.radioButtonDefault.CheckedChanged += new System.EventHandler(this.RadioCheckedChanged);
            // 
            // coverImageGroupBox
            // 
            this.coverImageGroupBox.Controls.Add(this.selectImageButton);
            this.coverImageGroupBox.Controls.Add(this.imagePathText);
            this.coverImageGroupBox.Controls.Add(this.radioButtonSelect);
            this.coverImageGroupBox.Controls.Add(this.pictureBox1);
            this.coverImageGroupBox.Controls.Add(this.radioButtonDefault);
            this.coverImageGroupBox.Location = new System.Drawing.Point(16, 75);
            this.coverImageGroupBox.Name = "coverImageGroupBox";
            this.coverImageGroupBox.Size = new System.Drawing.Size(240, 201);
            this.coverImageGroupBox.TabIndex = 6;
            this.coverImageGroupBox.TabStop = false;
            this.coverImageGroupBox.Text = "Cover Image";
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(206, 157);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(28, 23);
            this.selectImageButton.TabIndex = 9;
            this.selectImageButton.Text = "...";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // imagePathText
            // 
            this.imagePathText.Location = new System.Drawing.Point(9, 160);
            this.imagePathText.Name = "imagePathText";
            this.imagePathText.Size = new System.Drawing.Size(191, 20);
            this.imagePathText.TabIndex = 8;
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Location = new System.Drawing.Point(9, 136);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(97, 17);
            this.radioButtonSelect.TabIndex = 7;
            this.radioButtonSelect.TabStop = true;
            this.radioButtonSelect.Text = "Select from File";
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            this.radioButtonSelect.CheckedChanged += new System.EventHandler(this.RadioCheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(9, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // generatePdfButton
            // 
            this.generatePdfButton.Location = new System.Drawing.Point(85, 284);
            this.generatePdfButton.Name = "generatePdfButton";
            this.generatePdfButton.Size = new System.Drawing.Size(99, 23);
            this.generatePdfButton.TabIndex = 7;
            this.generatePdfButton.Text = "Generate PDF";
            this.generatePdfButton.UseVisualStyleBackColor = true;
            this.generatePdfButton.Click += new System.EventHandler(this.generatePdfButton_Click);
            // 
            // exportPDFDialog
            // 
            this.exportPDFDialog.DefaultExt = "pdf";
            this.exportPDFDialog.Filter = "PDF (*.pdf) | *.pdf";
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.Filter = "Image Files (*.PNG; *.JPG) | *.png; *.jpg";
            // 
            // SavePdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 319);
            this.Controls.Add(this.generatePdfButton);
            this.Controls.Add(this.coverImageGroupBox);
            this.Controls.Add(this.authorText);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.pdfTitleText);
            this.Controls.Add(this.pdfTitleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavePdfForm";
            this.Text = "Save PDF";
            this.coverImageGroupBox.ResumeLayout(false);
            this.coverImageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pdfTitleLabel;
        private System.Windows.Forms.TextBox pdfTitleText;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox authorText;
        private System.Windows.Forms.RadioButton radioButtonDefault;
        private System.Windows.Forms.GroupBox coverImageGroupBox;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.TextBox imagePathText;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button generatePdfButton;
        private System.Windows.Forms.SaveFileDialog exportPDFDialog;
        private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
    }
}