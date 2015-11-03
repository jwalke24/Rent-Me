using System;
using System.Collections;
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
            this.theController = new FurnitureController();
            this.InitializeComponent();
            this.UserControlType = UserControls.Inventory;
            this.loadAllData();
        }

        private void loadAllData()
        {
            this.loadInventory();
            this.LoadCategories();
            this.LoadStyles();
        }

        private void LoadStyles()
        {
            this.styleComboBox.Items.Add("All");
            
            CategoryStyleController catController = new CategoryStyleController();

            IList<Style> styles = catController.GetAllStyles();

            
            foreach (var style in styles)
            {
                this.styleComboBox.Items.Add(style);
            }

            this.styleComboBox.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            this.categoryComboBox.Items.Add("All");
            CategoryStyleController catController = new CategoryStyleController();
            
            IList<Category> categories = catController.GetAllCategories();

            foreach (var category in categories)
            {
                this.categoryComboBox.Items.Add(category);
            }

            this.categoryComboBox.SelectedIndex = 0;
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            IList<Furniture> result = this.theController.GetItemsByCategoryStyle(this.categoryComboBox.SelectedItem as Category, this.styleComboBox.SelectedItem as Style);
            this.DataGrid.DataSource = new BindingList<Furniture>(result);
        }

        private void idGoButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(this.idSearchTextBox.Text);
                IList<Furniture> result = this.theController.GetItemsFromIDWildcard(id);
                this.DataGrid.DataSource = new BindingList<Furniture>(result);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Please enter a numerical value.");
            }
            
            
        }
    }
}
