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
            this.pdfTitleLabel = new System.Windows.Forms.Label();
            this.pdfTitleText = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorText = new System.Windows.Forms.TextBox();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.coverImageGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.imagePathText = new System.Windows.Forms.TextBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlatRate.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(9, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
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
            // 
            // imagePathText
            // 
            this.imagePathText.Location = new System.Drawing.Point(9, 160);
            this.imagePathText.Name = "imagePathText";
            this.imagePathText.Size = new System.Drawing.Size(191, 20);
            this.imagePathText.TabIndex = 8;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(206, 157);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(28, 23);
            this.selectImageButton.TabIndex = 9;
            this.selectImageButton.Text = "...";
            this.selectImageButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Generate PDF";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SavePdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 319);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.coverImageGroupBox);
            this.Controls.Add(this.authorText);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.pdfTitleText);
            this.Controls.Add(this.pdfTitleLabel);
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
        private System.Windows.Forms.Button button1;
    }
}