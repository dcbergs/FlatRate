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
        private PartList partList = new PartList();
        private Task newTask = new Task();
        private List<Task> taskList = new List<Task>();
        private CultureInfo ci = new CultureInfo("en-us");
        ErrorProvider errorProvider1 = new ErrorProvider();
        private string[] forbiddenNames = {"taskid", "title", "description", "hours", "partsCost", "standardtotal", "premiumtotal",
                                    "partname", "partdescription", "partunitcost", "partquantity", "partsubtotal",
                                    "name", "unitprice", "category", "subcategory"};
        private Dictionary<string, Category> categories = new Dictionary<string, Category>();

        public Form1()
        {
            InitializeComponent();
            errorProvider1.SetIconAlignment(txtBoxHoursEntry, ErrorIconAlignment.MiddleRight);
        }

        //LOAD CSV OF PARTS
        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            if(openPartsListDialog.ShowDialog() == DialogResult.OK &&
                openPartsListDialog.FileName != "")
            {
                //this is where csv data comes in
                try
                {
                    //read csv input and put into partList object
                    readInput partsInput = new readInput(openPartsListDialog.FileName);
                    partList = partsInput.generatePartsList(partList);
                    partBindingSource.Clear();

                    foreach(KeyValuePair<string, Part> kvp in partList.partList)
                    {
                        partBindingSource.Add(kvp.Value);
                    }
                }
                catch(Exception except)
                {
                    Console.WriteLine("error reading file");
                    Console.WriteLine(except.Message);
                }
                //update all tasks in task list with new pricing, where applicable
                foreach(Task task in taskList)
                {
                    foreach(TaskRow taskRow in task.taskParts)
                    {
                        Part temp;
                        if(partList.partList.TryGetValue(taskRow.partName, out temp))
                        {
                            taskRow.partUnitCost = temp.price;
                        }
                    }
                    //update total task prices after all parts are updated
                    task.calculateCosts();
                }
                tasksGridView.Refresh();
            }
        }

        //LOAD CSV OF TASKS
        private void btnLoadTaskList_Click(object sender, EventArgs e)
        {
            if (openTaskListDialog.ShowDialog() == DialogResult.OK &&
                openTaskListDialog.FileName != "")
            {
                try
                {
                    //read csv input and put into taskList
                    readInput tasksInput = new readInput(openTaskListDialog.FileName);
                    taskList = tasksInput.loadTaskList(categories);
                    taskBindingSource.Clear();

                    foreach (Task task in taskList)
                    {
                        taskBindingSource.Add(task);
                    }

                    //do I need to taskGridView.Refresh()?

                }
                catch(Exception except)
                {
                    Console.WriteLine("error reading task list");
                    Console.WriteLine(except.Message);
                }
            }
        }

        //ADD AND REMOVE PARTS FROM CURRENT TASK
        private void btnAddPartToJob_Click(object sender, EventArgs e)
        {
            //find selected part in part list, if any, and add to current task in new/edit task field
            if(partsGridView.SelectedRows != null)
            {
                //generate taskRow for selected parts and add to newTask and task data view
                for(int i = 0; i < partsGridView.SelectedRows.Count; i++)
                {
                    //get info from parts, do not pass if name matches something already in task part list
                    //or if name matches already, add one to quantity?
                    bool duplicate = false;
                    string newName = (string)partsGridView.SelectedRows[i].Cells[0].Value;
                    for(int j = 0; j < newTask.taskParts.Count; j++)
                    {
                        if (newName.Equals(newTask.taskParts[j].partName))
                        {
                            duplicate = true;
                            newTask.taskParts[j].partQuantity += 1;
                            taskPartsGridView.Refresh();
                        }
                    }
                    //if not a duplicate part, add it to task part list
                    if (!duplicate)
                    {
                        string newDescription = (string)partsGridView.SelectedRows[i].Cells[1].Value;
                        float newCost = (float)partsGridView.SelectedRows[i].Cells[2].Value;

                        TaskRow newRow = new TaskRow(newName, newDescription, newCost);
                        taskRowBindingSource.Add(newRow);
                        newTask.addComponent(newRow);
                    }
                    
                }

                //update total costs
                updateCosts();

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
                newTask.taskParts.Remove((TaskRow)taskRowBindingSource[index]);
                taskRowBindingSource.RemoveAt(index);
            }

            updateCosts();
        }

        //INTERNAL USE FOR UPDATING
        private void updateCosts()
        {
            lblPartsDollars.Text = newTask.partsCost.ToString("C", ci);
            lblStandardDollars.Text = newTask.standardTotal.ToString("C", ci);
            lblPremiumDollars.Text = newTask.premiumTotal.ToString("C", ci);
        }

        private void updateTaskFields()
        {
            txtBoxTaskID.Text = newTask.taskID;
            txtBoxTaskTitle.Text = newTask.title;
            txtBoxTaskDescription.Text = newTask.description;
            txtBoxTaskCategory.Text = newTask.category.categoryName;
            txtBoxSubcategory.Text = newTask.subcategory.name;
            txtBoxHoursEntry.Text = newTask.hours.ToString();
            taskRowBindingSource.Clear();

            for(int i = 0; i < newTask.taskParts.Count; i++)
            {
                taskRowBindingSource.Add(newTask.taskParts[i]);
            }
        }

        //used for editing part quantity in current task
        private void taskPartsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateCosts();
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
                newTask.hours = entry;
                errorProvider1.SetError(txtBoxHoursEntry, "");
                updateCosts();
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

        //format subtotal column to only show two decimal places
        private void taskPartsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 4)
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

        //save new task to task list if enough information is provided and replace it with an empty task
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

            if (String.IsNullOrWhiteSpace(txtBoxTaskCategory.Text))
            {
                errorState = true;
                errorProvider1.SetError(txtBoxTaskCategory, "Please enter a category");
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

                //check if task ID already exists in table, ask to overwrite
                string tempTaskID = txtBoxTaskID.Text;
                bool overwrite = true; //defaults to true so you can save something unless it is a duplicate
                for(int i = 0; i < taskList.Count; i++)
                {
                    if(tempTaskID == taskList[i].taskID)
                    {
                        overwrite = false; //it's a duplicate, so don't overwrite by default
                        string title = "Duplicate Task ID";
                        string message = "This task ID has been used. Overwrite task?";
                        var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(result == DialogResult.Yes)
                        {
                            overwrite = true;
                        }
                    }
                }

                if (overwrite)
                {
                    for(int i = 0; i < taskList.Count; i++)
                    {
                        if(taskList[i].taskID == tempTaskID)
                        {
                            //somehow this gets called twice sometimes even without duplicate taskIDs....
                            taskBindingSource.Remove(taskList[i]);
                            //...try breaking out of for loop if this gets called:
                            i = taskList.Count;
                        }
                    }

                    //make sure categories list includes it if new
                    if (!categories.ContainsKey(newTask.categoryName))
                    {
                        categories.Add(newTask.categoryName, newTask.category);
                    }
                    if (!String.IsNullOrWhiteSpace(newTask.subcategory.name))
                    {
                        categories[newTask.categoryName].addSubcategory(newTask.subcategory.name);
                    }

                    //add newTask to taskList
                    taskList.Add(newTask);

                    //update UI
                    taskBindingSource.Add(newTask);
                    taskRowBindingSource.Clear();
                    txtBoxTaskID.Text = "";
                    txtBoxHoursEntry.Text = "";
                    txtBoxTaskTitle.Text = "";
                    txtBoxTaskDescription.Text = "";
                    txtBoxTaskCategory.Text = "";
                    txtBoxSubcategory.Text = "";

                    //a new newTask
                    newTask = new Task();
                    updateCosts();
                }
            }
        }

        //VALIDATE NEW TASK INFO INDIVIDUALLY
        private void txtBoxTaskTitle_Validating(object sender, CancelEventArgs e)
        {
            bool errorState = false;
            foreach (string term in forbiddenNames)
            {
                if (String.Equals(txtBoxTaskTitle.Text, term, StringComparison.OrdinalIgnoreCase))
                {
                    errorState = true;
                    errorProvider1.SetError(txtBoxTaskTitle, "Forbidden name!");
                }
            }
            if (!errorState)
            {
                newTask.title = txtBoxTaskTitle.Text;
                errorProvider1.SetError(txtBoxTaskTitle, "");
            }
        }

        private void txtBoxTaskDescription_Validating(object sender, CancelEventArgs e)
        {
            bool errorState = false;
            foreach (string term in forbiddenNames)
            {
                if (String.Equals(txtBoxTaskDescription.Text, term, StringComparison.OrdinalIgnoreCase))
                {
                    errorState = true;
                    errorProvider1.SetError(txtBoxTaskDescription, "Forbidden name!");
                }
            }
            if (!errorState)
            {
                newTask.description = txtBoxTaskDescription.Text;
                errorProvider1.SetError(txtBoxTaskDescription, "");
            }
        }

        private void txtBoxTaskID_Validating(object sender, CancelEventArgs e)
        {
            bool errorState = false;
            foreach (string term in forbiddenNames)
            {
                if (String.Equals(txtBoxTaskID.Text, term, StringComparison.OrdinalIgnoreCase))
                {
                    errorState = true;
                    errorProvider1.SetError(txtBoxTaskID, "Forbidden name!");
                }
            }
            if (!errorState)
            {
                newTask.taskID = txtBoxTaskID.Text;
                errorProvider1.SetError(txtBoxTaskID, "");
            }
        }

        //validate category
        private void txtBoxTaskCategory_Validating(object sender, CancelEventArgs e)
        {
            bool errorState = false;
            foreach (string term in forbiddenNames)
            {
                if (String.Equals(txtBoxTaskCategory.Text, term, StringComparison.OrdinalIgnoreCase))
                {
                    errorState = true;
                    errorProvider1.SetError(txtBoxTaskCategory, "Forbidden name!");
                }
            }
            if (!errorState)
            {
                newTask.category = new Category(txtBoxTaskCategory.Text);
                errorProvider1.SetError(txtBoxTaskCategory, "");
            }
        }

        //validate subcategory
        private void txtBoxSubcategory_Validating(object sender, CancelEventArgs e)
        {
            bool errorState = false;
            foreach (string term in forbiddenNames)
            {
                if (String.Equals(txtBoxSubcategory.Text, term, StringComparison.OrdinalIgnoreCase))
                {
                    errorState = true;
                    errorProvider1.SetError(txtBoxSubcategory, "Forbidden name!");
                }
            }
            if (!errorState)
            {
                newTask.subcategory = new Subcategory(txtBoxSubcategory.Text);
                errorProvider1.SetError(txtBoxSubcategory, "");
            }
        }

        //bring up a given job in the new/edit task box
        private void tasksGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //need to send this by value ("clone" the task) so it doesn't update task in task list from new/edit task portion
            //otherwise, changing info in new/edit task portion automatically changes task in task list too
            newTask = new Task((Task)(((DataGridView)sender).Rows[e.RowIndex].DataBoundItem));
            updateTaskFields();
            updateCosts();
        }

        //save task lists to csv file
        private void btnSaveTaskList_MouseClick(object sender, MouseEventArgs e)
        {
            if(saveTaskListDialog.ShowDialog() == DialogResult.OK && saveTaskListDialog.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveTaskListDialog.FileName))
                {
                    OutputTasks output = new OutputTasks(sw);
                    output.writeTaskList(taskList);
                }
            }
            else
            {
                //error with file name/dialog box?
            }
        }

        //export task list to pdf
        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            if (exportPDFDialog.ShowDialog() == DialogResult.OK && exportPDFDialog.FileName != "")
            {
                OutputBook outputBook = new OutputBook(exportPDFDialog.FileName);
                outputBook.writeBook(categories, taskList);
            }
            else
            {
                //error with file name/dialog box?
            }
        }

        //just clears fields in newTask, does not actually delete the task
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            newTask = new Task();
            updateTaskFields();
            updateCosts();
        }

        //deletes task in task list
        private void btnDeleteSelectedTask_Click(object sender, EventArgs e)
        {
            //find selected tasks in task list, if any, and remove them
            HashSet<int> rows = new HashSet<int>();
            foreach(DataGridViewCell cell in tasksGridView.SelectedCells)
            {
                rows.Add(cell.RowIndex);
            }
            foreach(int index in rows)
            {
                taskList.Remove((Task)taskBindingSource[index]);
                taskBindingSource.RemoveAt(index);
            }
        }

    }
}
