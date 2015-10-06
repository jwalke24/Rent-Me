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
            this.UserControlType = UserControls.Inventory;
        }

        /// <summary>
        /// Gets or sets the type of the control.
        /// </summary>
        /// <value>
        /// The type of the control.
        /// </value>
        public UserControls UserControlType { get; set; }

        public RentMeUserControlPrimaryStates currentState;

        public RentMeUserControlPrimaryStates CurrentState
        {
            get { return this.currentState; }
            private set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }

        public UserControls SwitchTo { get; private set; }
        public IRentMeUcInterface ChildReturned { get; set; }
        public IRentMeUcInterface ParentParameter { get; set; }

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

        public void processChild()
        {
            
        }

        public void processParentIntention()
        {
            
        }

        /// <summary>
        /// Called when [state changed].
        /// </summary>
        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }
    }
}
