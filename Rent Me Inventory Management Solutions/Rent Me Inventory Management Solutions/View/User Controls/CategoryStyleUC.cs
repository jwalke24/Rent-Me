using System;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// This class represents a Category and Style User Control.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public partial class CategoryStyleUC : BSMiddleClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryStyleUC"/> class.
        /// </summary>
        /// <param name="theGrid">The grid.</param>
        public CategoryStyleUC(DataGridView theGrid)
        {
            UserControlType = UserControls.CategoryStyle;
            this.InitializeComponent();
            DataGrid = theGrid;
        }

        /// <summary>
        /// Processes the child element in the parent class.
        /// </summary>
        public override void processChild()
        {
        }

        /// <summary>
        /// Processes the parameters.
        /// </summary>
        public override void processParentIntention()
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CurrentState = RentMeUserControlPrimaryStates.Deleting;
        }
    }
}