using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public enum InventoryStates
    {
        Main,
        Deleting
    }

    public partial class InventoryUC : UserControl,IRentMeUcInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryUC"/> class.
        /// </summary>
        public InventoryUC()
        {
            InitializeComponent();
            this.ControlType = UserControls.Inventory;
        }

        /// <summary>
        /// Gets or sets the type of the control.
        /// </summary>
        /// <value>
        /// The type of the control.
        /// </value>
        public UserControls ControlType { get; set; }

        public InventoryStates currentState;

        public InventoryStates CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }
        /// <summary>
        /// Gets or sets the data grid.
        /// </summary>
        /// <value>
        /// The data grid.
        /// </value>
        public DataGridView DataGrid { get; set; }
        /// <summary>
        /// Occurs when [state changed].
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        /// Called when [state changed].
        /// </summary>
        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = InventoryStates.Deleting;
        }
    }
}
