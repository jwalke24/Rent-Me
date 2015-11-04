using System;
using System.Globalization;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum TransactionStates
    {
        Main,
        AddItem
    }

    public partial class TransactionUC : BSMiddleClass
    {
        public TransactionUC()
        {
            this.InitializeComponent();
            this.Subtotal = 0;

            this.numItemsLabel.Text = "0";
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
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            this.InternalState = TransactionStates.AddItem;
        }

        private void addItemConfirmButton_Click(object sender, EventArgs e)
        {
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
    }
}