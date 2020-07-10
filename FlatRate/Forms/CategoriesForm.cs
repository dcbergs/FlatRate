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
        private DataSet flatRateData;
        private static CultureInfo ci = new CultureInfo("en-us");
        ErrorProvider errorProvider1 = new ErrorProvider();

        //-------------------------------------------------INITIALIZE WITH DATASET--------------------------------------------
        public CategoriesForm(DataSet data)
        {
            InitializeComponent();
            flatRateData = data;

            //define categoryGridView TODO format columns
            categoriesBindingSource.DataSource = flatRateData.Tables["Categories"];
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
                DataRow row = flatRateData.Tables["Categories"].NewRow();
                row["Title"] = ci.TextInfo.ToTitleCase(txtCategory.Text.ToLower());
                flatRateData.Tables["Categories"].Rows.Add(row);
                txtCategory.Text = "";
            }
        }

        private void txtCategory_Validating(object sender, CancelEventArgs e)
        {
            string potentialCategory = txtCategory.Text;
            potentialCategory = ci.TextInfo.ToTitleCase(potentialCategory.ToLower());
            DataRow[] existingRows;
            existingRows = flatRateData.Tables["Categories"].Select("Title LIKE '" + potentialCategory + "'");
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
                string categoryIDclicked = categoryGridView.Rows[index].Cells[0].Value.ToString();

                //query for when the subcategory's FK matches the category's PK
                EnumerableRowCollection<DataRow> query =
                    from subcategory in flatRateData.Tables["Subcategories"].AsEnumerable()
                    where subcategory.Field<Int32>("CategoryID") == Convert.ToInt32(categoryIDclicked)
                    select subcategory;

                EnumerableRowCollection<DataRow> query2 =
                    from task in flatRateData.Tables["Tasks"].AsEnumerable()
                    where task.Field<Int32>("CategoryID") == Convert.ToInt32(categoryIDclicked)
                    select task;

                bool doDelete = true;
                if(query.Count() > 0 || query2.Count() > 0)
                {
                    string title = "Warning: Category Deletion";
                    string message = "Deleting this category will delete " + query.Count() + " subcategories and " + query2.Count() + " tasks! Delete category anyway?";
                    var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        doDelete = false;
                    }
                }

                if (doDelete)
                {
                    foreach(DataRow task in query2)
                    {
                        //delete tasks_parts associations
                        EnumerableRowCollection<DataRow> taskspartsquery =
                        from removalRow in flatRateData.Tables["Tasks_Parts"].AsEnumerable()
                        where removalRow.Field<String>("TaskID") == task.Field<String>("ID")
                        select removalRow;

                        flatRateData.Tables["Tasks_Parts"].AcceptChanges();
                        foreach (DataRow taskspartsrow in taskspartsquery)
                        {
                            taskspartsrow.Delete();
                        }
                        flatRateData.Tables["Tasks_Parts"].AcceptChanges();
                    }
                    //delete tasks separately to not modify collection while iterating through tasks_parts
                    flatRateData.Tables["Tasks"].AcceptChanges();
                    foreach(DataRow task in query2)
                    {
                        task.Delete();
                    }
                    flatRateData.Tables["Tasks"].AcceptChanges();

                    //delete subcategories
                    flatRateData.Tables["Subcategories"].AcceptChanges();
                    foreach (DataRow subcat in query)
                    {
                        subcat.Delete();
                    }
                    flatRateData.Tables["Subcategories"].AcceptChanges();

                    flatRateData.Tables["Categories"].Rows.RemoveAt(index);
                }
                
            }
        }

        //--------------------------------------------------------DISPLAY SUBCATEGORIES WHEN CATEGORY CLICKED-------------------------------
        private void categoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the category row; make sure index is >= 0 (if it's -1 they clicked on the header)
            if(e.RowIndex >= 0)
            {
                string categoryIDclicked = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();

                //query for when the subcategory's FK matches the category's PK
                EnumerableRowCollection<DataRow> query =
                    from subcategory in flatRateData.Tables["Subcategories"].AsEnumerable()
                    where subcategory.Field<Int32>("CategoryID") == Convert.ToInt32(categoryIDclicked)
                    select subcategory;

                //use this query result as a view and send to subcat datagridview
                DataView view = query.AsDataView();
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
                existingRows = flatRateData.Tables["Subcategories"].Select("Title LIKE '" + potentialSubcategory + "' AND Convert(CategoryID, 'System.String') LIKE '" + id + "'");
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
                    existingRows = flatRateData.Tables["Subcategories"].Select("Title LIKE '" + potentialSubcategory + "' AND Convert(CategoryID, 'System.String') LIKE '" + id + "'");
                    if (existingRows.Length != 0)
                    {
                        errorProvider1.SetError(txtSubcategory, "Subcategory already exists in this category");
                    }
                    else
                    {
                        errorProvider1.SetError(txtSubcategory, "");

                        //new subcategory to be added to table
                        DataRow addRow = flatRateData.Tables["Subcategories"].NewRow();
                        addRow["Title"] = ci.TextInfo.ToTitleCase(txtSubcategory.Text.ToLower());
                        addRow["CategoryID"] = row["ID"];
                        flatRateData.Tables["Subcategories"].Rows.Add(addRow);

                        txtSubcategory.Text = "";

                        //update view: query for when the subcategory's FK matches the category's PK
                        EnumerableRowCollection<DataRow> query =
                            from subcategory in flatRateData.Tables["Subcategories"].AsEnumerable()
                            where subcategory.Field<Int32>("CategoryID") == Convert.ToInt32(row["ID"])
                            select subcategory;

                        //use this query result as a view and sent to subcat datagridview
                        DataView view = query.AsDataView();
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
                string subcategoryIDclicked = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();

                //query for when the task's FK matches the subcategory's PK
                EnumerableRowCollection<DataRow> query =
                    from task in flatRateData.Tables["Tasks"].AsEnumerable()
                    where task.Field<Int32>("SubcategoryID") == Convert.ToInt32(subcategoryIDclicked)
                    select task;

                //use this query result as a view and sent to subcat datagridview
                DataView view = query.AsDataView();
                tasksBindingSource.DataSource = view;
                tasksGridView.Columns[2].Visible = false;
                tasksGridView.Columns[3].Visible = false;
                tasksGridView.Columns[4].Visible = false;
                tasksGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                tasksGridView.Columns[0].Width = 80;
                tasksGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                tasksGridView.Columns[5].Width = 40;
            }
        }
    }
}
