namespace FlatRate.Forms
{
    partial class PartDeleteWarning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartDeleteWarning));
            this.TasksCountLabel = new System.Windows.Forms.Label();
            this.TasksLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProceedButton = new System.Windows.Forms.Button();
            this.CancelDeletionButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksCountLabel
            // 
            this.TasksCountLabel.AutoSize = true;
            this.TasksCountLabel.Location = new System.Drawing.Point(12, 9);
            this.TasksCountLabel.Name = "TasksCountLabel";
            this.TasksCountLabel.Size = new System.Drawing.Size(276, 13);
            this.TasksCountLabel.TabIndex = 0;
            this.TasksCountLabel.Text = "The parts will also be removed from the following X tasks:";
            // 
            // TasksLabel
            // 
            this.TasksLabel.AutoSize = true;
            this.TasksLabel.Location = new System.Drawing.Point(3, 0);
            this.TasksLabel.Name = "TasksLabel";
            this.TasksLabel.Size = new System.Drawing.Size(35, 13);
            this.TasksLabel.TabIndex = 1;
            this.TasksLabel.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.TasksLabel);
            this.panel1.Location = new System.Drawing.Point(15, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 154);
            this.panel1.TabIndex = 2;
            // 
            // ProceedButton
            // 
            this.ProceedButton.Location = new System.Drawing.Point(15, 217);
            this.ProceedButton.Name = "ProceedButton";
            this.ProceedButton.Size = new System.Drawing.Size(103, 23);
            this.ProceedButton.TabIndex = 3;
            this.ProceedButton.Text = "Proceed Anyway";
            this.ProceedButton.UseVisualStyleBackColor = true;
            this.ProceedButton.Click += new System.EventHandler(this.ProceedButton_Click);
            // 
            // CancelDeletionButton
            // 
            this.CancelDeletionButton.Location = new System.Drawing.Point(213, 217);
            this.CancelDeletionButton.Name = "CancelDeletionButton";
            this.CancelDeletionButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDeletionButton.TabIndex = 4;
            this.CancelDeletionButton.Text = "Cancel";
            this.CancelDeletionButton.UseVisualStyleBackColor = true;
            this.CancelDeletionButton.Click += new System.EventHandler(this.CancelDeletionButton_Click);
            // 
            // PartDeleteWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 252);
            this.Controls.Add(this.CancelDeletionButton);
            this.Controls.Add(this.ProceedButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TasksCountLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartDeleteWarning";
            this.Text = "Warning: Parts Deletion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TasksCountLabel;
        private System.Windows.Forms.Label TasksLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ProceedButton;
        private System.Windows.Forms.Button CancelDeletionButton;
    }
}