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
            // 
            // AddressUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.createAddressButton);
            this.Controls.Add(this.selectAddressButton);
            this.Name = "AddressUC";
            this.Size = new System.Drawing.Size(674, 136);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectAddressButton;
        private System.Windows.Forms.Button createAddressButton;
    }
}
