using System;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum CustomerStates
    {
        Main,
        EnrollCustomer
    }

    public partial class CustomerUserControl : UserControl, IRentMeUcInterface
    {

        public UserControls UserControlType { get; private set; }
        public DataGridView DataGrid { get; set; }
        public UserControls SwitchTo { get; private set; }
        public IRentMeUcInterface ChildReturned { get; set; }
        public IRentMeUcInterface ParentParameter { get; set; }

        /// <summary>
        /// Occurs when [state changed].
        /// </summary>
        public event EventHandler StateChanged;

        public void processChild()
        {
            
        }

        public void processParentIntention()
        {
            
        }

        private RentMeUserControlPrimaryStates currentState;

        public RentMeUserControlPrimaryStates CurrentState
        {
            get { return this.currentState; }
            private set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }

        private CustomerStates internalState;

        private CustomerStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;
                switch (value)
                {
                     case CustomerStates.EnrollCustomer:
                        this.changeToEnrollCustomerState();
                        break;
                     case CustomerStates.Main:
                        this.changeToMainState();
                        break;
                }
            }
        }


        public CustomerUserControl()
        {
            this.InitializeComponent();
            this.UserControlType = UserControls.Customer;
        }


        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }


        /// <summary>
        /// Changes the visual state of to main.
        /// </summary>
        private void changeToMainState()
        {
            this.enrollCustomerButton.Visible = true;
            this.selectCustomerButton.Visible = true;
            this.ucCancelButton.Visible = true;
            this.searchButton.Visible = true;
            this.searchTextBox.Visible = true;

            this.saveCustomerButton.Visible = false;
            this.cancelButton.Visible = false;
        }

        /// <summary>
        /// Changes the visual state of to enroll customer.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void changeToEnrollCustomerState()
        {
            this.enrollCustomerButton.Visible = false;
            this.selectCustomerButton.Visible = false;
            this.ucCancelButton.Visible = false;
            this.searchButton.Visible = false;
            this.searchTextBox.Visible = false;

            this.saveCustomerButton.Visible = true;
            this.cancelButton.Visible = true;
        }

        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            this.InternalState = CustomerStates.Main;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.InternalState = CustomerStates.Main;
        }

        private void enrollCustomerButton_Click(object sender, EventArgs e)
        {
            this.InternalState = CustomerStates.EnrollCustomer;
        }
    }
}
