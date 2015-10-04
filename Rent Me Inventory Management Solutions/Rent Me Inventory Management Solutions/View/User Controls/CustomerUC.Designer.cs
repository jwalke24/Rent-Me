namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class CustomerUserControl
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.enrollCustomerButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.selectCustomerButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.saveCustomerButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ucCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enrollCustomerButton
            // 
            this.enrollCustomerButton.Location = new System.Drawing.Point(568, 3);
            this.enrollCustomerButton.Name = "enrollCustomerButton";
            this.enrollCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.enrollCustomerButton.TabIndex = 0;
            this.enrollCustomerButton.Text = "Enroll Customer";
            this.enrollCustomerButton.UseVisualStyleBackColor = true;
            this.enrollCustomerButton.Click += new System.EventHandler(this.enrollCustomerButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(277, 107);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(91, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // selectCustomerButton
            // 
            this.selectCustomerButton.Enabled = false;
            this.selectCustomerButton.Location = new System.Drawing.Point(568, 110);
            this.selectCustomerButton.Name = "selectCustomerButton";
            this.selectCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.selectCustomerButton.TabIndex = 2;
            this.selectCustomerButton.Text = "Select Customer";
            this.selectCustomerButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(4, 109);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(267, 20);
            this.searchTextBox.TabIndex = 3;
            // 
            // saveCustomerButton
            // 
            this.saveCustomerButton.Location = new System.Drawing.Point(568, 32);
            this.saveCustomerButton.Name = "saveCustomerButton";
            this.saveCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.saveCustomerButton.TabIndex = 4;
            this.saveCustomerButton.Text = "Save Customer";
            this.saveCustomerButton.UseVisualStyleBackColor = true;
            this.saveCustomerButton.Visible = false;
            this.saveCustomerButton.Click += new System.EventHandler(this.saveCustomerButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(568, 61);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ucCancelButton
            // 
            this.ucCancelButton.Location = new System.Drawing.Point(459, 110);
            this.ucCancelButton.Name = "ucCancelButton";
            this.ucCancelButton.Size = new System.Drawing.Size(103, 23);
            this.ucCancelButton.TabIndex = 6;
            this.ucCancelButton.Text = "Cancel";
            this.ucCancelButton.UseVisualStyleBackColor = true;
            this.ucCancelButton.Click += new System.EventHandler(this.ucCancelButton_Click);
            // 
            // CustomerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ucCancelButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveCustomerButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.selectCustomerButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.enrollCustomerButton);
            this.Name = "CustomerUserControl";
            this.Size = new System.Drawing.Size(674, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enrollCustomerButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button selectCustomerButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button saveCustomerButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button ucCancelButton;
    }
}
