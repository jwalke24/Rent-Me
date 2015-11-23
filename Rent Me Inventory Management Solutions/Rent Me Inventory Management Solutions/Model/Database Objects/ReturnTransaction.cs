using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    class ReturnTransaction
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the return time.
        /// </summary>
        /// <value>
        /// The return time.
        /// </value>
        public DateTime returnTime { get; set; }

        /// <summary>
        /// Gets or sets the employee_id.
        /// </summary>
        /// <value>
        /// The employee_id.
        /// </value>
        public string Employee_id { get; set; }
    }
}
