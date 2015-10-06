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


    public interface IRentMeUcInterface
    {
        /// <summary>
        /// Gets the type of the user control.
        /// </summary>
        /// <value>
        /// The type of the user control.
        /// </value>
        UserControls UserControlType
        {
            get;
        }

        /// <summary>
        /// Gets or sets the data grid.
        /// </summary>
        /// <value>
        /// The data grid.
        /// </value>
        DataGridView DataGrid
        {
            get; set;
        }

        /// <summary>
        /// Gets the current external state of this User Control.
        /// </summary>
        /// <value>
        /// The state of the current.
        /// </value>
        RentMeUserControlPrimaryStates CurrentState
        {
            get;
        }

        /// <summary>
        /// Gets the User Control that this UC Wants to switch to. 
        /// </summary>
        /// <value>
        /// The switch to.
        /// </value>
        UserControls SwitchTo
        {
            get;
        }

        /// <summary>
        /// This object is for storing the child UC that is called from this UC.
        /// </summary>
        /// <value>
        /// The child returned.
        /// </value>
        IRentMeUcInterface ChildReturned
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the parameter passed to child.
        /// </summary>
        /// <value>
        /// The parameter passed to child.
        /// </value>
        IRentMeUcInterface ParameterPassedToChild { get; set; }


        /// <summary>
        /// Occurs when external [state changed].
        /// </summary>
        event EventHandler StateChanged;

        /// <summary>
        /// Processes the child element in the parent class.
        /// </summary>
        void processChild();

        /// <summary>
        /// Processes the parameters.
        /// </summary>
        void processParameter();

    }
}
