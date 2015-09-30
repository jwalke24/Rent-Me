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

        private DataGridView currentDataGridView;

        private List<IRentMeUcInterface> userControlStack; 
        

        public MainWindow()
        {
            this.InitializeComponent();
            this.setUpWindow();
        }

        private void setUpWindow()
        {
            this.currentDataGridView = this.dataGridView;
            this.loginUser();

            this.transactionUserControl1.DataGrid = this.dataGridView;
            this.transactionUserControl1.StateChanged += this.StateChange;

            userControlStack = new List<IRentMeUcInterface>();
            userControlStack.Add(this.transactionUserControl1);
        }

        private void StateChange(object sender, EventArgs e)
        {
            IRentMeUcInterface theSender = (IRentMeUcInterface) sender;

            if (theSender.ControlType == UserControls.Transaction)
            {
                TransactionUserControl transactionUserControl = (TransactionUserControl) theSender;

                if (transactionUserControl.CurrentState == TransactionStates.Hiding)
                {
                    transactionUserControl.Enabled = false;
                    transactionUserControl.Visible = false;
                    transactionUserControl.StateChanged -= this.StateChange;

                    this.Controls.Remove(transactionUserControl);

                    if (transactionUserControl.switchTo == UserControls.Customer)
                    {
                        this.displayCustomer();



                    }
                    else if (transactionUserControl.switchTo == UserControls.Inventory)
                    {
                        this.displayInventory();
                    }
                }
            }
        }

        private void displayCustomer()
        {
            DataGridView newGrid = this.cloneNewDataGridView();
            CustomerUserControl custUC = new CustomerUserControl();
            custUC.DataGrid = newGrid;
            custUC.Enabled = true;
            custUC.Visible = true;
            custUC.Location = this.userControlLocation;

            this.Controls.Add(custUC);

            this.swapDataGridView(newGrid);
            this.userControlStack.Add(custUC);


        }


        private void displayInventory()
        {
            DataGridView newGrid = this.cloneNewDataGridView();
            InventoryUC inventoryUc = new InventoryUC();
            inventoryUc.DataGrid = newGrid;
            inventoryUc.Enabled = true;
            inventoryUc.Visible = true;
            inventoryUc.Location = this.userControlLocation;

            this.Controls.Add(inventoryUc);

            this.swapDataGridView(newGrid);
            this.userControlStack.Add(inventoryUc);
        }

        private DataGridView swapDataGridView(DataGridView newView)
        {
            DataGridView oldView = this.currentDataGridView;
            this.currentDataGridView = newView;
            oldView.Visible = false;
            oldView.Enabled = false;
            newView.Enabled = true;
            newView.Visible = true;

            this.Controls.Remove(oldView);
            this.Controls.Add(newView);

            this.Invalidate();

            return oldView;
        }


        private DataGridView cloneNewDataGridView()
        {
            DataGridView theNewView = new DataGridView();
            theNewView.Location = this.currentDataGridView.Location;
            theNewView.Size = this.currentDataGridView.Size;
            theNewView.Visible = true;
            theNewView.Enabled = true;

            return theNewView;
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

        private void logoutButton_Click(object sender, EventArgs e)
        {
            //TODO Ensure network requests are fulfilled.
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            this.Close();
        }

    }
}
