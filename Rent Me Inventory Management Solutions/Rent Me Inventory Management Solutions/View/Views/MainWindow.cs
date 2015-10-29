using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{

    public partial class MainWindow : Form
    {
        private readonly Point userControlLocation = new Point( 13, 336);

        private readonly Point dataGridViewLocation = new Point( 13, 13);

        private readonly Size dataGridViewSize = new Size( 840, 316);

        private DataGridView currentDataGridView;

        private List<RentMeUserControl> userControlStack;

        private Timer dateTimeTimer;
        private LoginSession loginSession;


        public MainWindow()
        {
            this.InitializeComponent();
            this.setUpWindow();

            this.dateTimeTimer = new Timer();
            this.dateTimeTimer.Interval = 5000;
            this.dateTimeTimer.Enabled = true;
            this.dateTimeTimer.Tick += DateTimeTimerOnTick;
            this.DateTimeTimerOnTick(null, null);

        }


        private void setUpWindow()
        {
            this.loginUser();
            
     
            userControlStack = new List<RentMeUserControl>();

            this.displayNewTransaction();
        }

        private void DateTimeTimerOnTick(object sender, EventArgs eventArgs)
        {
            this.dateLabel.Text = DateTime.Now.ToShortDateString();
            this.timeLabel.Text = DateTime.Now.ToShortTimeString();
        }

        private void StateChange(object sender, EventArgs e)
        {
            if (sender == null)
            {
                
                foreach(var item in userControlStack)
                {
                    if (item.UserControlType == UserControls.Admin)
                    {
                        return;
                    }
                }

                this.removeUCFromDisplay(this.userControlStack[this.userControlStack.Count - 1]);
                this.displayNewAdmin();
                return;
            }

            RentMeUserControl theSender = (RentMeUserControl) sender;

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
                    case UserControls.Address:
                        this.displayNewAddress();
                        break;
                    case UserControls.Employee:
                        this.displayNewEmployee();
                        break;
                    case UserControls.CategoryStyle:
                        this.displayNewCategoryStyle();
                        break;
                }
            } else if (theSender.CurrentState == RentMeUserControlPrimaryStates.Deleting)
            {
                this.removeUCFromDisplay(theSender);
                this.popOffUserControlStack(theSender);
            }

        }

       


        private void removeUCFromDisplay(RentMeUserControl userControl)
        {
            UserControl uc = (UserControl) userControl;

            uc.Enabled = false;
            uc.Visible = false;

            this.Controls.Remove(uc);

            userControl.StateChanged -= this.StateChange;
        }

        private void addUCToDisplay(RentMeUserControl ucInterface)
        {
            UserControl userControl = (UserControl) ucInterface;

            userControl.Enabled = true;
            userControl.Visible = true;
            userControl.Location = this.userControlLocation;

            this.swapDataGridView(ucInterface.DataGrid);
            ucInterface.StateChanged += this.StateChange;
            
            this.Controls.Add(userControl);

            if (this.userControlStack.Count >= 2)
            {
                ucInterface.ParentParameter = this.userControlStack[this.userControlStack.Count - 2];
                ucInterface.processParentIntention();

            }

        }

        private void popOffUserControlStack(RentMeUserControl customerUserControl)
        {

            if (this.userControlStack.Count < 2)
            {
                return;
            }

            RentMeUserControl previousUC = this.userControlStack[this.userControlStack.Count - 1];

            this.userControlStack.RemoveAt(this.userControlStack.Count - 1);

            RentMeUserControl newUcInterface = this.userControlStack[this.userControlStack.Count - 1];
            UserControl newUserControl = (UserControl) newUcInterface;
            newUserControl.Enabled = true;
            newUserControl.Visible = true;
            newUserControl.Location = this.userControlLocation;

            newUcInterface.ChildReturned = previousUC;

            this.swapDataGridView(newUcInterface.DataGrid);
            newUcInterface.StateChanged += this.StateChange;

            this.Controls.Add(newUserControl);

            newUcInterface.processChild();

        }

        private void displayNewCustomer()
        {
            CustomerUserControl custUC = new CustomerUserControl(this.createNewDataGridView());

            this.userControlStack.Add(custUC);

            this.addUCToDisplay(custUC);


        }

        private void displayNewCategoryStyle()
        {
            CategoryStyleUC categoryUC = new CategoryStyleUC(this.createNewDataGridView());

            this.userControlStack.Add(categoryUC);

            this.addUCToDisplay(categoryUC);
        }

        private void displayNewEmployee()
        {
            EmployeeUC employeeUC = new EmployeeUC(this.createNewDataGridView());

            this.userControlStack.Add(employeeUC);

            this.addUCToDisplay(employeeUC);
        }

        private void displayNewAddress()
        {
            AddressUC addressUc = new AddressUC(this.createNewDataGridView());

            this.userControlStack.Add(addressUc);

            this.addUCToDisplay(addressUc);

            
        }


        private void displayNewInventory()
        {
            InventoryUC inventoryUc = new InventoryUC();
            inventoryUc.DataGrid = this.createNewDataGridView();

            this.userControlStack.Add(inventoryUc);

            this.addUCToDisplay(inventoryUc);
        }

        private void displayNewTransaction()
        {
            TransactionUC transactionUc = new TransactionUC();
            transactionUc.DataGrid = this.createNewDataGridView();

            this.userControlStack.Add(transactionUc);

            this.addUCToDisplay(transactionUc);
        }

        private void displayNewAdmin()
        {
            AdminUC adminUc = new AdminUC();
            adminUc.DataGrid = this.createNewDataGridView();

            this.userControlStack.Add(adminUc);

            this.addUCToDisplay(adminUc);
        }

        private void swapDataGridView(DataGridView newView)
        {
            if (this.currentDataGridView != null)
            {
                DataGridView oldView = this.currentDataGridView;
                oldView.Visible = false;
                oldView.Enabled = false;
                this.Controls.Remove(oldView);
            }
            
            this.currentDataGridView = newView;
            newView.Enabled = true;
            newView.Visible = true;

            this.Controls.Add(newView);

            this.Invalidate();
        }


        private DataGridView createNewDataGridView()
        {
            DataGridView theNewView = new DataGridView();
            theNewView.Location = this.dataGridViewLocation;
            theNewView.Size = this.dataGridViewSize;
            theNewView.Visible = true;
            theNewView.Enabled = true;
            theNewView.ReadOnly = true;
            theNewView.BackgroundColor = DefaultBackColor;
            

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
                this.loginSession = loginWindow.Tag as LoginSession;
                this.verifyAdminRights();
            }
            else
            {
                this.Close();
            }
            
        }

        private void verifyAdminRights()
        {
            if (this.loginSession.isAdmin)
            {
                this.adminOptionButton.Visible = true;
            }
            else
            {
                this.adminOptionButton.Visible = false;
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            //TODO Ensure network requests are fulfilled.
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            this.Close();
        }

        private void adminOptionButton_Click(object sender, EventArgs e)
        {
            if (this.loginSession.isAdmin)
            {
                this.StateChange(null, null);
            }
        }
    }
}
