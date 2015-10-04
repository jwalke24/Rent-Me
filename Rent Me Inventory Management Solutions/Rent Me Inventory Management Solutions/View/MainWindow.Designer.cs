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
            this.transactionNumberLabel = new System.Windows.Forms.Label();
            this.transactionNumberActualLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.enterButtonForEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // transactionNumberLabel
            // 
            this.transactionNumberLabel.AutoSize = true;
            this.transactionNumberLabel.Location = new System.Drawing.Point(697, 332);
            this.transactionNumberLabel.Name = "transactionNumberLabel";
            this.transactionNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.transactionNumberLabel.TabIndex = 2;
            this.transactionNumberLabel.Text = "Transcation #:";
            // 
            // transactionNumberActualLabel
            // 
            this.transactionNumberActualLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.transactionNumberActualLabel.Location = new System.Drawing.Point(773, 332);
            this.transactionNumberActualLabel.Name = "transactionNumberActualLabel";
            this.transactionNumberActualLabel.Size = new System.Drawing.Size(80, 13);
            this.transactionNumberActualLabel.TabIndex = 3;
            this.transactionNumberActualLabel.Text = "0000000000";
            this.transactionNumberActualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(700, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Administrative Options";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.Location = new System.Drawing.Point(782, 355);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(71, 13);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "9/27/2015";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.Location = new System.Drawing.Point(779, 368);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(74, 13);
            this.timeLabel.TabIndex = 8;
            this.timeLabel.Text = "10:44 PM";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // enterButtonForEvent
            // 
            this.enterButtonForEvent.Location = new System.Drawing.Point(288, 109);
            this.enterButtonForEvent.Name = "enterButtonForEvent";
            this.enterButtonForEvent.Size = new System.Drawing.Size(187, 23);
            this.enterButtonForEvent.TabIndex = 9;
            this.enterButtonForEvent.Text = "Enter button for events";
            this.enterButtonForEvent.UseVisualStyleBackColor = true;
            this.enterButtonForEvent.Visible = false;
            // 
            // MainWindow
            // 
            this.AcceptButton = this.enterButtonForEvent;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 487);
            this.Controls.Add(this.enterButtonForEvent);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.transactionNumberActualLabel);
            this.Controls.Add(this.transactionNumberLabel);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(881, 526);
            this.MinimumSize = new System.Drawing.Size(881, 526);
            this.Name = "MainWindow";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rent Me Database Management Software";
            this.Click += new System.EventHandler(this.MainWindow_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label transactionNumberLabel;
        private System.Windows.Forms.Label transactionNumberActualLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button enterButtonForEvent;
    }
}