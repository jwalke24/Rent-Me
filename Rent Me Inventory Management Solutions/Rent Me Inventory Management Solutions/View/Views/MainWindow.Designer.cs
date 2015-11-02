using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.logoutButton = new System.Windows.Forms.Button();
            this.adminOptionButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(782, 423);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(71, 23);
            this.logoutButton.TabIndex = 5;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // adminOptionButton
            // 
            this.adminOptionButton.Location = new System.Drawing.Point(700, 452);
            this.adminOptionButton.Name = "adminOptionButton";
            this.adminOptionButton.Size = new System.Drawing.Size(153, 23);
            this.adminOptionButton.TabIndex = 6;
            this.adminOptionButton.Text = "Administrative Options";
            this.adminOptionButton.UseVisualStyleBackColor = true;
            this.adminOptionButton.Click += new System.EventHandler(this.adminOptionButton_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.Location = new System.Drawing.Point(702, 332);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(71, 13);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "9/27/2015";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.Location = new System.Drawing.Point(779, 332);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(74, 13);
            this.timeLabel.TabIndex = 8;
            this.timeLabel.Text = "10:44 PM";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 487);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.adminOptionButton);
            this.Controls.Add(this.logoutButton);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(881, 526);
            this.MinimumSize = new System.Drawing.Size(881, 526);
            this.Name = "MainWindow";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rent Me Database Management Software";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button adminOptionButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
    }
}