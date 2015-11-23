using System;
using System.ComponentModel;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// This class represents a Purchase Transaction User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class PurchaseTransactionUC : BSMiddleClass
    {
        private TransactionController theController;
        private string CustomerID;

        public PurchaseTransaction SelectedTransaction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public PurchaseTransactionUC(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.theController = new TransactionController();
            InitializeComponent();
            UserControlType = UserControls.PurchaseTransaction;
        }

        /// <summary>
        /// Processes the child element in the parent class.
        /// </summary>
        public override void processChild()
        {

        }

        /// <summary>
        /// Processes the parameters.
        /// </summary>
        public override void processParentIntention()
        {
            this.CustomerID = (ParentParameter as ReturnTransactionUC)?.customerID;
            this.LoadData();
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            DataGrid.DataSource = new BindingList<PurchaseTransaction>(this.theController.GetPurchaseTransactionsByCustomerId(this.CustomerID));
        }

        private void viewPurchaseTransactionItemsButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.SelectedTransaction = this.DataGrid.SelectedRows[0].DataBoundItem as PurchaseTransaction;

                SwitchTo = UserControls.PurchaseTransactionItem;
                CurrentState = RentMeUserControlPrimaryStates.Hiding;
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("No Purchase Transaction Selected", "Please select a purchase transaction to view the items.");
            }
        }
    }
}
