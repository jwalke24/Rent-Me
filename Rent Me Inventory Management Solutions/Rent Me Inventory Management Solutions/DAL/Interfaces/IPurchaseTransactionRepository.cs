using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    /// <summary>
    /// This is an interface for the Purchase Transaction Repository.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal interface IPurchaseTransactionRepository : IRepository<PurchaseTransaction>
    {
        /// <summary>
        /// Gets the transactions by customer identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<PurchaseTransaction> GetTransactionsByCustomerId(string id);
    }
}
