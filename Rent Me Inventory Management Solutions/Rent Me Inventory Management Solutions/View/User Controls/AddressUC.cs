using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public partial class AddressUC : UserControl,IRentMeUcInterface
    {
        private AddressController theController;


        public AddressUC(DataGridView theGrid)
        {
            this.DataGrid = theGrid;

            InitializeComponent();

            this.theController = new AddressController();

            BindingList<Address> theAddresses = new BindingList<Address>(this.theController.GetAllAddresses());

            this.DataGrid.DataSource = theAddresses;

        }

        public UserControls UserControlType { get; }
        public DataGridView DataGrid { get; set; }

        private RentMeUserControlPrimaryStates currentState;

        public RentMeUserControlPrimaryStates CurrentState {
            get { return this.currentState; }
            private set
            {
                this.currentState = value;
                this.OnStateChanged();
            }
        }
        public UserControls SwitchTo { get; }
        public IRentMeUcInterface ChildReturned { get; set; }
        public IRentMeUcInterface ParentParameter { get; set; }
        public event EventHandler StateChanged;

        public string AddressID { get; private set; }


        public void processChild()
        {
            
        }

        public void processParentIntention()
        {
            
        }

        private void selectAddressButton_Click(object sender, EventArgs e)
        {

            if (this.DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please select an address.");
            }
            else
            {
                this.AddressID = ((int)this.DataGrid.SelectedRows[0].Cells["Id"].Value).ToString();
                this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
            }
        }

        protected virtual void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
