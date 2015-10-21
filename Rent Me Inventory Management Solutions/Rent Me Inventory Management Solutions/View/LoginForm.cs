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
            NetworkController theController = new NetworkController();
            int id = 0;
            Console.WriteLine(this.usernameTextBox.Text);
            try
            {
                id = Int32.Parse(this.usernameTextBox.Text);
            } catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
                //generate message for numbers only.
            }

            LoginSession theUser = theController.ValidateUserOnNetwork(id, this.passwordTextBox.Text);

            if (theUser.isAuthenticated == false)
            {
                return;
            }

            this.Tag = theUser;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
