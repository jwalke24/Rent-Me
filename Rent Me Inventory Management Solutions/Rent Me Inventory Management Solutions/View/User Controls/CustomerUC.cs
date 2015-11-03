using System;
using System.ComponentModel;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum CustomerStates
    {
        Main,
        EnrollCustomer
    }

    public partial class CustomerUserControl : BSMiddleClass
    {
        

        public CustomerUserControl(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.InitializeComponent();
            UserControlType = UserControls.Customer;
            this.controller = new MemberController();
            this.loadMembers();
        }

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

        private readonly MemberController controller;
        private CustomerStates internalState;
        private LoginSession theSession;

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public string CustomerID { get; private set; }

        public override void processChild()
        {
            using (var temp = ChildReturned as AddressUC)
            {
                if (temp != null)
                {
                    this.addressTextBox.Text = temp.AddressID;
                }
            }
        }

        public override void processParentIntention()
        {
            if (this.ParentParameter == null)
            {
                return;
            }

            switch (this.ParentParameter.UserControlType)
            {
                  case UserControls.Admin:
                    this.proccessAdminParent(this.ParentParameter as AdminUC);
                    break;
            }
        }

        private void proccessAdminParent(AdminUC adminUc)
        {
            if (adminUc != null && adminUc.theSession.isAdmin && adminUc.theSession.isAuthenticated)
            {
                this.theSession = adminUc.theSession;
                this.verifyAdminButtonsMainState();
            }
        }

        private void loadMembers()
        {
            var theList = new BindingList<Member>(this.controller.GetAll());

            DataGrid.DataSource = theList;
        }

        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        /// <summary>
        ///     Changes the visual state of to main.
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

            this.verifyAdminButtonsMainState();


        }

        private void verifyAdminButtonsMainState()
        {
            if (this.theSession != null && this.theSession.isAuthenticated && this.theSession.isAdmin)
            {
                this.deleteMemberButton.Visible = true;
            }
        }

        /// <summary>
        ///     Changes the visual state of to enroll customer.
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
            this.deleteMemberButton.Visible = false;

            this.clearTextBoxes();
        }

        private void clearTextBoxes()
        {
            this.fnameTextBox.Text = string.Empty;
            this.lNameTextBox.Text = string.Empty;
            this.minitTextBox.Text = string.Empty;
            this.phoneTextBox.Text = string.Empty;
            this.addressTextBox.Text = string.Empty;
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            if (this.fnameTextBox.Text == string.Empty || this.lNameTextBox.Text == string.Empty ||
                this.minitTextBox.Text == string.Empty || this.phoneTextBox.Text == string.Empty ||
                this.addressTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter member information into every textbox.");
                return;
            }

            if (this.phoneTextBox.Text.Length != 10)
            {
                MessageBox.Show("A phone number must have 10 digits.");
                return;
            }

            var theMember = new Member();
            theMember.Fname = this.fnameTextBox.Text;
            theMember.Minit = this.minitTextBox.Text;
            theMember.Lname = this.lNameTextBox.Text;
            theMember.PhoneNumber = this.phoneTextBox.Text;
            theMember.AddressId = this.addressTextBox.Text;

            this.controller.AddMember(theMember);

            this.loadMembers();

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
            SwitchTo = UserControls.Address;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void selectCustomerButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please select a customer for the transaction.");
            }
            else
            {
                this.CustomerID = ((int) DataGrid.SelectedRows[0].Cells["Id"].Value).ToString();
                this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }

        private void deleteMemberButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please select a customer to delete.");
            }
            else
            {

                string customerID = ((int)DataGrid.SelectedRows[0].Cells["Id"].Value).ToString();
                this.controller.DeleteMemberById(customerID);

                this.loadMembers();
            }
        }
    }
}