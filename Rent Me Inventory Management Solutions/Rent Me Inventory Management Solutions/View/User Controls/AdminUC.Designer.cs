using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class AdminUC
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
            this.returnEmployeeButton = new System.Windows.Forms.Button();
            this.editCustomersButton = new System.Windows.Forms.Button();
            this.editEmployeesButton = new System.Windows.Forms.Button();
            this.editInventoryButton = new System.Windows.Forms.Button();
            this.editCatStyleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // returnEmployeeButton
            // 
            this.returnEmployeeButton.Location = new System.Drawing.Point(533, 112);
            this.returnEmployeeButton.Name = "returnEmployeeButton";
            this.returnEmployeeButton.Size = new System.Drawing.Size(140, 23);
            this.returnEmployeeButton.TabIndex = 0;
            this.returnEmployeeButton.Text = "Return to Employee Mode";
            this.returnEmployeeButton.UseVisualStyleBackColor = true;
            this.returnEmployeeButton.Click += new System.EventHandler(this.returnEmployeeButton_Click);
            // 
            // editCustomersButton
            // 
            this.editCustomersButton.Location = new System.Drawing.Point(533, 3);
            this.editCustomersButton.Name = "editCustomersButton";
            this.editCustomersButton.Size = new System.Drawing.Size(138, 23);
            this.editCustomersButton.TabIndex = 1;
            this.editCustomersButton.Text = "Edit Customers";
            this.editCustomersButton.UseVisualStyleBackColor = true;
            this.editCustomersButton.Click += new System.EventHandler(this.editCustomersButton_Click);
            // 
            // editEmployeesButton
            // 
            this.editEmployeesButton.Location = new System.Drawing.Point(533, 32);
            this.editEmployeesButton.Name = "editEmployeesButton";
            this.editEmployeesButton.Size = new System.Drawing.Size(138, 23);
            this.editEmployeesButton.TabIndex = 2;
            this.editEmployeesButton.Text = "Edit Employees";
            this.editEmployeesButton.UseVisualStyleBackColor = true;
            this.editEmployeesButton.Click += new System.EventHandler(this.editEmployeesButton_Click);
            // 
            // editInventoryButton
            // 
            this.editInventoryButton.Location = new System.Drawing.Point(533, 61);
            this.editInventoryButton.Name = "editInventoryButton";
            this.editInventoryButton.Size = new System.Drawing.Size(138, 23);
            this.editInventoryButton.TabIndex = 3;
            this.editInventoryButton.Text = "Edit Inventory";
            this.editInventoryButton.UseVisualStyleBackColor = true;
            this.editInventoryButton.Click += new System.EventHandler(this.editInventoryButton_Click);
            // 
            // editCatStyleButton
            // 
            this.editCatStyleButton.Location = new System.Drawing.Point(389, 3);
            this.editCatStyleButton.Name = "editCatStyleButton";
            this.editCatStyleButton.Size = new System.Drawing.Size(138, 23);
            this.editCatStyleButton.TabIndex = 4;
            this.editCatStyleButton.Text = "Edit Categories and Styles";
            this.editCatStyleButton.UseVisualStyleBackColor = true;
            this.editCatStyleButton.Click += new System.EventHandler(this.editCatStyleButton_Click);
            // 
            // AdminUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.editCatStyleButton);
            this.Controls.Add(this.editInventoryButton);
            this.Controls.Add(this.editEmployeesButton);
            this.Controls.Add(this.editCustomersButton);
            this.Controls.Add(this.returnEmployeeButton);
            this.Name = "AdminUC";
            this.Size = new System.Drawing.Size(674, 136);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button returnEmployeeButton;
        private System.Windows.Forms.Button editCustomersButton;
        private System.Windows.Forms.Button editEmployeesButton;
        private System.Windows.Forms.Button editInventoryButton;
        private Button editCatStyleButton;
    }
}
