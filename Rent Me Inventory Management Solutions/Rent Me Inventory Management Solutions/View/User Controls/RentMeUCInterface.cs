using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    interface IRentMeUcInterface
    {
        UserControls ControlType
        {
            get; set;
        }

        DataGridView DataGrid
        {
            get; set;
        }

        
    }
}
