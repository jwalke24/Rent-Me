﻿using System;
using System.Globalization;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    internal enum TransactionStates
    {
        Main,
        AddItem,
        Hiding,
        Deleting
    }

    public partial class TransactionUserControl : UserControl, IRentMeUcInterface
    {
        private const double TAX_RATE = 0.07;

        #region Properties And Variables
        public DataGridView DataGrid { get; set; }

        public event EventHandler StateChanged;

        public UserControls SwitchTo { get; private set; }

        public UserControls ControlType { get; set; }

        private TransactionStates currentState;

        private string customerID
        {
            get { return this.customerIDLabel.Text; }

            set { this.customerIDLabel.Text = value; }
        }

        private double subtotal;

        private double Subtotal
        {
            get { return this.subtotal; }
            set
            {
                this.subtotal = value;
                this.taxLabel.Text = (value*TAX_RATE).ToString("C", CultureInfo.CurrentCulture);
                this.subtotalLabel.Text = this.subtotal.ToString("C",CultureInfo.CurrentCulture);
                this.totalLabel.Text = (value * (1+ TAX_RATE)).ToString("C", CultureInfo.CurrentCulture);
            }
        }



        #endregion

        internal TransactionStates CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;

                switch (this.currentState)
                {
                    case TransactionStates.Main:
                        changeToMainState();
                        break;
                    case TransactionStates.AddItem:
                        changeToAddItemState();
                        break;
                }

                this.OnStateChanged();
            }
        }

        public TransactionUserControl()
        {
            this.InitializeComponent();
            this.Subtotal = 41985.323568;
        }

        
        

        private void changeToAddItemState()
        {
            //Enable
            this.addItemConfirmButton.Visible = true;
            this.addItemConfirmButton.Enabled = true;
            this.cancelItemConfirmButton.Enabled = true;
            this.cancelItemConfirmButton.Visible = true;
            this.itemToAddTextBox.Enabled = true;
            this.itemToAddTextBox.Visible = true;

            //Disable
            this.DataGrid.Enabled = false;
            this.addItemButton.Enabled = false;
            this.voidItemButton.Enabled = false;
            this.voidTransactionButton.Enabled = false;
            this.submitTransactionButton.Enabled = false;
            this.customerButton.Enabled = false;
            this.inventoryButton.Enabled = false;

        }

        private void changeToMainState()
        {
            //Disable
            this.addItemConfirmButton.Visible = false;
            this.addItemConfirmButton.Enabled = false;
            this.cancelItemConfirmButton.Enabled = false;
            this.cancelItemConfirmButton.Visible = false;
            this.itemToAddTextBox.Enabled = false;
            this.itemToAddTextBox.Visible = false;

            //Enable
            this.DataGrid.Enabled = true;
            this.addItemButton.Enabled = true;
            this.voidItemButton.Enabled = true;
            this.voidTransactionButton.Enabled = true;
            this.submitTransactionButton.Enabled = true;
            this.customerButton.Enabled = true;
            this.inventoryButton.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = TransactionStates.AddItem;
        }

        private void addItemConfirmButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = TransactionStates.Main;
        }

        private void cancelItemConfirmButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = TransactionStates.Main;
        }

        protected virtual void OnStateChanged()
        {
            var handler = this.StateChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Customer;
            this.CurrentState = TransactionStates.Hiding;
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Inventory;
            this.CurrentState = TransactionStates.Hiding;
        }
    }
}