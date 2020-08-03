namespace FlatRate
{
    partial class CategoriesForm
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
            this.categoryGridView = new System.Windows.Forms.DataGridView();
            this.subcategoryGridView = new System.Windows.Forms.DataGridView();
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lblSubcategories = new System.Windows.Forms.Label();
            this.lblTasksPerSub = new System.Windows.Forms.Label();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnAddSubcategory = new System.Windows.Forms.Button();
            this.lblAddCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subcategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddSubcategory = new System.Windows.Forms.Label();
            this.txtSubcategory = new System.Windows.Forms.TextBox();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.categoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryGridView
            // 
            this.categoryGridView.AllowUserToAddRows = false;
            this.categoryGridView.AllowUserToDeleteRows = false;
            this.categoryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryGridView.Location = new System.Drawing.Point(12, 69);
            this.categoryGridView.MultiSelect = false;
            this.categoryGridView.Name = "categoryGridView";
            this.categoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoryGridView.Size = new System.Drawing.Size(253, 369);
            this.categoryGridView.TabIndex = 0;
            this.categoryGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.categoryGridView_CellClick);
            // 
            // subcategoryGridView
            // 
            this.subcategoryGridView.AllowUserToAddRows = false;
            this.subcategoryGridView.AllowUserToDeleteRows = false;
            this.subcategoryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subcategoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subcategoryGridView.Location = new System.Drawing.Point(304, 69);
            this.subcategoryGridView.MultiSelect = false;
            this.subcategoryGridView.Name = "subcategoryGridView";
            this.subcategoryGridView.Size = new System.Drawing.Size(256, 369);
            this.subcategoryGridView.TabIndex = 1;
            this.subcategoryGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subcategoryGridView_CellClick);
            // 
            // tasksGridView
            // 
            this.tasksGridView.AllowUserToAddRows = false;
            this.tasksGridView.AllowUserToDeleteRows = false;
            this.tasksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tasksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView.Location = new System.Drawing.Point(596, 29);
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.ReadOnly = true;
            this.tasksGridView.Size = new System.Drawing.Size(304, 409);
            this.tasksGridView.TabIndex = 2;
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(58, 18);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(57, 13);
            this.lblCategories.TabIndex = 3;
            this.lblCategories.Text = "Categories";
            // 
            // lblSubcategories
            // 
            this.lblSubcategories.AutoSize = true;
            this.lblSubcategories.Location = new System.Drawing.Point(301, 9);
            this.lblSubcategories.Name = "lblSubcategories";
            this.lblSubcategories.Size = new System.Drawing.Size(75, 13);
            this.lblSubcategories.TabIndex = 4;
            this.lblSubcategories.Text = "Subcategories";
            // 
            // lblTasksPerSub
            // 
            this.lblTasksPerSub.AutoSize = true;
            this.lblTasksPerSub.Location = new System.Drawing.Point(731, 9);
            this.lblTasksPerSub.Name = "lblTasksPerSub";
            this.lblTasksPerSub.Size = new System.Drawing.Size(36, 13);
            this.lblTasksPerSub.TabIndex = 5;
            this.lblTasksPerSub.Text = "Tasks";
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.Location = new System.Drawing.Point(203, 43);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(62, 23);
            this.btnNewCategory.TabIndex = 6;
            this.btnNewCategory.Text = "Add";
            this.btnNewCategory.UseVisualStyleBackColor = true;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(157, 13);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(95, 23);
            this.btnDeleteCategory.TabIndex = 7;
            this.btnDeleteCategory.Text = "Delete Selected";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnAddSubcategory
            // 
            this.btnAddSubcategory.Location = new System.Drawing.Point(509, 40);
            this.btnAddSubcategory.Name = "btnAddSubcategory";
            this.btnAddSubcategory.Size = new System.Drawing.Size(51, 23);
            this.btnAddSubcategory.TabIndex = 9;
            this.btnAddSubcategory.Text = "Add";
            this.btnAddSubcategory.UseVisualStyleBackColor = true;
            this.btnAddSubcategory.Click += new System.EventHandler(this.btnAddSubcategory_Click);
            // 
            // lblAddCategory
            // 
            this.lblAddCategory.AutoSize = true;
            this.lblAddCategory.Location = new System.Drawing.Point(13, 47);
            this.lblAddCategory.Name = "lblAddCategory";
            this.lblAddCategory.Size = new System.Drawing.Size(74, 13);
            this.lblAddCategory.TabIndex = 10;
            this.lblAddCategory.Text = "Add Category:";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(84, 45);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 20);
            this.txtCategory.TabIndex = 11;
            this.txtCategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategory_Validating);
            // 
            // lblAddSubcategory
            // 
            this.lblAddSubcategory.AutoSize = true;
            this.lblAddSubcategory.Location = new System.Drawing.Point(304, 45);
            this.lblAddSubcategory.Name = "lblAddSubcategory";
            this.lblAddSubcategory.Size = new System.Drawing.Size(92, 13);
            this.lblAddSubcategory.TabIndex = 12;
            this.lblAddSubcategory.Text = "Add Subcategory:";
            // 
            // txtSubcategory
            // 
            this.txtSubcategory.Location = new System.Drawing.Point(402, 42);
            this.txtSubcategory.Name = "txtSubcategory";
            this.txtSubcategory.Size = new System.Drawing.Size(100, 20);
            this.txtSubcategory.TabIndex = 13;
            this.txtSubcategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtSubcategory_Validating);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 457);
            this.Controls.Add(this.txtSubcategory);
            this.Controls.Add(this.lblAddSubcategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblAddCategory);
            this.Controls.Add(this.btnAddSubcategory);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnNewCategory);
            this.Controls.Add(this.lblTasksPerSub);
            this.Controls.Add(this.lblSubcategories);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.tasksGridView);
            this.Controls.Add(this.subcategoryGridView);
            this.Controls.Add(this.categoryGridView);
            this.Name = "CategoriesForm";
            this.Text = "Categories";
            ((System.ComponentModel.ISupportInitialize)(this.categoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView categoryGridView;
        private System.Windows.Forms.DataGridView subcategoryGridView;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label lblSubcategories;
        private System.Windows.Forms.Label lblTasksPerSub;
        private System.Windows.Forms.Button btnNewCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnAddSubcategory;
        private System.Windows.Forms.Label lblAddCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private System.Windows.Forms.BindingSource subcategoriesBindingSource;
        private System.Windows.Forms.Label lblAddSubcategory;
        private System.Windows.Forms.TextBox txtSubcategory;
        private System.Windows.Forms.BindingSource tasksBindingSource;
    }
}