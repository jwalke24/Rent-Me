using System;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.InitializeComponent();
            TopMost = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var theController = new EmployeeController();
            var id = 0;

            int.TryParse(this.usernameTextBox.Text, out id);

            DialogResult = DialogResult.None;

            if (id != 0)
            {
                var theUser = new LoginSession();
                try
                {
                    theUser = theController.ValidateUserOnNetwork(id, this.passwordTextBox.Text);
                }
                catch (Exception exception)
                {
                    ErrorHandler.DisplayErrorMessageToUserAndLog("Network Error",
                        "Unable to connect to SQL Database. Please try again.", exception);
                }

                if (theUser.isAuthenticated)
                {
                    Tag = theUser;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ErrorHandler.displayErrorBox("Login Error", "Invalid login information. Please try again.");
                }
            }
            else
            {
                ErrorHandler.displayErrorBox("Login Error", "Invalid login information. Please try again.");
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }
    }
}