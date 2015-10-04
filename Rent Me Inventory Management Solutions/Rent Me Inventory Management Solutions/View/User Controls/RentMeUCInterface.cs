using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    public enum RentMeUserControlPrimaryStates
    {
        Main,
        Hiding,
        Deleting
    }


    /// <summary>
    /// Different types of user controls. 
    /// </summary>
    public enum UserControls
    {
        Transaction,
        Admin,
        Inventory,
        Customer
    }


    interface IRentMeUcInterface
    {
        UserControls UserControlType
        {
            get;
        }

        DataGridView DataGrid
        {
            get; set;
        }

        RentMeUserControlPrimaryStates CurrentState
        {
            get;
        }

        UserControls SwitchTo
        {
            get;
        }
        

        event EventHandler StateChanged;


    }
}
