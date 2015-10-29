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
            this.fnameTextBox = new System.Windows.Forms.TextBox();
            this.minitTextBox = new System.Windows.Forms.TextBox();
            this.lNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectAddressButton = new System.Windows.Forms.Button();
            this.deleteMemberButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enrollCustomerButton
            // 
            this.enrollCustomerButton.Location = new System.Drawing.Point(568, 3);
            this.enrollCustomerButton.Name = "enrollCustomerButton";
            this.enrollCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.enrollCustomerButton.TabIndex = 0;
            this.enrollCustomerButton.Text = "Enroll Member";
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
            this.selectCustomerButton.Location = new System.Drawing.Point(568, 110);
            this.selectCustomerButton.Name = "selectCustomerButton";
            this.selectCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.selectCustomerButton.TabIndex = 2;
            this.selectCustomerButton.Text = "Select Member";
            this.selectCustomerButton.UseVisualStyleBackColor = true;
            this.selectCustomerButton.Click += new System.EventHandler(this.selectCustomerButton_Click);
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
            this.saveCustomerButton.Text = "Save Member";
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
            // fnameTextBox
            // 
            this.fnameTextBox.Location = new System.Drawing.Point(83, 1);
            this.fnameTextBox.Name = "fnameTextBox";
            this.fnameTextBox.Size = new System.Drawing.Size(111, 20);
            this.fnameTextBox.TabIndex = 7;
            // 
            // minitTextBox
            // 
            this.minitTextBox.Location = new System.Drawing.Point(83, 25);
            this.minitTextBox.Name = "minitTextBox";
            this.minitTextBox.Size = new System.Drawing.Size(111, 20);
            this.minitTextBox.TabIndex = 8;
            // 
            // lNameTextBox
            // 
            this.lNameTextBox.Location = new System.Drawing.Point(83, 51);
            this.lNameTextBox.Name = "lNameTextBox";
            this.lNameTextBox.Size = new System.Drawing.Size(111, 20);
            this.lNameTextBox.TabIndex = 9;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(293, 1);
            this.phoneTextBox.MaxLength = 10;
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(111, 20);
            this.phoneTextBox.TabIndex = 10;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Enabled = false;
            this.addressTextBox.Location = new System.Drawing.Point(293, 27);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(53, 20);
            this.addressTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.selectAddressButton);
            this.panel1.Controls.Add(this.fnameTextBox);
            this.panel1.Controls.Add(this.addressTextBox);
            this.panel1.Controls.Add(this.minitTextBox);
            this.panel1.Controls.Add(this.phoneTextBox);
            this.panel1.Controls.Add(this.lNameTextBox);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 100);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Address ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Phone Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Middle Initial:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "First Name:";
            // 
            // selectAddressButton
            // 
            this.selectAddressButton.Location = new System.Drawing.Point(352, 25);
            this.selectAddressButton.Name = "selectAddressButton";
            this.selectAddressButton.Size = new System.Drawing.Size(62, 23);
            this.selectAddressButton.TabIndex = 12;
            this.selectAddressButton.Text = "Select";
            this.selectAddressButton.UseVisualStyleBackColor = true;
            this.selectAddressButton.Click += new System.EventHandler(this.selectAddressButton_Click);
            // 
            // deleteMemberButton
            // 
            this.deleteMemberButton.Location = new System.Drawing.Point(459, 4);
            this.deleteMemberButton.Name = "deleteMemberButton";
            this.deleteMemberButton.Size = new System.Drawing.Size(103, 23);
            this.deleteMemberButton.TabIndex = 13;
            this.deleteMemberButton.Text = "Delete Member";
            this.deleteMemberButton.UseVisualStyleBackColor = true;
            this.deleteMemberButton.Visible = false;
            this.deleteMemberButton.Click += new System.EventHandler(this.deleteMemberButton_Click);
            // 
            // CustomerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.deleteMemberButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucCancelButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveCustomerButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.selectCustomerButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.enrollCustomerButton);
            this.Name = "CustomerUserControl";
            this.Size = new System.Drawing.Size(674, 136);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox fnameTextBox;
        private System.Windows.Forms.TextBox minitTextBox;
        private System.Windows.Forms.TextBox lNameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectAddressButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteMemberButton;
    }
}
