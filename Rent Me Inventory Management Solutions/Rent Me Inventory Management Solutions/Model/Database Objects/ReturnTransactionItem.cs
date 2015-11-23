using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    class ReturnTransactionItem
    {
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the furniture identifier.
        /// </summary>
        /// <value>
        /// The furniture identifier.
        /// </value>
        public string FurnitureID { get; set; }
        /// <summary>
        /// Gets or sets the purchase transaction identifier.
        /// </summary>
        /// <value>
        /// The purchase transaction identifier.
        /// </value>
        public string  PurchaseTransactionID { get; set; }

        /// <summary>
        /// Gets or sets the return transaction identifier.
        /// </summary>
        /// <value>
        /// The return transaction identifier.
        /// </value>
        [Browsable(false)]
        public string ReturnTransactionId { get; set; }
    }
}
