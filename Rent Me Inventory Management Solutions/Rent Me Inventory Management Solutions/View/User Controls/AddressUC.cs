using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum AddressStates
    {
        Main,
        AddAddress
    }

    public partial class AddressUC :BSMiddleClass
    {
        private AddressController theController;


        public AddressUC(DataGridView theGrid)
        {
            this.UserControlType = UserControls.Address;
            this.DataGrid = theGrid;

            InitializeComponent();

            this.theController = new AddressController();

            this.loadAddresses();
        }

        private void loadAddresses()
        {
            BindingList<Address> theAddresses = new BindingList<Address>(this.theController.GetAllAddresses());

            this.DataGrid.DataSource = theAddresses;
        }

        private AddressStates internalState;

        private AddressStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;
                switch (value)
                {
                    case AddressStates.AddAddress:
                        this.changeToAddAddressState();
                        break;
                    case AddressStates.Main:
                        this.changeToMainState();
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        public string AddressID { get; private set; }


        public override void processChild()
        {
            
        }

        public override void processParentIntention()
        {
            
        }

        private void selectAddressButton_Click(object sender, EventArgs e)
        {

            if (this.DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please select an address.");
            }
            else
            {
                this.AddressID = ((int)this.DataGrid.SelectedRows[0].Cells["Id"].Value).ToString();
                this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }

        private void createAddressButton_Click(object sender, EventArgs e)
        {
            this.InternalState = AddressStates.AddAddress;
        }


        private void saveAddressButton_Click(object sender, EventArgs e)
        {
            if (this.street1TextBox.Text == string.Empty || this.cityTextBox.Text == String.Empty ||
                this.stateTextBox.Text == String.Empty || this.zipTextBox.Text == String.Empty)
            {
                ErrorHandler.displayErrorBox("Error", "Please enter a value for required fields.");
                return;
            }

            try
            {
                int.Parse(zipTextBox.Text);
            }
            catch (Exception exception)
            {
                ErrorHandler.displayErrorBox("Error", "Please enter a valid zip code.");
                return;
            }

            if (this.stateTextBox.Text.Length != 2)
            {
                ErrorHandler.displayErrorBox("Error", "Please enter a valid state.");
            }


            try
            {
                this.theController.AddAddress(this.street1TextBox.Text, this.street2TextBox.Text, this.cityTextBox.Text,
                    this.stateTextBox.Text, this.zipTextBox.Text);

                this.loadAddresses();
                this.InternalState = AddressStates.Main;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error", "Failed to add address to database. Please try again.", exception);
                return;
            }
        }


        private void cancelAddressButton_Click(object sender, EventArgs e)
        {
            if (this.InternalState == AddressStates.Main)
            {
                this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
            else
            {
                this.InternalState = AddressStates.Main;
            }
        }

        private void changeToAddAddressState()
        {
            this.mainPanel.Visible = true;
            this.saveAddressButton.Visible = true;

            this.selectAddressButton.Visible = false;
            this.createAddressButton.Visible = false;
        }

        private void changeToMainState()
        {
            this.mainPanel.Visible = false;
            this.saveAddressButton.Visible = false;

            this.selectAddressButton.Visible = true;
            this.createAddressButton.Visible = true;
        }

    }
}
