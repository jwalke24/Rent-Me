using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public partial class PurchaseTransactionUC : BSMiddleClass
    {
        private TransactionController theController;
        private string CustomerID;
        public PurchaseTransactionUC(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.theController = new TransactionController();
            InitializeComponent();
        }

        public override void processChild()
        {

        }

        public override void processParentIntention()
        {
            ReturnTransactionUC theReturnTransactionUc;

            using (theReturnTransactionUc = ParentParameter as ReturnTransactionUC)
            {
                this.CustomerID = theReturnTransactionUc.customerID;
                this.LoadData();
            }
        }

        public void LoadData()
        {
            DataGrid.DataSource = new BindingList<PurchaseTransaction>(this.theController.GetPurchaseTransactionsByCustomerID(this.CustomerID));
        }
    }
}
