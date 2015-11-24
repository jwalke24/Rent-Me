using System;
using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    /// <summary>
    /// This class is responsible for managing Transactions.
    /// </summary>
    /// <author>Jonathan Walker and Jonah Nestrick</author>
    /// <version>Fall 2015</version>
    internal class TransactionController
    {
        private readonly IPurchaseTransactionRepository purchaseRepository;
        private readonly IPurchaseTransactionItemRepository purchaseItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        public TransactionController()
        {
            this.purchaseRepository = new PurchaseTransactionRepository();
            this.purchaseItemRepository = new PurchaseTransactionItemRepository();
        }

        /// <summary>
        /// Adds the purchase transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public void AddPurchaseTransaction(PurchaseTransaction transaction)
        {
            
            var id = this.purchaseRepository.AddOne(transaction);
            transaction.Id = id;

            try
            {
                foreach (var item in transaction.Items)
                {
                    item.PurchaseTransactionId = id;
                }

                this.purchaseItemRepository.AddList(transaction.Items);
            }
            catch (Exception)
            {
                this.deleteChangesFromDatabase(transaction.Items, id);

                throw;
            }
        }

        private void deleteChangesFromDatabase(List<PurchaseTransaction_Item> items, string id)
        {
            
            //Deletes all the items that were added to the database. 

            foreach (var item in items)
            {
                try
                {
                    this.purchaseItemRepository.Delete(item);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            try
            {
                this.purchaseRepository.DeleteById(id);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        /// Gets the purchase transactions by customer identifier.
        /// </summary>
        /// <param name="customerID">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IList<PurchaseTransaction> GetPurchaseTransactionsByCustomerId(string customerID)
        {
            if (string.IsNullOrEmpty(customerID))
                throw new ArgumentNullException(nameof(customerID));

            return this.purchaseRepository.GetTransactionsByCustomerId(customerID);
        }

        public PurchaseTransaction GetByID(string purchaseTransactionId)
        {
            if (string.IsNullOrEmpty(purchaseTransactionId))
            {
                throw new ArgumentNullException(nameof(purchaseTransactionId));
            }

            return this.purchaseRepository.GetById(purchaseTransactionId);
        }
    }
}
