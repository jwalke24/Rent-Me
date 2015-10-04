namespace Rent_Me_Inventory_Management_Solutions.View
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveCustomerButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ucCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Enroll Customer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(568, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Select Customer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 20);
            this.textBox1.TabIndex = 3;
            // 
            // saveCustomerButton
            // 
            this.saveCustomerButton.Enabled = false;
            this.saveCustomerButton.Location = new System.Drawing.Point(568, 32);
            this.saveCustomerButton.Name = "saveCustomerButton";
            this.saveCustomerButton.Size = new System.Drawing.Size(103, 23);
            this.saveCustomerButton.TabIndex = 4;
            this.saveCustomerButton.Text = "Save Customer";
            this.saveCustomerButton.UseVisualStyleBackColor = true;
            this.saveCustomerButton.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(568, 61);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
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
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CustomerUserControl";
            this.Size = new System.Drawing.Size(674, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button saveCustomerButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button ucCancelButton;
    }
}
