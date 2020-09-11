using FlatRate.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatRate
{
    public partial class CategoriesForm : Form
    {
        DataManager dataManager = DataManager.GetInstance();
        private static CultureInfo ci = new CultureInfo("en-us");
        ErrorProvider errorProvider1 = new ErrorProvider();

        public CategoriesForm()
        {
            InitializeComponent();

            //define categoryGridView
            categoriesBindingSource.DataSource = DataManager.Categories;
            categoryGridView.DataSource = categoriesBindingSource;
            categoryGridView.Columns[0].Visible = false;

            subcategoryGridView.DataSource = subcategoriesBindingSource;

            tasksGridView.DataSource = tasksBindingSource;
            
        }

        //-------------------------------------------------------------ADD NEW CATEGORY----------------------------------------------
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtCategory.Text))
            {
                dataManager.AddCategory(ci.TextInfo.ToTitleCase(txtCategory.Text.ToLower()));
                txtCategory.Text = "";
            }
        }

        private void txtCategory_Validating(object sender, CancelEventArgs e)
        {
            string potentialCategory = txtCategory.Text;
            potentialCategory = ci.TextInfo.ToTitleCase(potentialCategory.ToLower());
            DataRow[] existingRows;
            existingRows = DataManager.Categories.Select("Title LIKE '" + potentialCategory + "'");
            if(existingRows.Length != 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCategory, "Category already exists");
            }
            else
            {
                errorProvider1.SetError(txtCategory, "");
            }
        }

        //delete selected categories, if any, including subcategories and tasks
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            //this supports multiple selection but for now the datagridview is only allowing one at a time
            HashSet<int> rows = new HashSet<int>();
            foreach (DataGridViewCell cell in categoryGridView.SelectedCells)
            {
                rows.Add(cell.RowIndex);
            }
            foreach (int index in rows)
            {
                //check for subcategories
                int categoryId = (int)categoryGridView.Rows[index].Cells[0].Value;

                List<Subcategory> subcats = dataManager.GetSubcategoriesByCategoryId(categoryId);
                List<TaskSummary> tasks = dataManager.GetTaskSummariesByCategoryId(categoryId);

                bool doDelete = true;
                if(subcats.Count() > 0 || tasks.Count() > 0)
                {
                    string title = "Warning: Category Deletion";
                    string message = "Deleting this category will delete " + subcats.Count() + " subcategories and " + tasks.Count() + " tasks! Delete category anyway?";
                    var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        doDelete = false;
                    }
                }

                if (doDelete)
                {
                    dataManager.DeleteCategoryById(categoryId);
                }
            }
        }

        private void btnDeleteSubcategory_Click(object sender, EventArgs e)
        {
            //this supports multiple selection but for now the datagridview is only allowing one at a time
            HashSet<int> rows = new HashSet<int>();
            foreach (DataGridViewCell cell in subcategoryGridView.SelectedCells)
            {
                rows.Add(cell.RowIndex);
            }
            foreach (int index in rows)
            {
                //check for subcategories
                int subcategoryId = (int)subcategoryGridView.Rows[index].Cells[0].Value;

                List<TaskSummary> tasks = dataManager.GetTaskSummariesBySubcategoryId(subcategoryId);

                bool doDelete = true;
                if (tasks.Count() > 0)
                {
                    string title = "Warning: Subcategory Deletion";
                    string message = "Deleting this subcategory will delete " + tasks.Count() + " tasks! Delete subcategory anyway?";
                    var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        doDelete = false;
                    }
                }
                if (doDelete)
                {
                    dataManager.DeleteSubcategory(subcategoryId);
                }
            }
        }

        //--------------------------------------------------------DISPLAY SUBCATEGORIES WHEN CATEGORY CLICKED-------------------------------
        private void categoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the category row; make sure index is >= 0 (if it's -1 they clicked on the header)
            if(e.RowIndex >= 0)
            {
                int categoryIDclicked = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;

                //subcat datagridview gets appropriate subcategories in view form
                DataView view = dataManager.GetSubcategoriesViewByCategory(categoryIDclicked);
                subcategoriesBindingSource.DataSource = view;
                subcategoryGridView.Columns[0].Visible = false;
                subcategoryGridView.Columns[2].Visible = false;

                //clear tasks
                tasksBindingSource.DataSource = null;
            }
        }

        private void txtSubcategory_Validating(object sender, CancelEventArgs e)
        {
            //need to make sure a category is selected first
            if(categoryGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please create and select a category first", "No category selected", MessageBoxButtons.OK);
            }
            else
            {
                //get which category is selected
                DataRow row = ((DataRowView)categoryGridView.SelectedRows[0].DataBoundItem).Row;
                string id = row["ID"].ToString();

                string potentialSubcategory = txtSubcategory.Text;
                potentialSubcategory = ci.TextInfo.ToTitleCase(potentialSubcategory.ToLower());
                DataRow[] existingRows;
                existingRows = DataManager.Subcategories.Select("Title LIKE '" + potentialSubcategory + "' AND Convert(CategoryID, 'System.String') LIKE '" + id + "'");
                if (existingRows.Length != 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtSubcategory, "Subcategory already exists in this category");
                }
                else
                {
                    errorProvider1.SetError(txtSubcategory, "");
                }
            }
            
        }

        //---------------------------------------------------------------ADD SUBCATEGORY-----------------------------------------------------
        private void btnAddSubcategory_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSubcategory.Text))
            {
                //need to make sure a category is selected first
                if (categoryGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please create and select a category first", "No category selected", MessageBoxButtons.OK);
                }
                else
                {
                    //get which category is selected
                    DataRow row = ((DataRowView)categoryGridView.SelectedRows[0].DataBoundItem).Row;
                    string id = row["ID"].ToString();

                    string potentialSubcategory = txtSubcategory.Text;
                    potentialSubcategory = ci.TextInfo.ToTitleCase(potentialSubcategory.ToLower());
                    DataRow[] existingRows;
                    existingRows = DataManager.Subcategories.Select("Title LIKE '" + potentialSubcategory + "' AND Convert(CategoryID, 'System.String') LIKE '" + id + "'");
                    if (existingRows.Length != 0)
                    {
                        errorProvider1.SetError(txtSubcategory, "Subcategory already exists in this category");
                    }
                    else
                    {
                        errorProvider1.SetError(txtSubcategory, "");

                        //new subcategory to be added to table
                        Subcategory newSubcategory = new Subcategory
                        {
                            Title = ci.TextInfo.ToTitleCase(txtSubcategory.Text.ToLower()),
                            CategoryId = (int)row["id"],
                        };
                        dataManager.AddSubcategory(newSubcategory);

                        txtSubcategory.Text = "";

                        //update subcat datagridview
                        DataView view = dataManager.GetSubcategoriesViewByCategory(Convert.ToInt32(row["ID"]));
                        subcategoriesBindingSource.DataSource = view;
                        subcategoryGridView.Columns[0].Visible = false;
                        subcategoryGridView.Columns[2].Visible = false;
                    }
                }
                
            }
        }

        //--------------------------------------------------------DISPLAY TASKS WHEN SUBCATEGORY CLICKED-------------------------------------
        private void subcategoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //get the subcategory row
                int subcategoryIDclicked = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;

                //update tasks and format
                tasksBindingSource.DataSource = dataManager.GetTaskSummariesBySubcategoryId(subcategoryIDclicked);
                tasksGridView.DataSource = tasksBindingSource;
                tasksGridView.Columns[2].Visible = false;
                tasksGridView.Columns[3].Visible = false;
                tasksGridView.Columns[4].Visible = false;
            }
        }

        private void tasksGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                e.CellStyle.Format = "N2";
            }
        }

    }
}
