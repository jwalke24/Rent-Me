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
        Adding
    }

    public partial class InventoryUC : BSMiddleClass
    {
        private readonly Point categoryStyleDefaultLocation = new Point(1, -1);

        private FurnitureController theController;

        private InventoryStates internalState;

        private InventoryStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;

                switch (value)
                {
                    case InventoryStates.Main:
                        this.changeToMainState();
                        break;
                    case InventoryStates.Adding:
                        this.changeToAddingState();
                        break;
                }
            }
        }

        private void changeToAddingState()
        {
            this.searchButton.Visible = false;
            this.itemPanel.Visible = false;
            this.selectItemButton.Visible = false;
            this.addItemButton.Visible = false;

            this.addPanel.Visible = true;
            this.saveItemButton.Visible = true;

            this.categoryStylePanel.Location = this.itemPanel.Location;


        }

        private void changeToMainState()
        {
            this.searchButton.Visible = true;
            this.itemPanel.Visible = true;
            this.selectItemButton.Visible = true;
            this.addItemButton.Visible = true;

            this.addPanel.Visible = false;
            this.saveItemButton.Visible = false;

            this.categoryStylePanel.Location = this.categoryStyleDefaultLocation;

        }

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
            if (this.InternalState == InventoryStates.Main)
            {
                this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
            else
            {
                this.InternalState = InventoryStates.Main;
            }
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

        private void addItemButton_Click(object sender, EventArgs e)
        {
            this.InternalState = InventoryStates.Adding;
            
        }

        private void saveItemButton_Click(object sender, EventArgs e)
        {
            Category theCategory = this.categoryComboBox.SelectedItem as Category;
            Style theStyle = this.styleComboBox.SelectedItem as Style;
            decimal price;
            uint quantity;

            if (theCategory == null || theStyle == null || this.nameTextBox.Text == string.Empty ||
                this.priceTextBox.Text == string.Empty || this.quantityTextBox.Text == string.Empty ||
                this.descriptionTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter a value for every field.");
                return;
            }


            try
            {
                price = Decimal.Parse(this.priceTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid price for this item.");
                return;
            }

            try
            {
                quantity = UInt32.Parse(this.quantityTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid quantity.");
                return;
            }

            this.theController.AddItem(theCategory, theStyle, this.nameTextBox.Text, this.descriptionTextBox.Text, price,
                quantity);

            this.loadAllData();

            this.InternalState = InventoryStates.Main;

        }
    }
}
