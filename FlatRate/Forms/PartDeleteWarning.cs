using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatRate.Forms
{
    public partial class PartDeleteWarning : Form
    {
        public PartDeleteWarning(List<String> tasksAffected)
        {
            InitializeComponent();
            TasksLabel.Text = "";
            foreach (String id in tasksAffected)
            {
                TasksLabel.Text += id + "\n";
            }
            this.CancelButton = CancelDeletionButton;
        }

        private void CancelDeletionButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
