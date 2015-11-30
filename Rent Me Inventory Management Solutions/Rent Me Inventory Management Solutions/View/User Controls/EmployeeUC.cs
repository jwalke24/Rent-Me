using System;
using System.ComponentModel;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// The various employee states.
    /// </summary>
    internal enum EmployeeStates
    {
        Main,
        AddEmployee
    }

    /// <summary>
    /// This class represents an Employee User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class EmployeeUC : BSMiddleClass
    {
        private EmployeeStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;
                if (value == EmployeeStates.Main)
                {
                    this.changeToMainState();
                }
                else if (value == EmployeeStates.AddEmployee)
                {
                    this.changeToAddEmployeeState();
                }
            }
        }


        private readonly EmployeeController theController;
        private EmployeeStates internalState;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public EmployeeUC(DataGridView theGrid)
        {
            UserControlType = UserControls.Employee;
            DataGrid = theGrid;
            this.InitializeComponent();
            this.theController = new EmployeeController();
            this.loadEmployees();
        }

        private void loadEmployees()
        {
            var theList = new BindingList<Employee>(this.theController.GetAll());

            DataGrid.DataSource = theList;
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            this.InternalState = EmployeeStates.AddEmployee;
        }

        private void changeToAddEmployeeState()
        {
            this.panel1.Visible = true;

            this.createEmployeeButton.Visible = false;
            this.deleteEmployeeButton.Visible = false;
            this.backButton.Visible = false;
        }

        private void changeToMainState()
        {
            this.panel1.Visible = false;

            this.createEmployeeButton.Visible = true;
            this.deleteEmployeeButton.Visible = true;
            this.backButton.Visible = true;

            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.ssnTextBox.Text = "";
            this.adminCheckBox.Checked = false;
            this.phoneTextBox.Text = "";
            this.passwordTextBox.Text = "";
            this.addressTextBox.Text = "";
        }

        /// <summary>
        /// Processes the child element in the parent class.
        /// </summary>
        public override void processChild()
        {
            switch (ChildReturned.UserControlType)
            {
                case UserControls.Address:
                    var test = (AddressUC) ChildReturned;
                    this.addressTextBox.Text = test.AddressID;
                    break;
            }
        }

        /// <summary>
        /// Processes the parameters.
        /// </summary>
        public override void processParentIntention()
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Address;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.addressTextBox.Text == string.Empty || this.firstNameTextBox.Text == string.Empty ||
                this.lastNameTextBox.Text == string.Empty || this.phoneTextBox.Text == string.Empty ||
                this.ssnTextBox.Text == string.Empty || this.passwordTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter a value for every field.");
                return;
            }

            if (this.phoneTextBox.Text.Length != 10)
            {
                ErrorHandler.DisplayErrorBox("Phone Number Invalid", "Please enter a valid 10 digit phone number.");
                return;
            }

            try
            {
                long.Parse(this.phoneTextBox.Text);
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("Phone Number Invalid", "Please enter a valid 10 digit phone number.");
                return;
            }

            if (this.ssnTextBox.Text.Length != 9)
            {
                ErrorHandler.DisplayErrorBox("SSN Invalid", "Please enter a valid 9 digit SSN.");
                return;
            }

            try
            {
                uint.Parse(this.ssnTextBox.Text);
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("SSN Invalid", "Please enter a valid 9 digit SSN.");
                return;
            }

            try
            {
                Employee anEmployee = new Employee
                {
                    FirstName = this.firstNameTextBox.Text,
                    LastName = this.lastNameTextBox.Text,
                    PhoneNumber = this.phoneTextBox.Text,
                    SSN = this.ssnTextBox.Text,
                    IsAdmin = this.adminCheckBox.Checked,
                    EmployeeAddress = {Id = this.addressTextBox.Text}
                };


                this.theController.AddEmployee(anEmployee, this.passwordTextBox.Text);

                this.loadEmployees();
                this.InternalState = EmployeeStates.Main;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Failed to add employee to database. Please try again.", exception);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.InternalState = EmployeeStates.Main;
        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            ErrorHandler.DisplayErrorBox("Not Implemented", "This feature is not implemented.");


            /*if (DataGrid.SelectedRows.Count == 0)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please select an employee to delete.");
                return;
            }

            try
            {
                var deleteId = ((string) DataGrid.SelectedRows[0].Cells["Id"].Value);

                this.theController.DeleteEmployeeById(deleteId);

                this.loadEmployees();
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error", "Failed to delete employee from database.",
                    exception);
            }*/
        }
    }
}