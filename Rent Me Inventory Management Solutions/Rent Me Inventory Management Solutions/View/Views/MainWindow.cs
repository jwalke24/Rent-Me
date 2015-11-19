using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    public partial class MainWindow : Form
    {
        private readonly Point dataGridViewLocation = new Point(13, 13);
        private readonly Size dataGridViewSize = new Size(840, 316);
        private readonly Timer dateTimeTimer;
        private readonly Point userControlLocation = new Point(13, 336);
        private DataGridView currentDataGridView;
        private LoginSession loginSession;
        private List<RentMeUserControl> userControlStack;

        public MainWindow()
        {
            this.InitializeComponent();
            this.setUpWindow();

            this.dateTimeTimer = new Timer();
            this.dateTimeTimer.Interval = 5000;
            this.dateTimeTimer.Enabled = true;
            this.dateTimeTimer.Tick += this.DateTimeTimerOnTick;
            this.DateTimeTimerOnTick(null, null);
        }

        private void setUpWindow()
        {
            this.loginUser();


            this.userControlStack = new List<RentMeUserControl>();

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
                foreach (var item in this.userControlStack)
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

            var theSender = (RentMeUserControl) sender;

            if (theSender.CurrentState == RentMeUserControlPrimaryStates.Hiding)
            {
                this.removeUCFromDisplay(theSender);

                DataGridView dataGrid = this.createNewDataGridView();

                switch (theSender.SwitchTo)
                {
                    case UserControls.Inventory:
                        
                        this.displayNewUserControl(new InventoryUC(dataGrid));
                        break;
                    case UserControls.Customer:
                        this.displayNewUserControl(new CustomerUserControl(dataGrid));
                        break;
                    case UserControls.Address:
                        this.displayNewUserControl(new AddressUC(dataGrid));
                        break;
                    case UserControls.Employee:
                        this.displayNewUserControl(new EmployeeUC(dataGrid));
                        break;
                    case UserControls.CategoryStyle:
                        this.displayNewUserControl(new CategoryStyleUC(dataGrid));
                        break;
                    case UserControls.Return:
                        this.displayNewUserControl(new ReturnTransactionUC(dataGrid));
                        break;
                    case UserControls.PurchaseTransaction:
                        this.displayNewUserControl(new PurchaseTransactionUC(dataGrid));
                        break;
                }
            }
            else if (theSender.CurrentState == RentMeUserControlPrimaryStates.Deleting)
            {
                this.removeUCFromDisplay(theSender);
                this.popOffUserControlStack(theSender);
            }
        }

        private void removeUCFromDisplay(RentMeUserControl userControl)
        {
            UserControl uc = userControl;

            uc.Enabled = false;
            uc.Visible = false;

            Controls.Remove(uc);

            userControl.StateChanged -= this.StateChange;
        }

        private void addUCToDisplay(RentMeUserControl ucInterface)
        {
            UserControl userControl = ucInterface;

            userControl.Enabled = true;
            userControl.Visible = true;
            userControl.Location = this.userControlLocation;

            this.swapDataGridView(ucInterface.DataGrid);
            ucInterface.StateChanged += this.StateChange;

            Controls.Add(userControl);

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

            var previousUC = this.userControlStack[this.userControlStack.Count - 1];

            this.userControlStack.RemoveAt(this.userControlStack.Count - 1);

            var newUcInterface = this.userControlStack[this.userControlStack.Count - 1];
            UserControl newUserControl = newUcInterface;
            newUserControl.Enabled = true;
            newUserControl.Visible = true;
            newUserControl.Location = this.userControlLocation;

            newUcInterface.ChildReturned = previousUC;

            this.swapDataGridView(newUcInterface.DataGrid);
            newUcInterface.StateChanged += this.StateChange;

            Controls.Add(newUserControl);

            newUcInterface.processChild();
        }

        private void displayNewUserControl(RentMeUserControl uc)
        {
            this.userControlStack.Add(uc);
            this.addUCToDisplay(uc);
        }

        private void displayNewTransaction()
        {
            var transactionUc = new TransactionUC(this.createNewDataGridView(), this.loginSession);

            this.userControlStack.Add(transactionUc);

            this.addUCToDisplay(transactionUc);
        }

        private void displayNewAdmin()
        {
            var adminUc = new AdminUC(this.createNewDataGridView(), this.loginSession);

            this.userControlStack.Add(adminUc);

            this.addUCToDisplay(adminUc);
        }

        private void swapDataGridView(DataGridView newView)
        {
            if (this.currentDataGridView != null)
            {
                var oldView = this.currentDataGridView;
                oldView.Visible = false;
                oldView.Enabled = false;
                Controls.Remove(oldView);
            }

            this.currentDataGridView = newView;
            newView.Enabled = true;
            newView.Visible = true;

            Controls.Add(newView);

            Invalidate();
        }

        private DataGridView createNewDataGridView()
        {
            var theNewView = new DataGridView();
            theNewView.Location = this.dataGridViewLocation;
            theNewView.Size = this.dataGridViewSize;
            theNewView.Visible = true;
            theNewView.Enabled = true;
            theNewView.ReadOnly = true;
            theNewView.MultiSelect = false;
            theNewView.AllowUserToAddRows = false;
            theNewView.BackgroundColor = DefaultBackColor;
            theNewView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            return theNewView;
        }

        private void loginUser()
        {
            var loginWindow = new LoginForm();
            var loginResult = loginWindow.ShowDialog(this);

            if (loginResult == DialogResult.OK)
            {
                Enabled = true;
                Opacity = 100;
                this.loginSession = loginWindow.Tag as LoginSession;
                this.verifyAdminRights();
            }
            else
            {
                Close();
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
            Process.Start(Application.ExecutablePath);
            Close();
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