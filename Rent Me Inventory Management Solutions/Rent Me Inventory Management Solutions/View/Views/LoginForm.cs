using System;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.Views
{
    /// <summary>
    /// This class represents the login form window.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
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

                if (theUser.IsAuthenticated)
                {
                    Tag = theUser;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ErrorHandler.DisplayErrorBox("Login Error", "Invalid login information. Please try again.");
                }
            }
            else
            {
                ErrorHandler.DisplayErrorBox("Login Error", "Invalid login information. Please try again.");
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