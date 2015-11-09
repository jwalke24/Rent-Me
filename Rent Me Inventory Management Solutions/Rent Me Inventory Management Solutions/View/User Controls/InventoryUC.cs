using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public enum InventoryStates
    {
        Main,
        Adding,
        Editing
    }

    public partial class InventoryUC : BSMiddleClass
    {
        private InventoryStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;
                this.DataGrid.SelectionChanged -= this.DataGridOnSelectionChanged;

                switch (value)
                {   
                    case InventoryStates.Main:
                        this.changeToMainState();
                        break;
                    case InventoryStates.Adding:
                        this.changeToAddingState();
                        break;
                    case InventoryStates.Editing:


                        this.DataGrid.SelectionChanged += DataGridOnSelectionChanged;
                        this.changeToAddingState();
                        break;
                }
            }
        }

        private void DataGridOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            if (this.InternalState == InventoryStates.Editing)
            {
                if (DataGrid.SelectedRows.Count == 0)
                {
                    return;
                }

                Furniture item = (Furniture) this.DataGrid.SelectedRows[0].DataBoundItem;

                this.nameTextBox.Text = item.Name;
                this.priceTextBox.Text = item.Price.ToString();
                this.lateFeeTextBox.Text = item.LateFee.ToString();
                this.descriptionTextBox.Text = item.Description;
                this.quantityTextBox.Text = item.Quantity.ToString();

                foreach (var style in this.styleComboBox.Items)
                {
                    Style tempStyle = style as Style;

                    if (tempStyle != null && tempStyle.ID == item.StyleID)
                    {
                        this.styleComboBox.SelectedItem = tempStyle;
                    }
                }

                foreach (var category in this.categoryComboBox.Items)
                {
                    Category tempCategory = category as Category;

                    if (tempCategory != null && tempCategory.ID == item.StyleID)
                    {
                        this.categoryComboBox.SelectedItem = tempCategory;
                    }
                }


            }
        }

        private readonly Point categoryStyleDefaultLocation = new Point(1, -1);
        private readonly FurnitureController theController;
        private InventoryStates internalState;
        private LoginSession theSession;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InventoryUC" /> class.
        /// </summary>
        public InventoryUC(DataGridView theGrid)
        {
            DataGrid = theGrid;
            this.theController = new FurnitureController();
            this.InitializeComponent();
            UserControlType = UserControls.Inventory;
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
            try
            {
                this.styleComboBox.Items.Add("All");

                var catController = new CategoryStyleController();


                var styles = catController.GetAllStyles();


                foreach (var style in styles)
                {
                    this.styleComboBox.Items.Add(style);
                }

                this.styleComboBox.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Cannot Access Database",
                    "An error occured while loading this form.", exception);
            }
        }

        private void LoadCategories()
        {
            try
            {
                this.categoryComboBox.Items.Add("All");
                var catController = new CategoryStyleController();

                var categories = catController.GetAllCategories();

                foreach (var category in categories)
                {
                    this.categoryComboBox.Items.Add(category);
                }

                this.categoryComboBox.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Cannot Access Database",
                    "An error occured while loading this form.", exception);
            }
        }

        private void loadInventory()
        {
            try
            {
                var theList = new BindingList<Furniture>(this.theController.GetAll());

                DataGrid.DataSource = theList;
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Cannot Access Database",
                    "An error occured while loading this form.", exception);
            }
        }

        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            if (this.InternalState == InventoryStates.Main)
            {
                CurrentState = RentMeUserControlPrimaryStates.Deleting;
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
            if (ParentParameter == null)
            {
                return;
            }

            switch (ParentParameter.UserControlType)
            {
                case UserControls.Admin:
                    this.proccessAdminParent(ParentParameter as AdminUC);
                    break;
            }
        }

        private void proccessAdminParent(AdminUC adminUc)
        {
            if (adminUc != null && adminUc.theSession.isAdmin && adminUc.theSession.isAuthenticated)
            {
                this.theSession = adminUc.theSession;
                this.verifyAdminButtonsMainState();
            }
        }

        private void changeToAddingState()
        {
            this.searchButton.Visible = false;
            this.itemPanel.Visible = false;
            this.selectItemButton.Visible = false;
            this.addItemButton.Visible = false;
            this.editButton.Visible = false;
            this.deleteButton.Visible = false;

            this.addPanel.Visible = true;
            this.saveItemButton.Visible = true;

            this.categoryStylePanel.Location = this.itemPanel.Location;
        }

        private void changeToMainState()
        {
            this.searchButton.Visible = true;
            this.itemPanel.Visible = true;
            this.selectItemButton.Visible = true;

            this.addPanel.Visible = false;
            this.saveItemButton.Visible = false;

            this.categoryStylePanel.Location = this.categoryStyleDefaultLocation;

            this.verifyAdminButtonsMainState();
        }

        private void verifyAdminButtonsMainState()
        {
            if (this.theSession != null && this.theSession.isAuthenticated && this.theSession.isAdmin)
            {
                this.addItemButton.Visible = true;
                this.editButton.Visible = true;
                this.deleteButton.Visible = true;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var result = this.theController.GetItemsByCategoryStyle(this.categoryComboBox.SelectedItem as Category,
                this.styleComboBox.SelectedItem as Style);
            DataGrid.DataSource = new BindingList<Furniture>(result);
        }

        private void idGoButton_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(this.idSearchTextBox.Text);
                var result = this.theController.GetItemsFromIDWildcard(id);
                DataGrid.DataSource = new BindingList<Furniture>(result);
            }
            catch (Exception)
            {
                ErrorHandler.displayErrorBox("Error", "Please enter a numerical value.");
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            this.InternalState = InventoryStates.Adding;
        }

        private void saveItemButton_Click(object sender, EventArgs e)
        {
            if (this.InternalState == InventoryStates.Adding)
            {
                this.SaveNewItem();
            }
            else
            {
                this.UpdateItem();
            }
        }

        private void UpdateItem()
        {
            var theCategory = this.categoryComboBox.SelectedItem as Category;
            var theStyle = this.styleComboBox.SelectedItem as Style;
            decimal price;
            uint quantity;
            decimal lateFee;
            if (theCategory == null || theStyle == null || this.nameTextBox.Text == string.Empty ||
                this.priceTextBox.Text == string.Empty || this.quantityTextBox.Text == string.Empty ||
                this.descriptionTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter a value for every field.");
                return;
            }


            try
            {
                price = decimal.Parse(this.priceTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid price for this item.");
                return;
            }

            try
            {
                lateFee = decimal.Parse(this.lateFeeTextBox.Text);
            }
            catch
            {
                lateFee = decimal.Zero;
                return;
            }


            try
            {
                quantity = uint.Parse(this.quantityTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid quantity.");
                return;
            }
            try
            {
                this.theController.AddItem(theCategory, theStyle, this.nameTextBox.Text, this.descriptionTextBox.Text,
                    price,
                    quantity, lateFee);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Failed to add item to inventory. Please try again.", exception);
            }

            this.loadAllData();

            this.InternalState = InventoryStates.Main;
        }

        private void SaveNewItem()
        {
            var theCategory = this.categoryComboBox.SelectedItem as Category;
            var theStyle = this.styleComboBox.SelectedItem as Style;
            decimal price;
            uint quantity;
            decimal lateFee;
            if (theCategory == null || theStyle == null || this.nameTextBox.Text == string.Empty ||
                this.priceTextBox.Text == string.Empty || this.quantityTextBox.Text == string.Empty ||
                this.descriptionTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter a value for every field.");
                return;
            }


            try
            {
                price = decimal.Parse(this.priceTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid price for this item.");
                return;
            }

            try
            {
                lateFee = decimal.Parse(this.lateFeeTextBox.Text);
            }
            catch
            {
                lateFee = decimal.Zero;
                return;
            }


            try
            {
                quantity = uint.Parse(this.quantityTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid quantity.");
                return;
            }
            try
            {
                this.theController.AddItem(theCategory, theStyle, this.nameTextBox.Text, this.descriptionTextBox.Text,
                    price,
                    quantity, lateFee);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Failed to add item to inventory. Please try again.", exception);
            }

            this.loadAllData();

            this.InternalState = InventoryStates.Main;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                ErrorHandler.displayErrorBox("Error", "Please select an item to delete.");
                return;
            }

            try
            {
                var deleteId = ((string) DataGrid.SelectedRows[0].Cells["ID"].Value);

                this.theController.DeleteFurnitureById(deleteId);

                this.loadAllData();
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error", "Failed to delete item from database.", exception);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.InternalState = InventoryStates.Editing;
        }
    }
}