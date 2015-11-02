using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    /// This class was created to fix a VS-problem which doesn't allow the Designer to work with inherited abstract classes. Do not instantiate!
    /// </summary>
    public class BSMiddleClass : RentMeUserControl
    {
        public override void processChild()
        {
            throw new NotImplementedException();
        }

        public override void processParentIntention()
        {
            throw new NotImplementedException();
        }
    }
}
