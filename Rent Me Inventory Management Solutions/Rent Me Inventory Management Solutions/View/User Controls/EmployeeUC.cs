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
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum EmployeeStates
    {
        Main,
        AddEmployee
    }
    public partial class EmployeeUC :BSMiddleClass
    {
        private EmployeeController theController;
        public EmployeeUC(DataGridView theGrid)
        {
            this.DataGrid = theGrid;
            InitializeComponent();
            this.theController = new EmployeeController();
            this.loadEmployees();
        }

        private void loadEmployees()
        {
            BindingList<Employee> theList = new BindingList<Employee>(this.theController.GetAll());

            this.DataGrid.DataSource = theList;
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            this.InternalState = EmployeeStates.AddEmployee;
        }
        private EmployeeStates internalState;

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

        public override void processChild()
        {
            switch (ChildReturned.UserControlType)
            {
                case UserControls.Address:
                    AddressUC test = (AddressUC) this.ChildReturned;
                    this.addressTextBox.Text = test.AddressID;
                    break;

            }
        }

        public override void processParentIntention()
        {
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Address;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.theController.AddEmployee(new Employee
            {
                AddressId = this.addressTextBox.Text,
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                PhoneNumber = this.phoneTextBox.Text,
                SSN = this.ssnTextBox.Text,
                isAdmin = this.adminCheckBox.Checked
            }, this.passwordTextBox.Text);

            this.loadEmployees();
            this.InternalState = EmployeeStates.Main;
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.InternalState = EmployeeStates.Main;
        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (this.DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please select an employee to delete.");
            }
            else
            {

                string deleteId = ((string)this.DataGrid.SelectedRows[0].Cells["ID"].Value);

                this.theController.DeleteEmployeeById(deleteId);

                this.loadEmployees();


            }
        }
    }
}
