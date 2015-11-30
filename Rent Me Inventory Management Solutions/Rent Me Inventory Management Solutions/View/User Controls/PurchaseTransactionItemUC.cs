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
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public PurchaseTransaction_Item SelectedItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionItemUC" /> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public PurchaseTransactionItemUC(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.theController = new PurchaseTransactionItemController();
            InitializeComponent();
            UserControlType = UserControls.PurchaseTransactionItem;
        }

        private void loadItems()
        {
            try
            {
                DataGrid.DataSource = new BindingList<PurchaseTransaction_Item>(this.theController.GetAllItemsByPurchaseTransaction(this.transaction));
                var dataGridViewColumn = DataGrid.Columns["FurnitureId"];
                if (dataGridViewColumn != null)
                {
                    dataGridViewColumn.Visible = false;
                }
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
            this.transaction = (ParentParameter as PurchaseTransactionUC)?.SelectedTransaction;
            this.loadItems();


        }

        private void selectItemButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                ErrorHandler.DisplayErrorBox("No Item Selected", "Please select an item to return.");
            }else if (this.quantityTextBox.Text == "")
            {
                ErrorHandler.DisplayErrorBox("Quantity Not Specified", "Please set the quantity of the item you would like to return.");
            }
            else
            {
                this.SelectedItem = DataGrid.SelectedRows[0].DataBoundItem as PurchaseTransaction_Item;

                try
                {
                    int quantity = int.Parse(this.quantityTextBox.Text);
                    if (quantity > this.SelectedItem.ReturnableQuantity || quantity <= 0)
                        throw new ArgumentException();
                    this.SelectedItem.Quantity = quantity;
                }
                catch (ArgumentException)
                {
                    if (this.SelectedItem.ReturnableQuantity == 0)
                    {
                        ErrorHandler.DisplayErrorBox("Quantity Error", "Those items have already been returned.");
                    }
                    else
                    {
                        ErrorHandler.DisplayErrorBox("Quantity Error", "You must select a non-zero value less than or equal to " + this.SelectedItem.ReturnableQuantity + ".");
                    }
                    return;
                }
                catch
                {
                    ErrorHandler.DisplayErrorBox("Invalid Quantity","Please enter a valid quantity.");
                    return;
                }
                CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.SelectedItem = null;
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }
    }
}
