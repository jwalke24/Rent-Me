namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class PurchaseTransactionUC
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
            this.viewPurchaseTransactionItemsButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewPurchaseTransactionItemsButton
            // 
            this.viewPurchaseTransactionItemsButton.Location = new System.Drawing.Point(529, 79);
            this.viewPurchaseTransactionItemsButton.Name = "viewPurchaseTransactionItemsButton";
            this.viewPurchaseTransactionItemsButton.Size = new System.Drawing.Size(140, 23);
            this.viewPurchaseTransactionItemsButton.TabIndex = 0;
            this.viewPurchaseTransactionItemsButton.Text = "View Transaction Items";
            this.viewPurchaseTransactionItemsButton.UseVisualStyleBackColor = true;
            this.viewPurchaseTransactionItemsButton.Click += new System.EventHandler(this.viewPurchaseTransactionItemsButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(529, 108);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(342, 79);
            this.label1.MaximumSize = new System.Drawing.Size(200, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "On this screen, you can choose previous transactions, and the items rented in eac" +
    "h transaction. ";
            // 
            // PurchaseTransactionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.viewPurchaseTransactionItemsButton);
            this.Name = "PurchaseTransactionUC";
            this.Size = new System.Drawing.Size(672, 134);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewPurchaseTransactionItemsButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
    }
}
