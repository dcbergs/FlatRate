using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatRate
{
    public partial class RatesForm : Form
    {
        //for temporary storage of new rates before submitting
        private float tryStandard;
        private float tryPremium;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public RatesForm()
        {
            InitializeComponent();
            //set text boxes to show current rates
            txtBoxStandardRate.Text = Program.STANDARD_RATE.ToString();
            tryStandard = Program.STANDARD_RATE;
            txtBoxPremiumRate.Text = Program.PREMIUM_RATE.ToString();
            tryPremium = Program.PREMIUM_RATE;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //save changes into STANDARD_RATE and PREMIUM_RATE
            Program.STANDARD_RATE = tryStandard;
            Program.PREMIUM_RATE = tryPremium;
            //close form
            this.Close();
        }

        private void txtBoxPremiumRate_Validating(object sender, CancelEventArgs e)
        {
            //tryparse some floats into local variable
            if (!float.TryParse(((TextBox)sender).Text, out tryPremium) || tryPremium < 0)
            {
                errorProvider1.SetError(txtBoxPremiumRate, "Rate must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxPremiumRate, "");
            }

        }

        private void txtBoxStandardRate_Validating(object sender, CancelEventArgs e)
        {
            //tryparse some floats into local variable
            if (!float.TryParse(((TextBox)sender).Text, out tryStandard) || tryStandard < 0)
            {
                errorProvider1.SetError(txtBoxStandardRate, "Rate must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxStandardRate, "");
            }
        }
    }
}
