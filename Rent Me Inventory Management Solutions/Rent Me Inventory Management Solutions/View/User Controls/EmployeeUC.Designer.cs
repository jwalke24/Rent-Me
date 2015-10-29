namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class EmployeeUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createEmployeeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.deleteEmployeeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.adminLabel = new System.Windows.Forms.Label();
            this.adminCheckBox = new System.Windows.Forms.CheckBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.ssnLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.ssnTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createEmployeeButton
            // 
            this.createEmployeeButton.Location = new System.Drawing.Point(557, 3);
            this.createEmployeeButton.Name = "createEmployeeButton";
            this.createEmployeeButton.Size = new System.Drawing.Size(112, 23);
            this.createEmployeeButton.TabIndex = 0;
            this.createEmployeeButton.Text = "Create Employee";
            this.createEmployeeButton.UseVisualStyleBackColor = true;
            this.createEmployeeButton.Click += new System.EventHandler(this.createEmployeeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(557, 108);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(112, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // deleteEmployeeButton
            // 
            this.deleteEmployeeButton.Location = new System.Drawing.Point(557, 33);
            this.deleteEmployeeButton.Name = "deleteEmployeeButton";
            this.deleteEmployeeButton.Size = new System.Drawing.Size(112, 23);
            this.deleteEmployeeButton.TabIndex = 2;
            this.deleteEmployeeButton.Text = "Delete Employee";
            this.deleteEmployeeButton.UseVisualStyleBackColor = true;
            this.deleteEmployeeButton.Click += new System.EventHandler(this.deleteEmployeeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.adminLabel);
            this.panel1.Controls.Add(this.adminCheckBox);
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Controls.Add(this.ssnLabel);
            this.panel1.Controls.Add(this.addressLabel);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.phoneLabel);
            this.panel1.Controls.Add(this.lastNameLabel);
            this.panel1.Controls.Add(this.firstNameLabel);
            this.panel1.Controls.Add(this.phoneTextBox);
            this.panel1.Controls.Add(this.addressTextBox);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.firstNameTextBox);
            this.panel1.Controls.Add(this.ssnTextBox);
            this.panel1.Controls.Add(this.lastNameTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 128);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(368, 105);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(449, 105);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save Employee";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.Location = new System.Drawing.Point(6, 83);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(39, 13);
            this.adminLabel.TabIndex = 14;
            this.adminLabel.Text = "Admin:";
            // 
            // adminCheckBox
            // 
            this.adminCheckBox.AutoSize = true;
            this.adminCheckBox.Location = new System.Drawing.Point(82, 82);
            this.adminCheckBox.Name = "adminCheckBox";
            this.adminCheckBox.Size = new System.Drawing.Size(15, 14);
            this.adminCheckBox.TabIndex = 13;
            this.adminCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(299, 55);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(48, 23);
            this.selectButton.TabIndex = 12;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // ssnLabel
            // 
            this.ssnLabel.AutoSize = true;
            this.ssnLabel.Location = new System.Drawing.Point(3, 60);
            this.ssnLabel.Name = "ssnLabel";
            this.ssnLabel.Size = new System.Drawing.Size(32, 13);
            this.ssnLabel.TabIndex = 11;
            this.ssnLabel.Text = "SSN:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(188, 60);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 10;
            this.addressLabel.Text = "Address:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(188, 8);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password:";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(188, 35);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(41, 13);
            this.phoneLabel.TabIndex = 8;
            this.phoneLabel.Text = "Phone:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(3, 34);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 7;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(3, 5);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.firstNameLabel.TabIndex = 6;
            this.firstNameLabel.Text = "First Name:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(248, 31);
            this.phoneTextBox.MaxLength = 10;
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 5;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Enabled = false;
            this.addressTextBox.Location = new System.Drawing.Point(248, 57);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(45, 20);
            this.addressTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(248, 5);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(82, 5);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 2;
            // 
            // ssnTextBox
            // 
            this.ssnTextBox.Location = new System.Drawing.Point(82, 57);
            this.ssnTextBox.MaxLength = 10;
            this.ssnTextBox.Name = "ssnTextBox";
            this.ssnTextBox.Size = new System.Drawing.Size(100, 20);
            this.ssnTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(82, 31);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 0;
            // 
            // EmployeeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deleteEmployeeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.createEmployeeButton);
            this.Name = "EmployeeUC";
            this.Size = new System.Drawing.Size(672, 134);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createEmployeeButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button deleteEmployeeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label ssnLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox ssnTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.CheckBox adminCheckBox;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}
