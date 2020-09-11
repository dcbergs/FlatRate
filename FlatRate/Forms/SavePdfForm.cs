using FlatRate.Model;
using MigraDoc.DocumentObjectModel;
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

namespace FlatRate
{
    public partial class SavePdfForm : Form
    {
        private ErrorProvider ep = new ErrorProvider();
        public SavePdfForm()
        {
            InitializeComponent();
        }

        private void generatePdfButton_Click(object sender, EventArgs e)
        {
            bool errorState = false;
            if (String.IsNullOrWhiteSpace(pdfTitleText.Text))
            {
                errorState = true;
                ep.SetError(pdfTitleText, "Please add a title");
            }
            if (String.IsNullOrWhiteSpace(authorText.Text))
            {
                errorState = true;
                ep.SetError(authorText, "Please include an author");
            }
            if(!radioButtonDefault.Checked && !radioButtonSelect.Checked ||
                (radioButtonSelect.Checked && String.IsNullOrWhiteSpace(imagePathText.Text)))
            {
                errorState = true;
                ep.SetError(coverImageGroupBox, "Please select an image");
            }
            if (!errorState)
            {
                PdfAuthorInfo info = new PdfAuthorInfo(pdfTitleText.Text, authorText.Text, imagePathText.Text);

                if (exportPDFDialog.ShowDialog() == DialogResult.OK && exportPDFDialog.FileName != "")
                {
                    try
                    {
                        OutputBook outputBook = new OutputBook(exportPDFDialog.FileName, info);
                        outputBook.writeBook();
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("This file is already open. Please close the file and try again.", "Error in file access", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ep.SetError((Control)sender, "");
            }
        }

        private void RadioCheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonDefault.Checked || 
                (radioButtonSelect.Checked && !String.IsNullOrWhiteSpace(imagePathText.Text)))
            {
                ep.SetError(coverImageGroupBox, "");
            }
        }

        private void selectImageButton_Click(object sender, EventArgs e)
        {
            if(imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePathText.Text = imageOpenFileDialog.FileName.ToString();
            }
        }
    }
}
