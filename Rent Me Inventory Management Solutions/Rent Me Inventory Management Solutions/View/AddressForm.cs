using Rent_Me_Inventory_Management_Solutions.Controller;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    public partial class AddressForm : Form
    {
        private AddressController addressController;

        public int AddressID { get; private set; }

        public AddressForm()
        {
            InitializeComponent();

            this.addressController = new AddressController();
            BindingList<Address> addresses = new BindingList<Address>(this.addressController.GetAllAddresses());

            this.addressDataGridView.DataSource = addresses;
        }

        private void selectAddressButton_Click(object sender, EventArgs e)
        {
            if (this.addressDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an address.");
            } else
            {
                AddressID = (int)this.addressDataGridView.SelectedRows[0].Cells["Id"].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
