using System;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Controller;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum CustomerStates
    {
        Main,
        EnrollCustomer
    }

    public partial class CustomerUserControl : UserControl, IRentMeUcInterface
    {

        private MemberController controller;

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
            using (AddressUC temp = this.ChildReturned as AddressUC)
            {
                if (temp != null)
                {
                    this.addressTextBox.Text = temp.AddressID;
                }
            }
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


        public CustomerUserControl(DataGridView theGrid)
        {
            this.DataGrid = theGrid;
            this.InitializeComponent();
            this.UserControlType = UserControls.Customer;
            this.controller = new MemberController();
            this.loadMembers();
        }

        private void loadMembers()
        {
            BindingList<Member> theList = new BindingList<Member>(this.controller.GetAll());

            this.DataGrid.DataSource = theList;
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

            this.panel1.Visible = false;
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

            this.panel1.Visible = true;
        }

        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {

            if (this.fnameTextBox.Text == String.Empty || this.lNameTextBox.Text == String.Empty ||
                this.minitTextBox.Text == String.Empty || this.phoneTextBox.Text == String.Empty ||
                this.addressTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please enter member information into every textbox.");
            }

            Member theMember = new Member();
            theMember.Fname = this.fnameTextBox.Text;
            theMember.Minit = this.minitTextBox.Text;
            theMember.Lname = this.lNameTextBox.Text;
            theMember.PhoneNumber = this.phoneTextBox.Text;
            theMember.AddressId = this.addressTextBox.Text;

            this.controller.AddMember(theMember);


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

        private void selectAddressButton_Click(object sender, EventArgs e)
        {
            /*
            AddressForm addressForm = new AddressForm();
            var result = addressForm.ShowDialog(this);
            
            if (result == DialogResult.OK)
            {
                this.addressTextBox.Text = addressForm.AddressID.ToString();
                this.addressTextBox.Enabled = false;
            }
            */
            this.SwitchTo = UserControls.Address;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }
    }
}
