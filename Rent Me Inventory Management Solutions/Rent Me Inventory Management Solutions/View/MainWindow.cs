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
     
            userControlStack = new List<IRentMeUcInterface>();

            this.displayNewTransaction();
        }

        private void StateChange(object sender, EventArgs e)
        {
            IRentMeUcInterface theSender = (IRentMeUcInterface) sender;

            if (theSender.CurrentState == RentMeUserControlPrimaryStates.Hiding)
            {
                this.removeUCFromDisplay(theSender);

                switch (theSender.SwitchTo)
                {
                    case UserControls.Inventory:
                        this.displayNewInventory();
                        break;
                    case UserControls.Customer:
                        this.displayNewCustomer();
                        break;
                }
            } else if (theSender.CurrentState == RentMeUserControlPrimaryStates.Deleting)
            {
                this.removeUCFromDisplay(theSender);
                this.popOffUserControlStack(theSender);
            }

        }

        private void removeUCFromDisplay(IRentMeUcInterface userControl)
        {
            UserControl uc = (UserControl) userControl;

            uc.Enabled = false;
            uc.Visible = false;

            this.Controls.Remove(uc);

            userControl.StateChanged -= this.StateChange;
        }

        private void addUCToDisplay(IRentMeUcInterface ucInterface)
        {
            UserControl userControl = (UserControl) ucInterface;

            userControl.Enabled = true;
            userControl.Visible = true;
            userControl.Location = this.userControlLocation;

            this.swapDataGridView(ucInterface.DataGrid);
            ucInterface.StateChanged += this.StateChange;
            
            this.Controls.Add(userControl);
        }

        private void popOffUserControlStack(IRentMeUcInterface customerUserControl)
        {

            if (this.userControlStack.Count < 2)
            {
                return;
            }
            
            this.userControlStack.RemoveAt(this.userControlStack.Count - 1);

            IRentMeUcInterface newUcInterface = this.userControlStack[this.userControlStack.Count - 1];
            UserControl newUserControl = (UserControl) newUcInterface;
            newUserControl.Enabled = true;
            newUserControl.Visible = true;
            newUserControl.Location = this.userControlLocation;

            this.swapDataGridView(newUcInterface.DataGrid);
            newUcInterface.StateChanged += this.StateChange;

            this.Controls.Add(newUserControl);

        }

        private void displayNewCustomer()
        {
            DataGridView newGrid = this.cloneNewDataGridView();
            CustomerUserControl custUC = new CustomerUserControl();
            custUC.DataGrid = newGrid;

            this.userControlStack.Add(custUC);

            this.addUCToDisplay(custUC);


        }


        private void displayNewInventory()
        {
            DataGridView newGrid = this.cloneNewDataGridView();
            InventoryUC inventoryUc = new InventoryUC();
            inventoryUc.DataGrid = newGrid;

            this.userControlStack.Add(inventoryUc);

            this.addUCToDisplay(inventoryUc);
        }

        private void displayNewTransaction()
        {
            DataGridView newGrid = this.cloneNewDataGridView();
            TransactionUC transactionUc = new TransactionUC();
            transactionUc.DataGrid = newGrid;

            this.userControlStack.Add(transactionUc);

            this.addUCToDisplay(transactionUc);
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
