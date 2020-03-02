namespace FlatRate
{
    partial class Form1
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
            this.openPartsListDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.btnAddPartToTask = new System.Windows.Forms.Button();
            this.jobEditBox = new System.Windows.Forms.GroupBox();
            this.txtBoxSubcategory = new System.Windows.Forms.TextBox();
            this.lblTaskSubcategory = new System.Windows.Forms.Label();
            this.txtBoxTaskCategory = new System.Windows.Forms.TextBox();
            this.lblTaskCategory = new System.Windows.Forms.Label();
            this.txtBoxTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.lblPremiumDollars = new System.Windows.Forms.Label();
            this.lblStandardDollars = new System.Windows.Forms.Label();
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
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partUnitCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partSubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsGroupBox = new System.Windows.Forms.GroupBox();
            this.partsGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.btnDeleteSelectedTask = new System.Windows.Forms.Button();
            this.btnLoadTaskList = new System.Windows.Forms.Button();
            this.btnSaveTaskList = new System.Windows.Forms.Button();
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.taskIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partsCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standardTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.premiumTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveTaskListDialog = new System.Windows.Forms.SaveFileDialog();
            this.exportPDFDialog = new System.Windows.Forms.SaveFileDialog();
            this.openTaskListDialog = new System.Windows.Forms.OpenFileDialog();
            this.jobEditBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPartsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskRowBindingSource)).BeginInit();
            this.partsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            this.taskGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
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
            this.jobEditBox.Controls.Add(this.txtBoxSubcategory);
            this.jobEditBox.Controls.Add(this.lblTaskSubcategory);
            this.jobEditBox.Controls.Add(this.txtBoxTaskCategory);
            this.jobEditBox.Controls.Add(this.lblTaskCategory);
            this.jobEditBox.Controls.Add(this.txtBoxTaskID);
            this.jobEditBox.Controls.Add(this.lblTaskID);
            this.jobEditBox.Controls.Add(this.lblPremiumDollars);
            this.jobEditBox.Controls.Add(this.lblStandardDollars);
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
            this.jobEditBox.Location = new System.Drawing.Point(12, 12);
            this.jobEditBox.Name = "jobEditBox";
            this.jobEditBox.Size = new System.Drawing.Size(459, 325);
            this.jobEditBox.TabIndex = 1;
            this.jobEditBox.TabStop = false;
            this.jobEditBox.Text = "Edit Task";
            // 
            // txtBoxSubcategory
            // 
            this.txtBoxSubcategory.Location = new System.Drawing.Point(251, 48);
            this.txtBoxSubcategory.Name = "txtBoxSubcategory";
            this.txtBoxSubcategory.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSubcategory.TabIndex = 20;
            this.txtBoxSubcategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxSubcategory_Validating);
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
            // txtBoxTaskCategory
            // 
            this.txtBoxTaskCategory.Location = new System.Drawing.Point(251, 21);
            this.txtBoxTaskCategory.Name = "txtBoxTaskCategory";
            this.txtBoxTaskCategory.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTaskCategory.TabIndex = 18;
            this.txtBoxTaskCategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxTaskCategory_Validating);
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
            this.txtBoxTaskID.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxTaskID_Validating);
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
            // lblPremiumDollars
            // 
            this.lblPremiumDollars.AutoSize = true;
            this.lblPremiumDollars.Location = new System.Drawing.Point(373, 296);
            this.lblPremiumDollars.Name = "lblPremiumDollars";
            this.lblPremiumDollars.Size = new System.Drawing.Size(34, 13);
            this.lblPremiumDollars.TabIndex = 13;
            this.lblPremiumDollars.Text = "$0.00";
            // 
            // lblStandardDollars
            // 
            this.lblStandardDollars.AutoSize = true;
            this.lblStandardDollars.Location = new System.Drawing.Point(226, 296);
            this.lblStandardDollars.Name = "lblStandardDollars";
            this.lblStandardDollars.Size = new System.Drawing.Size(34, 13);
            this.lblStandardDollars.TabIndex = 11;
            this.lblStandardDollars.Text = "$0.00";
            // 
            // lblPartsDollars
            // 
            this.lblPartsDollars.AutoSize = true;
            this.lblPartsDollars.Location = new System.Drawing.Point(16, 296);
            this.lblPartsDollars.Name = "lblPartsDollars";
            this.lblPartsDollars.Size = new System.Drawing.Size(34, 13);
            this.lblPartsDollars.TabIndex = 7;
            this.lblPartsDollars.Text = "$0.00";
            // 
            // lblPremiumTotal
            // 
            this.lblPremiumTotal.AutoSize = true;
            this.lblPremiumTotal.Location = new System.Drawing.Point(370, 268);
            this.lblPremiumTotal.Name = "lblPremiumTotal";
            this.lblPremiumTotal.Size = new System.Drawing.Size(74, 13);
            this.lblPremiumTotal.TabIndex = 12;
            this.lblPremiumTotal.Text = "Premium Total";
            // 
            // lblStandardTotal
            // 
            this.lblStandardTotal.AutoSize = true;
            this.lblStandardTotal.Location = new System.Drawing.Point(223, 268);
            this.lblStandardTotal.Name = "lblStandardTotal";
            this.lblStandardTotal.Size = new System.Drawing.Size(77, 13);
            this.lblStandardTotal.TabIndex = 10;
            this.lblStandardTotal.Text = "Standard Total";
            // 
            // txtBoxHoursEntry
            // 
            this.txtBoxHoursEntry.Location = new System.Drawing.Point(128, 296);
            this.txtBoxHoursEntry.Name = "txtBoxHoursEntry";
            this.txtBoxHoursEntry.Size = new System.Drawing.Size(47, 20);
            this.txtBoxHoursEntry.TabIndex = 3;
            this.txtBoxHoursEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxHoursEntry_KeyDown);
            this.txtBoxHoursEntry.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxHoursEntry_Validating);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(125, 268);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 8;
            this.lblHours.Text = "Hours";
            // 
            // lblPartsSub
            // 
            this.lblPartsSub.AutoSize = true;
            this.lblPartsSub.Location = new System.Drawing.Point(13, 268);
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
            this.btnClearFields.Location = new System.Drawing.Point(373, 14);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(75, 23);
            this.btnClearFields.TabIndex = 5;
            this.btnClearFields.Text = "Clear All";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Location = new System.Drawing.Point(373, 41);
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
            this.txtBoxTaskDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxTaskDescription_Validating);
            // 
            // txtBoxTaskTitle
            // 
            this.txtBoxTaskTitle.Location = new System.Drawing.Point(71, 48);
            this.txtBoxTaskTitle.Name = "txtBoxTaskTitle";
            this.txtBoxTaskTitle.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTaskTitle.TabIndex = 1;
            this.txtBoxTaskTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxTaskTitle_Validating);
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
            this.taskPartsGridView.AutoGenerateColumns = false;
            this.taskPartsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.taskPartsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskPartsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partNameDataGridViewTextBoxColumn,
            this.partDescriptionDataGridViewTextBoxColumn,
            this.partUnitCostDataGridViewTextBoxColumn,
            this.partQuantityDataGridViewTextBoxColumn,
            this.partSubtotalDataGridViewTextBoxColumn});
            this.taskPartsGridView.DataSource = this.taskRowBindingSource;
            this.taskPartsGridView.Location = new System.Drawing.Point(16, 98);
            this.taskPartsGridView.Name = "taskPartsGridView";
            this.taskPartsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskPartsGridView.Size = new System.Drawing.Size(428, 163);
            this.taskPartsGridView.TabIndex = 5;
            this.taskPartsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskPartsGridView_CellEndEdit);
            this.taskPartsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.taskPartsGridView_CellFormatting);
            this.taskPartsGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.taskPartsGridView_CellValidating);
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            this.partNameDataGridViewTextBoxColumn.DataPropertyName = "partName";
            this.partNameDataGridViewTextBoxColumn.HeaderText = "name";
            this.partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            this.partNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.partNameDataGridViewTextBoxColumn.Width = 58;
            // 
            // partDescriptionDataGridViewTextBoxColumn
            // 
            this.partDescriptionDataGridViewTextBoxColumn.DataPropertyName = "partDescription";
            this.partDescriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.partDescriptionDataGridViewTextBoxColumn.Name = "partDescriptionDataGridViewTextBoxColumn";
            this.partDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.partDescriptionDataGridViewTextBoxColumn.Width = 83;
            // 
            // partUnitCostDataGridViewTextBoxColumn
            // 
            this.partUnitCostDataGridViewTextBoxColumn.DataPropertyName = "partUnitCost";
            this.partUnitCostDataGridViewTextBoxColumn.HeaderText = "unit cost";
            this.partUnitCostDataGridViewTextBoxColumn.Name = "partUnitCostDataGridViewTextBoxColumn";
            this.partUnitCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.partUnitCostDataGridViewTextBoxColumn.Width = 72;
            // 
            // partQuantityDataGridViewTextBoxColumn
            // 
            this.partQuantityDataGridViewTextBoxColumn.DataPropertyName = "partQuantity";
            this.partQuantityDataGridViewTextBoxColumn.HeaderText = "quantity";
            this.partQuantityDataGridViewTextBoxColumn.Name = "partQuantityDataGridViewTextBoxColumn";
            this.partQuantityDataGridViewTextBoxColumn.Width = 69;
            // 
            // partSubtotalDataGridViewTextBoxColumn
            // 
            this.partSubtotalDataGridViewTextBoxColumn.DataPropertyName = "partSubtotal";
            this.partSubtotalDataGridViewTextBoxColumn.HeaderText = "subtotal";
            this.partSubtotalDataGridViewTextBoxColumn.Name = "partSubtotalDataGridViewTextBoxColumn";
            this.partSubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.partSubtotalDataGridViewTextBoxColumn.Width = 69;
            // 
            // taskRowBindingSource
            // 
            this.taskRowBindingSource.DataSource = typeof(FlatRate.TaskRow);
            // 
            // partsGroupBox
            // 
            this.partsGroupBox.Controls.Add(this.partsGridView);
            this.partsGroupBox.Controls.Add(this.btnLoadCSV);
            this.partsGroupBox.Controls.Add(this.btnAddPartToTask);
            this.partsGroupBox.Location = new System.Drawing.Point(477, 12);
            this.partsGroupBox.Name = "partsGroupBox";
            this.partsGroupBox.Size = new System.Drawing.Size(388, 325);
            this.partsGroupBox.TabIndex = 0;
            this.partsGroupBox.TabStop = false;
            this.partsGroupBox.Text = "Parts List";
            // 
            // partsGridView
            // 
            this.partsGridView.AllowUserToAddRows = false;
            this.partsGridView.AllowUserToDeleteRows = false;
            this.partsGridView.AutoGenerateColumns = false;
            this.partsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.partsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.descriptionDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.partsGridView.DataSource = this.partBindingSource;
            this.partsGridView.Location = new System.Drawing.Point(6, 48);
            this.partsGridView.Name = "partsGridView";
            this.partsGridView.ReadOnly = true;
            this.partsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsGridView.Size = new System.Drawing.Size(368, 271);
            this.partsGridView.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "partID";
            this.Column1.HeaderText = "name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 58;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 83;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 55;
            // 
            // partBindingSource
            // 
            this.partBindingSource.DataSource = typeof(FlatRate.Part);
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Controls.Add(this.btnExportToPDF);
            this.taskGroupBox.Controls.Add(this.btnDeleteSelectedTask);
            this.taskGroupBox.Controls.Add(this.btnLoadTaskList);
            this.taskGroupBox.Controls.Add(this.btnSaveTaskList);
            this.taskGroupBox.Controls.Add(this.tasksGridView);
            this.taskGroupBox.Location = new System.Drawing.Point(12, 343);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(853, 314);
            this.taskGroupBox.TabIndex = 2;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Task List";
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Location = new System.Drawing.Point(364, 16);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(143, 23);
            this.btnExportToPDF.TabIndex = 4;
            this.btnExportToPDF.Text = "Export Task List to PDF";
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // btnDeleteSelectedTask
            // 
            this.btnDeleteSelectedTask.Location = new System.Drawing.Point(217, 16);
            this.btnDeleteSelectedTask.Name = "btnDeleteSelectedTask";
            this.btnDeleteSelectedTask.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteSelectedTask.TabIndex = 3;
            this.btnDeleteSelectedTask.Text = "Delete Selected Task";
            this.btnDeleteSelectedTask.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedTask.Click += new System.EventHandler(this.btnDeleteSelectedTask_Click);
            // 
            // btnLoadTaskList
            // 
            this.btnLoadTaskList.Location = new System.Drawing.Point(115, 16);
            this.btnLoadTaskList.Name = "btnLoadTaskList";
            this.btnLoadTaskList.Size = new System.Drawing.Size(95, 23);
            this.btnLoadTaskList.TabIndex = 2;
            this.btnLoadTaskList.Text = "Load Task List";
            this.btnLoadTaskList.UseVisualStyleBackColor = true;
            this.btnLoadTaskList.Click += new System.EventHandler(this.btnLoadTaskList_Click);
            // 
            // btnSaveTaskList
            // 
            this.btnSaveTaskList.Location = new System.Drawing.Point(6, 16);
            this.btnSaveTaskList.Name = "btnSaveTaskList";
            this.btnSaveTaskList.Size = new System.Drawing.Size(102, 23);
            this.btnSaveTaskList.TabIndex = 1;
            this.btnSaveTaskList.Text = "Save Task List";
            this.btnSaveTaskList.UseVisualStyleBackColor = true;
            this.btnSaveTaskList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSaveTaskList_MouseClick);
            // 
            // tasksGridView
            // 
            this.tasksGridView.AllowUserToAddRows = false;
            this.tasksGridView.AllowUserToDeleteRows = false;
            this.tasksGridView.AutoGenerateColumns = false;
            this.tasksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskIDDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn1,
            this.category,
            this.subcategory,
            this.hoursDataGridViewTextBoxColumn,
            this.partsCostDataGridViewTextBoxColumn,
            this.standardTotalDataGridViewTextBoxColumn,
            this.premiumTotalDataGridViewTextBoxColumn});
            this.tasksGridView.DataSource = this.taskBindingSource;
            this.tasksGridView.Location = new System.Drawing.Point(7, 45);
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.ReadOnly = true;
            this.tasksGridView.Size = new System.Drawing.Size(832, 263);
            this.tasksGridView.TabIndex = 0;
            this.tasksGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasksGridView_CellDoubleClick);
            this.tasksGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tasksGridView_CellFormatting);
            // 
            // taskIDDataGridViewTextBoxColumn
            // 
            this.taskIDDataGridViewTextBoxColumn.DataPropertyName = "taskID";
            this.taskIDDataGridViewTextBoxColumn.HeaderText = "taskID";
            this.taskIDDataGridViewTextBoxColumn.Name = "taskIDDataGridViewTextBoxColumn";
            this.taskIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // category
            // 
            this.category.DataPropertyName = "categoryName";
            this.category.HeaderText = "category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // subcategory
            // 
            this.subcategory.DataPropertyName = "subcategory";
            this.subcategory.HeaderText = "subcategory";
            this.subcategory.Name = "subcategory";
            this.subcategory.ReadOnly = true;
            // 
            // hoursDataGridViewTextBoxColumn
            // 
            this.hoursDataGridViewTextBoxColumn.DataPropertyName = "hours";
            this.hoursDataGridViewTextBoxColumn.HeaderText = "hours";
            this.hoursDataGridViewTextBoxColumn.Name = "hoursDataGridViewTextBoxColumn";
            this.hoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partsCostDataGridViewTextBoxColumn
            // 
            this.partsCostDataGridViewTextBoxColumn.DataPropertyName = "partsCost";
            this.partsCostDataGridViewTextBoxColumn.HeaderText = "partsCost";
            this.partsCostDataGridViewTextBoxColumn.Name = "partsCostDataGridViewTextBoxColumn";
            this.partsCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // standardTotalDataGridViewTextBoxColumn
            // 
            this.standardTotalDataGridViewTextBoxColumn.DataPropertyName = "standardTotal";
            this.standardTotalDataGridViewTextBoxColumn.HeaderText = "standardTotal";
            this.standardTotalDataGridViewTextBoxColumn.Name = "standardTotalDataGridViewTextBoxColumn";
            this.standardTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // premiumTotalDataGridViewTextBoxColumn
            // 
            this.premiumTotalDataGridViewTextBoxColumn.DataPropertyName = "premiumTotal";
            this.premiumTotalDataGridViewTextBoxColumn.HeaderText = "premiumTotal";
            this.premiumTotalDataGridViewTextBoxColumn.Name = "premiumTotalDataGridViewTextBoxColumn";
            this.premiumTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof(FlatRate.Task);
            // 
            // saveTaskListDialog
            // 
            this.saveTaskListDialog.DefaultExt = "csv";
            this.saveTaskListDialog.Filter = "Comma-Separated Values (*.csv) | *.csv";
            this.saveTaskListDialog.Title = "Save Task List to CSV";
            // 
            // exportPDFDialog
            // 
            this.exportPDFDialog.DefaultExt = "pdf";
            this.exportPDFDialog.Filter = "PDF (*.pdf) | *.pdf";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 669);
            this.Controls.Add(this.taskGroupBox);
            this.Controls.Add(this.partsGroupBox);
            this.Controls.Add(this.jobEditBox);
            this.Name = "Form1";
            this.Text = "FlatRate w datasets";
            this.jobEditBox.ResumeLayout(false);
            this.jobEditBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPartsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskRowBindingSource)).EndInit();
            this.partsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            this.taskGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partUnitCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partSubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.TextBox txtBoxTaskID;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.Button btnDeleteSelectedTask;
        private System.Windows.Forms.Button btnLoadTaskList;
        private System.Windows.Forms.Button btnSaveTaskList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.SaveFileDialog saveTaskListDialog;
        private System.Windows.Forms.Button btnExportToPDF;
        private System.Windows.Forms.SaveFileDialog exportPDFDialog;
        private System.Windows.Forms.OpenFileDialog openTaskListDialog;
        private System.Windows.Forms.TextBox txtBoxSubcategory;
        private System.Windows.Forms.Label lblTaskSubcategory;
        private System.Windows.Forms.TextBox txtBoxTaskCategory;
        private System.Windows.Forms.Label lblTaskCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn subcategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partsCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn standardTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn premiumTotalDataGridViewTextBoxColumn;
    }
}

