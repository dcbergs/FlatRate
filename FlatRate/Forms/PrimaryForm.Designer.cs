namespace FlatRate
{
    partial class PrimaryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryForm));
            this.openPartsListDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.btnAddPartToTask = new System.Windows.Forms.Button();
            this.jobEditBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPremiumDollars = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStandardDollars = new System.Windows.Forms.Label();
            this.txtBoxPremAdd = new System.Windows.Forms.TextBox();
            this.lblAddPrem = new System.Windows.Forms.Label();
            this.lblAddStd = new System.Windows.Forms.Label();
            this.txtBoxStdAdd = new System.Windows.Forms.TextBox();
            this.comboSubcategory = new System.Windows.Forms.ComboBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.lblTaskSubcategory = new System.Windows.Forms.Label();
            this.lblTaskCategory = new System.Windows.Forms.Label();
            this.txtBoxTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.lblPartsDollars = new System.Windows.Forms.Label();
            this.lblPremiumTotal = new System.Windows.Forms.Label();
            this.lblStandardTotal = new System.Windows.Forms.Label();
            this.txtBoxHoursEntry = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblPartsSub = new System.Windows.Forms.Label();
            this.btnRemovePartsFromTask = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.btnSaveTask = new System.Windows.Forms.Button();
            this.txtBoxTaskDescription = new System.Windows.Forms.TextBox();
            this.txtBoxTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.taskPartsGridView = new System.Windows.Forms.DataGridView();
            this.partsGroupBox = new System.Windows.Forms.GroupBox();
            this.labelSearchParts = new System.Windows.Forms.Label();
            this.txtBoxSearchParts = new System.Windows.Forms.TextBox();
            this.partsGridView = new System.Windows.Forms.DataGridView();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.btnEditSelectedTasks = new System.Windows.Forms.Button();
            this.btnExportToCSV = new System.Windows.Forms.Button();
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.btnDeleteSelectedTask = new System.Windows.Forms.Button();
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadDataDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveTaskCsvDialog = new System.Windows.Forms.SaveFileDialog();
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDeleteParts = new System.Windows.Forms.Button();
            this.jobEditBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPartsGridView)).BeginInit();
            this.partsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).BeginInit();
            this.taskGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openPartsListDialog
            // 
            this.openPartsListDialog.FileName = "partsfile.csv";
            this.openPartsListDialog.Filter = "CSV Files (*.csv) | *.csv";
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.Location = new System.Drawing.Point(6, 19);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCSV.TabIndex = 0;
            this.btnLoadCSV.Text = "Load Parts";
            this.btnLoadCSV.UseVisualStyleBackColor = true;
            this.btnLoadCSV.Click += new System.EventHandler(this.btnLoadCSV_Click);
            // 
            // btnAddPartToTask
            // 
            this.btnAddPartToTask.Location = new System.Drawing.Point(105, 19);
            this.btnAddPartToTask.Name = "btnAddPartToTask";
            this.btnAddPartToTask.Size = new System.Drawing.Size(197, 23);
            this.btnAddPartToTask.TabIndex = 2;
            this.btnAddPartToTask.Text = "Add Selected Part(s) to Current Task";
            this.btnAddPartToTask.UseVisualStyleBackColor = true;
            this.btnAddPartToTask.Click += new System.EventHandler(this.btnAddPartToJob_Click);
            // 
            // jobEditBox
            // 
            this.jobEditBox.Controls.Add(this.tableLayoutPanel2);
            this.jobEditBox.Controls.Add(this.tableLayoutPanel1);
            this.jobEditBox.Controls.Add(this.txtBoxPremAdd);
            this.jobEditBox.Controls.Add(this.lblAddPrem);
            this.jobEditBox.Controls.Add(this.lblAddStd);
            this.jobEditBox.Controls.Add(this.txtBoxStdAdd);
            this.jobEditBox.Controls.Add(this.comboSubcategory);
            this.jobEditBox.Controls.Add(this.comboCategory);
            this.jobEditBox.Controls.Add(this.lblTaskSubcategory);
            this.jobEditBox.Controls.Add(this.lblTaskCategory);
            this.jobEditBox.Controls.Add(this.txtBoxTaskID);
            this.jobEditBox.Controls.Add(this.lblTaskID);
            this.jobEditBox.Controls.Add(this.lblPartsDollars);
            this.jobEditBox.Controls.Add(this.lblPremiumTotal);
            this.jobEditBox.Controls.Add(this.lblStandardTotal);
            this.jobEditBox.Controls.Add(this.txtBoxHoursEntry);
            this.jobEditBox.Controls.Add(this.lblHours);
            this.jobEditBox.Controls.Add(this.lblPartsSub);
            this.jobEditBox.Controls.Add(this.btnRemovePartsFromTask);
            this.jobEditBox.Controls.Add(this.btnClearFields);
            this.jobEditBox.Controls.Add(this.btnSaveTask);
            this.jobEditBox.Controls.Add(this.txtBoxTaskDescription);
            this.jobEditBox.Controls.Add(this.txtBoxTaskTitle);
            this.jobEditBox.Controls.Add(this.lblTaskDescription);
            this.jobEditBox.Controls.Add(this.lblTaskTitle);
            this.jobEditBox.Controls.Add(this.taskPartsGridView);
            this.jobEditBox.Location = new System.Drawing.Point(12, 27);
            this.jobEditBox.Name = "jobEditBox";
            this.jobEditBox.Size = new System.Drawing.Size(459, 369);
            this.jobEditBox.TabIndex = 1;
            this.jobEditBox.TabStop = false;
            this.jobEditBox.Text = "Edit Task";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblPremiumDollars, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(311, 347);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(62, 20);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // lblPremiumDollars
            // 
            this.lblPremiumDollars.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPremiumDollars.AutoSize = true;
            this.lblPremiumDollars.Location = new System.Drawing.Point(28, 3);
            this.lblPremiumDollars.Margin = new System.Windows.Forms.Padding(0);
            this.lblPremiumDollars.Name = "lblPremiumDollars";
            this.lblPremiumDollars.Size = new System.Drawing.Size(34, 13);
            this.lblPremiumDollars.TabIndex = 13;
            this.lblPremiumDollars.Text = "$0.00";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblStandardDollars, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(170, 347);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(62, 20);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // lblStandardDollars
            // 
            this.lblStandardDollars.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStandardDollars.AutoSize = true;
            this.lblStandardDollars.Location = new System.Drawing.Point(28, 3);
            this.lblStandardDollars.Margin = new System.Windows.Forms.Padding(0);
            this.lblStandardDollars.Name = "lblStandardDollars";
            this.lblStandardDollars.Size = new System.Drawing.Size(34, 13);
            this.lblStandardDollars.TabIndex = 11;
            this.lblStandardDollars.Text = "$0.00";
            // 
            // txtBoxPremAdd
            // 
            this.txtBoxPremAdd.Location = new System.Drawing.Point(396, 347);
            this.txtBoxPremAdd.Name = "txtBoxPremAdd";
            this.txtBoxPremAdd.Size = new System.Drawing.Size(47, 20);
            this.txtBoxPremAdd.TabIndex = 26;
            this.txtBoxPremAdd.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPremAdd_Validating);
            // 
            // lblAddPrem
            // 
            this.lblAddPrem.AutoSize = true;
            this.lblAddPrem.Location = new System.Drawing.Point(377, 350);
            this.lblAddPrem.Name = "lblAddPrem";
            this.lblAddPrem.Size = new System.Drawing.Size(13, 13);
            this.lblAddPrem.TabIndex = 25;
            this.lblAddPrem.Text = "+";
            // 
            // lblAddStd
            // 
            this.lblAddStd.AutoSize = true;
            this.lblAddStd.Location = new System.Drawing.Point(234, 350);
            this.lblAddStd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblAddStd.Name = "lblAddStd";
            this.lblAddStd.Size = new System.Drawing.Size(13, 13);
            this.lblAddStd.TabIndex = 24;
            this.lblAddStd.Text = "+";
            // 
            // txtBoxStdAdd
            // 
            this.txtBoxStdAdd.Location = new System.Drawing.Point(253, 347);
            this.txtBoxStdAdd.Name = "txtBoxStdAdd";
            this.txtBoxStdAdd.Size = new System.Drawing.Size(50, 20);
            this.txtBoxStdAdd.TabIndex = 23;
            this.txtBoxStdAdd.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxStdAdd_Validating);
            // 
            // comboSubcategory
            // 
            this.comboSubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSubcategory.FormattingEnabled = true;
            this.comboSubcategory.Location = new System.Drawing.Point(250, 48);
            this.comboSubcategory.Name = "comboSubcategory";
            this.comboSubcategory.Size = new System.Drawing.Size(121, 21);
            this.comboSubcategory.TabIndex = 22;
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(237, 20);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(121, 21);
            this.comboCategory.TabIndex = 21;
            this.comboCategory.SelectionChangeCommitted += new System.EventHandler(this.comboCategory_SelectionChangeCommitted);
            // 
            // lblTaskSubcategory
            // 
            this.lblTaskSubcategory.AutoSize = true;
            this.lblTaskSubcategory.Location = new System.Drawing.Point(177, 51);
            this.lblTaskSubcategory.Name = "lblTaskSubcategory";
            this.lblTaskSubcategory.Size = new System.Drawing.Size(67, 13);
            this.lblTaskSubcategory.TabIndex = 19;
            this.lblTaskSubcategory.Text = "Subcategory";
            // 
            // lblTaskCategory
            // 
            this.lblTaskCategory.AutoSize = true;
            this.lblTaskCategory.Location = new System.Drawing.Point(177, 24);
            this.lblTaskCategory.Name = "lblTaskCategory";
            this.lblTaskCategory.Size = new System.Drawing.Size(49, 13);
            this.lblTaskCategory.TabIndex = 17;
            this.lblTaskCategory.Text = "Category";
            // 
            // txtBoxTaskID
            // 
            this.txtBoxTaskID.Location = new System.Drawing.Point(71, 21);
            this.txtBoxTaskID.Name = "txtBoxTaskID";
            this.txtBoxTaskID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTaskID.TabIndex = 0;
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Location = new System.Drawing.Point(6, 24);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(18, 13);
            this.lblTaskID.TabIndex = 16;
            this.lblTaskID.Text = "ID";
            // 
            // lblPartsDollars
            // 
            this.lblPartsDollars.AutoSize = true;
            this.lblPartsDollars.Location = new System.Drawing.Point(6, 350);
            this.lblPartsDollars.Name = "lblPartsDollars";
            this.lblPartsDollars.Size = new System.Drawing.Size(34, 13);
            this.lblPartsDollars.TabIndex = 7;
            this.lblPartsDollars.Text = "$0.00";
            // 
            // lblPremiumTotal
            // 
            this.lblPremiumTotal.AutoSize = true;
            this.lblPremiumTotal.Location = new System.Drawing.Point(348, 327);
            this.lblPremiumTotal.Name = "lblPremiumTotal";
            this.lblPremiumTotal.Size = new System.Drawing.Size(74, 13);
            this.lblPremiumTotal.TabIndex = 12;
            this.lblPremiumTotal.Text = "Premium Total";
            // 
            // lblStandardTotal
            // 
            this.lblStandardTotal.AutoSize = true;
            this.lblStandardTotal.Location = new System.Drawing.Point(203, 327);
            this.lblStandardTotal.Name = "lblStandardTotal";
            this.lblStandardTotal.Size = new System.Drawing.Size(77, 13);
            this.lblStandardTotal.TabIndex = 10;
            this.lblStandardTotal.Text = "Standard Total";
            // 
            // txtBoxHoursEntry
            // 
            this.txtBoxHoursEntry.Location = new System.Drawing.Point(113, 347);
            this.txtBoxHoursEntry.Name = "txtBoxHoursEntry";
            this.txtBoxHoursEntry.Size = new System.Drawing.Size(47, 20);
            this.txtBoxHoursEntry.TabIndex = 3;
            this.txtBoxHoursEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxHoursEntry_KeyDown);
            this.txtBoxHoursEntry.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxHoursEntry_Validating);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(110, 327);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 8;
            this.lblHours.Text = "Hours";
            // 
            // lblPartsSub
            // 
            this.lblPartsSub.AutoSize = true;
            this.lblPartsSub.Location = new System.Drawing.Point(6, 327);
            this.lblPartsSub.Name = "lblPartsSub";
            this.lblPartsSub.Size = new System.Drawing.Size(58, 13);
            this.lblPartsSub.TabIndex = 6;
            this.lblPartsSub.Text = "Parts Total";
            // 
            // btnRemovePartsFromTask
            // 
            this.btnRemovePartsFromTask.Location = new System.Drawing.Point(225, 72);
            this.btnRemovePartsFromTask.Name = "btnRemovePartsFromTask";
            this.btnRemovePartsFromTask.Size = new System.Drawing.Size(185, 23);
            this.btnRemovePartsFromTask.TabIndex = 15;
            this.btnRemovePartsFromTask.Text = "Remove Selected Part(s) from Task";
            this.btnRemovePartsFromTask.UseVisualStyleBackColor = true;
            this.btnRemovePartsFromTask.Click += new System.EventHandler(this.btnRemovePartsFromTask_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(378, 48);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(75, 23);
            this.btnClearFields.TabIndex = 5;
            this.btnClearFields.Text = "Clear All";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Location = new System.Drawing.Point(369, 19);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTask.TabIndex = 4;
            this.btnSaveTask.Text = "Save Task";
            this.btnSaveTask.UseVisualStyleBackColor = true;
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // txtBoxTaskDescription
            // 
            this.txtBoxTaskDescription.Location = new System.Drawing.Point(71, 74);
            this.txtBoxTaskDescription.Name = "txtBoxTaskDescription";
            this.txtBoxTaskDescription.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTaskDescription.TabIndex = 2;
            // 
            // txtBoxTaskTitle
            // 
            this.txtBoxTaskTitle.Location = new System.Drawing.Point(71, 48);
            this.txtBoxTaskTitle.Name = "txtBoxTaskTitle";
            this.txtBoxTaskTitle.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTaskTitle.TabIndex = 1;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoSize = true;
            this.lblTaskDescription.Location = new System.Drawing.Point(4, 77);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(60, 13);
            this.lblTaskDescription.TabIndex = 3;
            this.lblTaskDescription.Text = "Description";
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.Location = new System.Drawing.Point(6, 51);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTaskTitle.TabIndex = 1;
            this.lblTaskTitle.Text = "Title";
            // 
            // taskPartsGridView
            // 
            this.taskPartsGridView.AllowUserToAddRows = false;
            this.taskPartsGridView.AllowUserToDeleteRows = false;
            this.taskPartsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskPartsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskPartsGridView.Location = new System.Drawing.Point(6, 98);
            this.taskPartsGridView.Name = "taskPartsGridView";
            this.taskPartsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskPartsGridView.Size = new System.Drawing.Size(447, 226);
            this.taskPartsGridView.TabIndex = 5;
            this.taskPartsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskPartsGridView_CellEndEdit);
            this.taskPartsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.taskPartsGridView_CellFormatting);
            this.taskPartsGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.taskPartsGridView_CellValidating);
            // 
            // partsGroupBox
            // 
            this.partsGroupBox.Controls.Add(this.btnDeleteParts);
            this.partsGroupBox.Controls.Add(this.labelSearchParts);
            this.partsGroupBox.Controls.Add(this.txtBoxSearchParts);
            this.partsGroupBox.Controls.Add(this.partsGridView);
            this.partsGroupBox.Controls.Add(this.btnLoadCSV);
            this.partsGroupBox.Controls.Add(this.btnAddPartToTask);
            this.partsGroupBox.Location = new System.Drawing.Point(477, 27);
            this.partsGroupBox.Name = "partsGroupBox";
            this.partsGroupBox.Size = new System.Drawing.Size(388, 369);
            this.partsGroupBox.TabIndex = 0;
            this.partsGroupBox.TabStop = false;
            this.partsGroupBox.Text = "Parts List";
            // 
            // labelSearchParts
            // 
            this.labelSearchParts.AutoSize = true;
            this.labelSearchParts.Location = new System.Drawing.Point(6, 51);
            this.labelSearchParts.Name = "labelSearchParts";
            this.labelSearchParts.Size = new System.Drawing.Size(44, 13);
            this.labelSearchParts.TabIndex = 4;
            this.labelSearchParts.Text = "Search:";
            // 
            // txtBoxSearchParts
            // 
            this.txtBoxSearchParts.Location = new System.Drawing.Point(56, 48);
            this.txtBoxSearchParts.Name = "txtBoxSearchParts";
            this.txtBoxSearchParts.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSearchParts.TabIndex = 3;
            this.txtBoxSearchParts.TextChanged += new System.EventHandler(this.txtBoxSearchParts_TextChanged);
            this.txtBoxSearchParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSearchParts_KeyDown);
            // 
            // partsGridView
            // 
            this.partsGridView.AllowUserToAddRows = false;
            this.partsGridView.AllowUserToDeleteRows = false;
            this.partsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsGridView.Location = new System.Drawing.Point(6, 75);
            this.partsGridView.Name = "partsGridView";
            this.partsGridView.ReadOnly = true;
            this.partsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsGridView.Size = new System.Drawing.Size(376, 288);
            this.partsGridView.TabIndex = 1;
            this.partsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.partsGridView_CellFormatting);
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Controls.Add(this.btnEditSelectedTasks);
            this.taskGroupBox.Controls.Add(this.btnExportToCSV);
            this.taskGroupBox.Controls.Add(this.btnExportToPDF);
            this.taskGroupBox.Controls.Add(this.btnDeleteSelectedTask);
            this.taskGroupBox.Controls.Add(this.tasksGridView);
            this.taskGroupBox.Location = new System.Drawing.Point(12, 402);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(853, 231);
            this.taskGroupBox.TabIndex = 2;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Task List";
            // 
            // btnEditSelectedTasks
            // 
            this.btnEditSelectedTasks.Location = new System.Drawing.Point(154, 16);
            this.btnEditSelectedTasks.Name = "btnEditSelectedTasks";
            this.btnEditSelectedTasks.Size = new System.Drawing.Size(149, 23);
            this.btnEditSelectedTasks.TabIndex = 6;
            this.btnEditSelectedTasks.Text = "Group Edit Selected Task(s)";
            this.btnEditSelectedTasks.UseVisualStyleBackColor = true;
            this.btnEditSelectedTasks.Click += new System.EventHandler(this.btnEditSelectedTasks_Click);
            // 
            // btnExportToCSV
            // 
            this.btnExportToCSV.Location = new System.Drawing.Point(710, 16);
            this.btnExportToCSV.Name = "btnExportToCSV";
            this.btnExportToCSV.Size = new System.Drawing.Size(137, 23);
            this.btnExportToCSV.TabIndex = 5;
            this.btnExportToCSV.Text = "Export Task List to CSV";
            this.btnExportToCSV.UseVisualStyleBackColor = true;
            this.btnExportToCSV.Click += new System.EventHandler(this.btnExportToCSV_Click);
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Location = new System.Drawing.Point(561, 16);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(143, 23);
            this.btnExportToPDF.TabIndex = 4;
            this.btnExportToPDF.Text = "Export Task List to PDF";
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // btnDeleteSelectedTask
            // 
            this.btnDeleteSelectedTask.Location = new System.Drawing.Point(9, 16);
            this.btnDeleteSelectedTask.Name = "btnDeleteSelectedTask";
            this.btnDeleteSelectedTask.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteSelectedTask.TabIndex = 3;
            this.btnDeleteSelectedTask.Text = "Delete Selected Task(s)";
            this.btnDeleteSelectedTask.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedTask.Click += new System.EventHandler(this.btnDeleteSelectedTask_Click);
            // 
            // tasksGridView
            // 
            this.tasksGridView.AllowUserToAddRows = false;
            this.tasksGridView.AllowUserToDeleteRows = false;
            this.tasksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tasksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView.Location = new System.Drawing.Point(7, 45);
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.ReadOnly = true;
            this.tasksGridView.Size = new System.Drawing.Size(840, 177);
            this.tasksGridView.TabIndex = 0;
            this.tasksGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasksGridView_CellDoubleClick);
            this.tasksGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tasksGridView_CellFormatting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewToolStripMenuItem,
            this.saveAllDataToolStripMenuItem,
            this.loadDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startNewToolStripMenuItem
            // 
            this.startNewToolStripMenuItem.Name = "startNewToolStripMenuItem";
            this.startNewToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.startNewToolStripMenuItem.Text = "Start New";
            this.startNewToolStripMenuItem.Click += new System.EventHandler(this.startNewToolStripMenuItem_Click);
            // 
            // saveAllDataToolStripMenuItem
            // 
            this.saveAllDataToolStripMenuItem.Name = "saveAllDataToolStripMenuItem";
            this.saveAllDataToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAllDataToolStripMenuItem.Text = "Save Data...";
            this.saveAllDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadDataToolStripMenuItem.Text = "Load Data...";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem,
            this.ratesToolStripMenuItem});
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.Size = new System.Drawing.Size(39, 20);
            this.toolStripEdit.Text = "Edit";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // ratesToolStripMenuItem
            // 
            this.ratesToolStripMenuItem.Name = "ratesToolStripMenuItem";
            this.ratesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ratesToolStripMenuItem.Text = "Rates";
            this.ratesToolStripMenuItem.Click += new System.EventHandler(this.ratesToolStripMenuItem_Click);
            // 
            // saveDataDialog
            // 
            this.saveDataDialog.DefaultExt = "xml";
            this.saveDataDialog.Filter = "XML (*.xml) | *.xml";
            // 
            // saveTaskCsvDialog
            // 
            this.saveTaskCsvDialog.Filter = "CSV (*.csv) | *.csv";
            // 
            // btnDeleteParts
            // 
            this.btnDeleteParts.Location = new System.Drawing.Point(172, 46);
            this.btnDeleteParts.Name = "btnDeleteParts";
            this.btnDeleteParts.Size = new System.Drawing.Size(130, 23);
            this.btnDeleteParts.TabIndex = 5;
            this.btnDeleteParts.Text = "Delete Selected Part(s)";
            this.btnDeleteParts.UseVisualStyleBackColor = true;
            this.btnDeleteParts.Click += new System.EventHandler(this.btnDeleteParts_Click);
            // 
            // PrimaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 633);
            this.Controls.Add(this.taskGroupBox);
            this.Controls.Add(this.partsGroupBox);
            this.Controls.Add(this.jobEditBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrimaryForm";
            this.Text = "Favinger FlatRate";
            this.jobEditBox.ResumeLayout(false);
            this.jobEditBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPartsGridView)).EndInit();
            this.partsGroupBox.ResumeLayout(false);
            this.partsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).EndInit();
            this.taskGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openPartsListDialog;
        private System.Windows.Forms.Button btnLoadCSV;
        private System.Windows.Forms.BindingSource partBindingSource;
        private System.Windows.Forms.Button btnAddPartToTask;
        private System.Windows.Forms.BindingSource taskRowBindingSource;
        private System.Windows.Forms.GroupBox jobEditBox;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.Button btnSaveTask;
        private System.Windows.Forms.TextBox txtBoxTaskDescription;
        private System.Windows.Forms.TextBox txtBoxTaskTitle;
        private System.Windows.Forms.Label lblTaskDescription;
        private System.Windows.Forms.Label lblTaskTitle;
        private System.Windows.Forms.DataGridView taskPartsGridView;
        private System.Windows.Forms.GroupBox partsGroupBox;
        private System.Windows.Forms.DataGridView partsGridView;
        private System.Windows.Forms.Button btnRemovePartsFromTask;
        private System.Windows.Forms.Label lblPremiumDollars;
        private System.Windows.Forms.Label lblStandardDollars;
        private System.Windows.Forms.Label lblPartsDollars;
        private System.Windows.Forms.Label lblPremiumTotal;
        private System.Windows.Forms.Label lblStandardTotal;
        private System.Windows.Forms.TextBox txtBoxHoursEntry;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblPartsSub;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.TextBox txtBoxTaskID;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.Button btnDeleteSelectedTask;
        private System.Windows.Forms.Button btnExportToPDF;
        private System.Windows.Forms.Label lblTaskSubcategory;
        private System.Windows.Forms.Label lblTaskCategory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripEdit;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllDataToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboSubcategory;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private System.Windows.Forms.TextBox txtBoxSearchParts;
        private System.Windows.Forms.Label labelSearchParts;
        private System.Windows.Forms.ToolStripMenuItem ratesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveDataDialog;
        private System.Windows.Forms.OpenFileDialog loadDataDialog;
        private System.Windows.Forms.TextBox txtBoxPremAdd;
        private System.Windows.Forms.Label lblAddPrem;
        private System.Windows.Forms.Label lblAddStd;
        private System.Windows.Forms.TextBox txtBoxStdAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExportToCSV;
        private System.Windows.Forms.SaveFileDialog saveTaskCsvDialog;
        private System.Windows.Forms.Button btnEditSelectedTasks;
        private System.Windows.Forms.ToolStripMenuItem startNewToolStripMenuItem;
        private System.Windows.Forms.Button btnDeleteParts;
    }
}

