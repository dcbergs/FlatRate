using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FlatRate.Model;

namespace FlatRate.Forms
{
    public partial class MultiEdit : Form
    {
        private DataManager dataManager = DataManager.GetInstance();
        private List<String> taskIds;
        private ErrorProvider errorProvider = new ErrorProvider();

        public MultiEdit(List<String> taskIds)
        {
            InitializeComponent();

            this.taskIds = taskIds;
            numberOfTasksLabel.Text = "Changes will be applied to " + taskIds.Count() + " tasks:";
            categoryComboBox.Enabled = false;
            subcategoryComboBox.Enabled = false;
        }
        private void updateComboBoxes()
        {
            //category combo box
            categoryComboBox.DataSource = DataManager.Categories;
            categoryComboBox.DisplayMember = "Title";
            categoryComboBox.ValueMember = "ID";

            //setup subcategory combo box
            //get the category selected
            if ((DataRowView)categoryComboBox.SelectedItem != null)
            {
                DataRow row = ((DataRowView)categoryComboBox.SelectedItem).Row;
                if (row != null)
                {
                    //query for appropriate subcategories

                    DataView view = dataManager.GetSubcategoriesViewByCategory(Convert.ToInt32(row["Id"]));
                    subcategoryComboBox.DataSource = view;
                    subcategoryComboBox.DisplayMember = "Title";
                    subcategoryComboBox.ValueMember = "ID";
                }

            }
        }

        private void changeCategoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (changeCategoryCheckBox.Checked)
            {
                categoryComboBox.Enabled = true;
                subcategoryComboBox.Enabled = true;
                updateComboBoxes();
            }
            else
            {
                categoryComboBox.Enabled = false;
                subcategoryComboBox.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MultiTaskEditDescriptor changes = new MultiTaskEditDescriptor();
            bool errorState = false;
            //validate input and keep track of what is being changed
            if (categoryComboBox.Enabled && categoryComboBox.SelectedItem == null)
            {
                errorProvider.SetError(categoryComboBox, "If changing category/subcategory, both must be specified");
                errorState = true;
            }
            else
            {
                errorProvider.SetError(categoryComboBox, "");
                if (categoryComboBox.Enabled)
                {
                    changes.CategoryId = Convert.ToInt32(((DataRowView)categoryComboBox.SelectedItem).Row["ID"]);
                }
            }
            if (subcategoryComboBox.Enabled && subcategoryComboBox.SelectedItem == null)
            {
                errorProvider.SetError(subcategoryComboBox, "If changing category/subcategory, both must be specified");
                errorState = true;
            }
            else
            {
                errorProvider.SetError(subcategoryComboBox, "");
                if (subcategoryComboBox.Enabled)
                {
                    changes.SubcategoryId = Convert.ToInt32(((DataRowView)subcategoryComboBox.SelectedItem).Row["ID"]);
                }
            }
            if (changeCategoryCheckBox.Checked)
            {
                changes.IsCategoryChanging = true;
            }
            //hours
            if (!String.IsNullOrWhiteSpace(HoursTextBox.Text))
            {
                float testHours = 0.0f;
                if (!float.TryParse(HoursTextBox.Text, out testHours))
                {
                    errorProvider.SetError(HoursTextBox, "Please enter a valid number of hours");
                    errorState = true;
                }
                else
                {
                    changes.Hours = testHours;
                    changes.IsHoursChanging = true;
                    changes.IsHoursAdditive = HoursAddCheckBox.Checked;
                }
            }
            //standard add on
            if (!String.IsNullOrWhiteSpace(standardTextBox.Text))
            {
                float testStandard = 0.0f;
                if (!float.TryParse(standardTextBox.Text, out testStandard))
                {
                    errorProvider.SetError(standardTextBox, "Please enter a valid number for the add-on");
                    errorState = true;
                }
                else
                {
                    changes.StandardAddOn = testStandard;
                    changes.IsStandardChanging = true;
                    changes.IsStandardAdditive = standardAddCheckBox.Checked;
                }
            }
            //premium add on
            if (!String.IsNullOrWhiteSpace(premiumTextBox.Text))
            {
                float testPremium = 0.0f;
                if (!float.TryParse(premiumTextBox.Text, out testPremium))
                {
                    errorProvider.SetError(premiumTextBox, "Please enter a valid number for the add-on");
                    errorState = true;
                }
                else
                {
                    changes.PremiumAddOn = testPremium;
                    changes.IsPremiumChanging = true;
                    changes.IsPremiumAdditive = premiumCheckBox.Checked;
                }
            }
            if (!errorState)
            {
                foreach(String taskId in taskIds)
                {
                    dataManager.UpdateTaskWithoutParts(taskId, changes);
                }
                this.Close();
            }
        }

        private void HoursTextBox_Validating(object sender, CancelEventArgs e)
        {
            float test = 0.0f;
            if (float.TryParse(((TextBox)sender).Text, out test))
            {
                errorProvider.SetError((Control)sender, "");
            }
        }

        private void AddOn_Validating(object sender, CancelEventArgs e)
        {
            float test = 0.0f;
            if (float.TryParse(((TextBox)sender).Text, out test))
            {
                errorProvider.SetError((Control)sender, "");
            }
        }

        private void categoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateComboBoxes();
        }
    }
}
