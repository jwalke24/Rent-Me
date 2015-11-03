namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class InventoryUC
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
            this.ucCancelButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idSearchTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.idGoButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.selectItemButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.addPanel = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.saveItemButton = new System.Windows.Forms.Button();
            this.categoryStylePanel = new System.Windows.Forms.Panel();
            this.itemPanel.SuspendLayout();
            this.addPanel.SuspendLayout();
            this.categoryStylePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucCancelButton
            // 
            this.ucCancelButton.Location = new System.Drawing.Point(542, 110);
            this.ucCancelButton.Name = "ucCancelButton";
            this.ucCancelButton.Size = new System.Drawing.Size(129, 23);
            this.ucCancelButton.TabIndex = 0;
            this.ucCancelButton.Text = "Cancel";
            this.ucCancelButton.UseVisualStyleBackColor = true;
            this.ucCancelButton.Click += new System.EventHandler(this.ucCancelButton_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(5, 29);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(104, 21);
            this.categoryComboBox.TabIndex = 1;
            // 
            // styleComboBox
            // 
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(6, 69);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(103, 21);
            this.styleComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Style:";
            // 
            // idSearchTextBox
            // 
            this.idSearchTextBox.Location = new System.Drawing.Point(3, 24);
            this.idSearchTextBox.MaxLength = 10;
            this.idSearchTextBox.Name = "idSearchTextBox";
            this.idSearchTextBox.Size = new System.Drawing.Size(100, 20);
            this.idSearchTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item #:";
            // 
            // itemPanel
            // 
            this.itemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemPanel.Controls.Add(this.idGoButton);
            this.itemPanel.Controls.Add(this.label3);
            this.itemPanel.Controls.Add(this.idSearchTextBox);
            this.itemPanel.Location = new System.Drawing.Point(130, 3);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(108, 130);
            this.itemPanel.TabIndex = 7;
            // 
            // idGoButton
            // 
            this.idGoButton.Location = new System.Drawing.Point(4, 51);
            this.idGoButton.Name = "idGoButton";
            this.idGoButton.Size = new System.Drawing.Size(99, 23);
            this.idGoButton.TabIndex = 7;
            this.idGoButton.Text = "Go";
            this.idGoButton.UseVisualStyleBackColor = true;
            this.idGoButton.Click += new System.EventHandler(this.idGoButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(6, 107);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(104, 23);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // selectItemButton
            // 
            this.selectItemButton.Location = new System.Drawing.Point(542, 81);
            this.selectItemButton.Name = "selectItemButton";
            this.selectItemButton.Size = new System.Drawing.Size(129, 23);
            this.selectItemButton.TabIndex = 9;
            this.selectItemButton.Text = "Select Item";
            this.selectItemButton.UseVisualStyleBackColor = true;
            // 
            // addItemButton
            // 
            this.addItemButton.Location = new System.Drawing.Point(542, 3);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(129, 23);
            this.addItemButton.TabIndex = 10;
            this.addItemButton.Text = "Add Item";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // addPanel
            // 
            this.addPanel.Controls.Add(this.descriptionLabel);
            this.addPanel.Controls.Add(this.label4);
            this.addPanel.Controls.Add(this.descriptionTextBox);
            this.addPanel.Controls.Add(this.priceTextBox);
            this.addPanel.Controls.Add(this.quantityTextBox);
            this.addPanel.Controls.Add(this.nameTextBox);
            this.addPanel.Controls.Add(this.priceLabel);
            this.addPanel.Controls.Add(this.quantityLabel);
            this.addPanel.Controls.Add(this.nameLabel);
            this.addPanel.Location = new System.Drawing.Point(245, 3);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(291, 130);
            this.addPanel.TabIndex = 11;
            this.addPanel.Visible = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 34);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 8;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(6, 55);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(282, 72);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(204, 3);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(73, 20);
            this.priceTextBox.TabIndex = 1;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(204, 31);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(73, 20);
            this.quantityTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(58, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(164, 5);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(34, 13);
            this.priceLabel.TabIndex = 3;
            this.priceLabel.Text = "Price:";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(149, 34);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(49, 13);
            this.quantityLabel.TabIndex = 2;
            this.quantityLabel.Text = "Quantity:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 5);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // saveItemButton
            // 
            this.saveItemButton.Location = new System.Drawing.Point(542, 52);
            this.saveItemButton.Name = "saveItemButton";
            this.saveItemButton.Size = new System.Drawing.Size(129, 23);
            this.saveItemButton.TabIndex = 8;
            this.saveItemButton.Text = "Save Item";
            this.saveItemButton.UseVisualStyleBackColor = true;
            this.saveItemButton.Visible = false;
            this.saveItemButton.Click += new System.EventHandler(this.saveItemButton_Click);
            // 
            // categoryStylePanel
            // 
            this.categoryStylePanel.Controls.Add(this.label1);
            this.categoryStylePanel.Controls.Add(this.categoryComboBox);
            this.categoryStylePanel.Controls.Add(this.label2);
            this.categoryStylePanel.Controls.Add(this.styleComboBox);
            this.categoryStylePanel.Location = new System.Drawing.Point(1, -1);
            this.categoryStylePanel.Name = "categoryStylePanel";
            this.categoryStylePanel.Size = new System.Drawing.Size(109, 107);
            this.categoryStylePanel.TabIndex = 12;
            // 
            // InventoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.categoryStylePanel);
            this.Controls.Add(this.saveItemButton);
            this.Controls.Add(this.addPanel);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.selectItemButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.ucCancelButton);
            this.Name = "InventoryUC";
            this.Size = new System.Drawing.Size(674, 136);
            this.itemPanel.ResumeLayout(false);
            this.itemPanel.PerformLayout();
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            this.categoryStylePanel.ResumeLayout(false);
            this.categoryStylePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ucCancelButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idSearchTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.Button idGoButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button selectItemButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Button saveItemButton;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel categoryStylePanel;
    }
}
