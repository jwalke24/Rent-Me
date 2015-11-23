﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// This class represents a Return Transaction User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class ReturnTransactionUC : BSMiddleClass
    {
        private Button submitTransactionButton;
        private Label customerIDLabel;
        private Label selectedCustomerLabel;
        private Button customerButton;
        private Button cancelButton;
        private LoginSession theSession;
        private Button viewPurchaseTransactionsButton;
        private BindingList<PurchaseTransaction_Item> items; 

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public string customerID
        {
            get { return this.customerIDLabel.Text; }

            set { this.customerIDLabel.Text = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnTransactionUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public ReturnTransactionUC(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.InitializeComponent();
            UserControlType = UserControls.Return;
            this.items = new BindingList<PurchaseTransaction_Item>();
            theGrid.DataSource = this.items;
        }

        /// <summary>
        /// Processes the child element in the parent class.
        /// </summary>
        public override void processChild()
        {
            if (ChildReturned == null)
            {
                return;
            }


            switch (ChildReturned.UserControlType)
            {
                case UserControls.Customer:
                    this.processCustomerChild(ChildReturned as CustomerUserControl);
                    break;
                case UserControls.PurchaseTransaction:
                    this.processPurchaseTransactionChild(ChildReturned as PurchaseTransactionUC);
                    break;
            }

            this.displayViewTransactionsButton();
        }

        private void displayViewTransactionsButton()
        {
            if (this.customerID != "null")
            {
                this.viewPurchaseTransactionsButton.Enabled = true;
                this.viewPurchaseTransactionsButton.Visible = true;
            }
        }

        private void processPurchaseTransactionChild(PurchaseTransactionUC theUC)
        {
            if (theUC != null && theUC.SelectedItem != null)
            {
                this.items.Add(theUC.SelectedItem);
            }
        }

        private void processCustomerChild(CustomerUserControl theUC)
        {
            if (theUC != null && theUC.CustomerID != null)
            {
                this.customerID = theUC.CustomerID;
                SwitchTo = UserControls.PurchaseTransaction;
                CurrentState = RentMeUserControlPrimaryStates.Hiding;
            }
        }

        /// <summary>
        /// Processes the parent intention.
        /// </summary>
        public override void processParentIntention()
        {
            this.theSession = (ParentParameter as TransactionUC)?.session;
        }

        private void InitializeComponent()
        {
            this.submitTransactionButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.customerIDLabel = new System.Windows.Forms.Label();
            this.selectedCustomerLabel = new System.Windows.Forms.Label();
            this.customerButton = new System.Windows.Forms.Button();
            this.viewPurchaseTransactionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submitTransactionButton
            // 
            this.submitTransactionButton.Location = new System.Drawing.Point(558, 81);
            this.submitTransactionButton.Name = "submitTransactionButton";
            this.submitTransactionButton.Size = new System.Drawing.Size(113, 23);
            this.submitTransactionButton.TabIndex = 0;
            this.submitTransactionButton.Text = "Submit Transaction";
            this.submitTransactionButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(558, 110);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(113, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // customerIDLabel
            // 
            this.customerIDLabel.AutoSize = true;
            this.customerIDLabel.Location = new System.Drawing.Point(102, 8);
            this.customerIDLabel.Name = "customerIDLabel";
            this.customerIDLabel.Size = new System.Drawing.Size(23, 13);
            this.customerIDLabel.TabIndex = 23;
            this.customerIDLabel.Text = "null";
            // 
            // selectedCustomerLabel
            // 
            this.selectedCustomerLabel.AutoSize = true;
            this.selectedCustomerLabel.Location = new System.Drawing.Point(3, 8);
            this.selectedCustomerLabel.Name = "selectedCustomerLabel";
            this.selectedCustomerLabel.Size = new System.Drawing.Size(93, 13);
            this.selectedCustomerLabel.TabIndex = 22;
            this.selectedCustomerLabel.Text = "Selected Member:";
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(558, 4);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(113, 23);
            this.customerButton.TabIndex = 24;
            this.customerButton.Text = "Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // viewPurchaseTransactionsButton
            // 
            this.viewPurchaseTransactionsButton.Enabled = false;
            this.viewPurchaseTransactionsButton.Location = new System.Drawing.Point(131, 3);
            this.viewPurchaseTransactionsButton.Name = "viewPurchaseTransactionsButton";
            this.viewPurchaseTransactionsButton.Size = new System.Drawing.Size(107, 23);
            this.viewPurchaseTransactionsButton.TabIndex = 25;
            this.viewPurchaseTransactionsButton.Text = "View Transactions";
            this.viewPurchaseTransactionsButton.UseVisualStyleBackColor = true;
            this.viewPurchaseTransactionsButton.Visible = false;
            this.viewPurchaseTransactionsButton.Click += new System.EventHandler(this.viewPurchaseTransactionsButton_Click);
            // 
            // ReturnTransactionUC
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.viewPurchaseTransactionsButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.customerIDLabel);
            this.Controls.Add(this.selectedCustomerLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitTransactionButton);
            this.Name = "ReturnTransactionUC";
            this.Size = new System.Drawing.Size(674, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Customer;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void viewPurchaseTransactionsButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.PurchaseTransaction;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }
    }
}
