using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// This class represents an Admin User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class AdminUC : BSMiddleClass
    {
        /// <summary>
        ///     Gets the session.
        /// </summary>
        /// <value>
        ///     The session.
        /// </value>
        public LoginSession theSession { get; private set; }

        private GenericSqlController theController;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        /// <param name="theSession">The session.</param>
        public AdminUC(DataGridView theGrid, LoginSession theSession)
        {
            if (theSession.IsAdmin && theSession.IsAuthenticated)
            {
                DataGrid = theGrid;
                this.InitializeComponent();
                UserControlType = UserControls.Admin;
                this.theSession = theSession;
                this.theController = new GenericSqlController();
            }
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

        private void executeSQLButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet result = this.theController.ExecuteQuery(this.sqlQueryBox.Text);
                try
                {
                    DataGrid.DataSource = result.Tables[0];
                }
                catch
                {
                    MessageBox.Show("Query successful. ", "SQL Successful", MessageBoxButtons.OK);
                }
            }
            catch (MySqlException exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("SQL Error",
                    "There was an issue with your SQL statement. Please try again.", exception);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Unknown Error", "There was an unknown error. Please try again.", exception);
            }
        }
    }
}