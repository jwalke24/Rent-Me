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
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public enum InventoryStates
    {
        Main,
        Deleting
    }

    public partial class InventoryUC : BSMiddleClass
    {

        private FurnitureController theController;
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryUC"/> class.
        /// </summary>
        public InventoryUC(DataGridView theGrid)
        {
            this.DataGrid = theGrid;
            theController = new FurnitureController();
            InitializeComponent();
            this.UserControlType = UserControls.Inventory;
            this.loadInventory();
        }

        private void loadInventory()
        {
            BindingList<Furniture> theList = new BindingList<Furniture>(this.theController.GetAll());

            this.DataGrid.DataSource = theList;
        }

        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        public override void processChild()
        {
            
        }

        public override void processParentIntention()
        {
            
        }
    }
}
