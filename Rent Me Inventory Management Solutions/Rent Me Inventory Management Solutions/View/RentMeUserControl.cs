﻿using System;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    public enum RentMeUserControlPrimaryStates
    {
        Main,
        Hiding,
        Deleting
    }


    /// <summary>
    ///     Different types of user controls.
    /// </summary>
    public enum UserControls
    {
        Transaction,
        Admin,
        Inventory,
        Customer,
        Address,
        Employee,
        Return,
        PurchaseTransaction,
        PurchaseTransactionItem
    }


    /// <summary>
    /// This class provides a template for all other User Controls.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public abstract class RentMeUserControl : UserControl
    {
        /// <summary>
        ///     Gets the type of the user control.
        /// </summary>
        /// <value>
        ///     The type of the user control.
        /// </value>
        public UserControls UserControlType { get; protected set; }

        /// <summary>
        ///     Gets or sets the data grid.
        /// </summary>
        /// <value>
        ///     The data grid.
        /// </value>
        public DataGridView DataGrid { get; set; }

        /// <summary>
        ///     Gets the current external state of this User Control.
        /// </summary>
        /// <value>
        ///     The state of the current.
        /// </value>
        public RentMeUserControlPrimaryStates CurrentState
        {
            get { return this.currentState; }
            protected set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }

        /// <summary>
        ///     Gets the User Control that this UC Wants to switch to.
        /// </summary>
        /// <value>
        ///     The switch to.
        /// </value>
        public UserControls SwitchTo { get; protected set; }

        /// <summary>
        ///     This object is for storing the child UC that is called from this UC.
        /// </summary>
        /// <value>
        ///     The child returned.
        /// </value>
        public RentMeUserControl ChildReturned { get; set; }

        /// <summary>
        ///     Gets or sets the parameter passed to child.
        /// </summary>
        /// <value>
        ///     The parameter passed to child.
        /// </value>
        public RentMeUserControl ParentParameter { get; set; }

        private RentMeUserControlPrimaryStates currentState;

        /// <summary>
        ///     Occurs when external [state changed].
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        ///     Processes the child element in the parent class.
        /// </summary>
        public abstract void processChild();

        /// <summary>
        ///     Processes the parameters.
        /// </summary>
        public abstract void processParentIntention();

        /// <summary>
        /// Called when [state changed].
        /// </summary>
        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}