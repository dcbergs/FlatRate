namespace FlatRate.Forms
{
    partial class MultiEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiEdit));
            this.numberOfTasksLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.subcategoryLabel = new System.Windows.Forms.Label();
            this.subcategoryComboBox = new System.Windows.Forms.ComboBox();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.HoursTextBox = new System.Windows.Forms.TextBox();
            this.HoursAddCheckBox = new System.Windows.Forms.CheckBox();
            this.standardAddCheckBox = new System.Windows.Forms.CheckBox();
            this.standardLabel = new System.Windows.Forms.Label();
            this.premiumLabel = new System.Windows.Forms.Label();
            this.standardTextBox = new System.Windows.Forms.TextBox();
            this.premiumTextBox = new System.Windows.Forms.TextBox();
            this.premiumCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.changeCategoryCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // numberOfTasksLabel
            // 
            this.numberOfTasksLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numberOfTasksLabel.AutoSize = true;
            this.numberOfTasksLabel.Location = new System.Drawing.Point(25, 9);
            this.numberOfTasksLabel.Name = "numberOfTasksLabel";
            this.numberOfTasksLabel.Size = new System.Drawing.Size(171, 13);
            this.numberOfTasksLabel.TabIndex = 0;
            this.numberOfTasksLabel.Text = "Changes will be applied to X tasks:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(25, 55);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 1;
            this.categoryLabel.Text = "Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(119, 52);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryComboBox.TabIndex = 2;
            this.categoryComboBox.SelectionChangeCommitted += new System.EventHandler(this.categoryComboBox_SelectionChangeCommitted);
            // 
            // subcategoryLabel
            // 
            this.subcategoryLabel.AutoSize = true;
            this.subcategoryLabel.Location = new System.Drawing.Point(25, 82);
            this.subcategoryLabel.Name = "subcategoryLabel";
            this.subcategoryLabel.Size = new System.Drawing.Size(67, 13);
            this.subcategoryLabel.TabIndex = 3;
            this.subcategoryLabel.Text = "Subcategory";
            // 
            // subcategoryComboBox
            // 
            this.subcategoryComboBox.FormattingEnabled = true;
            this.subcategoryComboBox.Location = new System.Drawing.Point(119, 79);
            this.subcategoryComboBox.Name = "subcategoryComboBox";
            this.subcategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.subcategoryComboBox.TabIndex = 4;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(25, 122);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(35, 13);
            this.hoursLabel.TabIndex = 7;
            this.hoursLabel.Text = "Hours";
            // 
            // HoursTextBox
            // 
            this.HoursTextBox.Location = new System.Drawing.Point(119, 119);
            this.HoursTextBox.Name = "HoursTextBox";
            this.HoursTextBox.Size = new System.Drawing.Size(121, 20);
            this.HoursTextBox.TabIndex = 8;
            this.HoursTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.HoursTextBox_Validating);
            // 
            // HoursAddCheckBox
            // 
            this.HoursAddCheckBox.AutoSize = true;
            this.HoursAddCheckBox.Location = new System.Drawing.Point(28, 145);
            this.HoursAddCheckBox.Name = "HoursAddCheckBox";
            this.HoursAddCheckBox.Size = new System.Drawing.Size(212, 17);
            this.HoursAddCheckBox.TabIndex = 10;
            this.HoursAddCheckBox.Text = "add to existing hours (default is replace)";
            this.HoursAddCheckBox.UseVisualStyleBackColor = true;
            // 
            // standardAddCheckBox
            // 
            this.standardAddCheckBox.AutoSize = true;
            this.standardAddCheckBox.Location = new System.Drawing.Point(28, 205);
            this.standardAddCheckBox.Name = "standardAddCheckBox";
            this.standardAddCheckBox.Size = new System.Drawing.Size(219, 17);
            this.standardAddCheckBox.TabIndex = 11;
            this.standardAddCheckBox.Text = "add to existing add-on (default is replace)";
            this.standardAddCheckBox.UseVisualStyleBackColor = true;
            // 
            // standardLabel
            // 
            this.standardLabel.AutoSize = true;
            this.standardLabel.Location = new System.Drawing.Point(25, 182);
            this.standardLabel.Name = "standardLabel";
            this.standardLabel.Size = new System.Drawing.Size(89, 13);
            this.standardLabel.TabIndex = 12;
            this.standardLabel.Text = "Standard Add-On";
            // 
            // premiumLabel
            // 
            this.premiumLabel.AutoSize = true;
            this.premiumLabel.Location = new System.Drawing.Point(25, 240);
            this.premiumLabel.Name = "premiumLabel";
            this.premiumLabel.Size = new System.Drawing.Size(86, 13);
            this.premiumLabel.TabIndex = 13;
            this.premiumLabel.Text = "Premium Add-On";
            // 
            // standardTextBox
            // 
            this.standardTextBox.Location = new System.Drawing.Point(128, 179);
            this.standardTextBox.Name = "standardTextBox";
            this.standardTextBox.Size = new System.Drawing.Size(112, 20);
            this.standardTextBox.TabIndex = 14;
            this.standardTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AddOn_Validating);
            // 
            // premiumTextBox
            // 
            this.premiumTextBox.Location = new System.Drawing.Point(128, 237);
            this.premiumTextBox.Name = "premiumTextBox";
            this.premiumTextBox.Size = new System.Drawing.Size(112, 20);
            this.premiumTextBox.TabIndex = 15;
            this.premiumTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AddOn_Validating);
            // 
            // premiumCheckBox
            // 
            this.premiumCheckBox.AutoSize = true;
            this.premiumCheckBox.Location = new System.Drawing.Point(28, 263);
            this.premiumCheckBox.Name = "premiumCheckBox";
            this.premiumCheckBox.Size = new System.Drawing.Size(219, 17);
            this.premiumCheckBox.TabIndex = 16;
            this.premiumCheckBox.Text = "add to existing add-on (default is replace)";
            this.premiumCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 295);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Update Tasks";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(165, 295);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // changeCategoryCheckBox
            // 
            this.changeCategoryCheckBox.AutoSize = true;
            this.changeCategoryCheckBox.Location = new System.Drawing.Point(28, 34);
            this.changeCategoryCheckBox.Name = "changeCategoryCheckBox";
            this.changeCategoryCheckBox.Size = new System.Drawing.Size(173, 17);
            this.changeCategoryCheckBox.TabIndex = 19;
            this.changeCategoryCheckBox.Text = "Change Category/Subcategory";
            this.changeCategoryCheckBox.UseVisualStyleBackColor = true;
            this.changeCategoryCheckBox.CheckedChanged += new System.EventHandler(this.changeCategoryCheckBox_CheckedChanged);
            // 
            // MultiEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 335);
            this.Controls.Add(this.changeCategoryCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.premiumCheckBox);
            this.Controls.Add(this.premiumTextBox);
            this.Controls.Add(this.standardTextBox);
            this.Controls.Add(this.premiumLabel);
            this.Controls.Add(this.standardLabel);
            this.Controls.Add(this.standardAddCheckBox);
            this.Controls.Add(this.HoursAddCheckBox);
            this.Controls.Add(this.HoursTextBox);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.subcategoryComboBox);
            this.Controls.Add(this.subcategoryLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.numberOfTasksLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiEdit";
            this.Text = "FlatRate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberOfTasksLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label subcategoryLabel;
        private System.Windows.Forms.ComboBox subcategoryComboBox;
        private System.Windows.Forms.TextBox HoursTextBox;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.CheckBox HoursAddCheckBox;
        private System.Windows.Forms.CheckBox standardAddCheckBox;
        private System.Windows.Forms.Label standardLabel;
        private System.Windows.Forms.Label premiumLabel;
        private System.Windows.Forms.TextBox standardTextBox;
        private System.Windows.Forms.TextBox premiumTextBox;
        private System.Windows.Forms.CheckBox premiumCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox changeCategoryCheckBox;
    }
}