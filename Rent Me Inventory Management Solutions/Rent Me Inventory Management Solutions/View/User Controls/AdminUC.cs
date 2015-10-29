﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public partial class AdminUC :BSMiddleClass
    {
        public AdminUC(DataGridView theGrid, LoginSession theSession)
        {
            if (theSession.isAdmin == true && theSession.isAuthenticated == true)
            {
                this.DataGrid = theGrid;
                InitializeComponent();
                this.UserControlType = UserControls.Admin;
                this.theSession = theSession;
            }
        }

        public LoginSession theSession { get; private set; }

        public override void processChild()
        {
            
        }

        public override void processParentIntention()
        {
            
        }

        private void returnEmployeeButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        private void editCustomersButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Customer;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editEmployeesButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Employee;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editInventoryButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Inventory;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editCatStyleButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.CategoryStyle;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }
    }
}
