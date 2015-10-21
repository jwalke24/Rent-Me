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

            Int32.TryParse(this.usernameTextBox.Text, out id);

            if (id == 0)
            {
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }

            LoginSession theUser = theController.ValidateUserOnNetwork(id, this.passwordTextBox.Text);

            this.Tag = theUser;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
