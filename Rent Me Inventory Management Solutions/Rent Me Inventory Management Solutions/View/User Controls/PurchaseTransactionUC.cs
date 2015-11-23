using System.ComponentModel;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public PurchaseTransactionUC(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.theController = new TransactionController();
            InitializeComponent();
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
            ReturnTransactionUC theReturnTransactionUc;

            using (theReturnTransactionUc = ParentParameter as ReturnTransactionUC)
            {
                this.CustomerID = theReturnTransactionUc.customerID;
                this.LoadData();
            }
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            DataGrid.DataSource = new BindingList<PurchaseTransaction>(this.theController.GetPurchaseTransactionsByCustomerId(this.CustomerID));
        }
    }
}
