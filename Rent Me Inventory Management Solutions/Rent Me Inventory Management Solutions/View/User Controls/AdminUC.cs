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
    public partial class AdminUC : UserControl,IRentMeUcInterface
    {
        public AdminUC()
        {
            InitializeComponent();
            this.UserControlType = UserControls.Admin;
        }

        /// <summary>
        /// Gets or sets the type of the control.
        /// </summary>
        /// <value>
        /// The type of the control.
        /// </value>
        public UserControls UserControlType { get; private set; }
        /// <summary>
        /// Gets or sets the data grid.
        /// </summary>
        /// <value>
        /// The data grid.
        /// </value>
        public DataGridView DataGrid { get; set; }

        private RentMeUserControlPrimaryStates currentState;
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
        public IRentMeUcInterface ParameterPassedToChild { get; set; }

        /// <summary>
        /// Occurs when [state changed].
        /// </summary>
        public event EventHandler StateChanged;

        public void processChild()
        {
            
        }

        public void processParameter()
        {
            
        }

        /// <summary>
        /// Called when [state changed].
        /// </summary>
        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void returnEmployeeButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        private void editCustomersButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Customer;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editEmployeesButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Customer;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }

        private void editInventoryButton_Click(object sender, EventArgs e)
        {
            this.SwitchTo = UserControls.Inventory;
            this.CurrentState = RentMeUserControlPrimaryStates.Hiding;
        }
    }
}
