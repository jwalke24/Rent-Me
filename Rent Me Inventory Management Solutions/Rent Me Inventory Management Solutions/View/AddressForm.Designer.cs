namespace Rent_Me_Inventory_Management_Solutions.View
{
    partial class AddressForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addressDataGridView = new System.Windows.Forms.DataGridView();
            this.selectAddressButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.addressDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addressDataGridView
            // 
            this.addressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addressDataGridView.Location = new System.Drawing.Point(12, 12);
            this.addressDataGridView.Name = "addressDataGridView";
            this.addressDataGridView.Size = new System.Drawing.Size(475, 153);
            this.addressDataGridView.TabIndex = 0;
            // 
            // selectAddressButton
            // 
            this.selectAddressButton.Location = new System.Drawing.Point(202, 216);
            this.selectAddressButton.Name = "selectAddressButton";
            this.selectAddressButton.Size = new System.Drawing.Size(103, 23);
            this.selectAddressButton.TabIndex = 1;
            this.selectAddressButton.Text = "Select Address";
            this.selectAddressButton.UseVisualStyleBackColor = true;
            this.selectAddressButton.Click += new System.EventHandler(this.selectAddressButton_Click);
            // 
            // AddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 329);
            this.Controls.Add(this.selectAddressButton);
            this.Controls.Add(this.addressDataGridView);
            this.Name = "AddressForm";
            this.Text = "AddressForm";
            ((System.ComponentModel.ISupportInitialize)(this.addressDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView addressDataGridView;
        private System.Windows.Forms.Button selectAddressButton;
    }
}