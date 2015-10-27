using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.TopMost = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            EmployeeController theController = new EmployeeController();
            int id = 0;

            Int32.TryParse(this.usernameTextBox.Text, out id);

            this.DialogResult = DialogResult.None;

            if (id != 0)
            {

                LoginSession theUser = theController.ValidateUserOnNetwork(id, this.passwordTextBox.Text);

                if (theUser.isAuthenticated)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    
                }
                
            }

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }
    }
}
