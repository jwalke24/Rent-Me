using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    
    public enum UserControls
    {
        Transaction,
        Admin,
        Inventory,
        Customer
    }

    public partial class MainWindow : Form
    {
        private readonly Point userControlLocation = new Point(13, 336);

        public MainWindow()
        {
            this.InitializeComponent();
            this.loginUser();

            this.transactionUserControl1.DataGrid = this.dataGridView;
            this.transactionUserControl1.StateChanged += this.StateChange;
            
        }

        private void StateChange(object sender, EventArgs e)
        {
            IRentMeUcInterface theSender = (IRentMeUcInterface) sender;

            if (theSender.ControlType == UserControls.Transaction)
            {
                TransactionUserControl transactionUserControl = (TransactionUserControl) theSender;

                if (transactionUserControl.switchTo == UserControls.Customer)
                {
                    
                } else if (transactionUserControl.switchTo == UserControls.Inventory)
                {
                    
                }
            }
        }

        private void loginUser()
        {
            var loginWindow = new LoginForm();
            DialogResult loginResult = loginWindow.ShowDialog(this);
            if (loginResult == DialogResult.OK)
            {
                this.Enabled = true;
                this.Opacity = 100;
            }
            else
            {
                this.Close();
            }
            
        }

    }
}
