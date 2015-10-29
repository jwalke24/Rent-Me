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
    public partial class CategoryStyleUC : BSMiddleClass
    {
        public CategoryStyleUC(DataGridView theGrid)
        {
            this.UserControlType = UserControls.CategoryStyle;
            InitializeComponent();
            this.DataGrid = theGrid;
        }

        public override void processChild()
        {
            
        }

        public override void processParentIntention()
        {
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }
    }
}
