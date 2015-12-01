using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum TransactionStates
    {
        Main,
        AddItem
    }

    /// <summary>
    /// This class represents a Transaction User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class TransactionUC : BSMiddleClass
    {
        private BindingList<PurchaseTransaction_Item> itemsToPurchase;
        public LoginSession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        /// <param name="session">The session.</param>
        public TransactionUC(DataGridView theGrid, LoginSession session)
        {
            this.DataGrid = theGrid;
            this.InitializeComponent();
            this.itemsToPurchase = new BindingList<PurchaseTransaction_Item>();
            this.session = session;
            this.DataGrid.RowsAdded += this.DataGridOnRowsChanged;
            this.DataGrid.RowsRemoved += this.DataGridOnRowsChanged;
            this.dateTimePicker1.MinDate = DateTime.Now;
            UserControlType = UserControls.Transaction;
        }

        private void DataGridOnRowsChanged(object sender, object dataGridViewRowsAddedEventArgs)
        {
            try
            {
                FurnitureController tempFurnitureController = new FurnitureController();
                decimal total = 0;
                foreach (var purchaseTransactionItem in DataGrid.DataSource as BindingList<PurchaseTransaction_Item>)
                {
                    total += purchaseTransactionItem.LeaseTime *
                         tempFurnitureController.GetItemById(int.Parse(purchaseTransactionItem.FurnitureId)).Price *
                         purchaseTransactionItem.Quantity;
                }

                this.totalPriceLabel.Text = string.Format("{0:C}", total);
            }
            catch (MySqlException exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Network Exception", "There was an error connecting to the database. Please try again.", exception);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Unknown Error","An unknown error occured.", exception);
            }
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
            this.itemIDLabel.Visible = true;

            //Disable
            DataGrid.Enabled = false;
            this.addItemButton.Enabled = false;
            this.voidItemButton.Enabled = false;
            this.voidTransactionButton.Enabled = false;
            this.submitTransactionButton.Enabled = false;
            this.customerButton.Enabled = false;
            this.inventoryButton.Enabled = false;
            this.startReturnTransactionButton.Enabled = false;
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
            this.itemIDLabel.Visible = false;

            //Enable
            DataGrid.Enabled = true;
            this.addItemButton.Enabled = true;
            this.voidItemButton.Enabled = true;
            this.voidTransactionButton.Enabled = true;
            this.submitTransactionButton.Enabled = true;
            this.customerButton.Enabled = true;
            this.inventoryButton.Enabled = true;
            this.startReturnTransactionButton.Enabled = true;
        }

        private void voidButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"You must select an item before you can void it.");
            }
            else
            {
                this.itemsToPurchase.Remove(DataGrid.SelectedRows[0].DataBoundItem as PurchaseTransaction_Item);
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            this.clearPreviousItemToAddData();
            this.InternalState = TransactionStates.AddItem;
        }

        private void clearPreviousItemToAddData()
        {
            this.itemToAddTextBox.Text = String.Empty;
            this.qtyTextBox.Text = String.Empty;
            this.dateTimePicker1.Value = this.dateTimePicker1.MinDate;
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

                if (quantity <= 0)
                {
                    ErrorHandler.DisplayErrorBox("Error", "Please enter a valid quantity. ");
                    return;
                }

                if (result == null)
                {
                    ErrorHandler.DisplayErrorBox("Error", "Item not found. Please try again.");
                    return;
                }

                if (result.Quantity < quantity)
                {
                    ErrorHandler.DisplayErrorBox("Quantity Error",
                        "There are not enough items in stock. You can only rent " + result.Quantity + " items or less.");
                    return;
                }

                if (days <= 0)
                {
                    ErrorHandler.DisplayErrorBox("Lease Time Error", "You must rent for at least one day.");
                    return;
                }

                PurchaseTransaction_Item theItem = new PurchaseTransaction_Item();
                theItem.FurnitureId = result.Id;
                theItem.Quantity = quantity;
                theItem.LeaseTime = days;
                theItem.FurnitureName = result.Name;


                foreach (var purchaseTransactionItem in this.itemsToPurchase)
                {
                    if (purchaseTransactionItem.FurnitureId == theItem.FurnitureId)
                    {
                        ErrorHandler.DisplayErrorBox("Duplicate Error", "Cannot add duplicate item to transaction");
                        return;
                    }
                }

                this.itemsToPurchase.Add(theItem);

                if (this.DataGrid.DataSource == null)
                {
                    this.DataGrid.DataSource = this.itemsToPurchase;
                    this.DataGrid.Columns["ReturnableQuantity"].Visible = false;
                }
            }
            catch (MySqlException error)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Network Error", "There was a problem adding this item to the transaciton. Please try again.", error);
                return;
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please enter a numerical value.");
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
                case UserControls.Inventory:
                    this.processInventoryChild(ChildReturned as InventoryUC);
                    break;
                case UserControls.Customer:
                    this.processCustomerChild(ChildReturned as CustomerUserControl);
                    break;
                case UserControls.Transaction:
                    ErrorHandler.DisplayErrorMessageToUserAndLog("Fatal Error", "An unknown error occured.", new Exception("Transaction cannot be child of parent."));
                    this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
                    break;

            }
        }

        private void processInventoryChild(InventoryUC inventoryUc)
        {
            if (inventoryUc?.FurnitureID != null)
            {
                this.itemToAddTextBox.Text = inventoryUc?.FurnitureID;
                this.InternalState = TransactionStates.AddItem;
            }

        }

        private void processCustomerChild(CustomerUserControl theUC)
        {
            if (theUC != null && theUC.CustomerID != null)
            {
                this.customerID = theUC.CustomerID;
            }
        }

        /// <summary>
        /// Processes the parent intention.
        /// </summary>
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



        #endregion

        private void submitTransactionButton_Click(object sender, EventArgs e)
        {
            if (this.itemsToPurchase.Count == 0)
            {
                ErrorHandler.DisplayErrorBox("Error", "Cannot submit an empty transaction.");
                return;
            }

            if (this.customerID == "null")
            {
                ErrorHandler.DisplayErrorBox("Error", "Must select a customer.");
                return;
            }

            try
            {
                var theController = new TransactionController();
                var furnitureController = new FurnitureController();

                var transaction = new PurchaseTransaction
                {
                    TransactionTime = DateTime.Now,
                    CustomerId = this.customerID,
                    EmployeeId = this.session.Id.ToString(),
                    Items = new List<PurchaseTransaction_Item>(this.itemsToPurchase)
                };


                theController.AddPurchaseTransaction(transaction);

                furnitureController.UpdateQuantitiesByIds(transaction.Items);
                MessageBox.Show(this.itemsToPurchase.Count + @" item(s) were purchased for a total of " + this.totalPriceLabel.Text + ".", @"Transaction Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                this.clearTransaction();
            }
            catch (NullReferenceException nullReference)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Session Error", "The login session is null.", nullReference);
            }
            catch (InvalidCastException invalidCast)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Session Error", "The tag cannot be cast as a login session.", invalidCast);
            }
            catch (MySqlException sqlException)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("SQL Error",
                    "The transaction could not be added to the database.", sqlException);
            }
            catch (ArgumentOutOfRangeException rangeException)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Quantity Error",
                    rangeException.Message, rangeException);
            }
        }

        private void clearTransaction()
        {
            this.itemsToPurchase.Clear();
            this.customerID = "null";
            this.clearPreviousItemToAddData();
        }

        private void voidTransactionButton_Click(object sender, EventArgs e)
        {
            this.clearTransaction();
        }

        private void startReturnTransactionButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Return;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }
    }
}