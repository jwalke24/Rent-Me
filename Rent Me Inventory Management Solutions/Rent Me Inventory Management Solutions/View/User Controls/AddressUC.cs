using System;
using System.ComponentModel;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum AddressStates
    {
        Main,
        AddAddress
    }

    /// <summary>
    /// This class represents an Address User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class AddressUC : BSMiddleClass
    {
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
        ///     Gets the address identifier.
        /// </summary>
        /// <value>
        ///     The address identifier.
        /// </value>
        public string AddressID { get; private set; }

        private readonly AddressController theController;
        private AddressStates internalState;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public AddressUC(DataGridView theGrid)
        {
            UserControlType = UserControls.Address;
            DataGrid = theGrid;

            this.InitializeComponent();

            this.theController = new AddressController();

            this.loadAddresses();
        }

        private void loadAddresses()
        {
            var theAddresses = new BindingList<Address>(this.theController.GetAllAddresses());

            DataGrid.DataSource = theAddresses;
        }

        /// <summary>
        /// Processes the child.
        /// </summary>
        public override void processChild()
        {
        }

        /// <summary>
        /// Processes the parent intention.
        /// </summary>
        public override void processParentIntention()
        {
        }

        private void selectAddressButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please select an address.");
            }
            else
            {
                this.AddressID = DataGrid.SelectedRows[0].Cells["Id"].Value.ToString();
                CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }

        private void createAddressButton_Click(object sender, EventArgs e)
        {
            this.InternalState = AddressStates.AddAddress;
        }

        private void saveAddressButton_Click(object sender, EventArgs e)
        {
            if (this.street1TextBox.Text == string.Empty || this.cityTextBox.Text == string.Empty ||
                this.stateTextBox.Text == string.Empty || this.zipTextBox.Text == string.Empty)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please enter a value for required fields.");
                return;
            }

            try
            {
                int.Parse(this.zipTextBox.Text);
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please enter a valid zip code.");
                return;
            }

            if (this.stateTextBox.Text.Length != 2)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please enter a valid state.");
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
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Failed to add address to database. Please try again.", exception);
            }
        }

        private void cancelAddressButton_Click(object sender, EventArgs e)
        {
            if (this.InternalState == AddressStates.Main)
            {
                CurrentState = RentMeUserControlPrimaryStates.Deleting;
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