namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    partial class PurchaseTransactionItemUC
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
            this.selectItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectItemButton
            // 
            this.selectItemButton.Location = new System.Drawing.Point(3, 3);
            this.selectItemButton.Name = "selectItemButton";
            this.selectItemButton.Size = new System.Drawing.Size(75, 23);
            this.selectItemButton.TabIndex = 0;
            this.selectItemButton.Text = "Select Item";
            this.selectItemButton.UseVisualStyleBackColor = true;
            this.selectItemButton.Click += new System.EventHandler(this.selectItemButton_Click);
            // 
            // PurchaseTransactionItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.selectItemButton);
            this.Name = "PurchaseTransactionItemUC";
            this.Size = new System.Drawing.Size(670, 132);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectItemButton;
    }
}
