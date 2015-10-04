using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    public enum CustomerStates
    {
        Main,
        Deleting
    }

    public partial class CustomerUserControl : UserControl, IRentMeUcInterface
    {

        public UserControls ControlType { get; set; }
        public DataGridView DataGrid { get; set; }
        /// <summary>
        /// Occurs when [state changed].
        /// </summary>
        public event EventHandler StateChanged;

        private CustomerStates currentState;

        public CustomerStates CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }
        public CustomerUserControl()
        {
            this.InitializeComponent();
            this.ControlType = UserControls.Customer;
        }


        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = CustomerStates.Deleting;
        }

        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
