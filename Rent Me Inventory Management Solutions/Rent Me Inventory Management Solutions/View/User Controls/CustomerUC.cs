using System;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    internal enum CustomerStates
    {
        Main
    }

    public partial class CustomerUserControl : UserControl, IRentMeUcInterface
    {

        public UserControls UserControlType { get; private set; }
        public DataGridView DataGrid { get; set; }
        public UserControls SwitchTo { get; private set; }

        /// <summary>
        /// Occurs when [state changed].
        /// </summary>
        public event EventHandler StateChanged;

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
        public CustomerUserControl()
        {
            this.InitializeComponent();
            this.UserControlType = UserControls.Customer;
        }


        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
