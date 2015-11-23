using System.Collections;
using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    /// <summary>
    /// This is an interface for the Purchase Transaction Item Repository.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal interface IPurchaseTransactionItemRepository : IRepository<PurchaseTransaction_Item>
    {
        /// <summary>
        /// Gets all items by purchase transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        IList<PurchaseTransaction_Item> GetAllItemsByPurchaseTransaction(PurchaseTransaction transaction);
    }
}
