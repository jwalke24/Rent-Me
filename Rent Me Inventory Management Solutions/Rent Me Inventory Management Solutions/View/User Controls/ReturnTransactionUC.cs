using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

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
        private Label label1;
        private Label extraFeesLabel;
        private Label extraFeesValueLabel;
        private ReturnTransactionController theController;

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
            this.theController = new ReturnTransactionController();
            DataGrid = theGrid;
            this.InitializeComponent();
            UserControlType = UserControls.Return;
            this.items = new BindingList<PurchaseTransaction_Item>();
            DataGrid.DataSource = this.items;
            this.DataGrid.RowsAdded += this.DataGridOnRowsChanged;
            this.DataGrid.RowsRemoved += this.DataGridOnRowsChanged;
        }

        private void DataGridOnRowsChanged(object sender, object dataGridViewRowsAddedEventArgs)
        {
            try
            {
                FurnitureController tempFurnitureController = new FurnitureController();
                TransactionController tempTransactionController = new TransactionController();
                decimal total = 0;
                foreach (var purchaseTransactionItem in DataGrid.DataSource as BindingList<PurchaseTransaction_Item>)
                {
                    int daysOut =
                        (DateTime.Now -
                         tempTransactionController.GetByID(purchaseTransactionItem.PurchaseTransactionId)
                                                  .TransactionTime).Days;

                    daysOut -= purchaseTransactionItem.LeaseTime;
                    if (daysOut < 0)
                        daysOut = 0;
                    total += daysOut * tempFurnitureController.GetItemById(int.Parse(purchaseTransactionItem.FurnitureId)).LateFee;

                }

                this.extraFeesValueLabel.Text = string.Format("{0:C}", total);
            }
            catch (MySqlException exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Network Exception", "There was an error connecting to the database. Please try again.", exception);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Unknown Error", "An unknown error occured.", exception);
            }
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
            this.label1 = new System.Windows.Forms.Label();
            this.extraFeesLabel = new System.Windows.Forms.Label();
            this.extraFeesValueLabel = new System.Windows.Forms.Label();
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
            this.submitTransactionButton.Click += new System.EventHandler(this.submitTransactionButton_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(322, 81);
            this.label1.MaximumSize = new System.Drawing.Size(250, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "To get started, select a customer, then choose items to return from previous tran" +
    "sactions. ";
            // 
            // extraFeesLabel
            // 
            this.extraFeesLabel.AutoSize = true;
            this.extraFeesLabel.Location = new System.Drawing.Point(6, 110);
            this.extraFeesLabel.Name = "extraFeesLabel";
            this.extraFeesLabel.Size = new System.Drawing.Size(63, 13);
            this.extraFeesLabel.TabIndex = 27;
            this.extraFeesLabel.Text = "Extra Fees: ";
            // 
            // extraFeesValueLabel
            // 
            this.extraFeesValueLabel.AutoSize = true;
            this.extraFeesValueLabel.Location = new System.Drawing.Point(75, 110);
            this.extraFeesValueLabel.Name = "extraFeesValueLabel";
            this.extraFeesValueLabel.Size = new System.Drawing.Size(34, 13);
            this.extraFeesValueLabel.TabIndex = 28;
            this.extraFeesValueLabel.Text = "$0.00";
            // 
            // ReturnTransactionUC
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.extraFeesValueLabel);
            this.Controls.Add(this.extraFeesLabel);
            this.Controls.Add(this.label1);
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

        private void submitTransactionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerID) || customerID == "null")
            {
                ErrorHandler.DisplayErrorBox("Error","Please select a customer before submitting the transaction.");
                return;
            }

            if (this.items.Count < 1)
            {
                ErrorHandler.DisplayErrorBox("Error", "You must add at least one item before submitting the transaction.");
                return;
            }

            try
            {
                this.theController.ReturnItems(this.items, this.theSession);

                var furnitureController = new FurnitureController();
                var furnitureIdQuantities = new Dictionary<string, int>();

                foreach (var item in this.items)
                {
                    furnitureIdQuantities.Add(item.FurnitureId, -(item.Quantity));
                }

                furnitureController.UpdateQuantitiesByIds(furnitureIdQuantities);
            }
            catch (MySqlException exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Unable to process this return transaction. Please try again.", exception);
                return;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Unknown Error", "An unknown error has occured.", exception);
                return;
            }

            MessageBox.Show(@"Items returned successfully!");
            this.clearScreen();

        }

        private void clearScreen()
        {
            (this.DataGrid.DataSource as BindingList<PurchaseTransaction_Item>)?.Clear();
            this.customerID = "null";
            this.displayViewTransactionsButton();
        }
    }
}
