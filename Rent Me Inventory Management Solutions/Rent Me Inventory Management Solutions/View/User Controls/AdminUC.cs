using System;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public partial class AdminUC : BSMiddleClass
    {
        /// <summary>
        ///     Gets the session.
        /// </summary>
        /// <value>
        ///     The session.
        /// </value>
        public LoginSession theSession { get; private set; }

        public AdminUC(DataGridView theGrid, LoginSession theSession)
        {
            if (theSession.isAdmin && theSession.isAuthenticated)
            {
                DataGrid = theGrid;
                this.InitializeComponent();
                UserControlType = UserControls.Admin;
                this.theSession = theSession;
            }
        }

        public override void processChild()
        {
        }

        public override void processParentIntention()
        {
        }

        private void returnEmployeeButton_Click(object sender, EventArgs e)
        {
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        private void editCustomersButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Customer;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editEmployeesButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Employee;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editInventoryButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.Inventory;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editCatStyleButton_Click(object sender, EventArgs e)
        {
            SwitchTo = UserControls.CategoryStyle;
            CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }
    }
}