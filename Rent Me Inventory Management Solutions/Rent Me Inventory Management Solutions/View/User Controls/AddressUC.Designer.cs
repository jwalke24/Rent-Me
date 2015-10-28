namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class AddressUC
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
            this.selectAddressButton = new System.Windows.Forms.Button();
            this.createAddressButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.saveAddressButton = new System.Windows.Forms.Button();
            this.cancelAddressButton = new System.Windows.Forms.Button();
            this.street1TextBox = new System.Windows.Forms.TextBox();
            this.street2TextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.street1Label = new System.Windows.Forms.Label();
            this.street2Label = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.zipLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectAddressButton
            // 
            this.selectAddressButton.Location = new System.Drawing.Point(567, 110);
            this.selectAddressButton.Name = "selectAddressButton";
            this.selectAddressButton.Size = new System.Drawing.Size(104, 23);
            this.selectAddressButton.TabIndex = 0;
            this.selectAddressButton.Text = "Select Address";
            this.selectAddressButton.UseVisualStyleBackColor = true;
            this.selectAddressButton.Click += new System.EventHandler(this.selectAddressButton_Click);
            // 
            // createAddressButton
            // 
            this.createAddressButton.Location = new System.Drawing.Point(567, 3);
            this.createAddressButton.Name = "createAddressButton";
            this.createAddressButton.Size = new System.Drawing.Size(104, 23);
            this.createAddressButton.TabIndex = 1;
            this.createAddressButton.Text = "Create Address";
            this.createAddressButton.UseVisualStyleBackColor = true;
            this.createAddressButton.Click += new System.EventHandler(this.createAddressButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.zipLabel);
            this.mainPanel.Controls.Add(this.stateLabel);
            this.mainPanel.Controls.Add(this.cityLabel);
            this.mainPanel.Controls.Add(this.street2Label);
            this.mainPanel.Controls.Add(this.street1Label);
            this.mainPanel.Controls.Add(this.zipTextBox);
            this.mainPanel.Controls.Add(this.stateTextBox);
            this.mainPanel.Controls.Add(this.cityTextBox);
            this.mainPanel.Controls.Add(this.street2TextBox);
            this.mainPanel.Controls.Add(this.street1TextBox);
            this.mainPanel.Location = new System.Drawing.Point(3, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(558, 130);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Visible = false;
            // 
            // saveAddressButton
            // 
            this.saveAddressButton.Location = new System.Drawing.Point(567, 42);
            this.saveAddressButton.Name = "saveAddressButton";
            this.saveAddressButton.Size = new System.Drawing.Size(104, 23);
            this.saveAddressButton.TabIndex = 0;
            this.saveAddressButton.Text = "Save Address";
            this.saveAddressButton.UseVisualStyleBackColor = true;
            this.saveAddressButton.Visible = false;
            this.saveAddressButton.Click += new System.EventHandler(this.saveAddressButton_Click);
            // 
            // cancelAddressButton
            // 
            this.cancelAddressButton.Location = new System.Drawing.Point(567, 71);
            this.cancelAddressButton.Name = "cancelAddressButton";
            this.cancelAddressButton.Size = new System.Drawing.Size(104, 23);
            this.cancelAddressButton.TabIndex = 1;
            this.cancelAddressButton.Text = "Cancel";
            this.cancelAddressButton.UseVisualStyleBackColor = true;
            this.cancelAddressButton.Visible = false;
            this.cancelAddressButton.Click += new System.EventHandler(this.cancelAddressButton_Click);
            // 
            // street1TextBox
            // 
            this.street1TextBox.Location = new System.Drawing.Point(56, 3);
            this.street1TextBox.MaxLength = 75;
            this.street1TextBox.Name = "street1TextBox";
            this.street1TextBox.Size = new System.Drawing.Size(211, 20);
            this.street1TextBox.TabIndex = 0;
            // 
            // street2TextBox
            // 
            this.street2TextBox.Location = new System.Drawing.Point(56, 29);
            this.street2TextBox.MaxLength = 75;
            this.street2TextBox.Name = "street2TextBox";
            this.street2TextBox.Size = new System.Drawing.Size(211, 20);
            this.street2TextBox.TabIndex = 1;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(56, 55);
            this.cityTextBox.MaxLength = 45;
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(124, 20);
            this.cityTextBox.TabIndex = 2;
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(227, 55);
            this.stateTextBox.MaxLength = 2;
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(40, 20);
            this.stateTextBox.TabIndex = 3;
            // 
            // zipTextBox
            // 
            this.zipTextBox.Location = new System.Drawing.Point(56, 81);
            this.zipTextBox.MaxLength = 5;
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(124, 20);
            this.zipTextBox.TabIndex = 4;
            // 
            // street1Label
            // 
            this.street1Label.AutoSize = true;
            this.street1Label.Location = new System.Drawing.Point(3, 3);
            this.street1Label.Name = "street1Label";
            this.street1Label.Size = new System.Drawing.Size(47, 13);
            this.street1Label.TabIndex = 5;
            this.street1Label.Text = "Street 1:";
            // 
            // street2Label
            // 
            this.street2Label.AutoSize = true;
            this.street2Label.Location = new System.Drawing.Point(3, 29);
            this.street2Label.Name = "street2Label";
            this.street2Label.Size = new System.Drawing.Size(47, 13);
            this.street2Label.TabIndex = 6;
            this.street2Label.Text = "Street 2:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(3, 55);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 7;
            this.cityLabel.Text = "City:";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(186, 55);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 13);
            this.stateLabel.TabIndex = 8;
            this.stateLabel.Text = "State:";
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(3, 81);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(25, 13);
            this.zipLabel.TabIndex = 9;
            this.zipLabel.Text = "Zip:";
            // 
            // AddressUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cancelAddressButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.saveAddressButton);
            this.Controls.Add(this.createAddressButton);
            this.Controls.Add(this.selectAddressButton);
            this.Name = "AddressUC";
            this.Size = new System.Drawing.Size(674, 136);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectAddressButton;
        private System.Windows.Forms.Button createAddressButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button cancelAddressButton;
        private System.Windows.Forms.Button saveAddressButton;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label street2Label;
        private System.Windows.Forms.Label street1Label;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox street2TextBox;
        private System.Windows.Forms.TextBox street1TextBox;
    }
}
