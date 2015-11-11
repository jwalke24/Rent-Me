using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum TransactionStates
    {
        Main,
        AddItem
    }

    public partial class TransactionUC : BSMiddleClass
    {
        private BindingList<PurchaseTransaction_Item> itemsToPurchase;
        private LoginSession session;

        public TransactionUC(DataGridView theGrid, LoginSession session)
        {
            this.DataGrid = theGrid;
            this.InitializeComponent();
            this.itemsToPurchase = new BindingList<PurchaseTransaction_Item>();
            this.session = session;
            this.DataGrid.DataSource = this.itemsToPurchase;
            this.Subtotal = 0;
            this.dateTimePicker1.MinDate = DateTime.Now;
            UserControlType = UserControls.Transaction;
        }

        private void changeToAddItemState()
        {
            //Enable
            this.addItemConfirmButton.Visible = true;
            this.addItemConfirmButton.Enabled = true;
            this.cancelItemConfirmButton.Enabled = true;
            this.cancelItemConfirmButton.Visible = true;
            this.itemToAddTextBox.Enabled = true;
            this.itemToAddTextBox.Visible = true;
            this.dateTimePicker1.Visible = true;
            this.qtyTextBox.Visible = true;
            this.qtyLabel.Visible = true;

            //Disable
            DataGrid.Enabled = false;
            this.addItemButton.Enabled = false;
            this.voidItemButton.Enabled = false;
            this.voidTransactionButton.Enabled = false;
            this.submitTransactionButton.Enabled = false;
            this.customerButton.Enabled = false;
            this.inventoryButton.Enabled = false;
        }

        private void changeToMainState()
        {
            //Disable
            this.addItemConfirmButton.Visible = false;
            this.addItemConfirmButton.Enabled = false;
            this.cancelItemConfirmButton.Enabled = false;
            this.cancelItemConfirmButton.Visible = false;
            this.itemToAddTextBox.Enabled = false;
            this.itemToAddTextBox.Visible = false;
            this.dateTimePicker1.Visible = false;
            this.qtyTextBox.Visible = false;
            this.qtyLabel.Visible = false;

            //Enable
            DataGrid.Enabled = true;
            this.addItemButton.Enabled = true;
            this.voidItemButton.Enabled = true;
            this.voidTransactionButton.Enabled = true;
            this.submitTransactionButton.Enabled = true;
            this.customerButton.Enabled = true;
            this.inventoryButton.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"You must select an item before you can void it.");
            }
            else
            {
                string id = DataGrid.SelectedRows[0].Cells["FurnitureID"].Value.ToString();

                foreach (var purchaseTransactionItem in this.itemsToPurchase)
                {
                    if (purchaseTransactionItem.FurnitureID == id)
                    {
                        this.itemsToPurchase.Remove(purchaseTransactionItem);
                        break;
                    }
                }
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            this.InternalState = TransactionStates.AddItem;
        }

        private void addItemConfirmButton_Click(object sender, EventArgs e)
        {
            FurnitureController theController = new FurnitureController();
            try
            {
                var id = int.Parse(this.itemToAddTextBox.Text);
                var result = theController.GetItemById(id);
                var quantity = int.Parse(this.qtyTextBox.Text);
                var days = (this.dateTimePicker1.Value - DateTime.Now).Days + 1;

                if (result == null)
                {
                    ErrorHandler.displayErrorBox("Error", "Item not found. Please try again.");
                    return;
                }

                if (result.Quantity < quantity)
                {
                    ErrorHandler.displayErrorBox("Quantity Error",
                        "There are not enough items in stock. You can only rent " + result.Quantity + " items or less.");
                    return;
                }

                if (days <= 0)
                {
                    ErrorHandler.displayErrorBox("Lease Time Error", "You must rent for at least one day.");
                    return;
                }

                PurchaseTransaction_Item theItem = new PurchaseTransaction_Item();
                theItem.FurnitureID = result.ID;
                theItem.Quantity = quantity;
                theItem.LeaseTime = days;


                foreach (var purchaseTransactionItem in this.itemsToPurchase)
                {
                    if (purchaseTransactionItem.FurnitureID == theItem.FurnitureID)
                    {
                        ErrorHandler.displayErrorBox("Duplicate Error", "Cannot add duplicate item to transaction");
                        return;
                    }
                }

                this.itemsToPurchase.Add(theItem);
            }
            catch (MySqlException error)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Network Error", "There was a problem adding this item to the transaciton. Please try again.", error);
                return;
            }
            catch (Exception)
            {
                ErrorHandler.displayErrorBox("Error", "Please enter a numerical value.");
                return;
            }

            this.InternalState = TransactionStates.Main;
        }

        private void cancelItemConfirmButton_Click(object sender, EventArgs e)
        {
            this.InternalState = TransactionStates.Main;
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Customer;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Inventory;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        /// <summary>
        ///     Processes the child.
        /// </summary>
        /// <exception cref="Exception">Invalid child type.</exception>
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
                case UserControls.Transaction:
                    throw new Exception("Invalid child type.");
            }
        }

        private void processCustomerChild(CustomerUserControl theUC)
        {
            if (theUC != null && theUC.CustomerID != null)
            {
                this.customerID = theUC.CustomerID;
            }
        }

        public override void processParentIntention()
        {
        }

        #region Properties And Variables

        private const double TAX_RATE = 0.07;

        private TransactionStates internalState;

        private TransactionStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;

                if (value == TransactionStates.Main)
                {
                    this.changeToMainState();
                }
                else if (value == TransactionStates.AddItem)
                {
                    this.changeToAddItemState();
                }
            }
        }

        private string customerID
        {
            get { return this.customerIDLabel.Text; }

            set { this.customerIDLabel.Text = value; }
        }

        private double subtotal;

        private double Subtotal
        {
            get { return this.subtotal; }
            set
            {
                this.subtotal = value;
                this.taxLabel.Text = (value*TAX_RATE).ToString("C", CultureInfo.CurrentCulture);
                this.subtotalLabel.Text = this.subtotal.ToString("C", CultureInfo.CurrentCulture);
                this.totalLabel.Text = (value*(1 + TAX_RATE)).ToString("C", CultureInfo.CurrentCulture);
            }
        }

        #endregion

        private void submitTransactionButton_Click(object sender, EventArgs e)
        {
            if (this.itemsToPurchase.Count == 0)
            {
                ErrorHandler.displayErrorBox("Error","Cannot submit an empty transaction.");
                return;
            }

            if (this.customerID == "null")
            {
                ErrorHandler.displayErrorBox("Error","Must select a customer.");
                return;
            }

            try
            {
                var theController = new TransactionController();

                var transaction = new PurchaseTransaction
                {
                    TransactionTime = DateTime.Now,
                    CustomerID = this.customerID,
                    EmployeeID = this.session.Id.ToString()
                };


                theController.AddPurchaseTransaction(transaction, this.itemsToPurchase);
            }
            catch (NullReferenceException nullReference)
            {
                ErrorHandler.displayErrorBox("Session Error", "The login session is null.");
            }
            catch (InvalidCastException invalidCast)
            {
                ErrorHandler.displayErrorBox("Session Error", "The tag cannot be cast as a login session.");
            }
            catch (MySqlException sqlException)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("SQL Error", "The transaction could not be added to the database.",sqlException);
            }
        }
    }
}