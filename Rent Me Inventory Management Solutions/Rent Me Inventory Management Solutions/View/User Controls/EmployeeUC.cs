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
    public partial class EmployeeUC : UserControl, IRentMeUcInterface
    {
        private EmployeeController theController;
        public EmployeeUC(DataGridView theGrid)
        {
            this.DataGrid = theGrid;
            InitializeComponent();
            this.theController = new EmployeeController();
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            this.InternalState = EmployeeStates.AddEmployee;
        }

        public UserControls UserControlType { get; }
        public DataGridView DataGrid { get; set; }
        public RentMeUserControlPrimaryStates CurrentState
        {
            get { return this.currentState; }
            private set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }
        public UserControls SwitchTo { get; private set; }
        public IRentMeUcInterface ChildReturned { get; set; }
        public IRentMeUcInterface ParentParameter { get; set; }
        public event EventHandler StateChanged;

        private EmployeeStates internalState;
        private RentMeUserControlPrimaryStates currentState;

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

        public void processChild()
        {
            using (AddressUC test = this.ChildReturned as AddressUC)
            {
                if (test != null)
                {
                    this.addressTextBox.Text = test.AddressID;
                }
            }
        }

        public void processParentIntention()
        {
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
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

            this.InternalState = EmployeeStates.Main;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.InternalState = EmployeeStates.Main;
        }
    }
}
