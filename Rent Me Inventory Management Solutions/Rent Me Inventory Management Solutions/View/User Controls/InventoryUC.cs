﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using Rent_Me_Inventory_Management_Solutions.Static;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// The various inventory states.
    /// </summary>
    public enum InventoryStates
    {
        Main,
        Adding,
        Editing
    }

    /// <summary>
    /// This class represents an Inventory User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class InventoryUC : BSMiddleClass
    {
        private InventoryStates InternalState
        {
            get { return this.internalState; }
            set
            {
                this.internalState = value;
                this.DataGrid.SelectionChanged -= this.DataGridOnSelectionChanged;
                this.clearValues();
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

        private void clearValues()
        {
            this.nameTextBox.Text = string.Empty;
            this.descriptionTextBox.Text = string.Empty;
            this.quantityTextBox.Text = string.Empty;
            this.lateFeeTextBox.Text = string.Empty;
            this.priceTextBox.Text = string.Empty;
        }

        private void DataGridOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            if (this.InternalState == InventoryStates.Editing)
            {
                if (DataGrid.SelectedRows.Count == 0)
                {
                    return;
                }

                Furniture item = (Furniture)this.DataGrid.SelectedRows[0].DataBoundItem;

                this.nameTextBox.Text = item.Name;
                this.priceTextBox.Text = item.Price.ToString();
                this.lateFeeTextBox.Text = item.LateFee.ToString();
                this.descriptionTextBox.Text = item.Description;
                this.quantityTextBox.Text = item.Quantity.ToString();

                foreach (var style in this.styleComboBox.Items)
                {
                    Style tempStyle = style as Style;

                    if (tempStyle != null && tempStyle.Id == item.StyleId)
                    {
                        this.styleComboBox.SelectedItem = tempStyle;
                    }
                }

                foreach (var category in this.categoryComboBox.Items)
                {
                    Category tempCategory = category as Category;

                    if (tempCategory != null && tempCategory.Id == item.StyleId)
                    {
                        this.categoryComboBox.SelectedItem = tempCategory;
                    }
                }


            }
        }

        /// <summary>
        /// Gets the furniture identifier.
        /// </summary>
        /// <value>
        /// The furniture identifier.
        /// </value>
        public string FurnitureID { get; private set; }
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
            this.styleComboBox.Items.Clear();
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
            this.categoryComboBox.Items.Clear();

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
            if (adminUc != null && adminUc.theSession.IsAdmin && adminUc.theSession.IsAuthenticated)
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
            if (this.theSession != null && this.theSession.IsAuthenticated && this.theSession.IsAdmin)
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
                var result = this.theController.GetItemsFromIdWildcard(id);
                DataGrid.DataSource = new BindingList<Furniture>(result);
            }
            catch (MySqlException exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Network Error", "Unable to search the database for this object. Please try again.", exception);
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please enter a numerical value.");
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
            string itemID = string.Empty;
            try
            {
                itemID = (DataGrid.SelectedRows[0].DataBoundItem as Furniture)?.Id;
            }
            catch (Exception)
            {
                ErrorHandler.DisplayErrorBox("Error", "No item selected.");
            }
            var theCategory = this.categoryComboBox.SelectedItem as Category;
            var theStyle = this.styleComboBox.SelectedItem as Style;
            decimal price;
            uint quantity;
            decimal lateFee;
            if (string.IsNullOrEmpty(itemID) || theCategory == null || theStyle == null || this.nameTextBox.Text == string.Empty ||
                this.priceTextBox.Text == string.Empty || this.quantityTextBox.Text == string.Empty ||
                this.descriptionTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter a valid value for every field.");
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
                this.theController.UpdateItem(theCategory, theStyle, this.nameTextBox.Text, this.descriptionTextBox.Text,
                    price,
                    quantity, lateFee, itemID);
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error",
                    "Failed to update item in the inventory. Please try again.", exception);
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
            ErrorHandler.DisplayErrorBox("Not Implemented","This feature is not implemented.");

            /*if (DataGrid.SelectedRows.Count == 0)
            {
                ErrorHandler.DisplayErrorBox("Error", "Please select an item to delete.");
                return;
            }

            try
            {
                var deleteId = ((string)DataGrid.SelectedRows[0].Cells["Id"].Value);

                this.theController.DeleteFurnitureById(deleteId);

                this.loadAllData();
            }
            catch (Exception exception)
            {
                ErrorHandler.DisplayErrorMessageToUserAndLog("Error", "Failed to delete item from database.", exception);
            }*/
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.InternalState = InventoryStates.Editing;
        }

        private void selectItemButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"You must select an item before you can add it.");
            }
            else
            {
                this.FurnitureID = (DataGrid.SelectedRows[0].DataBoundItem as Furniture)?.Id;
                this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }
    }
}