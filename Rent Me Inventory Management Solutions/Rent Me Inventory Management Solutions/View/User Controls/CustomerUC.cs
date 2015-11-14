using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
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

        /// <summary>
        ///     Gets the customer identifier.
        /// </summary>
        /// <value>
        ///     The customer identifier.
        /// </value>
        public string CustomerID { get; private set; }

        private readonly MemberController controller;
        private CustomerStates internalState;
        private LoginSession theSession;

        public CustomerUserControl(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.InitializeComponent();
            UserControlType = UserControls.Customer;
            this.controller = new MemberController();
            this.loadMembers();
        }

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
            if (ParentParameter == null)
            {
                return;
            }

            switch (ParentParameter.UserControlType)
            {
                case UserControls.Admin:
                    this.proccessAdminParent(ParentParameter as AdminUC);
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
            try
            {
                var theList = new BindingList<Member>(this.controller.GetAll());

                DataGrid.DataSource = theList;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Cannot Access Database",
                    "An error occured while loading this form.", exception);
            }
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
                this.phoneTextBox.Text == string.Empty ||
                this.addressTextBox.Text == string.Empty)
            {
                ErrorHandler.displayErrorBox("Invalid Data", "Please enter member information into every textbox.");
                return;
            }

            if (this.phoneTextBox.Text.Length != 10)
            {
                ErrorHandler.displayErrorBox("Phone Number Invalid", "Please enter a valid 10 digit phone number.");
                return;
            }

            try
            {
                long.Parse(this.phoneTextBox.Text);
            }
            catch (Exception)
            {
                ErrorHandler.displayErrorBox("Phone Number Invalid", "Please enter a valid 10 digit phone number.");
                return;
            }

            var theMember = new Member
            {
                Fname = this.fnameTextBox.Text,
                Minit = this.minitTextBox.Text,
                Lname = this.lNameTextBox.Text,
                PhoneNumber = this.phoneTextBox.Text,
                AddressId = this.addressTextBox.Text
            };

            try
            {
                this.controller.AddMember(theMember);

                this.loadMembers();

                this.InternalState = CustomerStates.Main;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Failed to add member to database. Please try again.", exception);
            }
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
                CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }

        private void deleteMemberButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                ErrorHandler.displayErrorBox("Error", "Please select a customer to delete.");
                return;
            }

            try
            {
                var customerID = ((int) DataGrid.SelectedRows[0].Cells["Id"].Value).ToString();
                this.controller.DeleteMemberById(customerID);

                this.loadMembers();
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error", "Failed to delete employee from database.",
                    exception);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (this.searchTextBox.Text == null)
            {
                return;
            }
            try
            {
                IList<Member> resultList = this.controller.SearchMember(this.searchTextBox.Text);
                this.DataGrid.DataSource = new BindingList<Member>(resultList);
            }
            catch (MySqlException exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error", "An error occured while searching the database. Please try again.",exception);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Unknown Error","An unknown error has occured. Please try again.",exception);
            }
        }
    }
}