using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// This class represents a Purchase Transaction Item User Control.
    /// </summary>
    /// <author>Jonathan Walker and Jonah Nestrick</author>
    /// <version>Fall 2015</version>
    public partial class PurchaseTransactionItemUC : BSMiddleClass
    {
        private readonly PurchaseTransactionItemController theController;
        private PurchaseTransaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionItemUC" /> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public PurchaseTransactionItemUC(DataGridView theGrid)
        {
            InitializeComponent();
            DataGrid = theGrid;
            this.theController = new PurchaseTransactionItemController();
        }

        private void loadItems()
        {
            try
            {
                DataGrid.DataSource = new BindingList<PurchaseTransaction_Item>(this.theController.GetAllItemsByPurchaseTransaction(this.transaction));
            }
            catch (MySqlException)
            {
                ErrorHandler.DisplayErrorBox("Database Exception", "There was a problem loading the purchase transaction items.");
            }
        }

        /// <summary>
        ///     Processes the child element in the parent class.
        /// </summary>
        public override void processChild()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Processes the parameters.
        /// </summary>
        public override void processParentIntention()
        {
            PurchaseTransactionUC purchaseTransactionUc;

            using (purchaseTransactionUc = ParentParameter as PurchaseTransactionUC)
            {
                this.transaction = purchaseTransactionUc.SelectedTransaction;
                this.loadItems();
            }

        }
    }
}
