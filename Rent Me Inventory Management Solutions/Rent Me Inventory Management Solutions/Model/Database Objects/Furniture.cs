﻿using System.ComponentModel;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    internal class Furniture
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public uint Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>
        ///     The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        ///     Gets or sets the late fee.
        /// </summary>
        /// <value>
        ///     The late fee.
        /// </value>
        public decimal LateFee { get; set; }

        /// <summary>
        ///     Gets or sets the category identifier.
        /// </summary>
        /// <value>
        ///     The category identifier.
        /// </value>
        [Browsable(false)]
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        /// <summary>
        ///     Gets or sets the style identifier.
        /// </summary>
        /// <value>
        ///     The style identifier.
        /// </value>
        [Browsable(false)]
        public string StyleID { get; set; }

        public string StyleName { get; set; }
    }
}