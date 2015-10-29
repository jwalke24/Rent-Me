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

    public partial class InventoryUC : BSMiddleClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryUC"/> class.
        /// </summary>
        public InventoryUC()
        {
            InitializeComponent();
            this.UserControlType = UserControls.Inventory;
        }

        private void ucCancelButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }

        public override void processChild()
        {
            
        }

        public override void processParentIntention()
        {
            
        }
    }
}
