using System;
using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    /// <summary>
    /// This class is responsible for managing Purchase Transaction Items.
    /// </summary>
    /// <author>Jonathan Walker and Jonah Nestrick</author>
    /// <version>Fall 2015</version>
    internal class PurchaseTransactionItemController
    {
        private readonly PurchaseTransactionItemRepository itemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionItemController"/> class.
        /// </summary>
        public PurchaseTransactionItemController()
        {
            this.itemRepository = new PurchaseTransactionItemRepository();
        }

        /// <summary>
        /// Gets all items by purchase transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns>
        /// The purchase transaction's items.
        /// </returns>
        public IList<PurchaseTransaction_Item> GetAllItemsByPurchaseTransaction(PurchaseTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException();
            }

            return this.itemRepository.GetAllItemsByPurchaseTransaction(transaction);
        }
    }
}
