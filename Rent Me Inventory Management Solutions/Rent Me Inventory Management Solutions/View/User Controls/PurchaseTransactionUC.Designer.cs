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
            // PurchaseTransactionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.viewPurchaseTransactionItemsButton);
            this.Name = "PurchaseTransactionUC";
            this.Size = new System.Drawing.Size(672, 134);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button viewPurchaseTransactionItemsButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
