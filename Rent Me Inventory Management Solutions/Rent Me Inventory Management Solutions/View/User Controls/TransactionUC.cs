using System;
using System.Globalization;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum TransactionStates
    {
        Main,
        AddItem
    }

    public partial class TransactionUC : UserControl, IRentMeUcInterface
    {


        #region Properties And Variables

        private const double TAX_RATE = 0.07;
        /// <summary>
        /// Gets or sets the data grid.
        /// </summary>
        /// <value>
        /// The data grid.
        /// </value>
        public DataGridView DataGrid { get; set; }

        public IRentMeUcInterface ParameterPassedToChild { get; set; }

        /// <summary>
        /// Occurs when [state changed].
        /// </summary>
        public event EventHandler StateChanged;


        /// <summary>
        /// Lets the parent program know which UC needs to be presented when this one closes. 
        /// </summary>
        /// <value>
        /// The switch to.
        /// </value>
        public UserControls SwitchTo { get; private set; }

        public IRentMeUcInterface ChildReturned { get; set; }

        /// <summary>
        /// Gets or sets the type of the control.
        /// </summary>
        /// <value>
        /// The type of the control.
        /// </value>
        public UserControls UserControlType { get; private set; }

        private RentMeUserControlPrimaryStates currentState;
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
                } else if (value == TransactionStates.AddItem)
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
                this.subtotalLabel.Text = this.subtotal.ToString("C",CultureInfo.CurrentCulture);
                this.totalLabel.Text = (value * (1+ TAX_RATE)).ToString("C", CultureInfo.CurrentCulture);
            }
        }


        public RentMeUserControlPrimaryStates CurrentState
        {
            get { return this.currentState; }
            private set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }

        #endregion


        public TransactionUC()
        {
            this.InitializeComponent();
            this.Subtotal = 0;
            this.selectedCustomerLabel.Text = "0";
            this.numItemsLabel.Text = "0";
            this.UserControlType = UserControls.Transaction;
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
            this.DataGrid.Enabled = false;
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
            this.DataGrid.Enabled = true;
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

        protected virtual void OnStateChanged()
        {
            var handler = this.StateChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Customer;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Inventory;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }


        /// <summary>
        /// Processes the child.
        /// </summary>
        /// <exception cref="Exception">Invalid child type.</exception>
        public void processChild()
        {
            if (ChildReturned == null)
            {
                return;
            }


            switch (ChildReturned.UserControlType)
            {
                case UserControls.Transaction:
                    throw new Exception("Invalid child type.");
                    break;
                case UserControls.Customer:
                    this.processCustomerChild();
                    break;
                case UserControls.Inventory:
                    this.processInventoryChild();
                    break;
            }
                
        }

        public void processParameter()
        {
            
        }

        private void processInventoryChild()
        {
            
        }

        private void processCustomerChild()
        {
            
        }
    }
}