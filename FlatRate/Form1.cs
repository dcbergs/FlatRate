using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatRate
{
    public partial class Form1 : Form
    {
        private DataSet flatRateData = new DataSet("FlatRateData");

        //holds parts in the edit/new task field while the task is not yet saved
        private List<TaskRow> temporaryParts = new List<TaskRow>();
        //formatting and error message variables
        private CultureInfo ci = new CultureInfo("en-us");
        ErrorProvider errorProvider1 = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();

            //defines flatRateData with Schema class
            DefineTable();

            Program.STANDARD_RATE = 160;
            Program.PREMIUM_RATE = 180;

            //auto-load data
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FlatRate", "data.xml");

            if (File.Exists(directory))
            {
                flatRateData.ReadXml(directory);
            }

            //set data bindings
            partBindingSource.DataSource = flatRateData.Tables["Parts"];
            partsGridView.DataSource = partBindingSource;
            partsGridView.Columns[0].HeaderText = "Name";
            partsGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            partsGridView.Columns[0].Width = 80;
            partsGridView.Columns[2].HeaderText = "Cost";
            partsGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            partsGridView.Columns[2].Width = 40;

            taskRowBindingSource.DataSource = temporaryParts;
            taskPartsGridView.DataSource = taskRowBindingSource;

            updateTaskListDisplay();

            //category combo box
            comboCategory.DataSource = flatRateData.Tables["Categories"];
            comboCategory.DisplayMember = "Title";
            comboCategory.ValueMember = "ID";

            //setup subcategory combo box
            //get the category selected
            DataRow row = ((DataRowView)comboCategory.SelectedItem).Row;
            //query for appropriate subcategories
            EnumerableRowCollection<DataRow> subcategoryQuery =
                from subcategory in flatRateData.Tables["Subcategories"].AsEnumerable()
                where subcategory.Field<Int32>("CategoryID") == Convert.ToInt32(row["ID"])
                select subcategory;

            DataView view = subcategoryQuery.AsDataView();
            comboSubcategory.DataSource = view;
            comboSubcategory.DisplayMember = "Title";
            comboSubcategory.ValueMember = "ID";
        }

        private void DefineTable()
        {
            Schema schema = new Schema(flatRateData);
            schema.setupData();
        }

        //----------------------------------------------------------------------LOAD CSV OF PARTS--------------------------------
        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            if (openPartsListDialog.ShowDialog() == DialogResult.OK &&
                openPartsListDialog.FileName != "")
            {
                //this is where csv data comes in
                try
                {
                    //read csv input and put into partList object
                    readInput partsInput = new readInput(openPartsListDialog.FileName);
                    partsInput.generatePartsList(flatRateData);
                }
                catch (Exception except)
                {
                    Console.WriteLine("error reading file");
                    Console.WriteLine(except.Message);
                }
                //need to update all job costs
                //might make a variation on this function to return/notify how many tasks/parts were affected
                updateTaskListDisplay();
            }
        }

        //-----------------------------------------------------------ADD AND REMOVE PARTS FROM CURRENT TASK-----------------------
        private void btnAddPartToJob_Click(object sender, EventArgs e)
        {
            //find selected part in part list, if any, and add to current task in new/edit task field
            if (partsGridView.SelectedRows != null)
            {
                //generate taskRow for selected parts
                for (int i = 0; i < partsGridView.SelectedRows.Count; i++)
                {
                    //get info from parts, if name matches a part already in task, add one to quantity
                    bool duplicate = false;
                    string partID = (string)partsGridView.SelectedRows[i].Cells[0].Value;
                    foreach(TaskRow part in temporaryParts)
                    {
                        if (partID.Equals(part.id))
                        {
                            duplicate = true;
                            //add one to quantity
                            part.quantity++;
                        }
                    }
                    taskRowBindingSource.DataSource = null;
                    taskRowBindingSource.DataSource = temporaryParts;
                    //if not a duplicate part, add it to temp part list
                    if (!duplicate)
                    {
                        string newDescription = (string)partsGridView.SelectedRows[i].Cells[1].Value;
                        float newCost = (float)partsGridView.SelectedRows[i].Cells[2].Value;
                        TaskRow newPart = new TaskRow(partID, newDescription, newCost);
                        temporaryParts.Add(newPart);
                        taskRowBindingSource.DataSource = null;
                        taskRowBindingSource.DataSource = temporaryParts;
                    }

                }

                //update total costs
                updateTempCosts();

            }
        }

        private void btnRemovePartsFromTask_Click(object sender, EventArgs e)
        {
            //find selected tasks in task list, if any, and remove them
            HashSet<int> rows = new HashSet<int>();
            foreach (DataGridViewCell cell in taskPartsGridView.SelectedCells)
            {
                rows.Add(cell.RowIndex);
            }
            foreach (int index in rows)
            {
                temporaryParts.Remove((TaskRow)taskRowBindingSource[index]);
                taskRowBindingSource.DataSource = null;
                taskRowBindingSource.DataSource = temporaryParts;
            }

            updateTempCosts();
        }

        //--------------------------------------------------------------------INTERNAL USE FOR UPDATING--------------------------
        private void updateTempCosts()
        {
            float partsCost = 0.0f;
            foreach(TaskRow part in temporaryParts)
            {
                partsCost += part.partSubtotal;
            }
            float hours = 0;
            if(txtBoxHoursEntry.Text != null)
            {
                float.TryParse(txtBoxHoursEntry.Text, out hours);
            }
            float standardTotal = (Program.STANDARD_RATE * hours) + partsCost;
            float premiumTotal = (Program.PREMIUM_RATE * hours) + partsCost;

            lblPartsDollars.Text = partsCost.ToString("C", ci);
            lblStandardDollars.Text = standardTotal.ToString("C", ci);
            lblPremiumDollars.Text = premiumTotal.ToString("C", ci);
        }

        private void emptyTempTaskFields()
        {
            txtBoxTaskID.Text = "";
            txtBoxTaskTitle.Text = "";
            txtBoxTaskDescription.Text = "";
            txtBoxHoursEntry.Text = "";
            taskRowBindingSource.Clear();

            foreach(TaskRow row in temporaryParts)
            {
                taskRowBindingSource.Add(row);
            }
        }

        private void updateTaskListDisplay()
        {
            var taskrows =
                (from task in flatRateData.Tables["Tasks"].AsEnumerable()
                 join taskpart in flatRateData.Tables["Tasks_Parts"].AsEnumerable()
                 on task.Field<String>("ID") equals taskpart.Field<String>("TaskID") into tp
                 select new
                 {
                     id = task.Field<String>("ID"),
                     title = task.Field<String>("Title"),
                     desc = task.Field<String>("Description"),
                     cat = task.GetParentRow("taskCategories").Field<String>("Title"),
                     subcat = task.GetParentRow("taskSubcategories").Field<String>("Title"),
                     hrs = task.Field<float>("Hours"),
                     stdtotal = tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + task.Field<float>("Hours") * Program.STANDARD_RATE,
                     premtotal = tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + task.Field<float>("Hours") * Program.PREMIUM_RATE
                 }).ToList();

            taskBindingSource.DataSource = taskrows;
            tasksGridView.DataSource = taskBindingSource;
        }

        //--------------------------------------------------------------------INPUT VALIDATION-----------------------------------------
        //used for editing part quantity in current task
        private void taskPartsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateTempCosts();
        }

        //event method for exiting/validating quantity in current task
        private void taskPartsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            taskPartsGridView.Rows[e.RowIndex].ErrorText = "";
            //only need to validate if a "quantity" cell is being left
            if(e.ColumnIndex == taskPartsGridView.Columns[3].Index)
            {
                float entry = 0.0f;
                if(!float.TryParse(e.FormattedValue.ToString(), out entry) || entry < 0)
                {
                    e.Cancel = true;
                    taskPartsGridView.Rows[e.RowIndex].ErrorText = "Quantity must be a positive value";
                }
            }
            
        }

        //validate text box hours
        private void txtBoxHoursEntry_Validating(object sender, CancelEventArgs e)
        {
            
            float entry = 0.0f;
            if (!float.TryParse(((TextBox)sender).Text, out entry) || entry < 0)
            {
                errorProvider1.SetError(txtBoxHoursEntry, "Hours must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxHoursEntry, "");
                updateTempCosts();
            }

        }

        //so that enter can be used to escape focus of hours textbox
        //currently disabled
        private void txtBoxHoursEntry_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if(e.KeyCode == Keys.Enter)
            {
                //essentially send it a tab to run validation code
                SendKeys.Send("{TAB}");
            }
            */
        }

        //------------------------------------------------------------------FORMATTING FOR TABLES---------------------------------
        //format subtotal column to only show two decimal places
        private void taskPartsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            taskPartsGridView.Columns[0].HeaderText = "Part ID";
            taskPartsGridView.Columns[0].ReadOnly = true;

            taskPartsGridView.Columns[1].HeaderText = "Description";
            taskPartsGridView.Columns[1].ReadOnly = true;

            taskPartsGridView.Columns[2].HeaderText = "Unit Price";
            taskPartsGridView.Columns[2].ReadOnly = true;

            taskPartsGridView.Columns[3].HeaderText = "Quantity";

            taskPartsGridView.Columns[4].HeaderText = "Subtotal";
            taskPartsGridView.Columns[4].ReadOnly = true;

            if (e.ColumnIndex == 4)
            {
                e.CellStyle.Format = "N2";
            }
        }

        private void tasksGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                e.CellStyle.Format = "N2";
            }
        }

        private void partsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                e.CellStyle.Format = "N2";
            }
        }

        //------------------------------------------------------------------SAVE NEW TASK-----------------------------------------------------
        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            bool errorState = false;
            //check for errors and display error messages
            if (String.IsNullOrWhiteSpace(txtBoxTaskID.Text))
            {
                errorState = true;
                errorProvider1.SetError(txtBoxTaskID, "Please enter a task ID");
            }

            if (String.IsNullOrWhiteSpace(txtBoxTaskTitle.Text))
            {
                errorState = true;
                errorProvider1.SetError(txtBoxTaskTitle, "Please enter a task name");
            }

            if (String.IsNullOrWhiteSpace(txtBoxTaskDescription.Text))
            {
                errorState = true;
                errorProvider1.SetError(txtBoxTaskDescription, "Please enter a description");
            }

            if (String.IsNullOrWhiteSpace(txtBoxHoursEntry.Text))
            {
                txtBoxHoursEntry.Text = "0";
            }

            //if all task info is provided...
            if (!errorState)
            {
                //clear error states
                errorProvider1.SetError(txtBoxTaskID, "");
                errorProvider1.SetError(txtBoxTaskTitle, "");
                errorProvider1.SetError(txtBoxTaskDescription, "");
                errorProvider1.SetError(txtBoxHoursEntry, "");

                //check if task ID already exists in Tasks table to ask to overwrite if needed
                string newID = txtBoxTaskID.Text;

                bool overwrite = true; //default to true so task will be saved unless it's a duplicate
                DataRow row = flatRateData.Tables["Tasks"].Rows.Find(newID);
                if (row != null)
                {
                    overwrite = false; //it's a duplicate, so don't overwrite by default
                    string title = "Duplicate Task ID";
                    string message = "This task ID has been used. Overwrite task?";
                    var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        overwrite = true;
                    }
                }

                if (overwrite)
                {
                    //if duplicate, edit
                    if (row != null)
                    {
                        row["Title"] = txtBoxTaskTitle.Text;
                        row["Description"] = txtBoxTaskDescription.Text;
                        //get category ID from selected category in combo box
                        row["CategoryID"] = ((DataRowView)comboCategory.SelectedItem).Row["ID"];
                        //get subcategory ID from selected subcategory in combo box
                        row["SubcategoryID"] = ((DataRowView)comboSubcategory.SelectedItem).Row["ID"];
                        float test = 0.0f;
                        if(!float.TryParse(txtBoxHoursEntry.Text, out test) || test < 0)
                        {
                            //error
                            Console.WriteLine("Error parsing task hours");
                        }
                        else
                        {
                            row["Hours"] = test;
                        }
                        //also edit tasks_parts
                        //remove prior associations with this Task.ID, if any
                        var toRemove =
                            from taskpart in flatRateData.Tables["Tasks_Parts"].AsEnumerable()
                            where taskpart.Field<string>("TaskID") == newID
                            select taskpart;
                        foreach(var removeRow in toRemove.ToList())
                        {
                            removeRow.Delete();
                        }
                        //add new associations with this Task.ID
                        foreach(TaskRow part in temporaryParts)
                        {
                            DataRow newPart = flatRateData.Tables["Tasks_Parts"].NewRow();
                            newPart["TaskID"] = newID;
                            newPart["PartID"] = part.id;
                            newPart["Quantity"] = part.quantity;
                            flatRateData.Tables["Tasks_Parts"].Rows.Add(newPart);
                        }
                    }
                    //else add new row to Tasks
                    else
                    {
                        //Tasks row
                        DataRow newRow = flatRateData.Tables["Tasks"].NewRow();
                        newRow["ID"] = txtBoxTaskID.Text;
                        newRow["Title"] = txtBoxTaskTitle.Text;
                        newRow["Description"] = txtBoxTaskDescription.Text;
                        //get category ID from selected category in combo box
                        newRow["CategoryID"] = ((DataRowView)comboCategory.SelectedItem).Row["ID"];
                        //get subcategory ID from selected subcategory in combo box
                        newRow["SubcategoryID"] = ((DataRowView)comboSubcategory.SelectedItem).Row["ID"];
                        float test = 0.0f;
                        if (!float.TryParse(txtBoxHoursEntry.Text, out test) || test < 0)
                        {
                            //error
                            Console.WriteLine("Error parsing task hours");
                        }
                        else
                        {
                            newRow["Hours"] = test;
                        }
                        flatRateData.Tables["Tasks"].Rows.Add(newRow);

                        //Tasks_Parts rows
                        foreach (TaskRow part in temporaryParts)
                        {
                            DataRow newPart = flatRateData.Tables["Tasks_Parts"].NewRow();
                            newPart["TaskID"] = newID;
                            newPart["PartID"] = part.id;
                            newPart["Quantity"] = part.quantity;
                            flatRateData.Tables["Tasks_Parts"].Rows.Add(newPart);
                        }

                    }

                    //update UI
                    updateTaskListDisplay();

                    //new/edit task area
                    taskRowBindingSource.Clear();
                    txtBoxTaskID.Text = "";
                    txtBoxHoursEntry.Text = "";
                    txtBoxTaskTitle.Text = "";
                    txtBoxTaskDescription.Text = "";
                    //prolly don't reset category/subcategory so it's quick to make a new task with same specs

                    updateTempCosts();

                }
            }
        }

        //-------------------------------------------------------------------EDIT TASK---------------------------------------------------------
        private void tasksGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                //fill text boxes based on task ID from data table
                string tempID = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
                //task info which can be found tirectly in Tasks table
                txtBoxTaskID.Text = tempID;
                txtBoxTaskTitle.Text = flatRateData.Tables["Tasks"].Rows.Find(tempID).Field<String>("Title");
                txtBoxTaskDescription.Text = flatRateData.Tables["Tasks"].Rows.Find(tempID).Field<String>("Description");
                //combo box selection
                comboCategory.SelectedValue = flatRateData.Tables["Tasks"].Rows.Find(tempID).Field<Int32>("CategoryID");
                //query for appropriate subcategories
                EnumerableRowCollection<DataRow> subcategoryQuery =
                    from subcategory in flatRateData.Tables["Subcategories"].AsEnumerable()
                    where subcategory.Field<Int32>("CategoryID") == flatRateData.Tables["Tasks"].Rows.Find(tempID).Field<Int32>("CategoryID")
                    select subcategory;

                DataView view = subcategoryQuery.AsDataView();
                comboSubcategory.DataSource = view;
                comboSubcategory.DisplayMember = "Title";
                comboSubcategory.ValueMember = "ID";
                comboSubcategory.SelectedValue = flatRateData.Tables["Tasks"].Rows.Find(tempID).Field<Int32>("SubcategoryID");
                txtBoxHoursEntry.Text = flatRateData.Tables["Tasks"].Rows.Find(tempID).Field<float>("Hours").ToString();
                //task parts which need to be found in Tasks_Parts
                //clear temporary parts first
                temporaryParts.Clear();
                //select all rows from tasks_parts belonging to taskID
                var taskpartsquery =
                    from taskparts in flatRateData.Tables["Tasks_Parts"].AsEnumerable()
                    where taskparts.Field<String>("TaskID") == tempID
                    select taskparts;

                //for each row, extract data and make a new TaskRow object
                foreach (DataRow taskpart in taskpartsquery)
                {
                    string newid = taskpart.Field<String>("PartID");
                    string newDescription = taskpart.GetParentRow("taskPartsParts").Field<String>("Description");
                    float newCost = taskpart.GetParentRow("taskPartsParts").Field<float>("UnitPrice");
                    float newQuantity = taskpart.Field<float>("Quantity");
                    TaskRow newPart = new TaskRow(newid, newDescription, newCost, newQuantity);

                    temporaryParts.Add(newPart);
                }
                taskRowBindingSource.DataSource = null;
                taskRowBindingSource.DataSource = temporaryParts;
                updateTempCosts();
            }
            
        }

        //just clears fields in new/edit task, does not actually delete the task if it was selected from grid
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            emptyTempTaskFields();
            updateTempCosts();
        }

        //deletes task in task list
        private void btnDeleteSelectedTask_Click(object sender, EventArgs e)
        {
            //find selected tasks in task list and collect indices
            HashSet<int> rows = new HashSet<int>();
            foreach(DataGridViewCell cell in tasksGridView.SelectedCells)
            {
                rows.Add(cell.RowIndex);
            }
            //for each selected task, remove Tasks_Parts associations and then Tasks row
            foreach (int index in rows)
            {
                string tempID = tasksGridView.Rows[index].Cells[0].Value.ToString();

                //query Tasks_Parts for removal
                EnumerableRowCollection<DataRow> taskspartsquery =
                    from removalRow in flatRateData.Tables["Tasks_Parts"].AsEnumerable()
                    where removalRow.Field<String>("TaskID") == tempID
                    select removalRow;
                flatRateData.Tables["Tasks_Parts"].AcceptChanges();
                foreach (DataRow taskspartsrow in taskspartsquery)
                {
                    taskspartsrow.Delete();
                }
                flatRateData.Tables["Tasks_Parts"].AcceptChanges();

                //remove the task itself
                flatRateData.Tables["Tasks"].Rows.Find(tempID).Delete();
                flatRateData.Tables["Tasks"].AcceptChanges();

                //update binding source
                updateTaskListDisplay();
            }
        }

        //----------------------------------------------------------------------MENU STRIP-----------------------------------------------------
        //let user view and edit categories/subcategories for tasks
        //probably also refresh task gridview after it closes! categories may have changed names
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm categoriesForm = new CategoriesForm(flatRateData);
            categoriesForm.ShowDialog();
        }

        private void saveAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FlatRate");

            System.IO.Directory.CreateDirectory(directory);

            flatRateData.WriteXml(Path.Combine(directory, "data.xml"));

        }

        //updates the subcategory combo box whenever a new category is selected
        private void comboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //get the category selected
            DataRow row = ((DataRowView)comboCategory.SelectedItem).Row;
            //query for appropriate subcategories
            EnumerableRowCollection<DataRow> query =
                from subcategory in flatRateData.Tables["Subcategories"].AsEnumerable()
                where subcategory.Field<Int32>("CategoryID") == Convert.ToInt32(row["ID"])
                select subcategory;

            DataView view = query.AsDataView();
            comboSubcategory.DataSource = view;
            comboSubcategory.DisplayMember = "Title";
        }

        private void ratesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RatesForm ratesForm = new RatesForm();
            ratesForm.ShowDialog();
            //after this is done, update the costs
            updateTaskListDisplay();
        }

        //------------------------------------------------------------------------SEARCH----------------------------------------------------
        private void txtBoxSearchParts_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string searchTerm = txtBoxSearchParts.Text;
                flatRateData.Tables["Parts"].DefaultView.RowFilter = "ID LIKE '%" + searchTerm + "%'";
                flatRateData.Tables["Parts"].DefaultView.RowFilter += "OR Description LIKE '%" + searchTerm + "%'";

            }
        }

        private void txtBoxSearchParts_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBoxSearchParts.Text;
            flatRateData.Tables["Parts"].DefaultView.RowFilter = "ID LIKE '%" + searchTerm + "%'";
            flatRateData.Tables["Parts"].DefaultView.RowFilter += "OR Description LIKE '%" + searchTerm + "%'";
        }

        //----------------------------------------------------------------------EXPORT TO PDF---------------------------------------------
        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            if (exportPDFDialog.ShowDialog() == DialogResult.OK && exportPDFDialog.FileName != "")
            {
                try
                {
                    OutputBook outputBook = new OutputBook(exportPDFDialog.FileName, flatRateData);
                    outputBook.writeBook();
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("This file is already open. Please close the file and try again.", "Error in file access", MessageBoxButtons.OK);
                }
                
            }
            else
            {
                //error with file name/dialog box?
            }
        }

    }
}
