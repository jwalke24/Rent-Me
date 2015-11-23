using System.ComponentModel;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    /// <summary>
    /// This class represents a Purchase Transaction item.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public class PurchaseTransaction_Item
    {
        /// <summary>
        /// Gets or sets the furniture identifier.
        /// </summary>
        /// <value>
        /// The furniture identifier.
        /// </value>
        public string FurnitureId { get; set; }

        /// <summary>
        /// Gets or sets the name of the furniture.
        /// </summary>
        /// <value>
        /// The name of the furniture.
        /// </value>
        public string FurnitureName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the lease time.
        /// </summary>
        /// <value>
        /// The lease time.
        /// </value>
        public int LeaseTime { get; set; }

        /// <summary>
        /// Gets or sets the purchase transaction identifier.
        /// </summary>
        /// <value>
        /// The purchase transaction identifier.
        /// </value>
        [Browsable(false)]
        public string PurchaseTransactionId { get; set; }
    }
}
