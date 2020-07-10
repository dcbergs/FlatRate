namespace FlatRate
{
    partial class RatesForm
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
            this.lblStandardRate = new System.Windows.Forms.Label();
            this.lblPremiumRate = new System.Windows.Forms.Label();
            this.txtBoxStandardRate = new System.Windows.Forms.TextBox();
            this.txtBoxPremiumRate = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStandardRate
            // 
            this.lblStandardRate.AutoSize = true;
            this.lblStandardRate.Location = new System.Drawing.Point(12, 16);
            this.lblStandardRate.Name = "lblStandardRate";
            this.lblStandardRate.Size = new System.Drawing.Size(79, 13);
            this.lblStandardRate.TabIndex = 0;
            this.lblStandardRate.Text = "Standard Rate:";
            // 
            // lblPremiumRate
            // 
            this.lblPremiumRate.AutoSize = true;
            this.lblPremiumRate.Location = new System.Drawing.Point(12, 53);
            this.lblPremiumRate.Name = "lblPremiumRate";
            this.lblPremiumRate.Size = new System.Drawing.Size(76, 13);
            this.lblPremiumRate.TabIndex = 1;
            this.lblPremiumRate.Text = "Premium Rate:";
            // 
            // txtBoxStandardRate
            // 
            this.txtBoxStandardRate.Location = new System.Drawing.Point(99, 13);
            this.txtBoxStandardRate.Name = "txtBoxStandardRate";
            this.txtBoxStandardRate.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStandardRate.TabIndex = 2;
            this.txtBoxStandardRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxStandardRate_Validating);
            // 
            // txtBoxPremiumRate
            // 
            this.txtBoxPremiumRate.Location = new System.Drawing.Point(99, 50);
            this.txtBoxPremiumRate.Name = "txtBoxPremiumRate";
            this.txtBoxPremiumRate.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPremiumRate.TabIndex = 3;
            this.txtBoxPremiumRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPremiumRate_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(124, 131);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // RatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 175);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBoxPremiumRate);
            this.Controls.Add(this.txtBoxStandardRate);
            this.Controls.Add(this.lblPremiumRate);
            this.Controls.Add(this.lblStandardRate);
            this.Name = "RatesForm";
            this.Text = "RatesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStandardRate;
        private System.Windows.Forms.Label lblPremiumRate;
        private System.Windows.Forms.TextBox txtBoxStandardRate;
        private System.Windows.Forms.TextBox txtBoxPremiumRate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
    }
}