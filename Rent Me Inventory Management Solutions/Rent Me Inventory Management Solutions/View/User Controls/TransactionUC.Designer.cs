namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class TransactionUC
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
            this.voidTransactionButton = new System.Windows.Forms.Button();
            this.submitTransactionButton = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.voidItemButton = new System.Windows.Forms.Button();
            this.itemToAddTextBox = new System.Windows.Forms.TextBox();
            this.addItemConfirmButton = new System.Windows.Forms.Button();
            this.cancelItemConfirmButton = new System.Windows.Forms.Button();
            this.selectedCustomerLabel = new System.Windows.Forms.Label();
            this.customerIDLabel = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.qtyTextBox = new System.Windows.Forms.TextBox();
            this.qtyLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.itemIDLabel = new System.Windows.Forms.Label();
            this.startReturnTransactionButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // voidTransactionButton
            // 
            this.voidTransactionButton.Location = new System.Drawing.Point(565, 83);
            this.voidTransactionButton.Name = "voidTransactionButton";
            this.voidTransactionButton.Size = new System.Drawing.Size(108, 23);
            this.voidTransactionButton.TabIndex = 11;
            this.voidTransactionButton.Text = "Void Transaction";
            this.voidTransactionButton.UseVisualStyleBackColor = true;
            this.voidTransactionButton.Click += new System.EventHandler(this.voidTransactionButton_Click);
            // 
            // submitTransactionButton
            // 
            this.submitTransactionButton.Location = new System.Drawing.Point(565, 112);
            this.submitTransactionButton.Name = "submitTransactionButton";
            this.submitTransactionButton.Size = new System.Drawing.Size(108, 23);
            this.submitTransactionButton.TabIndex = 12;
            this.submitTransactionButton.Text = "Submit Transaction";
            this.submitTransactionButton.UseVisualStyleBackColor = true;
            this.submitTransactionButton.Click += new System.EventHandler(this.submitTransactionButton_Click);
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(565, 4);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(108, 23);
            this.customerButton.TabIndex = 13;
            this.customerButton.Text = "Customers";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.Location = new System.Drawing.Point(565, 33);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(108, 23);
            this.inventoryButton.TabIndex = 14;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = true;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.Location = new System.Drawing.Point(193, 83);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(75, 23);
            this.addItemButton.TabIndex = 15;
            this.addItemButton.Text = "Add Item";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // voidItemButton
            // 
            this.voidItemButton.Location = new System.Drawing.Point(193, 112);
            this.voidItemButton.Name = "voidItemButton";
            this.voidItemButton.Size = new System.Drawing.Size(75, 23);
            this.voidItemButton.TabIndex = 16;
            this.voidItemButton.Text = "Void Item";
            this.voidItemButton.UseVisualStyleBackColor = true;
            this.voidItemButton.Click += new System.EventHandler(this.voidButton_Click);
            // 
            // itemToAddTextBox
            // 
            this.itemToAddTextBox.Enabled = false;
            this.itemToAddTextBox.Location = new System.Drawing.Point(313, 88);
            this.itemToAddTextBox.Name = "itemToAddTextBox";
            this.itemToAddTextBox.Size = new System.Drawing.Size(99, 20);
            this.itemToAddTextBox.TabIndex = 17;
            this.itemToAddTextBox.Visible = false;
            // 
            // addItemConfirmButton
            // 
            this.addItemConfirmButton.Enabled = false;
            this.addItemConfirmButton.Location = new System.Drawing.Point(418, 83);
            this.addItemConfirmButton.Name = "addItemConfirmButton";
            this.addItemConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.addItemConfirmButton.TabIndex = 18;
            this.addItemConfirmButton.Text = "Add Item";
            this.addItemConfirmButton.UseVisualStyleBackColor = true;
            this.addItemConfirmButton.Visible = false;
            this.addItemConfirmButton.Click += new System.EventHandler(this.addItemConfirmButton_Click);
            // 
            // cancelItemConfirmButton
            // 
            this.cancelItemConfirmButton.Enabled = false;
            this.cancelItemConfirmButton.Location = new System.Drawing.Point(418, 112);
            this.cancelItemConfirmButton.Name = "cancelItemConfirmButton";
            this.cancelItemConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.cancelItemConfirmButton.TabIndex = 19;
            this.cancelItemConfirmButton.Text = "Cancel";
            this.cancelItemConfirmButton.UseVisualStyleBackColor = true;
            this.cancelItemConfirmButton.Visible = false;
            this.cancelItemConfirmButton.Click += new System.EventHandler(this.cancelItemConfirmButton_Click);
            // 
            // selectedCustomerLabel
            // 
            this.selectedCustomerLabel.AutoSize = true;
            this.selectedCustomerLabel.Location = new System.Drawing.Point(4, 4);
            this.selectedCustomerLabel.Name = "selectedCustomerLabel";
            this.selectedCustomerLabel.Size = new System.Drawing.Size(93, 13);
            this.selectedCustomerLabel.TabIndex = 20;
            this.selectedCustomerLabel.Text = "Selected Member:";
            // 
            // customerIDLabel
            // 
            this.customerIDLabel.AutoSize = true;
            this.customerIDLabel.Location = new System.Drawing.Point(100, 4);
            this.customerIDLabel.Name = "customerIDLabel";
            this.customerIDLabel.Size = new System.Drawing.Size(23, 13);
            this.customerIDLabel.TabIndex = 21;
            this.customerIDLabel.Text = "null";
            // 
            // qtyTextBox
            // 
            this.qtyTextBox.Location = new System.Drawing.Point(313, 114);
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new System.Drawing.Size(99, 20);
            this.qtyTextBox.TabIndex = 22;
            this.qtyTextBox.Visible = false;
            // 
            // qtyLabel
            // 
            this.qtyLabel.AutoSize = true;
            this.qtyLabel.Location = new System.Drawing.Point(275, 117);
            this.qtyLabel.Name = "qtyLabel";
            this.qtyLabel.Size = new System.Drawing.Size(32, 13);
            this.qtyLabel.TabIndex = 23;
            this.qtyLabel.Text = "QTY:";
            this.qtyLabel.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(274, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.Visible = false;
            // 
            // itemIDLabel
            // 
            this.itemIDLabel.AutoSize = true;
            this.itemIDLabel.Location = new System.Drawing.Point(271, 91);
            this.itemIDLabel.Name = "itemIDLabel";
            this.itemIDLabel.Size = new System.Drawing.Size(37, 13);
            this.itemIDLabel.TabIndex = 25;
            this.itemIDLabel.Text = "Item#:";
            this.itemIDLabel.Visible = false;
            // 
            // startReturnTransactionButton
            // 
            this.startReturnTransactionButton.Location = new System.Drawing.Point(3, 111);
            this.startReturnTransactionButton.Name = "startReturnTransactionButton";
            this.startReturnTransactionButton.Size = new System.Drawing.Size(135, 23);
            this.startReturnTransactionButton.TabIndex = 26;
            this.startReturnTransactionButton.Text = "Start Return Transaction";
            this.startReturnTransactionButton.UseVisualStyleBackColor = true;
            this.startReturnTransactionButton.Click += new System.EventHandler(this.startReturnTransactionButton_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(7, 57);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(37, 13);
            this.totalLabel.TabIndex = 27;
            this.totalLabel.Text = "Total: ";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(50, 57);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(34, 13);
            this.totalPriceLabel.TabIndex = 28;
            this.totalPriceLabel.Text = "$0.00";
            // 
            // TransactionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.startReturnTransactionButton);
            this.Controls.Add(this.itemIDLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.qtyLabel);
            this.Controls.Add(this.qtyTextBox);
            this.Controls.Add(this.customerIDLabel);
            this.Controls.Add(this.selectedCustomerLabel);
            this.Controls.Add(this.cancelItemConfirmButton);
            this.Controls.Add(this.addItemConfirmButton);
            this.Controls.Add(this.itemToAddTextBox);
            this.Controls.Add(this.voidItemButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.submitTransactionButton);
            this.Controls.Add(this.voidTransactionButton);
            this.Name = "TransactionUC";
            this.Size = new System.Drawing.Size(676, 138);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button voidTransactionButton;
        private System.Windows.Forms.Button submitTransactionButton;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button inventoryButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button voidItemButton;
        private System.Windows.Forms.TextBox itemToAddTextBox;
        private System.Windows.Forms.Button addItemConfirmButton;
        private System.Windows.Forms.Button cancelItemConfirmButton;
        private System.Windows.Forms.Label selectedCustomerLabel;
        private System.Windows.Forms.Label customerIDLabel;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TextBox qtyTextBox;
        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label itemIDLabel;
        private System.Windows.Forms.Button startReturnTransactionButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalPriceLabel;
    }
}
