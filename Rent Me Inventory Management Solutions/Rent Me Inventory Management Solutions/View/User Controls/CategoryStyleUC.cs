using System;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public partial class CategoryStyleUC : BSMiddleClass
    {
        public CategoryStyleUC(DataGridView theGrid)
        {
            UserControlType = UserControls.CategoryStyle;
            this.InitializeComponent();
            DataGrid = theGrid;
        }

        public override void processChild()
        {
        }

        public override void processParentIntention()
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }
    }
}