﻿namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.idGoButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.categoryComboBox.Location = new System.Drawing.Point(3, 27);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryComboBox.TabIndex = 1;
            // 
            // styleComboBox
            // 
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(3, 71);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(121, 21);
            this.styleComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.idGoButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.idSearchTextBox);
            this.panel1.Location = new System.Drawing.Point(130, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 129);
            this.panel1.TabIndex = 7;
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
            this.searchButton.Location = new System.Drawing.Point(6, 98);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(118, 23);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(542, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Add Item";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // InventoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.styleComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.ucCancelButton);
            this.Name = "InventoryUC";
            this.Size = new System.Drawing.Size(674, 136);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ucCancelButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idSearchTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button idGoButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button button4;
    }
}
